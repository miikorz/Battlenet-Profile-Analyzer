using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.IO.Compression;
using System.Globalization;
using System.Resources;

namespace D3ArmoryTest
{
    public partial class ProfileShower : Form
    {
        ProfileForm profileForm;
        String masterURL;
        WebClient client = new WebClient();
        String jsonString;
        XmlDocument doc = new XmlDocument();
        String sourceXML = @".\profile.xml";
        DataSet ds;
        private Image btnetBackground;
        public String selectedChardId;
        public String battletag;
        public String language;
        public Boolean profileFound;
        ResourceManager res_man;    // Declare Resource manager to access to specific cultureinfo
        CultureInfo cul;            // Declare culture info

        public ProfileShower(ProfileForm startForm)
        {
            InitializeComponent();
            btnetBackground = new Bitmap("./CommonResources/background4.png");
            this.BackgroundImage = btnetBackground;
            this.profileForm = startForm;
            this.battletag = profileForm.BattleTag;
            this.language = profileForm.Language;
            this.masterURL = "https://eu.api.battle.net/d3/profile/" + battletag + "/?locale=" + language + "&apikey=dzswy2ebvfzn3bm839vevuqhe6vhzcfn";
            jsonString = client.DownloadString(masterURL);
            doc = JsonConvert.DeserializeXmlNode(format_json(jsonString), "profile"); //MUST INDICATES THE NAME OF THE ROOT NODE, IN THIS CASE "PROFILE"
            doc.Save("./profile.xml");

            ds = new DataSet();
            ds.ReadXml(sourceXML);

            SNSeasonParagonLevel.BackColor = System.Drawing.Color.Transparent;
            SNSeasonParagonLevel.ForeColor = System.Drawing.Color.LightBlue;
            SSeasonParagonLevel.BackColor = System.Drawing.Color.Transparent;
            SSeasonParagonLevel.ForeColor = System.Drawing.Color.LightBlue;
            guild.BackColor = System.Drawing.Color.Transparent;
            guild.ForeColor = System.Drawing.Color.LightBlue;
            HNSeasonParagonLevel.BackColor = System.Drawing.Color.Transparent;
            HNSeasonParagonLevel.ForeColor = System.Drawing.Color.LightBlue;
            hardcore.BackColor = System.Drawing.Color.Transparent;
            softcore.BackColor = System.Drawing.Color.Transparent;
            HSeasonParagonLevel.BackColor = System.Drawing.Color.Transparent;
            HSeasonParagonLevel.ForeColor = System.Drawing.Color.LightBlue;
            characterlist.BackColor = System.Drawing.Color.Transparent;
            characterlist.ForeColor = System.Drawing.Color.LightBlue;
            battleTagLabel.BackColor = System.Drawing.Color.Transparent;
            battleTagLabel.ForeColor = System.Drawing.Color.LightBlue;
            guildLabel.BackColor = System.Drawing.Color.Transparent;
            guildLabel.ForeColor = System.Drawing.Color.LightBlue;

            this.backButton.ImageLocation = ("./CommonResources/backbutton.png");

            res_man = new ResourceManager("D3armoryTest.Language.Res", typeof(ProfileShower).Assembly);

            switch (language)
            {
                case "es_ES":
                    cul = CultureInfo.CreateSpecificCulture("es");
                    break;
                case "en_GB":
                    cul = CultureInfo.CreateSpecificCulture("en");
                    break;
                case "de_DE":
                    cul = CultureInfo.CreateSpecificCulture("de");
                    break;
                case "fr_FR":
                    cul = CultureInfo.CreateSpecificCulture("fr");
                    break;
            }

        }

        private static string format_json(string json) //This will allow to format a json string properly
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);
        }

        private void ProfileShower_Load(object sender, EventArgs e)
        {
            
            if (jsonString.Contains("NOTFOUND"))
            {
                profileFound = false;
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                profileFound = true;

                //Filling Character List
                listBox1.DataSource = ds.Tables["heroes"];
                listBox1.DisplayMember = "name";
                SNParagon.DataBindings.Add("Text", ds.Tables["profile"], "paragonLevel");
                SSParagon.DataBindings.Add("Text", ds.Tables["profile"], "paragonLevelSeason");
                HNParagon.DataBindings.Add("Text", ds.Tables["profile"], "paragonLevelHardcore");
                HSParagon.DataBindings.Add("Text", ds.Tables["profile"], "paragonLevelSeasonHardcore");
                battleTagLabel.DataBindings.Add("Text", ds.Tables["profile"], "battleTag");
                guildLabel.DataBindings.Add("Text", ds.Tables["profile"], "guildName");

                hideIdContainer.DataSource = ds.Tables["heroes"];
                hideIdContainer.DisplayMember = "id";

                //we ensure that selectedChardId gets a initial value
                selectedChardId = hideIdContainer.GetItemText(hideIdContainer.SelectedItem);

                this.softcore.Text = res_man.GetString("Softcore", cul);
                this.SNSeasonParagonLevel.Text = res_man.GetString("SNSeasonParagonLevel", cul);
                this.SSeasonParagonLevel.Text = res_man.GetString("SSeasonParagonLevel", cul);
                this.hardcore.Text = res_man.GetString("Hardcore", cul);
                this.HNSeasonParagonLevel.Text = res_man.GetString("HNSeasonParagonLevel", cul);
                this.HSeasonParagonLevel.Text = res_man.GetString("HSeasonParagonLevel", cul);
                this.characterlist.Text = res_man.GetString("CharacterList", cul);
                this.guild.Text = res_man.GetString("Guild", cul);
                this.characterdetails.Text = res_man.GetString("CharacterDetails", cul);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //we get the properly char id from getting the item's text from a hide listbox which is binded to the character list listbox (easy way)
            selectedChardId = hideIdContainer.GetItemText(hideIdContainer.SelectedItem);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DiabloCharForm dCForm = new DiabloCharForm(this);
            if (dCForm.ShowDialog() == DialogResult.Cancel)
            {
                this.Show();
            }
        }

        private void backButton_MouseHover(object sender, EventArgs e)
        {
            this.backButton.ImageLocation = ("./CommonResources/backbutton2.png");
        }

        private void backButton_MouseLeave(object sender, EventArgs e)
        {
            this.backButton.ImageLocation = ("./CommonResources/backbutton.png");
        }

        private void backButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        
        
        
        
    }
}
