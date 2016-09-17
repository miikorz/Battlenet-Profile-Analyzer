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
    public partial class ProfileForm : Form
    {
        public String BattleTag { get; set; }
        public String Language { get; set; }
        private Image btnetBackground;
        private Boolean profileFound;

        public ProfileForm()
        {
            InitializeComponent();
            LanguageCombo.SelectedIndex = 0;
            pictureBox1.ImageLocation = "./CommonResources/battlenet.png";
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox2.ImageLocation = "./EuropeFlags/UnitedKingDom.png";
            pictureBox2.BackColor = System.Drawing.Color.Transparent;
            btnetBackground = new Bitmap("./CommonResources/background2.png");
            this.BackgroundImage = btnetBackground;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.ForeColor = System.Drawing.Color.LightBlue;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.ForeColor = System.Drawing.Color.LightBlue;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.ForeColor = System.Drawing.Color.LightBlue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NameTextBox.Text = "";
            IDTextBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BattleTag = NameTextBox.Text +"-"+ IDTextBox.Text;
            switch (LanguageCombo.SelectedIndex)
            {
                case 1:
                    Language = "de_DE";
                    break;
                case 2:
                    Language = "es_ES";
                    break;
                case 3:
                    Language = "fr_FR";
                    break;
                case 4:
                    Language = "it_IT";
                    break;
                case 5:
                    Language = "pl_PL";
                    break;
                case 6:
                    Language = "pt_PT";
                    break;
                case 7:
                    Language = "ru_RU";
                    break;
                default:
                    Language = "en_GB";
                    break;
            }

            this.Hide();         
            ProfileShower profileShower = new ProfileShower(this);
            if (profileShower.ShowDialog() == DialogResult.Cancel)
            {
                profileFound = profileShower.profileFound;
                this.Show();

                if (!profileFound)
                {
                   MessageBox.Show("Incorrect profile or doesn't exist", "Not Found", MessageBoxButtons.OK);
                }
            }


        }

        private void LanguageCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (LanguageCombo.SelectedIndex)
            {
                case 1:
                    pictureBox2.ImageLocation = "./EuropeFlags/Germany.png";
                    break;
                case 2:
                    pictureBox2.ImageLocation = "./EuropeFlags/Spain.png";
                    break;
                case 3:
                    pictureBox2.ImageLocation = "./EuropeFlags/France.png";
                    break;
                case 4:
                    pictureBox2.ImageLocation = "./EuropeFlags/Italy.png";
                    break;
                case 5:
                    pictureBox2.ImageLocation = "./EuropeFlags/Poland.png";
                    break;
                case 6:
                    pictureBox2.ImageLocation = "./EuropeFlags/Portugal.png";
                    break;
                case 7:
                    pictureBox2.ImageLocation = "./EuropeFlags/Russia.png";
                    break;
                default:
                    pictureBox2.ImageLocation = "./EuropeFlags/UnitedKingDom.png";
                    break;
            }
        }

        private void IDTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Just allow numbers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


    }
}
