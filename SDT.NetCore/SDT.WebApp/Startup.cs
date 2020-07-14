using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace SDT.WebApp
{
    /// <summary>
    /// <see cref="Startup"/>类可用来定义请求处理管道和配置应用需要的服务。
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Asp.Net Core自带的依赖注入容器<see cref="IServiceCollection"/>
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            //Session是基于分布式缓存创建的，在配置Session之前要先配置DistributedCache
            services.AddDistributedMemoryCache();
            services.AddSession((options => options.IdleTimeout = TimeSpan.FromSeconds(10)));
        }

        /// <summary>
        ///  用于配置中间件
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            //默认文档服务，请求文件夹的时候将检索以下文件：default.htm、default.html、index.htm、index.html
            app.UseDefaultFiles();
            //可以理解为有权限访问wwwroot下的静态资源文件
            app.UseStaticFiles();
            //路由中间件
            app.UseRouting();
            //
            app.UseAuthentication();
            //
            app.UseAuthorization();
            //
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
