using System;

namespace MvcLib
{
    class Program
    {
        /// <summary>
        /// 整个流程目前是由我们的App自己控制，如果要引入Ioc那么我们需要再外面再包一层(暂且将其称为MvcFrame)，
        /// 然后将目前写的这部分解析，构建到<see cref="MvcEngine"/>类中，
        /// 那么我们将App对解析的控制权交由<see cref="MvcFrame"/>处理，那么就在框架中引入了Ioc的概念
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            while (true)
            {
                Uri address = new Uri("http://0.0.0.0:8080/mvcapp");
                await MvcLib.ListenAsync(address);
                while (true)
                {
                    var request = await MvcLib.ReceiveAsync();
                    var controller = await MvcLib.CreateControllerAsync(request);
                    var view = await MvcLib.ExecuteControllerAsync(controller);
                    await MvcLib.RenderViewAsync(view);
                }
            }
        }
    }
}
