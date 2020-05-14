/**
 * 简易版的DI框架源码学习，详见<see cref="https://www.cnblogs.com/artech/p/net-core-di-04.html"/>
 */
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;



namespace CatDI
{
    /// <summary>
    /// 为了便于理解，我将之前的<c>[Cat]</c>类名修改为<see cref="DependencyInjectionContainer"/>，表示这个类为一个依赖注入的容器
    /// <para>1、所有的注册对象保存在根容器的<see cref="ConcurrentDictionary{Type, ServiceRegistry}"/>中</para>
    /// <para>2、生命周期为<see cref="Lifetime.Root"/>时，所有的实例保存在跟容器的<see cref="_services"/>变量中</para>
    /// <para>3、生命周期为<see cref="Lifetime.Self"/>时，其对象实例保存在当前的容器节点中，并且改对象标记为可释放</para>
    /// <para>4、生命周期为<see cref="Lifetime.Transient"/>时，同上</para>
    /// <para>
    ///     <see cref="DependencyInjectionContainer"/>容器是一个层级容器（也可以理解为树形容器），有顶级节点、子节点等多层结构，
    ///     那么，生命周期指的是在这个众多容器容器树中，从那个一个容器节点取对象，生命周期就影响这对象的。
    /// </para>
    /// <para>
    ///     例子：有一个容器树为 A -> A1、A2 -> A11、A12、A21、A22，在这个树形的容器中我们有7个容器，</para>
    /// <para>   A</para>
    /// <para>    |---A1</para>
    /// <para>    |     |-----A11</para>
    /// <para>    |     |-----A22</para>
    /// <para>    |---A2</para>
    /// <para>          |-----A11</para>
    /// <para>          |-----A22</para>
    /// <para>1、现在有S1服务，在这7个容器中的任意一个容器注册S1服务，所有的容器都可以通过GetService的方式获取对象实例</para>
    /// <para>2、当S1服务的生命周期为<see cref="Lifetime.Root"/>时，在这7个容器中访问返回的对象实例都为统一个实例</para>
    /// <para>3、当S1服务的生命周期为<see cref="Lifetime.Self"/>时，在每个容器内内部的每一次获取的实例都是一致的</para>
    /// <para>4、当S1服务的生命周期为<see cref="Lifetime.Transient"/>时，在每个容器内内部的每一次获取都是最新的</para>
    /// </summary>
    public class DependencyInjectionContainer : IServiceProvider, IDisposable
    {
        /// <summary>
        /// 作为根容器的Cat对象通过_root字段表示
        /// </summary>
        internal readonly DependencyInjectionContainer _root;
        /// <summary>
        /// _registries字段返回的一个ConcurrentDictionary<Type, ServiceRegistry>对象表示所有添加的服务注册，
        /// 字典对象的Key和Value分别表示服务类型和ServiceRegistry链表
        /// </summary>
        internal readonly ConcurrentDictionary<Type, ServiceRegistry> _registries;
        /// <summary>
        /// 由当前<see cref="DependencyInjectionContainer"/>对象提供的非<see cref="Lifetime.Transient"/>服务实例保存在由_services字段表示的一个
        /// <see cref="ConcurrentDictionary{ServiceRegistry, object}"/>对象上，该字典对象的Key表示创建服务实例所使用的<see cref="ServiceRegistry"/>对象
        /// </summary>
        private readonly ConcurrentDictionary<Key, object> _services;
        /// <summary>
        /// 实现了IDisposable接口的服务实例保存在_disposables字段表示的集合中，一般会存储声明周期为Self、Transient的标记
        /// </summary>
        private readonly ConcurrentBag<IDisposable> _disposables;
        /// <summary>
        /// 
        /// </summary>
        private volatile bool _disposed;

        /// <summary>
        /// 构造函数，构建一个有效且为空的<see cref="DependencyInjectionContainer"/>依赖注入容器
        /// </summary>
        public DependencyInjectionContainer()
        {
            _registries = new ConcurrentDictionary<Type, ServiceRegistry>();
            _root = this;
            _services = new ConcurrentDictionary<Key, object>();
            _disposables = new ConcurrentBag<IDisposable>();
        }

        /// <summary>
        /// 内部构造函数，提供给子级的
        /// </summary>
        /// <param name="parent"></param>
        internal DependencyInjectionContainer(DependencyInjectionContainer parent)
        {
            _root = parent._root;
            _registries = _root._registries;
            _services = new ConcurrentDictionary<Key, object>();
            _disposables = new ConcurrentBag<IDisposable>();
        }

        private void EnsureNotDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("DependencyInjectionContainer");
            }
        }

        /// <summary>
        /// 注册对象实例到容器中
        /// </summary>
        /// <param name="registry"></param>
        /// <returns></returns>
        public DependencyInjectionContainer Register(ServiceRegistry registry)
        {
            //
            EnsureNotDisposed();

            if (_registries.TryGetValue(registry.ServiceType, out var existing))
            {
                _registries[registry.ServiceType] = registry;
                registry.Next = existing;
            }
            else
            {
                _registries[registry.ServiceType] = registry;
            }
            return this;
        }

        /// <summary>
        /// 获取一个有效的对象实例
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            EnsureNotDisposed();

            if (serviceType == typeof(DependencyInjectionContainer) || serviceType == typeof(IServiceProvider))
            {
                return this;
            }

            ServiceRegistry registry;
            //IEnumerable<T>
            if (serviceType.IsGenericType && serviceType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                var elementType = serviceType.GetGenericArguments()[0];
                if (!_registries.TryGetValue(elementType, out registry))
                {
                    return Array.CreateInstance(elementType, 0);
                }

                var registries = registry.AsEnumerable();
                var services = registries.Select(it => GetServiceCore(it, Type.EmptyTypes)).ToArray();
                Array array = Array.CreateInstance(elementType, services.Length);
                services.CopyTo(array, 0);
                return array;
            }

            //Generic
            if (serviceType.IsGenericType && !_registries.ContainsKey(serviceType))
            {
                var definition = serviceType.GetGenericTypeDefinition();
                return _registries.TryGetValue(definition, out registry)
                    ? GetServiceCore(registry, serviceType.GetGenericArguments())
                    : null;
            }

            //Normal
            return _registries.TryGetValue(serviceType, out registry)
                    ? GetServiceCore(registry, new Type[0])
                    : null;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            _disposed = true;
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
            _disposables.Clear();
            _services.Clear();
        }

        /// <summary>
        /// 获取服务实例的核心方法
        /// </summary>
        /// <param name="registry"></param>
        /// <param name="genericArguments"></param>
        /// <returns></returns>
        private object GetServiceCore(ServiceRegistry registry, Type[] genericArguments)
        {
            var key = new Key(registry, genericArguments);
            var serviceType = registry.ServiceType;

            switch (registry.Lifetime)
            {
                case Lifetime.Root: return GetOrCreate(_root._services, _root._disposables);
                case Lifetime.Self: return GetOrCreate(_services, _disposables);
                default:
                    {
                        var service = registry.Factory(this, genericArguments);
                        if (service is IDisposable disposable && disposable != this)
                        {
                            _disposables.Add(disposable);
                        }
                        return service;
                    }
            }

            object GetOrCreate(ConcurrentDictionary<Key, object> services, ConcurrentBag<IDisposable> disposables)
            {
                if (services.TryGetValue(key, out var service))
                {
                    return service;
                }
                service = registry.Factory(this, genericArguments);
                services[key] = service;
                if (service is IDisposable disposable)
                {
                    disposables.Add(disposable);
                }
                return service;
            }
        }
    }
}