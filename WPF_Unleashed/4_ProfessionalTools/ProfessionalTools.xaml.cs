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

namespace WPF_Unleashed._4_ProfessionalTools
{
    /// <summary>
    /// Interaction logic for ProfessionalTools.xaml
    /// </summary>
    public partial class ProfessionalTools : Window
    {
        public ProfessionalTools()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _12_Resources.Resources window = new _12_Resources.Resources();
            window.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _13_DataBinding.DataBinding window = new _13_DataBinding.DataBinding();
            window.Show();
        }
    }
}
