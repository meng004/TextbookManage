using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TextbookManage.Application.Interface;
using TextbookManage.Application.Factory;
using TextbookManage.Application.ViewModel;

namespace TextbookManage.WebUI.ReprotViewUI
{
    public partial class SchoolTextbookSum : System.Web.UI.Page
    {

        IDeclaration _declaration;
        readonly string _ipAddress = HttpContext.Current.Request.UserHostAddress;
        //readonly string _loginName = HttpContext.Current.User.Identity.Name;
        readonly string _loginName = "hynhpgj";
        protected void Page_Load(object sender, EventArgs e)
        {
            _declaration = new ApplicationFactory(_loginName, _ipAddress).CreateDeclarationApplication();
            
            if (!IsPostBack)
            {                 
                ccmbTerm.DoDataBind();
            }
        }

        protected void cbtnPreview_Click(object sender, EventArgs e)
        {

        }

        protected void ccmbTerm_BeforeDataBind(object sender, EventArgs e)
        {
            ccmbTerm.DataSource = _declaration.GetTermList();
           
        }

        protected void ccmbTerm_AfterDataBind(object sender, EventArgs e)
        {

        }

        protected void ccmbTerm_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }
    }
}