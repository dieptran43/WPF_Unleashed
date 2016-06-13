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

namespace WPF_Unleashed.Testing.ImageTextOther
{
    /// <summary>
    /// Interaction logic for ImageTextOther.xaml
    /// </summary>
    public partial class ImageTextOther : Window
    {
        public ImageTextOther()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyImage window = new MyImage();
            window.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextInk window = new TextInk();
            window.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MyDocuments window = new MyDocuments();
            window.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Other window = new Other();
            window.Show();
        }
    }
}
