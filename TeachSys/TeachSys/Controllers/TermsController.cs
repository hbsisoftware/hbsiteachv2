using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeachSys.Controllers
{
    public class TermsController : Controller
    {
        Models.TeachDBEntities tdb = App_Start.Helper.tdb;
        //
        // GET: /Terms/

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 添加学期
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult GetTerms()
        {
            var terms = tdb.Terms.ToList();
            return Json(terms, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 修改学期
        /// </summary>
        /// <param name="id">要修改的学期的id</param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var term = tdb.Terms.First(t => t.ID == id);
            return View(term);
        }
        /// <summary>
        /// 添加保存学期
        /// </summary>
        /// <param name="term">要保存的学期</param>
        /// <returns></returns>
        public ActionResult AddTerm(Models.Terms term)
        {
            try
            {
                tdb.Terms.Add(term);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("err");
            }
        }
        /// <summary>
        /// 更新修改的学期
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public ActionResult EditTerm(Models.Terms term)
        {
            try
            {
                var te = tdb.Terms.First(t => t.ID == term.ID);
                te.Name = term.Name;
                te.Status = term.Status;
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("err");
            }
        }
        /// <summary>
        /// 删除学期
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            try
            {
                var term = tdb.Terms.First(t => t.ID == id);
                tdb.Terms.Remove(term);
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
