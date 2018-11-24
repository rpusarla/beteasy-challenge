using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace dotnet_code_challenge
{
    public class XmlData
    {
        public void ReadXml()
        {
            try
            {
                var xml = XDocument.Load(@".\FeedData\Caulfield_Race1.xml");
                var race = xml.Elements("meeting").Elements("races").Elements("race");
                var horses = race.Elements("horses").Elements("horse");


                var orderByPriceAscending = race.Elements("prices").Elements("price").Elements("horses").Elements("horse").OrderBy(e => Convert.ToDecimal(e.Attribute("Price").Value));

                Console.WriteLine("Horse Names ascending order by Price fetched from XML File");
                Console.WriteLine("============================================================");

                foreach (var price in orderByPriceAscending)
                {
                    IEnumerable<XElement> ancestors = horses.Elements("number").Where(e => e.Value == price.Attribute("number").Value).Ancestors();

                    var getFirstElement = ancestors.First();
                                        
                    Console.WriteLine(String.Format("Horse Name: {0}", getFirstElement.Attribute("name").Value));                    

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("There's an unexpected error occurred: " + ex);
            }
        }
    }
}
