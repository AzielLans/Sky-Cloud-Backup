using MaterialSkin;
using MaterialSkin.Controls;

namespace Sky_Cloud_Backup
{
    public partial class Help : MaterialForm
    {
        public Help()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
        }
        MaterialSkinManager ThemeManager = MaterialSkinManager.Instance;
    }
}
