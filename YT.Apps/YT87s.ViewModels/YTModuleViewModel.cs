using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YT87s.ViewModels
{
    public class YTModuleViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public string ParentId { get; set; }
        public string Url { get; set; }
        public string Iconic { get; set; }
        public Nullable<int> Sort { get; set; }
        public string Remark { get; set; }
        public Nullable<bool> State { get; set; }
        public string CreatePerson { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public bool IsLast { get; set; }
        public byte[] Version { get; set; }
    }
}
