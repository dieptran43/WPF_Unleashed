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
    /// Interaction logic for ItemsControls.xaml
    /// </summary>
    public partial class ItemsControls : Window
    {
        public ItemsControls()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListBox window = new ListBox();
            window.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ItemsPanel window = new ItemsPanel();
            window.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Selectors window = new Selectors();
            window.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MyListView window = new MyListView();
            window.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MyTabControl window = new MyTabControl();
            window.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MyDataGrid window = new MyDataGrid();
            window.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MyMenu window = new MyMenu();
            window.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            MyContextMenu window = new MyContextMenu();
            window.Show();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            MyTreeView window = new MyTreeView();
            window.Show();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            MyToolBar window = new MyToolBar();
            window.Show();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            MyStatusBar window = new MyStatusBar();
            window.Show();
        }
    }
}
