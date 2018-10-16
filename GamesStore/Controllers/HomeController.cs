using GamesStore.Models;
using System.IO;
using System.Web.Mvc;

namespace GamesStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly GamesEntities db = new GamesEntities();
        public ActionResult Index()
        {
            return View(db.Games);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public FileContentResult fullImageUrl(string path)
        {
            path = Path.Combine(Server.MapPath("~/Upload/Images/") + path);
            byte[] imgarray = System.IO.File.ReadAllBytes(path);
            return new FileContentResult(imgarray, "image/jpg");
        }
    }
}