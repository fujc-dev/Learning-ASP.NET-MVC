using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YT87s.Database.Service;
using YT87s.Entities;

namespace YT87s.Database.Implements
{
    public class YTModuleRepositoryImp : IYTModuleRepository
    {
        public List<YTModule> GetMenuByPersonId(string moduleId)
        {
            using (YT87sEntities db = new YT87sEntities())
            {
                var menus =
                (
                    from m in db.YTModule
                    where m.ParentId == moduleId
                    where m.Id != "0"
                    select m
                          ).Distinct().OrderBy(a => a.Sort).ToList();
                return menus;
            }
        }
    }
}
