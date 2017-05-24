using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace TeachSys.Controllers
{
    public class PartJobTeacherDocsController : Controller
    {
        //
        // GET: /PartJobTeachersDocs/

        Models.TeachDBEntities tdb = new Models.TeachDBEntities();
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
            Models.PartJobTeacherDocs pd = tdb.PartJobTeacherDocs.First(t => t.ID == id);
            return View(pd);
        }

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

        public ActionResult load(Models.PartJobTeacherDocs pt)
        {
            
            //try
            //{

                //HttpPostedFileBase getfile = Request.Files["fileupload"];
                //string filename = getfile.FileName;
                //string str = filename.Substring(filename.LastIndexOf("\\") + 1);
                //string path = "/doc/" + Guid.NewGuid() + str;
                //string getpath = Server.MapPath(path);
                //getfile.SaveAs(path);
                //tdb.PartJobTeacherDocs.Add(pt);
                //pt.Url = getpath;




            try
            {
                HttpPostedFileBase getfile = Request.Files["fileupload"];
                string filename = getfile.FileName;
                string str = filename.Substring(filename.LastIndexOf("\\") + 1);
                string path = "/doc/" + Guid.NewGuid() + str;
                getfile.SaveAs(Server.MapPath(path));
                tdb.PartJobTeacherDocs.Add(pt);
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
