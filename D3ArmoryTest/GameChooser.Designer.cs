namespace D3ArmoryTest
{
    partial class GameChooser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameChooser));
            this.diabloButton = new System.Windows.Forms.Button();
            this.wowButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).BeginInit();
            this.SuspendLayout();
            // 
            // diabloButton
            // 
            this.diabloButton.Location = new System.Drawing.Point(12, 12);
            this.diabloButton.Name = "diabloButton";
            this.diabloButton.Size = new System.Drawing.Size(566, 105);
            this.diabloButton.TabIndex = 4;
            this.diabloButton.UseVisualStyleBackColor = true;
            this.diabloButton.Click += new System.EventHandler(this.diabloButton_Click);
            // 
            // wowButton
            // 
            this.wowButton.Location = new System.Drawing.Point(12, 123);
            this.wowButton.Name = "wowButton";
            this.wowButton.Size = new System.Drawing.Size(566, 105);
            this.wowButton.TabIndex = 5;
            this.wowButton.UseVisualStyleBackColor = true;
            this.wowButton.Click += new System.EventHandler(this.wowButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.Location = new System.Drawing.Point(244, 234);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(110, 45);
            this.exitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exitButton.TabIndex = 6;
            this.exitButton.TabStop = false;
            this.exitButton.MouseLeave += new System.EventHandler(this.exitButton_MouseLeave);
            this.exitButton.MouseHover += new System.EventHandler(this.exitButton_MouseHover);
            this.exitButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.exitButton_MouseUp);
            // 
            // GameChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(590, 291);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.wowButton);
            this.Controls.Add(this.diabloButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameChooser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameChooser";
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button diabloButton;
        private System.Windows.Forms.Button wowButton;
        private System.Windows.Forms.PictureBox exitButton;
    }
}