using Cleaning_company_ArapovDaniil.FolderClasses;
using Cleaning_company_ArapovDaniil.ModelBD;
using Cleaning_company_ArapovDaniil.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cleaning_company_ArapovDaniil
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ConnectionToBD.model = new EntitiesADV();
            Navigation.Frame = FrmMainWindow;
            FrmMainWindow.Navigate(new Manager());

            //List<Package> packages = model.Package.ToList();
            //foreach (Package package in packages)
            //{
            //    string str = package.ImageName;
            //    //str = str.Trim();
            //    if (str.Equals(""))
            //    {
            //        str = "00.jpg";
            //    }
            //    str = "C:\\Users\\User\\Desktop\\ArapovPractika\\Image_2\\" + str;
            //    byte[] bytes = File.ReadAllBytes(str);
            //    var obj = packages.Where(x => x.ID == package.ID).FirstOrDefault();
            //    obj.ImagePath = bytes;
            //    model.SaveChanges();
            //}
        }
    }
}
