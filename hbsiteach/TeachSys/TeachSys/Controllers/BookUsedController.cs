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
        public ActionResult Add()
        {
            return View();
        }
        /// <summary>
        /// 添加需要课程列表，教师列表，教材列表，需要到对应的控制器中，找到与之对应的***标记，调用即可。_。
        /// </summary>
        /// <returns></returns>
        public ActionResult BookUseAdd()
        {
            return View();
        }

    }
}
