/**
 * 简易版的DI框架源码学习，详见<see cref="https://www.cnblogs.com/artech/p/net-core-di-04.html"/>
 */

namespace CatDI
{
    /// <summary>
    /// <see cref="Lifetime"/>枚举代表着三种生命周期模式
    /// </summary>
    public enum Lifetime
    {
        /// <summary>
        ///  在一个容器树中的顶级节点保存一份对象实例，所有的GetService返回的都是相同实例
        /// </summary>
        Root,
        /// <summary>
        /// Self是将提供服务实例保存在当前容器中，它代表针对某个容器的单例模式
        /// </summary>
        Self,
        /// <summary>
        /// Transient代表容器针对每次服务请求都会创建一个新的服务实例，它代表一种“即用即取，用完即弃”的消费方式
        /// </summary>
        Transient
    }
}