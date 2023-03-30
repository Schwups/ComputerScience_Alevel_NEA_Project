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
            this.highScorePanel = new System.Windows.Forms.Panel();
            this.date = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.Label();
            this.highScoresPanel = new System.Windows.Forms.Panel();
            this.highScoreTabControl = new System.Windows.Forms.TabControl();
            this.beginnerTabPage = new System.Windows.Forms.TabPage();
            this.dateColumnLabel = new System.Windows.Forms.Label();
            this.timeColumnLabel = new System.Windows.Forms.Label();
            this.userNameColumnLabel = new System.Windows.Forms.Label();
            this.intermediateTabPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.expertTabPage = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.returnButton = new System.Windows.Forms.Button();
            this.highScorePanel.SuspendLayout();
            this.highScoresPanel.SuspendLayout();
            this.highScoreTabControl.SuspendLayout();
            this.beginnerTabPage.SuspendLayout();
            this.intermediateTabPage.SuspendLayout();
            this.expertTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // highScoreLabel
            // 
            this.highScoreLabel.AutoSize = true;
            this.highScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreLabel.Location = new System.Drawing.Point(103, 15);
            this.highScoreLabel.Name = "highScoreLabel";
            this.highScoreLabel.Size = new System.Drawing.Size(129, 25);
            this.highScoreLabel.TabIndex = 1;
            this.highScoreLabel.Text = "High Scores";
            // 
            // highScorePanel
            // 
            this.highScorePanel.Controls.Add(this.date);
            this.highScorePanel.Controls.Add(this.time);
            this.highScorePanel.Controls.Add(this.userName);
            this.highScorePanel.Location = new System.Drawing.Point(6, 12);
            this.highScorePanel.Name = "highScorePanel";
            this.highScorePanel.Size = new System.Drawing.Size(260, 35);
            this.highScorePanel.TabIndex = 5;
            this.highScorePanel.Visible = false;
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
            // highScoresPanel
            // 
            this.highScoresPanel.AutoScroll = true;
            this.highScoresPanel.Controls.Add(this.highScorePanel);
            this.highScoresPanel.Location = new System.Drawing.Point(14, 40);
            this.highScoresPanel.Name = "highScoresPanel";
            this.highScoresPanel.Size = new System.Drawing.Size(274, 249);
            this.highScoresPanel.TabIndex = 7;
            this.highScoresPanel.Visible = false;
            // 
            // highScoreTabControl
            // 
            this.highScoreTabControl.Controls.Add(this.beginnerTabPage);
            this.highScoreTabControl.Controls.Add(this.intermediateTabPage);
            this.highScoreTabControl.Controls.Add(this.expertTabPage);
            this.highScoreTabControl.Location = new System.Drawing.Point(12, 49);
            this.highScoreTabControl.Name = "highScoreTabControl";
            this.highScoreTabControl.SelectedIndex = 0;
            this.highScoreTabControl.Size = new System.Drawing.Size(314, 325);
            this.highScoreTabControl.TabIndex = 7;
            // 
            // beginnerTabPage
            // 
            this.beginnerTabPage.Controls.Add(this.highScoresPanel);
            this.beginnerTabPage.Controls.Add(this.dateColumnLabel);
            this.beginnerTabPage.Controls.Add(this.timeColumnLabel);
            this.beginnerTabPage.Controls.Add(this.userNameColumnLabel);
            this.beginnerTabPage.Location = new System.Drawing.Point(4, 22);
            this.beginnerTabPage.Name = "beginnerTabPage";
            this.beginnerTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.beginnerTabPage.Size = new System.Drawing.Size(306, 299);
            this.beginnerTabPage.TabIndex = 0;
            this.beginnerTabPage.Text = "beginner";
            this.beginnerTabPage.UseVisualStyleBackColor = true;
            // 
            // dateColumnLabel
            // 
            this.dateColumnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateColumnLabel.Location = new System.Drawing.Point(195, 19);
            this.dateColumnLabel.Name = "dateColumnLabel";
            this.dateColumnLabel.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.dateColumnLabel.Size = new System.Drawing.Size(80, 13);
            this.dateColumnLabel.TabIndex = 7;
            this.dateColumnLabel.Text = "Date";
            this.dateColumnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeColumnLabel
            // 
            this.timeColumnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeColumnLabel.Location = new System.Drawing.Point(109, 19);
            this.timeColumnLabel.Name = "timeColumnLabel";
            this.timeColumnLabel.Size = new System.Drawing.Size(80, 13);
            this.timeColumnLabel.TabIndex = 6;
            this.timeColumnLabel.Text = "Time";
            this.timeColumnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userNameColumnLabel
            // 
            this.userNameColumnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameColumnLabel.Location = new System.Drawing.Point(23, 14);
            this.userNameColumnLabel.Name = "userNameColumnLabel";
            this.userNameColumnLabel.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.userNameColumnLabel.Size = new System.Drawing.Size(80, 23);
            this.userNameColumnLabel.TabIndex = 5;
            this.userNameColumnLabel.Text = "Username";
            this.userNameColumnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // intermediateTabPage
            // 
            this.intermediateTabPage.Controls.Add(this.label1);
            this.intermediateTabPage.Controls.Add(this.label2);
            this.intermediateTabPage.Controls.Add(this.label3);
            this.intermediateTabPage.Location = new System.Drawing.Point(4, 22);
            this.intermediateTabPage.Name = "intermediateTabPage";
            this.intermediateTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.intermediateTabPage.Size = new System.Drawing.Size(306, 299);
            this.intermediateTabPage.TabIndex = 1;
            this.intermediateTabPage.Text = "intermediate";
            this.intermediateTabPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(195, 19);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(109, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Time";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 14);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label3.Size = new System.Drawing.Size(80, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Username";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // expertTabPage
            // 
            this.expertTabPage.Controls.Add(this.label4);
            this.expertTabPage.Controls.Add(this.label5);
            this.expertTabPage.Controls.Add(this.label6);
            this.expertTabPage.Location = new System.Drawing.Point(4, 22);
            this.expertTabPage.Name = "expertTabPage";
            this.expertTabPage.Size = new System.Drawing.Size(306, 299);
            this.expertTabPage.TabIndex = 2;
            this.expertTabPage.Text = "expert";
            this.expertTabPage.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(195, 19);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Date";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(109, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Time";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 14);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label6.Size = new System.Drawing.Size(80, 23);
            this.label6.TabIndex = 11;
            this.label6.Text = "Username";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(112, 382);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(110, 23);
            this.returnButton.TabIndex = 8;
            this.returnButton.Text = "Back to main menu";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // HighScoreWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 417);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.highScoreTabControl);
            this.Controls.Add(this.highScoreLabel);
            this.Name = "HighScoreWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HighScoreWindow";
            this.highScorePanel.ResumeLayout(false);
            this.highScoresPanel.ResumeLayout(false);
            this.highScoreTabControl.ResumeLayout(false);
            this.beginnerTabPage.ResumeLayout(false);
            this.intermediateTabPage.ResumeLayout(false);
            this.expertTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

            }

            #endregion
            private System.Windows.Forms.Label highScoreLabel;
            private System.Windows.Forms.Panel highScorePanel;
            private System.Windows.Forms.Label date;
            private System.Windows.Forms.Label time;
            private System.Windows.Forms.Label userName;
            private System.Windows.Forms.Panel highScoresPanel;
            private System.Windows.Forms.TabControl highScoreTabControl;
            private System.Windows.Forms.TabPage beginnerTabPage;
            private System.Windows.Forms.TabPage intermediateTabPage;
            private System.Windows.Forms.Label dateColumnLabel;
            private System.Windows.Forms.Label timeColumnLabel;
            private System.Windows.Forms.Label userNameColumnLabel;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.Label label3;
            private System.Windows.Forms.TabPage expertTabPage;
            private System.Windows.Forms.Label label4;
            private System.Windows.Forms.Label label5;
            private System.Windows.Forms.Label label6;
            private System.Windows.Forms.Button returnButton;
        }
    }
}