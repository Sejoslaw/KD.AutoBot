namespace Test_Windows_Forms_TestForm
{
    partial class Form1
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
            this.TB_TestTextBox = new System.Windows.Forms.TextBox();
            this.B_TestButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TB_TestTextBox
            // 
            this.TB_TestTextBox.Location = new System.Drawing.Point(296, 12);
            this.TB_TestTextBox.Name = "TB_TestTextBox";
            this.TB_TestTextBox.Size = new System.Drawing.Size(178, 20);
            this.TB_TestTextBox.TabIndex = 0;
            this.TB_TestTextBox.Text = "Test TextBox Value";
            // 
            // B_TestButton
            // 
            this.B_TestButton.Location = new System.Drawing.Point(13, 13);
            this.B_TestButton.Name = "B_TestButton";
            this.B_TestButton.Size = new System.Drawing.Size(107, 46);
            this.B_TestButton.TabIndex = 1;
            this.B_TestButton.Text = "Test Button Text";
            this.B_TestButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 419);
            this.Controls.Add(this.B_TestButton);
            this.Controls.Add(this.TB_TestTextBox);
            this.Name = "Form1";
            this.Text = "Test Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_TestTextBox;
        private System.Windows.Forms.Button B_TestButton;
    }
}

