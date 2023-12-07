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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cleaning_company_ArapovDaniil.Pages
{
    /// <summary>
    /// Логика взаимодействия для Manager.xaml
    /// </summary>
    public partial class Manager : Page
    {
        Class1 clas = new Class1();
        public Manager()
        {
            InitializeComponent();

            Cmb2_Manager.SelectedValuePath = "ID";
            Cmb2_Manager.DisplayMemberPath = "Name";
            Cmb2_Manager.ItemsSource = ConnectionToBD.model.TypePackage.ToList();

            ListPackage.ItemsSource = ConnectionToBD.model.Package.ToList();
        }
        private void PoiskManager_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListPackage.ItemsSource = ConnectionToBD.model.Package.Where(x => x.Name.Contains(PoiskManager.Text) || x.Description.Contains(PoiskManager.Text)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private void Cmb_Manager_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectIndex = Cmb_Manager.SelectedIndex;
            try
            {
                switch (SelectIndex)
                {
                    case 0:
                        {
                            ListPackage.ItemsSource = ConnectionToBD.model.Package.ToList();
                        }
                        break;

                    case 1:
                        {
                            ListPackage.ItemsSource = ConnectionToBD.model.Package.OrderByDescending(x => x.Name).ToList();
                        }
                        break;

                    case 2:
                        {
                            ListPackage.ItemsSource = ConnectionToBD.model.Package.OrderBy(x => x.Name).ToList();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private void Cmb2_Manager_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectGroup = Convert.ToInt32(Cmb2_Manager.SelectedValue);

            ListPackage.ItemsSource = ConnectionToBD.model.Package.Where(x => x.TypePackageID == SelectGroup).ToList();
            ListPackage.SelectedIndex = 0;
        }

        private void See_Client_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Frame.Navigate(new Client());
        }

        private void BackManager_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Frame.Navigate(new Input());
        }

        private void ListPackage_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Package material = ListPackage.SelectedItem as Package;
            clas.package.Add(material);
        }

        private void OpenClas_Click(object sender, RoutedEventArgs e)
        {
            List<Package> package = clas.package;
            NavigationService.Navigate(new Busket(package));
        }
    }
}
