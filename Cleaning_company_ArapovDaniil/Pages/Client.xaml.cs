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
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Page
    {
        public Client()
        {
            InitializeComponent();

            ListClient.ItemsSource = ConnectionToBD.model.Client_C.ToList();
        }
        private void Cmb_Client_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectIndex = Cmb_Client.SelectedIndex;
            try
            {
                switch (SelectIndex)
                {
                    case 0:
                        {
                            ListClient.ItemsSource = ConnectionToBD.model.Client_C.ToList();
                        }
                        break;

                    case 1:
                        {
                            ListClient.ItemsSource = ConnectionToBD.model.Client_C.OrderByDescending(x => x.FIO).ToList();
                        }
                        break;

                    case 2:
                        {
                            ListClient.ItemsSource = ConnectionToBD.model.Client_C.OrderBy(x => x.FIO).ToList();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private void PoiskClient_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListClient.ItemsSource = ConnectionToBD.model.Client_C.Where(x => x.FIO.Contains(PoiskClient.Text) || x.Phone.Contains(PoiskClient.Text)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private void BackClient_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Frame.Navigate(new Manager());
        }

        private void Add_Client_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Frame.Navigate(new AddClient());
        }

        private void Delet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ListClient.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < ListClient.SelectedItems.Count; i++)
                    {
                        Client_C client = ListClient.SelectedItems[i] as Client_C;
                        ConnectionToBD.model.Client_C.Remove(client);
                    }
                    ConnectionToBD.model.SaveChanges();
                    MessageBox.Show("Клиент удален");
                    ListClient.ItemsSource = ConnectionToBD.model.Client_C;
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
            Navigation.Frame.Navigate(new Client());
        }

        private void ListClient_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
