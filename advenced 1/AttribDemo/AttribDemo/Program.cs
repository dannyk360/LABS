using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    class Program
    {
        public static bool AnalayzeAssembly(Assembly assemblyObject)
        {
            var assemblyObjects = assemblyObject.GetTypes();
            bool flag= true;
            foreach (dynamic assembly in assemblyObjects)
            {
                var attr = assembly.GetCustomAttributes(typeof(CodeReviewAttribute), false);
                foreach (CodeReviewAttribute cra in attr)
                {
                    Console.WriteLine("name : " + cra.reviewerName + " date:" +cra.reviewDate + " approved:" + cra.codeApproved);
                    if (cra.codeApproved == false)
                        flag = false;
                }

            }
            
            return flag;
        }

        static void Main(string[] args)
        {

            Console.WriteLine(AnalayzeAssembly(Assembly.GetExecutingAssembly()));
            Console.ReadLine();

        }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false,AllowMultiple = true)]

    class CodeReviewAttribute : Attribute
    {
        public CodeReviewAttribute(string Name, string Date, bool approval)
        {
            reviewerName = Name;
            reviewDate = Date;
            codeApproved = approval;
        }

        public string reviewerName { get; set; }
        public string reviewDate { get; set; }
        public bool codeApproved { get; set; }
    }
}
