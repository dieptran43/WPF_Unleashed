using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace WPF_Unleashed._1_Basic_Information._2_XAML
{
    class Testing
    {

    }

    // Аттрибуты
    [System.Serializable]
    public class SampleClass
    {
        // Objects of this type can be serialized.

        // Объявление метода с атрибутом DllImportAttribute выглядит следующим образом.
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        extern static void SampleMethod();

        void MethodA([In][Out] ref double x) { }
        void MethodB([Out][In] ref double x) { }
        void MethodC([In, Out] ref double x) { }

        // Для заданной сущности некоторые атрибуты можно указать несколько раз.Примером такого многократно используемого атрибута является ConditionalAttribute.
        // [Conditional("DEBUG"), Conditional("TEST1")]
        void TraceMethod()
        {
            // ...
        }
    }

    // Parial

    public partial class Employee
    {
        public void DoWork()
        {
        }
    }

    public partial class Employee
    {
        public void GoToLunch()
        {
        }
    }

    class Container
    {
        partial class Nested
        {
            void Test() { }
        }
        partial class Nested
        {
            void Test2() { }
        }
    }

    [SerializableAttribute]
    partial class Moon { }

    [ObsoleteAttribute]
    partial class Moon { }

    // Универсальные классы
    class BaseNode { }
    class BaseNodeGeneric<T> { }

    // concrete type
    class NodeConcrete<T> : BaseNode { }

    //closed constructed type
    class NodeClosed<T> : BaseNodeGeneric<int> { }

    //open constructed type 
    class NodeOpen<T> : BaseNodeGeneric<T> { }
}
