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
using System.Windows.Navigation;

namespace WPF_Unleashed.Testing.OneChildControls
{
    /// <summary>
    /// Interaction logic for OneChildControls.xaml
    /// </summary>
    public partial class OneChildControls : Window
    {
        public OneChildControls()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Buttons page = new Buttons();
            myFrame.NavigationService.Navigate(page);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SimpleContainers page = new SimpleContainers();
            myFrame.NavigationService.Navigate(page);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ContainersWithHeaders page = new ContainersWithHeaders();
            myFrame.NavigationService.Navigate(page);
        }
    }
}
