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
using System.Text.RegularExpressions;


namespace WPF_Unleashed._1_Basic_Information._2_XAML
{
    /// <summary>
    /// Interaction logic for StreamConditioningOffset.xaml
    /// </summary>
    public partial class StreamConditioningOffset : Window, INotifyPropertyChanged
    {
        public StreamConditioningOffset()
        {
            InitializeComponent();
            this.DataContext = this;
            MyList = new List<Test>();
            MyList.Add(new Test { IsChecked = true, Offset = "10" });
            MyList.Add(new Test { IsChecked = false, Offset = "20" });
        }

        // CheckBox
        protected void OnPropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public bool IsChecked
        {
            get
            {
                return isChecked;
            }

            set
            {
                isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Handle(sender as CheckBox);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Handle(sender as CheckBox);
        }

        void Handle(CheckBox checkBox)
        {
            // Use IsChecked.
            bool flag = checkBox.IsChecked.Value;

            // Assign Window Title.
            this.Title = "IsChecked = " + flag.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format("IsChecked: {0}, ", IsChecked));
            IsChecked = !IsChecked;
            Offset = "99";
        }

        private bool isChecked;
        public event PropertyChangedEventHandler PropertyChanged;

        // TextBox
        public string Offset
        {
            get
            {
                return offset;
            }

            set
            {
                int numVal = Int32.Parse(value);
                if (numVal > 5000 || numVal < -3000)
                {
                    MessageBox.Show(string.Format("Corrcet range is [-3000;5000]"));
                }
                else
                {
                    offset = value;
                    OnPropertyChanged("Offset");
                }
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9]+$"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        private string offset;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //var data = new Test { IsChecked = IsChecked, Offset = Offset };
            ///DataGridTest.Items.Add(data);
            // OnPropertyChanged("MyList");

        }

        // Range validation rule, is my realisation correct?

        // DataGrid
        public List<Test> MyList { get; set; }


        // GroupBox
        private bool myStreamConditioning;
        private bool myStreamConditioningOffset;

        public bool StreamConditioning
        {
            get
            {
                return myStreamConditioning;
            }

            set
            {
                myStreamConditioning = value;
                OnPropertyChanged("StreamConditioning");
            }
        }

        public bool MyStreamConditioningOffset
        {
            get
            {
                return myStreamConditioningOffset;
            }

            set
            {
                myStreamConditioningOffset = value;
                OnPropertyChanged("MyStreamConditioningOffset");
            }
        }


    }

    public class Test
    {
        public bool IsChecked { get; set; }
        public string Offset { get; set; }
    }
    
    
}
