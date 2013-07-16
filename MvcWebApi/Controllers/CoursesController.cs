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
        static List<course> courses = new List<course>();

        public CoursesController()
        {
            courses.Add(new course() { id = 0, title = "first" });
            courses.Add(new course() { id = 1, title = "second" });
            courses.Add(new course() { id = 2, title = "third" });
            courses.Add(new course() { id = 3, title = "forth" });
        }

        public IEnumerable<course> Get()
        {
            return courses;
        }

        public course Get(int id)
        {
            return courses.Where((x)=> x.id == id).FirstOrDefault();
            //if nulll than return 404
        }
    }

    public class course
    {
        public int id;
        public string title;
    }
}
