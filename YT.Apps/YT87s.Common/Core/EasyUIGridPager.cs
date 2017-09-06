using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YT87s.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class EasyUIGridPager
    {
        /// <summary>
        /// 每页行数
        /// </summary>
        public int rows { get; set; }
        /// <summary>
        /// 页码索引
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 排序方式
        /// </summary>
        public string order { get; set; }
        /// <summary>
        /// 排序列
        /// </summary>
        public string sort { get; set; }
        /// <summary>
        /// 总行数
        /// </summary>
        public int totalRows;

        public int totalPages //总页数
        {
            get
            {
                return (int)Math.Ceiling((float)totalRows / (float)rows);
            }
        }
    }
}
