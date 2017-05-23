using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeachSys.Controllers
{
    public class PartJobTeacherController : Controller
    {
        //
        // GET: /PartJobTeacher/

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
            Models.PartJobTeachers p=tdb.PartJobTeachers.First(t=>t.ID==id);
            return View(p);
        }

        public ActionResult GetPartJobTeachers()
        {
            var pt = from p in tdb.View_PartJobTeachers
                     select new
                     {
                         id = p.ID,
                         name = p.Name,
                         typename = p.TypeName,
                         titlename = p.TitleName,
                         sex = p.Sex,
                         eduname = p.EduName,
                         intime = p.InTime,
                         tel = p.Tel,
                         uname = p.UnitName,
                         cname = p.ContactName,
                         jtext = p.JudgeText,
                         ltime = p.LastTime,
                         memo = p.Memo,
                         status = p.Status

                     };
            return Json(pt, JsonRequestBehavior.AllowGet);

        }
        public ActionResult EditPartJobTeachers(int id, string name, int typeid, DateTime birthday, bool sex, int eduid, int titleid, DateTime intime, string tel, string uname, string cname, string jtext, DateTime ltime, string memo, int status)
        {
            try
            {
                var pt = tdb.PartJobTeachers.First(t => t.ID == id);
                pt.Name = name;
                pt.TypeID = typeid;
                pt.Birthday = birthday;
                pt.Sex = sex;
                pt.EduID = eduid;
                pt.TitleID = titleid;
                pt.InTime = intime;
                pt.Tel = tel;
                pt.UnitName = uname;
                pt.ContactName = cname;
                pt.JudgeText = jtext;
                pt.LastTime = ltime;
                pt.Memo = memo;
                pt.Status = status;
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }
        public ActionResult AddPartJobTeachers(Models.PartJobTeachers pt)
        {
            try
            {
                tdb.PartJobTeachers.Add(pt);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }
        public ActionResult DeletePartJobTeachers(int id)
        {
            try
            {
                var p = tdb.PartJobTeachers.First(t => t.ID == id);
                tdb.PartJobTeachers.Remove(p);
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
