using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D3ArmoryTest
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Splash sp = new Splash();
            if (sp.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new GameChooser());
            }
            
        }
    }
}
