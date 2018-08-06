using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Text.RegularExpressions;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_4
{
    public partial class TextbookStockUpdate : System.Web.UI.Page
    {
        private CPMis.IBLL.Tb_Maintain.Tb_Maintain_4.IStockUpdateBLL _StockUpdateBLL = new CPMis.BLL.Tb_Maintain.Tb_Maintain_4.StockUpdateBLL();         //执行更新操作的对象
        private CPMis.IBLL.Tb_Maintain.Tb_Maintain_4.IGetStockDetailBLL _GetStockDetailBLL = new CPMis.BLL.Tb_Maintain.Tb_Maintain_4.GetStockDetailBLL();//页面跳转时用来保存当前信息的对象        
        IList<CPMis.Model.Tb_Maintain.Tb_Maintain_4.StockModel> _GetStockDetailList = new List<CPMis.Model.Tb_Maintain.Tb_Maintain_4.StockModel>();      //model对象，用来保存所修改的信息
        string para_stockid = "";
        /// <summary>
        /// 页面跳转时获取当前所需更新仓库的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                Fn_Query(); 
            }
        }

        /// <summary>
        /// 用来页面跳转时保存当前所需修改的值
        /// </summary>
        protected void Fn_Query() 
        {
            para_stockid = Request.QueryString["StockID"].ToString();//获取上个页面传来的StockID
            //ViewState["para_stockid"] = para_stockid;//保存StockId
            _GetStockDetailList = _GetStockDetailBLL.Fn_GetStockDetailByStockID(para_stockid);//调用BLL层的方法
            //保存所需修改的信息
            ctxtStockName.Text = _GetStockDetailList[0].StockName.ToString();
            ctxtStockNum.Text = _GetStockDetailList[0].StockNum.ToString();
            ctxtStockAddress.Text = _GetStockDetailList[0].StockAddress.ToString();
            ctxtTelephone.Text = _GetStockDetailList[0].Telephone.ToString();
            CPMisDatePicker1.DbSelectedDate = _GetStockDetailList[0].AccountBeginDate;
        }

        /// <summary>
        /// 保存所修改的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnBeforeSave(object sender, EventArgs e)
        {
            //Regex TelephoneReger = new Regex(@"^[0-9]{5,12}$",RegexOptions.IgnoreCase);
            //string Telephone = ctxtTelephone.Text;
            if (ctxtStockName.Text != "" && ctxtStockAddress.Text != "" && ctxtTelephone.Text != "")
            {
                //if (TelephoneReger.IsMatch(Telephone))
                //{
                    CPMis.Model.Tb_Maintain.Tb_Maintain_4.StockModel _StockUpdateModel = new Model.Tb_Maintain.Tb_Maintain_4.StockModel();
                    _StockUpdateModel.StockId = Request.QueryString["StockID"].ToString(); //调用上面所保存的StockIDViewState["para_stockid"].ToString();
                    //保存所需修改信息在model对象中
                    _StockUpdateModel.StockName = ctxtStockName.Text;
                    _StockUpdateModel.StockAddress = ctxtStockAddress.Text;
                    _StockUpdateModel.Telephone = ctxtTelephone.Text;
                    _StockUpdateModel.AccountBeginDate = CPMisDatePicker1.DbSelectedDate.ToString();
                    string message = "";
                    _StockUpdateBLL.Fn_StockUpdate(_StockUpdateModel, ref message);
                    CPMis.Web.WebClient.ScriptManager.Alert(message);//弹出提示信息

                    //判断修改是否成功，成功后关闭弹出窗，调用刷新
                    if (message == "√ 仓库信息修改成功!")
                    {
                        string script = "<script language='javascript' type='text/javascript'>Sys.Application.add_load(CloseAndRebind);</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "CloseAndRebind", script);

                    }
                //}
                //else 
                //{
                //    CPMis.Web.WebClient.ScriptManager.Alert("联系方式格式错误，请输入正确的格式！");
                //}
            }
            else
            {
                CPMis.Web.WebClient.ScriptManager.Alert("请输入完整的信息再保存");
            }
        }

        protected void cbtnAfterSave(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 取消按钮恢复初始页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnCancle_Click(object sender, EventArgs e) 
        {
            Fn_Query();
        }
    }
}