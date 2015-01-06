using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Vacation_management_system.Web.Common.Class;

namespace VMSUnitTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            string json = @"[ {
             'Name': 'Product 1',
             'ExpiryDate': '2000-12-29T00:00Z',

                                },
                                {
             'Name': 'Product 2',
             'ExpiryDate': '2009-07-31T00:00Z',
                                 },
                  {
             'Name': 'Product 3',
             'ExpiryDate': '2010-07-31T00:00Z',
                                 }
                                    ]";
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);

            for (int i = 0; i < products.Count; i++)
            {
                if (i == 0)
                {
                    Assert.IsTrue(Utilities.ComparePassword("Product 1", products[i].Name));

                    Assert.IsTrue(Utilities.ComparePassword("2000-12-29T00:00Z", products[i].ExpiryDate));
                }

            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            string json = @"{""key1"":""value1"",""key2"":""value2""}";

            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            Console.WriteLine(values.Count);

            Console.WriteLine(values["key1"]);
        }


        [TestMethod]
        public void TestMethod3()
        {
            string json = @"{""Holidayname"":""Holiday"",""HolidayDate"":""dd/mm/yyyy""}";   

            Dictionary<string, string> products = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            for (int i = 0; i < products.Count; i++)
            {
                if (i == 0)
                {
                    Assert.IsTrue(Utilities.ComparePassword("Holiday", products["Holidayname"]));

                    Assert.IsTrue(Utilities.ComparePassword("dd/mm/yyyy", products["HolidayDate"]));
                }

            }
        }

        [TestMethod]
        public void TestMethod4()
        {
            // {'results':

            

            var json =
                @"{'results':[{'FirstName': 'John','LastName': 'Smith'},{'Name': 'Product 2','ExpiryDate': '2009-07-31T00:00Z'}]}";

            var obj = AllChildren(JObject.Parse(json)).First(c => c.Type == JTokenType.Array && c.Path.Contains("results")).Children<JObject>();

           
            foreach (JObject result in obj)
            {
                foreach (JProperty property in result.Properties())
                {
                    // do something with the property belonging to result

                    var Str = property.Value;
                    Debug.WriteLine(Str);
                }

                var res = result;
            }
        }


        private static IEnumerable<JToken> AllChildren(JToken json)
        {
            foreach (var c in json.Children())
            {
                yield return c;
                foreach (var cc in AllChildren(c))
                {
                    yield return cc;
                }
            }
        }
    }
}
