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
    /// Interaction logic for RoutedEvent.xaml
    /// </summary>
    public partial class RoutedEvent : Window
    {
        public RoutedEvent()
        {
            InitializeComponent();
            // Не очень правильно.
            // this.AddHandler(Window.MouseRightButtonDownEvent,
            //     new MouseButtonEventHandler(AboutDialog_MouseRightButtonDown), true);
        }

        void AboutDialog_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Вывести информацию о событии
            this.Title = "Source = " + e.Source.GetType().Name + ", OriginalSource = " +
            e.OriginalSource.GetType().Name + " @ " + e.Timestamp;
            // В этом примере все возможные источники наследуют Control
            Control source = e.Source as Control;
            // Показать или скрыть рамку вокруг элемента-источника
            if (source.BorderThickness != new Thickness(5))
            {
                source.BorderThickness = new Thickness(5);
                source.BorderBrush = Brushes.Black;
            }
            else
                source.BorderThickness = new Thickness(0);
        }
    }
}
