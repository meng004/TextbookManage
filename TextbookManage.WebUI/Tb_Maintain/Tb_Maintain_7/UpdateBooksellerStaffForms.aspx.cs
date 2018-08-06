using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPMis.Model.Tb_Maintain.Tb_Maintain_7;
using System.Text.RegularExpressions;

namespace CPMis.WebPage.Tb_Maintain
{
    public partial class UpdateBooksellerStaffForms : System.Web.UI.Page
    {
        IBLL.Tb_Maintain.Tb_Maintain_7.IBooksellerStaffBLL _booksellerStaffBLL = new BLL.Tb_Maintain.Tb_Maintain_7.BooksellerStaffBLL();
        static string StaffName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ctxtBooksellerName.Text = Request.QueryString["BooksellerName"].ToString();
                string para_booksellerStaffId = Request.QueryString["BooksellerStaffId"].ToString();
                Fn_GetBooksellerStaffInfo(para_booksellerStaffId);
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string staffName = ctxtWorkerName.Text.Trim().ToString();
            string message = "";
            if (staffName != "")
            {
                string reg = @"^([\u4e00-\u9fa5]|[0-9]|[a-zA-Z]){1,}$";

                if (Regex.IsMatch(staffName, reg))
                {
                    BooksellerStaffModel _booksellerStaffModel = new BooksellerStaffModel();
                    _booksellerStaffModel.BooksellerStaffId = new Guid(Request.QueryString["BooksellerStaffId"].ToString());
                    _booksellerStaffModel.StaffName = staffName;
                    _booksellerStaffModel.Sex = ccmbSex.SelectedText;

                    _booksellerStaffBLL.Fn_UpdateBooksellerStaffInfo(_booksellerStaffModel, ref message);

                    CPMis.Web.WebClient.ScriptManager.Alert(message);
                }
                else
                {
                    ctxtWorkerName.Text = StaffName;
                    CPMis.Web.WebClient.ScriptManager.Alert("员工姓名只能输入中英文字符或数字！");
                }
            }
            else
            {
                CPMis.Web.WebClient.ScriptManager.Alert("带*的项不能为空！");
            }
        }   

        protected void btnCancel_Click(object sender, EventArgs e)
        {          
            ccmbSex.SelectedIndex = 0;
            ctxtWorkerName.Text = StaffName;
        }
        protected void Fn_GetBooksellerStaffInfo(string para_booksellerStaffId)
        {
           BooksellerStaffModel _booksellerStaffModel=_booksellerStaffBLL.Fn_GetBooksellerStaffByBooksellerStaffId(para_booksellerStaffId);

           ctxtWorkerName.Text = _booksellerStaffModel.StaffName;
           StaffName = _booksellerStaffModel.StaffName;
           for (int i = 0; i < ccmbSex.Items.Count; i++)
           {               
               if (ccmbSex.Items[i].Text.ToString() == _booksellerStaffModel.Sex)
               {
                   ccmbSex.SelectedIndex = i;
               }
           }
        }
    }
}