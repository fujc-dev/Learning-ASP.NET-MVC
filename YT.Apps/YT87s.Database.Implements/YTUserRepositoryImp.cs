using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YT87s.Database.Service;
using YT87s.Entities;

namespace YT87s.Database.Implements
{
    public class YTUserRepositoryImp : IYTUserRepository
    {
        public SysUser Login(string username, string pwd)
        {
            using (YT87sEntities db = new YT87sEntities())
            {
                return db.SysUser.SingleOrDefault(a => a.UserName == username && a.Password == pwd);
            }
        }
    }
}
