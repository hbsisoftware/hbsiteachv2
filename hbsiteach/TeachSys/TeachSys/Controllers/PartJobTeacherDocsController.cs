﻿using System;
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

        //public ActionResult AddFile(HttpPostedFileBase file)
        //{
        //    if (file != null)
        //    {
        //        try
        //        {
        //            string filepath = Server.MapPath("`/PartJobTeacherDocs");
        //            if (!Directory.Exists(filepath))
        //            {
        //                Directory.CreateDirectory(filepath);
        //            }
        //            string filename = Path.GetFileName(file.FileName);//获取文件名
        //            string fileextension = Path.GetExtension(filename);//文件扩展名
        //            string savename = Guid.NewGuid().ToString() + fileextension;//保存文件名
        //            file.SaveAs(filepath + savename);
        //            return Json(new { Success = true, FileName = filename, SaveName = savename });

        //        }
        //        catch (Exception ex)
        //        {
        //            return Json(new { Success = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);

        //        }
        //    }
        //    else
        //    {
        //        return Json(new { Success = false, Message = "请选择要上传的文件！" }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        public ActionResult load()
        {
            try
            {
                HttpPostedFileBase getfile = Request.Files["fileupload"];
                string filename = getfile.FileName;
                string str = filename.Substring(filename.LastIndexOf("\\") + 1);
                string path = "/PartJobTeachersDocsFile/" + Guid.NewGuid() + str;
                getfile.SaveAs(Server.MapPath(path));
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }



    }
}