namespace HSTournament
{
    partial class hsTournamentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.processMatchButton = new System.Windows.Forms.Button();
            this.challongeUsernameTextbox = new System.Windows.Forms.TextBox();
            this.challongeUsernameLabel = new System.Windows.Forms.Label();
            this.challongeApiKeyLabel = new System.Windows.Forms.Label();
            this.challongeApiKeyTextbox = new System.Windows.Forms.TextBox();
            this.challongeTournamentIdLabel = new System.Windows.Forms.Label();
            this.challongeTournamentIdTextbox = new System.Windows.Forms.TextBox();
            this.hsReplayIdLabel = new System.Windows.Forms.Label();
            this.hsReplayIdTextbox = new System.Windows.Forms.TextBox();
            this.winnerTitleLabel = new System.Windows.Forms.Label();
            this.winnerLabel = new System.Windows.Forms.Label();
            this.loserLabel = new System.Windows.Forms.Label();
            this.loserTitleLabel = new System.Windows.Forms.Label();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.logLabel = new System.Windows.Forms.Label();
            this.hsReplayGroupBox = new System.Windows.Forms.GroupBox();
            this.challongeGroupBox = new System.Windows.Forms.GroupBox();
            this.activeTournamentLabel = new System.Windows.Forms.Label();
            this.activeTournamentTitleLabel = new System.Windows.Forms.Label();
            this.fetchTournamentButton = new System.Windows.Forms.Button();
            this.hsReplayGroupBox.SuspendLayout();
            this.challongeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // processMatchButton
            // 
            this.processMatchButton.Enabled = false;
            this.processMatchButton.Location = new System.Drawing.Point(208, 73);
            this.processMatchButton.Name = "processMatchButton";
            this.processMatchButton.Size = new System.Drawing.Size(133, 61);
            this.processMatchButton.TabIndex = 6;
            this.processMatchButton.Text = "Process Match";
            this.processMatchButton.UseVisualStyleBackColor = true;
            this.processMatchButton.Click += new System.EventHandler(this.processMatchButton_Click);
            // 
            // challongeUsernameTextbox
            // 
            this.challongeUsernameTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::HSTournament.Properties.Settings.Default, "ChallongeUsername", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.challongeUsernameTextbox.Location = new System.Drawing.Point(9, 32);
            this.challongeUsernameTextbox.Name = "challongeUsernameTextbox";
            this.challongeUsernameTextbox.Size = new System.Drawing.Size(311, 20);
            this.challongeUsernameTextbox.TabIndex = 1;
            this.challongeUsernameTextbox.Text = global::HSTournament.Properties.Settings.Default.ChallongeUsername;
            // 
            // challongeUsernameLabel
            // 
            this.challongeUsernameLabel.AutoSize = true;
            this.challongeUsernameLabel.Location = new System.Drawing.Point(6, 16);
            this.challongeUsernameLabel.Name = "challongeUsernameLabel";
            this.challongeUsernameLabel.Size = new System.Drawing.Size(105, 13);
            this.challongeUsernameLabel.TabIndex = 999;
            this.challongeUsernameLabel.Text = "Challonge Username";
            // 
            // challongeApiKeyLabel
            // 
            this.challongeApiKeyLabel.AutoSize = true;
            this.challongeApiKeyLabel.Location = new System.Drawing.Point(6, 62);
            this.challongeApiKeyLabel.Name = "challongeApiKeyLabel";
            this.challongeApiKeyLabel.Size = new System.Drawing.Size(95, 13);
            this.challongeApiKeyLabel.TabIndex = 999;
            this.challongeApiKeyLabel.Text = "Challonge API Key";
            // 
            // challongeApiKeyTextbox
            // 
            this.challongeApiKeyTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::HSTournament.Properties.Settings.Default, "ChallongeAPIKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.challongeApiKeyTextbox.Location = new System.Drawing.Point(9, 78);
            this.challongeApiKeyTextbox.Name = "challongeApiKeyTextbox";
            this.challongeApiKeyTextbox.Size = new System.Drawing.Size(311, 20);
            this.challongeApiKeyTextbox.TabIndex = 2;
            this.challongeApiKeyTextbox.Text = global::HSTournament.Properties.Settings.Default.ChallongeAPIKey;
            this.challongeApiKeyTextbox.UseSystemPasswordChar = true;
            // 
            // challongeTournamentIdLabel
            // 
            this.challongeTournamentIdLabel.AutoSize = true;
            this.challongeTournamentIdLabel.Location = new System.Drawing.Point(6, 107);
            this.challongeTournamentIdLabel.Name = "challongeTournamentIdLabel";
            this.challongeTournamentIdLabel.Size = new System.Drawing.Size(128, 13);
            this.challongeTournamentIdLabel.TabIndex = 999;
            this.challongeTournamentIdLabel.Text = "Challonge Tournament ID";
            // 
            // challongeTournamentIdTextbox
            // 
            this.challongeTournamentIdTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::HSTournament.Properties.Settings.Default, "ChallongeTournamentId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.challongeTournamentIdTextbox.Location = new System.Drawing.Point(9, 123);
            this.challongeTournamentIdTextbox.Name = "challongeTournamentIdTextbox";
            this.challongeTournamentIdTextbox.Size = new System.Drawing.Size(311, 20);
            this.challongeTournamentIdTextbox.TabIndex = 3;
            this.challongeTournamentIdTextbox.Text = global::HSTournament.Properties.Settings.Default.ChallongeTournamentId;
            // 
            // hsReplayIdLabel
            // 
            this.hsReplayIdLabel.AutoSize = true;
            this.hsReplayIdLabel.Location = new System.Drawing.Point(6, 16);
            this.hsReplayIdLabel.Name = "hsReplayIdLabel";
            this.hsReplayIdLabel.Size = new System.Drawing.Size(69, 13);
            this.hsReplayIdLabel.TabIndex = 999;
            this.hsReplayIdLabel.Text = "HSReplay ID";
            // 
            // hsReplayIdTextbox
            // 
            this.hsReplayIdTextbox.Enabled = false;
            this.hsReplayIdTextbox.Location = new System.Drawing.Point(6, 32);
            this.hsReplayIdTextbox.Name = "hsReplayIdTextbox";
            this.hsReplayIdTextbox.Size = new System.Drawing.Size(311, 20);
            this.hsReplayIdTextbox.TabIndex = 5;
            this.hsReplayIdTextbox.Text = "TCtFGnVwjqNyoMfpTv2j55";
            // 
            // winnerTitleLabel
            // 
            this.winnerTitleLabel.AutoSize = true;
            this.winnerTitleLabel.Location = new System.Drawing.Point(6, 82);
            this.winnerTitleLabel.Name = "winnerTitleLabel";
            this.winnerTitleLabel.Size = new System.Drawing.Size(44, 13);
            this.winnerTitleLabel.TabIndex = 999;
            this.winnerTitleLabel.Text = "Winner:";
            // 
            // winnerLabel
            // 
            this.winnerLabel.AutoSize = true;
            this.winnerLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.winnerLabel.Location = new System.Drawing.Point(56, 82);
            this.winnerLabel.Name = "winnerLabel";
            this.winnerLabel.Size = new System.Drawing.Size(52, 13);
            this.winnerLabel.TabIndex = 999;
            this.winnerLabel.Text = "WINNER";
            // 
            // loserLabel
            // 
            this.loserLabel.AutoSize = true;
            this.loserLabel.ForeColor = System.Drawing.Color.Crimson;
            this.loserLabel.Location = new System.Drawing.Point(56, 106);
            this.loserLabel.Name = "loserLabel";
            this.loserLabel.Size = new System.Drawing.Size(43, 13);
            this.loserLabel.TabIndex = 999;
            this.loserLabel.Text = "LOSER";
            // 
            // loserTitleLabel
            // 
            this.loserTitleLabel.AutoSize = true;
            this.loserTitleLabel.Location = new System.Drawing.Point(6, 106);
            this.loserTitleLabel.Name = "loserTitleLabel";
            this.loserTitleLabel.Size = new System.Drawing.Size(36, 13);
            this.loserTitleLabel.TabIndex = 999;
            this.loserTitleLabel.Text = "Loser:";
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(376, 25);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logTextBox.Size = new System.Drawing.Size(308, 351);
            this.logTextBox.TabIndex = 999;
            this.logTextBox.TabStop = false;
            this.logTextBox.WordWrap = false;
            // 
            // logLabel
            // 
            this.logLabel.AutoSize = true;
            this.logLabel.Location = new System.Drawing.Point(362, 9);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(25, 13);
            this.logLabel.TabIndex = 999;
            this.logLabel.Text = "Log";
            // 
            // hsReplayGroupBox
            // 
            this.hsReplayGroupBox.Controls.Add(this.hsReplayIdLabel);
            this.hsReplayGroupBox.Controls.Add(this.hsReplayIdTextbox);
            this.hsReplayGroupBox.Controls.Add(this.processMatchButton);
            this.hsReplayGroupBox.Controls.Add(this.loserLabel);
            this.hsReplayGroupBox.Controls.Add(this.winnerLabel);
            this.hsReplayGroupBox.Controls.Add(this.loserTitleLabel);
            this.hsReplayGroupBox.Controls.Add(this.winnerTitleLabel);
            this.hsReplayGroupBox.Location = new System.Drawing.Point(12, 235);
            this.hsReplayGroupBox.Name = "hsReplayGroupBox";
            this.hsReplayGroupBox.Size = new System.Drawing.Size(347, 141);
            this.hsReplayGroupBox.TabIndex = 999;
            this.hsReplayGroupBox.TabStop = false;
            // 
            // challongeGroupBox
            // 
            this.challongeGroupBox.Controls.Add(this.activeTournamentLabel);
            this.challongeGroupBox.Controls.Add(this.activeTournamentTitleLabel);
            this.challongeGroupBox.Controls.Add(this.fetchTournamentButton);
            this.challongeGroupBox.Controls.Add(this.challongeUsernameTextbox);
            this.challongeGroupBox.Controls.Add(this.challongeUsernameLabel);
            this.challongeGroupBox.Controls.Add(this.challongeApiKeyTextbox);
            this.challongeGroupBox.Controls.Add(this.challongeApiKeyLabel);
            this.challongeGroupBox.Controls.Add(this.challongeTournamentIdLabel);
            this.challongeGroupBox.Controls.Add(this.challongeTournamentIdTextbox);
            this.challongeGroupBox.Location = new System.Drawing.Point(12, 12);
            this.challongeGroupBox.Name = "challongeGroupBox";
            this.challongeGroupBox.Size = new System.Drawing.Size(347, 217);
            this.challongeGroupBox.TabIndex = 999;
            this.challongeGroupBox.TabStop = false;
            // 
            // activeTournamentLabel
            // 
            this.activeTournamentLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.activeTournamentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeTournamentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.activeTournamentLabel.Location = new System.Drawing.Point(6, 165);
            this.activeTournamentLabel.Name = "activeTournamentLabel";
            this.activeTournamentLabel.Size = new System.Drawing.Size(196, 42);
            this.activeTournamentLabel.TabIndex = 1001;
            this.activeTournamentLabel.Text = "ACTIVE TOURNAMENT";
            this.activeTournamentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // activeTournamentTitleLabel
            // 
            this.activeTournamentTitleLabel.AutoSize = true;
            this.activeTournamentTitleLabel.Location = new System.Drawing.Point(47, 149);
            this.activeTournamentTitleLabel.Name = "activeTournamentTitleLabel";
            this.activeTournamentTitleLabel.Size = new System.Drawing.Size(100, 13);
            this.activeTournamentTitleLabel.TabIndex = 1000;
            this.activeTournamentTitleLabel.Text = "Active Tournament:";
            // 
            // fetchTournamentButton
            // 
            this.fetchTournamentButton.Location = new System.Drawing.Point(208, 149);
            this.fetchTournamentButton.Name = "fetchTournamentButton";
            this.fetchTournamentButton.Size = new System.Drawing.Size(133, 61);
            this.fetchTournamentButton.TabIndex = 4;
            this.fetchTournamentButton.Text = "Fetch Tournament";
            this.fetchTournamentButton.UseVisualStyleBackColor = true;
            this.fetchTournamentButton.Click += new System.EventHandler(this.fetchTournamentButton_Click);
            // 
            // hsTournamentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(696, 388);
            this.Controls.Add(this.challongeGroupBox);
            this.Controls.Add(this.hsReplayGroupBox);
            this.Controls.Add(this.logLabel);
            this.Controls.Add(this.logTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "hsTournamentForm";
            this.Text = "Hearthstone Tournament Recorder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.hsTournamentForm_FormClosing);
            this.hsReplayGroupBox.ResumeLayout(false);
            this.hsReplayGroupBox.PerformLayout();
            this.challongeGroupBox.ResumeLayout(false);
            this.challongeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button processMatchButton;
        private System.Windows.Forms.TextBox challongeUsernameTextbox;
        private System.Windows.Forms.Label challongeUsernameLabel;
        private System.Windows.Forms.Label challongeApiKeyLabel;
        private System.Windows.Forms.TextBox challongeApiKeyTextbox;
        private System.Windows.Forms.Label challongeTournamentIdLabel;
        private System.Windows.Forms.TextBox challongeTournamentIdTextbox;
        private System.Windows.Forms.Label hsReplayIdLabel;
        private System.Windows.Forms.TextBox hsReplayIdTextbox;
        private System.Windows.Forms.Label winnerTitleLabel;
        private System.Windows.Forms.Label winnerLabel;
        private System.Windows.Forms.Label loserLabel;
        private System.Windows.Forms.Label loserTitleLabel;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.GroupBox hsReplayGroupBox;
        private System.Windows.Forms.GroupBox challongeGroupBox;
        private System.Windows.Forms.Button fetchTournamentButton;
        private System.Windows.Forms.Label activeTournamentLabel;
        private System.Windows.Forms.Label activeTournamentTitleLabel;
    }
}

