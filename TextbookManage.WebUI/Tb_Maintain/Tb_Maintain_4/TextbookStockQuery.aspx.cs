using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_4
{
    public partial class TextbookStockQuery : System.Web.UI.Page
    {
        CPMis.Web.WebClient.ProfileManger profile = new Web.WebClient.ProfileManger(HttpContext.Current.User.Identity.Name);
        private CPMis.IBLL.Tb_Maintain.Tb_Maintain_4.IGetStockDetailBLL _GetStockDetailBLL = new CPMis.BLL.Tb_Maintain.Tb_Maintain_4.GetStockDetailBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //书商名下拉列表绑定数据源
                cdlstBookSellerName.DataSource = _GetStockDetailBLL.Fn_GetBooksellerList();
                cdlstBookSellerName.DataBind();
                //cdlstBookSellerName.InsertListItem(0, "----全部----", "全部");
                string booksellerId = profile.UserInGroupID;
                for (int i = 0; i < cdlstBookSellerName.Items.Count; i++)
                {
                    if (cdlstBookSellerName.Items[i].Value == booksellerId)
                    {
                        cdlstBookSellerName.SelectedIndex = i;
                        cdlstBookSellerName.Enabled = false;
                        return;
                    }
                }
                cgrdStockQuery.DoDataBind();
            }
        }
       

        protected void cbntQuery_Click(object sender, EventArgs e)
        {
            //gridview数据绑定
            cgrdStockQuery.DoDataBind();
        }

        protected void cgrdStockQuery_BeforeDataBind(object sender, EventArgs e)
        {                        
            //获取gridview数据源
            cgrdStockQuery.DataSource = _GetStockDetailBLL.Fn_GetStockDetail(cdlstBookSellerName.SelectedValue);
        }

        /// <summary>
        /// 点击删除按钮删除仓库全部信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdDelete_Click(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string message = "";
            string name = e.CommandName;
            GridDataItem dataItem = e.Item as GridDataItem;
            if (name == "Delete_Click")
            {
                string ID = dataItem["StockID"].Text.ToString();//获取仓库ID
                message = _GetStockDetailBLL.Fn_DeleteStockDetail(ID);
                CPMis.Web.WebClient.ScriptManager.Alert(message);
            }
            cgrdStockQuery.DoDataBind();//删除后刷新gridview          
        }
    }
}