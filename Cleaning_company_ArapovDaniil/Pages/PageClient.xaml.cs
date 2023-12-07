using Cleaning_company_ArapovDaniil.FolderClasses;
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

namespace Cleaning_company_ArapovDaniil.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageClient.xaml
    /// </summary>
    public partial class PageClient : Page
    {
        public PageClient()
        {
            InitializeComponent();

            Cmb2_PageClient.SelectedValuePath = "ID";
            Cmb2_PageClient.DisplayMemberPath = "Name";
            Cmb2_PageClient.ItemsSource = ConnectionToBD.model.TypePackage.ToList();

            ListPackage.ItemsSource = ConnectionToBD.model.Package.ToList();
        }

        private void PoiskPageClient_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListPackage.ItemsSource = ConnectionToBD.model.Package.Where(x => x.Name.Contains(PoiskPageClient.Text) || x.Description.Contains(PoiskPageClient.Text)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private void Cmb_PageClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectIndex = Cmb_PageClient.SelectedIndex;
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

        private void Cmb2_PageClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectGroup = Convert.ToInt32(Cmb2_PageClient.SelectedValue);

            ListPackage.ItemsSource = ConnectionToBD.model.Package.Where(x => x.TypePackageID == SelectGroup).ToList();
            ListPackage.SelectedIndex = 0;
        }

        private void BackPageClient_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Frame.Navigate(new Input());
        }
    }
}
