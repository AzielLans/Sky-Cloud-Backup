using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace Sky_Cloud_Backup
{
    public partial class About : MaterialForm
    {
        public About()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            versionlabel.Text = "Beta " + Assembly.GetExecutingAssembly().GetName().Version.Build.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Revision.ToString();
        }
        MaterialSkinManager ThemeManager = MaterialSkinManager.Instance;

        private void Github_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/Involts/Sky-Cloud-Backup");
            }
            catch (Exception ex)
            {
                Error_10(ex.Message);
            }
        }

        private void Error_10(string text)
        {
            MessageBox.Show(text, "Sky Cloud Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Bugs_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/Involts/Sky-Cloud-Backup/issues");
            }
            catch (Exception ex)
            {
                Error_10(ex.Message);
            }
        }

        private void License_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/Involts/Sky-Cloud-Backup/blob/master/LICENSE");
            }
            catch (Exception ex)
            {
                Error_10(ex.Message);
            }
        }
    }
}
