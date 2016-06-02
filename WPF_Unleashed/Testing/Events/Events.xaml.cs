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

namespace WPF_Unleashed.Testing.Events
{
    /// <summary>
    /// Interaction logic for Events.xaml
    /// </summary>
    public partial class Events : Window
    {
        public Events()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AboutDialog window = new AboutDialog();
            window.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AttachedEvent window = new AttachedEvent();
            window.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Dragging window = new Dragging();
            window.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Commands window = new Commands();
            window.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            CommandControl window = new CommandControl();
            window.Show();
        }
    }
}
