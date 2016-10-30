using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTournament
{
    class TournamentController
    {
        ChallongeTournament m_tournament;
        Util.Logger m_logger;

        public TournamentController(Util.Logger logger)
        {
            m_logger = logger;
        }

        public bool SetupTournament(
            string challongeUsername,
            string challongeApiKey,
            string challongeTournamentId)
        {
            m_tournament = null;

            m_logger.LogInfo("Fetching challonge tournament [" + challongeTournamentId + "]");

            ChallongeTournament tournament = new ChallongeTournament(
                challongeUsername,
                challongeApiKey,
                challongeTournamentId,
                m_logger);

            if (!tournament.Valid())
            {
                return false;
            }

            m_logger.LogInfo("Tournament [" + challongeTournamentId + "] fetched.");

            m_tournament = tournament;

            return true;
        }

        public string GetTournamentName()
        {
            return m_tournament.GetName();
        }

        public void ProcessMatches(string matchIds)
        {
            ProcessMatch(matchIds);
        }

        private void ProcessMatch(string matchId)
        {
            m_logger.LogInfo("Processing match [" + matchId + "]");

            HSReplayMatch hsMatch = new HSReplayMatch(
                matchId,
                m_logger);

            if (!hsMatch.Valid())
            {
                m_logger.LogError("Match [" + matchId + "] is invalid");
                return;
            }

            m_logger.LogInfo("Match [" + matchId + "] has winner: [" + hsMatch.GetWinner() + "]");

            ChallongeMatch cMatch =
               m_tournament.GetOpenMatchByPlayers(hsMatch.GetWinner(), hsMatch.GetLoser());

            if (cMatch == null)
            {
                m_logger.LogError("Could not find challonge match between [" +
                                  hsMatch.GetWinner() + "] and [" +
                                  hsMatch.GetLoser() + "]");
                return;
            }

            m_logger.LogDebug("Updating Challonge match.");

            cMatch.SetWinner(hsMatch.GetWinner());

            m_logger.LogDebug("Refreshing challonge tournament after update");

            // Re-fetch the tournament to keep it updated
            m_tournament.Refresh();

            m_logger.LogInfo("Updated winner [" + hsMatch.GetWinner() +
                             "] for challonge match [" + cMatch.GetMatchId() + "]");
        }
    }
}
