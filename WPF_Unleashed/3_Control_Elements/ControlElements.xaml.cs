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

namespace WPF_Unleashed._3_Control_Elements
{
    /// <summary>
    /// Interaction logic for ControlElements.xaml
    /// </summary>
    public partial class ControlElements : Window
    {
        public ControlElements()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _9_1ChildElements.OneChildElements window = new _9_1ChildElements.OneChildElements();
            window.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _10_ManyChildElements.ManyChildElements window = new _10_ManyChildElements.ManyChildElements();
            window.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _11_ImageTextOther.ImageTextOther window = new _11_ImageTextOther.ImageTextOther();
            window.Show();
        }
    }
}
