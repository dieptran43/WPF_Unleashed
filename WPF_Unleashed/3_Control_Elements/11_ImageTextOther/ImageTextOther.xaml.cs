﻿using System;
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

namespace WPF_Unleashed._3_Control_Elements._11_ImageTextOther
{
    /// <summary>
    /// Interaction logic for ImageTextOther.xaml
    /// </summary>
    public partial class ImageTextOther : Window
    {
        public ImageTextOther()
        {
            InitializeComponent();
        }
    }

    // Элемент управления Image
    // Класс System.Windows.Controls.Image позволяет включать в пользовательский интерфейс изображения (в формате BMP, PNG, GIF, JPG и др.). В нем имеется свойство Source типа System.Windows.Media.ImageSource, но благодаря конвертеру типа System.Windows.Media.ImageSourceConverter его можно задавать в XAML в виде простой строки, например:
    // <Image Source="zoom.gif"/>
    // Свойство ImageSource может указывать на изображения, представленные URL- адресом, хранящиеся в файловой системе и даже внедренные в сборку.
    // В классе Image определены те же самые свойства Stretch и StretchDirection – они позволяют управлять масштабированием.
    // К элементу Image можно присоединить свойство RenderOptions.BitmapScalingMode, задающее компромисс между скоростью и качеством визуализации. Из всех принимаемых им значений наиболее важным является NearestNeighbor – это режим масштабирования растрового изображения по ближайшей соседней точке, при котором изображение становится более четким.
    // <Image RenderOptions.BitmapScalingMode="NearestNeighbor" Source="zoom.gif"/>
    // СОВЕТ
    // Вместо того чтобы пользоваться конвертером типа для преобразования строкового имени файла в объект ImageSource, можно явно присвоить свойству Source объекта Image ссылку на объект одного из подклассов ImageSource, что открывает дополнительные возможности. Например, в подклассе BitmapImage есть ряд свойств, таких как DecodePixelWidth и DecodePixelHeight, с помощью которых можно задать размер изображения, меньший естественного, и тем самым сэкономить память – иногда довольно ощутимо. Подкласс FormatConvertedBitmap позволяет изменять формат пикселов Image, создавая различные эффекты, например переход к полутоновому изображению.
    // <StackPanel Orientation="Horizontal">
    // <!-- Нормальное изображение, формат пикселов Pbgra32: -->
    // <Image Source="photo.jpg" />
    // <!-- Полутоновое изображение:
    // -->
    // <Image>
    // <Image.Source>
    // <FormatConvertedBitmap Source="photo.jpg" DestinationFormat="Gray32Float" />
    // </Image.Source>
    // </Image>
    // <!-- Черно-белое изображение:
    // -->
    // <Image>
    //    <Image.Source>
    // <FormatConvertedBitmap Source="photo.jpg" DestinationFormat="BlackWhite" />
    // </Image.Source>
    // </Image>
    // </StackPanel>
    // Длинный перечень возможных форматов определен в перечислении System.Windows.Media.PixelFormats.
    
    // Элементы управления Text и Ink
    // Помимо элементов TextBlock и Label WPF содержит еще ряд элементов для отображения и редактирования текста – посредством как клавиатурного набора, так и рукописного ввода с помощью стилуса. В этом разделе мы чуть подробнее рассмотрим элемент TextBlock, а также поговорим о следующих элементах:
    // - TextBox
    // - RichTextBox
    // - PasswordBox
    // - InkCanvas
    // Главное, о чем нужно знать, – это присоединенное свойство TextOptions.TextFormattingMode. Его можно задавать как для отдельных текстовых элементов, так и – что практикуется чаще – для родительского элемента, например Window; в последнем случае оно распространяется на визуализацию текста во всем дереве элементов-потомков. Присвоив свойству TextFormattingMode значение Display, вы включите новый механизм визуализации текста в WPF 4, в котором применяются метрики текста, совместимые с GDI. С точки зрения четкости текста основная особенность этого механизма состоит в том, что каждый глиф позиционируется на границе пикселов (а его ширина кратна ширине пиксела). 
    // Присоединенному свойству TextOptions.TextRenderingMode можно присвоить значение ClearType, Grayscale, Aliased или Auto – для управления режимом сглаживания текста (antialiasing). При заданном значении Auto (по умолчанию) будет действовать режим ClearType, если эта технология не отключена на данном компьютере, в противном случае – режим Grayscale.
    // Далее свойству TextOptions.TextHintingMode можно присвоить значение Fixed, Animated или Auto – для оптимизации отображения в зависимости от того, является текст стационарным или анимированным.
    // Не следует ли всегда задавать значение Display свойства TextFormattingMode, чтобы оптимизировать визуализацию текста?
    // Нет. Если текст отображается достаточно крупным кеглем (FontSize порядка 15 или больше), то режим Ideal дает такое же четкое изображение, как режим Display, а глифы располагаются лучше. Но еще важнее то, что в случае применения к тексту геометрического преобразования режим Display оказывается хуже, поскольку выравнивание на границы пикселов больше не применяется. 
    // Но для типичных меток, отображаемых мелким шрифтом, у режима Display нет конкурентов.

    // Элемент TextBlock
    // У элемента TextBlock есть ряд простых свойств, модифицирующих его внешний вид, например FontFamily, FontSize, FontStyle, FontWeight и FontStretch. Но главный сорприз TextBlock заключается в том, что его свойством содержимого является не Text, а коллекция объектов Inlines. Хотя показанная ниже разметка дает тот же самый результат, что и установка свойства Text, в действительности мы устанавливаем другое свойство:
    // <!-- Здесь устанавливается свойство TextBlock.Inlines: -->
    // <TextBlock>Text in a TextBlock</TextBlock>
    // эквивалентно
    // <TextBlock><Run Text="Text in a TextBlock"/></TextBlock>
    // эквивалентно 
    // <TextBlock><Run>Text in a TextBlock</Run></TextBlock>
    // Однако в классе Run имеется несколько свойств форматирования, позволяющих переопределить соответствующие свойства, установленные в родительском элементе TextBlock, а именно: FontFamily, FontSize, FontStretch, FontStyle, FontWeight, Foreground и TextDecorations. 
    // TextBlock и пустое пространство
    // Если содержимое TextBlock устанавливается с помощью свойства Text, то все символы пробела сохраняются. Если же оно устанавливается с помощью свойства Inlines в XAML, то пустое пространство не сохраняется. Начальные и конечные пробелы при этом игнорируются, а соседние пробелы заменяются одним 
    // СОВЕТ
    // При добавлении содержимого в свойство Inlines элемента TextBlock его неформатированное представление дописывается в конец свойства Text. Поэтому программа по-прежнему может пользоваться свойством Text, даже если явно устанавливается только Inlines.
    // Явно и неявно заданные фрагменты Run
    // <TextBlock>Text in<LineBreak/>a TextBlock</TextBlock>
    // эквивалентно
    // <TextBlock><Run>Text in</Run><LineBreak/><Run>a TextBlock</Run></TextBlock>

    // Элемент TextBox
    // В отличие от большинства других элементов управления в WPF, содержимое TextBox хранится не в виде объекта типа System.Object, а в строковом свойстве Text.
    // Хотя на первый взгляд TextBox выглядит очень просто, в него встроена весьма развитая функциональность, привязки для команд Cut, Copy, Paste, Undo и Redo и даже проверка правописания!
    // В классе TextBox определено несколько методов и свойств для выбора различных частей текста (выделенного фрагмента, по номеру строку и т. д.), а также методы для поиска физической точки в тексте по номеру строки и символа и наоборот. Определены также события TextChanged и SelectionChanged. 
    // Если на размер элемента TextBox не налагает ограничений окружение (и он не задан явно), то элемент растет по мере добавления в него текста. Если же ширина TextBox ограничена, то можно установить режим переноса строк, присвоив свойству TextWrapping значение Wrap или WrapWithOverflow. В режиме Wrap содержимое ни при каких условиях не может выйти за пределы области, занятой элементом, даже если придется разорвать строку в середине слова. В режиме WrapWithOverflow строка разрывается, только если есть такая возможность, так что длинные слова могут выйти за границы области.
    // Как сделать, чтобы элемент TextBox поддерживал ввод нескольких строк текста?
    // Если присвоить свойству AcceptsReturn значение true, то при нажатии клавиши Enter будет создаваться новая строка. Отметим, что TextBox в любом случае поддерживает создание многострочных текстов из программы. Если записать в свойство Text текст, содержащий символы NewLine, то он отобразится в виде нескольких строк вне зависимости от значения AcceptsReturn.
    // Проверка правописания
    // Чтобы включить проверку правописания в TextBox (или RichTextBox), необходимо присвоить присоединенному свойству SpellCheck.IsEnabled значение true.
    
    // Элемент RichTextBox
    // Элемент RichTextBox предоставляет больше возможностей, чем TextBox, поскольку может содержать форматированный текст
    // У RichTextBox и TextBox общий базовый класс (TextBoxBase), поэтому многие возможности, описанные выше для TextBox, применимы и к RichTextBox. Но некоторые средства TextBox реализованы в RichTextBox более полно. Там, где TextBox предоставляет лишь простые целочисленные свойства CaretIndex, SelectionStart и SelectionEnd, RichTextBox предлагает свойство CaretPosition типа TextPointer и свойство Selection типа TextSelection. Кроме того, содержимое RichTextBox хранится в свойстве Document типа FlowDocument, а не в простом строковом свойстве Text. Содержимое может даже включать объекты типа UIElement, с которыми можно взаимодействовать и которые генерируют события, если свойство IsDocumentEnabled элемента RichTextBox имеет значение true.
    
    // Элемент PasswordBox
    // Элемент PasswordBox – это упрощенный вариант TextBox, предназначенный для ввода пароля. Вместо вводимых символов в нем отображаются кружочки.
    // Если вам не нравятся кружочки, можете выбрать другой символ с помощью свойства PasswordChar.
    // Текст элемента PasswordBox хранится в строковом свойстве Password. В действительности для более надежной защиты применяется специальный класс System.Security.SecureString. Содержимое объекта типа SecureString шифруется и намеренно стирается, тогда как объекты System.String не шифруются и могут оставаться в куче неопределенно долгое время, пока не будут убраны сборщиком мусора.
    // При изменении пароля генерируется событие TextboxPasswordChanged. Его обработчик имеет тип RoutedEventHandler, то есть вместе с событием не передается информация о старом и новом паролях. Если нужно узнать текущий пароль, можно просто опросить внутри обработчика свойство Password. 

    // Элемент InkCanvas
    // Основная задача поразительно гибкого элемента InkCanvas – предоставить средства для рукописного ввода
    // В режиме по умолчанию InkCanvas позволяет просто писать или рисовать на своей поверхности. При работе со стилусом заостренный конец рисует, а обратный конец стирает. Каждый нанесенный штрих запоминается в виде объекта System.Windows.Ink.Stroke, а все такие объекты сохраняются в коллекции Strokes. Но InkCanvas позволяет также хранить любое число произвольных объектов типа UIElement в коллекции Children (это его свойство содержимого).
    // 



    // !!!


}
