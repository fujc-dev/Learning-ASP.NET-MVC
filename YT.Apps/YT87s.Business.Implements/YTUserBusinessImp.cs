using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YT87s.Business.Service;
using YT87s.Database.Service;

namespace YT87s.Business.Implements
{
    public class YTUserBusinessImp : IYTUserBusiness
    {
        [Dependency]
        public IYTUserRepository userRep { get; set; }
        public Entities.SysUser Login(string username, string pwd)
        {
            return userRep.Login(username, pwd);
        }
    }
}
