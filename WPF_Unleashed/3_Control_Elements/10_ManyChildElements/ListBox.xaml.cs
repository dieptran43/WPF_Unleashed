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

namespace WPF_Unleashed._3_Control_Elements._10_ManyChildElements
{
    /// <summary>
    /// Interaction logic for ListBox.xaml
    /// </summary>
    public partial class ListBox : Window
    {
        public ListBox()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Сначала очищаем имеющиеся описания сортировки
            myListBox.Items.SortDescriptions.Clear();
            // Затем сортируем по свойству Content
            myListBox.Items.SortDescriptions.Add(new SortDescription("Content", ListSortDirection.Descending));
        }
    }
}
