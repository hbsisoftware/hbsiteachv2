using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeachSys.Controllers
{
    public class BooksController : Controller
    {
        //
        // GET: /Books/
        Models.TeachDBEntities tdb = new Models.TeachDBEntities();
        public ActionResult Index()
        {
           
            return View();
        }
      /// <summary>
      /// ***Books
      /// </summary>
      /// <returns></returns>
        public ActionResult getBooks()
        {
            var books = from b in tdb.View_Books
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
      
        public ActionResult AddBooks(Models.Books bdd)
        {
            try
            {
                var books = tdb.Books.Add(bdd);
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
            var m = new Models.Books();
            m = tdb.Books.First(t => t.ID == id);
            return View(m);
        }
        public ActionResult EditBooks(Models.Books editbdd)
        {
            try
            {
                var editbook = tdb.Books.First(t => t.ID == editbdd.ID);
                editbook.ID = editbdd.ID;
                editbook.Name = editbdd.Name;
                editbook.Author = editbdd.Author;
                editbook.PublisherID = editbdd.PublisherID;
                editbook.PubYear = editbdd.PubYear;
                editbook.ISBN = editbdd.ISBN;
                editbook.Price = editbdd.Price;
                editbook.BookPropertyID = editbdd.BookPropertyID;
                editbook.BookTypeID = editbdd.BookTypeID;
                editbook.DisabledTime = editbdd.DisabledTime;
                editbook.LastTime = editbdd.LastTime;
                editbook.Status = editbdd.Status;
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("err");
            }
        }
        public ActionResult DelBooks(int id)
        {
            try
            {
                var bookid = tdb.Books.First(t => t.ID == id);
                tdb.Books.Remove(bookid);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch 
            {
                return Content("err");
            }

        }

        /// <summary>
        /// 获取出版社，教材类别，教材性质
        /// </summary>
        /// <param name="typeno"></param>
        /// <returns></returns>
        public ActionResult Press(int typeno)
        {
            var press = from p in tdb.BaseDataDics
                        where p.TypeNo == typeno
                        select new
                        {
                            ID = p.ID,
                            Name = p.Name,
                        };
            return Json(press, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 停止使用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         DateTime ts1 = DateTime.Now;
        public ActionResult StopUse(int id)
        {
            try
            {
                var sid = tdb.Books.First(t => t.ID == id);
                sid.DisabledTime = ts1.Year + "-" + Time(ts1.Month) + "-" + Day(ts1.Day);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("err");
            }

        }
        public string Time(int month)
        {
           
            if (month < 10)
            {
                return "0" + month;
            }
            else
            {
                return "" + month;
            }
        }
        public string Day(int day)
        {

            if (day < 10)
            {
                return "0" + day;
            }
            else
            {
                return "" + day;
            }
        }
       
    }
}
