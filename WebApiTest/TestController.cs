using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApiTest
{
    public class TestController : ApiController
    {
        List<string> items = new List<string>() { "item1", "item2" };

        public string Get()
        {
            return items.Aggregate((str1, str2) => str1 + " " + str2);
        }

        public void Put(int index, [FromBody]string item)
        {
            items[index] = item;
        }

        public void Post([FromBody]string item) //http://localhost:64981/test with item in the body
        {
            //POST http://localhost:64981/test HTTP/1.1
            //User-Agent: Fiddler
            //Host: localhost:64981
            //Content-Length: 6
            //Content-Type: application/x-www-form-urlencoded

            //=asdas
            
            //------------------OR ------------------

            //POST http://localhost:64981/test HTTP/1.1
            //User-Agent: Fiddler
            //Host: localhost:64981
            //Content-Length: 6
            //Content-Type: application/json

            //"item"
            items.Add(item);
        }

        public void Delete([FromBody]int index) //http://localhost:64981/test?0
        {
            items.RemoveAt(index);
        }
    }
}