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
using System.IO;

namespace Cleaning_company_ArapovDaniil.Pages
{
    /// <summary>
    /// Логика взаимодействия для Redact.xaml
    /// </summary>
    public partial class Redact : Page
    {
        public Redact(Package package)
        {
            InitializeComponent();

            try
            {
                Name.Text = package.Name;
                ComboBox_TypePackage.SelectedValuePath = "ID";
                ComboBox_TypePackage.DisplayMemberPath = "Name";
                ComboBox_TypePackage.ItemsSource = ConnectionToBD.model.TypePackage.ToList();
                Description.Text = package.Description;
                Actual.Text = package.isActual;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            } 
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Frame.Navigate(new Administrator());
        }

        private void Save_Administrator_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //string img = PicturePath.Text;
                Package product = new Package()
                {
                    Name = Name.Text,
                    Description = Description.Text,
                    TypePackage = ComboBox_TypePackage.SelectedItem as TypePackage,
                    isActual = Actual.Text,
                    //ImageName = PicturePath.Text,
                    //ImagePath = File.ReadAllBytes(img),
                };
                ConnectionToBD.model.Package.Add(product);
                ConnectionToBD.model.SaveChanges();
                MessageBox.Show("Изменения сохранены"); Navigation.Frame.Navigate(new Administrator());
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void ComboBox_TypePackage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
