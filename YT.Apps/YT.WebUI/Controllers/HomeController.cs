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
    public class HomeController : Controller
    {
        [Dependency]
        public IYTSimpleBusiness business { get; set; }
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }



        #region WEB API Part


        public JsonResult GetList(EasyUIGridPager p)
        {
            int total = 0;
            List<YTSampleViewModel> list = business.GetList(p.page, p.rows, p.sort, p.order, ref total);
            var json = new
            {
                total = total,
                rows = (from r in list
                        select new
                        {
                            Id = r.Id,
                            Name = r.Name,
                            Age = r.Age,
                            Bir = r.Bir == null ? "" : DateTime.Parse(r.Bir.ToString()).ToString("yyyy-MM-dd"),
                            Photo = r.Photo,
                            Note = r.Note,
                            CreateTime = r.CreateTime == null ? "" : DateTime.Parse(r.CreateTime.ToString()).ToString("yyyy-MM-dd"),
                        }).ToArray()
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
