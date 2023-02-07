using Output.MinesweeperOutput;
using Output.ErrorOutput;
using SupportComponents;
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
            public MainMenuWindow()
            {
                InitializeComponent();
            }
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                HideCustomMenu();
                beginnerRadioButton.Checked = true;
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
                    gameWindow.Dispose();
                    this.Show();
                }
                catch (ArgumentException ex)
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

            const byte customMenuHeight = 50;
            private void ShowCustomMenu()
            {
                //this.Height = this.Height + customMenuHeight;
                //customWidthLabel.Show();
                //customWidthUpDown.Show();
                //customHeightLabel.Show();
                //customHeightUpDown.Show();
                //customMineCountLabel.Show();
                //customMineCountUpDown.Show();
                this.Height = this.Height + customDifficultySettingsPanel.Height;
                customDifficultySettingsPanel.Show();
            }
            private void HideCustomMenu()
            {
                //this.Height = this.Height - customMenuHeight;
                //customWidthLabel.Hide();
                //customWidthUpDown.Hide();
                //customHeightLabel.Hide();
                //customHeightUpDown.Hide();
                //customMineCountLabel.Hide();
                //customMineCountUpDown.Hide();
                this.Height = this.Height - customDifficultySettingsPanel.Height;
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

            private void highScoreButton_Click(object sender, EventArgs e)
            {
                ShowErrorWindow(new NotImplementedException("Fuck you this isnt implemented yet\nDumb Fuck"));
            }
            private void exitGameButton_Click(object sender, EventArgs e)
            {
                this.Close();
            }
            private void ShowErrorWindow(Exception ex)
            {
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