/**
 * 简易版的DI框架源码学习，详见<see cref="https://www.cnblogs.com/artech/p/net-core-di-04.html"/>
 */
 using System;
using System.Collections.Generic;
using System.Text;

namespace CatDI
{
    public class ServiceRegistry
    {
        public Type ServiceType { get; }
        public Lifetime Lifetime { get; }
        public Func<DependencyInjectionContainer, Type[], object> Factory { get; }
        internal ServiceRegistry Next { get; set; }

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
