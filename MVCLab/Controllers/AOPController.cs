using MVCLab.Manager;
using System.Diagnostics;
using System.Web.Mvc;

namespace MVCLab.Controllers
{
    public class AOPController : Controller
    {
        // GET: AOP
        public ActionResult Index()
        {
            new NothingManager().DoNothing();
            new NothingManager().DoNothing1();
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