using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YT87s.Business.Service;
using YT87s.Common;
using YT87s.ViewModels;

namespace YT.WebUI
{
    public class LogHandler
    {
        [Dependency]
        public static IYTLogBusiness logBusiness { get; set; }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="oper">操作人</param>
        /// <param name="mes">操作信息</param>
        /// <param name="result">结果</param>
        /// <param name="type">类型</param>
        /// <param name="module">操作模块</param>
        public static void WriteServiceLog(string oper, string mes, string result, string type, string module)
        {
            YTLogViewModel entity = new YTLogViewModel();
            entity.Id = ResultHelper.NewId;
            entity.Operator = oper;
            entity.Message = mes;
            entity.Result = result;
            entity.Type = type;
            entity.Module = module;
            entity.CreateTime = ResultHelper.NowTime;
            logBusiness.Create(entity);
        }
    }
}