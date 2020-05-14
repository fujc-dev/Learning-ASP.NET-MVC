/**
 * 简易版的DI框架源码学习，详见<see cref="https://www.cnblogs.com/artech/p/net-core-di-04.html"/>
 */
 using System;

namespace CatDI
{
    internal class Key : IEquatable<Key>
    {
        public ServiceRegistry Registry { get; }
        public Type[] GenericArguments { get; }

        public Key(ServiceRegistry registry, Type[] genericArguments)
        {
            Registry = registry;
            GenericArguments = genericArguments;
        }

        public bool Equals(Key other)
        {
            if (Registry != other.Registry)
            {
                return false;
            }
            if (GenericArguments.Length != other.GenericArguments.Length)
            {
                return false;
            }
            for (int index = 0; index < GenericArguments.Length; index++)
            {
                if (GenericArguments[index] != other.GenericArguments[index])
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = Registry.GetHashCode();
            for (int index = 0; index < GenericArguments.Length; index++)
            {
                hashCode ^= GenericArguments[index].GetHashCode();
            }
            return hashCode;
        }
        public override bool Equals(object obj) => obj is Key key ? Equals(key) : false;
    }

}