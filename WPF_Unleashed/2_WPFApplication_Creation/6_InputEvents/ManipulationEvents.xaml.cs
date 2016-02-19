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
    /// Interaction logic for ManipulationEvents.xaml
    /// </summary>
    public partial class ManipulationEvents : Window
    {
        public ManipulationEvents()
        {
            InitializeComponent();
            canvas.ManipulationDelta += Canvas_ManipulationDelta;
            canvas.ManipulationInertiaStarting += Canvas_ManipulationInertiaStarting;
        }

        void Canvas_ManipulationInertiaStarting(object sender, ManipulationInertiaStartingEventArgs e)
        {
            e.TranslationBehavior.DesiredDeceleration = 0.01;
            e.RotationBehavior.DesiredDeceleration = 0.01;
            e.ExpansionBehavior.DesiredDeceleration = 0.01;
        }

        void Canvas_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            MatrixTransform transform = photo.RenderTransform as MatrixTransform;
            if (transform != null)
            {
                // Применить дельты к матрице, затем воспользоваться 
                // созданной матрицей в преобразовании MatrixTransform
                Matrix matrix = transform.Matrix;
                matrix.Translate(e.DeltaManipulation.Translation.X,
                e.DeltaManipulation.Translation.Y);
                matrix.RotateAt(e.DeltaManipulation.Rotation,
                e.ManipulationOrigin.X, e.ManipulationOrigin.Y);
                matrix.ScaleAt(e.DeltaManipulation.Scale.X,
                e.DeltaManipulation.Scale.Y,
                e.ManipulationOrigin.X, e.ManipulationOrigin.Y);
                transform.Matrix = matrix;
                e.Handled = true;
            }
        }
    }
}
