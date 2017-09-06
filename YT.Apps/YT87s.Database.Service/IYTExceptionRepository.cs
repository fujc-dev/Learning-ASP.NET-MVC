using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YT87s.Entities;

namespace YT87s.Database.Service
{
    public interface IYTExceptionRepository
    {
        int Create(SysException entity);
        IQueryable<SysException> GetList(YT87sEntities db);
        SysException GetById(string id);
    }
}
