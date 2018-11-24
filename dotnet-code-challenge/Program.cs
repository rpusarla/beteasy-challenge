using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;


namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var jsonData = new JsonData();
            var xmlData = new XmlData();

            jsonData.ReadJson();
            Console.WriteLine();
            Console.WriteLine();
            xmlData.ReadXml();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");

            Console.Read();
        }
               
    }
}
