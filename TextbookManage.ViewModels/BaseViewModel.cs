using System;

namespace TextbookManage.ViewModels
{

    using System.Runtime.Serialization;

    [Serializable]
    public class BaseViewModel
    {

        #region 属性
        
        /// <summary>
        /// 获得或设置删除标记 
        /// </summary>

        public string DeleteFlag { get; set; }
        /// <summary>
        /// 获得或设置选中状态
        /// </summary>

        public bool CheckFlag { get; set; }
        /// <summary>
        /// 获得或设置是否删除
        /// </summary>

        public bool IsDelete
        {
            get
            {
                return "1" == DeleteFlag;
            }
            set
            {
                DeleteFlag = true == value ? "1" : "0";
            }
        }

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseViewModel()
        {
            DeleteFlag = "0";
            CheckFlag = false;
        }
        #endregion

    }
}
