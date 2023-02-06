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
            this.label1 = new System.Windows.Forms.Label();
            this.beginnerRadioButton = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.intermediateRadioButton = new System.Windows.Forms.RadioButton();
            this.expertRadioButton = new System.Windows.Forms.RadioButton();
            this.customRadioButton = new System.Windows.Forms.RadioButton();
            this.difficultyLabel = new System.Windows.Forms.Label();
            this.widthUpDown = new System.Windows.Forms.NumericUpDown();
            this.customWidthLabel = new System.Windows.Forms.Label();
            this.customHeightLabel = new System.Windows.Forms.Label();
            this.heightUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.widthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(330, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Main Menu";
            // 
            // beginnerRadioButton
            // 
            this.beginnerRadioButton.AutoSize = true;
            this.beginnerRadioButton.Location = new System.Drawing.Point(539, 124);
            this.beginnerRadioButton.Name = "beginnerRadioButton";
            this.beginnerRadioButton.Size = new System.Drawing.Size(67, 17);
            this.beginnerRadioButton.TabIndex = 1;
            this.beginnerRadioButton.TabStop = true;
            this.beginnerRadioButton.Text = "Beginner";
            this.beginnerRadioButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(354, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start Game";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // intermediateRadioButton
            // 
            this.intermediateRadioButton.AutoSize = true;
            this.intermediateRadioButton.Location = new System.Drawing.Point(539, 147);
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
            this.expertRadioButton.Location = new System.Drawing.Point(539, 170);
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
            this.customRadioButton.Location = new System.Drawing.Point(539, 193);
            this.customRadioButton.Name = "customRadioButton";
            this.customRadioButton.Size = new System.Drawing.Size(60, 17);
            this.customRadioButton.TabIndex = 5;
            this.customRadioButton.TabStop = true;
            this.customRadioButton.Text = "Custom";
            this.customRadioButton.UseVisualStyleBackColor = true;
            // 
            // difficultyLabel
            // 
            this.difficultyLabel.AutoSize = true;
            this.difficultyLabel.Location = new System.Drawing.Point(552, 89);
            this.difficultyLabel.Name = "difficultyLabel";
            this.difficultyLabel.Size = new System.Drawing.Size(47, 13);
            this.difficultyLabel.TabIndex = 6;
            this.difficultyLabel.Text = "Difficulty";
            // 
            // widthUpDown
            // 
            this.widthUpDown.InterceptArrowKeys = false;
            this.widthUpDown.Location = new System.Drawing.Point(498, 279);
            this.widthUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.widthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthUpDown.Name = "widthUpDown";
            this.widthUpDown.Size = new System.Drawing.Size(80, 20);
            this.widthUpDown.TabIndex = 7;
            this.widthUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // customWidthLabel
            // 
            this.customWidthLabel.AutoSize = true;
            this.customWidthLabel.Location = new System.Drawing.Point(523, 247);
            this.customWidthLabel.Name = "customWidthLabel";
            this.customWidthLabel.Size = new System.Drawing.Size(35, 13);
            this.customWidthLabel.TabIndex = 8;
            this.customWidthLabel.Text = "Width";
            // 
            // customHeightLabel
            // 
            this.customHeightLabel.AutoSize = true;
            this.customHeightLabel.Location = new System.Drawing.Point(630, 247);
            this.customHeightLabel.Name = "customHeightLabel";
            this.customHeightLabel.Size = new System.Drawing.Size(38, 13);
            this.customHeightLabel.TabIndex = 9;
            this.customHeightLabel.Text = "Height";
            // 
            // heightUpDown
            // 
            this.heightUpDown.InterceptArrowKeys = false;
            this.heightUpDown.Location = new System.Drawing.Point(610, 279);
            this.heightUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.heightUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.heightUpDown.Name = "heightUpDown";
            this.heightUpDown.Size = new System.Drawing.Size(80, 20);
            this.heightUpDown.TabIndex = 10;
            this.heightUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MainMenuWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.heightUpDown);
            this.Controls.Add(this.customHeightLabel);
            this.Controls.Add(this.customWidthLabel);
            this.Controls.Add(this.widthUpDown);
            this.Controls.Add(this.difficultyLabel);
            this.Controls.Add(this.customRadioButton);
            this.Controls.Add(this.expertRadioButton);
            this.Controls.Add(this.intermediateRadioButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.beginnerRadioButton);
            this.Controls.Add(this.label1);
            this.Name = "MainMenuWindow";
            this.Text = "MainMenu";
            ((System.ComponentModel.ISupportInitialize)(this.widthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton beginnerRadioButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton intermediateRadioButton;
        private System.Windows.Forms.RadioButton expertRadioButton;
        private System.Windows.Forms.RadioButton customRadioButton;
        private System.Windows.Forms.Label difficultyLabel;
        private System.Windows.Forms.NumericUpDown widthUpDown;
        private System.Windows.Forms.Label customWidthLabel;
        private System.Windows.Forms.Label customHeightLabel;
        private System.Windows.Forms.NumericUpDown heightUpDown;
    }
}