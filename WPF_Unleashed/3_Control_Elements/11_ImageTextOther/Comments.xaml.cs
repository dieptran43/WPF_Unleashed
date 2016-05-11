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
using System.Windows.Annotations;
using System.Windows.Annotations.Storage;
using System.IO;

namespace WPF_Unleashed._3_Control_Elements._11_ImageTextOther
{
    /// <summary>
    /// Interaction logic for Comments.xaml
    /// </summary>
    public partial class Comments : Window
    {
        FileStream stream;

        public Comments()
        {
            InitializeComponent();
        }

        protected void OnInitialized(object sender, EventArgs e)
        {
            // Включить и загрузить комментарии 
            AnnotationService service = AnnotationService.GetService(reader);
            if (service == null)
            {
                stream = new FileStream("storage.xml", FileMode.OpenOrCreate);
                service = new AnnotationService(reader);
                AnnotationStore store = new XmlStreamStore(stream);
                store.AutoFlush = true;
                service.Enable(store);
            }
        }
        protected void OnClosed(object sender, EventArgs e)
        {
            // Выключить и сохранить комментарии
            AnnotationService service = AnnotationService.GetService(reader);
            if (service != null && service.IsEnabled)
            {
                service.Disable();
                stream.Close();
            }
        }
    }
}
