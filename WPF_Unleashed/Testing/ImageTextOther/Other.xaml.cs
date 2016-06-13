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
    /// Interaction logic for Other.xaml
    /// </summary>
    public partial class Other : Window
    {
        public Other()
        {
            InitializeComponent();
        }

        private void MyS_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MyPB.Value = MyS.Value * 10;
        }
    }
}
