using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using CPMis.Web.WebControls;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_7
{
    public partial class UpdateBooksellerStaff : System.Web.UI.Page
    {
        CPMis.Web.WebClient.ProfileManger profile = new Web.WebClient.ProfileManger(HttpContext.Current.User.Identity.Name);
        IBLL.Tb_Maintain.Tb_Maintain_7.IBooksellerStaffBLL _booksellerStaffBLL = new BLL.Tb_Maintain.Tb_Maintain_7.BooksellerStaffBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //下拉列表绑定
                ccmbBooksellerName.DataSourceID = "SqlDataSource_Bookseller";
                ccmbBooksellerName.DataBind();
                string booksellerId = profile.UserInGroupID;
                for (int i = 0; i < ccmbBooksellerName.Items.Count; i++)
                {
                    if (ccmbBooksellerName.Items[i].Value == booksellerId)
                    {
                        ccmbBooksellerName.SelectedIndex = i;
                        ccmbBooksellerName.Enabled = false;
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// 查询按钮处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnQuery_Click(object sender, EventArgs e)
        {
            cgrdUpdateBooksellerStaff.DoDataBind();
        }
        /// <summary>
        /// cgrdUpdateBooksellerStaff数据绑定前处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdUpdateBooksellerStaff_OnBeforeDataBind(object sender, EventArgs e)
        {
            cgrdUpdateBooksellerStaff.DataSource = _booksellerStaffBLL.Fn_GetListBooksellerStaff(ccmbBooksellerName.SelectedValue);
        }
        /// <summary>
        /// 删除员工信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            string message = "";
            GridDataItem Item = (GridDataItem)((CPMisLinkButton)sender).Parent.Parent;
            string booksellerStaffId = Item.OwnerTableView.DataKeyValues[Item.ItemIndex]["BooksellerStaffId"].ToString();

            _booksellerStaffBLL.Fn_DeleteBooksellerStaffByBooksellerStaffId(booksellerStaffId,ref message);

            cgrdUpdateBooksellerStaff.DoDataBind();

            CPMis.Web.WebClient.ScriptManager.Alert(message);
        }

        protected void lbtnUpdate_Click(object sender, EventArgs e)
        {
            GridDataItem Item = (GridDataItem)((CPMisLinkButton)sender).Parent.Parent;
            string booksellerStaffId = Item.OwnerTableView.DataKeyValues[Item.ItemIndex]["BooksellerStaffId"].ToString();
            string booksellerName = ccmbBooksellerName.SelectedText;

            string js="OnClientBooksellerStaff('"+booksellerStaffId+"', '"+booksellerName+"')";

            CPMis.Web.WebClient.ScriptManager.ExecuteJs(js);
        }
    }
}