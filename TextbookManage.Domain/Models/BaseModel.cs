using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// 基础类
    /// </summary>
    public class BaseModel
    {

        public string ID { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public int Num { get; set; }
    }
}
