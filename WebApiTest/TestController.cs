using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApiTest
{
    public class TestController : ApiController
    {
        List<string> items = new List<string>() { "item1", "item2" };

        public string Get(int index)
        {
            if (index > 0)
            {
                return items.Aggregate((str1, str2) => str1 + " " + str2);
            }
            else
            {
                return "Modifyed Collection";
            }
        }

        public string Put(int index, [FromBody]string item)
        {
            //PUT http://localhost:64981/test?index=0
            //Content-Type: application/json
            //Host: localhost:64981
            //Accept: application/json
            //Content-Length: 8

            //Body
            //"updated item"

            items[index] = item;
            return items.Aggregate((str1, str2) => str1 + " " + str2);
        }

        public string Post([FromBody]string item) //http://localhost:64981/test with item in the body
        {
            //POST http://localhost:64981/test HTTP/1.1
            //User-Agent: Fiddler
            //Host: localhost:64981
            //Content-Length: 6
            //Content-Type: application/json

            //"new item"
            items.Add(item);
            return items.Aggregate((str1, str2) => str1 + " " + str2);
        }

        public string Delete([FromBody]int index) //http://localhost:64981/test?0
        {
            //DELETE http://localhost:64981/test?0 HTTP/1.1

            items.RemoveAt(index);

            return items.Aggregate((str1, str2) => str1 + " " + str2);
        }
    }
}