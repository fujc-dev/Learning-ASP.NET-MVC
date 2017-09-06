using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YT87s.Business.Service;
using YT87s.Common;
using YT87s.Entities;
using YT87s.ViewModels;

namespace YT.WebUI.Controllers
{
    public class ExceptionController : Controller
    {
        //
        // GET: /Exception/
        [Dependency]
        public IYTExceptionBusiness exceptionBusiness { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetList(YT87s.Common.EasyUIGridPager pager, string queryStr)
        {
            List<SysException> list = exceptionBusiness.GetList(pager.page, pager.rows, pager.sort, pager.order, ref  pager.totalRows, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new YTExceptionViewModel
                        {
                            Id = r.Id,
                            HelpLink = r.HelpLink,
                            Message = r.Message,
                            Source = r.Source,
                            StackTrace = r.StackTrace,
                            TargetSite = r.TargetSite,
                            Data = r.Data,
                            CreateTime = r.CreateTime
                        }).ToArray()

            };
            return Json(json);
        }

        public ActionResult Details(string id)
        {
            return View(exceptionBusiness.GetById(id));
        }

        public ActionResult Error()
        {

            ExceptionViewModel ex = new ExceptionViewModel();
            return View(ex);
        }
    }
}
