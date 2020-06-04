using System;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using Microsoft.Extensions.Options;

namespace SDT.Web
{

    /// <summary>
    /// 创建一个空的ASP.NET Core3.1的Web空项目，包含4个文件
    ///  <para>1、<see cref = "Program" />.cs</para>
    ///  <para>2、<see cref = "Startup" />.cs</para>
    ///  <para>3、appsettings.json</para>
    ///  <para>4、appsettings.Development.json</para>
    ///  <para>编译并成功运行开Web项目，从bin/debug文件中看到也只有一个SDT.Web的DLL文件以及相关的json文件，这一个Web系统太轻量级级了</para>
    /// <para></para>
    /// 
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
        }

    }
}
