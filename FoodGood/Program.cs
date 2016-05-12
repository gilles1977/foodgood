using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultra.DomainModel;
using Ultra.Services;

namespace FoodGood
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new UsdaApiClientService("eIQTHeqjEITpxwy1AcdHXijwJFRwI8WDSasId5pK", "http://api.nal.usda.gov/ndb/list");
            var query = new NutrientListQuery()
            {
                ListType = "n",
                Offset = "10",
                Max = "5"
            };
            var result = service.Retrieve(query).Result;

            Console.WriteLine(result);

            Console.WriteLine("\r\nPress any key to continue...");
            Console.Read();
        }
    }
}
