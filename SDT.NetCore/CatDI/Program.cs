/**
 * 简易版的DI框架源码学习，详见<see cref="https://www.cnblogs.com/artech/p/net-core-di-04.html"/>
 */
using System;
using System.Reflection;

namespace CatDI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var root = new DependencyInjectionContainer()
                .Register<IFoo, Foo>(Lifetime.Transient)
                .Register<IBar>(_ => new Bar(), Lifetime.Self)
                .Register<IBaz, Baz>(Lifetime.Root)
                .Register(Assembly.GetEntryAssembly()))
            {

                using (var cat = root.CreateChild())
                {
                    cat.GetService<IFoo>();
                    cat.GetService<IFoo>();
                    cat.GetService<IFoo>();
                    cat.GetService<IFoo>();
                }
                using (var cat = root.CreateChild())
                {
                    cat.GetService<IFoo>();
                    cat.GetService<IFoo>();
                    cat.GetService<IFoo>();
                    cat.GetService<IFoo>();
                }
            }
        }
    }
}
