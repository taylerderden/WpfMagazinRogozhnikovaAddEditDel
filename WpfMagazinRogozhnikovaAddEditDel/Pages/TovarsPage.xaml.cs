using System;
using System.Collections.Generic;
using System.Drawing;
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
//using WpfMagazinRogozhnikovaAddEditDel.DbModels;

namespace WpfMagazinRogozhnikovaAddEditDel.Pages
{
    /// <summary>
    /// Логика взаимодействия для TovarsPage.xaml
    /// </summary>
    public partial class TovarsPage : Page
    {
        Tovar tovar;
        public TovarsPage()
        {
            InitializeComponent();
            lViewTovar.ItemsSource = CoreModel.init().Tovars.ToList();

            DataContext = tovar;
        }
        private void Update()
        {
            lViewTovar.ItemsSource = CoreModel.init().Tovars.ToList();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTovarPage(new Tovar()));
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (lViewTovar.SelectedItems.Count > 1)
            {
                return;
            }

            Tovar tovDel = lViewTovar.SelectedItem as Tovar;

            if (MessageBox.Show("Delete?", "Realy delete?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CoreModel.init().Tovars.Remove(tovDel);
                CoreModel.init().SaveChanges();
                Update();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Tovar tovEdit = lViewTovar.SelectedItem as Tovar;
            NavigationService.Navigate(new AddTovarPage(tovEdit));
        }

        private void AddServices_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Update();
        }
    }
}
