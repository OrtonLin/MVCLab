using MVCLab.Attributes;
using MVCLab.Extension;
using MVCLab.Manager;
using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using static MVCLab.Models.Enums;

namespace MVCLab.Controllers
{
    public class EnumAttributeController : Controller
    {
        public ActionResult Index()
        {
            foreach (TeamEnum team in (TeamEnum[])Enum.GetValues(typeof(TeamEnum)))
            {
                //get enum's attribute
                var lattribute = team.GetAttribute<LeagueAttribute>();
                Debug.WriteLine(lattribute?.League);
            }

            var teamEnums = ((TeamEnum[])Enum.GetValues(typeof(TeamEnum)));
            foreach(var team in teamEnums.Where(x => x.GetAttribute<LeagueAttribute>()?.League.ToString() == "EPL").ToList())
            {
                Debug.WriteLine($"EPL: {team}");
            }
            


            return View();
        }
    }
}