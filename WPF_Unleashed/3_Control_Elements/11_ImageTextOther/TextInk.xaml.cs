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

namespace WPF_Unleashed._3_Control_Elements._11_ImageTextOther
{
    /// <summary>
    /// Interaction logic for TextInk.xaml
    /// </summary>
    public partial class TextInk : Window
    {
        public TextInk()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // ... Get control that raised this event.
            var textBox = sender as TextBox;
            // ... Change Window Title.
            this.Title = textBox.Text +
            "[Length = " + textBox.Text.Length.ToString() + "]";
        }
    }
}
