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
using System.Globalization;

namespace WPF_Unleashed._4_ProfessionalTools._14_StyleTemplateCoverTheme
{
    /// <summary>
    /// Interaction logic for Templates.xaml
    /// </summary>
    public partial class Templates : Window
    {
        public Templates()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VSM window = new VSM();
            window.Show();
        }
    }

    public class ValueMinMaxToIsLargeArcConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType,
        object parameter, CultureInfo culture)
        {
            double value = (double)values[0];
            double minimum = (double)values[1];
            double maximum = (double)values[2];
            // Возвращаем true, только если value составляет не менее 50% диапазона
            return ((value * 2) >= (maximum - minimum));
        }
        public object[] ConvertBack(object value, Type[] targetTypes,
        object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public class ValueMinMaxToPointConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType,
        object parameter, CultureInfo culture)
        {
            double value = (double)values[0];
            double minimum = (double)values[1];
            double maximum = (double)values[2];
            // Приводит value к диапазону от 0 до 360
            double current = (value / (maximum - minimum)) * 360;
            // Корректируем вид в состоянии «полностью выполнено »,
            // чтобы дуга ArcSegment рисовалась в виде полной окружности
            if (current == 360)
                current = 359.999;
            // Поворачиваем на 90 градусов, чтобы 0 оказался в верхней точке окружности current = current - 90;
            // Переводим градусы в радианы current = current * 0.017453292519943295;
            // Вычисляем координаты точки на окружности
            double x = 10 + 10 * Math.Cos(current);
            double y = 10 + 10 * Math.Sin(current);
            return new Point(x, y);
        }
        public object[] ConvertBack(object value, Type[] targetTypes,
        object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
