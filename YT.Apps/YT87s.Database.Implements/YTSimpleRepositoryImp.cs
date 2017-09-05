using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YT87s.Database.Service;
using YT87s.Entities;

namespace YT87s.Database.Implements
{
    public class YTSimpleRepositoryImp : IYTSimpleRepository, IDisposable
    {
        /// <summary>
        /// 获取列表
        ///</summary>
        /// <param name="db">数据库上下文</param>
        /// <returns>数据列表</returns>
        public IQueryable<YTSimple> GetList(YT87sEntities db, ref int total, int page, int rows, string sort = "Id", string order = "desc")
        {
            IQueryable<YTSimple> list = db.YTSimple.AsQueryable().OrderByDescending(o => sort);
            total = list.Count();
            return list;
        }
        /// <summary>
        /// 创建一个实体
        ///</summary>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">实体</param>
        public int Create(YTSimple entity)
        {
            using (YT87sEntities db = new YT87sEntities())
            {
                db.Set<YTSimple>().Add(entity);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 删除一个实体
        ///</summary>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">主键ID</param>
        public int Delete(string id)
        {
            using (YT87sEntities db = new YT87sEntities())
            {
                YTSimple entity = db.YTSimple.SingleOrDefault(a => a.Id == id);
                db.Set<YTSimple>().Remove(entity);
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// 修改一个实体
        ///</summary>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">实体</param>
        public int Edit(YTSimple entity)
        {
            using (YT87sEntities db = new YT87sEntities())
            {
                db.Set<YTSimple>().Attach(entity);
                db.Entry<YTSimple>(entity).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 获得一个实体
        ///</summary>
        /// <param name="id">id</param>
        /// <returns>实体</returns>
        public YTSimple GetById(string id)
        {
            using (YT87sEntities db = new YT87sEntities())
            {
                return db.YTSimple.SingleOrDefault(a => a.Id == id);
            }
        }
        /// <summary>
        /// 判断一个实体是否存在
        ///        </summary>
        /// <param name="id">id</param>
        /// <returns>是否存在 true or false</returns>
        public bool IsExist(string id)
        {
            using (YT87sEntities db = new YT87sEntities())
            {
                YTSimple entity = GetById(id);
                if (entity != null)
                    return true;
                return false;
            }
        }

        #region IDisposable 实现部分
        public void Dispose()
        {
            // 使用using会自动化调用这个方法
        }
        #endregion
    }
}
