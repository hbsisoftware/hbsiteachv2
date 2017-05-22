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

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getBooksUsed()
        {
            return View();
        }

    }
}
