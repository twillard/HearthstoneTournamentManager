using System;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Collections.Generic;

public class ChallongeTournament
{
    private string m_username;
    private string m_apiKey;
    private string m_tournamentId;
    private Util.Logger m_logger;

    private ChallongeSchema.Response m_tournamentInfo;
    private bool m_valid;
    private Dictionary<int, ChallongeSchema.ParticipantInfo> m_participantsById;

    public ChallongeTournament(
        string username,
        string apiKey,
        string tournamentId,
        Util.Logger logger)
    {
        m_username = username;
        m_apiKey = apiKey;
        m_tournamentId = tournamentId;
        m_logger = logger;

        m_logger.LogDebug("Looking up tournament " + tournamentId);

        Request();
    }

    public void Refresh()
    {
        Request();
    }

    public bool Valid()
    {
        return m_valid;
    }

    public string GetName()
    {
        return m_tournamentInfo.Tournament.Name;
    }

    public ChallongeMatch GetOpenMatchByPlayers(
        string player1,
        string player2)
    {
        m_logger.LogDebug("Searching for challonge match between " + player1 + " and " + player2);
        foreach (ChallongeSchema.MatchWrapper match in m_tournamentInfo.Tournament.Matches)
        {
            Tuple<ChallongeSchema.ParticipantInfo, ChallongeSchema.ParticipantInfo> participants =
                CheckMatch(match.Match, player1, player2);

            // If participants are returned, this match satisfies the criteria
            if (participants != null)
            {
                m_logger.LogDebug(String.Format("Found a match, ID {0}", match.Match.Id));
                return new ChallongeMatch(
                    m_username,
                    m_apiKey,
                    m_tournamentId,
                    match.Match,
                    participants.Item1,
                    participants.Item2,
                    m_logger);
            }
        }

        return null;
    }

    private Tuple<ChallongeSchema.ParticipantInfo, ChallongeSchema.ParticipantInfo> CheckMatch(
        ChallongeSchema.MatchInfo match,
        string player1,
        string player2)
    {
        if (match.State != "open")
        {
            return null;
        }

        int matchPlayer1;
        int matchPlayer2;

        try
        {
            matchPlayer1 = Int32.Parse(match.Player1Id);
            matchPlayer2 = Int32.Parse(match.Player2Id);
        }
        catch(Exception)
        {
            return null;
        }

        Tuple<ChallongeSchema.ParticipantInfo, ChallongeSchema.ParticipantInfo> participants =
            Tuple.Create(m_participantsById[matchPlayer1], m_participantsById[matchPlayer2]);

        if ((participants.Item1.Name == player1 && participants.Item2.Name == player2) ||
            (participants.Item2.Name == player1 && participants.Item1.Name == player2))
        {
            return participants;
        }

        return null;
    }

    private void Request()
    {
        m_valid = false;

        m_tournamentInfo = null;
        m_participantsById = new Dictionary<int, ChallongeSchema.ParticipantInfo>();

        try
        {
            m_tournamentInfo = MakeRequest(CreateGetTournamentUri());
            if (m_tournamentInfo != null)
            {
                ProcessResponse(m_tournamentInfo);
                m_valid = true;
            }
        }
        catch (Exception e)
        {
            m_logger.LogError(e.Message);
            Console.WriteLine(e.Message);
        }
    }

    private string CreateGetTournamentUri()
    {
        string UrlRequest =
            "https://api.challonge.com/v1/tournaments/" +
            m_tournamentId +
            ".json?include_matches=1&include_participants=1";
        m_logger.LogDebug(UrlRequest);
        return (UrlRequest);
    }

    private ChallongeSchema.Response MakeRequest(string requestUrl)
    {
        try
        {
            HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
            Util.HTTPBasicAuth.SetBasicAuthHeader(request, m_username, m_apiKey);
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(String.Format(
                    "Server error (HTTP {0}: {1}).",
                    response.StatusCode,
                    response.StatusDescription));
                DataContractJsonSerializer jsonSerializer =
                    new DataContractJsonSerializer(typeof(ChallongeSchema.Response));
                object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                ChallongeSchema.Response jsonResponse = objResponse as ChallongeSchema.Response;
                return jsonResponse;
            }
        }
        catch (Exception e)
        {
            m_logger.LogError("HTTP failed: " + e.Message);
            Console.WriteLine(e.Message);
            return null;
        }
    }

    private void ProcessResponse(ChallongeSchema.Response response)
    {
        if (m_tournamentInfo.Tournament.State != "underway")
        {
            throw new Exception(String.Format("Tournament [{0}] is not in progress!  Status: [{1}]", m_tournamentInfo.Tournament.Name, m_tournamentInfo.Tournament.State));
        }

        foreach (ChallongeSchema.ParticipantWrapper participant in m_tournamentInfo.Tournament.Participants)
        {
            m_logger.LogDebug(
                String.Format("Player {0} with id {1}",
                participant.Participant.Name,
                participant.Participant.Id));

            m_participantsById[participant.Participant.Id] = participant.Participant;
        }
    }
}
