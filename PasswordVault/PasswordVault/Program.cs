using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataJuggler.Tutorials.PasswordVault.Forms;

namespace PasswordVault
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {  
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // create a new MainForm           
            MainForm form = new MainForm();

            // set the context
            ApplicationContext context = new ApplicationContext(form);
                
            // run the app
            Application.Run(context);
        }
    }
}
