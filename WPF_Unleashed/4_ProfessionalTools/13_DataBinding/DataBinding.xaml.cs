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
using System.Globalization;
using System.IO;

namespace WPF_Unleashed._4_ProfessionalTools._13_DataBinding
{
    /// <summary>
    /// Interaction logic for DataBinding.xaml
    /// </summary>
    public partial class DataBinding : Window
    {
        public DataBinding()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UsingBinding window = new UsingBinding();
            window.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataBindingPhotoGallery.MainWindow window = new DataBindingPhotoGallery.MainWindow();
            window.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DataProvider window = new DataProvider();
            window.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SeveralSources window = new SeveralSources();
            window.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Twitter window = new Twitter();
            window.Show();
        }
    }

    public class JpgValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string filename = value.ToString();
            // Отвергаем несуществующие файлы:
            if (!File.Exists(filename))
                return new ValidationResult(false, "Value is not a valid file.");
            // Отвергаем файлы с расширением, отличным от .jpg:
            if (!filename.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase))
                return new ValidationResult(false, "Value is not a .jpg file.");
            // Данные прошли все проверки!
            return new ValidationResult(true, null);
        }
    }

    // public class ProgressConverter : IMultiValueConverter
    // {
    //     public object Convert(object[] values, Type targetType,
    //     object parameter, CultureInfo culture)
    //     {
    //         int totalProgress = 0;
    //         // Требуется, чтобы каждое поданное на вход значение было экземпляром класса Worker
    //         foreach (Worker worker in values)
    //             totalProgress += worker.Progress;
    //         return totalProgress;
    //     }
    //     public object[] ConvertBack(object value, Type[] targetTypes,
    //     object parameter, CultureInfo culture)
    //     {
    //         return DependencyProperty.UnsetValue;
    //     }
    // }

    // Привязка к данным
    // WPF термин данные обычно употребляется для описания произвольного объекта .NET.
    // Примерами такого соглашения могут служить словосочетания привязка к данным, шаблоны данных и триггеры данных.
    // В роли данных может выступать объект-коллекция, XML-файл, веб-служба, таблица базы данных, объект написанного вами класса и даже элемент WPF, к примеру Button.
    // Классический пример – визуальное представление (например, в виде списка ListBox или сетки DataGrid) данных, хранящихся в XML-файле, в базе данных или в коллекции в памяти.
    
    // Знакомство с объектом Binding
    // Ключом к механизму привязки к данным является объект класса System.Windows.Data.Binding, который «склеивает» между собой два свойства и открывает коммуникационный канал между ними.
    // Объект Binding можно один раз настроить и поручить ему дальнейшую заботу о синхронизации.

    // Использование объекта Binding в процедурном коде
    // Для объекта Binding определены понятия свойства-источника и свойства-приемника.
    // Свойство-источник (в нашем случае treeView.SelectedItem.Header) задается в два приема:
    // запись ссылки на объект-источник в свойство Source и имени интересующего нас свойства (или цепочки, состоящей из имени свойства и его «субсвойств»), обернутого объектом PropertyPath, в свойство Path.
    // Чтобы ассоциировать Binding со свойством-приемником (в нашем случае currentFolder.Text) Binding, нужно вызвать метод SetBinding (унаследованный от класса FrameworkElement или FrameworkContentElement), передав ему нужное свойство зависимости и сам объект Binding.
    // СОВЕТ
    // На самом деле существует два способа настроить объект Binding в процедурном коде.
    // Первый – вызвать метод экземпляра SetBinding от имени объекта FrameworkElement или FrameworkContentElement, как было показано выше.
    // Второй – вызвать статический метод SetBinding класса BindingOperations. Ему передаются те же аргументы, что и методу экземпляра, плюс дополнительный первый аргумент, представляющий объект-приемник:
    // BindingOperations.SetBinding(currentFolder, TextBlock.TextProperty, binding);
    // Достоинство статического метода в том, что первый параметр имеет тип DependencyObject, то есть открывается возможность осуществлять привязку к объектам, не наследующим ни FrameworkElement, ни FrameworkContentElement (например, класса Freezable).
    // КОПНЕМ ГЛУБЖЕ
    // Удаление объекта Binding
    // Если вы не хотите, чтобы объект Binding существовал на протяжении всего времени работы приложения, то его можно в любой момент «отключить» с помощью статического метода BindingOperations.ClearBinding.
    // Методу передается объект-приемник и его свойство зависимости.
    // BindingOperations.ClearBinding(currentFolder, TextBlock.TextProperty);
    // Если к объекту-приемнику присоединено более одного объекта Binding, то можно очистить их все за один прием, вызвав метод BindingOperations.ClearAllBindings:
    // BindingOperations.ClearAllBindings(currentFolder);
    // Еще один способ убрать привязку – напрямую записать в свойство-приемник новое значение, например:
    // currentFolder.Text = "I am no longer receiving updates.";
    // Но такой способ очищает только односторонние привязки.
    // Подход на основе метода ClearBinding в любом случае более гибкий, поскольку оставляет свойству зависимости возможность принимать данные из других источников с более низким приоритетом (триггеров стилей, механизма наследования значений свойств и т. д.).
    
    // Использование объекта Binding в XAML
    // СОВЕТ
    // Помимо конструктора по умолчанию в классе Binding имеется конструктор, принимающий один аргумент Path.
    // Следовательно, можно оформить расширение разметки и по-другому, передав путь Path конструктору, а не устанавливая его явно в качестве свойства.
    // Иными словами, приведенный выше фрагмент XAML можно было бы переписать и в таком виде:
    // Text="{Binding SelectedItem.Header, ElementName=treeView}"
    // Впрочем, с появлением в WPF 4 расширения разметки x:Reference свойство Source можно задать следующим образом:
    // Text="{Binding Source={x:Reference TreeView}, Path=SelectedItem.Header}"
    // СОВЕТ
    // С помощью свойства TargetNullValue объекта Binding можно указать специальное значение, которое будет возвращаться, если значение реального свойства-источника равно null.
    // Например, в показанном ниже текстовом блоке будет отображаться не пустая строка, а строка «Nothing is selected.» (Ничегоне выбрано) в случае, когда значение-источник равно null:
    // <TextBlock Text="{Binding ... TargetNullValue=Nothing is selected.}" .../>
    // КОПНЕМ ГЛУБЖЕ
    // Свойство RelativeSource объекта Binding
    // Чтобы сделать элемент-источник равным элементу-приемнику:
    // {Binding RelativeSource={RelativeSource Self}}
    // Чтобы сделать элемент-источник равным свойству TemplatedParent элемента-приемника
    // {Binding RelativeSource={RelativeSource TemplatedParent}}
    // Чтобы сделать элемент-источник равным ближайшему родителю элемента-приемника, имеющему заданный тип:
    // {Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type desiredType}}}
    // Чтобы сделать элемент- источник равным n-му ближайшему родителю элемента-приемника, имеющему заданный тип:
    // {Binding RelativeSource={RelativeSource FindAncestor, AncestorLevel=n, AncestorType={x:Type desiredType}}}
    // Чтобы сделать элемент-источник равным предыдущему объекту в коллекции, привязанной к данным:
    // {Binding RelativeSource={RelativeSource PreviousData}}
    // Особенно полезно свойство RelativeSource в контексте шаблонов элементов управления, которые мы будем обсуждать в следующей главе.
    // Однако использование RelativeSource в режиме Self удобно для привязки одного свойства элемента к другому его же свойству без указания имени элемента.
    
    // Привязка к обычным свойствам .NET
    // Однако на пути использования обычного свойства .NET в качестве источника привязки нас подстерегает неприятность.
    // Поскольку в таких свойствах не предусмотренысредства уведомления об изменениях, то приемник не будет автоматически синхронизироваться с источником – для этого нужна дополнительная работа.
    // Чтобы синхронизировать источник с приемником, объект- источник должен сделать одно из двух:
    // - Реализовать интерфейс System.ComponentModel.INotifyPropertyChanged, в котором определено единственное событие PropertyChanged.
    // - Реализовать событие XXXChanged, где XXX – имя свойства, значение которого изменяется.
    // Рекомендуется первое решение, поскольку WPF оптимизирована под него. 
    // Таким образом, для синхронизации привязки к photos.Count достаточно заменить в исходном коде строку 
    // public class Photos : Collection<Photo>
    // на такую
    // public class Photos : ObservableCollection<Photo>

    // КОПНЕМ ГЛУБЖЕ
    // Как работает привязка к обычным свойствам .NET
    // Чтобы получить значение свойства-источника, которое является обычным свойством .NET, WPF применяет отражение.
    // ПРЕДУПРЕЖДЕНИЕ
    // Источники и приемники данных обрабатываются по-разному!
    // Свойством-источником действительно может быть любое свойство любого объекта .NET, однако для свойства-приемника это уже не так.
    // Свойство-приемник обязано быть свойством зависимости.
    // Отметим также, что источник должен быть настоящим (и притом открытым) свойством, а не просто полем.

    // Привязка ко всему объекту
    // Можно привязать свойство-приемник ко всему объекту.
    // СОВЕТ
    // Привязка ко всему объекту удобна, когда нужно в XAML-коде задать некое свойство, требующее объекта, который нельзя получить ни с помощью конвертера типа, ни посредством расширения разметки.
    // ПРЕДУПРЕЖДЕНИЕ
    // Будьте осторожны с привязкой к объекту типа UIElement!
    // Привязывая некоторые свойства-приемники ко всему объекту UIElement, вы можете, сами того не желая, попытаться поместить один и тот же элемент в разные места визуального дерева.
    // Привязка к коллекции
    // Непосредственная привязка
    // Однако и ListBox, и все прочие многодетные элементы управления имеют свойство зависимости ItemsSource, специально предназначенное для привязки к данным.
    // <ListBox x:Name="pictureBox"
    // ItemsSource="{Binding Source={StaticResource photos}}" ...>
    // ...
    // </ListBox>
    // Чтобы свойство-приемник синхронизировалось с изменениями в коллекции-источнике (то есть отражало добавление и удаление объектов), коллекция-источник должна реализовывать интерфейс INotifyCollectionChanged.
    // Улучшение отображения
    // Один из способов навести порядок – воспользоваться свойством DisplayMemberPath, которое имеется у всех многодетных элементов управления.
    // Оно работает рука об руку со свойством ItemsSource.
    // <ListBox x:Name="pictureBox" DisplayMemberPath="Name"
    // ItemsSource="{Binding Source={StaticResource photos}}" ...>
    // ...
    // </ListBox>
    // ПРЕДУПРЕЖДЕНИЕ
    // Свойства Items и ItemsSource объекта ItemsControl нельзя модифицировать одновременно!
    // Вы должны заранее решить, как будете заполнять многодетный элемент управления: вручную с помощью свойства Items или путем привязки к данным с помощью свойства ItemsSource, потому что смешивать эти два приема нельзя.
    // Отметим, что вне зависимости от того, каким способом объекты помещаются в многодетный элемент управления, обращаться к ним для чтения всегда разрешается с помощью коллекции Items.

    // Управление выбранным объектом
    // Чтобы включить рассматриваемую поддержку, присвойте значение true свойству IsSynchronizedWithCurrentItem
    
    // ПРЕДУПРЕЖДЕНИЕ
    // Свойство IsSynchronizedWithCurrentItem не поддерживает множественный выбор!
    // Если в селекторе Selector выбрано несколько объектов (как в случае, когда свойство SelectionMode элемента ListBox равно Multiple или Extended), то все остальные синхронизированные с ним элементы увидят только первый выбранный объект, даже если сами поддерживают множественный выбор!
    
    // Обобществление источника с помощью DataContext
    // Поэтому WPF поддерживает задание неявного источника данных вместо того, чтобы явно указывать в каждом элементе Binding свойства Source, RelativeSource или ElementName.
    // Такой неявный источник данных называют также контекстом данных.
    // чтобы привязать элементы Label и ListBox к одному и тому же объекту-источнику, можно было бы установить DataContext следующим образом:
    // <StackPanel DataContext="{StaticResource photos}">
    // <Label x:Name="numItemsLabel"
    // Content="{Binding Path=Count}" .../>
    // ...
    // <ListBox x:Name="pictureBox" DisplayMemberPath="Name"
    // ItemsSource="{Binding}" ...>
    // ...
    // </ListBox>
    // ...
    // </StackPanel>
    // СОВЕТ
    // Увидев в XAML свойство, значением которого является просто строка {Binding}, легко прийти в недоумение, но это всего  лишь означает, что объект-источник задан где-то выше в дереве в виде контекста данных и что привязка производится ко всему этому объекту, а не к отдельному его свойству.
    // FAQ
    // Когда следует задавать объект-источник в виде контекста данных, а когда явно в привязке Binding?
    // Вообще говоря, это дело вкуса. Если объект-источник используется только в одном свойстве-приемнике, то определение контекста данных – это перебор, да и разметка становится менее понятной.
    // Если же объект-источник обобществляется, то контекст данных позволяет описать его в одном месте и, значит, уменьшить вероятность ошибки в случае смены источника.
    // Одна из ситуаций, когда контекст данных оказывается по-настоящему полезным, – подключение ресурсов, определенных где-то в другом месте. 
    
    // Управление визуализацией
    // WPF предоставляет три разных способа получить и отобразить значение источника, поэтому не стоит отказываться от преимуществ привязки к данным, когда с первого взгляда неясно, как добиться желаемого результата в нестандартной ситуации.
    // Вот эти способы: форматирование строк, шаблоны данных и конвертеры значений.
    
    // Форматирование строк
    // Когда результатом привязки к данным должно стать отображение строки, может оказаться полезным свойство StringFormat объекта Binding.
    // Если оно задано, то WPF вызывает метод String.Format, передавая ему значение свойства StringFormat в первом аргументе (format) и неформатированный объект-приемник – во втором (args[0]).
    // <TextBlock x:Name="numItemsLabel"
    // Text="{Binding StringFormat={}{0} item(s),
    // Source={StaticResource photos}, Path=Count}"
    // DockPanel.Dock="Bottom"/>
    // Вставлять {} необязательно, если Binding используется в виде элемента (а не атрибута) свойства:
    // <TextBlock x:Name="numItemsLabel" DockPanel.Dock="Bottom">
    // <TextBlock.Text>
    // <Binding Source="{StaticResource photos}" Path="Count">
    // <Binding.StringFormat>{0} item(s)</Binding.StringFormat>
    // </Binding>
    // </TextBlock.Text>
    // </TextBlock>
    // ПРЕДУПРЕЖДЕНИЕ
    // Свойство StringFormat работает, только если свойство-приемник — строка!
    // Попытка воспользоваться им для свойства Content элемента Label не даст никакого эффекта, потому что тип этого свойства – Object.
    // А вот свойство Text элемента TextBlock имеет тип string, поэтому та же привязка работает для него отлично.
    // ПРЕДУПРЕЖДЕНИЕ
    // System.Xaml обрабатывает управляющую последовательность {} некорректно!
    // У многих элементов управления имеется также свойство XXXStringFormat, где XXX представляет форматируемую часть.
    // Например, у однодетных элементов есть свойство ContentStringFormat, которое применяется к свойству Content, а у многодетных – свойство ItemStringFormat, применяемое к каждому объекту в коллекции. 
    // Свойства форматирования строк, имеющиеся в WPF
    // Свойство - Классы
    // StringFormat - BindingBase
    // ContentStringFormat - ContentControl, ContentPresenter, TabControl
    // ItemStringFormat - ItemsControl, HierarchicalDataTemplate
    // HeaderStringFormat - HeaderedContentControl, HeaderedItemsControl, DataGridColumn, GridViewColumn, GroupStyle
    // ColumnHeaderStringFormat - GridView, GridViewHeaderRowPresenter
    // Вместо замены Label на TextBlock, чтобы иметь возможность воспользоваться свойством StringFormat объекта Binding, можно было бы прибегнуть к собственному свойству элемента Label – ContentStringFormat, поскольку Label – однодетный элемент управления.

    // Шаблоны данных
    // Шаблон данных – это часть пользовательского интерфейса, которую можно применять к произвольному объекту .NET на этапе его визуализации.
    // Свойства типа DataTemplate
    // Свойство - Классы
    // ContentTemplate - ContentControl, ContentPresenter, TabControl
    // ItemTemplate - ItemsControl, HierarchicalDataTemplate
    // HeaderTemplate - HeaderedContentControl, HeaderedItemsControl, DataGridRow, DataGridColumn, GridViewColumn, GroupStyle
    // SelectedContentTemplate - TabControl
    // DetailsTemplate - DataGridRow
    // RowDetailsTemplate - DataGrid
    // RowHeaderTemplate - DataGrid
    // ColumnHeaderTemplate - GridView, GridViewHeaderRowPresenter
    // CellTemplate - DataGridTemplateColumn, GridViewColumn
    // CellEditingTemplate - DataGridTemplateColumn
    // Класс DataTemplate, как и класс ItemsPanelTemplate, является производным от FrameworkTemplate. 
    // Поэтому в нем есть свойство содержимого VisualTree, в которое можно записать произвольное дерево элементов FrameworkElement.
    // <ListBox x:Name="pictureBox"
    // ItemsSource="{Binding Source={StaticResource photos}}" ...>
    // <ListBox.ItemTemplate>
    // <DataTemplate>
    // <Image Source="placeholder.jpg" Height="35"/>
    // </DataTemplate>
    // </ListBox.ItemTemplate>
    // ...
    // </ListBox>
    // чтобы получить фотографии нужно:
    // <ListBox x:Name="pictureBox"
    // ItemsSource="{Binding Source={StaticResource photos}}" ...>
    // <ListBox.ItemTemplate>
    // <DataTemplate>
    // <Image Source="{Binding Path=FullPath}" Height="35"/>
    // </DataTemplate>
    // </ListBox.ItemTemplate>
    // ...
    // </ListBox>
    // Разумеется, шаблон данных необязательно определять в том месте, где он используется.
    // Чаще всего шаблоны данных хранятся в виде ресурсов, разделяемых несколькими элементами.
    // СОВЕТ
    // Хотя шаблоны данных можно использовать и с объектами, не привязанными к данным (например, со списком ListBox, который заполнялся вручную), почти всегда желательно, чтобы внутри шаблона привязка к данным была – именно это позволяет изменять визуальное дерево в соответствии с отображаемыми объектами.
    // КОПНЕМ ГЛУБЖЕ
    // Селекторы шаблонов
    // WPF предоставляет также механизм, позволяющий подключить  процедурный код, который может выбрать любой шаблон (или создать новый «на лету») во время выполнения программы, когда возникает необходимость визуализировать данные.
    // Для этого нужно создать класс, производный от DataTemplateSelector, и переопределить в нем виртуальный метод SelectTemplate. 
    // Свойство - Классы
    // ContentTemplateSelector - ContentControl, ContentPresenter, TabControl
    // ItemTemplateSelector - ItemsControl, HierarchicalDataTemplate
    // HeaderTemplateSelector - HeaderedContentControl, HeaderedItemsControl, DataGridRow, DataGridColumn, GridViewColumn, GroupStyle
    // SelectedContentTemplateSelector - TabControl
    // DetailsTemplateSelector - DataGridRow
    // RowDetailsTemplateSelector - DataGrid
    // RowHeaderTemplateSelector - DataGrid
    // ColumnHeaderTemplateSelector - GridView, GridViewHeaderRowPresenter
    // CellTemplateSelector - DataGridTemplateColumn, GridViewColumn
    // CellEditingTemplateSelector - DataGridTemplateColumn
    
    // Конвертеры значений
    // Если шаблоны данных позволяют изменить способ визуализации значений в свойстве-приемнике, то конвертеры значений предназначены для преобразования значения, полученного из источника, в нечто совершенно  иное перед доставкой приемнику.
    // С их помощью можно подключить собственный код, не отказываясь  от преимуществ привязки к данным.
    
    // Согласование несовместимых типов данных
    // Допустим, вы задумали менять цвет фона метки  (свойство Background) в зависимостиот количества фотографий в коллекции  photos (значение свойства Count).
    // Следующая привязка не имеет смысла, так как пытается присвоить свойству Background число, а не ожидаемый объект Brush:
    // <Label Background="{Binding Path=Count, Source={StaticResource photos}}" .../>
    // Дело можно поправить, подключив конвертер значений с помощью свойства Converter:
    // <Label Background="{Binding Path=Count, Converter={StaticResource myConverter}, Source={StaticResource photos}}" .../>
    // Здесь предполагается, что вы написали класс, умеющий преобразовывать целое  число в кисть Brush, и включили его в состав ресурсов:
    // <Window.Resources>
    // <local:CountToBackgroundConverter x:Key="myConverter"/>
    // </Window.Resources>
    // Чтобы создать такой класс CountToBackgroundConverter, необходимо реализовать простой  интерфейс IValueConverter (определен в пространстве имен System.Windows.Data).
    // В этом интерфейсе есть всего два метода: Convert, принимающий объект-источник, который нужно преобразовать в объект-приемник, и ConvertBack, выполняющий обратную операцию.
    // СОВЕТ
    // Во избежание недоразумений рекомендуется отражать семантику конвертера значений в его названии.
    // СОВЕТ
    // В состав WPF входит ряд конвертеров значений для нескольких очень распространенных сценариев привязки к данным. 
    // Один из них называется BooleanToVisibilityConverter и преобразует трехпозиционное перечисление Visibility (в нем определены значения Visible, Hidden, Collapsed) в тип Boolean, в том числе допускающий значение null (и обратно).
    // В одном направлении true отображается на Visible, а false и null – на Collapsed.
    // В другом направлении Visible отображается на true, а Hidden и Collapsed – на false.
    // ПРЕДУПРЕЖДЕНИЕ
    // Ошибки привязки к данным не возбуждают исключений!
    // В случае когда во время привязки к данным обнаруживается ошибка, WPF не возбуждает исключение, а выводит пояснительный текст в трассировку отладки, которую можно видеть, только если к программе присоединен отладчик.
    
    // Настройка отображения данных
    // Конвертер значений позволяет настроить текст в зависимости от значения, то есть выводить «1 item» (в единственном числе), но «2 items» (во множественном числе).
    // Эту задачу решает класс RawCountToDescriptionConverter:
    // public class RawCountToDescriptionConverter : IValueConverter
    // {
    //     public object Convert(object value, Type targetType,
    //     object parameter, CultureInfo culture)
    //     {
    //     // Если формат входных данных недопустим, то Parse возбудит исключение
    //     int num = int.Parse(value.ToString());
    //     return num + (num == 1 ? " item" : " items");
    //     }
    //     public object ConvertBack(object value, Type targetType,
    //     object parameter, CultureInfo culture)
    //     {
    //         return DependencyProperty.UnsetValue;
    //     }
    // }
    // СОВЕТ
    // Конвертеры значений дают возможность подключить к процессу привязки к данным любую логику, выходящую за рамки простого форматирования.
    // Нужно ли вам применить к значению-источнику некоторое преобразование перед отображением или изменить способ обновления приемника при изменении значения-источника – все это можно легко сделать с помощью класса, реализующего интерфейс IValueConverter.
    // СОВЕТ
    // Можно сделать так, что конвертер значений будет временно отменять привязку к данным, возвращая специальное значение Binding.DoNothing.
    // Это не то же самое, что возврат null, поскольку null может быть вполне допустимым значением свойства-приемника.
    // Binding.DoNothing означает следующее: «Я не хочу сейчас ничего привязывать, сделай вид, что объекта Binding не существует».
    // FAQ
    // Как заставить конвертер значений выполнять преобразование для каждого объекта, когда привязка осуществляется к коллекции?
    // Можно применить шаблон данных к свойству ItemTemplate элемента ItemsControl, а затем применять конвертеры значений ко всем объектам Binding, находящимся внутри шаблона.
    
    // Настройка представления коллекции
    // Когда производится привязка к коллекции (любому объекту, реализующему интерфейс IEnumerable), между источником и приемником неявно вставляется представление по умолчанию.
    // В этом представлении (объекте, реализующем интерфейс ICollectionView) хранится вся информация о текущем объекте, но помимо этого оно поддерживает сортировку, группировку, фильтрацию и навигацию.
    // СОВЕТ
    // Представления автоматически ассоциируются с коллекциями-источниками, но не с приемниками.
    // В результате любое изменение представления (например, сортировка или фильтрация) автоматически становится видимым всем приемникам. 
    // Сортировка
    // SortDescription sort = new SortDescription("Name", ListSortDirection.Ascending);
    // Например, если добавить в коллекцию следующие два объекта SortDescription, то сначала будет произведена сортировка по DateTime в порядке убывания, а если при этом обнаружатся объекты с одинаковыми значениями в данном свойстве, то они будут дополнительно отсортированы по свойству Name (в порядке возрастания):
    // view.SortDescriptions.Add(new SortDescription("DateTime", ListSortDirection.Descending));
    // view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
    // КОПНЕМ ГЛУБЖЕ
    // Нестандартная сортировка
    // Если вам нужен больший контроль над процессом сортировки, чем может дать ICollectionView.SortDescriptions (что маловероятно), то лучше всего воспользоваться поддержкой нестандартной сортировки.
    // Если представляемая коллекция реализует интерфейс IList (как большинство коллекций), то объект ICollectionView, возвращенный методом CollectionViewSource.GetDefaultView, в действительности является экземпляром класса ListCollectionView.
    // Если привести ICollectionView к типу ListCollectionView, то можно будет присоединить объект, реализующий интерфейс IComparer, к его свойству CustomSort.

    // Группировка
    // В интерфейсе ICollectionView определено свойство GroupDescriptions, принцип работы которого такой же, как у SortDescriptions.
    // В эту коллекцию можно добавить сколько угодно объектов PropertyGroupDescription с целью разбить все объекты представляемой коллекции на группы и, возможно, подгруппы.
    // // Получаем представление по умолчанию
    // ICollectionView view = CollectionViewSource.GetDefaultView(this.FindResource("photos"));
    // // Выполняем группировку
    // view.GroupDescriptions.Clear();
    // view.GroupDescriptions.Add(new PropertyGroupDescription("DateTime"));
    // Списку ListBox в приложении Photo Gallery можно назначить такой объект GroupStyle:
    // <ListBox x:Name="pictureBox"
    // ItemsSource="{Binding Source={StaticResource photos}}" ...>
    // <ListBox.GroupStyle>
    // <GroupStyle>
    // <GroupStyle.HeaderTemplate>
    // <DataTemplate>
    // <Border BorderBrush="Black" BorderThickness="1">
    // <TextBlock Text="{Binding Path=Name}" FontWeight="Bold"/>
    // </Border>
    // </DataTemplate>
    // </GroupStyle.HeaderTemplate>
    // </GroupStyle>
    // </ListBox.GroupStyle>
    // ...
    // </ListBox>
    // СОВЕТ
    // Если вы хотите сгруппировать объекты, хранящиеся в многодетном элементе управления, но равнодушны к оформлению заголовков групп, то можете воспользоваться объектом GroupStyle, встроенным в WPF.
    // Его можно получить в виде статического свойства GroupStyle.Default и сослаться на него в XAML следующим образом:
    // <ListBox x:Name="pictureBox"
    // ItemsSource="{Binding Source={StaticResource photos}}" ...>
    // <ListBox.GroupStyle>
    // <x:Static Member="GroupStyle.Default"/>
    // </ListBox.GroupStyle>
    // ...
    // </ListBox>
    // Для этого конструктор принимает конвертер значений.
    // Стало быть, можно написать класс DateTimeToDateConverter, который преобразует значение DateTime в строку, больше подходящую для группировки.
    // СОВЕТ
    // Возможно, вам захочется реализовать группировку по нескольким свойствам. 
    // Для этого следует сконструировать объект PropertyGroupDescription, в котором имя свойства содержит null.
    // В таком случае в качестве параметра value ваш конвертер значений получит весь объект-источник (объект типа Photo в приложении Photo Gallery), а не значение одного свойства.
    
    // Фильтрация
    // Помимо свойств для поддержки сортировки и группировки в интерфейсе ICollectionView имеется свойство, позволяющее реализовать фильтрацию – избирательное исключение объектов, удовлетворяющих произвольному условию.
    // Оно называется Filter и имеет тип Predicate<Object> (иными словами, это делегат, принимающий один параметр типа Object и возвращающий булевское значение).
    // Анонимные делегаты в C# позволяют записать фильтр очень компактно.
    // Например, следующий код отфильтровывает все объекты Photo, для которых свойство DateTime описывает дату, отстоящую от текущей более  чем на 7 дней:
    // ICollectionView view = CollectionViewSource.GetDefaultView(this.FindResource("photos"));
    // view.Filter = delegate(object o)
    // {return ((o as Photo).DateTime – DateTime.Now).Days <= 7;
    // };
    // Можно записать это еще компактнее с помощью лямбда-выражения, хотя с непривычки разобраться в такой нотации сложнее:
    // Чтобы снять фильтр, достаточно присвоить свойству view.Filter значение null.
    
    // Навигация
    // В интерфейсе ICollectionView определено не только свойство CurrentItem (и соответствующее ему свойство CurrentPosition, которое возвращает индекс текущего элемента, нумеруемый с нуля), но и ряд методов для программного изменения CurrentItem.
    // В версии Photo Gallery с привязкой к данным эти методы используются для реализации обработчиков события Click от кнопок Next Photo (Следующая фотография) и Previous Photo (Предыдущая фотография).
    // СОВЕТ
    // Пути к свойствам, задаваемые в привязках Binding, поддерживают специальный синтаксис для ссылки на текущий объект коллекции – косую черту.
    // Например, следующий объект Binding привязывается к текущему объекту в предположении, что источник данных – коллекция:
    // "{Binding Path=/}"
    // А такой объект Binding – к свойству DateTime текущего объекта:
    // "{Binding Path=/DateTime}"
    // А такой объект Binding – к текущему объекту коллекции, которую возвращает свойство Photos другого источника данных, причем сам он коллекцией не является:
    // "{Binding Path=Photos/}"
    // И наконец, следующий объект Binding привязывается к свойству DateTime текущего объекта из предыдущего примера:
    // "{Binding Path=Photos/DateTime}"
    // Эта возможность весьма полезна для реализации интерфейсов вида  главный/подчиненный без написания процедурного кода.
    // ПРЕДУПРЕЖДЕНИЕ
    // В представлении по умолчанию навигация не предлагается автоматически!
    // В отличие от сортировки, группировки и фильтрации, средства навигации в представлении по умолчанию доступны, только если свойство IsSynchronizedWithCurrentItem селектора равно true.
    // В противном случае свойство SelectedItem селектора и свойство CurrentItem представления по умолчанию не синхронизированы и могут изменяться независимо друг от друга.
    // Дополнительные представления
    // Оказывается, класс CollectionViewSource умеет не только возвращать представление по умолчанию, но и конструировать новое представлениенад любым источником.
    // Чтобы создать новое представление над коллекцией photos в приложении Photo Gallery, нужно сделать следующее:
    // CollectionViewSource viewSource = new CollectionViewSource();
    // viewSource.Source = photos;
    // теперь viewSource.View указывает на реализацию интерфейса ICollectionView, отличную от подразумеваемой по умолчанию
    // Класс CollectionViewSource устроен так, что можно без труда создавать нестандартные представления декларативно
    // <Window.Resources>
    // <local:Photos x:Key="photos"/>
    // <CollectionViewSource x:Key="viewSource" Source="{StaticResource photos}"/>
    // </Window.Resources>
    // Чтобы применить нестандартное представление к свойству-приемнику, достаточно привязать его к объекту CollectionViewSource, а не к исходному объекту источнику, над которым построено представление:
    // <ListBox x:Name="pictureBox"
    // ItemsSource="{Binding Source={StaticResource photos viewSource}}" ...>
    // ...
    // </ListBox>
    // Чтобы можно было конфигурировать сортировку и группировку с помощью нестандартного представления целиком в XAML, класс CollectionViewSource предлагает собственные свойства SortDescriptions и GroupDescriptions, работающие точно так же, как их аналоги в интерфейсе ICollectionView. 
    // Класс SortDescription находится в пространстве имен .NET, которое не отображено на стандартное пространство именXML, поэтому необходима следующая директива:
    // xmlns:componentModel="clr-namespace:System.ComponentModel;assembly=WindowsBase"
    // Метод viewSource_Filter, на который ссылается XAML, можно было бы реализовать, как показано ниже; это просто по-другому записанный делегат для исключения фотографий старше семи дней:
    // void viewSource_Filter(object sender, FilterEventArgs e)
    // {
    // e.Accepted = ((e.Item as Photo).DateTime – DateTime.Now).Days <= 7;
    // }
    // СОВЕТ
    // Даже если в нескольких представлениях одной коллекции-источника нет нужды, все равно можно создать и применить нестандартное представление в виде явного объекта CollectionViewSource просто для того,чтобы сортировать и группировать без написания процедурного кода!
    // FAQ
    // Если в моем приложении есть коллекция и никто нигде не привязывается к ней напрямую (а только к CollectionViewSource), будет ли существовать представление по умолчанию?
    // Нет. Из соображений производительности представление по умолчанию создается только по запросу. 
    // ПРЕДУПРЕЖДЕНИЕ
    // В нестандартном представлении навигация работает по-другому!
    // По умолчанию изменение текущего объекта в нестандартном представлении автоматически отражается на всех привязанных к нему селекторах; чтобы отменить синхронизацию, нужно явно присвоить свойству селектора IsSynchronizedWithCurrentItem значение false.
    // То есть поведение прямо противоположно тому, что наблюдается в представлении по умолчанию!
    
    // Поставщики данных
    // Чтобы уменьшить потребность в написании своего кода, WPF предлагает два класса, в которых необходимые члены  реализованы обобщенным  – «дружественным к привязке к данным» – образом: XmlDataProvider и ObjectDataProvider.
    // СОВЕТ
    // Начиная с версии WPF 3.5 SP1 механизм привязки к данным отлично работает с технологией Language Integrated Query (LINQ).
    // Можно записать в свойство Source объекта Binding (или в свойство DataContext элемента) LINQ-запрос и использовать возвращенный результат типа IEnumerable точно так же, как и любую другую коллекцию.
    // Следовательно, наличие технологий LINQ to SQL, LINQ to XML и других, позволяющих использовать в качестве поставщиков данных классы LINQ, а не WPF, открывает альтернативную возможность для привязки к таблицам базы данных, XML-документам.
    // Класс XmlDataProvider
    // Класс XmlDataProvider дает простой способ привязаться к фрагменту XML-документа, будь то объект в памяти или файл.
    // СОВЕТ
    // Когда остров XML-данных внедряется в XAML-разметку, его корневой узел следует помечать пустым атрибутом xmlns.
    // В противном случае элементы оказываются в пространстве имен, подразумеваемом по умолчанию (в данном случае http://schemas.microsoft.com/winfx/2006/xaml/presentation), в результате чего XPath-запросы работают не так, как вы ожидаете.
    // Если XML-документ находится в отдельном файле (как оно обычно и бывает), то можно просто записать в свойство Source элемента XmlDataProvider соответствующий унифицированный идентификатор ресурса(URI), а не устанавливать свойство содержимого.
    // <XmlDataProvider x:Key="dataProvider" XPath="GameStats" Source="GameStats.xml"/>
    // КОПНЕМ ГЛУБЖЕ
    // Взаимодействие между свойствами XPath и Path
    // Свойства XPath и Path можно задавать одновременно в одной и той же привязке Binding.
    // XML-данные поставляются объектом XmlDataProvider в виде объектов, определенных в сборке System.Xml.dll (из пространства имен System.Xml), например XmlNode.
    // Это важно иметь в виду, когда вы работаете с данными из программы, и это же означает, что свойство Path объекта Binding может ссылаться на текущий экземпляр XmlNode или XmlNodeList.
    // Если требуется привязать целый фрагмент XML-данных к элементу, умеющему работать с иерархиями (TreeView или Menu) без написания кода, то следует использовать один или несколько шаблонов HierarchicalDataTemplates.
    
    // Класс ObjectDataProvider
    // ObjectDataProvider добавляет целый ряд возможностей, которых нет в случае прямой привязки к объекту.
    // Например, он позволяет:
    // - Декларативно создавать объект-источник с помощью конструктора с параметрами
    // - Осуществлять привязку к методу объекта-источника
    // - Реализовывать асинхронную привязку к данным
    // КОПНЕМ ГЛУБЖЕ
    // Асинхронная привязка к данным
    // Если привязка к данным оказывается медленной операцией, то ее следует производить асинхронно, чтобы не «подвешивать» пользовательский интерфейс.
    // WPF предлагает два независимых механизма асинхронной привязки: в классе Binding есть свойство IsAsync, а в классах XmlDataProvider и ObjectDataProvider – свойство IsAsynchronous.
    
    // Использование в XAML конструктора с параметрами
    // У большинства источников данных, с которыми вам приходилось работать, скорее всего, имеется конструктор по умолчанию.
    // Следующий XAML-код «обертывает» эту коллекцию объектом ObjectDataProvider:
    // <Window.Resources>
    // <local:Photos x:Key="photos"/>
    // <ObjectDataProvider x:Key="dataProvider"
    // ObjectInstance="{StaticResource photos}"/>
    // </Window.Resources>
    
    // Привязка к методу
    // Но давайте предположим, что в коллекции photos имеется метод GetFolderName, который возвращает строку, представляющую папку с фотографиями.
    // Превратить этот метод в источник данных можно следующим образом:
    // <ObjectDataProvider x:Key="dataProvider" ObjectType="{x:Type local:Photos}" MethodName="GetFolderName"/>
    // Чтобы привязаться к этому методу, нужно просто выполнить привязку ко всему объекту ObjectDataProvider:
    // <TextBlock Text="{Binding Source={StaticResource dataProvider}}"/>
    // КОПНЕМ ГЛУБЖЕ
    // Подавление автоматического разворачивания поставщиков данных
    // Если вы хотите осуществлять привязку непосредственно к свойствам объекта ObjectDataProvider, а не к свойствам обернутого им источника данных, то можете присвоить значение true свойству BindsDirectlyToSource объекта Binding и тем самым подавить автоматическое разворачивание.
    // Этот способ работает для любого источника, производного от класса DataSourceProvider.

    // Дополнительные вопросы

    // Настройка потока данных
    // Во всех рассмотренных до сих пор примерах привязки к данным поток обновлений направлен от источника к приемнику.
    // Но в некоторых случаях пользователь может напрямую изменить свойство-приемник, и хорошо бы, чтобы такое изменение распространялось назад к источнику.
    // Класс Binding поддерживает этот и другие режимы с помощью свойства Mode, которое может принимать следующие значения, определенные в перечислении BindingMode:
    // - OneWay – приемник обновляется при изменении источника.
    // - TwoWay – изменение в источнике или приемнике отражается на противоположной стороне.
    // - OneWayToSource – этот режим противоположен OneWay. Источник обновляется, когда изменяется приемник.
    // - OneTime – работает, как OneWay с тем отличием, что изменения источника не  отражаются на приемнике.
    // Приемник сохраняет мгновенный снимок источника в момент инициализации привязки.
    // ПРЕДУПРЕЖДЕНИЕ
    // Следите за режимом BindingMode, подразумеваемым по умолчанию!
    // Тот факт, что для разных свойств зависимости подразумеваемый по умолчанию режим BindingMode различен, может стать причиной недоразумений.
    // Например, в отличие от свойства Label.Content, привязка TextBox.Text к свойству Count коллекции приведет к ошибке, если явно не установить режим BindingMode OneWay (или OneTime), потому что свойство Count допускает только чтение, а режимы TwoWay и OneWayToSource требуют, чтобы свойство-источник можно было изменять. 
    // FAQ
    // Зачем может понадобиться привязка в режиме OneWayToSource? Получается, что на самом деле приемник должен быть источником, а источник – приемником.
    // Одна из причин заключается в том, что может быть несколько привязок, причем в одних поток данных направлен от источника к приемнику, а в других – от приемника к источнику.
    // Например, к одному и тому же источнику может быть привязано несколько приемников, из которых лишь одному разрешено обновлять источник с помощью механизма привязки к данным.
    // Режим OneWayToSource может также применяться как хитроумный способ обойти ограничение, согласно которому свойство-приемник обязано быть свойством зависимости.
    // Если требуется привязать свойство-источник, являющееся свойством зависимости, к свойству-приемнику, которое свойством зависимости не является, то режим OneWayToSource позволяет это сделать, пометив «реальный источник» как приемник, а «реальный приемник» – как источник! 
    // При использовании привязки в режимах TwoWay или OneWayToSource иногда требуется точнее указать, когда и как обновляется источник.
    // Класс Binding позволяет управлять этими аспектами поведения с помощью свойства UpdateSourceTrigger.
    // Свойство UpdateSourceTrigger может принимать следующие значения, определенные в перечислении UpdateSourceTrigger:
    // - PropertyChanged – источник обновляется при каждом изменении свойства-приемника.
    // - LostFocus – источник обновляется только после того, как элемент-приемник теряет фокус (при условии, что его значение изменилось).
    // - Explicit – источник обновляется в результате явного вызова метода BindingExpression.UpdateSource.
    // Экземпляр объекта BindingExpression можно получить, обратившись к статическому методу BindingOperations.GetBindingExpression либо к методу GetBindingExpression объекта любого класса, производного от FrameworkElement или FrameworkContentElement.
    // КОПНЕМ ГЛУБЖЕ
    // Свойства зависимости и настройки по умолчанию
    // Чтобы проверить настройку любого свойства зависимости из программы, можно вызвать его метод GetMetadata (например, TextBox.TextProperty.GetMetadata()), а затем опросить значение нужного свойства, скажем BindsTwoWayByDefault или DefaultUpdateSourceTrigger.
    // СОВЕТ
    // Хотя данные в источнике и/или приемнике при использовании привязки к данным обновляются автоматически, иногда желательно предпринять дополнительные действия в момент обновления.
    // Быть может, записать что-то в журнал или визуально подтвердить, что обновление произошло.
    // К счастью, в классах FrameworkElement и FrameworkContentElement определены события SourceUpdated и TargetUpdated, которые можно обработать.
    // Однако из соображений производительности они генерируются, только если булевскому свойству NotifyOnSourceUpdated (или NotifyOnTargetUpdated) объекта Binding присвоено значение true.
    // Добавление в привязку правил проверки
    // Допустим, вы хотите, чтобы пользователь мог вводить имя существующего JPG-файла в привязанное к данным поле TextBox.
    // Могут возникнуть две очевидные ошибки: введено имя несуществующего файла или расширение файла отлично от .jpg.
    // В этой ситуации можно действовать несколькими способами.
    // Во-первых, вы можете написать свое правило проверки, а во-вторых, – воспользоваться исключениями, которые, возможно, и так возбуждаются при попытке некорректного обновления источника.
    // СОВЕТ
    // Описанная в этом разделе техника применима только к распространению изменения от приемника к источнику.
    // Иначе говоря, она работает лишь в том случае, если свойство BindingMode равно OneWayToSource или TwoWay.

    // Написание собственного правила проверки
    // В классе Binding имеется свойство ValidationRules, в котором можно сохранить один или несколько объектов, производных от класса ValidationRule.
    // О том, что данные некорректны, мы сообщаем, присваивая значение false объекту ValidationResult; если же все правильно, то этот объект получит значение true.
    // <TextBox>
    // <TextBox.Text>
    // <Binding ...>
    // <Binding.ValidationRules>
    // <local:JpgValidationRule/>
    // </Binding.ValidationRules>
    // </Binding>
    // </TextBox.Text>
    // </TextBox>

    // Передача уже имеющейся обработки ошибок через систему проверки
    // Если какой-то из вышеупомянутых компонентов возбуждает исключение при тех же условиях, которые вы считаете ошибочными, то можно воспользоваться встроенным объектом ExceptionValidationRule. Например: 
    // <TextBox>
    // <TextBox.Text>
    // <Binding ...>
    // <Binding.ValidationRules>
    // <ExceptionValidationRule/>
    // </Binding.ValidationRules>
    // </Binding>
    // </TextBox.Text>
    // </TextBox>
    // Объект ExceptionValidationRule просто помечает данные как некорректные, если при попытке обновить свойство-источник возникло любое исключение.
    // Следовательно, этот механизм позволяет адекватно отреагировать на исключение, а не «глотать» его, оставляя следы только в отладочной трассировке.
    // WPF пришли к выводу, что этот синтаксис слишком многословный и громоздкий.
    // Поэтому в версии WPF 3.5 SP1 в класс Binding были добавлены два новых булевских свойства – ValidatesOnExceptions и ValidatesOnDataErrors, – которые позволяют добавитьв коллекцию ValidationRules те же самые правила проверки, но более лаконично. 
    // Таким образом, предыдущий XAML-код можно переписать и так:
    // <TextBox>
    // <TextBox.Text>
    // <Binding ValidatesOnExceptions="True" ValidatesOnDataErrors="True" .../>
    // </TextBox.Text>
    // </TextBox>
    // КОПНЕМ ГЛУБЖЕ
    // Существует несколько способов обработки исключений
    // Еще один способ обработки исключений, возбуждаемых при обновлении источника, заключается в том, чтобы присоединить делегат к свойству UpdateSourceExceptionFilter объекта Binding.
    // Интересно, что все же существует связь между делегатом UpdateSourceExceptionFilter и другими схемами проверки.
    // Если делегат возвращает объект ValidationError, то система будет рассматривать этот делегат как правило проверки и добавит полученный объект ValidationError в коллекцию Validation.Errors объекта-приемника, установит для свойства Validation.HasError значение true и, возможно, сгенерирует событие Validation.Error.
    // Подведем итоги: если источник данных или конвертер значений уже возбуждает исключения при обнаружении некорректных данных, то можно поступить одним из следующих способов:
    // - Воспользоваться делегатом UpdateSourceExceptionFilter для реализации собственной логики уведомления об ошибках.
    // - Установить свойство ValidatesOnExceptions или воспользоваться встроенным объектом ExceptionValidationRule, определить шаблон ErrorTemplate и/или подключить дополнительную логику, опрашивая свойство Validation.HasError либо обрабатывая событие Validation.Error (если свойство NotifyOnValidationError равно true).
    
    // Проверка для группы привязок Binding
    // Такая коллективная проверка поддерживается с помощью объекта BindingGroup.
    // Как и в случае Binding, этому объекту можно передать набор правил ValidationRule, которые должны применяться к группе привязок Binding.
    
    // Работа с несколькими источниками
    // WPF предлагает ряд интересных способов объединения нескольких источников данных.
    // В основе этого механизма лежат следующие классы:
    // - CompositeCollection
    // - MultiBinding
    // - PriorityBinding

    // Класс CompositeCollection
    // Класс CompositeCollection дает простой способ представить не связанные между собой коллекции и/или произвольные объекты в виде одной коллекции.
    // Это бывает полезно, когда нужно осуществить привязку к коллекции объектов, поступающих из нескольких источников.
    // <CompositeCollection>
    // <CollectionContainer Collection="{Binding Source={StaticResource photos}}"/>
    // <local:Photo .../>
    // <local:Photo .../>
    // </CompositeCollection>
    // составная коллекция CompositeCollection, содержащая все, что хранится в коллекции photos, и еще два объекта.

    // Класс MultiBinding
    // Класс MultiBinding позволяет агрегировать несколько объектов Binding, так что приемник будет получать единственное значение.
    // Для этого необходим конвертер значений, потому что иначе WPF не будет знать, как объединить несколько входных значений.
    // <ProgressBar ...>
    // <ProgressBar.Value>
    // <MultiBinding Converter="{StaticResource converter}">
    // <Binding Source="{StaticResource worker1}"/>
    // <Binding Source="{StaticResource worker2}"/>
    // <Binding Source="{StaticResource worker3}"/>
    // </MultiBinding>
    // </ProgressBar.Value>
    // </ProgressBar>
    // Однако конвертеры значений для MultiBinding пишутся несколько иначе, чем для Binding.
    // Они должны реализовывать интерфейс IMultiValueConverter, методы которого принимают и возвращают не одно значение, а целый массив.
    
    // СОВЕТ
    // Совместно с MultiBinding можно использовать метод StringFormat.
    // В этом случае {0} будет представлять первый объект Binding, {1} – второй и т. д.

    // Класс PriorityBinding
    // Класс PriorityBinding похож на MultiBinding тем, что инкапсулирует несколько объектов Binding.
    // Но вместо того чтобы агрегировать их, этот класс организует состязание нескольких привязок за право установить значение свойства-приемника!
    // Если привязка осуществляется к медленному источнику данных (и не в ваших силах ускорить его работу), то можно подключить более быстрые источники, которые дадут «приближенную» версию данных, пока программа ожидает поступления точной информации. 
    // <PriorityBinding>
    // <Binding Source="HighPri" Path="SlowSpeed" IsAsync="True"/>
    // <Binding Source="MediumPri" Path="MediumSpeed" IsAsync="True"/>
    // <Binding Source="LowPri" Path="FastSpeed"/>
    // </PriorityBinding>
    // СОВЕТ
    // При использовании элемента PriorityBinding для всех привязок Binding, кроме последней, необходимо присваивать свойству IsAsync значение true, чтобы они обрабатывались в фоновом режиме.
    // В противном случае наиболее приоритетная привязка будет выполняться синхронно (возможно, «подвешивая» пользовательский интерфейс), а после ее завершения результаты низкоприоритетных привязок уже не будутпредставлять никакого  интереса!
    
    // А теперь все вместе: клиент Twitter на чистом XAML
    // Отметим некоторые интересные особенности решения:
    // - Первоначально свойство Text поля ввода TextBox привязывается к свойству Source поставщика данных XmlDataProvider.
    // При этом используется подразумеваемая по умолчанию двусторонняя привязка, чтобы пользователь в любой момент мог изменить адрес источника.
    // - Чтобы привязка осуществлялась именно к полю Source поставщика данных, в объекте Binding для TextBox свойству BindsDirectlyToSource присвоено значение true.
    // В противном случае его свойство Path указывало бы на RSS-ленту, а это неправильно.
    // - В заданном для TextBox объекте Binding свойство UpdateSourceTrigger равно PropertyChanged, поэтому обновление данных будет производиться при нажатии каждой клавиши.
    // Наверное, было бы лучше задать режим UpdateSourceTrigger= Explicit и добавить кнопку Go (Перейти), чтобы источник можно было обновлять явно.
    // Но тогда потребовалось бы написать одну строчку процедурного кода, а это противоречит идее примера!
    // - Значением свойства DisplayMemberPath элемента ListBox является выражение XPath, позволяющее извлекать элемент title из каждой статьи ленты, представленной в формате XML.
    // - Совместно элементы ListBox и Frame образуют пару главный/подчиненный с общим источником данных.
    // - Можно было не использовать Frame, а отобразить исходное содержимое каждой RSS-статьи в чем-то типа TextBlock.
    // Но такую содержащую HTML-теги разметку было бы трудно читать.
    // И не существует никакого иного декларативного способа правильно визуализировать HTML, кроме как воспользоваться элементом Frame или WebBrowser с указанием URL-адреса файла (его нам любезно предоставляет элемент link, входящий в состав статьи).
    // - При выборе новой статьи в ленте (или вообще другой ленты) имеющиеся во фрейме кнопки навигации автоматически запоминают ваши действия.


    // !!!
    // - погуглить data binding.
    // - разобрать еще раз все примеры с главы.
    // - bind to a property
    // - bind to array
    // - bind to resource
    // - several selectors have 1 same item
    // - sort
    // - group
    // - filter
    // - лямбда выражение
}
