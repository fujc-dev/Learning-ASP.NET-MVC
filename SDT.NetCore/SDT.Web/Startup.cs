using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SDT.Web
{
    /// <summary>
    /// <see cref="Startup"/> 类配置服务和应用的请求管道
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 依赖关系注入（服务）
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {

        }

        /// <summary>
        /// 中间件
        /// <para>请求处理管道由一系列中间件组件组成.</para>
        /// <para> 每个组件在 HttpContext 上执行操作，调用管道中的下一个中间件或终止请求。</para>
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
