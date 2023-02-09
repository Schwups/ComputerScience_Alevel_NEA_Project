﻿using HighScoreSystem;
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
    namespace HighScores
    {
        public partial class HighScoreWindow : Form
        {
            public HighScoreWindow()
            {
                InitializeComponent();
            }
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                AddHighScorePanels(HighScoreUtilities.GetHighScores());
            }

            private void AddHighScorePanels(HighScore[] highScores)
            {
                int count = 0;
                foreach (HighScore score in highScores)
                {
                    Panel highScorePanel = CreateHighScorePanel(score);
                    highScorePanel.Location = new Point(6, 10 + (40 * count));
                    highScoresGroupBox.Controls.Add(highScorePanel);
                    count++;
                }
            }
            private Panel CreateHighScorePanel(HighScore score)
            {
                Panel highScorePanel = new Panel()
                {
                    Name = "highScorePanel",
                    Width = 260,
                    Height = 35,
                };
                var userNameLabel = new Label
                {
                    AutoEllipsis = true,
                    AutoSize = false,
                    Location = new Point(3, 6),
                    Name = "userNameLabel",
                    Width = 80,
                    Height = 23,
                    Text = score.userName,
                    TextAlign = ContentAlignment.MiddleCenter,
                };
                var timeLabel = new Label
                {
                    AutoEllipsis = true,
                    AutoSize = false,
                    Location = new Point(89, 6),
                    Name = "timeLabel",
                    Width = 80,
                    Height = 23,
                    Text = score.time.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                };
                var dateLabel = new Label
                {
                    AutoEllipsis = true,
                    AutoSize = false,
                    Location = new Point(175, 6),
                    Name = "userNameLabel",
                    Width = 80,
                    Height = 23,
                    Text = score.date.Date.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                };
                highScorePanel.Controls.Add(userNameLabel);
                highScorePanel.Controls.Add(timeLabel);
                highScorePanel.Controls.Add(dateLabel);
                return highScorePanel;
            }
        }
    }
}