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

namespace WPF_Unleashed.Testing.ItemsControls
{
    /// <summary>
    /// Interaction logic for ComboBox.xaml
    /// </summary>
    public partial class MyComboBox : Window
    {
        public MyComboBox()
        {
            InitializeComponent();
        }

        void OnDropDownOpened(object sender, EventArgs e)
        {
            //if (MyCB.IsDropDownOpen == true)
            //{
            //    MyCB.Text = "Combo box opened";
            //}
        }

        void OnDropDownClosed(object sender, EventArgs e)
        {
            //if (MyCB.IsDropDownOpen == false)
            //{
            //    MyCB.Text = "Combo box closed";
            //}
        }

        void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if(cb != null)
            {
                var index = cb.SelectedIndex;
                var item = cb.SelectedItem;
                var value = cb.SelectedValue;
            }

            if (e.AddedItems.Count > 0)
            {
                object newSelection = e.AddedItems[0];
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var index = MyCB.SelectedIndex;
            var item = MyCB.SelectedItem;
            var value = MyCB.SelectedValue;
            var items = MyCB.Items.Count;

            if(index == 1)
            {
                MyCB.SelectedIndex = 2;
            }
        }

    }
}
