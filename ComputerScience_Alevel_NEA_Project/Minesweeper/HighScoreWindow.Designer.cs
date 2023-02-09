namespace Output
{
    namespace HighScores
    {
        partial class HighScoreWindow
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
            this.highScoreLabel = new System.Windows.Forms.Label();
            this.userNameColumnLabel = new System.Windows.Forms.Label();
            this.timeColumnLabel = new System.Windows.Forms.Label();
            this.dateColumnLabel = new System.Windows.Forms.Label();
            this.highScorePanel = new System.Windows.Forms.Panel();
            this.date = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.Label();
            this.highScoresGroupBox = new System.Windows.Forms.GroupBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.highScorePanel.SuspendLayout();
            this.highScoresGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // highScoreLabel
            // 
            this.highScoreLabel.AutoSize = true;
            this.highScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreLabel.Location = new System.Drawing.Point(103, 58);
            this.highScoreLabel.Name = "highScoreLabel";
            this.highScoreLabel.Size = new System.Drawing.Size(129, 25);
            this.highScoreLabel.TabIndex = 1;
            this.highScoreLabel.Text = "High Scores";
            // 
            // userNameColumnLabel
            // 
            this.userNameColumnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameColumnLabel.Location = new System.Drawing.Point(37, 137);
            this.userNameColumnLabel.Name = "userNameColumnLabel";
            this.userNameColumnLabel.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.userNameColumnLabel.Size = new System.Drawing.Size(80, 23);
            this.userNameColumnLabel.TabIndex = 2;
            this.userNameColumnLabel.Text = "Username";
            this.userNameColumnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeColumnLabel
            // 
            this.timeColumnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeColumnLabel.Location = new System.Drawing.Point(123, 142);
            this.timeColumnLabel.Name = "timeColumnLabel";
            this.timeColumnLabel.Size = new System.Drawing.Size(80, 13);
            this.timeColumnLabel.TabIndex = 3;
            this.timeColumnLabel.Text = "Time";
            this.timeColumnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateColumnLabel
            // 
            this.dateColumnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateColumnLabel.Location = new System.Drawing.Point(209, 142);
            this.dateColumnLabel.Name = "dateColumnLabel";
            this.dateColumnLabel.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.dateColumnLabel.Size = new System.Drawing.Size(80, 13);
            this.dateColumnLabel.TabIndex = 4;
            this.dateColumnLabel.Text = "Date";
            this.dateColumnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // highScorePanel
            // 
            this.highScorePanel.Controls.Add(this.date);
            this.highScorePanel.Controls.Add(this.time);
            this.highScorePanel.Controls.Add(this.userName);
            this.highScorePanel.Location = new System.Drawing.Point(6, 10);
            this.highScorePanel.Name = "highScorePanel";
            this.highScorePanel.Size = new System.Drawing.Size(260, 35);
            this.highScorePanel.TabIndex = 5;
            // 
            // date
            // 
            this.date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.Location = new System.Drawing.Point(175, 6);
            this.date.Name = "date";
            this.date.Padding = new System.Windows.Forms.Padding(3);
            this.date.Size = new System.Drawing.Size(80, 23);
            this.date.TabIndex = 6;
            this.date.Text = "Date";
            this.date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // time
            // 
            this.time.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time.Location = new System.Drawing.Point(89, 6);
            this.time.Name = "time";
            this.time.Padding = new System.Windows.Forms.Padding(3);
            this.time.Size = new System.Drawing.Size(80, 23);
            this.time.TabIndex = 6;
            this.time.Text = "Time";
            this.time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userName
            // 
            this.userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.Location = new System.Drawing.Point(3, 6);
            this.userName.Name = "userName";
            this.userName.Padding = new System.Windows.Forms.Padding(3);
            this.userName.Size = new System.Drawing.Size(80, 23);
            this.userName.TabIndex = 5;
            this.userName.Text = "Username";
            this.userName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // highScoresGroupBox
            // 
            this.highScoresGroupBox.Controls.Add(this.vScrollBar1);
            this.highScoresGroupBox.Controls.Add(this.highScorePanel);
            this.highScoresGroupBox.Location = new System.Drawing.Point(20, 163);
            this.highScoresGroupBox.Name = "highScoresGroupBox";
            this.highScoresGroupBox.Size = new System.Drawing.Size(294, 256);
            this.highScoresGroupBox.TabIndex = 6;
            this.highScoresGroupBox.TabStop = false;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar1.Location = new System.Drawing.Point(271, 7);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(20, 247);
            this.vScrollBar1.TabIndex = 6;
            // 
            // HighScoreWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 450);
            this.Controls.Add(this.highScoresGroupBox);
            this.Controls.Add(this.dateColumnLabel);
            this.Controls.Add(this.timeColumnLabel);
            this.Controls.Add(this.userNameColumnLabel);
            this.Controls.Add(this.highScoreLabel);
            this.Name = "HighScoreWindow";
            this.Text = "HighScoreWindow";
            this.highScorePanel.ResumeLayout(false);
            this.highScoresGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

            }

            #endregion
            private System.Windows.Forms.Label highScoreLabel;
            private System.Windows.Forms.Label userNameColumnLabel;
            private System.Windows.Forms.Label timeColumnLabel;
            private System.Windows.Forms.Label dateColumnLabel;
            private System.Windows.Forms.Panel highScorePanel;
            private System.Windows.Forms.Label date;
            private System.Windows.Forms.Label time;
            private System.Windows.Forms.Label userName;
            private System.Windows.Forms.GroupBox highScoresGroupBox;
            private System.Windows.Forms.VScrollBar vScrollBar1;
        }
    }
}