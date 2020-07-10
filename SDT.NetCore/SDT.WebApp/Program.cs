using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SDT.WebApp
{
    public class Program
    {
        /// <summary>
        /// 1、ASP.NET CORE 启动流程源码分析
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //方法创建了一个IHostBuilder 抽象对象
            IHostBuilder hostBuilder = CreateHostBuilder(args);
            //负责创建IHost
            IHost host = hostBuilder.Build();
            //启动IHost
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            //创建默认的通用主机Host建造者
            IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args);
            //构建通用主机的默认配置
            hostBuilder.ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
            return hostBuilder;
        }

    }
}
