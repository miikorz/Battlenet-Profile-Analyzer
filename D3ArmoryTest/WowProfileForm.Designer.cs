namespace D3ArmoryTest
{
    partial class WowProfileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WowProfileForm));
            this.clearButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.LanguageCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.serverTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.serverPicture = new System.Windows.Forms.PictureBox();
            this.flagPicture = new System.Windows.Forms.PictureBox();
            this.characterPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.serverPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flagPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(191, 111);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(55, 23);
            this.clearButton.TabIndex = 18;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(252, 111);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(55, 23);
            this.searchButton.TabIndex = 17;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // LanguageCombo
            // 
            this.LanguageCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageCombo.FormattingEnabled = true;
            this.LanguageCombo.Items.AddRange(new object[] {
            "English",
            "German",
            "Spanish",
            "French"});
            this.LanguageCombo.Location = new System.Drawing.Point(153, 73);
            this.LanguageCombo.Name = "LanguageCombo";
            this.LanguageCombo.Size = new System.Drawing.Size(95, 21);
            this.LanguageCombo.TabIndex = 16;
            this.LanguageCombo.SelectedIndexChanged += new System.EventHandler(this.LanguageCombo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Language";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(153, 18);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(125, 20);
            this.NameTextBox.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Character Name";
            // 
            // backButton
            // 
            this.backButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.backButton.Location = new System.Drawing.Point(12, 111);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // serverTextBox
            // 
            this.serverTextBox.Location = new System.Drawing.Point(153, 45);
            this.serverTextBox.Name = "serverTextBox";
            this.serverTextBox.Size = new System.Drawing.Size(125, 20);
            this.serverTextBox.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Realm";
            // 
            // serverPicture
            // 
            this.serverPicture.BackColor = System.Drawing.Color.Transparent;
            this.serverPicture.Location = new System.Drawing.Point(22, 45);
            this.serverPicture.Name = "serverPicture";
            this.serverPicture.Size = new System.Drawing.Size(22, 22);
            this.serverPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.serverPicture.TabIndex = 22;
            this.serverPicture.TabStop = false;
            // 
            // flagPicture
            // 
            this.flagPicture.BackColor = System.Drawing.Color.Transparent;
            this.flagPicture.Location = new System.Drawing.Point(22, 73);
            this.flagPicture.Name = "flagPicture";
            this.flagPicture.Size = new System.Drawing.Size(22, 22);
            this.flagPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.flagPicture.TabIndex = 20;
            this.flagPicture.TabStop = false;
            // 
            // characterPicture
            // 
            this.characterPicture.BackColor = System.Drawing.Color.Transparent;
            this.characterPicture.Location = new System.Drawing.Point(22, 18);
            this.characterPicture.Name = "characterPicture";
            this.characterPicture.Size = new System.Drawing.Size(22, 22);
            this.characterPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.characterPicture.TabIndex = 19;
            this.characterPicture.TabStop = false;
            // 
            // WowProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(319, 146);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.serverPicture);
            this.Controls.Add(this.serverTextBox);
            this.Controls.Add(this.flagPicture);
            this.Controls.Add(this.characterPicture);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.LanguageCombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WowProfileForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Battlenet Profile Analyzer";
            ((System.ComponentModel.ISupportInitialize)(this.serverPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flagPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox flagPicture;
        private System.Windows.Forms.PictureBox characterPicture;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ComboBox LanguageCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TextBox serverTextBox;
        private System.Windows.Forms.PictureBox serverPicture;
        private System.Windows.Forms.Label label2;
    }
}