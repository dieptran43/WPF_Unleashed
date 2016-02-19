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
    /// Interaction logic for Spin.xaml
    /// </summary>
    public partial class Spin : Window
    {
        public Spin()
        {
            InitializeComponent();
            grid.ManipulationStarting += Grid_ManipulationStarting;
            grid.ManipulationDelta += Grid_ManipulationDelta;
            grid.ManipulationInertiaStarting += Grid_ManipulationInertiaStarting;
            grid.ManipulationCompleted += Grid_ManipulationCompleted;
        }

        void Grid_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {
            // Включаем только для поворотов 
            e.Mode = ManipulationModes.Rotate;
        }

        void Grid_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            (prizeWheel.RenderTransform as RotateTransform).Angle +=
            e.DeltaManipulation.Rotation;
        }

        void Grid_ManipulationInertiaStarting(object sender, ManipulationInertiaStartingEventArgs e)
        {
            e.RotationBehavior.DesiredDeceleration = 0.001;
        }

        void Grid_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            // Колесо остановилось. Пора сообщить пользователю, // что он выиграл!
        }
    }
}
