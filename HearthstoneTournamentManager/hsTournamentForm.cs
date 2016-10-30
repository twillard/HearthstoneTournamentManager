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
        TournamentController m_controller;
        Util.Logger m_logger;

        public hsTournamentForm()
        {
            InitializeComponent();
            m_logger = new Util.Logger(this.logTextBox);
            m_controller = new TournamentController(this.m_logger);

            this.activeTournamentLabel.Text = "";
        }

        private void processMatchButton_Click(object sender, EventArgs e)
        {
            m_controller.ProcessMatches(this.hsReplayIdTextbox.Text);
        }

        private void fetchTournamentButton_Click(object sender, EventArgs e)
        {
            this.hsReplayIdTextbox.Enabled = false;
            this.processMatchButton.Enabled = false;
            this.activeTournamentLabel.Text = "";

            bool valid = m_controller.SetupTournament(
                this.challongeUsernameTextbox.Text,
                this.challongeApiKeyTextbox.Text,
                this.challongeTournamentIdTextbox.Text);

            if (!valid)
            {
                return;
            }

            this.activeTournamentLabel.Text = m_controller.GetTournamentName();

            this.hsReplayIdTextbox.Enabled = true;
            this.processMatchButton.Enabled = true;
        }

        private void hsTournamentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.ChallongeUsername = this.challongeUsernameTextbox.Text;
            Properties.Settings.Default.ChallongeAPIKey = this.challongeApiKeyTextbox.Text;
            Properties.Settings.Default.ChallongeTournamentId = this.challongeTournamentIdTextbox.Text;
            Properties.Settings.Default.Save();
        }

        private void DebugCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_logger.SetDebugEnabled(this.debugCheckBox.CheckState == CheckState.Checked);
        }
    }
}
