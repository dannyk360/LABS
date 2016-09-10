using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DBA
{
    public class ReadFromXml
    {
        public static List<string> GetGroceriesFromAdb(string typeName)
        {
            var chainDoc = new XmlDocument();

            chainDoc.Load("groceries.xml");
            var xElement = XElement.Load(new XmlNodeReader(chainDoc));

            var itemByCategories = xElement.Elements("Items");

            var itemsOfType = itemByCategories.Where(items =>
            {
                var xAttribute = items.Attribute("name");
                return (xAttribute != null) && (xAttribute.Value == typeName);
            }).Elements();

            return itemsOfType.Select(item =>
            {
                var element = item.Element("ItemName");
                if (element != null) return element.Value;
                return null;
            }).ToList();
        }

        public static List<ChainStruct> GetChains()
        {
            var chainDoc = new XmlDocument();

            chainDoc.Load("groceries.xml");
            var xElement = XElement.Load(new XmlNodeReader(chainDoc));

            var chains = xElement.Element("Chains");

            if (chains != null)
                return (from chain in chains.Elements()
                    let xAttribute = chain.Attribute("Id")
                    where xAttribute != null
                    select new ChainStruct {Id = xAttribute.Value, Name = chain.Value}).ToList();
            return null;
        }


        public static Task<double> GetPrice(string chainName, string itemCode)
        {
            var branchDoc = new XmlDocument();

            branchDoc.Load(chainName + ".xml");
            var xElement = XElement.Load(new XmlNodeReader(branchDoc));

            var items = xElement.Elements().Last().Elements();
            return Task.Run(() =>
            {
                var groceries = items.Where(item =>
                {
                    var element = item.Element("ItemCode");
                    return (element != null) && (element.Value == itemCode);
                });

                var grocery = groceries.ElementAt(0);
                var price = grocery.Element("ItemPrice");
                double priceNumber;
                double.TryParse(price.Value, out priceNumber);
                return priceNumber;
            });
        }

        public static string GetItemId(string itemName, string chainName)
        {
            var chainDoc = new XmlDocument();

            chainDoc.Load("groceries.xml");
            var xElement = XElement.Load(new XmlNodeReader(chainDoc));

            var itemByCategories = xElement.Elements("Items");
            var chainsForItems = itemByCategories.Elements().Where(item =>
            {
                var element = item.Element("ItemName");
                return (element != null) && (element.Value == itemName);
            });

            return chainsForItems.Elements("ItemCode").Where(item =>
            {
                var xAttribute = item.Attribute("name");
                return (xAttribute != null) && (xAttribute.Value == chainName);
            }).ElementAt(0).Value;
        }

        public static string[] GetCategories()
        {
            var chainDoc = new XmlDocument();

            chainDoc.Load("groceries.xml");
            var xElement = XElement.Load(new XmlNodeReader(chainDoc));

            var categories = xElement.Elements("Items");
            return categories.Select(category =>
            {
                var xAttribute = category.Attribute("name");
                if (xAttribute != null) return xAttribute.Value;
                return null;
            }).ToArray();
        }
    }
}