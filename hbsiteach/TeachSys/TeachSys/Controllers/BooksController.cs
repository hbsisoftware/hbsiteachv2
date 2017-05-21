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
        //public ActionResult AddBooks(Models.Books bdd)
        //{
        //    try
        //    {
        //        var books = tdb.Books.Add(bdd);
        //        tdb.SaveChanges();
        //        return Content("ok");
        //    }
        //    catch
        //    {
        //        return Content("err");
        //    }
        //}
        //public ActionResult EditBooks(Models.Books editbdd)
        //{
        //    try
        //    {
        //         var editbook = tdb.Books.First(t => t.ID == editbdd.ID);
        //        editbook.ID = editbdd.ID;
        //        editbook.Name = editbdd.Name;
        //        editbook.Author = editbdd.Author;
        //        editbook.PublisherID = editbdd.PublisherID;
        //        editbook.PubYear = editbdd.PubYear;
        //        editbook.ISBN = editbdd.ISBN;
        //        editbook.Price = editbdd.Price;
        //        editbook.BookPropertyID = editbdd.BookPropertyID;
        //        editbook.BookTypeID = editbdd.BookTypeID;
        //        editbook.DisabledTime = editbdd.DisabledTime;
        //        editbook.LastTime = editbdd.LastTime;
        //        editbook.Status = editbdd.Status;
        //        tdb.SaveChanges();
        //        return Content("ok");
        //    }
        //    catch
        //    {
        //        return Content("err");
        //    }
        //}
        //public ActionResult Edit(int id)
        //{
        //    var m = new Models.BaseDataDics();
        //    m = tdb.BaseDataDics.First(t => t.ID == id);
        //    return View(m);
        //}
        ///// <summary>
        ///// 获取出版社，教材类别，教材性质
        ///// </summary>
        ///// <param name="typeno"></param>
        ///// <returns></returns>
        //public ActionResult Press(int typeno)
        //{
        //    var press = from p in tdb.BaseDataDics
        //                where p.TypeNo == typeno
        //                select new
        //                {
        //                    ID = p.ID,
        //                    Name = p.Name,
        //                };
        //    return Json(press, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult getBooks()
        //{
        //    var books = from b in tdb.Books
        //                select new
        //                {
        //                    ID = b.ID,
        //                    Name = b.Name,
        //                    Author = b.Author,
        //                    PublisherID = b.PublisherID,
        //                    PubYear = b.PubYear,
        //                    ISBN = b.ISBN,
        //                    Price = b.Price,
        //                    BookPropertyID = b.BookPropertyID,
        //                    BookTypeID = b.BookTypeID,
        //                    LastTime = b.LastTime,
        //                    DisabledTime = b.DisabledTime,
        //                    Status = b.Status
        //                };
        //    return Json(books, JsonRequestBehavior.AllowGet);
        //}
        //public ActionResult getBooksByIDS(int PublisherID, int BookPropertyID, int BookTypeID)
        //{
        //    var books = from b in tdb.Books
        //                select new
        //                {
        //                    ID = b.ID,
        //                    Name = b.Name,
        //                    Author = b.Author,
        //                    PublisherID = b.PublisherID,
        //                    PubYear = b.PubYear,
        //                    ISBN = b.ISBN,
        //                    Price = b.Price,
        //                    BookPropertyID = b.BookPropertyID,
        //                    BookTypeID = b.BookTypeID,
        //                    LastTime = b.LastTime,
        //                    DisabledTime = b.DisabledTime,
        //                    Status = b.Status
        //                };
        //    if (PublisherID != -1)
        //    {
        //        books = books.Where(t => t.PublisherID == PublisherID);
        //    }
        //    if (BookPropertyID != -1)
        //    {
        //        books = books.Where(t => t.BookPropertyID == BookPropertyID);
        //    }
        //    if (BookTypeID != -1)
        //    {
        //        books = books.Where(t => t.BookTypeID == BookTypeID);
        //    }
        //    return Json(books, JsonRequestBehavior.AllowGet);
        //}

    }
}
