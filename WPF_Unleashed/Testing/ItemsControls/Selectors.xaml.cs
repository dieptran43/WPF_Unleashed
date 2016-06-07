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

namespace WPF_Unleashed.Testing.ItemsControls
{
    /// <summary>
    /// Interaction logic for Selectors.xaml
    /// </summary>
    public partial class Selectors : Window
    {
        public Selectors()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBox window = new ComboBox();
            window.Show();
        }
    }
}
