using System;
using System.Windows.Forms;

namespace Test_Windows_Forms_TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void B_TestButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button has been clicked.");
        }
    }
}
