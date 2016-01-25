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
using System.Diagnostics;

namespace WPF_Unleashed._1_Basic_Information._3_WPFBasics
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
            PrintLogicalTree(0, this);
        }

        // который выполняется после завершения компоновки.
        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            PrintVisualTree(0, this);
        }

        void PrintLogicalTree(int depth, object obj)
        {
            // Напечатать объект с предшествующими пробелами,
            // число которых соответствует глубине вложенности
            Debug.WriteLine(new string(' ', depth) + obj);
            // Иногда листовые узлы не принадлежат классу
            // DependencyObject (например, строки)
            if (!(obj is DependencyObject)) return;
            // Рекурсивный вызов для каждого логического
            // дочернего узла
            foreach (object child in LogicalTreeHelper.GetChildren(obj as DependencyObject))
                PrintLogicalTree(depth + 1, child);
        }

        void PrintVisualTree(int depth, DependencyObject obj)
        {
            // Напечатать объект с предшествующими пробелами,
            // число которых соответствует глубине вложенности
            Debug.WriteLine(new string(' ', depth) + obj);
            // Рекурсивный вызов для каждого логического
            // дочернего узла
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                PrintVisualTree(depth + 1, VisualTreeHelper.GetChild(obj, i));
        }

        // Сделать цвет фона синим, когда указатель находится над кнопкой
        void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            if (b != null) b.Foreground = Brushes.Blue;
        }
        // Восстановить черный цвет фона, когда указатель покидает кнопку
        void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            if (b != null) b.Foreground = Brushes.Black;
        }
    }
}
