﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YT87s.Database.Service;
using YT87s.Entities;

namespace YT87s.Database.Implements
{
    public class YTLogRepositoryImp : IYTLogRepository
    {
        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="db">数据库</param>
        /// <returns>集合</returns>
        public IQueryable<SysLog> GetList(YT87sEntities db)
        {
            IQueryable<SysLog> list = db.SysLog.AsQueryable();
            return list;
        }
        /// <summary>
        /// 创建一个对象
        /// </summary>
        /// <param name="db">数据库</param>
        /// <param name="entity">实体</param>
        public int Create(SysLog entity)
        {
            using (YT87sEntities db = new YT87sEntities())
            {
                db.SysLog.Add(entity);
                return db.SaveChanges();
            }

        }

        /// <summary>
        /// 删除对象集合
        /// </summary>
        /// <param name="db">数据库</param>
        /// <param name="deleteCollection">集合</param>
        public void Delete(YT87sEntities db, string[] deleteCollection)
        {
            IQueryable<SysLog> collection = from f in db.SysLog
                                            where deleteCollection.Contains(f.Id)
                                            select f;
            foreach (var deleteItem in collection)
            {
                db.SysLog.Remove(deleteItem);
            }
        }
        /// <summary>
        /// 根据ID获取一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysLog GetById(string id)
        {
            using (YT87sEntities db = new YT87sEntities())
            {
                return db.SysLog.SingleOrDefault(a => a.Id == id);
            }
        }
        public void Dispose()
        {

        }
    }
}
