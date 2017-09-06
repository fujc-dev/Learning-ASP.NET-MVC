using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YT87s.Business.Service;
using YT87s.Database.Service;
using YT87s.Entities;

namespace YT87s.Business.Implements
{


    public class YTLogBusinessImp : IYTLogBusiness
    {
        [Dependency]
        public IYTLogRepository logRep { get; set; }



        public List<ViewModels.YTLogViewModel> GetList(int page, int rows, string sort, string order, ref int total, string queryStr)
        {
            YT87sEntities db = new YT87sEntities();
            List<SysLog> query = null;
            IQueryable<SysLog> list = logRep.GetList(db);
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                list = list.Where(a => a.Message.Contains(queryStr) || a.Module.Contains(queryStr));
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
            List<ViewModels.YTLogViewModel> viewModels = new List<ViewModels.YTLogViewModel>();
            query.ForEach((o) =>
            {
                var _ = new ViewModels.YTLogViewModel()
                {
                    Id = o.Id,
                    Operator = o.Operator,
                    Message = o.Message,
                    Result = o.Result,
                    Type = o.Type,
                    Module = o.Module,
                    CreateTime = o.CreateTime
                };
                viewModels.Add(_);
            });
            return viewModels;
        }

        public ViewModels.YTLogViewModel GetById(string id)
        {
            var o = logRep.GetById(id);
            var _ = new ViewModels.YTLogViewModel()
            {
                Id = o.Id,
                Operator = o.Operator,
                Message = o.Message,
                Result = o.Result,
                Type = o.Type,
                Module = o.Module,
                CreateTime = o.CreateTime
            };
            return _;
        }


        public int Create(ViewModels.YTLogViewModel entity)
        {
            SysLog log = new SysLog()
            {
                Id = entity.Id,
                Operator = entity.Operator,
                Message = entity.Message,
                Result = entity.Result,
                Type = entity.Type,
                Module = entity.Module,
                CreateTime = entity.CreateTime
            };
            return logRep.Create(log);
        }
    }
}
