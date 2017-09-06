using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YT87s.Entities;
using YT87s.ViewModels;

namespace YT87s.Business.Service
{
    public interface IYTExceptionBusiness
    {
        List<SysException> GetList(int page, int rows, string sort, string order, ref int total, string queryStr);
        SysException GetById(string id);
    }
}
