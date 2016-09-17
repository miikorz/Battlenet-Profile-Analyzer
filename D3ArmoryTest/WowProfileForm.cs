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
    public partial class WowProfileForm : Form
    {
        Bitmap btnetBackground;
        public String CharName { get; set; }
        public String Server { get; set; }
        public String Language { get; set; }
        private Boolean charFound;

        public WowProfileForm()
        {
            InitializeComponent();
            LanguageCombo.SelectedIndex = 0;
            btnetBackground = new Bitmap("./CommonResources/background2.png");
            this.BackgroundImage = btnetBackground;
            characterPicture.ImageLocation = "./WowImages/wowicon.png";
            flagPicture.ImageLocation = "./EuropeFlags/UnitedKingDom.png";
            serverPicture.ImageLocation = "./CommonResources/battlenet.png";
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.ForeColor = System.Drawing.Color.LightBlue;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.ForeColor = System.Drawing.Color.LightBlue;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.ForeColor = System.Drawing.Color.LightBlue;
        }

        private void LanguageCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (LanguageCombo.SelectedIndex)
            {
                case 1:
                    flagPicture.ImageLocation = "./EuropeFlags/Germany.png";
                    break;
                case 2:
                    flagPicture.ImageLocation = "./EuropeFlags/Spain.png";
                    break;
                case 3:
                    flagPicture.ImageLocation = "./EuropeFlags/France.png";
                    break;
                case 4:
                    flagPicture.ImageLocation = "./EuropeFlags/Italy.png";
                    break;
                case 5:
                    flagPicture.ImageLocation = "./EuropeFlags/Poland.png";
                    break;
                case 6:
                    flagPicture.ImageLocation = "./EuropeFlags/Portugal.png";
                    break;
                case 7:
                    flagPicture.ImageLocation = "./EuropeFlags/Russia.png";
                    break;
                default:
                    flagPicture.ImageLocation = "./EuropeFlags/UnitedKingDom.png";
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CharName = NameTextBox.Text;
            Server = serverTextBox.Text;
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
            WowProfileShower wPS = new WowProfileShower(this);
            if (wPS.ShowDialog() == DialogResult.Cancel)
            {
                charFound = wPS.charFound;
                this.Show();

                if (!charFound)
                {
                    MessageBox.Show("Character or realm doesn't exist", "Not Found", MessageBoxButtons.OK);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NameTextBox.Text = "";
            serverTextBox.Text = "";
        }
    }
}
