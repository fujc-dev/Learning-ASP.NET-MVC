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
        int Create(SysLog entity);
        void Delete(YT87sEntities db, string[] deleteCollection);
        IQueryable<SysLog> GetList(YT87sEntities db);
        SysLog GetById(string id);
    }
}
