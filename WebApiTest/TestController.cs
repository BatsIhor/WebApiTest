using System.Web.Http;

namespace WebApiTest
{
    public class TestController : ApiController
    {
        public string Get()
        {
            return "Test WebApi method!";
        }
        
        public string Put()
        {
            return "Test WebApi method1!";
        }

        public string Post([FromBody]string item) //http://localhost:64981/test with item in the body
        {
            return "Test WebApi method2!";
        }

        public string Delete([FromBody]int index) //http://localhost:64981/test?0
        {
            return "Test WebApi method3!";
        }
    }
}