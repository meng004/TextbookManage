using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_4
{
    public partial class TextbookStockAdd : System.Web.UI.Page
    {
        CPMis.Web.WebClient.ProfileManger profile = new Web.WebClient.ProfileManger(HttpContext.Current.User.Identity.Name);
        CPMis.IBLL.Tb_Maintain.Tb_Maintain_4.IStockAddBLL _StockAddBLL = new CPMis.BLL.Tb_Maintain.Tb_Maintain_4.StockAddBLL();
        CPMis.Model.Tb_Maintain.Tb_Maintain_4.StockModel _StockAddModel = new Model.Tb_Maintain.Tb_Maintain_4.StockModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //书商名绑定数据源
                cdlstBooksellerName.DataSource = _StockAddBLL._GetBookSellerlist();
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
        /// 保存添加的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnSave_Click(object sender, EventArgs e)
        {
            if (_StockAddBLL.Fn_CheckStockNameByStockName(cdlstBooksellerName.SelectedValue, ctxtStockName.Text))
            {
                CPMis.Web.WebClient.ScriptManager.Alert("该书商已存在此仓库，请重新输入仓库名！");
                ctxtStockName.Text = "";
            }
            else
            {
                _StockAddModel.StockName = ctxtStockName.Text;
                _StockAddModel.StockAddress = ctxtStockAddress.Text;
                _StockAddModel.BookSellerName = cdlstBooksellerName.SelectedText;
                _StockAddModel.Telephone = ctxtTelephone.Text;
                _StockAddModel.AccountBeginDate = CPMisDatePicker1.DbSelectedDate.ToString();

                string message = "";                                     //数据库返回信息
                _StockAddBLL.Fn_StockAdd(_StockAddModel, ref message);   //调用BLL层的方法
                CPMis.Web.WebClient.ScriptManager.Alert(message);        //页面弹出添加是否成功的提示框 
                cdlstBooksellerName.Text = _StockAddModel.BookSellerName;  //保存后下拉列表显示刚刚添加的值
            }
            
        }

        /// <summary>
        /// 取消按钮恢复初始页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnCancle_Click(object sender, EventArgs e) 
        {
            ctxtStockName.Text = "";
            ctxtStockAddress.Text = "";
            ctxtTelephone.Text = "";
            CPMisDatePicker1.DbSelectedDate = "";
        }
    }
}