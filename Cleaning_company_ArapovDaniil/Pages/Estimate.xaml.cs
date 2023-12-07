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
    /// Логика взаимодействия для Estimate.xaml
    /// </summary>
    public partial class Estimate : Page
    {
        DateTime dateTime = DateTime.Now;
        EntitiesADV model = new EntitiesADV();
        public Estimate(String str)
        {
            string nameManager = "Сидоренко К. А.";
            string contractor = "\"Дом ремонта\" г. Ростов-на-Дону, ул. Пушкина, д. 2, тел: +7(000)000-00-00";
            decimal sumCost = 0;
            List<Bucket> buckets = model.Bucket.ToList();
            foreach (Bucket i in buckets)
            {
                if (i.TakeID == int.Parse(str))
                {
                    Package package = model.Package.FirstOrDefault(x => x.ID == i.ID);
                    sumCost = package.Cost;
                }
            }

            InitializeComponent();

            List<Package> mat = new List<Package>();

            foreach (Bucket i in buckets)
            {
                if (i.TakeID == int.Parse(str))
                {
                    Package package = model.Package.FirstOrDefault(x => x.ID == i.ID);
                    mat.Add(package);
                }
            }

            dgMaterial.ItemsSource = mat;

            tbToken.Text = str;
            tbTime.Text = "" + dateTime;
            tbManager.Text = nameManager;
            tbContractor.Text = contractor;
            tbCost.Text = sumCost + "";
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog print = new PrintDialog();
            print.PrintVisual(ActWrap, "Печать сметы");
        }
    }
}
