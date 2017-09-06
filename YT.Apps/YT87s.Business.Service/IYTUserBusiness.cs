using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YT87s.Entities;

namespace YT87s.Business.Service
{
    public interface IYTUserBusiness
    {
        SysUser Login(string username, string pwd);
    }
}
