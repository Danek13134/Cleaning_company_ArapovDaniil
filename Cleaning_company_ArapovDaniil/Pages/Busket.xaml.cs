using Cleaning_company_ArapovDaniil.FolderClasses;
using Cleaning_company_ArapovDaniil.ModelBD;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Cleaning_company_ArapovDaniil.Pages
{
    /// <summary>
    /// Логика взаимодействия для Busket.xaml
    /// </summary>
    public partial class Busket : Page
    {
        Class1 clas = new Class1();
        List<Package> package;
        public Busket(List<Package> packages)
        {
            InitializeComponent();

            package = packages;
            ListPackage.ItemsSource = package;

        }

        private void bOpenPrint_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            string str = "";
            for (int i = 0; i < 8; i++)
            {
                int buffer = random.Next(1, 9);
                str += buffer;
            }
            foreach (Package i in package)
            {
                Bucket bucket = new Bucket()
                {
                    PackageID = int.Parse("" + i.ID),
                    TakeID = int.Parse(str),
                };
                ConnectionToBD.model.Bucket.Add(bucket);
                ConnectionToBD.model.SaveChanges();
            }
            MessageBox.Show("Заказ размещен,\nКод для получения товара: " + str, "Оповещение",
            MessageBoxButton.OK, MessageBoxImage.Information);

            Navigation.Frame.Navigate(new Estimate(str));
        }
    }
}
