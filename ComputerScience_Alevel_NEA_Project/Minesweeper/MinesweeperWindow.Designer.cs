﻿namespace Output
{
    namespace MinesweeperOutput
    {
        partial class MinesweeperWindow
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
            this.gridControls = new System.Windows.Forms.TableLayoutPanel();
            this.mineCounter = new System.Windows.Forms.Label();
            this.clockDisplay = new System.Windows.Forms.Label();
            this.minesLeftLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gridControls
            // 
            this.gridControls.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gridControls.ColumnCount = 1;
            this.gridControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.3871F));
            this.gridControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.6129F));
            this.gridControls.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.gridControls.Location = new System.Drawing.Point(50, 100);
            this.gridControls.Margin = new System.Windows.Forms.Padding(0);
            this.gridControls.Name = "gridControls";
            this.gridControls.RowCount = 1;
            this.gridControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gridControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gridControls.Size = new System.Drawing.Size(300, 69);
            this.gridControls.TabIndex = 8;
            // 
            // mineCounter
            // 
            this.mineCounter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mineCounter.Location = new System.Drawing.Point(50, 57);
            this.mineCounter.Margin = new System.Windows.Forms.Padding(3);
            this.mineCounter.Name = "mineCounter";
            this.mineCounter.Size = new System.Drawing.Size(85, 14);
            this.mineCounter.TabIndex = 10;
            this.mineCounter.Text = "mineCounter";
            this.mineCounter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // clockDisplay
            // 
            this.clockDisplay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.clockDisplay.Location = new System.Drawing.Point(198, 57);
            this.clockDisplay.Name = "clockDisplay";
            this.clockDisplay.Size = new System.Drawing.Size(50, 14);
            this.clockDisplay.TabIndex = 11;
            this.clockDisplay.Text = "Clock";
            this.clockDisplay.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // minesLeftLabel
            // 
            this.minesLeftLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.minesLeftLabel.Location = new System.Drawing.Point(50, 36);
            this.minesLeftLabel.Name = "minesLeftLabel";
            this.minesLeftLabel.Size = new System.Drawing.Size(85, 14);
            this.minesLeftLabel.TabIndex = 12;
            this.minesLeftLabel.Text = "Mines left:";
            // 
            // timeLabel
            // 
            this.timeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.timeLabel.Location = new System.Drawing.Point(198, 36);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(50, 14);
            this.timeLabel.TabIndex = 13;
            this.timeLabel.Text = "Time:";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MinesweeperWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 200);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.minesLeftLabel);
            this.Controls.Add(this.clockDisplay);
            this.Controls.Add(this.mineCounter);
            this.Controls.Add(this.gridControls);
            this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Name = "MinesweeperWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

            }

            #endregion
            private System.Windows.Forms.TableLayoutPanel gridControls;
            private System.Windows.Forms.Label mineCounter;
            private System.Windows.Forms.Label clockDisplay;
            private System.Windows.Forms.Label minesLeftLabel;
            private System.Windows.Forms.Label timeLabel;
        }
    }
}