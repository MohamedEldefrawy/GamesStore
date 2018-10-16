using GamesStore.Models;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GamesStore.Controllers
{
    public class GamesManagementController : Controller
    {
        private GamesEntities db = new GamesEntities();

        #region CRUD

        // GET: GamesManagement
        public ActionResult Index()
        {

            return View(db.Games.ToList());
        }

        // GET: GamesManagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: GamesManagement/Create
        public ActionResult Create()
        {
            ViewBag.SupplierID = new SelectList(db.Suppliers, "ID", "Name");
            return View();
        }

        // POST: GamesManagement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Game game)
        {
            if (ModelState.IsValid)
            {
                //Save in Object to save into DB
                string _fileName = Path.GetFileNameWithoutExtension(game.FilePhoto.FileName);
                string _Extenstion = Path.GetExtension(game.FilePhoto.FileName);
                _fileName = game.ID.ToString() + _Extenstion;
                game.Image = _fileName;
                _fileName = Path.Combine(Server.MapPath("~/Upload/Images/") + _fileName);
                game.FilePhoto.SaveAs(_fileName);
                db.Games.Add(game);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(game);
        }

        // GET: GamesManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: GamesManagement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                if (game.FilePhoto != null)
                {
                    string _fileName = game.ID.ToString() + Path.GetExtension(game.FilePhoto.FileName);
                    game.Image = _fileName;
                    _fileName = Path.Combine(Server.MapPath("~/Upload/Images/") + _fileName);
                    game.FilePhoto.SaveAs(_fileName);
                }

                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: GamesManagement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: GamesManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        //Combine Root with img path
        public FileContentResult fullImageUrl(string path)
        {
            path = Path.Combine(Server.MapPath("~/Upload/Images/") + path);
            byte[] imgarray = System.IO.File.ReadAllBytes(path);
            return new FileContentResult(imgarray, "image/*");
        }

        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string Search, string Name)
        {
            switch (Search.ToLower())
            {
                case "start with":
                    {
                        return PartialView("_GamesSearch", db.Games.Where(q => q.Name.StartsWith(Name)));

                    }

                case "end with":
                    {
                        return PartialView("_GamesSearch", db.Games.Where(q => q.Name.EndsWith(Name)));
                    }

                default:
                    {
                        return View("_GamesSearch", db.Games.Where(q => q.Name.Contains(Name)));
                    }
            }

        }

    }
}
