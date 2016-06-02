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

namespace WPF_Unleashed.Testing.Panel
{
    /// <summary>
    /// Interaction logic for CoolPanel.xaml
    /// </summary>
    public partial class CoolPanel : Window
    {
        // Фиктивные столбцы для слоев 0 и 1:
        ColumnDefinition column1CloneForLayer0;
        ColumnDefinition column2CloneForLayer0;
        ColumnDefinition column2CloneForLayer1;

        public CoolPanel()
        {
            InitializeComponent();

            // Инициализировать фиктивные столбцы, используемые,
            // когда панели пристыкованы
            column1CloneForLayer0 = new ColumnDefinition();
            column1CloneForLayer0.SharedSizeGroup = "column1";
            column2CloneForLayer0 = new ColumnDefinition();
            column2CloneForLayer0.SharedSizeGroup = "column2";
            column2CloneForLayer1 = new ColumnDefinition();
            column2CloneForLayer1.SharedSizeGroup = "column2";
        }

        // Переключаем состояние: пристыкована/ не пристыкована (панель 1)
        public void pane1Pin_Click(object sender, RoutedEventArgs e)
        {
            if (pane1Button.Visibility == Visibility.Collapsed)
                UndockPane(1);
            else
                DockPane(1);
        }

        // Переключаем состояние: пристыкована/ не пристыкована (панель 2)
        public void pane2Pin_Click(object sender, RoutedEventArgs e)
        {
            if (pane2Button.Visibility == Visibility.Collapsed)
                UndockPane(2);
            else
                DockPane(2);
        }

        // Показываем панель 1, когда указатель мыши находится над ее кнопкой
        public void pane1Button_MouseEnter(object sender, RoutedEventArgs e)
        {
            layer1.Visibility = Visibility.Visible;

            // Корректируем Z-порядок, чтобы панель всегда была сверху:
            parentGrid.Children.Remove(layer1);
            parentGrid.Children.Add(layer1);

            // Скрываем вторую панель, если она не пристыкована
            if (pane2Button.Visibility == Visibility.Visible)
                layer2.Visibility = Visibility.Collapsed;
        }

        // Показываем панель 2, когда указатель мыши находится над ее кнопкой
        public void pane2Button_MouseEnter(object sender, RoutedEventArgs e)
        {
            layer2.Visibility = Visibility.Visible;

            // Корректируем Z-порядок, чтобы панель всегда была сверху:
            parentGrid.Children.Remove(layer2);
            parentGrid.Children.Add(layer2);

            // Скрываем вторую панель, если она не пристыкована
            if (pane1Button.Visibility == Visibility.Visible)
                layer1.Visibility = Visibility.Collapsed;
        }

        // Скрываем все непристыкованные панели, когда указатель мыши перемещается в слой 0
        public void layer0_MouseEnter(object sender, RoutedEventArgs e)
        {
            if (pane1Button.Visibility == Visibility.Visible)
                layer1.Visibility = Visibility.Collapsed;
            if (pane2Button.Visibility == Visibility.Visible)
                layer2.Visibility = Visibility.Collapsed;
        }

        // Скрываем вторую панель, если она не пристыкована, когда указатель мыши перемещается на панель 1
        public void pane1_MouseEnter(object sender, RoutedEventArgs e)
        {
            // Скрываем вторую панель, если она не пристыкована
            if (pane2Button.Visibility == Visibility.Visible)
                layer2.Visibility = Visibility.Collapsed;
        }

        // Скрываем вторую панель, если она не пристыкована, когда указатель мыши перемещается на панель 2
        public void pane2_MouseEnter(object sender, RoutedEventArgs e)
        {
            // Скрываем другую панель,если она не пристыкована
            if (pane1Button.Visibility == Visibility.Visible)
                layer1.Visibility = Visibility.Collapsed;
        }

       // Пристыковываем панель, при этом скрывается соответствующая ей кнопка
        public void DockPane(int paneNumber)
        {
            if (paneNumber == 1)
            {
                pane1Button.Visibility = Visibility.Collapsed;
                pane1PinImage.Source = new BitmapImage(new Uri("pin.gif", UriKind.Relative));

                // Добавляем клонированный столбец в слой 0:
                layer0.ColumnDefinitions.Add(column1CloneForLayer0);
                // Добавляем клонированный столбец в слой 1, но только если панель 2 пристыкована:
                if (pane2Button.Visibility == Visibility.Collapsed) layer1.ColumnDefinitions.Add(column2CloneForLayer1);
            }
            else if (paneNumber == 2)
            {
                pane2Button.Visibility = Visibility.Collapsed;
                pane2PinImage.Source = new BitmapImage(new Uri("pin.gif", UriKind.Relative));

                // Добавляем клонированный столбец в слой 0:
                layer0.ColumnDefinitions.Add(column2CloneForLayer0);
                // Добавляем клонированный столбец в слой 1, но только если панель 1 пристыкована:
                if (pane1Button.Visibility == Visibility.Collapsed) layer1.ColumnDefinitions.Add(column2CloneForLayer1);
            }
        }

        // Отстыковываем панель, при этом становится видна соответствующая ей кнопка
        public void UndockPane(int paneNumber)
        {
            if (paneNumber == 1)
            {
                layer1.Visibility = Visibility.Collapsed;
                pane1Button.Visibility = Visibility.Visible;
                pane1PinImage.Source = new BitmapImage(new Uri("pinHorizontal.gif", UriKind.Relative));

                // Удаляем клонированные столбцы из слоев 0 и 1:
                layer0.ColumnDefinitions.Remove(column1CloneForLayer0);
                // Этот столбец присутствует не всегда, но метод Remove
                // молча игнорирует попытку удалить несуществующий столбец:
                layer1.ColumnDefinitions.Remove(column2CloneForLayer1);
            }
            else if (paneNumber == 2)
            {
                layer2.Visibility = Visibility.Collapsed;
                pane2Button.Visibility = Visibility.Visible;
                pane2PinImage.Source = new BitmapImage(new Uri("pinHorizontal.gif", UriKind.Relative));

                // Удаляем клонированные столбцы из слоев 0 и 1:
                layer0.ColumnDefinitions.Remove(column2CloneForLayer0);
                // Этот столбец присутствует не всегда, но метод Remove
                // молча игнорирует попытку удалить несуществующий столбец:
                layer1.ColumnDefinitions.Remove(column2CloneForLayer1);
            }
        }
    }
}
