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
        Models.TeachDBEntities1 tdb = new Models.TeachDBEntities1();
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
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
        /// 添加需要课程列表，教师列表，教材列表，班级列表，需要到对应的控制器中，找到与之对应的***标记，调用即可。_。
        /// 不需要学生数量-----添加
        /// </summary>
        /// <returns></returns>

        public ActionResult BookUseAdd(int CoursesID, int ClassID, int BookID, int TeacherID, int Status, int TeaBookNums)
        {
            try
            {
                var bu = tdb.GetStudentNums(CoursesID, ClassID, BookID, TeacherID, Status, TeaBookNums);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("err");
            }
        }
        public ActionResult Edit(int id)
        {
            var book = new Models.BookUsed();
            book = tdb.BookUsed.First(t => t.ID == id);
            return View(book);
        }
        /// <summary>
        /// 不需要提供学生数量-----编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult EditBooksUse(int CoursesID, int BookID, int TeacherID, int Status, int id, int TeaBookNums, int StudentNums)
        {
            try
            {
                var editbook = tdb.EditBookUsed(CoursesID, BookID, TeacherID, Status, id, TeaBookNums, StudentNums);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("err");
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult RemteBookUse(int id)
        {
            try
            {
                var RBU = tdb.BookUsed.First(t => t.ID == id);
                tdb.BookUsed.Remove(RBU);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("err");
            }

        }

    }
}
