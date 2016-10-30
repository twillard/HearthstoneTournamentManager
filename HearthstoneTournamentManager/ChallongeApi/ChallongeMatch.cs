using System;
using System.Net;
using System.Runtime.Serialization.Json;

public class ChallongeMatch
{
    private string m_username;
    private string m_apiKey;
    private string m_tournamentId;
    private Util.Logger m_logger;

    private ChallongeSchema.MatchInfo m_match;

    private ChallongeSchema.ParticipantInfo m_player1;
    private ChallongeSchema.ParticipantInfo m_player2;

    public ChallongeMatch(
        string username,
        string apiKey,
        string tournamentId,
        ChallongeSchema.MatchInfo match,
        ChallongeSchema.ParticipantInfo player1,
        ChallongeSchema.ParticipantInfo player2,
        Util.Logger logger)
    {
        m_username = username;
        m_apiKey = apiKey;
        m_tournamentId = tournamentId;
        m_logger = logger;

        m_match = match;
        m_player1 = player1;
        m_player2 = player2;
    }

    public int GetMatchId()
    {
        return m_match.Id;
    }

    public void SetWinner(string winnerName)
    {
        string uri;
        if (winnerName == m_player1.Name)
        {
            uri = CreateModifyMatchUri(m_match.Id, m_player1.Id, true);
        }
        else
        {
            uri = CreateModifyMatchUri(m_match.Id, m_player2.Id, false);
        }
        Request(uri);
    }

    private void Request(string uri)
    {
        try
        {
            ChallongeSchema.MatchWrapper match = MakeRequest(uri);
            if (match != null)
            {
                ProcessResponse(match);
            }
        }
        catch (Exception e)
        {
            m_logger.LogError(e.Message);
            Console.WriteLine(e.Message);
        }
    }

    private string CreateModifyMatchUri(int matchId, int winnerId, bool player1Wins)
    {
        string scores;

        if (player1Wins)
        {
            scores = "1-0";
        }
        else
        {
            scores = "0-1";
        }

        string UrlRequest = String.Format("https://api.challonge.com/v1/tournaments/{0}/matches/{1}.json?match[scores_csv]={2}&match[winner_id]={3}",
            m_tournamentId,
            matchId,
            scores,
            winnerId);

        m_logger.LogDebug(UrlRequest);
        return (UrlRequest);
    }

    private ChallongeSchema.MatchWrapper MakeRequest(string requestUrl)
    {
        try
        {
            HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
            request.Method = "PUT";
            request.ContentType = "application/json";
            request.ContentLength = 0;

            Util.HTTPBasicAuth.SetBasicAuthHeader(request, m_username, m_apiKey);
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(String.Format(
                    "Server error (HTTP {0}: {1}).",
                    response.StatusCode,
                    response.StatusDescription));
                DataContractJsonSerializer jsonSerializer =
                    new DataContractJsonSerializer(typeof(ChallongeSchema.MatchWrapper));
                object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                ChallongeSchema.MatchWrapper jsonResponse = objResponse as ChallongeSchema.MatchWrapper;
                return jsonResponse;
            }
        }
        catch (Exception e)
        {
            m_logger.LogError("HTTP failure: " + e.Message);
            Console.WriteLine(e.Message);
            return null;
        }
    }

    private void ProcessResponse(ChallongeSchema.MatchWrapper response)
    {
        if (response.Match.State != "complete")
        {
            throw new Exception(String.Format("Match winner not updated; status=[{0}]. Check tournament webpage.", response.Match.State));
        }
    }
}
