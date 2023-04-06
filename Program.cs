using System;
using System.IO;
using System.Windows.Forms;

namespace Sky_Cloud_Backup
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
            string chk_cnl = "Cancel";
            if (File.Exists(chk_cnl))
            {
                File.Delete(chk_cnl);
                Application.Run(new Main_Screen());
            }
            else
            {
                Application.Run(new loading_screen());
            }

        }
    }
}
