using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TextbookManage.WebUI.WindowForMessage
{
    public partial class TbmisHelp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ctlbDeclaration_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            var argu = e.Item.AccessKey;
            if (argu == "h")
            {
                Response.ContentType = "/doc";
                Response.AppendHeader("Content-Disposition", "attachment; filename=帮助文档.doc");
                Response.TransmitFile(Server.MapPath("帮助文档.doc"));
                Response.End();
            }
        }
    }
}