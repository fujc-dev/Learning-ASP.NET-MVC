/**
 * 简易版的DI框架源码学习，详见<see cref="https://www.cnblogs.com/artech/p/net-core-di-04.html"/>
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace CatDI
{
    /// <summary>
    /// <see cref="ServiceRegistry"/>描述一个服务注册项对象
    /// </summary>
    public class ServiceRegistry
    {
        /// <summary>
        /// 服务类型
        /// </summary>
        public Type ServiceType { get; }
        /// <summary>
        /// 生命周期模式
        /// </summary>
        public Lifetime Lifetime { get; }
        /// <summary>
        /// 创建服务实例的工厂
        /// </summary>
        public Func<DependencyInjectionContainer, Type[], object> Factory { get; }
        internal ServiceRegistry Next { get; set; }

        /// <summary>
        /// 构建一个 <see cref="ServiceRegistry"/>服务注册项对象
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="lifetime">生命周期模式</param>
        /// <param name="factory">创建服务实例的工厂</param>
        public ServiceRegistry(Type serviceType, Lifetime lifetime, Func<DependencyInjectionContainer, Type[], object> factory)
        {
            ServiceType = serviceType;
            Lifetime = lifetime;
            Factory = factory;
        }

        internal IEnumerable<ServiceRegistry> AsEnumerable()
        {
            var list = new List<ServiceRegistry>();
            for (var self = this; self != null; self = self.Next)
            {
                list.Add(self);
            }
            return list;
        }
    }
}
