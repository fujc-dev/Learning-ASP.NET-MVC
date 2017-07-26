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


        public ActionResult Simple()
        {
            IYTSampleBusiness business = new YT87s.Business.Implements.YTSampleBusinessImp();
            return View(business.GetList(""));
        }

    }
}
