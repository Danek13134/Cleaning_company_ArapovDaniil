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
    /// Логика взаимодействия для Input.xaml
    /// </summary>
    public partial class Input : Page
    {
        public Input()
        {
            InitializeComponent();
        }
        private void Vxod_Click(object sender, RoutedEventArgs e)
        {
            var userObj = ConnectionToBD.model.User.FirstOrDefault(x => x.Login == Login.Text && x.Password == Password.Password);
            switch (userObj.NameRole)
            {
                case 1:
                    MessageBox.Show("Вы вошли как Администратор!");
                    Navigation.Frame.Navigate(new Administrator());
                    break;
                case 2:
                    MessageBox.Show("Вы вошли как Менеджер!");
                    Navigation.Frame.Navigate(new Manager());
                    break;
            }
        }

        private void Vxod_Client_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы вошли как Клиент!");
            Navigation.Frame.Navigate(new PageClient());
        }
    }
}
