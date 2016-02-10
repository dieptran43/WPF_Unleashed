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

namespace WPF_Unleashed._2_WPFApplication_Creation._5_LayoutPanels
{
    /// <summary>
    /// Interaction logic for LayoutPanels.xaml
    /// </summary>
    public partial class LayoutPanels : Window
    {
        public LayoutPanels()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Canvas window = new Canvas();
            window.Show();
        }

        // пять основных встроенных панелей
        // - Canvas
        // - StackPanel
        // - WrapPanel
        // - DockPanel
        // - Grid
        
        // Панель Canvas
        // Canvas поддерживает только «классическое» позиционирование элементов путем явного задания координат; впрочем, координаты хотя бы задаются в независимых от устройства пикселах, в отличие от прежних систем конструирования пользовательских интерфейсов. Панель Canvas позволяет задавать координаты относительнолюбого,  а не только левого верхнего угла.
        // Позиционирование элемента на холсте осуществляется с помощью присоединенных свойств: Left, Top, Right и Bottom. Задавая значение Left или Right, вы определяете, что ближайшая сторона элемента должна всегда отстоять на фиксированное расстояние от соответствующей стороны холста.
        // 



        // !!!
    }
}
