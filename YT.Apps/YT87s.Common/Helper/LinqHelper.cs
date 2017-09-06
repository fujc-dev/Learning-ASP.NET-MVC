using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YT87s.Common
{
    /// <summary>
    /// LINQ表达式帮助类
    /// </summary>
    public class LinqHelper
    {
        /**
         * 在做多条件查询时，EF的LINQ表达式组装查询条件没有SQL语句那么直接和暴力，
         * 我们需要编写LINQ Expression来完成构建查询条件
         * eg：select * from tab where 1=1 and f1=1 and f2=2 ....
         */


        /// <summary>
        /// 组装排序
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="field">排序字段</param>
        /// <param name="direction">排序方式</param>
        /// <returns></returns>
        public IQueryable<T> ToSort<T>(IQueryable<T> source, string field, Direction direction)
        {
            String sortingDir = "OrderBy";
            //构建排序字段参数
            ParameterExpression param = Expression.Parameter(typeof(T), field);
            //我们在传入的类型中找出我们需要进行排序的字段
            PropertyInfo pi = typeof(T).GetProperty(field);
            Type[] types = new Type[2];
            types[0] = typeof(T);
            types[1] = pi.PropertyType;
            //构建表达式
            Expression expr = Expression.Call(typeof(Queryable), sortingDir, types, source.Expression, Expression.Lambda(Expression.Property(param, field), param));
            return source.AsQueryable().Provider.CreateQuery<T>(expr);
        }
    }
}
