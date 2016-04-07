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
using System.Threading;

namespace MyApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Thread.Sleep(2000);
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties["MyProperty"] = MyTextBox.Text;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MyLabel.Content = Application.Current.Properties["MyProperty"];
        }

        // Как в WPF создать приложение, которое может существовать в единственном экземпляре?
        // К WPF-приложениям применим классический подход к решению этой задачи: именованный (то есть единственный во всей операционной системе) мьютекс. Ниже показано, как это сделать на С#:

        // Многопоточные приложения
        // В типичном WPF-приложении имеется один поток пользовательского интерфейса и один поток визуализации. (Поток визуализации — это деталь реализации, которая разработчикам напрямую недоступна. Он работает в фоновом режиме и занимается разными низкоуровневыми операциями, в частности композицией.) Вы можете запускать и дополнительные фоновые потоки, но они не должны напрямую обращаться к любым производным от DispatcherObject объектам, созданным в потоке пользовательского интерфейса. (Из этого правила есть несколько исключений, например замороженный объект типа Freezable.)
        // К счастью, в WPF имеется простой механизм, позволяющий любому потоку за-планировать выполнение некоторого кода в потоке пользовательского интерфейса. В классе DispatcherObject определено свойство Dispatcher(типа Dispatcher). Возвращаемый им объект содержит несколько перегруженных вариантов методов Invoke(синхронный вызов) и BeginInvoke(асинхронный вызов). Эти методы позволяют передать делегат, который должен быть вызван в соответствующем диспетчеру потоке пользовательского интерфейса. Всем вариантам методов Invoke и Beginlnvoke в обязательном порядке передается значение перечисления DispatcherPriority, в котором определено 10 приоритетов, начиная от высшего Send(то есть выполнить немедленно) до низшего SystemIdle(выполнить, когда в очереди диспетчера больше ничего нет).
        // Можно даже создать в приложении несколько потоков пользовательского ин-терфейса, если вызвать метод Dispatcher.Run в запущенном вами потоке. Так образом, если у приложения более одного окна верхнего уровня, то каждое такое окно может работать в своем потоке. Это редко бывает необходимо, но в случае, когда одно окно может начать операцию, потребляющую все ресурсы потока, такая схема способна улучшить время отклика приложения. Правда, это негативно отражается на абстракции Application, потому что она подразумевает наличие единственного диспетчера. Например, коллекция Application.Windows содержит только окна, созданные в том же потоке, что и Application.

        // Показ заставки

    }
}
