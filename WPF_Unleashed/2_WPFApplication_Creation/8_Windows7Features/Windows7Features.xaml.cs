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
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace WPF_Unleashed._2_WPFApplication_Creation._8_Windows7Features
{
    /// <summary>
    /// Interaction logic for Windows7Features.xaml
    /// </summary>
    public partial class Windows7Features : Window
    {
        public Windows7Features()
        {
            InitializeComponent();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            // Это нельзя делать до возникновения события Sourcelnitialized:
            GlassHelper.ExtendGlassFrame(this, new Thickness(-1));
            // Присоединяем оконную процедуру, чтобы впоследствии
            // можно было понять, включен ли режим композиции рабочего стола
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            HwndSource.FromHwnd(hwnd).AddHook(new HwndSourceHook(WndProc));
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool
        handled)
        {
            if (msg == WM_DWMCOMPOSITIONCHANGED)
            {
                // Повторно включаем эффект стекла:
                GlassHelper.ExtendGlassFrame(this, new Thickness(-1));
                handled = true;
            }
            return IntPtr.Zero;
        }

        private const int WM_DWMCOMPOSITIONCHANGED = 0x031E;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MARGINS
    {
        public MARGINS(Thickness t)
        {
            Left = (int)t.Left;
            Right = (int)t.Right;
            Top = (int)t.Top;
            Bottom = (int)t.Bottom;
        }
        public int Left;
        public int Right;
        public int Top;
        public int Bottom;
    }

    public class GlassHelper
    {
        [DllImport("dwmapi.dll", PreserveSig = false)]
        static extern void DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [DllImport("dwmapi.dll", PreserveSig = false)]
        static extern bool DwmIsCompositionEnabled();

        public static bool ExtendGlassFrame(Window window, Thickness margin)
        {
            if (!DwmIsCompositionEnabled())
                return false;
            IntPtr hwnd = new WindowInteropHelper(window).Handle;
            if (hwnd == IntPtr.Zero)
                throw new InvalidOperationException(
                "The Window must be shown before extending glass.");
            // Устанавливаем прозрачный фон - как с точки зрения WPF, так и в Win32
            window.Background = Brushes.Transparent;
            HwndSource.FromHwnd(hwnd).CompositionTarget.BackgroundColor =
            Colors.Transparent;
            MARGINS margins = new MARGINS(margin);
            DwmExtendFrameIntoClientArea(hwnd, ref margins);
            return true;
        }
    }

    // Списки переходов
    // В WPF 4 имеется класс System.Windows.Shell.JumpList, который позволяет определить собственный список переходов для приложения с помощью несложного управляемого кода или даже целиком в XAML!
    
    // Элемент JumpTask
    // Поскольку никаких других свойств не задано, первый элемент Jump.Task просто перезапускает приложение Photo Gallery. Это дублирует действие стандартного элемента, расположенного в конце списка переходов, и в реальном приложении не имеет смысла. Но вот следующие два элемента JumpTask передают новому экземпляру Photo Gallery дополнительные аргументы командной строки, инструктируя приложение о необходимости предпринять какие-то другие действия. Photo Gallery может прочитать эти аргументы из свойства Environment.CommandLine и отреагировать соответствующим образом.
    // Совет
    // С точки зрения пользователя, типичная задача в списке переходов не запускает новый экземпляр программы, а приводит к выполнению каких-то действий в уже запущенном экземпляре. Чтобы добиться подобного поведения, можно написать приложение так, чтобы у него всегда было не более одного работающего экземпляра (эта тема обсуждалась в предыдущей главе), и передать этому экземпляру информацию, указанную в командной строке.
    // Если у приложения имеется нестандартный список переходов, то его элементы появляются также в меню Пуск, когда данное приложение становится текущим. На рис. 8.4 показано, как список переходов, автоматически добавляется в меню Пуск.
    // ПРЕДУПРЕЖДЕНИЕ
    // Отладчик Visual Studio взаимодействует со списками переходов!
    // При запуске под отладчиком в Visual Studio приложение представляется в виде файла vshost32.exe, как показано на рис. 8.5. Свой список переходов вы видите, но значки могут выглядеть иначе, а щелчок по ним не работает (потому что приводит к запуску vshost32.exe, а не вашей программы). Еще хуже обстоит дело с элементами JumpPath, описанными в следующем разделе, — они не появляются вовсе. Чтобы обойти эту проблему, можно сбросить флажок Enable the Visual Studio hosting process (Включить ведущий процесс Visual Studio) в разделе Debug (Отладка) на странице свойств проекта.
    // ПРЕДУПРЕЖДЕНИЕ
    // Списки переходов разделяются всеми экземплярами приложения!
    // Списки переходов ассоциированы с приложением, а не с его конкретным окном или работающим экземпляром. Все элементы, помещенные в список переходов, сохраняются, даже когда приложение не работает. Если будет запущен второй экземпляр приложения, который включит в список переходов другие элементы, то они заменят элементы, ранее помещенные первым экземпляром.
    
    // Настройка поведения JumpTask
    // У элемента JumpTask имеется ряд свойств для установки значков и запуска приложений, отличных от определенных владельцем списка.
    // СОВЕТ
    // В файлах %WINDIR%\System32\shell32.dll и %WINDIR%\System32\imageres.dll имеется много готовых значков, которые вполне можно использовать в элементах JumpTask. Не гарантируется, что во всех версиях они одинаковы, но польза все равно есть.
    // СОВЕТ
    // Если вы не хотите показывать значок рядом с именем элемента JuшpTask в списке переходов, присвойте свойству IconResourcelndex значение -1. Этот способ работает вне зависимости от того, задано свойство IconResourcePath или нет.
    // СОВЕТ
    // Чтобы поставить между элементами JumpTask горизонтальную линию, достаточно добавить в нужное место элемент JumpTask, не задавая для него никаких свойств.

    // Нестандартные категории
    // ПРЕДУПРЕЖДЕНИЕ
    // Закрепление JumpTask не работает, если не задано свойство Arguments!
    // Из-за ошибки в Windows 7 задачи без аргументов закрепить невозможно. Кнопка закрепления присутствует, но при ее нажатии ничего не происходит. К счастыо, у большинства задач есть хотя бы один аргумент. Если необходимо запустить программу, которой аргументы не нужны, а фиктивный аргумент передать невозможно, то можно написать промежуточную программу запуска, которая принимает и игнорирует аргумент.
    // ПРЕДУПРЕЖДЕНИЕ
    // Нестандартные категории отображаются в порядке снизу вверх!
    // И элементы JumpTask, и нестандартные категории отображаются в том порядке, в котором они хранятся в коллекции JumpItems. Но если список JumpTask растет сверху вниз, то список категорий - снизу вверх! Именно поэтому категория Two на рис. 8.8 и 8.9 находится над категорией One.

    // Элемент JumpPath
    // Если элемент JumpTask представляет программу, то JumpPath представляет файл, который открывается приложением-владельцем списка. В действитедаиости приложение может использовать элементы JumpPath, только если оно зарегистрировано в Windows для обработки файлов с соответствующим расширением.
    // <Application x:Class="PhotoGallery.App"
    // xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    // xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    //     StartupUri="MainWindow.xaml">
    // <JumpList.JumpList>
    // <JumpList>
    // <JumpPath Path="C:\Users\Adam\Pictures\DSC06397.jpg"
    // CustomCategory="Photos"/>
    // <JumpTask Title="Magnifier" CustomCategory="One"
    // Description="Open the Windows Magnifier."
    // ApplicationPath="%WINDIR%\system32\magnify.exe"/>
    // …
    // </JumpList>
    // </JumpList.JumpList>
    // </Application>
    // По умолчанию элементы JumpPath помещаются в категорию Tasks, что выглядит странновато. Однако их можно поместить и в другие категории, задав свойство CustomCategory (унаследованное от JumpItem). Достоинство такого подхода в том, что каждый элемент автоматически становится доступным для закрепления.
    // ПРЕДУПРЕЖДЕНИЕ
    // В свойстве Path элемента JumpPath не поддерживаются переменные окружения! Именно поэтому в листинге 8.4 путь к JPG-файлу зашит жестко. На практике, однако, это не должно составлять серьезную проблему. Обычно приложения добавляют пути динамически в процедурном коде, а в этом случае логика формирования пути может быть произвольной (в том числе с применением переменных окружения).

    // Недавние и часто посещаемые пути JumpPath
    // Чтобы та или другая категория появилась в списке переходов, достаточно установить для свойства ShowRecentCategory и/или ShowFrequentCategory элемента JumpList значение true. Тогда соответствующая категория появится и будет заполняться автоматически.
    // Если вы хотите принудительно поместить элемент в какой-либо из этих списков (например, потому, что приложение открывает файлы в обход вышеупомянутых механизмов), то можете вызвать метод JumpList.AddToRecentCategory. У него есть перегруженные варианты, принимающие путь в виде строки, объекта JumpPath и даже объекта JumpTask. Не существует метода AddToFrequentCategory; для того чтобы файл появился в списке часто посещаемых, необходимо достаточно много раз поместить его в категорию недавних.
    // 
    // <JumpList ShowFrequentCategory="True" ShowRecentCategory="True">
    // <JumpPath Path="C:\Users\Adam\Pictures\DSC06397.jpg"
    // CustomCategory="Photos"/>
    // <JumpTask Title="Magnifier" CustomCategory="One"
    // Description="Open the Windows Magnifier."
    // ApplicationPath="%WINDIR%\system32\magnify.exe"/>
    // …
    // </JumpList>

    // Реакция на отказ от добавления или на удаление элемента из списка переходов
    // Если приложение не зарегистрировано как обработчик файлов определенного типа или файл не существует, то Windows отказывается добавлять путь JumpPath в коллекцию JumpItems списка переходов, а может и удалить уже присутствующий в списке путь. Чтобы предотвратить такое автоматическое удаление, следует обработать событие JumpItemsRejected объекте JumpList.
    // Объект типа JumpItemsRejectedEventArgs, передаваемый обработчику события содержит список всех отвергнутых элементов Jumpltem, а также список значений перечисления JumpItemRejectionReason, а именно:
    // - NoRegisteredHandler - приложение не зарегистрировано как обработчик файлов данного типа.
    // - InvalidItem - файл не существует (при работе в версии Windows, предшест-вующей Windows 7).
    // - RemovedByUser - элемент удален пользователем.
    // - None - причина отказа неизвестна.
    // КОПНЕМ ГЛУБЖЕ
    // О моменте возникновения событий JumpItemsRejected и JumpItemsRemovedByUser

    // Настройка элементов на панели задач
    // Начиная с версии WPF 4 в классе Window имеется свойство TaskbarItemInfo (типа System.Windows.Shell.TaskbarItemInfо), которое позволяет настраивать значок приложения на панели задач или его эскиз.
    // <Window …>
    // <Window.TaskbarItemInfo>
    // <TaskbarItemInfo Description="Custom tooltip"/>
    // </Window.TaskbarItemInfo>
    // …
    // </Window>
    // Или в программе на С#:
    // public MainWindow()
    // {
    // …
    // this.TaskbarItemInfo = new TaskbarItemInfo();
    // this.TaskbarItemInfo.Description = ‚Custom tooltip‛;
    // }

    // Индикатор выполнения для элемента на панели задач
    // Элементы на панели задач поддерживают встроенный индикатор выполнения. Он бывает полезен, когда нужно отобразить состояние долго работающей задачи, не отвлекая внимание пользователя. Эта возможность используется и в Проводнике Windows, и в Internet Explorer. Очень удобно - работаешь в одной программе и время от времени поглядываешь, что делается в другой.
    // Чтобы показать индикатор выполнения, достаточно задать два свойства объекта TaskbarItemInfo: ProgressValue и ProgressState. ProgressValue может принимать значение типа double от 0 (0%) до 1 (100%), показывающее процент заполненности полосы индикатора. ProgressState может принимать следующие значения, принадлежащие перечислению TaskbarItemProgressState:
    // - Normal - показывать зеленый индикатор.
    // - Paused - показывать желтый индикатор.
    // - Error - показывать красный индикатор.
    // - Indeterminate - показывать зеленый анимированный индикатор, а не стандартную частично заполненную полосу, отражающую значение ProgressValue.
    // - None - не показывать индикатор. Это значение по умолчанию.
    
    // Наложения для элементов на панели задач
    // В классе TaskbarItemInfo эта возможность реализуется с помощью свойства Overlay типа ImageSource.
    // <Window …>
    // <Window.TaskbarItemInfo>
    // <TaskbarItemInfo Overlay="overlay.png"/>
    // </Window.TaskbarItemInfo>
    // …
    // </Window>
    // Если установлен режим показа мелких значков на панели задач, то наложение не поддерживается, то есть установка этого свойства ничего не дает. Кроме того, попытка воспользоваться любой функциональностью класса TaskbarItemInfo ни к чему не приводит, если приложение работает в версии Windows, предшествующей Windows 7.
    // СОВЕТ
    // При смене изображений в свойстве Overlay эффект плавного затухания не используется. Поэтому быстрое изменение значения этого свойства может создать эффект анимации!

    // Настройка содержимого эскиза
    // По умолчанию эскиз, отображаемый при задержке указателя мыши над элементом на панели задачи, - это просто уменьшенное изображение текущего окна приложения. Класс Taskbarltemlnfo позволяет чуть изменить это поведение. Установив свойство ThumbnailClipMargin (типа Thickness), можно обрезать эскиз по умолчанию.

    // Добавление кнопок управления к эскизу на панели задач
    // И последнее, что позволяет сделать класс TaskbarItemInfo, - поместить под эскизом кнопки, имитирующие интерфейс Windows Media Player: Воспроизведение/Пауза, Предыдущая, Следующая. Для этой цели предназначено свойство ThumbButtonInfos - коллекция объектов типа ThumbButtonInfo.
    // Хотя ThumbButtonInfo не наследует классу WPF UIElement, он обладает основными свойствами, ожидаемыми от кнопки. Единственное ограничение состоит в том, что содержимое может быть только объектом типа ImageSource. В классе ThumbButtonInfo имеется свойство ImageSource, определяющее содержимое, свойство Description, задающее всплывающую подсказку, и событие Click. (Однако, в отличие от класса Button, событие Click не маршрутизируется.)
    // В классе ThumbButtonInfo есть также стандартное свойство Visibility, способное принимать любое из трех обычных значений. (Приятная неожиданность, если учесть, что компоновка WPF здесь не применяется.) И ряд булевских свойств: IsEnabled, IsInteractive, IsBackgroundVisible и DismissWhenClicked; все они, кроме последнего, по умолчанию равны true. Под «фоном* (background), упоминаемым в названии свойства IsBackgroundVisible, понимается обрамление кнопки, никакого настраиваемого фона у этих кнопок не существует.
    // <Window …>
    // <Window.TaskbarItemInfo>
    // <TaskbarItemInfo>
    // <TaskbarItemInfo.ThumbButtonInfos>
    // <ThumbButtonInfo Description="Previous" Click="…"
    // ImageSource="Images\previousSmall.gif"/>
    // <ThumbButtonInfo Description="Slideshow" Click="…"
    // ImageSource="Images\slideshowSmall.gif"/>
    // <ThumbButtonInfo Description="Next" Click="…"
    // ImageSource="Images\nextSmall.gif"/>
    // <ThumbButtonInfo Description="Undo" Click="…"
    // ImageSource="Images\counterclockwiseSmall.gif"/>
    // <ThumbButtonInfo Description="Redo" Click="…"
    // ImageSource="Images\clockwiseSmall.gif"/>
    // <ThumbButtonInfo Description="Delete" Click="…"
    // ImageSource="Images\deleteSmall.gif"/>
    // </TaskbarItemInfo.ThumbButtonInfos>
    // </TaskbarItemInfo>
    // </Window.TaskbarItemInfo>
    // …
    // </Window>
    // ПРЕДУПРЕЖДЕНИЕ
    // Во внимание принимаются лишь первые семь элементов ThumbButtonlnfo! Поскольку в окне эскиза есть место только для семи кнопок управления, все последующие элементы коллекции ThumbButtonInfos игнорируются. Но тут есть тонкий момент - дополнительные кнопки игнорируются даже в случае, когда для некоторых из первых семи свойство Visibility равно Collapsed (то есть теоретически есть место для других кнопок). Поэтому» если вы хотите динамически изменять состав кнопок, общее число которых превышает семь, то должны будете добавлять и удалять элементы коллекции, а не просто манипулировать свойством Visibility.
    // FAQ
    // Как настроить изменение цвета элемента на панели задач при наведении указателя мыши?
    // Единственный способ — изменить цвета самого значка. Windows выбирает доминирующий цвет для значка и на его основе определяет цвет подсветки.

    // Функция Aero Glass
    // Aero Glass - это размытое, прозрачное обрамление окна, которое можно распространить на клиентскую область. Впервые эта функция появилась в Windows Vista. Чтобы воспользоваться ею в WPF-приложении, проще всего вызывать функцию DwmExtendFrameIntoClientArea из Win32 API.
    // В программе на Visual C++ вызвать функцию DwmExtendFramelntoClientArea можно непосредственно. Но в языках типа C# или Visual Basic необходимо использовать технологию PInvoke (конкретно - задать атрибут DllImport). PInvoke - ключ к вызову из C# любой функции API из группы Desktop Window Manager. В листинге 8.5 приведены сигнатуры PInvoke и простой служебный метод, обертывающий обращения к PInvoke.

    // Функция TaskDialog
    // Часто у разработчика возникает искушение использовать MessageBox там, где уместнее выглядело бы нестандартное диалоговое окно. Но человеку свойственно лениться, поэтому в Windows Vista появился новый, улучшенный вариант класса MessageBox - TaskDialog, - который обладает большей гибкостью.
    // Чтобы воспользоваться этой функциональностью, следует вызвать функцию TaskDialog из Win32 API. Как и при работе с Aero Glass, ключом к вызову этой функции является технология PInvoke.
    // ПРЕДУПРЕЖДЕНИЕ
    // Для работы с TaskDialog необходима версия 6 библиотеки Windows Common Controls DLL (ComCtl32.dll)!
    // СОВЕТ
    // Для проведения глубокой настройки TaskDialog можно также воспользоваться более сложной функцией TaskDialogIndirect.

    // Резюме
    // Мы не будем пытаться поведать обо всех хитростях интероперабельности с неуправляемым кодом, необходимых для доступа к некоторым из этих средств, а вместо этого порекомендуем загрузить пакет Windows API Code Pack с сайта http://code.msdn.microsoft.com/WindowsAPICodePack.
    // СОВЕТ
    // Даже если вы пока не готовы к переносу своего приложения на WPF 4, то все равно можете воспользоваться описанными в этой главе функциями Windows 7, прибегнув к помощи библиотеки WPF Shell Integration Library, которая находится по адресу http://code.msdn.microsoft.com/WPFShell.
    // СОВЕТ
    // Планируя воспользоваться средствами, имеющимися в конкретной версии Windows, всегда нужно думать о том, что делать, если программа будет запущена в более ранней версии (если, конечно, вы собираетесь эти более ранние версии поддерживать).
    // В части списков переходов и средств работы с панелью задач в пространстве имен System.Windows.Shell WPF сама заботится о поддержке более старых версий Windows. Если запустить рассмотренные в этой главе примеры в Windows Vista, то код, работающий с классами JumpList, TaskbarItemInfo и пр., будет выполняться без ошибок, но и без видимого эффекта.
    // Что же касается прямых обращений к неуправляемым функциям через PInvoke, то вы должны явно проверять версию Windows и соответственно адаптировать поведение программы. В .NET для проверки версии операционной системы можно использовать свойство System.Environment.OSVersion. Например:
    // if (System.Environment.OSVersion.Version.Major >= 6)
    // // Windows Vista или более поздняя, используем TaskDialog
    // else
    // // Младше Windows Vista, используем MessageBox


    // !!!
}
