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

namespace WPF_Unleashed._2_WPFApplication_Creation._6_InputEvents
{
    /// <summary>
    /// Interaction logic for AttachedEvent.xaml
    /// </summary>
    public partial class AttachedEvent : Window
    {
        public AttachedEvent()
        {
            InitializeComponent();
            //this.AddHandler(ListBox.SelectionChangedEvent,
            //    new SelectionChangedEventHandler(ListBox_SelectionChanged));
            //this.AddHandler(Button.ClickEvent, new RoutedEventHandler(Button_Click));
        }

        void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
                MessageBox.Show("You just selected " + e.AddedItems[0]);
        }

        void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You just clicked " + e.Source);
        }
    }
}
