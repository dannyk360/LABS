using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace Xlinq
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement xmlElement = new XElement("XMLmscorlib");
            var classesInAsm = getAllTheClasses("mscorlib");
            var tree = getTree(classesInAsm);

            xmlElement.Add(tree);
            xmlElement.Save("XMLmscorlib.xml");

            Console.WriteLine(tree.stringOfTypesWithoutProperties());
            Console.WriteLine(tree.numberOfFunctionsNotInhereated());
            Console.WriteLine(tree.numberOfProperties());
            Console.WriteLine(tree.mostCommonType());
            var Xelement = tree.SortTypesByMethods();
            new XElement("TypesSortedByMethodsXml", Xelement).Save("TypesSortedXml.xml");
            Console.WriteLine(tree.GroupByMethods());
            Console.ReadLine();
        }

        private static IEnumerable<XElement> getTree(IEnumerable<Type> classes)
        {
           
            foreach (var _class in classes)
            {
                yield return new XElement("Type", new XAttribute("FullName", _class.FullName),
                    getProperties(_class),
                    getMethods(_class));
            }
        }
        private static XElement getMethods(Type _class)
        {
            return new XElement("Methods", from methodInClass in _class.GetMethods()
                                           where methodInClass.IsPublic && methodInClass.DeclaringType == _class
                                           select new XElement("Method",new XAttribute("Name" , methodInClass.Name),
                   new XAttribute("Type", methodInClass.ReturnType),
                   getParameters(methodInClass)));
        }

        private static XElement getParameters(MethodInfo method)
        {
            return new XElement("Parameters", from Parameter in method.GetParameters()
                   select new XElement("Parameter", new XAttribute("Name", Parameter.Name),
                          new XAttribute("Type", Parameter.ParameterType)));
        }

        private static XElement getProperties(Type _class)
        {
            return new XElement("Properties", 
                from propertyOfclass in _class.GetProperties()
                where propertyOfclass.CanRead 
                select new XElement("Property",
                new XAttribute("Name",propertyOfclass.Name) ,
                new XAttribute("Type",propertyOfclass.PropertyType)));
        }

        private static IEnumerable<Type> getAllTheClasses(string asmName)
        {
            var asm = Assembly.Load(asmName);
            return     from objectInMetadata in asm.GetExportedTypes()
                       where objectInMetadata.IsClass && objectInMetadata.IsPublic
                       select objectInMetadata;

        }
    }
    static class Extentions
    {
        public static int numberOfProperties(this IEnumerable<XElement> elements)
        {
            return (elements.Select(x => x.Element("Properties").Elements().Count()).Sum());
        }
        public static string mostCommonType(this IEnumerable<XElement> elements)
        {
            return (elements.Descendants("Parameter")
                               .GroupBy(x => x.Attribute("Type"))
                               .Select(x => new { type = x.Key, cnt = x.Count() })
                               .OrderBy(x => x.cnt)
                               .Last()).type.Value;

        }
        public static int numberOfFunctionsNotInhereated(this IEnumerable<XElement> elements)
        {
            return (elements.Select(x => x.Element("Methods").Elements().Count()).Sum());
        }

        public static string stringOfTypesWithoutProperties(this IEnumerable<XElement> elements)
        {
            var strings = (from element in elements
            where element.Element("Properties").Elements().Count() == 0
            orderby element.Attribute("FullName").ToString()
            select element.Attribute("FullName").ToString());
            var str = "";
            foreach (var _string in  strings)
            {
                str += _string + ",";
            }
            str += strings.Count();
            return str;
        }
        public static IEnumerable<XElement> SortTypesByMethods(this IEnumerable<XElement> elements)
        {
            var numberOfMethodsInOrder = from e in elements
                                           orderby e.Elements("Method").Count() descending
                                           select e;

            var Xelement = from element in numberOfMethodsInOrder
                     select new XElement("Type", new XAttribute("FullName", element.FirstAttribute.Value),
                                       new XAttribute("NumberOfProperties", element.Descendants("Property").Count()),
                                       new XAttribute("NumberOfMethods", element.Descendants("Method").Count()));

            return Xelement;
        }

        public static string GroupByMethods(this IEnumerable<XElement> elements)
        {
            var groupedByMethods = elements
                .OrderBy(x => x.Attribute("FullName").ToString())
                .GroupBy(x => x.Descendants("Method").Count())
                .OrderByDescending(x => x.Descendants("Method").Count());
            string result ="";
            foreach (var group in groupedByMethods)
            {
                foreach (var element in group)
                {
                    result += "Type of the group:" + element.Attribute("FullName") + ", number of methods in the group:" + element.Descendants("Method").Count();
                    
                }
                
            }
            return result;
        }
    }
}
