using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPMis.Model.Tb_Maintain.Tb_Maintain_7;
using System.Text.RegularExpressions;

namespace CPMis.WebPage.Tb_Maintain.Tb_Maintain_7
{
    public partial class AddBooksellerStaff : System.Web.UI.Page
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
        /// 新增书商员工信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnAdd_Click(object sender, EventArgs e)
        {
            string staffName = ctxtStaffName.Text.Trim().ToString();
            string message = "";
            if (staffName != "")
            {
                string reg = @"^([\u4e00-\u9fa5]|[0-9]|[a-zA-Z]){1,}$";

                if (Regex.IsMatch(staffName, reg))
                {
                    BooksellerStaffModel _booksellerStaffModel = new BooksellerStaffModel();

                    _booksellerStaffModel.BooksellerId = new Guid(ccmbBooksellerName.SelectedValue);
                    _booksellerStaffModel.StaffName = staffName;
                    _booksellerStaffModel.Sex = ccmbSex.SelectedText;

                    _booksellerStaffBLL.Fn_AddBooksellerStaff(_booksellerStaffModel, ref message);

                    CPMis.Web.WebClient.ScriptManager.Alert(message);
                }
                else
                {
                    ctxtStaffName.Text = "";
                    Page.SetFocus(ctxtStaffName);
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
            ccmbBooksellerName.SelectedIndex = 0;
            ccmbSex.SelectedIndex = 0;
            ctxtStaffName.Text = "";
        }
    }
}