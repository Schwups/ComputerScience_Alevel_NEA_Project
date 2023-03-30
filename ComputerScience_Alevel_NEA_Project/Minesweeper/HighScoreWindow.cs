using HighScoreSystem;
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
        // Class to handle display of the stored high scores
        public partial class HighScoreWindow : Form
        {
            HighScoresArray highScores;
            public HighScoreWindow(HighScoresArray highScores)
            {
                this.highScores = highScores;
                InitializeComponent();
            }
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                // Generates a panel containing each high score for each difficulty from the input HighScoresArray object

                beginnerTabPage.Controls.Add(CreateHighScorePanel(HighScoreUtilities.SortScoresByTime(highScores.beginnerHighScores.ToArray())));
                intermediateTabPage.Controls.Add(CreateHighScorePanel(HighScoreUtilities.SortScoresByTime(highScores.intermediateHighScores.ToArray())));
                expertTabPage.Controls.Add(CreateHighScorePanel(HighScoreUtilities.SortScoresByTime(highScores.expertHighScores.ToArray())));
            }

            private Panel CreateHighScorePanel(HighScore[] highScores)
            {
                // Generates a panel containing all of the high score data panels
                Panel highScoresPanel = new Panel()
                {
                    Location = new Point(14, 40),
                    Width = 274,
                    Height = 249,
                    AutoScroll = true,
                };

                int count = 0;
                foreach (HighScore score in highScores)
                {
                    Panel highScorePanel = CreateHighScorePanel(score);
                    highScorePanel.Location = new Point(6, 10 + (40 * count));
                    highScorePanel.Anchor = AnchorStyles.Top;
                    highScoresPanel.Controls.Add(highScorePanel);
                    count++;
                }
                if (count > 6)
                {
                    highScoresPanel.Width += 20;
                }
                return highScoresPanel;
            }
            private Panel CreateHighScorePanel(HighScore score)
            {
                // Generates a panel containing all of the data stored by a high score object
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
                    Name = "dateLabel",
                    Width = 80,
                    Height = 23,
                    Text = score.date.ToShortDateString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                };
                highScorePanel.Controls.Add(userNameLabel);
                highScorePanel.Controls.Add(timeLabel);
                highScorePanel.Controls.Add(dateLabel);
                return highScorePanel;
            }

            private void returnButton_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
    }
}