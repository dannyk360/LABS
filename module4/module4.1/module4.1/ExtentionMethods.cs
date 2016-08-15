

using System.Linq;
using System.Reflection;

namespace module4._1
{
    static class ExtentionMethods
    {


        public static void CopyTo(this object firstobj,object second)
        {
            var WriteProperties = from property in firstobj.GetType().GetProperties()
                                where property.CanWrite == true
                                select property;
            foreach (var property in WriteProperties)
            {
                second.GetType().GetProperty(property.Name).SetValue(second, property.GetValue(firstobj));
            }
        }
    }
}
