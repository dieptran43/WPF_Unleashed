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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Unleashed._2_WPFApplication_Creation._7_ApplicationDeployment
{
    /// <summary>
    /// Interaction logic for PhotoPage.xaml
    /// </summary>
    public partial class PhotoPage : Page
    {
        public PhotoPage()
        {
            InitializeComponent();
            // NavigationService.LoadCompleted += new LoadCompletedEventHandler(container_LoadCompleted);
        }

        public PhotoPage(Page navigationPage)
        {
            InitializeComponent();
            // NavigationService.LoadCompleted += new LoadCompletedEventHandler(container_LoadCompleted);
            mNavigationPage = navigationPage;
        }

        private Page mNavigationPage;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(mNavigationPage != null)
            {
                this.NavigationService.Navigate(mNavigationPage);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("http://www.google.com.ua"));
        }

        void container_LoadCompleted(object sender, NavigationEventArgs e)
        {
            if (e.ExtraData != null)
                PhotoMessage.Text = (String)(e.ExtraData);
        }
       
    }
}
