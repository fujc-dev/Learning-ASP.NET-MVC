using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YT87s.Business.Service;
using YT87s.Database.Service;
using YT87s.Entities;
using YT87s.ViewModels;

namespace YT87s.Business.Implements
{
    public class YTExceptionBusinessImp : IYTExceptionBusiness
    {
        [Dependency]
        public IYTExceptionRepository exRep { get; set; }


        public List<SysException> GetList(int page, int rows, string sort, string order, ref int total, string queryStr)
        {

            YT87sEntities db = new YT87sEntities();
            List<SysException> query = null;
            IQueryable<SysException> list = exRep.GetList(db);
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                list = list.Where(a => a.Message.Contains(queryStr));
                total = list.Count();
            }
            else
            {
                total = list.Count();
            }

            if (order == "desc")
            {
                query = list.OrderByDescending(c => c.CreateTime).Skip((page - 1) * rows).Take(rows).ToList();
            }
            else
            {
                query = list.OrderBy(c => c.CreateTime).Skip((page - 1) * rows).Take(rows).ToList();
            }

            return query;

        }

        public SysException GetById(string id)
        {
            return exRep.GetById(id);
        }
    }
}
