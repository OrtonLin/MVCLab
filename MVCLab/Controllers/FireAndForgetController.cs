using MVCLab.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCLab.Controllers
{
    public class FireAndForgetController : Controller
    {
        public static StringBuilder _StringContainer { get; set; } = new StringBuilder();
        public static Dictionary<string, int> _Counter = new Dictionary<string, int>();
        // GET: FireAndForget
        public ActionResult Index()
        {
            ViewBag.Counter = _Counter;

            Task.Run(() =>
            {
                Triger3SecLog("TaskRun", DateTime.Now);
            });

            Task.Run(async () =>
            {
            await Triger3SecLogAsync("TaskRunAsyncNoAwait", DateTime.Now);
            }).ConfigureAwait(false);

            TaskUtility.RunAndForget(()=> Triger3SecLogAsync("RunAndForget", DateTime.Now));

            ViewBag.StringContext = _StringContainer;

            return View();
        }

        public void Triger3SecLog(string caller, DateTime dateTime)
        {
            Thread.Sleep(3000);
            if(!_Counter.ContainsKey(caller))
            {
                _Counter.Add(caller, 1);
            }
            else
            {
                _Counter[caller] += 1;
            }
            _StringContainer.Append($"[{dateTime.ToString("yyyy/MM/dd HH:mm:ss:fff")}] Trigger 3 seconds log by '{caller}' on <br/>");
        }

        public Task Triger3SecLogAsync(string caller, DateTime dateTime)
        {
            return Task.Run(() =>
            {
                Triger3SecLog(caller, dateTime);
            });
            
        }

    }
}