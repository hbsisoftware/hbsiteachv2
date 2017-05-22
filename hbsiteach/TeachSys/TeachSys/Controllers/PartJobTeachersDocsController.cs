using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeachSys.Controllers
{
    public class PartJobTeachersDocsController : Controller
    {
        //
        // GET: /PartJobTeachersDocs/
<<<<<<< HEAD
=======

>>>>>>> aad2e41493bc8ac23ddb82ced4fecdd87ebec0fb
        Models.TeachDBEntities1 tdb = new Models.TeachDBEntities1();
        public ActionResult Index()
        {
            return View();
        }
<<<<<<< HEAD
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            Models.PartJobTeacherDocs pd = tdb.PartJobTeacherDocs.First(t => t.ID == id);
            return View(pd);
        }
=======
>>>>>>> aad2e41493bc8ac23ddb82ced4fecdd87ebec0fb
        public ActionResult GetDocs()
        {
            var gd = from c in tdb.PartJobTeacherDocs
                     join b in tdb.BaseDataDics on c.DocTypeID equals b.ID
                     join p in tdb.PartJobTeachers on c.PJTeacherID equals p.ID
                     select new
                     {
                         ID = c.ID,
                         Url = c.Url,
                         PName = p.Name,
                         DocTypeId = b.Name,
                         UploadTime = c.UploadTime,
                         Status = c.Status
                     };
            return Json(gd, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddDocs(Models.PartJobTeacherDocs pt)
        {
            try
            {
                tdb.PartJobTeacherDocs.Add(pt);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }
        public ActionResult EditDocs(int id, int doctypeid, DateTime uploadtime, int status, string url)
        {
            try
            {
                var p = tdb.PartJobTeacherDocs.First(t => t.ID == id);
                p.UploadTime = uploadtime;
                p.Status = status;
                p.Url = url;
                p.DocTypeID = doctypeid;
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }
        public ActionResult DeleteDocs(int id)
        {
            try
            {
                var p = tdb.PartJobTeacherDocs.First(t => t.ID == id);
                tdb.PartJobTeacherDocs.Remove(p);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }
<<<<<<< HEAD

=======
>>>>>>> aad2e41493bc8ac23ddb82ced4fecdd87ebec0fb
    }
}
