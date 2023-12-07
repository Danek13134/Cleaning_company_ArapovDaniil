using Cleaning_company_ArapovDaniil.FolderClasses;
using Cleaning_company_ArapovDaniil.ModelBD;
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
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Page
    {
        public AddClient()
        {
            InitializeComponent();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Frame.Navigate(new Client());
        }

        private void Register_Client_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client_C client_с = new Client_C()
                {
                    FIO = FIO.Text,
                    Phone = Phone.Text,
                };
                ConnectionToBD.model.Client_C.Add(client_с);
                ConnectionToBD.model.SaveChanges();
                MessageBox.Show("Клиент зарегистрирован", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                Navigation.Frame.Navigate(new Client());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Критическая ошибка");
            }
        }
    }
}
