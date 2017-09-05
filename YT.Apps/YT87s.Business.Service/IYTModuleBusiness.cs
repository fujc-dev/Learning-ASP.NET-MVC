using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YT87s.ViewModels;

namespace YT87s.Business.Service
{
    public interface IYTModuleBusiness
    {
        List<YTModuleViewModel> GetMenuByPersonId(string moduleId);
    }
}
