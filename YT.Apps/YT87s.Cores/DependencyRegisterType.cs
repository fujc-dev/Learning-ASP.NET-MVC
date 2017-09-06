using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YT87s.Business.Implements;
using YT87s.Business.Service;
using YT87s.Database.Implements;
using YT87s.Database.Service;

namespace YT87s.Cores
{
    public class DependencyRegisterType
    {
        //系统注入
        public static void Container_Sys(ref UnityContainer container)
        {
            container.RegisterType<IYTSimpleBusiness, YTSimpleBusinessImp>();
            container.RegisterType<IYTSimpleRepository, YTSimpleRepositoryImp>();

            container.RegisterType<IYTModuleBusiness, YTModuleBusinessImp>();
            container.RegisterType<IYTModuleRepository, YTModuleRepositoryImp>();

            container.RegisterType<IYTLogBusiness, YTLogBusinessImp>();
            container.RegisterType<IYTLogRepository, YTLogRepositoryImp>();

            container.RegisterType<IYTExceptionBusiness, YTExceptionBusinessImp>();
            container.RegisterType<IYTExceptionRepository, YTExceptionRepositoryImp>();

            container.RegisterType<IYTUserRepository, YTUserRepositoryImp>();
            container.RegisterType<IYTUserBusiness, YTUserBusinessImp>();


        }
    }
}
