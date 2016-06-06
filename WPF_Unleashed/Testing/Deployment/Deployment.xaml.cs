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
    /// Interaction logic for Deployment.xaml
    /// </summary>
    public partial class Deployment : Window
    {
        public Deployment()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navigation window = new Navigation();
            window.Show();
        }
    }
}
