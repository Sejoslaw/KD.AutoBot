namespace Game_TicTacToe
{
    partial class MainForm
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
            this.GB_Buttons = new System.Windows.Forms.GroupBox();
            this.B_8 = new System.Windows.Forms.Button();
            this.B_7 = new System.Windows.Forms.Button();
            this.B_6 = new System.Windows.Forms.Button();
            this.B_5 = new System.Windows.Forms.Button();
            this.B_4 = new System.Windows.Forms.Button();
            this.B_3 = new System.Windows.Forms.Button();
            this.B_2 = new System.Windows.Forms.Button();
            this.B_1 = new System.Windows.Forms.Button();
            this.B_0 = new System.Windows.Forms.Button();
            this.GB_CurrentPlayerTurn = new System.Windows.Forms.GroupBox();
            this.TB_CurrentPlayerTurn = new System.Windows.Forms.TextBox();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_NewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.GB_Score = new System.Windows.Forms.GroupBox();
            this.TB_Score_Player2 = new System.Windows.Forms.TextBox();
            this.TB_Score_Player1 = new System.Windows.Forms.TextBox();
            this.L_Score_Player2 = new System.Windows.Forms.Label();
            this.L_Score_Player1 = new System.Windows.Forms.Label();
            this.GB_Buttons.SuspendLayout();
            this.GB_CurrentPlayerTurn.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.GB_Score.SuspendLayout();
            this.SuspendLayout();
            // 
            // GB_Buttons
            // 
            this.GB_Buttons.Controls.Add(this.B_8);
            this.GB_Buttons.Controls.Add(this.B_7);
            this.GB_Buttons.Controls.Add(this.B_6);
            this.GB_Buttons.Controls.Add(this.B_5);
            this.GB_Buttons.Controls.Add(this.B_4);
            this.GB_Buttons.Controls.Add(this.B_3);
            this.GB_Buttons.Controls.Add(this.B_2);
            this.GB_Buttons.Controls.Add(this.B_1);
            this.GB_Buttons.Controls.Add(this.B_0);
            this.GB_Buttons.Location = new System.Drawing.Point(12, 27);
            this.GB_Buttons.Name = "GB_Buttons";
            this.GB_Buttons.Size = new System.Drawing.Size(178, 194);
            this.GB_Buttons.TabIndex = 0;
            this.GB_Buttons.TabStop = false;
            this.GB_Buttons.Text = "Buttons";
            // 
            // B_8
            // 
            this.B_8.Location = new System.Drawing.Point(118, 131);
            this.B_8.Name = "B_8";
            this.B_8.Size = new System.Drawing.Size(50, 50);
            this.B_8.TabIndex = 8;
            this.B_8.UseVisualStyleBackColor = true;
            this.B_8.Click += new System.EventHandler(this.B_8_Click);
            // 
            // B_7
            // 
            this.B_7.Location = new System.Drawing.Point(62, 131);
            this.B_7.Name = "B_7";
            this.B_7.Size = new System.Drawing.Size(50, 50);
            this.B_7.TabIndex = 7;
            this.B_7.UseVisualStyleBackColor = true;
            this.B_7.Click += new System.EventHandler(this.B_7_Click);
            // 
            // B_6
            // 
            this.B_6.Location = new System.Drawing.Point(6, 131);
            this.B_6.Name = "B_6";
            this.B_6.Size = new System.Drawing.Size(50, 50);
            this.B_6.TabIndex = 6;
            this.B_6.UseVisualStyleBackColor = true;
            this.B_6.Click += new System.EventHandler(this.B_6_Click);
            // 
            // B_5
            // 
            this.B_5.Location = new System.Drawing.Point(118, 75);
            this.B_5.Name = "B_5";
            this.B_5.Size = new System.Drawing.Size(50, 50);
            this.B_5.TabIndex = 5;
            this.B_5.UseVisualStyleBackColor = true;
            this.B_5.Click += new System.EventHandler(this.B_5_Click);
            // 
            // B_4
            // 
            this.B_4.Location = new System.Drawing.Point(62, 75);
            this.B_4.Name = "B_4";
            this.B_4.Size = new System.Drawing.Size(50, 50);
            this.B_4.TabIndex = 4;
            this.B_4.UseVisualStyleBackColor = true;
            this.B_4.Click += new System.EventHandler(this.B_4_Click);
            // 
            // B_3
            // 
            this.B_3.Location = new System.Drawing.Point(6, 75);
            this.B_3.Name = "B_3";
            this.B_3.Size = new System.Drawing.Size(50, 50);
            this.B_3.TabIndex = 3;
            this.B_3.UseVisualStyleBackColor = true;
            this.B_3.Click += new System.EventHandler(this.B_3_Click);
            // 
            // B_2
            // 
            this.B_2.Location = new System.Drawing.Point(118, 19);
            this.B_2.Name = "B_2";
            this.B_2.Size = new System.Drawing.Size(50, 50);
            this.B_2.TabIndex = 2;
            this.B_2.UseVisualStyleBackColor = true;
            this.B_2.Click += new System.EventHandler(this.B_2_Click);
            // 
            // B_1
            // 
            this.B_1.Location = new System.Drawing.Point(62, 19);
            this.B_1.Name = "B_1";
            this.B_1.Size = new System.Drawing.Size(50, 50);
            this.B_1.TabIndex = 1;
            this.B_1.UseVisualStyleBackColor = true;
            this.B_1.Click += new System.EventHandler(this.B_1_Click);
            // 
            // B_0
            // 
            this.B_0.Location = new System.Drawing.Point(6, 19);
            this.B_0.Name = "B_0";
            this.B_0.Size = new System.Drawing.Size(50, 50);
            this.B_0.TabIndex = 0;
            this.B_0.UseVisualStyleBackColor = true;
            this.B_0.Click += new System.EventHandler(this.B_0_Click);
            // 
            // GB_CurrentPlayerTurn
            // 
            this.GB_CurrentPlayerTurn.Controls.Add(this.TB_CurrentPlayerTurn);
            this.GB_CurrentPlayerTurn.Location = new System.Drawing.Point(197, 27);
            this.GB_CurrentPlayerTurn.Name = "GB_CurrentPlayerTurn";
            this.GB_CurrentPlayerTurn.Size = new System.Drawing.Size(131, 49);
            this.GB_CurrentPlayerTurn.TabIndex = 1;
            this.GB_CurrentPlayerTurn.TabStop = false;
            this.GB_CurrentPlayerTurn.Text = "Current Player Turn";
            // 
            // TB_CurrentPlayerTurn
            // 
            this.TB_CurrentPlayerTurn.Location = new System.Drawing.Point(6, 19);
            this.TB_CurrentPlayerTurn.Name = "TB_CurrentPlayerTurn";
            this.TB_CurrentPlayerTurn.ReadOnly = true;
            this.TB_CurrentPlayerTurn.Size = new System.Drawing.Size(115, 20);
            this.TB_CurrentPlayerTurn.TabIndex = 0;
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(343, 24);
            this.MainMenu.TabIndex = 3;
            this.MainMenu.Text = "MainMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_NewGame,
            this.TSMI_Exit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // TSMI_NewGame
            // 
            this.TSMI_NewGame.Name = "TSMI_NewGame";
            this.TSMI_NewGame.Size = new System.Drawing.Size(132, 22);
            this.TSMI_NewGame.Text = "New Game";
            this.TSMI_NewGame.Click += new System.EventHandler(this.TSMI_NewGame_Click);
            // 
            // TSMI_Exit
            // 
            this.TSMI_Exit.Name = "TSMI_Exit";
            this.TSMI_Exit.Size = new System.Drawing.Size(132, 22);
            this.TSMI_Exit.Text = "Exit";
            this.TSMI_Exit.Click += new System.EventHandler(this.TSMI_Exit_Click);
            // 
            // GB_Score
            // 
            this.GB_Score.Controls.Add(this.TB_Score_Player2);
            this.GB_Score.Controls.Add(this.TB_Score_Player1);
            this.GB_Score.Controls.Add(this.L_Score_Player2);
            this.GB_Score.Controls.Add(this.L_Score_Player1);
            this.GB_Score.Location = new System.Drawing.Point(196, 82);
            this.GB_Score.Name = "GB_Score";
            this.GB_Score.Size = new System.Drawing.Size(132, 67);
            this.GB_Score.TabIndex = 4;
            this.GB_Score.TabStop = false;
            this.GB_Score.Text = "Score";
            // 
            // TB_Score_Player2
            // 
            this.TB_Score_Player2.Location = new System.Drawing.Point(32, 39);
            this.TB_Score_Player2.Name = "TB_Score_Player2";
            this.TB_Score_Player2.ReadOnly = true;
            this.TB_Score_Player2.Size = new System.Drawing.Size(90, 20);
            this.TB_Score_Player2.TabIndex = 5;
            this.TB_Score_Player2.Text = "0";
            // 
            // TB_Score_Player1
            // 
            this.TB_Score_Player1.Location = new System.Drawing.Point(31, 13);
            this.TB_Score_Player1.Name = "TB_Score_Player1";
            this.TB_Score_Player1.ReadOnly = true;
            this.TB_Score_Player1.Size = new System.Drawing.Size(91, 20);
            this.TB_Score_Player1.TabIndex = 4;
            this.TB_Score_Player1.Text = "0";
            // 
            // L_Score_Player2
            // 
            this.L_Score_Player2.AutoSize = true;
            this.L_Score_Player2.Location = new System.Drawing.Point(8, 42);
            this.L_Score_Player2.Name = "L_Score_Player2";
            this.L_Score_Player2.Size = new System.Drawing.Size(18, 13);
            this.L_Score_Player2.TabIndex = 3;
            this.L_Score_Player2.Text = "O:";
            // 
            // L_Score_Player1
            // 
            this.L_Score_Player1.AutoSize = true;
            this.L_Score_Player1.Location = new System.Drawing.Point(8, 16);
            this.L_Score_Player1.Name = "L_Score_Player1";
            this.L_Score_Player1.Size = new System.Drawing.Size(17, 13);
            this.L_Score_Player1.TabIndex = 2;
            this.L_Score_Player1.Text = "X:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 233);
            this.Controls.Add(this.GB_Score);
            this.Controls.Add(this.GB_CurrentPlayerTurn);
            this.Controls.Add(this.GB_Buttons);
            this.Controls.Add(this.MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.MainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "TicTacToe";
            this.GB_Buttons.ResumeLayout(false);
            this.GB_CurrentPlayerTurn.ResumeLayout(false);
            this.GB_CurrentPlayerTurn.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.GB_Score.ResumeLayout(false);
            this.GB_Score.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_NewGame;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Exit;
        private System.Windows.Forms.Label L_Score_Player2;
        private System.Windows.Forms.Label L_Score_Player1;
        public System.Windows.Forms.Button B_0;
        public System.Windows.Forms.GroupBox GB_Buttons;
        public System.Windows.Forms.Button B_8;
        public System.Windows.Forms.Button B_7;
        public System.Windows.Forms.Button B_6;
        public System.Windows.Forms.Button B_5;
        public System.Windows.Forms.Button B_4;
        public System.Windows.Forms.Button B_3;
        public System.Windows.Forms.Button B_2;
        public System.Windows.Forms.Button B_1;
        public System.Windows.Forms.GroupBox GB_CurrentPlayerTurn;
        public System.Windows.Forms.TextBox TB_CurrentPlayerTurn;
        public System.Windows.Forms.GroupBox GB_Score;
        public System.Windows.Forms.TextBox TB_Score_Player1;
        public System.Windows.Forms.TextBox TB_Score_Player2;
    }
}

