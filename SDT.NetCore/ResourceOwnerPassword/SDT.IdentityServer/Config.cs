/**
 * 此示例介绍了使用IdentityServer保护API的最基本场景。
 * 
 * 参考资料：https://www.cnblogs.com/jardeng/p/12774193.html
 *              ：https://www.cnblogs.com/haoxiaozhang/p/11727637.html
 *              ：https://www.cnblogs.com/stulzq/p/7495129.html
 */

using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDT.IdentityServer
{

    /// <summary>
    /// IdentityServer4资源和客户端配置文件
    /// </summary>
    public static class Config
    {

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password"
                }
            };
        }

        /// <summary>
        /// API资源集合，<see cref="IdentityServer4.Stores.IResourceStore"/>根据内存中的<see cref="Scope"/> 配置对象集合注册实现。
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }

        /// <summary>
        /// 客户端集合，
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                /**
                 * 客户端模式（ClientCredentials）
                 *      可以将ClientId和ClientSecrets视为应用程序的登录名和密码。
                 *      IdentityServer4将此处定义的<see cref="Client"/>对象标识到身份服务器，
                 *      后续客户端应用程序访问时，IdentityServer4会在服务器进行匹配。
                 */
                new Client
                {
                    ClientId = "ailsabe@126.com",
                    // 无交互用户，使用clientid/secret进行身份验证
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    // 认证秘钥
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    // 客户端有权访问的作用域
                    AllowedScopes = { "api1" }
                }
            };
        }
    }
}
