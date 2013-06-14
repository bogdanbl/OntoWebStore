using System.Web.Mvc;

namespace OntoWebStore.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        class AModel : Tripple
        {
        }

        private class TModel : Tripple
        {
        }

        class Tripple
        {
            public Subject Subject { get; set; }
        }

        class Subject
        {
            public Predicate Predicate { get; set; } 
        }

        class Predicate
        {
            public object Object { get; set; }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
