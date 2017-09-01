using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YT87s.Entities;
using YT87s.ViewModels;

namespace YT87s.Business.Service
{
    public interface IYTSampleBusiness
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pager">JQgrid分页</param>
        /// <param name="queryStr">搜索条件</param>
        /// <returns>列表</returns>
        List<YTSampleViewModel> GetList(string queryStr);

        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="errors">持久的错误信息</param>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        bool Create(YTSampleViewModel entity);

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="errors">持久的错误信息</param>
        /// <param name="id">id</param>
        /// <returns>是否成功</returns>
        bool Delete(string id);

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="errors">持久的错误信息</param>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        bool Edit(YTSampleViewModel entity);


        /// <summary>
        /// 判断是否存在实体
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns>是否存在</returns>
        bool IsExists(string id);

        /// <summary>
        /// 根据ID获得一个实体
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>实体</returns>
        YTSampleViewModel GetById(string id);


        /// <summary>
        /// 判断一个实体是否存在
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>是否存在 true or false</returns>
        bool IsExist(string id);
    }
}
