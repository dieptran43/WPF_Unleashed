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
    }

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
    // 437





    // !!!
    // - погуглить data binding.
    // - разобрать еще раз все примеры с главы.
    // - bind to a property
    // - bind to array
}
