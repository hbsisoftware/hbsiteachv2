using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeachSys.Controllers
{
    public class BaseDataDicsController : Controller
    {
        //
        // GET: /BaseDataDics/
        Models.TeachDBEntities1 tdb = new Models.TeachDBEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            Models.BaseDataDics de = tdb.BaseDataDics.First(t => t.ID == id);
            return View(de);

        }
        public ActionResult GetDatabase()
        {
            try
            {

                var da = (from d in tdb.BaseDataDics
                          select new { id = d.ID, name = d.Name, d.Status });
                return Json(da, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Content("error");
            }
        }

        public ActionResult AddDatabase(Models.BaseDataDics b)
        {
            try
            {
                tdb.BaseDataDics.Add(b);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }
        public ActionResult EditDatabase(int typeno, string name, int id, int status)
        {
            try
            {
                var b = tdb.BaseDataDics.First(t => t.ID == id);
                b.Name = name;
                b.TypeNo = typeno;
                b.Status = status;
                tdb.SaveChanges();
                return Content("ok");

            }
            catch
            {
                return Content("error");
            }
        }
        public ActionResult DeleteDatabase(int id)
        {
            try
            {
                var no = tdb.BaseDataDics.First(t => t.ID == id);
                tdb.BaseDataDics.Remove(no);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }
        public ActionResult GettypeID(int typeno)
        {
            var classes = from c in tdb.BaseDataDics


                          select new
                          {
                              ID = c.ID,
                              Name = c.Name,
                              Index = c.IndexNo,
                              typeno = c.TypeNo,
                              Status = c.Status
                          };
            if (typeno != -1)
            {
                classes = classes.Where(t => t.typeno == typeno);
            }

            return Json(classes, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDatabases(int typeno)
        {
            try
            {

                var da = (from d in tdb.BaseDataDics
                          where d.TypeNo == typeno
                          select new { id = d.ID, name = d.Name, d.Status });
                return Json(da, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Content("error");
            }
        }

    }
}
