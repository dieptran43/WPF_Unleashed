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

namespace WPF_Unleashed._3_Control_Elements._10_ManyChildElements
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ListBox window = new ListBox();
            window.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ListView window = new ListView();
            window.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            TabControl window = new TabControl();
            window.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            DataGrid window = new DataGrid();
            window.Show();
        }
    }
}
