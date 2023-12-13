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

namespace WpfMagazinRogozhnikovaAddEditDel.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddTovarPage.xaml
    /// </summary>
    public partial class AddTovarPage : Page
    {
        Tovar tovar;
        public AddTovarPage(Tovar tov)
        {
            this.tovar = tov;
            DataContext = tovar;
            InitializeComponent();
        }

        private void Button_SaveClick(object sender, RoutedEventArgs e)
        {
            if (tovar.Idtovars == 0)
            {
                CoreModel.init().Tovars.Add(tovar);
            }
            CoreModel.init().SaveChanges();
            NavigationService.GoBack();
        }

        private void AddServices_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (tovar.Idtovars != 0)
            {
                CoreModel.init().Entry(tovar).Reload();
            }
        }
    }
}
