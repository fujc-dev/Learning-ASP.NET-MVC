using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YT87s.Business.Service;
using YT87s.Database.Implements;
using YT87s.Database.Service;
using YT87s.Entities;
using YT87s.ViewModels;

namespace YT87s.Business.Implements
{
    public class YTSampleBusinessImp : IYTSampleBusiness
    {
        YT87sEntities db = new YT87sEntities();

        IYTSampleRepository Rep = new YTSampleRepositoryImp();

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pager">JQgrid分页</param>
        /// <param name="queryStr">搜索条件</param>
        /// <returns>列表</returns>
        public List<YTSampleViewModel> GetList(string queryStr)
        {

            List<YTSampleViewModel> listResult = new List<YTSampleViewModel>();

            this.Rep.GetList(db).ToList().ForEach((o) =>
            {
                var _ = new YTSampleViewModel()
                {
                    Id = o.Id,
                    Age = o.Age,
                    Bir = o.Bir,
                    CreateTime = o.CreateTime,
                    Name = o.Name,
                    Note = o.Note,
                    Photo = o.Photo
                };
                listResult.Add(_);
            });
            return listResult;
        }

        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="errors">持久的错误信息</param>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public bool Create(YTSampleViewModel model)
        {
            try
            {
                YTSample entity = Rep.GetById(model.Id);
                if (entity != null)
                {
                    return false;
                }
                entity = new YTSample();
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Age = model.Age;
                entity.Bir = model.Bir;
                entity.Photo = model.Photo;
                entity.Note = model.Note;
                entity.CreateTime = model.CreateTime;

                if (Rep.Create(entity) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //ExceptionHander.WriteException(ex);
                return false;
            }
        }
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="errors">持久的错误信息</param>
        /// <param name="id">id</param>
        /// <returns>是否成功</returns>
        public bool Delete(string id)
        {
            try
            {
                if (Rep.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //ExceptionHander.WriteException(ex);
                return false;
            }
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="errors">持久的错误信息</param>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public bool Edit(YTSampleViewModel model)
        {
            try
            {
                YTSample entity = Rep.GetById(model.Id);
                if (entity == null)
                {
                    return false;
                }
                entity.Name = model.Name;
                entity.Age = model.Age;
                entity.Bir = model.Bir;
                entity.Photo = model.Photo;
                entity.Note = model.Note;
                if (Rep.Edit(entity) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                //ExceptionHander.WriteException(ex);
                return false;
            }
        }
        /// <summary>
        /// 判断是否存在实体
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns>是否存在</returns>
        public bool IsExists(string id)
        {
            if (db.YTSample.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 根据ID获得一个实体
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>实体</returns>
        public YTSampleViewModel GetById(string id)
        {
            if (IsExist(id))
            {

                YTSample entity = Rep.GetById(id);
                YTSampleViewModel model = new YTSampleViewModel();
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.Age = entity.Age;
                model.Bir = entity.Bir;
                model.Photo = entity.Photo;
                model.Note = entity.Note;
                model.CreateTime = entity.CreateTime;

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 判断一个实体是否存在
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>是否存在 true or false</returns>
        public bool IsExist(string id)
        {
            return Rep.IsExist(id);
        }
    }
}
