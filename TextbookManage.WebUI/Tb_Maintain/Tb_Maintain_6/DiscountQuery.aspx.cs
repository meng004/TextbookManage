using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPMis.IBLL.Tb_Maintain.Tb_Maintain_6;
using CPMis.BLL.Tb_Maintain.Tb_Maintain_6;
using CPMis.Model.Tb_Maintain.Tb_Maintain_6;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_6
{
    public partial class DiscountQuery : System.Web.UI.Page
    {
      
        CPMis.Web.WebClient.ProfileManger profile = new Web.WebClient.ProfileManger(HttpContext.Current.User.Identity.Name);
        private IDiscountMaintainBLL _discountMaintainBLL = new DiscountMaintainBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            //页面第一次加载
            if (!IsPostBack)
            {
                //grid数据绑定
                cdgrdList.DataSource = null;
                cdlstBooksellerName.DataSourceID = "SqlDataSource3";
                cdlstBooksellerName.DataBind();
                string booksellerId = profile.UserInGroupID;
                for (int i = 0; i < cdlstBooksellerName.Items.Count; i++)
                {
                    if (cdlstBooksellerName.Items[i].Value == booksellerId)
                    {
                        cdlstBooksellerName.SelectedIndex = i;
                        cdlstBooksellerName.Enabled = false;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 点击查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnQuery_Click(object sender, EventArgs e)
        {
            cdgrdList.DoDataBind();
        }


        #region 下拉列表联动

        /// <summary>
        /// cdlstBooksellerName呈现之前绑定cdlstStockName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cdlstBooksellerName_PreRender(object sender, EventArgs e)
        {
            cdlstStockName.DataSource = _discountMaintainBLL.Fn_GetStockInfoByBooksellerID(cdlstBooksellerName.SelectedValue);
            cdlstStockName.DataBind();
            cdlstStockName.DataTextField = "StockName";
        }


        #endregion
        

        #region Ajax分页
        /// <summary>
        /// grid绑定之前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cdgrdList_BeforeDataBind(object sender, EventArgs e)
        {
            //执行查询，返回操作结果
            int totalCount = 0;
            cdgrdList.DataSource = _discountMaintainBLL.Fn_DiscountGetList(cdlstTerm.SelectedText, cdlstBooksellerName.SelectedText, cdlstStockName.SelectedText, ctxtTextbookName.Text, cdgrdList.PageSize, cdgrdList.CurrentPageIndex+1, ref totalCount);
            cdgrdList.VirtualItemCount = totalCount;
        }


        /// <summary>
        /// 换页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cdgrdList_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            int totalCount = 0;
            cdgrdList.DataSource = _discountMaintainBLL.Fn_DiscountGetList(cdlstTerm.SelectedText, cdlstBooksellerName.SelectedText, cdlstStockName.SelectedText, ctxtTextbookName.Text, cdgrdList.PageSize,  e.NewPageIndex + 1, ref totalCount);
            cdgrdList.VirtualItemCount = totalCount;
        }


        /// <summary>
        /// 改变每页数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cdgrdList_PageSizeChanged(object sender, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
        {
            int totalCount = 0;
            cdgrdList.DataSource = _discountMaintainBLL.Fn_DiscountGetList(cdlstTerm.SelectedText, cdlstBooksellerName.SelectedText, cdlstStockName.SelectedText, ctxtTextbookName.Text, cdgrdList.PageSize, cdgrdList.CurrentPageIndex + 1, ref totalCount);
            cdgrdList.VirtualItemCount = totalCount;
        }


        #endregion


        #region 删除

        protected void cdgrdList_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            //删除
            if (e.CommandName == "delete")
            {
                string id = e.CommandArgument.ToString();
                string message = string.Empty;
                _discountMaintainBLL.Fn_DeleteDiscountById(id, ref message);
                CPMis.Web.WebClient.ScriptManager.Alert(message);
                cdgrdList.DoDataBind();
            }
        }

        #endregion

    }
}