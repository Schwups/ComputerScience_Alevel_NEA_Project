namespace Output
{
    namespace MainMenu
    {
        partial class MainMenuWindow
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
            this.mainMenuLabel = new System.Windows.Forms.Label();
            this.beginnerRadioButton = new System.Windows.Forms.RadioButton();
            this.startGameButton = new System.Windows.Forms.Button();
            this.intermediateRadioButton = new System.Windows.Forms.RadioButton();
            this.expertRadioButton = new System.Windows.Forms.RadioButton();
            this.customRadioButton = new System.Windows.Forms.RadioButton();
            this.difficultyLabel = new System.Windows.Forms.Label();
            this.customWidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.customWidthLabel = new System.Windows.Forms.Label();
            this.customHeightLabel = new System.Windows.Forms.Label();
            this.customHeightUpDown = new System.Windows.Forms.NumericUpDown();
            this.customMineCountUpDown = new System.Windows.Forms.NumericUpDown();
            this.customMineCountLabel = new System.Windows.Forms.Label();
            this.customSeedCheckBox = new System.Windows.Forms.CheckBox();
            this.customSeedUpDown = new System.Windows.Forms.NumericUpDown();
            this.exitGameButton = new System.Windows.Forms.Button();
            this.highScoreButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customWidthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customHeightUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customMineCountUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customSeedUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuLabel
            // 
            this.mainMenuLabel.AutoSize = true;
            this.mainMenuLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenuLabel.Location = new System.Drawing.Point(105, 34);
            this.mainMenuLabel.Name = "mainMenuLabel";
            this.mainMenuLabel.Size = new System.Drawing.Size(119, 26);
            this.mainMenuLabel.TabIndex = 0;
            this.mainMenuLabel.Text = "Main Menu";
            // 
            // beginnerRadioButton
            // 
            this.beginnerRadioButton.AutoSize = true;
            this.beginnerRadioButton.Location = new System.Drawing.Point(122, 111);
            this.beginnerRadioButton.Name = "beginnerRadioButton";
            this.beginnerRadioButton.Size = new System.Drawing.Size(67, 17);
            this.beginnerRadioButton.TabIndex = 1;
            this.beginnerRadioButton.TabStop = true;
            this.beginnerRadioButton.Text = "Beginner";
            this.beginnerRadioButton.UseVisualStyleBackColor = true;
            // 
            // startGameButton
            // 
            this.startGameButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.startGameButton.Location = new System.Drawing.Point(125, 326);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(75, 23);
            this.startGameButton.TabIndex = 2;
            this.startGameButton.Text = "Start Game";
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // intermediateRadioButton
            // 
            this.intermediateRadioButton.AutoSize = true;
            this.intermediateRadioButton.Location = new System.Drawing.Point(122, 134);
            this.intermediateRadioButton.Name = "intermediateRadioButton";
            this.intermediateRadioButton.Size = new System.Drawing.Size(83, 17);
            this.intermediateRadioButton.TabIndex = 3;
            this.intermediateRadioButton.TabStop = true;
            this.intermediateRadioButton.Text = "Intermediate";
            this.intermediateRadioButton.UseVisualStyleBackColor = true;
            // 
            // expertRadioButton
            // 
            this.expertRadioButton.AutoSize = true;
            this.expertRadioButton.Location = new System.Drawing.Point(122, 157);
            this.expertRadioButton.Name = "expertRadioButton";
            this.expertRadioButton.Size = new System.Drawing.Size(52, 17);
            this.expertRadioButton.TabIndex = 4;
            this.expertRadioButton.TabStop = true;
            this.expertRadioButton.Text = "Exper";
            this.expertRadioButton.UseVisualStyleBackColor = true;
            // 
            // customRadioButton
            // 
            this.customRadioButton.AutoSize = true;
            this.customRadioButton.Location = new System.Drawing.Point(122, 180);
            this.customRadioButton.Name = "customRadioButton";
            this.customRadioButton.Size = new System.Drawing.Size(60, 17);
            this.customRadioButton.TabIndex = 5;
            this.customRadioButton.TabStop = true;
            this.customRadioButton.Text = "Custom";
            this.customRadioButton.UseVisualStyleBackColor = true;
            this.customRadioButton.CheckedChanged += new System.EventHandler(this.customRadioButton_CheckedChanged);
            // 
            // difficultyLabel
            // 
            this.difficultyLabel.AutoSize = true;
            this.difficultyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.difficultyLabel.Location = new System.Drawing.Point(135, 82);
            this.difficultyLabel.Name = "difficultyLabel";
            this.difficultyLabel.Size = new System.Drawing.Size(65, 17);
            this.difficultyLabel.TabIndex = 6;
            this.difficultyLabel.Text = "Difficulty:";
            // 
            // customWidthUpDown
            // 
            this.customWidthUpDown.InterceptArrowKeys = false;
            this.customWidthUpDown.Location = new System.Drawing.Point(39, 232);
            this.customWidthUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.customWidthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.customWidthUpDown.Name = "customWidthUpDown";
            this.customWidthUpDown.Size = new System.Drawing.Size(80, 20);
            this.customWidthUpDown.TabIndex = 7;
            this.customWidthUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // customWidthLabel
            // 
            this.customWidthLabel.AutoSize = true;
            this.customWidthLabel.Location = new System.Drawing.Point(59, 216);
            this.customWidthLabel.Name = "customWidthLabel";
            this.customWidthLabel.Size = new System.Drawing.Size(35, 13);
            this.customWidthLabel.TabIndex = 8;
            this.customWidthLabel.Text = "Width";
            // 
            // customHeightLabel
            // 
            this.customHeightLabel.AutoSize = true;
            this.customHeightLabel.Location = new System.Drawing.Point(142, 216);
            this.customHeightLabel.Name = "customHeightLabel";
            this.customHeightLabel.Size = new System.Drawing.Size(38, 13);
            this.customHeightLabel.TabIndex = 9;
            this.customHeightLabel.Text = "Height";
            // 
            // customHeightUpDown
            // 
            this.customHeightUpDown.InterceptArrowKeys = false;
            this.customHeightUpDown.Location = new System.Drawing.Point(125, 232);
            this.customHeightUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.customHeightUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.customHeightUpDown.Name = "customHeightUpDown";
            this.customHeightUpDown.Size = new System.Drawing.Size(80, 20);
            this.customHeightUpDown.TabIndex = 10;
            this.customHeightUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // customMineCountUpDown
            // 
            this.customMineCountUpDown.InterceptArrowKeys = false;
            this.customMineCountUpDown.Location = new System.Drawing.Point(211, 232);
            this.customMineCountUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.customMineCountUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.customMineCountUpDown.Name = "customMineCountUpDown";
            this.customMineCountUpDown.Size = new System.Drawing.Size(80, 20);
            this.customMineCountUpDown.TabIndex = 11;
            this.customMineCountUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // customMineCountLabel
            // 
            this.customMineCountLabel.AutoSize = true;
            this.customMineCountLabel.Location = new System.Drawing.Point(211, 216);
            this.customMineCountLabel.Name = "customMineCountLabel";
            this.customMineCountLabel.Size = new System.Drawing.Size(70, 13);
            this.customMineCountLabel.TabIndex = 12;
            this.customMineCountLabel.Text = "Mine Number";
            // 
            // customSeedCheckBox
            // 
            this.customSeedCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.customSeedCheckBox.AutoSize = true;
            this.customSeedCheckBox.Location = new System.Drawing.Point(110, 274);
            this.customSeedCheckBox.Name = "customSeedCheckBox";
            this.customSeedCheckBox.Size = new System.Drawing.Size(111, 17);
            this.customSeedCheckBox.TabIndex = 13;
            this.customSeedCheckBox.Text = "Use Custom Seed";
            this.customSeedCheckBox.UseVisualStyleBackColor = true;
            this.customSeedCheckBox.CheckedChanged += new System.EventHandler(this.customSeedCheckBox_CheckedChanged);
            // 
            // customSeedUpDown
            // 
            this.customSeedUpDown.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.customSeedUpDown.InterceptArrowKeys = false;
            this.customSeedUpDown.Location = new System.Drawing.Point(125, 299);
            this.customSeedUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.customSeedUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.customSeedUpDown.Name = "customSeedUpDown";
            this.customSeedUpDown.Size = new System.Drawing.Size(80, 20);
            this.customSeedUpDown.TabIndex = 14;
            this.customSeedUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.customSeedUpDown.Visible = false;
            // 
            // exitGameButton
            // 
            this.exitGameButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.exitGameButton.Location = new System.Drawing.Point(213, 326);
            this.exitGameButton.Name = "exitGameButton";
            this.exitGameButton.Size = new System.Drawing.Size(75, 23);
            this.exitGameButton.TabIndex = 15;
            this.exitGameButton.Text = "Exit Game";
            this.exitGameButton.UseVisualStyleBackColor = true;
            this.exitGameButton.Click += new System.EventHandler(this.exitGameButton_Click);
            // 
            // highScoreButton
            // 
            this.highScoreButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.highScoreButton.Location = new System.Drawing.Point(37, 327);
            this.highScoreButton.Name = "highScoreButton";
            this.highScoreButton.Size = new System.Drawing.Size(75, 23);
            this.highScoreButton.TabIndex = 16;
            this.highScoreButton.Text = "High Scores";
            this.highScoreButton.UseVisualStyleBackColor = true;
            this.highScoreButton.Click += new System.EventHandler(this.highScoreButton_Click);
            // 
            // MainMenuWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 361);
            this.Controls.Add(this.highScoreButton);
            this.Controls.Add(this.exitGameButton);
            this.Controls.Add(this.customSeedUpDown);
            this.Controls.Add(this.customSeedCheckBox);
            this.Controls.Add(this.customMineCountLabel);
            this.Controls.Add(this.customMineCountUpDown);
            this.Controls.Add(this.customHeightUpDown);
            this.Controls.Add(this.customHeightLabel);
            this.Controls.Add(this.customWidthLabel);
            this.Controls.Add(this.customWidthUpDown);
            this.Controls.Add(this.difficultyLabel);
            this.Controls.Add(this.customRadioButton);
            this.Controls.Add(this.expertRadioButton);
            this.Controls.Add(this.intermediateRadioButton);
            this.Controls.Add(this.startGameButton);
            this.Controls.Add(this.beginnerRadioButton);
            this.Controls.Add(this.mainMenuLabel);
            this.Name = "MainMenuWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            ((System.ComponentModel.ISupportInitialize)(this.customWidthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customHeightUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customMineCountUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customSeedUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.Label mainMenuLabel;
            private System.Windows.Forms.RadioButton beginnerRadioButton;
            private System.Windows.Forms.Button startGameButton;
            private System.Windows.Forms.RadioButton intermediateRadioButton;
            private System.Windows.Forms.RadioButton expertRadioButton;
            private System.Windows.Forms.RadioButton customRadioButton;
            private System.Windows.Forms.Label difficultyLabel;
            private System.Windows.Forms.NumericUpDown customWidthUpDown;
            private System.Windows.Forms.Label customWidthLabel;
            private System.Windows.Forms.Label customHeightLabel;
            private System.Windows.Forms.NumericUpDown customHeightUpDown;
            private System.Windows.Forms.NumericUpDown customMineCountUpDown;
            private System.Windows.Forms.Label customMineCountLabel;
            private System.Windows.Forms.CheckBox customSeedCheckBox;
            private System.Windows.Forms.NumericUpDown customSeedUpDown;
            private System.Windows.Forms.Button exitGameButton;
            private System.Windows.Forms.Button highScoreButton;
        }
    }
}