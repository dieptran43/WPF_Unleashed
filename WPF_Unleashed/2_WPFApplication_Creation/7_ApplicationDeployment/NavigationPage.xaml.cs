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

namespace WPF_Unleashed._2_WPFApplication_Creation._7_ApplicationDeployment
{
    /// <summary>
    /// Interaction logic for NavigationPage.xaml
    /// </summary>
    public partial class NavigationPage : Page
    {
        public NavigationPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String message = MessageTextBox.Text;
            PhotoPage nextPage = new PhotoPage(this);
            this.NavigationService.Navigate(nextPage, message);

            // this.NavigationService.Navigate(new Uri("PhotoPage.xaml", UriKind.Relative));
        }
    }
}
