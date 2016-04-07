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

namespace WPF_Unleashed._2_WPFApplication_Creation._7_ApplicationDeployment
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public TestWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChildWindow window = new ChildWindow();
            window.Owner = this;
            ChildWindowCount.Content = "Child Window count = " + OwnedWindows.Count.ToString();
            window.Show();
        }

        protected override void OnActivated(EventArgs e)
        {
            Console.WriteLine("TestWindow::OnActivated()");
            base.OnActivated(e);
        }

        protected override void OnDeactivated(EventArgs e)
        {
            Console.WriteLine("TestWindow::OnDeactivated()");
            base.OnDeactivated(e);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            Console.WriteLine("TestWindow::OnClosing()");
            base.OnClosing(e);

            // if (MessageBox.Show("Are you sure you want to close TestWindow?", "Annoying Prompt", MessageBoxButton.YesNo, MessageBoxImage.Question)
            //    == MessageBoxResult.No)
            //    e.Cancel = true;
        }

        protected override void OnClosed(EventArgs e)
        {
            Console.WriteLine("TestWindow::OnClosed()");
            base.OnClosed(e);
        }

        protected override void OnInitialized(EventArgs e)
        {
            Console.WriteLine("TestWindow::OnInitialized()");
            base.OnInitialized(e);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() == true) //Результат может быть равен true, false, или null
            {

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DialogWindow dialogWindow = new DialogWindow();
            if(dialogWindow.ShowDialog() == true)
            {
                Console.WriteLine("dialogWindow::ShowDialog() == true");
            }
        }
        
        // Создав объект Window, вы сможете показать его на экране с помощью метода Show, скрыть - методом Hide(это то же самое, что присвоить свойству Visibility значение Hidden или Collapsed)
        // и закрыть навсегда - методом Close.
        // Внешним видом Window можно управлять с помощью таких свойств, как Icon, Title(интерпретируется как заголовок окна) и Windowstyle.
        // Для управления положением на экране служат свойства Left и Тор. Более осмысленного поведения можно добиться, присваивая свойству WindowstartupLocation значение CenterScreen или CenterOwner.
        // Скажем, если установить для Topmost значение true, то окно будет всегда отображаться поверх других
        // если присвоить ShowInTaskbar значение false, то значок окна не будет показываться на панели задач.
        // Объект Window может создавать произвольное число дополнительных окон. Для этого нужно лишь создать объект класса, производного от Window, и вызвать его метод Show. Эти дополнительные окна при желании можно сделать дочерними. Дочернее окно ведет себя так же, как любое другое окно верхнего уровня, но автоматически закрывается, когда закрывается его родитель и минимизируется тоже вместе с родителем. Иногда такие окна называют не-модальными диалоговыми окнами.
        // Если некое окно хочет сделать другое окно дочерним, оно должно записать в свойство Owner(типа Window) последнего ссылку на себя, но только после того, как родитель уже был показан на экране. Перебрать дочерние окна позволяет доступное только для чтения свойство OwnedWindows.
        // Всякий раз, как окно становится активным или неактивным (например, из-за того, что пользователь переключается между разными окнами), возникает событие Activated или Deactivated объекта Window. Можно также принудительно сделать окно активным, вызвав его метод Activate (который ведет себя так же, как функция SetForegroundWindow из Win32 API). Можно предотвратить автоматическую активацию окна при первом показе, присвоив свойству ShowActivated значение false.
        // обработчик события может запретить закрытие окна, присвоив значение true свойству Cancelпереданного ему объекта CancelEventArgs
        // Если процесс закрытия не прерван, то окно закрывается и генерируется событие Closed(его отменить уже невозможно).


        // !!!
    }
}
