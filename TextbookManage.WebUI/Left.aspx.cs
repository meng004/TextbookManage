using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Data;
using Telerik.Web.UI;

namespace CPMis.WebPage
{
    public partial class Navigation : CPMis.Web.WebControls.Page
    {
        private CPMis.IBLL.Sys.IUser _user = new CPMis.BLL.Sys.User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var name = Page.User.Identity.Name;
                fillData();
                CPMis.Web.WebClient.ProfileManger profile =
                    new CPMis.Web.WebClient.ProfileManger(HttpContext.Current.User.Identity.Name);
                string strInf = "今天是:" + DateTime.Now.ToString("yyyy年MM月dd日  ");
                string strDay = "";
                switch (DateTime.Now.DayOfWeek.ToString("d"))
                {
                    case "0":
                        strDay = "星期日";
                        break;
                    case "1":
                        strDay = "星期一";
                        break;
                    case "2":
                        strDay = "星期二";
                        break;
                    case "3":
                        strDay = "星期三";
                        break;
                    case "4":
                        strDay = "星期四";
                        break;
                    case "5":
                        strDay = "星期五";
                        break;
                    case "6":
                        strDay = "星期六";
                        break;
                }
                strInf += strDay;
                if (profile.UserTruelyName.Length > 0)
                    strInf += "\r\n您好!" + profile.UserTruelyName;
                lbl_UserName.Text = strInf;
            }
        }

        protected void exit_button_Click(object sender, EventArgs e)
        {
            Response.Write("<Script>top.window.location.href = '../Home.aspx';</Script>");
            FormsAuthentication.SignOut();
        }

        private void fillData()
        {
            MembershipUser currentUser = Membership.GetUser();
            if (null == currentUser)
            {
                return;
            }
            string userName = currentUser.UserName.ToString();
            //bool isAdmin = Roles.IsUserInRole("系统管理员");
            //string[] roles = Roles.GetRolesForUser();
            //string[] roles = Roles.GetRolesForUser(userName);
            IList<CPMis.Model.Sys.FunctionModel> functionModelList = _user.GetUserFunctionList(userName);
            //IList<USCTAMis.Model.Sys.FunctionModel> functionModelList = _user.GetUserFunctionList("guiqi");
            if (null == functionModelList || functionModelList.Count == 0)
            {
                return;
            }
            DataTable functionTable = _user.ConvertToDataTable<CPMis.Model.Sys.FunctionModel>(functionModelList);
            int strLen = functionTable.Rows[0]["FunctionID"].ToString().Length;
            String filterStr2 = new string('0', strLen - 2);
            String filterStr1 = "";
            AddNode(functionTable, filterStr1, filterStr2, (RadTreeNode)null);
        }

        private void AddNode(DataTable functionTable, String filterStr1, String filterStr2, RadTreeNode functionItem)
        {
            //if (filterStr2.Equals("") || filterStr2.Equals(null))
            if (filterStr1.Length > 6)
            {
                return;
            }

            //使用字段名FunctionId过滤，并不易扩展，不利于与数据库工作的分工。这里可以使用AND进行多个条件过滤。
            String filter = String.Format("FunctionID LIKE '{0}*' AND FunctionID LIKE '*{1}'", filterStr1, filterStr2);
            DataRow[] functionRows = functionTable.Select(filter, "FunctionID");
            //当没有过滤出数据而且表里面还有内容，即可能没有根节点,但是它是父节点下面，如果自己是子节点也不需进来
            if (0 == functionRows.Length && functionTable.Rows.Count > 0 && functionItem == null)
            {
                if (filterStr2.Length == 0)
                {
                    return;
                }
                filterStr1 = functionTable.Rows[0]["FunctionID"].ToString().Substring(0, functionTable.Rows[0]["FunctionID"].ToString().Length - filterStr2.Length);
                //filterStr1 = filterStr1.Substring(0, functionTable.Rows[0]["FunctionID"].ToString().Length - filterStr2.Length);
                if (filterStr1.Length >= 6)
                {
                    AddNode(functionTable, filterStr1, "", functionItem);
                    return;
                }
                else
                {
                    AddNode(functionTable, filterStr1, filterStr2.Remove(0, 2), functionItem);
                    return;
                }
                //AddNode(functionTable, filterStr1, filterStr2.Remove(0, 2), functionItem);
            }
            //对已筛选出来的row进行删除，减少下次筛选量，同时也消除父级菜单的二次选中
            DataTable firstTable = functionTable.Clone();
            foreach (DataRow row in functionRows)
            {
                firstTable.ImportRow(row);
                functionTable.Rows.Remove(row);
            }
            DataRow[] rowsSecond = firstTable.Select();

            foreach (DataRow functionRow in rowsSecond)
            {
                RadTreeNode _functionItem = new RadTreeNode();
                if (null == functionItem)
                {
                    _functionItem.Text = functionRow["FunctionName"].ToString();
                    _functionItem.Value = functionRow["FunctionID"].ToString();
                    tv_Function.Nodes.Add(_functionItem);
                }
                else
                {
                    _functionItem.Text = functionRow["FunctionName"].ToString();
                    _functionItem.Value = functionRow["FunctionID"].ToString();
                    if ((!functionRow["FunctionURL"].ToString().Equals("")) &&
                        !functionRow["FunctionURL"].ToString().Equals(null))
                    {
                        _functionItem.NavigateUrl = functionRow["FunctionURL"].ToString();
                        _functionItem.Target = "mainFrame";
                    }
                    functionItem.Nodes.Add(_functionItem);
                }
                filterStr1 = functionRow["FunctionID"].ToString().Substring(0, functionRow["FunctionID"].ToString().Length - filterStr2.Length);
                if (filterStr1.Length >= 6)
                {
                    AddNode(functionTable, filterStr1, "", _functionItem);
                }
                else
                {
                    AddNode(functionTable, filterStr1, filterStr2.Remove(0, 2), _functionItem);
                }
            }
        }
    }
}