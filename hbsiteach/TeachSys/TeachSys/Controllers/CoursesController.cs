﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeachSys.Controllers
{
    public class CoursesController : Controller
    {
        Models.TeachDBEntities1 tdb = App_Start.Helper.tdb;
        //
        // GET: /Courses/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var m = new Models.Courses();
            var i = tdb.Courses.First(t => t.ID == id);
            return View(i);
        }

        /// <summary>
        /// ***课程列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Courses()
        {
            var courses = from c in tdb.Courses
                          select new
                          {
                              ID = c.ID,
                              Name = c.Name,
                          };
            return Json(courses, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getCourses(int majorid)
        {
            var maj = from m in tdb.Courses
                      select new
                      {
                          id = m.ID,
                          name = m.Name,
                          nums = m.Nums,
                          memo = m.Memo,
                          majid = m.MajorID,
                          term = m.Term,
                          status = m.Status,
                      };
            if (majorid != -1)
            {
                maj = maj.Where(t => t.majid == majorid);
            }
            return Json(maj, JsonRequestBehavior.AllowGet);
        }
      
        public ActionResult coursesAdd(Models.Courses courses)
        {
            try
            {
                tdb.Courses.Add(courses);
                if (courses.Nums <= 0)
                {
                    return Content("nums err");
                }
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("err");
            }

        }

        public ActionResult editCourses(Models.Courses courses)
        {
            try
            {
                var id = tdb.Courses.First(t => t.ID == courses.ID);
                id.Name = courses.Name;
                if (courses.Nums <= 0)
                {
                    return Content("nums err");
                }
                id.Nums = courses.Nums;
                id.MajorID = courses.MajorID;
                id.Term = courses.Term;
                id.Memo = courses.Memo;
                id.Status = courses.Status;
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("err");
            }

        }
        public ActionResult Remove(int id)
        {
            try
            {
                var ids = tdb.Courses.First(t => t.ID == id);
                tdb.Courses.Remove(ids);
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