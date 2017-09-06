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
    public class YTSimpleBusinessImp : IYTSimpleBusiness
    {
        YT87sEntities db = new YT87sEntities();

        IYTSimpleRepository Rep = new YTSimpleRepositoryImp();

        public List<YTSampleViewModel> GetList(int page, int rows, string sort, string order, ref int total)
        {
            IQueryable<SysSimple> queryData = Rep.GetList(db, ref total, page, rows, sort, order);
            return CreateModelList(ref queryData, page, rows, ref total);
        }
        private List<YTSampleViewModel> CreateModelList(ref IQueryable<SysSimple> queryData, int page, int rows, ref int total)
        {

            if (total > 0)
            {
                if (page <= 1)
                {
                    queryData = queryData.Take(rows);
                }
                else
                {
                    queryData = queryData.Skip((page - 1) * rows).Take(rows);
                }
            }
            List<YTSampleViewModel> modelList = new List<YTSampleViewModel>();

            queryData.ToList().ForEach((r) =>
            {
                var _ = new YTSampleViewModel
                                                      {
                                                          Id = r.Id,
                                                          Name = r.Name,
                                                          Age = r.Age,
                                                          Bir = r.Bir,
                                                          Photo = r.Photo,
                                                          Note = r.Note,
                                                          CreateTime = r.CreateTime,

                                                      };
                modelList.Add(_);
            });

            return modelList;
        }

        public bool Create(YTSampleViewModel model)
        {
            try
            {
                SysSimple entity = Rep.GetById(model.Id);
                if (entity != null)
                {
                    return false;
                }
                entity = new SysSimple();
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

        public bool Edit(YTSampleViewModel model)
        {
            try
            {
                SysSimple entity = Rep.GetById(model.Id);
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

        public bool IsExists(string id)
        {
            if (db.SysSimple.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public YTSampleViewModel GetById(string id)
        {
            if (IsExist(id))
            {

                SysSimple entity = Rep.GetById(id);
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

        public bool IsExist(string id)
        {
            return Rep.IsExist(id);
        }


    }
}
