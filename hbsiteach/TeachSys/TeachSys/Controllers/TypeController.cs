using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeachSys.Controllers
{
    public class TypeController : Controller
    {
       
        // GET: /Type/

        Models.TeachDBEntities tdb = new Models.TeachDBEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            Models.Type type = tdb.Type.First(t => t.ID == id);
            return View(type);
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult GetType()
        {
            try
            {

                var da = (from d in tdb.Type

                          select new { id = d.ID, name = d.Name, typid = d.TypeId, Status = d.Status });
                return Json(da, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Content("error");
            }
        }
        public ActionResult AddType(Models.Type t)
        {
            try
            {
                tdb.Type.Add(t);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }
        public ActionResult EditType(int id, string name, int typeid, int status)
        {
            try
            {
                var type = tdb.Type.First(t => t.ID == id);
                type.Name = name;
                type.TypeId = typeid;

                type.Status = status;

                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }
        public ActionResult DeleteType(int id)
        {
            try
            {
                var type = tdb.Type.First(t => t.ID == id);
                tdb.Type.Remove(type);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }

    }
}
