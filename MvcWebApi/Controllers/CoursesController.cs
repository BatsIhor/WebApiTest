using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcWebApi.Controllers
{
    public class CoursesController : ApiController
    {
        private static List<course> courses;

        public CoursesController()
        {
            Init();
        }

        private static void Init()
        {
            if (courses == null)
            {
                courses = new List<course>
                    {
                        new course() {id = 0, title = "first"},
                        new course() {id = 1, title = "second"},
                        new course() {id = 2, title = "third"},
                        new course() {id = 3, title = "forth"}
                    };
            }
        }

        public IEnumerable<course> Get()
        {
            return courses;
        }

        public HttpResponseMessage Get(int id)
        {
            course firstOrDefault = courses.FirstOrDefault(x => x.id == id);
            
            if (firstOrDefault == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "incorrect item id");
            }

            HttpResponseMessage httpResponseMessage = Request.CreateResponse<course>(HttpStatusCode.Found, firstOrDefault);
            return httpResponseMessage;
        }

        public HttpResponseMessage Post([FromBody]course _course)
        {
            _course.id = courses.Count;
            courses.Add(_course);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.Created);
            httpResponseMessage.Headers.Location = new Uri(Request.RequestUri + _course.id.ToString());

            return httpResponseMessage;
        }
        
        public void Put(int id, [FromBody]course _course)
        {
            course firstOrDefault = courses.FirstOrDefault(x => x.id == id);
            firstOrDefault.title = _course.title;
            //return 201
        }

        public void Delete(int id)
        {
            course firstOrDefault = courses.FirstOrDefault(x => x.id == id);
            courses.Remove(firstOrDefault);
        }
    }

    public class course
    {
        public int id;
        public string title;
    }
}
