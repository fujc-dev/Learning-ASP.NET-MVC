using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YT.WebUI.Controllers
{
    /// <summary>
    /// 首页相关控制器
    /// </summary>
    public class IndexController : Controller
    {
        //
        // GET: /Index/
        [Dependency]
        public YT87s.Business.Service.IYTSimpleBusiness business { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveInfo(YT87s.ViewModels.YTSampleViewModel model)
        {
            if (business.Create(model))
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }


    }
}
