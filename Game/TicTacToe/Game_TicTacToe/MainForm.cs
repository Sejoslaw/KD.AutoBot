using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game_TicTacToe
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// TicTacToe game logic.
        /// </summary>
        private TicTacToeGame Game { get; }

        private Button[] Buttons;

        public MainForm()
        {
            InitializeComponent();

            this.Game = new TicTacToeGame(SystemColors.Control);
            this.Buttons = new Button[]
            {
                this.B_0, this.B_1, this.B_2,
                this.B_3, this.B_4, this.B_5,
                this.B_6, this.B_7, this.B_8
            };

            this.NewGame();
        }

        private void TSMI_Exit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void TSMI_NewGame_Click(object sender, System.EventArgs e)
        {
            this.NewGame();
        }

        public void NextTurn()
        {
            this.Game.NextTurn();
            this.TB_CurrentPlayerTurn.Text = this.Game.CurrentPlayer.UsedChar;
        }

        public void RestartGame()
        {
            this.Game.RestartGame();

            foreach (Button button in this.Buttons)
            {
                button.BackColor = this.Game.DefaultButtonsColor;
                button.Text = "";
                button.Enabled = true;
            }

            this.TB_Score_Player1.Text = this.Game.Players[0].Points.ToString();
            this.TB_Score_Player2.Text = this.Game.Players[1].Points.ToString();

            this.NextTurn();
        }

        private void NewGame()
        {
            this.Game.NewGame();
            this.RestartGame();
        }

        /// <summary>
        /// 1. Color button.
        /// 2. Set Text to the player who clicked button.
        /// 3. Use game logic to check if the winning condition is completed.
        /// 4. Start next turn.
        /// </summary>
        private void CheckButton(Button clicked)
        {
            clicked.Enabled = false;
            clicked.BackColor = this.Game.CurrentPlayer.Color;
            clicked.Text = this.Game.CurrentPlayer.UsedChar;

            string[][] gameGrid = this.BuildGameGrid();
            bool won = this.Game.CheckWinCondition(gameGrid);
            if (won)
            {
                this.Game.CurrentPlayer.Points++;
                this.RestartGame();
            }

            if (this.CheckDraw(gameGrid))
            {
                this.RestartGame();
            }

            this.NextTurn();
        }

        private bool CheckDraw(string[][] gameGrid)
        {
            bool draw = true;

            for (int i = 0; i < gameGrid.Length; ++i)
            {
                for (int j = 0; j < gameGrid[0].Length; ++j)
                {
                    if (gameGrid[i][j].Equals(""))
                    {
                        draw = false;
                    }
                }
            }

            return draw;
        }

        private string[][] BuildGameGrid()
        {
            return new string[][]
            {
                new string[] { this.B_0.Text, this.B_1.Text, this.B_2.Text },
                new string[] { this.B_3.Text, this.B_4.Text, this.B_5.Text },
                new string[] { this.B_6.Text, this.B_7.Text, this.B_8.Text }
            };
        }

        private void B_0_Click(object sender, System.EventArgs e)
        {
            this.CheckButton(sender as Button);
        }

        private void B_1_Click(object sender, System.EventArgs e)
        {
            this.CheckButton(sender as Button);
        }

        private void B_2_Click(object sender, System.EventArgs e)
        {
            this.CheckButton(sender as Button);
        }

        private void B_3_Click(object sender, System.EventArgs e)
        {
            this.CheckButton(sender as Button);
        }

        private void B_4_Click(object sender, System.EventArgs e)
        {
            this.CheckButton(sender as Button);
        }

        private void B_5_Click(object sender, System.EventArgs e)
        {
            this.CheckButton(sender as Button);
        }

        private void B_6_Click(object sender, System.EventArgs e)
        {
            this.CheckButton(sender as Button);
        }

        private void B_7_Click(object sender, System.EventArgs e)
        {
            this.CheckButton(sender as Button);
        }

        private void B_8_Click(object sender, System.EventArgs e)
        {
            this.CheckButton(sender as Button);
        }
    }
}