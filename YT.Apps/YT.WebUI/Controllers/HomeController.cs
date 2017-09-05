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
        [Dependency]
        public IYTModuleBusiness moduleBusiness { get; set; }


        //
        // GET: /Home/

        public ActionResult Index()
        {
            YTAccountModel account = new YTAccountModel();
            account.Id = "admin";
            account.TrueName = "admin";
            Session["Account"] = account;
            return View();
        }



        #region WEB API Part

        [HttpPost]
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

        /// <summary>
        /// 获取导航菜单
        /// </summary>
        /// <param name="id">所属</param>
        /// <returns>树</returns>
        public JsonResult GetTree(string id)
        {

            List<YTModuleViewModel> menus = moduleBusiness.GetMenuByPersonId(id);
            var jsonData = (
                    from m in menus
                    select new
                    {
                        id = m.Id,
                        text = m.Name,
                        value = m.Url,
                        showcheck = false,
                        complete = false,
                        isexpand = false,
                        checkstate = 0,
                        hasChildren = m.IsLast ? false : true,
                        Icon = m.Iconic
                    }
                ).ToArray();
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }

    }

        #endregion
}
