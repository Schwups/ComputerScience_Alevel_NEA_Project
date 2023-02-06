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
                errorLabel.Text = ex.Message;
                errorToolTip.SetToolTip(errorLabel, ex.ToString());
            }
        }
    }
}
