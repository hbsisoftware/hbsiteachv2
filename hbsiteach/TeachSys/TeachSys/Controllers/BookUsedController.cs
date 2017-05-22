using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeachSys.Controllers
{
    public class BookUsedController : Controller
    {
        //
        // GET: /BookUsed/
        Models.TeachDBEntities5 tdb = new Models.TeachDBEntities5();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getBookUsed()
        {
            var bookuse = from bu in tdb.View_BookUsed
                          select new
                          {
                              ID = bu.ID,
                              BookID = bu.BookID,
                              Name = bu.Name,
                              CourseID = bu.CourseID,
                              CoursesName = bu.CoursesName,
                              TeacherID = bu.TeacherID,
                              TeacherName = bu.TeachName,
                              StuBookNums = bu.StuBookNums,
                              TeaBookNums = bu.TeaBookNums,
                          };
            return Json(bookuse, JsonRequestBehavior.AllowGet);
        }

    }
}
