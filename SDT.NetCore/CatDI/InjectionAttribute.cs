/**
 * 简易版的DI框架源码学习，详见<see cref="https://www.cnblogs.com/artech/p/net-core-di-04.html"/>
 */
 using System;

namespace CatDI
{
    [AttributeUsage(AttributeTargets.Constructor)]
    public class InjectionAttribute : Attribute { }
}