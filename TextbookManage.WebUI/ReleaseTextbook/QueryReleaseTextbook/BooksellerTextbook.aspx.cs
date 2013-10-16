using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPMis.WebPage.Tb_Query.Tb_Query_3
{
    public partial class BooksellerTextbook : System.Web.UI.Page
    {
        CPMis.Web.WebClient.ProfileManger profile = new Web.WebClient.ProfileManger(HttpContext.Current.User.Identity.Name);
        private CPMis.IBLL.Tb_Query.Tb_Query_3.IBooksellerQueryBLL _IBooksellerQueryBLL = new CPMis.BLL.Tb_Query.Tb_Query_3.BooksellerQueryBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cdlstBooksellerName.DataSourceID = "SqlDataSource2";
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

        protected void cbntQuery_Click(object sender, EventArgs e)
        {
            cgrdBookSeller.DoDataBind();
        }

        protected void cgrdSeller_BeforeDataBind(object sender, EventArgs e)
        {
            cgrdBookSeller.DataSource = _IBooksellerQueryBLL.Fn_BooksellerGetList(profile.UserInGroupID, cdlstTerm.SelectedText);
        }
    }
}