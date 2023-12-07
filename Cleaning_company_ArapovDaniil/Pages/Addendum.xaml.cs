using Cleaning_company_ArapovDaniil.FolderClasses;
using Cleaning_company_ArapovDaniil.ModelBD;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Addendum.xaml
    /// </summary>
    public partial class Addendum : Page
    {
        public Addendum()
        {
            InitializeComponent();

            ComboBox_TypePackage.SelectedValuePath = "ID";
            ComboBox_TypePackage.DisplayMemberPath = "Name";
            ComboBox_TypePackage.ItemsSource = ConnectionToBD.model.TypePackage.ToList();
        }
        private void ComboBox_TypePackage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Dobavit_Administrator_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string img = PicturePath.Text;
                Package package = new Package()
                {
                    Name = Name.Text,
                    Description = Description.Text,
                    TypePackage = ComboBox_TypePackage.SelectedItem as TypePackage,
                    isActual = Actual.Text,
                    ImageName = PicturePath.Text,
                    ImagePath = File.ReadAllBytes(img),
                };
                ConnectionToBD.model.Package.Add(package);
                ConnectionToBD.model.SaveChanges();
                MessageBox.Show("Товар добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                Navigation.Frame.Navigate(new Administrator());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Критическая ошибка");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Frame.Navigate(new Administrator());
        }
    }
}
