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
    /// Interaction logic for TouchEvents.xaml
    /// </summary>
    public partial class TouchEvents : Window
    {
        public TouchEvents()
        {
            InitializeComponent();
        }
        // Сопоставляем изображения с объектами TouchDevice
        Dictionary<TouchDevice, Image> fingerprints =
        new Dictionary<TouchDevice, Image>();

        protected override void OnTouchDown(TouchEventArgs e)
        {
            base.OnTouchDown(e);
            // Захватываем данное сенсорное устройство
            canvas.CaptureTouch(e.TouchDevice);
            // Создаем новое изображение для этого касания
            Image fingerprint = new Image
            {
                Source = new BitmapImage(
                    new Uri("fingerprint.png"))
            };
            // Перемещаем изображение в точку касания
            TouchPoint point = e.GetTouchPoint(canvas);
            fingerprint.RenderTransform = new TranslateTransform(
            point.Position.X, point.Position.Y);
            // Запоминаем изображение и помещаем его на холст
            fingerprints[e.TouchDevice] = fingerprint;
            canvas.Children.Add(fingerprint);
        }

        protected override void OnTouchMove(TouchEventArgs e)
        {
            base.OnTouchMove(e);
            if (e.TouchDevice.Captured == canvas)
            {
                // Находим нужное изображение
                Image fingerprint = fingerprints[e.TouchDevice];
                TranslateTransform transform =
                fingerprint.RenderTransform as TranslateTransform;
                // Перемещаем его в новое место
                TouchPoint point = e.GetTouchPoint(canvas);
                transform.X = point.Position.X;
                transform.Y = point.Position.Y;
            }
        }

        protected override void OnTouchUp(TouchEventArgs e)
        {
            base.OnTouchUp(e);
            // Освобождаем захваченное устройство
            canvas.ReleaseTouchCapture(e.TouchDevice);
            // Удаляем изображение с холста и из словаря
            canvas.Children.Remove(fingerprints[e.TouchDevice]);
            fingerprints.Remove(e.TouchDevice);
        }
    }
}
