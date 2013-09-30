using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Linq;

namespace TextbookManage.WebControls
{

    public class TbGrid : RadGrid
    {

        #region 属性

        /// <summary>
        /// 获得或设置数据源
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
        /// Checkbox控件的ID
        /// </summary>
        public string CheckControlID { get; set; }

        #endregion

        #region CheckBox

        /// <summary>
        /// 设置当前页的Check状态
        /// 全选或全不选
        /// </summary>
        /// <param name="isChecked"></param>
        public void SetCheckStateOfCurrentPage(bool isChecked)
        {
            foreach (GridDataItem gdItem in MasterTableView.Items)
            {
                SetCheckStateOfItem(isChecked, gdItem.ItemIndex);  
            }
        }

        /// <summary>
        /// 设置单行的选中状态
        /// </summary>
        /// <param name="isChecked"></param>
        /// <param name="rowIndex"></param>
        public void SetCheckStateOfItem(bool isChecked, int itemIndex)
        {
            IList<object> objDataSource = DataSource as IList<object>;
            if (objDataSource == null)
            {
                return;
            }

            GridDataItem gdItem = MasterTableView.Items[itemIndex];
            
            CheckBox chk = gdItem.FindControl(CheckControlID) as CheckBox;//检查每一行的checkbox列
            if (chk.Enabled && chk.Checked != isChecked)//如果不能选，则不算
            {
                //设置数据项的CheckFlag属性值
                objDataSource[gdItem.DataSetIndex].GetType()
                    .GetProperty("CheckFlag")
                    .SetValue(objDataSource[gdItem.DataSetIndex], isChecked, null);

                //设置CheckBox选中状态
                chk.Checked = isChecked;
                //设置Grid行选中状态
                gdItem.Selected = isChecked;
            }

            chk.Dispose();
        }

        /// <summary>
        /// 持久化checkBox的选中状态
        /// </summary>
        public void PersistCheckState()
        {
            var objDataSource = DataSource as IList<object>;
            CheckBox chk = new CheckBox();

            foreach (GridDataItem item in Items)
            {
                chk = item.FindControl(CheckControlID) as CheckBox;
                objDataSource[item.DataSetIndex].GetType().GetProperty("CheckFlag").SetValue(objDataSource[item.DataSetIndex], chk.Checked, null);
                item.Selected = chk.Checked;
            }
            DataSource = objDataSource;
            chk.Dispose();
        }

        #endregion

        #region 取数据

        /// <summary>
        /// 获得指定行的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="offsetIndex"></param>
        /// <returns></returns>
        public T GetData<T>(int rowIndex)
        {
            //对于分页的处理
            int offSet = MasterTableView.CurrentPageIndex * MasterTableView.PageSize;
            object objDataSourse = DataSource;
            if (objDataSourse is IList<T>)
                return (objDataSourse as IList<T>)[rowIndex + offSet];
            else
                return default(T);
        }



        /// <summary>
        /// 取全部选中数据项
        /// </summary>
        /// <returns></returns>
        public IList<object> GetCheckedItems()
        {
            return GetItemsByCheck(true);
        }

        /// <summary>
        /// 取全部未选中数据项
        /// </summary>
        /// <returns></returns>
        public IList<object> GetNotCheckedItems()
        {
            return GetItemsByCheck(false);
        }

        /// <summary>
        /// 根据Check值，取数据项
        /// </summary>
        /// <param name="checkValue">CheckBox的值</param>
        /// <returns></returns>
        private IList<object> GetItemsByCheck(bool checkValue)
        {
            //持久化Check状态
            PersistCheckState();

            var objDataSource = DataSource as IList<object>;
            var rtnDataList = new List<object>();

            if (objDataSource == null)
            {
                return rtnDataList;
            }

            foreach (var item in objDataSource)
            {
                bool isSelected = (bool)item.GetType().GetProperty("CheckFlag").GetValue(item, null);
                if (isSelected == checkValue)
                {
                    rtnDataList.Add(item);
                }
            }
            return rtnDataList;
        }

 
        /// <summary>
        /// 取当前页中选中项
        /// </summary>
        /// <returns></returns>
        public IList<object> GetCheckedItemsOfCurrentPage()
        {
            return GetItemsOfCurrentPageByCheck(true);
        }

        /// <summary>
        /// 取当前页中未选中项
        /// </summary>
        /// <returns></returns>
        public IList<object> GetNotCheckedItemsOfCurrentPage()
        {
            return GetItemsOfCurrentPageByCheck(false);
        }

        /// <summary>
        /// 根据Check值，取当前页中数据项
        /// </summary>
        /// <param name="checkValue"></param>
        /// <returns></returns>
        private IList<object> GetItemsOfCurrentPageByCheck(bool checkValue)
        {
            IList<object> rtnDataList = new List<object>();
            CheckBox chk = new CheckBox();
            foreach (GridDataItem item in Items)
            {
                chk = item.FindControl(CheckControlID) as CheckBox;
                if (chk.Enabled && chk.Checked == checkValue)
                {
                    rtnDataList.Add(item.DataItem);
                }
            }
            chk.Dispose();
            return rtnDataList;
        }


        #endregion

    }
}
