/**
 * 简易版的DI框架源码学习，详见<see cref="https://www.cnblogs.com/artech/p/net-core-di-04.html"/>
 */
using System;

namespace CatDI
{
    /// <summary>
    /// 通过<see cref="Attribute"/>的方式为对象配置生命周期
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class MapToAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public Type ServiceType { get; }
        /// <summary>
        /// 生命周期
        /// </summary>
        public Lifetime Lifetime { get; }

        public MapToAttribute(Type serviceType, Lifetime lifetime)
        {
            ServiceType = serviceType;
            Lifetime = lifetime;
        }

        public MapToAttribute(Type serviceType)
        {
            ServiceType = serviceType;
            Lifetime = Lifetime.Root;
        }
    }
}