using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using System.Xml.Linq;

namespace DynamicXml
{
    class DynamicXElement : DynamicObject
    {
        private XElement _element { get; }

        private DynamicXElement(XElement el)
        {
            _element = el;
        }


        public static dynamic Create(XElement element)
        {
            return new DynamicXElement(element);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var res = _element.Element(binder.Name);
            result = new DynamicXElement(res);
            
            if (result != null)
                return true;
            return false;
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {

            if (indexes.Length != 2|| typeof(string) != indexes[0].GetType() || typeof(int) != indexes[1].GetType())
            {
                result = null;
                return false;
            }
            var collectionElements = _element.Elements((string) indexes[0]);
            var res = collectionElements.ElementAt((int)indexes[1]);
            result = new DynamicXElement(res);
            if (result == null)
                return false;
            return true;


        }

        public override string ToString()
        {
            return _element.Value.ToString();
        }
    }
}
