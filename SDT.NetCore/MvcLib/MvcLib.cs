using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MvcLib
{
    /// <summary>
    /// 目标：模拟一个Web的Mvc类库处理浏览器访问URL显示网页
    /// <para>1、启动一个<see cref="ListenAsync"/>监听器，将绑定一个地址进行HTTP的请求监听，直到有请求抵达，理解成Socket的端口监听不知道有没有问题，反正其目的是通过这个端口接收来自浏览器的访问</para>
    /// <para>2、抵达的请求通过<see cref="ReceiveAsync"/>进行接收，其中包含Controller、Action、参数，我们将这些必要信息封装到<see cref="Request"/>对象中</para>
    /// <para>3、根据我们的<see cref="Request"/>匹配指定的<see cref="Controller"/>，然后将该<see cref="Controller"/>对象创建出来</para>
    /// <para>4、当我们匹配到<see cref="Controller"/>并创建出来后，所做的就是执行<see cref="Controller"/>，包裹着参数执行到具体的Action</para>
    /// <para>5、控制器、Action以及相关参数被执行完毕后，就是一个显示页面的操作RenderView</para>
    /// </summary>
    public class MvcLib
    {
        public static Task ListenAsync(Uri address) { throw new NotImplementedException(); }
        public static Task<Request> ReceiveAsync() { throw new NotImplementedException(); }
        public static Task<Controller> CreateControllerAsync(Request request) { throw new NotImplementedException(); }
        public static Task<View> ExecuteControllerAsync(Controller controller) { throw new NotImplementedException(); }
        public static Task RenderViewAsync(View view) { throw new NotImplementedException(); }
    }


}
