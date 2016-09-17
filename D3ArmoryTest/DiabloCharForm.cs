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
    public partial class DiabloCharForm : Form
    {
        ProfileShower _profileShower;
        private String masterURL;
        WebClient client = new WebClient();
        String jsonString;
        XmlDocument doc = new XmlDocument();
        DataSet ds;
        String sourceXML = @".\chardata.xml";
        ResourceManager res_man;    // Declare Resource manager to access to specific cultureinfo
        CultureInfo cul;            // Declare culture info

        public DiabloCharForm(ProfileShower profileShower)
        {
            InitializeComponent();
            this._profileShower = profileShower;
            this.masterURL = "https://eu.api.battle.net/d3/profile/" + _profileShower.battletag + "/hero/" + _profileShower.selectedChardId + "?locale=" + _profileShower.language + "&apikey=dzswy2ebvfzn3bm839vevuqhe6vhzcfn";
            jsonString = client.DownloadString(masterURL);
            doc = JsonConvert.DeserializeXmlNode(formatJson(jsonString), "profile"); //MUST INDICATES THE NAME OF THE ROOT NODE, IN THIS CASE "PROFILE"
            doc.Save(sourceXML);

            ds = new DataSet();
            ds.ReadXml(sourceXML);

            try
            {
                res_man = new ResourceManager("D3armoryTest.Language.Res", typeof(DiabloCharForm).Assembly);

                switch (_profileShower.language)
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

                charName.DataBindings.Add("Text", ds.Tables["profile"], "name");
                charLevel.DataBindings.Add("Text", ds.Tables["profile"], "level");
                eliteKills.DataBindings.Add("Text", ds.Tables["kills"], "elites");
                charParagonLvl.DataBindings.Add("Text", ds.Tables["profile"], "paragonLevel");
                seasonCreated.DataBindings.Add("Text", ds.Tables["profile"], "seasonCreated");
                charClass.DataBindings.Add("Text", ds.Tables["profile"], "class");

                //Since stats node is duplicated we'll collect the data we need with this way
                XmlNodeList allstats = doc.SelectNodes("//stats");
                //The last <stats> node will contains all the stats we need so to get the last one properly 
                //we'll use allstats[allstats.Count-1] (since there could be different numbers of <stats> nodes)
                String allStatsToString = allstats[allstats.Count-1].InnerXml;
                charLife.Text = allStatsToString.Split('>','<')[2];
                charDamage.Text = allStatsToString.Split('>', '<')[6];
                charToughness.Text = allStatsToString.Split('>', '<')[10];
                charStrenght.Text = allStatsToString.Split('>', '<')[26];
                charDexterity.Text = allStatsToString.Split('>', '<')[30];
                charVitality.Text = allStatsToString.Split('>', '<')[34];
                charIntelligence.Text = allStatsToString.Split('>', '<')[38];
             
            }
            catch{;}

            this.BackgroundImage = new Bitmap("./DiabloImages/charbackground.jpg");
            this.backButton.ImageLocation = ("./CommonResources/backbutton.png");

        }

        private static string formatJson(string json) //This will allow to format a json string properly
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);
        }

        private void DiabloCharForm_Load(object sender, EventArgs e)
        {
            Binding gender = new Binding("Text", ds.Tables["profile"], "gender");
            gender.Format += new ConvertEventHandler(FormatGender);
            charGender.DataBindings.Add(gender);

            Binding hc = new Binding("Text", ds.Tables["profile"], "hardcore");
            hc.Format += new ConvertEventHandler(FormatHc);
            isCharHc.DataBindings.Add(hc);

            Binding season = new Binding("Text", ds.Tables["profile"], "seasonal");
            season.Format += new ConvertEventHandler(FormatSeason);
            isCharSeason.DataBindings.Add(season);

            switch (charClass.Text)
            {
                case "crusader":
                    if (charGender.Text.Equals("Male"))
                    {
                       charPicture.ImageLocation = ("./DiabloImages/crusader.jpg");
                    }
                    else
                    {
                       charPicture.ImageLocation = ("./DiabloImages/crusaderfemale.jpg");
                    }
                    break;

                case "witch-doctor":
                    if (charGender.Text.Equals("Male"))
                    {
                        charPicture.ImageLocation = ("./DiabloImages/witchdoctor.jpg");
                    }
                    else
                    {
                        charPicture.ImageLocation = ("./DiabloImages/witchdoctorfemale.jpg");
                    }
                    break;

                case "demon-hunter":
                    if (charGender.Text.Equals("Male"))
                    {
                        charPicture.ImageLocation = ("./DiabloImages/demonhunter.jpg");
                    }
                    else
                    {
                        charPicture.ImageLocation = ("./DiabloImages/demonhunterfemale.jpg");
                    }
                    break;

                case "monk":
                    if (charGender.Text.Equals("Male"))
                    {
                        charPicture.ImageLocation = ("./DiabloImages/monk.jpg");
                    }
                    else
                    {
                        charPicture.ImageLocation = ("./DiabloImages/monkfemale.jpg");
                    }
                    break;

                case "wizard":
                    if (charGender.Text.Equals("Male"))
                    {
                        charPicture.ImageLocation = ("./DiabloImages/mage.jpg");
                    }
                    else
                    {
                        charPicture.ImageLocation = ("./DiabloImages/magefemale.jpg");
                    }
                    break;

                case "barbarian":
                    if (charGender.Text.Equals("Male"))
                    {
                        charPicture.ImageLocation = ("./DiabloImages/barbarian.jpg");
                    }
                    else
                    {
                        charPicture.ImageLocation = ("./DiabloImages/barbarianfemale.jpg");
                    }
                    break;
            }

            if (isCharHc.Text.Equals("Yes"))
            {
                hcPicture.ImageLocation = ("./DiabloImages/hc.png");
            }

            if (isCharSeason.Text.Equals("Yes"))
            {
                seasonPicture.ImageLocation = ("./DiabloImages/seasonleaf.png");
            }

            this.MainStats.Text = res_man.GetString("MainStats", cul);
            this.Life.Text = res_man.GetString("Life", cul);
            this.Damage.Text = res_man.GetString("Damage", cul);
            this.Toughness.Text = res_man.GetString("Toughness", cul);
            this.Strenght.Text = res_man.GetString("Strenght", cul);
            this.Dexterity.Text = res_man.GetString("Dexterity", cul);
            this.Vitality.Text = res_man.GetString("Vitality", cul);
            this.Intelligence.Text = res_man.GetString("Intelligence", cul);
            this.CharacterInfo.Text = res_man.GetString("CharacterInfo", cul);
            this.NameL.Text = res_man.GetString("Name", cul);
            this.ClassL.Text = res_man.GetString("Class", cul);
            this.Gender.Text = res_man.GetString("Gender", cul);
            this.ParagonLevel.Text = res_man.GetString("ParagonLevel", cul);
            this.Season.Text = res_man.GetString("Season", cul);
            this.SeasonNumber.Text = res_man.GetString("SeasonNumber", cul);
            this.EliteKillsL.Text = res_man.GetString("EliteKills", cul);
            this.Hardcore.Text = res_man.GetString("HardCore2", cul);

        }

        private void FormatSeason(object sender, ConvertEventArgs e)
        {
            if (e.Value.ToString().Equals("true"))
            {
                e.Value = "Yes";
            }
            else
            {
                e.Value = "No";
            } 
        }

        private void FormatHc(object sender, ConvertEventArgs e)
        {
            if (e.Value.ToString().Equals("true"))
            {
                e.Value = "Yes";
            }
            else
            {
                e.Value = "No";
            } 
        }

        private void FormatGender(object sender, ConvertEventArgs e)
        {
                if (e.Value.ToString().Equals("0"))
                {
                    e.Value = "Male";
                }
                else
                {
                    e.Value = "Female";
                }           
        }

        private void backButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void backButton_MouseHover(object sender, EventArgs e)
        {
            backButton.ImageLocation = ("./CommonResources/backbutton2.png");
        }

        private void backButton_MouseLeave(object sender, EventArgs e)
        {
            backButton.ImageLocation = ("./CommonResources/backbutton.png");
        }


    }
}
