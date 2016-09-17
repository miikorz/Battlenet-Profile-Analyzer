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
    public partial class WowProfileShower : Form
    {
        WowProfileForm _wPForm;
        String masterURL;
        String masterURL2;
        WebClient client = new WebClient();
        WebClient client2 = new WebClient();
        XmlDocument doc = new XmlDocument();
        XmlDocument doc2 = new XmlDocument();
        String jsonString;
        String jsonString2;
        String sourceXML = @".\profile.xml";
        String sourceXML2 = @".\chardata.xml";
        DataSet ds;
        DataSet ds2;
        public Boolean charFound;
        String spec;
        ResourceManager res_man;    // Declare Resource manager to access to specific cultureinfo
        CultureInfo cul;            // Declare culture info

        public WowProfileShower(WowProfileForm wPForm)
        {
            InitializeComponent();

            this._wPForm = wPForm;
            this.BackgroundImage = new Bitmap("./WowImages/charbackground.jpg");
            this.backButton.ImageLocation = ("./CommonResources/backbutton.png");
            this.achievementPicture.ImageLocation = ("./WowImages/achievementlogo.png");
            this.masterURL = "https://eu.api.battle.net/wow/character/"+_wPForm.Server+"/"+_wPForm.CharName+"?fields=guild&locale="+_wPForm.Language+"&apikey=dzswy2ebvfzn3bm839vevuqhe6vhzcfn";
            this.masterURL2 = "https://eu.api.battle.net/wow/character/" + _wPForm.Server + "/" + _wPForm.CharName + "?fields=talents&locale=" + _wPForm.Language + "&apikey=dzswy2ebvfzn3bm839vevuqhe6vhzcfn";
            try
            {
                res_man = new ResourceManager("D3armoryTest.Language.Res", typeof(WowProfileShower).Assembly);

                jsonString = client.DownloadString(masterURL);
                jsonString2 = client.DownloadString(masterURL2);
                charFound = true;

                doc = JsonConvert.DeserializeXmlNode(format_json(jsonString), "profile"); //MUST INDICATES THE NAME OF THE ROOT NODE, IN THIS CASE "PROFILE"
                doc.Save("./profile.xml");

                doc = JsonConvert.DeserializeXmlNode(format_json(jsonString2), "profile"); //MUST INDICATES THE NAME OF THE ROOT NODE, IN THIS CASE "PROFILE"
                doc.Save("./chardata.xml");
                
                ds = new DataSet();
                ds.ReadXml(sourceXML);

                ds2 = new DataSet();
                ds2.ReadXml(sourceXML2);
            }
            catch (Exception)
            {    
                charFound = false;
                this.DialogResult = DialogResult.Cancel;
            }

            switch (_wPForm.Language)
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

        private string format_json(string json) //This will allow to format a json string properly
        {
            try
            {
                dynamic parsedJson = JsonConvert.DeserializeObject(json);
                return JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);
            }
            catch (Exception)
            {
                charFound = false;
                this.DialogResult = DialogResult.Cancel;
                return "not found";
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

        private void WowProfileShower_Load(object sender, EventArgs e)
        {
            if (charFound == false)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                charFound = true;

                nameLabel.DataBindings.Add("Text", ds.Tables["profile"], "name");
                serverLabel.DataBindings.Add("Text", ds.Tables["profile"], "realm");
                battlegroupLabel.DataBindings.Add("Text", ds.Tables["profile"], "battlegroup");
                levelLabel.DataBindings.Add("Text", ds.Tables["profile"], "level");
                achievementLabel.DataBindings.Add("Text", ds.Tables["profile"], "achievementPoints");
                hKillsLabel.DataBindings.Add("Text", ds.Tables["profile"], "totalHonorableKills");               

                try
                {
                    this.name.Text = res_man.GetString("Name", cul);
                    this.server.Text = res_man.GetString("Server", cul);
                    this.guild.Text = res_man.GetString("Guild", cul);
                    this.classL.Text = res_man.GetString("Class", cul);
                    this.race.Text = res_man.GetString("Race", cul);
                    this.faction.Text = res_man.GetString("Faction", cul);
                    this.level.Text = res_man.GetString("Level", cul);
                    this.role.Text = res_man.GetString("Role", cul);
                    this.honorkills.Text = res_man.GetString("HonorKills", cul);
                    this.gender.Text = res_man.GetString("Gender", cul);
                    this.battlegroup.Text = res_man.GetString("Battlegroup", cul);
                    this.characterinfo.Text = res_man.GetString("CharacterInfo", cul);
                    

                    hideClassNumber.DataBindings.Add("Text", ds.Tables["profile"], "class");
                    this.hideClassNumber.Visible = false;

                    raceLabel.DataBindings.Clear();
                    Binding race = new Binding("Text", ds.Tables["profile"], "race");
                    race.Format += new ConvertEventHandler(FormatRace);
                    raceLabel.DataBindings.Add(race);

                    genderLabel.DataBindings.Clear();
                    Binding gender = new Binding("Text", ds.Tables["profile"], "gender");
                    gender.Format += new ConvertEventHandler(FormatGender);
                    genderLabel.DataBindings.Add(gender);

                    factionLabel.DataBindings.Clear();
                    Binding faction = new Binding("Text", ds.Tables["profile"], "faction");
                    faction.Format += new ConvertEventHandler(FormatFaction);
                    factionLabel.DataBindings.Add(faction);

                    classLabel.DataBindings.Clear();
                    Binding charClass = new Binding("Text", ds.Tables["profile"], "class");
                    charClass.Format += new ConvertEventHandler(FormatcharClass);
                    classLabel.DataBindings.Add(charClass);

                    XmlNodeList allSpecs = doc.SelectNodes("//spec");
                    String allSpecsToString = allSpecs[0].InnerXml;
                    roleLabel.Text = allSpecsToString.Split('>', '<')[6];
                    spec = allSpecsToString.Split('>', '<')[2];
                    classLabel.Text += " " + spec;
                }
                catch {;}

                try
                {
                    guildLabel.DataBindings.Add("Text", ds.Tables["guild"], "name");
                }
                catch (Exception)
                {
                    guildLabel.Text = "No guild";
                }

                switch (hideClassNumber.Text)
                {
                    case "1":
                        classPicture.ImageLocation = ("./WowImages/warriorlogo.png");
                        break;
                    case "2":
                        classPicture.ImageLocation = ("./WowImages/paladinlogo.png");
                        break;
                    case "3":
                        classPicture.ImageLocation = ("./WowImages/hunterlogo.png");
                        break;
                    case "4":
                        classPicture.ImageLocation = ("./WowImages/roguelogo.png");
                        break;
                    case "5":
                        classPicture.ImageLocation = ("./WowImages/priestlogo.png");
                        break;
                    case "6":
                        classPicture.ImageLocation = ("./WowImages/dklogo.png");
                        break;
                    case "7":
                        classPicture.ImageLocation = ("./WowImages/shamanlogo.png");
                        break;
                    case "8":
                        classPicture.ImageLocation = ("./WowImages/magelogo.png");
                        break;
                    case "9":
                        classPicture.ImageLocation = ("./WowImages/warlocklogo.png");
                        break;
                    case "10":
                        classPicture.ImageLocation = ("./WowImages/monklogo.png");
                        break;
                    case "11":
                        classPicture.ImageLocation = ("./WowImages/druidlogo.png");
                        break;
                }

                if (factionLabel.Text == "Horde")
                {
                    factionPicture.ImageLocation = ("./WowImages/hordelogo.png");
                }
                else
                {
                    factionPicture.ImageLocation = ("./WowImages/alliancelogo.png");
                }
            }
  
        }

        private void FormatcharClass(object sender, ConvertEventArgs e)
        {
            switch (e.Value.ToString())
            {
                case "1":
                    e.Value = "Warrior";
                    break;
                case "2":
                    e.Value = "Paladin";
                    break;
                case "3":
                    e.Value = "Hunter";
                    break;
                case "4":
                    e.Value = "Rogue";
                    break;
                case "5":
                    e.Value = "Priest";
                    break;
                case "6":
                    e.Value = "Death Knight";
                    break;
                case "7":
                    e.Value = "Shaman";
                    break;
                case "8":
                    e.Value = "Mage";
                    break;
                case "9":
                    e.Value = "Warlock";
                    break;
                case "10":
                    e.Value = "Monk";
                    break;
                case "11":
                    e.Value = "Druid";
                    break;
            }
        }

        private void FormatRace(object sender, ConvertEventArgs e)
        {
            switch (e.Value.ToString())
            {
                case "1":
                    e.Value = "Human";
                    break;
                case "2":
                    e.Value = "Orc";
                    break;
                case "3":
                    e.Value = "Dwarf";
                    break;
                case "4":
                    e.Value = "Night Elf";
                    break;
                case "5":
                    e.Value = "Undead";
                    break;
                case "6":
                    e.Value = "Tauren";
                    break;
                case "7":
                    e.Value = "Gnome";
                    break;
                case "8":
                    e.Value = "Troll";
                    break;
                case "9":
                    e.Value = "Goblin";
                    break;
                case "10":
                    e.Value = "Blood Elf";
                    break;
                case "11":
                    e.Value = "Draenei";
                    break;
                case "22":
                    e.Value = "Worgen";
                    break;
                case "24":
                    e.Value = "Pandaren";
                    break;
                case "25":
                    e.Value = "Pandaren";
                    break;
                case "26":
                    e.Value = "Pandaren";
                    break;
            }
        }

        private void FormatFaction(object sender, ConvertEventArgs e)
        {
            if (e.Value.ToString().Equals("0"))
            {
                e.Value = "Alliance";
            }
            else
            {
                e.Value = "Horde";
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
    }
}
