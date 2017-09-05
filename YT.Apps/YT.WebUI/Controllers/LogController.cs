using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YT87s.Business.Service;
using YT87s.Common;
using YT87s.ViewModels;

namespace YT.WebUI.Controllers
{
    public class LogController : Controller
    {
        //
        // GET: /Log/

        [Dependency]
        public IYTLogBusiness logBusiness { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetList(EasyUIGridPager pager, string queryStr)
        {
            List<YTLogViewModel> list = logBusiness.GetList(pager.page, pager.rows, pager.sort, pager.order, ref  pager.totalRows, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = list
            };
            return Json(json);
        }

        public ActionResult Details(string id)
        {
            return View(logBusiness.GetById(id));
        }


    }
}
