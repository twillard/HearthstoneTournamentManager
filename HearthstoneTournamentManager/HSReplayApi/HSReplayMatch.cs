using System;
using System.Net;
using System.Runtime.Serialization.Json;

public class HSReplayMatch
{
    private string m_matchId;
    private HSReplaySchema.Response m_matchInfo;
    private string m_winner;
    private string m_loser;
    private bool m_valid;
    private Util.Logger m_logger;

    public HSReplayMatch(string matchId, Util.Logger logger)
    {
        m_valid = false;

        m_logger = logger;

        m_matchId = matchId;
        Request();
    }

    public string GetWinner()
    {
        return m_winner;
    }

    public string GetLoser()
    {
        return m_loser;
    }

    public bool Valid()
    {
        return m_valid;
    }

    private void Request()
    {
        try
        {
            m_matchInfo = MakeRequest(CreateRequestUri());
            if (m_matchInfo != null)
            {
                ProcessResponse(m_matchInfo);
                m_valid = true;
            }
        }
        catch (Exception e)
        {
            m_logger.LogError(e.Message);
            Console.WriteLine(e.Message);
        }
    }

    private string CreateRequestUri()
    {
        string UrlRequest = "https://hsreplay.net/api/v1/games/" +
                             m_matchId + "/";
        m_logger.LogDebug(UrlRequest);
        return (UrlRequest);
    }

    private HSReplaySchema.Response MakeRequest(string requestUrl)
    {
        try
        {
            HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(String.Format(
                    "Server error (HTTP {0}: {1}).",
                    response.StatusCode,
                    response.StatusDescription));
                DataContractJsonSerializer jsonSerializer =
                    new DataContractJsonSerializer(typeof(HSReplaySchema.Response));
                object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                HSReplaySchema.Response jsonResponse = objResponse as HSReplaySchema.Response;
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

    private void ProcessResponse(HSReplaySchema.Response response)
    {
        if (m_matchInfo.Won)
        {
            m_winner = m_matchInfo.GlobalGame.Players[0].Name;
            m_loser = m_matchInfo.GlobalGame.Players[1].Name;
        }
        else
        {
            m_winner = m_matchInfo.GlobalGame.Players[1].Name;
            m_loser = m_matchInfo.GlobalGame.Players[0].Name;
        }
    }
}
