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

namespace WPF_Unleashed._3_Control_Elements._10_ManyChildElements
{
    /// <summary>
    /// Interaction logic for DataGrid.xaml
    /// </summary>
    public partial class DataGrid : Window
    {
        public DataGrid()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = new Record[]
            {
                new Record { FirstName="Adam", LastName="Nathan", Website=
                new Uri("http://adamnathan.net"), Gender=Gender.Male },
                new Record { FirstName="Bill", LastName="Gates", Website=
                new Uri("http://twitter.com/billgates"), Gender=Gender.Male,
                IsBillionaire=true }
            };
        }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public class Record
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Uri Website { get; set; }
        public bool IsBillionaire { get; set; }
        public Gender Gender { get; set; }
    }
}
