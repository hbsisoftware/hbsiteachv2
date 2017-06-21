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

        /// <summary>
        /// 查询书名,作者，出版社
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>

        public ActionResult getBookss(int page, int rows, string name, string author, string pub)
        {

            int nums = tdb.Books.Count();
            var books = (from b in tdb.View_Books
                         orderby b.ID descending
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
                         }
                             );//.Skip((page - 1) * rows).Take(rows);

            if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(author) && string.IsNullOrEmpty(pub))
            {
                books = books.Where(t => t.Name.Contains(name));
            }
            else if (!string.IsNullOrEmpty(author) && string.IsNullOrEmpty(name) && string.IsNullOrEmpty(pub))
            {
                books = books.Where(t => t.Author.Contains(author));
            }
            else if (!string.IsNullOrEmpty(pub) && string.IsNullOrEmpty(name) && string.IsNullOrEmpty(author))
            {
                books = books.Where(t => t.pubName.Contains(pub));
            }
            else if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(author) && string.IsNullOrEmpty(pub))
            {
                books = books.Where(t => t.Name.Contains(name) && t.Author.Contains(author));
            }
            else if (string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(author) && !string.IsNullOrEmpty(pub))
            {
                books = books.Where(t => t.pubName.Contains(pub) && t.Author.Contains(author));
            }
            else if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(author) && !string.IsNullOrEmpty(pub))
            {
                books = books.Where(t => t.Name.Contains(name) && t.pubName.Contains(pub));
            }
            else if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(author) && !string.IsNullOrEmpty(pub))
            {
                books = books.Where(t => t.Name.Contains(name) && t.pubName.Contains(pub) && t.Author.Contains(author));
            }
            //else if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(author) && string.IsNullOrEmpty(pub))
            var bb = books.Skip((page - 1) * rows).Take(rows);
            return Json(new { total = nums, rows = bb }, JsonRequestBehavior.AllowGet);
        }
        ////}
        /// <summary>
        /// ***Books
        /// </summary>
        /// <returns></returns>
        public ActionResult getBooks(int page, int rows)
        {
            int nums = tdb.Books.Count();
            var books = (from b in tdb.View_Books
                         orderby b.ID descending
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
                         }).Skip((page - 1) * rows).Take(rows);
            return Json(new { total = nums, rows = books }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// ***Books
        /// </summary>
        /// <returns></returns>
        public ActionResult getBooksss(string name)
        {
            var books = from b in tdb.View_Books
                        select new
                        {
                            ID = b.ID,
                            Name = b.Name,
                        };
            if (!string.IsNullOrEmpty(name))
            {
                books = books.Where(t => t.Name.Contains(name));
            }
            return Json(books, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getBooksbyID(int id)
        {
            var books = tdb.Books.Single((t => t.ID == id));
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

    }
}
