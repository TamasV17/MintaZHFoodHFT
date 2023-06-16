using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MintaZHFoodHFT
{
    internal class Refrigerator
    {
        [DisplayName("Márka")]
        public string Brand { get; set; }
        [DisplayName("Kapacitás")]
        public int Capacity { get; set; }
        [DisplayName("Termékek")]
        public List<Product> Products { get; set; }
        public Refrigerator()
        {
            Products = new List<Product>();
        }
        public static Refrigerator LoadFromXML(string path = "frigo.xml")
        {
            var xdoc = XDocument.Load(path);
            var result = new Refrigerator();
            result.Brand = xdoc.Root.Attribute("brand").Value;
            result.Capacity = int.Parse(xdoc.Root.Attribute("capacity").Value);
            foreach (var item in xdoc.Descendants("product"))
            {
                result.Products.Add(new Product()
                { 
                    Name = item.Value,
                    Amount = int.Parse(item.Attribute("amount").Value)
                });
            }
            return result;
        }
    }
}
