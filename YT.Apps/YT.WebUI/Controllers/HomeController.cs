using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YT87s.Business.Service;

namespace YT.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [Dependency]
        public IYTSampleBusiness business { get; set; }
        public ActionResult Simple()
        {
            return View(business.GetList(""));
        }

    }
}
