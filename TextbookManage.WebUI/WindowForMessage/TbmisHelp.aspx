<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TbmisHelp.aspx.cs" Inherits="TextbookManage.WebUI.WindowForMessage.TbmisHelp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>操作帮助</title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <div>
            <cp:CPMisToolBar ID="ctlbDeclaration" runat="server" OnButtonClick="ctlbDeclaration_ButtonClick">
                <Items>
                    <telerik:RadToolBarButton runat="server" Text="帮助" ImageUrl="~/Img/tlb_Help.png" AccessKey="h">
                    </telerik:RadToolBarButton>
                </Items>
            </cp:CPMisToolBar>
        </div>
    </form>
</body>
</html>
