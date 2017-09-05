using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YT87s.Business.Service;
using YT87s.Database.Service;
using YT87s.ViewModels;

namespace YT87s.Business.Implements
{
    public class YTModuleBusinessImp : IYTModuleBusiness
    {
        [Dependency]
        public IYTModuleRepository Rep { get; set; }

        public List<YTModuleViewModel> GetMenuByPersonId(string moduleId)
        {
            var modules = Rep.GetMenuByPersonId(moduleId);
            List<YTModuleViewModel> viewModules = new List<YTModuleViewModel>();
            modules.ForEach((o) =>
            {
                var _ = new YTModuleViewModel()
                {
                    Id = o.Id,
                    Name = o.Name,
                    EnglishName = o.EnglishName,
                    ParentId = o.ParentId,
                    Url = o.Url,
                    Iconic = o.Iconic,
                    Sort = o.Sort,
                    Remark = o.Remark,
                    State = o.State,
                    CreatePerson = o.CreatePerson,
                    CreateTime = o.CreateTime,
                    IsLast = o.IsLast,
                    Version = o.Version,
                };
                viewModules.Add(_);
            });
            return viewModules;
        }
    }
}
