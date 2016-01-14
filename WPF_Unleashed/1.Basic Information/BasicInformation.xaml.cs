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
            WPF_Unleashed._1.Basic_Information._1.WPFandSilverlight.WPFandSilverlight MyWPFandSilverlight = new WPF_Unleashed._1.Basic_Information._1.WPFandSilverlight.WPFandSilverlight();
            MyWPFandSilverlight.Show();
        }
    }
}
