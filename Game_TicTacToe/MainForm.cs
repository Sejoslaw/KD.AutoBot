using System.Windows.Forms;

namespace Game_TicTacToe
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void TSMI_Exit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
