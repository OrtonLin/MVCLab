using MVCLab.Manager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLab.Controllers
{
    [Attribute.Interceptor]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //DoSomeThing();
            //DoSomeThing1();
            new NothingManager().DoNothing();
            new NothingManager().DoNothing1();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        private void DoSomeThing()
        {
            Debug.WriteLine("DoSomeThing");
        }
        private void DoSomeThing1()
        {
            Debug.WriteLine("DoSomeThing1");
        }

    }
}