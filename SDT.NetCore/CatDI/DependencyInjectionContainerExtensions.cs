/**
 * 简易版的DI框架源码学习，详见<see cref="https://www.cnblogs.com/artech/p/net-core-di-04.html"/>
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CatDI
{
    public static class CatExtensions
    {
        public static DependencyInjectionContainer Register(this DependencyInjectionContainer cat, Type from, Type to, Lifetime lifetime)
        {
            Func<DependencyInjectionContainer, Type[], object> factory = (_, arguments) => Create(_, to, arguments);
            cat.Register(new ServiceRegistry(from, lifetime, factory));
            return cat;
        }

        public static DependencyInjectionContainer Register<TFrom, TTo>(this DependencyInjectionContainer cat, Lifetime lifetime) where TTo : TFrom
            => cat.Register(typeof(TFrom), typeof(TTo), lifetime);

        public static DependencyInjectionContainer Register(this DependencyInjectionContainer cat, Type serviceType, object instance)
        {
            Func<DependencyInjectionContainer, Type[], object> factory = (_, arguments) => instance;
            cat.Register(new ServiceRegistry(serviceType, Lifetime.Root, factory));
            return cat;
        }

        public static DependencyInjectionContainer Register<TService>(this DependencyInjectionContainer cat, TService instance)
        {
            Func<DependencyInjectionContainer, Type[], object> factory = (_, arguments) => instance;
            cat.Register(new ServiceRegistry(typeof(TService), Lifetime.Root, factory));
            return cat;
        }

        public static DependencyInjectionContainer Register(this DependencyInjectionContainer cat, Type serviceType,
            Func<DependencyInjectionContainer, object> factory, Lifetime lifetime)
        {
            cat.Register(new ServiceRegistry(serviceType, lifetime, (_, arguments) => factory(_)));
            return cat;
        }

        public static DependencyInjectionContainer Register<TService>(this DependencyInjectionContainer cat,
            Func<DependencyInjectionContainer, TService> factory, Lifetime lifetime)
        {
            cat.Register(new ServiceRegistry(typeof(TService), lifetime, (_, arguments) => factory(_)));
            return cat;
        }

        public static DependencyInjectionContainer Register(this DependencyInjectionContainer cat, Assembly assembly)
        {
            var typedAttributes = from type in assembly.GetExportedTypes()
                                  let attribute = type.GetCustomAttribute<MapToAttribute>()
                                  where attribute != null
                                  select new { ServiceType = type, Attribute = attribute };
            foreach (var typedAttribute in typedAttributes)
            {
                cat.Register(typedAttribute.Attribute.ServiceType, typedAttribute.ServiceType, typedAttribute.Attribute.Lifetime);
            }
            return cat;
        }

        public static DependencyInjectionContainer CreateChild(this DependencyInjectionContainer cat) => new DependencyInjectionContainer(cat);

        public static T GetService<T>(this DependencyInjectionContainer cat) => (T)cat.GetService(typeof(T));

        public static IEnumerable<T> GetServices<T>(this DependencyInjectionContainer cat) => cat.GetService<IEnumerable<T>>();

        private static object Create(DependencyInjectionContainer cat, Type type, Type[] genericArguments)
        {
            if (genericArguments.Length > 0)
            {
                type = type.MakeGenericType(genericArguments);
            }
            var constructors = type.GetConstructors();
            if (constructors.Length == 0)
            {
                throw new InvalidOperationException($"Cannot create the instance of {type} which does not have an public constructor.");
            }
            var constructor = constructors.FirstOrDefault(it => it.GetCustomAttributes(false).OfType<InjectionAttribute>().Any());
            constructor ??= constructors.First();
            var parameters = constructor.GetParameters();
            if (parameters.Length == 0)
            {
                return Activator.CreateInstance(type);
            }
            var arguments = new object[parameters.Length];
            for (int index = 0; index < arguments.Length; index++)
            {
                arguments[index] = cat.GetService(parameters[index].ParameterType);
            }
            return constructor.Invoke(arguments);
        }

    }
}
