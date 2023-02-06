namespace Output
{
    namespace ErrorOutput
    {
        partial class ErrorWindow
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
            this.components = new System.ComponentModel.Container();
            this.continueButton = new System.Windows.Forms.Button();
            this.abortButton = new System.Windows.Forms.Button();
            this.errorOccouredLabel = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.errorToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // continueButton
            // 
            this.continueButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.continueButton.Location = new System.Drawing.Point(244, 318);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(75, 23);
            this.continueButton.TabIndex = 0;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = true;
            // 
            // abortButton
            // 
            this.abortButton.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.abortButton.Location = new System.Drawing.Point(478, 318);
            this.abortButton.Name = "abortButton";
            this.abortButton.Size = new System.Drawing.Size(75, 23);
            this.abortButton.TabIndex = 1;
            this.abortButton.Text = "Abort";
            this.abortButton.UseVisualStyleBackColor = true;
            // 
            // errorOccouredLabel
            // 
            this.errorOccouredLabel.AutoSize = true;
            this.errorOccouredLabel.Location = new System.Drawing.Point(339, 153);
            this.errorOccouredLabel.Name = "errorOccouredLabel";
            this.errorOccouredLabel.Size = new System.Drawing.Size(115, 13);
            this.errorOccouredLabel.TabIndex = 2;
            this.errorOccouredLabel.Text = "An error has occoured:";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(372, 223);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(46, 13);
            this.errorLabel.TabIndex = 3;
            this.errorLabel.Text = "ERROR";
            // 
            // ErrorWindow
            // 
            this.AcceptButton = this.continueButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.abortButton;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.errorOccouredLabel);
            this.Controls.Add(this.abortButton);
            this.Controls.Add(this.continueButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ErrorWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ErrorWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.Button continueButton;
            private System.Windows.Forms.Button abortButton;
            private System.Windows.Forms.Label errorOccouredLabel;
            private System.Windows.Forms.Label errorLabel;
            private System.Windows.Forms.ToolTip errorToolTip;
        }
    }
}