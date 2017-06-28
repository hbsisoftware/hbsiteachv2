using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeachSys.Controllers
{
    public class PartJobTeacherDocsController : Controller
    {
        //
        // GET: /PartJobTeacherDocs/

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
        public ActionResult EditDocs(int id, int PJTeacherID, int doctypeid, string url)
        {
            try
            {
                var p = tdb.PartJobTeacherDocs.First(t => t.ID == id);
                p.PJTeacherID = PJTeacherID;
                //p.UploadTime = uploadtime;

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
            DateTime dt = DateTime.Now;

            try
            {
                var p = Server.MapPath("/PartJobTeachersDocsFile/") + pt.PJTeacherID + "/";
                if (!System.IO.Directory.Exists(p))
                {
                    System.IO.Directory.CreateDirectory(p);
                }
                HttpPostedFileBase getfile = Request.Files["uploadify"];
                string filename = getfile.FileName;
                string str = filename.Substring(filename.LastIndexOf("\\") + 1);
                string path = p + Guid.NewGuid() + str;
                getfile.SaveAs(path);
                tdb.PartJobTeacherDocs.Add(pt);
                pt.UploadTime = dt;
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }



        }

        public ActionResult UploadifyFun(HttpPostedFileBase Filedata)
        {

            if (Filedata == null ||
                String.IsNullOrEmpty(Filedata.FileName) ||
                Filedata.ContentLength == 0)
            {
                return this.HttpNotFound();
            }

            string filename = System.IO.Path.GetFileName(Filedata.FileName);
            string virtualPath = String.Format("~/doc/{0}", filename);

            string path = this.Server.MapPath(virtualPath);
            Filedata.SaveAs(path);
            return this.Json(new object { });
        }  

    }
}
