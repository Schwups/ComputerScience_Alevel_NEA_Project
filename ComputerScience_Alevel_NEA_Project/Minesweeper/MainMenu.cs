using Output.MinesweeperOutput;
using Output.ErrorOutput;
using Output.HighScores;
using HighScoreSystem;
using MinesweeperGame.SupportComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Output
{
    namespace MainMenu
    {
        public partial class MainMenuWindow : Form
        {
            private MinesweeperWindow gameWindow;
            private HighScoresArray highScores;
            public MainMenuWindow()
            {
                InitializeComponent();
            }
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                HideCustomMenu();
                beginnerRadioButton.Checked = true;
                highScores = HighScoreUtilities.GetHighScores();
            }
            protected override void OnClosed(EventArgs e)
            {
                base.OnClosed(e);
                HighScoreUtilities.UpdateHighScores(highScores);
            }
            private void startGameButton_Click(object sender, EventArgs e)
            {
                try
                {
                    GameParameters gameParameters;
                    string gameSeed;
                    if (customSeedCheckBox.Checked)
                    {
                        gameSeed = customSeedUpDown.Value.ToString();
                    }
                    else
                    {
                        gameSeed = null;
                    }

                    switch (difficultyGroupBox.Controls.OfType<RadioButton>().FirstOrDefault(Ctrl => Ctrl.Checked).Name)
                    {
                        case "customRadioButton":
                            gameParameters = new GameParameters()
                            {
                                width = (short)customWidthUpDown.Value,
                                height = (short)customHeightUpDown.Value,
                                mineCount = (int)customMineCountUpDown.Value,
                                gameSeed = gameSeed,
                                gameDifficulty = Difficulty.Custom,
                            };
                            break;
                        case "beginnerRadioButton":
                            gameParameters = new GameParameters()
                            {
                                width = 9,
                                height = 9,
                                mineCount = 10,
                                gameSeed = gameSeed,
                                gameDifficulty = Difficulty.Beginner,
                            };
                            break;
                        case "intermediateRadioButton":
                            gameParameters = new GameParameters()
                            {
                                width = 16,
                                height = 16,
                                mineCount = 40,
                                gameSeed = gameSeed,
                                gameDifficulty = Difficulty.Intermediate,
                            };
                            break;
                        case "expertRadioButton":
                            gameParameters = new GameParameters()
                            {
                                width = 30,
                                height = 16,
                                mineCount = 99,
                                gameSeed = gameSeed,
                                gameDifficulty = Difficulty.Expert,
                            };
                            break;
                        default:
                            throw new ArgumentException("No difficulty selected");
                    }
                    gameWindow = new MinesweeperWindow(gameParameters);
                    this.Hide();
                    gameWindow.ShowDialog();
                    if (gameWindow.endState == GameState.Won)
                    {
                        AddHighScore(gameWindow.endTime, gameWindow.gameParameters);
                    }
                    gameWindow.Dispose();
                    this.Show();
                }
                catch (Exception ex)
                {
                    ShowErrorWindow(ex);                    
                }
            }

            private void customRadioButton_CheckedChanged(object sender, EventArgs e)
            {
                if (customRadioButton.Checked)
                {
                    ShowCustomMenu();
                }
                else
                {
                    HideCustomMenu();
                }
            }
            private void ShowCustomMenu()
            {
                this.Height += customDifficultySettingsPanel.Height;
                customDifficultySettingsPanel.Show();
            }
            private void HideCustomMenu()
            {
                this.Height -= customDifficultySettingsPanel.Height;
                customDifficultySettingsPanel.Hide();
            }

            private void customSeedCheckBox_CheckedChanged(object sender, EventArgs e)
            {
                if (customSeedCheckBox.Checked)
                {
                    customSeedUpDown.Show();
                }
                else
                {
                    customSeedUpDown.Hide();
                }
            }

            private void AddHighScore(long timeTaken, GameParameters gameParameters)
            {
                string userName = String.IsNullOrWhiteSpace(userNameTextBox.Text) ? "Unknown" : userNameTextBox.Text;
                switch (gameParameters.gameDifficulty)
                {
                    case Difficulty.Beginner:
                        highScores.beginnerHighScores.Add(
                            new HighScore()
                            {
                                userName = userName,
                                time = (int)(timeTaken / 1000),
                                date = DateTime.Now
                            });
                        break;
                    case Difficulty.Intermediate:
                        highScores.intermediateHighScores.Add(
                            new HighScore()
                            {
                                userName = userName,
                                time = (int)(timeTaken / 1000),
                                date = DateTime.Now
                            });
                        break;
                    case Difficulty.Expert:
                        highScores.expertHighScores.Add(
                            new HighScore()
                            {
                                userName = userName,
                                time = (int)(timeTaken / 1000),
                                date = DateTime.Now
                            });
                        break;
                    default:
                        break;
                }
            }

            private void highScoreButton_Click(object sender, EventArgs e)
            {

                HighScoreWindow highScoresWindow = new HighScoreWindow(highScores);
                this.Hide();
                highScoresWindow.ShowDialog();
                this.Show();
                highScoresWindow.Dispose();
            }
            private void exitGameButton_Click(object sender, EventArgs e)
            {
                this.Close();
            }
            private void ShowErrorWindow(Exception ex)
            {
                this.Show();
                Debug.Write($"Error occoured: {ex.Message}\nMore details:{ex.ToString()}\n");
                ErrorWindow errorWindow = new ErrorWindow(ex);
                errorWindow.ShowDialog();
                if (errorWindow.DialogResult == DialogResult.Abort)
                {
                    System.Environment.Exit(1);
                }
                errorWindow.Dispose();
            }
        }
    }
}