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
using System.Collections.ObjectModel;

namespace WPF_Unleashed._4_ProfessionalTools._13_DataBinding
{
    /// <summary>
    /// Interaction logic for UsingBinding.xaml
    /// </summary>
    public partial class UsingBinding : Window
    {
        public UsingBinding()
        {
            InitializeComponent();

            // Binding binding = new Binding();
            // Задаем объект-источник 
            // binding.Source = treeView;
            // Задаем свойство-источник
            // binding.Path = new PropertyPath("SelectedValue");
            // Присоединяем к нему свойство-приемник
            // currentFolder.SetBinding(TextBlock.TextProperty, binding);
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //currentFolder.Text = treeView.SelectedValue.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Age = Convert.ToInt32(myAge.Text);
        }

        public Int32 Age
        {
            get
            {
                return m_Age;
            }

            set
            {
                m_Age = value;
            }
        }

        private Int32 m_Age;
    }
}
