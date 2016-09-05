using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace DBAccess
{
    public class readFromXml
    {
        public static List<string> GetGroceriesFromAdb(string typeName)
        {
            XmlDocument chainDoc = new XmlDocument();

            chainDoc.Load("groceries.xml");
            var xElement = XElement.Load(new XmlNodeReader(chainDoc));

            var itemByCategories = xElement.Elements("Items");
            var itemsOfType = itemByCategories.Where((items) => (items.Attribute("name").Value == typeName)).Elements();
            return itemsOfType.Select((item) => item.Element("ItemName").Value).ToList();
        }
        
        public static List<ChainStruct> getChains()
        {
            XmlDocument chainDoc = new XmlDocument();

            chainDoc.Load("groceries.xml");
            var xElement = XElement.Load(new XmlNodeReader(chainDoc));

            var chains = xElement.Element("Chains");

            return  (from chain in chains.Elements()
                     select new ChainStruct() {id = chain.Attribute("Id").Value,name = chain.Value}).ToList();
        }


        public static Task<double> getPrice(string chainName,string itemCode)
        {
            XmlDocument branchDoc = new XmlDocument();

            branchDoc.Load(chainName+".xml");
            var xElement = XElement.Load(new XmlNodeReader(branchDoc));

            var items = xElement.Elements().Last().Elements();
            return Task.Run(() =>
            {
                var groceries = items.Where((item) => item.Element("ItemCode").Value == itemCode);
                var grocery = groceries.ElementAt(0);
                return double.Parse(grocery.Element("ItemPrice").Value);
            });
        }

        public static string getItemId(string itemName, string chainName)
        {
             XmlDocument chainDoc = new XmlDocument();

            chainDoc.Load("groceries.xml");
            var xElement = XElement.Load(new XmlNodeReader(chainDoc));

            var itemByCategories = xElement.Elements("Items");
            var chainsForItems = itemByCategories.Elements().Where((item) => item.Element("ItemName").Value == itemName);
            return chainsForItems.Elements("ItemCode").Where((item) => item.Attribute("name").Value == chainName).ElementAt(0).Value;
        }
    }
}
