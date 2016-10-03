using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HSTournament
{
    public partial class hsTournamentForm : Form
    {
        ChallongeTournament m_tournament;
        Util.Logger m_logger;

        public hsTournamentForm()
        {
            InitializeComponent();
            m_logger = new Util.Logger(this.logTextBox);

            this.winnerLabel.Text = "";
            this.loserLabel.Text = "";
            this.activeTournamentLabel.Text = "";
        }

        private void processMatchButton_Click(object sender, EventArgs e)
        {
            this.winnerLabel.Text = "";
            this.loserLabel.Text = "";

            m_logger.Log("BEGIN: Processing match.");

            HSReplayMatch hsMatch = new HSReplayMatch(
                this.hsReplayIdTextbox.Text,
                m_logger);

            if (!hsMatch.Valid())
            {
                return;
            }

            this.winnerLabel.Text = hsMatch.GetWinner();
            this.loserLabel.Text = hsMatch.GetLoser();

            m_logger.Log("DONE: Match Processed.");

            m_logger.Log("BEGIN: Updating winner.");

            ChallongeMatch cMatch =
               m_tournament.GetOpenMatchByPlayers(hsMatch.GetWinner(), hsMatch.GetLoser());

            if (cMatch == null)
            {
                m_logger.Log("ERROR: Could not find open match for players.");
                return;
            }

            cMatch.SetWinner(hsMatch.GetWinner());
            
            // Re-fetch the tournament to keep it updated
            m_tournament = new ChallongeTournament(
                this.challongeUsernameTextbox.Text,
                this.challongeApiKeyTextbox.Text,
                this.challongeTournamentIdTextbox.Text,
                m_logger);

            m_logger.Log("DONE: Updating winner.");
        }

        private void fetchTournamentButton_Click(object sender, EventArgs e)
        {
            this.hsReplayIdTextbox.Enabled = false;
            this.processMatchButton.Enabled = false;
            this.activeTournamentLabel.Text = "";
            this.winnerLabel.Text = "";
            this.loserLabel.Text = "";

            m_logger.Log("BEGIN: Fetching tournament.");

            ChallongeTournament tournament = new ChallongeTournament(
                this.challongeUsernameTextbox.Text,
                this.challongeApiKeyTextbox.Text,
                this.challongeTournamentIdTextbox.Text,
                m_logger);

            if (!tournament.Valid())
            {
                return;
            }

            this.activeTournamentLabel.Text = tournament.GetName();

            this.hsReplayIdTextbox.Enabled = true;
            this.processMatchButton.Enabled = true;
            m_logger.Log("DONE: Tournament fetched.");

            m_tournament = tournament;
        }

        private void hsTournamentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.ChallongeUsername = this.challongeUsernameTextbox.Text;
            Properties.Settings.Default.ChallongeAPIKey = this.challongeApiKeyTextbox.Text;
            Properties.Settings.Default.ChallongeTournamentId = this.challongeTournamentIdTextbox.Text;
            Properties.Settings.Default.Save();
        }
    }
}
