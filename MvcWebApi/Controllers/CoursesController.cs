using System.Collections.Generic;
using System.Linq;
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

        public course Get(int id)
        {
            return courses.FirstOrDefault(x => x.id == id);
            //if null than return 404
        }

        public void Post([FromBody]course _course)
        {
            _course.id = courses.Count;
            courses.Add(_course);
            //return 201
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
