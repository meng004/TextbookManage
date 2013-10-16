<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeedbackForDeclaration.aspx.cs" Inherits="TextbookManage.WebUI.WindowForMessage.FeedbackForDeclaration" %>
<%@ OutputCache Duration="60" VaryByParam="DeclarationID" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>回告详情</title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
        <div>
            <ul>
                <li>
                    <utm:UTMisTextBox runat="server" ID="txt_Person" ReadOnly="True" Label="回告人" SkinID="tb200" EmptyMessage="无"></utm:UTMisTextBox></li>
                <li>
                    <utm:UTMisTextBox runat="server" ID="txt_Date" ReadOnly="true" Label="回告日期" SkinID="tb200" EmptyMessage="无"></utm:UTMisTextBox></li>
                <li>
                    <utm:UTMisTextBox runat="server" ID="txt_State" ReadOnly="true" Label="回告状态" SkinID="tb200" EmptyMessage="无"></utm:UTMisTextBox></li>
                <li>
                    <utm:UTMisTextBox runat="server" ID="txt_Remark" ReadOnly="true" TextMode="MultiLine" Label="备注" SkinID="tb200" Height="100" EmptyMessage="无"></utm:UTMisTextBox></li>
            </ul>
        </div>
    </form>
</body>
</html>
