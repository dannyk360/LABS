using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    class Program
    {
        public static void InvokeHello(object ob,string str)
        {
            var result = ob.GetType().GetMethod("Hello").Invoke(ob, new object[] {str});
            Console.WriteLine(result);
        }

        static void Main(string[] args)
        {
            A AClass = new A();
            B BClass = new B();
            C CClass = new C();
            InvokeHello(AClass, "A class here");
            InvokeHello(BClass, "B class here");
            InvokeHello(CClass, "C class here");
            Console.ReadLine();
        }
    }
}
