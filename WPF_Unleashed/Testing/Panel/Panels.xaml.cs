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

namespace WPF_Unleashed.Testing.Panel
{
    /// <summary>
    /// Interaction logic for Panels.xaml
    /// </summary>
    public partial class Panels : Window
    {
        public Panels()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Panel.StackPanel window = new Panel.StackPanel();
            window.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Panel.Grid window = new Panel.Grid();
            window.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Panel.GridSplitter window = new Panel.GridSplitter();
            window.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Panel.SharedGroupSize window = new Panel.SharedGroupSize();
            window.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Panel.WrapPanel window = new Panel.WrapPanel();
            window.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Panel.DockPanel window = new Panel.DockPanel();
            window.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MyDockPanel window = new MyDockPanel();
            window.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Panel.ScrollViewer window = new Panel.ScrollViewer();
            window.Show();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Panel.ViewBox window = new Panel.ViewBox();
            window.Show();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            CoolPanel window = new CoolPanel();
            window.Show();
        }
    }
}
