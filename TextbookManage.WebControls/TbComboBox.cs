using System;
using System.Collections.Generic;


namespace TextbookManage.WebControls
{
    public class TbComboBox : Telerik.Web.UI.RadComboBox
    {

        #region 属性

        /// <summary>
        /// 获取或设置数据源
        /// </summary>
        public new object DataSource
        {
            get
            {
                return ViewState["dataSource"];
            }
            set
            {
                base.DataSource = ViewState["dataSource"] = value;
            }
        }

        /// <summary>
        /// 获取或设置当前数据选择项的文本
        /// </summary>
        public string SelectedText
        {
            get
            {
                if (null != base.SelectedItem)
                    return base.SelectedItem.Text;
                return string.Empty;
            }
            set
            {
                Telerik.Web.UI.RadComboBoxItem listItem = base.FindItemByText(value);
                if (null != listItem)
                    base.SelectedValue = listItem.Value;
                else
                    base.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 获取或设置当前数据选择项的文本
        /// </summary>
        public string SelectedValue
        {
            get
            {
                if (null != base.SelectedItem)
                    return base.SelectedItem.Value;
                return string.Empty;
            }
            set
            {
                Telerik.Web.UI.RadComboBoxItem listItem = base.FindItemByValue(value);
                if (null != listItem)
                    base.SelectedValue = listItem.Value;
                else
                    base.SelectedIndex = 0;
            }
        }

        /// <summary>
        ///  是否保持上次选择项的值
        /// </summary>
        public bool IsMaintainSelectedValue { get; set; }

        /// <summary>
        /// 获取或设置默认的数据选择项的位置
        /// </summary>
        public int DefaultIndex { get; set; }

        /// <summary>
        /// 获取或设置数据源对象绑定字段
        /// </summary>
        public string DataValueField2 { get; set; }

        /// <summary>
        /// 获取或设置默认的数据选择项的文本
        /// </summary>
        public string DefaultText { get; set; }
        #endregion

        #region 数据方法

        /// <summary>
        /// 获得当前选择项数据
        /// </summary>
        public T GetData<T>()
        {
            return GetData<T>(SelectedIndex);
        }

        /// <summary>
        /// 根据下标获得数据
        /// </summary>		
        public T GetData<T>(int index)
        {
            object obj = DataSource;
            if (obj is IList<T>)
                return (obj as IList<T>)[index];
            throw new Exception("获取数据异常！");
        }

        #endregion

        #region 选项Item操作

        /// <summary>
        /// 添加选项
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="value">值</param>
        public void AddItem(string text, string value)
        {
            Telerik.Web.UI.RadComboBoxItem item = new Telerik.Web.UI.RadComboBoxItem(text, value);
            Items.Add(item);
        }

        /// <summary>
        /// 插入选项
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="value">值</param>
        /// <param name="index">索引位置</param>
        public void InsertItem(string text, string value, int index)
        {
            Telerik.Web.UI.RadComboBoxItem item = new Telerik.Web.UI.RadComboBoxItem(text, value);
            Items.Insert(index, item);
        }

        /// <summary>
        /// 清空所有的项
        /// </summary>
        public void Clear()
        {
            Items.Clear();
        }
        #endregion

    }
}
