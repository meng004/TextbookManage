﻿using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// 数据标识
    /// 区分本部、船山、成教与国际学院
    /// </summary>
    public class DataSign : AggregateRoot
    {
        public DataSign()
        {
            //不区分
            DataSignId = "0";
            //
            Name = "不区分";

            TeachingTasks = new List<TeachingTask>();
        }
        /// <summary>
        /// 数据标识ID
        /// </summary>
        public string DataSignId { get; set; }
        /// <summary>
        /// 数据标识名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 教学任务集合
        /// </summary>
        public virtual ICollection<TeachingTask> TeachingTasks { get; set; }
    }
}
