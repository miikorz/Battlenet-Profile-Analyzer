using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D3ArmoryTest
{
    public partial class GameChooser : Form
    {
        public GameChooser()
        {
            InitializeComponent();

            diabloButton.BackgroundImage = new Bitmap("./DiabloImages/diablo3resized.jpg");
            wowButton.BackgroundImage = new Bitmap("./WowImages/wowbutton.jpg");
            this.BackgroundImage = new Bitmap("./CommonResources/chooserbackground.png");
            exitButton.ImageLocation = "./CommonResources/exitbutton.png";
        }

        private void exitButton_MouseUp(object sender, MouseEventArgs e)
        {
            DialogResult confirmation = MessageBox.Show("Are you sure you want to exit?", "Warning", MessageBoxButtons.YesNo);
            if (confirmation == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                exitButton.ImageLocation = "./CommonResources/exitbutton.png";
            }
        }

        private void diabloButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProfileForm d3Form = new ProfileForm();
            if (d3Form.ShowDialog() == DialogResult.Cancel)
            {
                this.Show();
            }
        }

        private void wowButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            WowProfileForm wowForm = new WowProfileForm();
            if (wowForm.ShowDialog() == DialogResult.Cancel)
            {
                this.Show();
            }
        }

        private void exitButton_MouseHover(object sender, EventArgs e)
        {
            exitButton.ImageLocation = "./CommonResources/exitbutton2.png";
        }

        private void exitButton_MouseLeave(object sender, EventArgs e)
        {
            exitButton.ImageLocation = "./CommonResources/exitbutton.png";
        }

    }
}
