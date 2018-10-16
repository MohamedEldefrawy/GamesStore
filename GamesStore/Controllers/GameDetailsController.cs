using GamesStore.Models;
using System.IO;
using System.Web.Mvc;

namespace DafroGames.Controllers
{
    public class GameDetailsController : Controller
    {
        private GamesEntities db = new GamesEntities();
        
        [HttpGet]
        public ActionResult Detail(int? id)
        {
            return View(db.Games.Find(id));
        }

        public FileContentResult fullImageUrl(string path)
        {
            path = Path.Combine(Server.MapPath("~/Upload/Images/") + path);
            byte[] imgarray = System.IO.File.ReadAllBytes(path);
            return new FileContentResult(imgarray, "image/jpg");
        }
    }
}