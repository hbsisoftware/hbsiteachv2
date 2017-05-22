using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeachSys.Controllers
{
    public class TypeController : Controller
    {
        //
        // GET: /Type/
<<<<<<< HEAD
=======
<<<<<<< HEAD

=======
>>>>>>> d5934dd1ac2a8e90f60d3a09b9a83248f57b1467
>>>>>>> aad2e41493bc8ac23ddb82ced4fecdd87ebec0fb
        Models.TeachDBEntities1 tdb = new Models.TeachDBEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            Models.Type type = tdb.Type.First(t => t.ID == id);
            return View(type);
<<<<<<< HEAD

=======
<<<<<<< HEAD

=======
           
>>>>>>> d5934dd1ac2a8e90f60d3a09b9a83248f57b1467
>>>>>>> aad2e41493bc8ac23ddb82ced4fecdd87ebec0fb
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult GetType()
        {
            var type = from t in tdb.Type
<<<<<<< HEAD
                       select new { name = t.Name, typeid = t.TypeId };
=======
<<<<<<< HEAD
                       select new { name = t.Name, typeid = t.TypeId };
=======
                       select new { t.Name, t.TypeId };
>>>>>>> d5934dd1ac2a8e90f60d3a09b9a83248f57b1467
>>>>>>> aad2e41493bc8ac23ddb82ced4fecdd87ebec0fb
            return Json(type, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddType(Models.Type t)
        {
            try
            {
                tdb.Type.Add(t);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }
        public ActionResult EditType(int id, string name, int typeid, int status)
        {
            try
            {
                var type = tdb.Type.First(t => t.ID == id);
                type.Name = name;
                type.TypeId = typeid;
<<<<<<< HEAD
                type.Status = status;
=======
<<<<<<< HEAD
                type.Status = status;
=======

>>>>>>> d5934dd1ac2a8e90f60d3a09b9a83248f57b1467
>>>>>>> aad2e41493bc8ac23ddb82ced4fecdd87ebec0fb
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }
        public ActionResult DeleteType(int id)
        {
            try
            {
                var type = tdb.Type.First(t => t.ID == id);
                tdb.Type.Remove(type);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }
<<<<<<< HEAD

=======
<<<<<<< HEAD
=======

>>>>>>> d5934dd1ac2a8e90f60d3a09b9a83248f57b1467
>>>>>>> aad2e41493bc8ac23ddb82ced4fecdd87ebec0fb
    }
}
