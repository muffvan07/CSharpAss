using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharpAssignment.Areas.CustomerArea.Controllers
{
    public class HomeController : Controller
    {
        // GET: CustomerArea/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}