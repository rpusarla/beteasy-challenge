using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_code_challenge
{
    public class JsonData
    {
        public void ReadJson()
        {
            try
            {
                using (StreamReader r = new StreamReader(@".\FeedData\Wolferhampton_Race1.json"))
                {
                    string json = r.ReadToEnd();
                    dynamic data = JsonConvert.DeserializeObject(json);
                    dynamic markets = data.RawData.Markets;
                    JArray objCollection = new JArray();


                    foreach (var market in markets.Children())
                    {
                        foreach (var selection in market.Selections.Children())
                        {
                            objCollection.Add(selection);
                        }
                    }

                    JArray orderByPriceAscending = new JArray(objCollection.OrderBy(obj => (decimal)obj["Price"]));
                    Console.WriteLine("Horse Names ascending order by Price fetched from JSON File");
                    Console.WriteLine("============================================================");
                    foreach (var temp in orderByPriceAscending)
                    {
                        Console.WriteLine(String.Format("Horse Name: {0}",temp["Tags"]["name"]));
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("There's an unexpected error occurred: " + ex);
            }
        }
    }    
}
