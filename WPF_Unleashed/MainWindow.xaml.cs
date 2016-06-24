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

namespace WPF_Unleashed
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Basic_Information.BasicInformation basicInformationWindow = new Basic_Information.BasicInformation();
            basicInformationWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _2_WPFApplication_Creation.WPFApplicationCreation window = new _2_WPFApplication_Creation.WPFApplicationCreation();
            window.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _3_Control_Elements.ControlElements window = new _3_Control_Elements.ControlElements();
            window.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Testing.Testing window = new Testing.Testing();
            window.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            _4_ProfessionalTools.ProfessionalTools window = new _4_ProfessionalTools.ProfessionalTools();
            window.Show();
        }
    }
}
