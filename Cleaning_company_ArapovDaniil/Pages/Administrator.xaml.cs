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
using Cleaning_company_ArapovDaniil.ModelBD;

namespace Cleaning_company_ArapovDaniil.Pages
{
    /// <summary>
    /// Логика взаимодействия для Administrator.xaml
    /// </summary>
    public partial class Administrator : Page
    {
        public Administrator()
        {
            InitializeComponent();

            Cmb2_Admin.SelectedValuePath = "ID";
            Cmb2_Admin.DisplayMemberPath = "Name";
            Cmb2_Admin.ItemsSource = ConnectionToBD.model.TypePackage.ToList();

            ListPackage.ItemsSource = ConnectionToBD.model.Package.ToList();
        }
        private void Cmb_Admin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectIndex = Cmb_Admin.SelectedIndex;
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

        private void Cmb2_Admin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectGroup = Convert.ToInt32(Cmb2_Admin.SelectedValue);

            ListPackage.ItemsSource = ConnectionToBD.model.Package.Where(x => x.TypePackageID == SelectGroup).ToList();
            ListPackage.SelectedIndex = 0;
        }

        private void PoiskAdmin_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListPackage.ItemsSource = ConnectionToBD.model.Package.Where(x => x.Name.Contains(PoiskAdmin.Text) || x.Description.Contains(PoiskAdmin.Text)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private void BackAdmin_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Frame.Navigate(new Input());
        }

        private void DeleteAdmin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ListPackage.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < ListPackage.SelectedItems.Count; i++)
                    {
                        Package product = ListPackage.SelectedItems[i] as Package;
                        ConnectionToBD.model.Package.Remove(product);
                    }
                    ConnectionToBD.model.SaveChanges();
                    MessageBox.Show("Запись удалена");
                    ListPackage.ItemsSource = ConnectionToBD.model.Package;
                }
                else
                {
                    MessageBox.Show("В таблице нет данных");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка работы приложения" + ex.Message.ToString());
            }
            Navigation.Frame.Navigate(new Administrator());
        }

        private void ListPackage_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Add_Package_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Frame.Navigate(new Addendum());
        }

        private void Redaction_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Frame.Navigate(new Redact((sender as Button).DataContext as Package));
        }
    }
}
