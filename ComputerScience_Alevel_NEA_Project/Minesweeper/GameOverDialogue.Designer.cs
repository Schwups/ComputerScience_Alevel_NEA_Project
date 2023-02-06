namespace Output
{
    namespace MinesweeperOutput
    {
        partial class GameOverDialogue
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
            this.endMessage = new System.Windows.Forms.Label();
            this.endTimeLabel = new System.Windows.Forms.Label();
            this.endTime = new System.Windows.Forms.Label();
            this.contineButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // endMessage
            // 
            this.endMessage.AutoSize = true;
            this.endMessage.Location = new System.Drawing.Point(84, 25);
            this.endMessage.Name = "endMessage";
            this.endMessage.Size = new System.Drawing.Size(119, 13);
            this.endMessage.TabIndex = 0;
            this.endMessage.Text = "GAME END MESSAGE";
            this.endMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // endTimeLabel
            // 
            this.endTimeLabel.Location = new System.Drawing.Point(92, 77);
            this.endTimeLabel.Name = "endTimeLabel";
            this.endTimeLabel.Size = new System.Drawing.Size(100, 13);
            this.endTimeLabel.TabIndex = 1;
            this.endTimeLabel.Text = "Your time was:";
            this.endTimeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // endTime
            // 
            this.endTime.Location = new System.Drawing.Point(92, 95);
            this.endTime.Name = "endTime";
            this.endTime.Size = new System.Drawing.Size(100, 13);
            this.endTime.TabIndex = 2;
            this.endTime.Text = "TIME";
            this.endTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // contineButton
            // 
            this.contineButton.Location = new System.Drawing.Point(92, 131);
            this.contineButton.Name = "contineButton";
            this.contineButton.Size = new System.Drawing.Size(100, 23);
            this.contineButton.TabIndex = 3;
            this.contineButton.Text = "Return to menu";
            this.contineButton.UseVisualStyleBackColor = true;
            this.contineButton.Click += new System.EventHandler(this.contineButton_Click);
            // 
            // GameOverDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 168);
            this.Controls.Add(this.contineButton);
            this.Controls.Add(this.endTime);
            this.Controls.Add(this.endTimeLabel);
            this.Controls.Add(this.endMessage);
            this.Name = "GameOverDialogue";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GameOver";
            this.Load += new System.EventHandler(this.GameOverDialogue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.Label endMessage;
            private System.Windows.Forms.Label endTimeLabel;
            private System.Windows.Forms.Label endTime;
            private System.Windows.Forms.Button contineButton;
        }
    }
}