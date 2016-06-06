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
using System.Windows.Shapes;

namespace WPF_Unleashed.Testing.Deployment
{
    /// <summary>
    /// Interaction logic for Navigation.xaml
    /// </summary>
    public partial class Navigation : Window
    {
        public Navigation()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Перейти к экземпляру страницы
            MyProperties nextPage = new MyProperties();
            MyFrame.NavigationService.Navigate(nextPage);
            
            // Или перейти на страницу с заданным URI
            // this.NavigationService.Navigate(new Uri("PhotoPage.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TheirProperties nextPage = new TheirProperties();
            MyFrame.NavigationService.Navigate(nextPage);
        }
    }
}
