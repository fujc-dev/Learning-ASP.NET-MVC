﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YT87s.Entities;

namespace YT87s.Database.Service
{
    public interface IYTSimpleRepository
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>数据列表</returns>
        IQueryable<SysSimple> GetList(YT87sEntities db, ref int total, int page, int rows, string sort, string order);
        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        int Create(SysSimple entity);
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="entity">主键ID</param>
        int Delete(string id);

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        int Edit(SysSimple entity);
        /// <summary>
        /// 获得一个实体
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>实体</returns>
        SysSimple GetById(string id);
        /// <summary>
        /// 判断一个实体是否存在
        /// </summary>
        bool IsExist(string id);
    }
}