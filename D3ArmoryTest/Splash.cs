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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();

            timeLifeController.Enabled = true;
            timeLifeController.Interval = 3500;
            this.pictureBox1.ImageLocation = "./CommonResources/splash.png";
        }

        private void timeLifeController_Tick(object sender, EventArgs e) //this event will be called at the first tick and then this form will die.
        {
            timeLifeController.Stop();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
