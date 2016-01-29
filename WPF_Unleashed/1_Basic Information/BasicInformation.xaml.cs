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

namespace WPF_Unleashed.Basic_Information
{
    /// <summary>
    /// Interaction logic for BasicInformation.xaml
    /// </summary>
    public partial class BasicInformation : Window
    {
        public BasicInformation()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _1.Basic_Information._1.WPFandSilverlight.WPFandSilverlight MyWPFandSilverlight = new _1.Basic_Information._1.WPFandSilverlight.WPFandSilverlight();
            MyWPFandSilverlight.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _1_Basic_Information._2_XAML.XAML myWindow = new _1_Basic_Information._2_XAML.XAML();
            myWindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _1_Basic_Information._3_WPFBasics.WPFBasics wpfBasics = new _1_Basic_Information._3_WPFBasics.WPFBasics();
            wpfBasics.Show();
        }
    }
}
