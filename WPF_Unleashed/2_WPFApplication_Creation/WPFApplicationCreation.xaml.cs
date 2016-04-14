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

namespace WPF_Unleashed._2_WPFApplication_Creation
{
    /// <summary>
    /// Interaction logic for WPFApplicationCreation.xaml
    /// </summary>
    public partial class WPFApplicationCreation : Window
    {
        public WPFApplicationCreation()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _4_Element_size_position_transformation.ElementSizePositionTransformation window = new _4_Element_size_position_transformation.ElementSizePositionTransformation();
            window.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _5_LayoutPanels.LayoutPanels window = new _5_LayoutPanels.LayoutPanels();
            window.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _6_InputEvents.InputEvents window = new _6_InputEvents.InputEvents();
            window.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            _7_ApplicationDeployment.ApplicationDeployment window = new _7_ApplicationDeployment.ApplicationDeployment();
            window.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            _8_Windows7Features.Windows7Features window = new _8_Windows7Features.Windows7Features();
            window.Show();
        }
    }
}
