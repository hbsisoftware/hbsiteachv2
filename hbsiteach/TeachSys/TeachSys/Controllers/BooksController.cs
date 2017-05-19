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
        Models.TeachDBEntities1 tdb = new Models.TeachDBEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
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

        public ActionResult getBooks()
        {
            var books = from b in tdb.Books
                        select new
                        {
                            ID = b.ID,
                            Name = b.Name,
                            Author = b.Author,
                            PublisherID = b.PublisherID,
                            PubYear = b.PubYear,
                            ISBN = b.ISBN,
                            Price = b.Price,
                            BookPropertyID = b.BookPropertyID,
                            BookTypeID = b.BookTypeID,
                            LastTime = b.LastTime,
                            DisabledTime = b.DisabledTime,
                            Status = b.Status
                        };
            return Json(books, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getBooksByIDS(int PublisherID, int BookPropertyID, int BookTypeID)
        {
            var books = from b in tdb.Books
                        select new
                        {
                            ID = b.ID,
                            Name = b.Name,
                            Author = b.Author,
                            PublisherID = b.PublisherID,
                            PubYear = b.PubYear,
                            ISBN = b.ISBN,
                            Price = b.Price,
                            BookPropertyID = b.BookPropertyID,
                            BookTypeID = b.BookTypeID,
                            LastTime = b.LastTime,
                            DisabledTime = b.DisabledTime,
                            Status = b.Status
                        };
            if (PublisherID != -1)
            {
                books = books.Where(t => t.PublisherID == PublisherID);
            }
            if (BookPropertyID != -1)
            {
                books = books.Where(t => t.BookPropertyID == BookPropertyID);
            }
            if (BookTypeID != -1)
            {
                books = books.Where(t => t.BookTypeID == BookTypeID);
            }
            return Json(books, JsonRequestBehavior.AllowGet);
        }
    }
}
