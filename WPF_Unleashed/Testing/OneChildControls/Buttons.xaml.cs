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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Unleashed.Testing.OneChildControls
{
    /// <summary>
    /// Interaction logic for Buttons.xaml
    /// </summary>
    public partial class Buttons : Page
    {
        public Buttons()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String name = myLabel.Content.ToString();
            DialogWindow dialog = new DialogWindow(name);
            if(dialog.ShowDialog() == true)
            {
                String newFileName = dialog.NewFileName;
                myLabel.Content = newFileName;
            }
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            Rect.Width += 10;
        }

        private void RepeatButton_Click_1(object sender, RoutedEventArgs e)
        {
            Rect.Width -= 10;
        }
    }
}
