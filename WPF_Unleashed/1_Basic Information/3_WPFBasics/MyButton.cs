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
using System.Windows.Controls.Primitives;

namespace WPF_Unleashed._1_Basic_Information._3_WPFBasics
{
    class MyButton : ButtonBase
    {
        // Свойство зависимости
        public static readonly DependencyProperty IsDefaultProperty;
        static MyButton()
        {
            // Зарегестрировать свойство
            MyButton.IsDefaultProperty = DependencyProperty.Register("IsDefault",
            typeof(bool), typeof(MyButton),
            new FrameworkPropertyMetadata(false,
            new PropertyChangedCallback(OnIsDefaultChanged)));
        }

        // Обертка в виде обычного свойства .NET (необязательно)
        public bool IsDefault
        {
            get { return (bool)GetValue(Button.IsDefaultProperty); }
            set { SetValue(Button.IsDefaultProperty, value); }
        }

        // Метод, вызываемый при изменении свойства (необязательно)
        private static void OnIsDefaultChanged(
        DependencyObject o, DependencyPropertyChangedEventArgs e) { }
    }
}
