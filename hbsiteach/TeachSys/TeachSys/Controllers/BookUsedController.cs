using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeachSys.Controllers
{
    public class BookUsedController : Controller
    {
        //
        // GET: /BookUsed/
        Models.TeachDBEntities tdb = new Models.TeachDBEntities();
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 根据学期查询，并分页
        /// </summary>
        /// <returns></returns>
        public ActionResult getBookUsed(int page, int rows, string e)
        {
                int nums = tdb.View_BookUsed.Count();
                var bookuse = (from bu in tdb.View_BookUsed
                               orderby bu.ID descending
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
                                   term = bu.Term,
                               }).Skip((page - 1) * rows).Take(rows);
                if (!string.IsNullOrEmpty(e))
                {
                    bookuse = bookuse.Where(t => t.term.Contains(e));
                }
                return Json(new { total = nums, rows = bookuse }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getBookUseds(string e)
        {

            //int nums = tdb.View_BookUsed.Count();
            var bookuse = (from bu in tdb.View_BookUsed
                           orderby bu.ID descending
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
                               term = bu.Term,
                           });
            if (!string.IsNullOrEmpty(e))
            {
                bookuse = bookuse.Where(t => t.term.Contains(e));
            }
            return Json(bookuse,JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 显示学期
        /// </summary>
        /// <returns></returns>
        public ActionResult Term()
        {
            var term = (from t in tdb.Courses
                        select new
                        {
                            
                            termName = t.Term
                        }).Distinct();
            return Json(term, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取书的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult getBooksContent(string name)
        {
            var books = from b in tdb.View_Books
                        where b.Name==name
                        select new
                        {
                            ID = b.ID,
                            Name = b.Name,
                            Author = b.Author,
                            pubName = b.publisherName,
                            PubYear = b.PubYear,
                            ISBN = b.ISBN,
                            Price = b.Price,
                            BPN = b.BookProertyName,
                            BTN = b.BookTypeName,
                            LastTime = b.LastTime,
                            DisabledTime = b.DisabledTime,
                        };
            return Json(books, JsonRequestBehavior.AllowGet);
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
        //public ActionResult coursesAdd(Models.Courses c)
        //{
        //    try
        //    {
        //        char[] a = { '{', '}', 'T', 'e', 'r', 'm', '=', ' ' };
        //        foreach (var item in (from m in tdb.Courses select new { m.Term }))
        //        {

        //            string[] s = item.ToString().Split(a, StringSplitOptions.RemoveEmptyEntries);
        //            //string str = String.Empty;
        //            //foreach (string tempStr in s)
        //            //{
        //            //    str += tempStr;
        //            //} 
        //            if (String.Join("", s) == c.Term.ToString())
        //            {
        //                return Content("输入的学期重复了");
        //            }
        //        }
        //        tdb.Courses.Add(c);
        //        if (c.Nums <= 0)
        //        {
        //            return Content("nums err");
        //        }
        //        tdb.SaveChanges();
        //        return Content("ok");
        //    }
        //    catch
        //    {
        //        return Content("err");
        //    }

        //}
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


        /// <summary>
        /// Excel导入
        /// </summary>
        /// <returns></returns>
        //public ActionResult ExportExcel()
        //{
        //    string json = Request.Params["data"];
        //    try
        //    {
        //        DataTable dt = ExcelHelper.JsonToDataTable(json);
        //        string pathDestop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //        ExcelHelper.GridToExcelByNPOI(dt, pathDestop + "\\" + "销售订单-" + DateTime.Now.ToString("yyyy-MM-dd") + "导出" + ".xls");
        //        return Content("1");
        //    }
        //    catch (Exception)
        //    {
        //        return Content("-1");
        //    }
        //}
    }
}
