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
using System.ComponentModel;

namespace WPF_Unleashed.Testing.ItemsControls
{
    /// <summary>
    /// Interaction logic for MyListBox.xaml
    /// </summary>
    public partial class MyListBox : Window
    {
        public MyListBox()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyLB.Items.SortDescriptions.Clear();
            MyLB.Items.SortDescriptions.Add(new SortDescription("Content", ListSortDirection.Ascending));
        }
    }
}
