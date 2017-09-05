using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YT87s.Entities;

namespace YT87s.Database.Service
{
    public interface IYTLogRepository
    {
        int Create(YTLog entity);
        void Delete(YT87sEntities db, string[] deleteCollection);
        IQueryable<YTLog> GetList(YT87sEntities db);
        YTLog GetById(string id);
    }
}
