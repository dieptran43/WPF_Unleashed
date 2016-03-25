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

namespace WPF_Unleashed._2_WPFApplication_Creation._7_ApplicationDeployment
{
    /// <summary>
    /// Interaction logic for GadgetWindow.xaml
    /// </summary>
    public partial class GadgetWindow : Window
    {
        public GadgetWindow()
        {
            InitializeComponent();
        }

        void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
