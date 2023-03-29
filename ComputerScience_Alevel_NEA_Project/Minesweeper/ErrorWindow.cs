using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Output
{
    namespace ErrorOutput
    {
        // Simple class to show an error window detailing the error 
        // with an abort and if applicable continue button
        public partial class ErrorWindow : Form
        {
            private Exception ex;
            public ErrorWindow(Exception ex)
            {
                InitializeComponent();
                this.ex = ex;
            }
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                if (ex is ArgumentException)
                {
                    ShowContinueButton();
                }
                errorLabel.Text = $"Object thrown by:{ex.Source}\n{ex.Message}";
                errorToolTip.SetToolTip(errorLabel, ex.ToString());
            }
            private void ShowContinueButton()
            {
                abortButton.Location = new Point(172, 191);
                continueButton.Location = new Point(30, 191);
                continueButton.Show();
            }
        }
    }
}
