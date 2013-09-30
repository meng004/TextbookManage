<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TextbookDetailMessage.aspx.cs" Inherits="TextbookManage.WebUI.WindowForMessage.TextbookDetailMessage" %>

<%@ OutputCache Duration="60" VaryByParam="TextbookID" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>教材详细信息</title>
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
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline">
        </telerik:RadAjaxManager>
        <telerik:RadCodeBlock runat="server">
            <script type="text/javascript">
                //如果点击的是导出按钮则将AJAX禁用
                function onRequestStart(sender, args) {
                    if (args.get_eventTarget().indexOf("ExportToExcelButton") >= 0 ||
                            args.get_eventTarget().indexOf("ExportToWordButton") >= 0 ||
                            args.get_eventTarget().indexOf("ExportToPdfButton") >= 0 ||
                            args.get_eventTarget().indexOf("ExportToCsvButton") >= 0) {

                        args.set_enableAjax(false);
                    }
                }
            </script>
        </telerik:RadCodeBlock>
        <div>
            <ul>

                <li>
                    <utm:UTMisTextBox ID="ctxtTextbookNum" ReadOnly="True" SkinID="txt200" runat="server" Label="教材编号" >
                    </utm:UTMisTextBox>
                </li>


                <li>
                    <utm:UTMisTextBox ID="ctxtTextbookName" ReadOnly="true" SkinID="txt200" runat="server" Label="教材名称"
                        TextMode="MultiLine" Rows="5">
                    </utm:UTMisTextBox>
                </li>


                <li>
                    <utm:UTMisTextBox ID="ctxtAuthor" ReadOnly="true" SkinID="txt200" runat="server" Label="作者" TextMode="MultiLine" Rows="2">
                    </utm:UTMisTextBox>
                </li>



                <li>
                    <utm:UTMisTextBox ID="ctxtPress" ReadOnly="true" SkinID="txt200" runat="server" Label="出版社" TextMode="MultiLine" Rows="2">
                    </utm:UTMisTextBox>
                </li>



                <li>
                    <utm:UTMisTextBox ID="ctxtISBN" ReadOnly="true" SkinID="txt200" runat="server" Label="ISBN">
                    </utm:UTMisTextBox>
                </li>


                <li>
                    <utm:UTMisTextBox ID="ctxtEdition" ReadOnly="true" SkinID="txt200" runat="server" Label="版本">
                    </utm:UTMisTextBox>
                </li>


                <li>
                    <utm:UTMisTextBox ID="ctxtPrintCount" ReadOnly="true" SkinID="txt200" runat="server" Label="版次">
                    </utm:UTMisTextBox>
                </li>



                <li>
                    <utm:UTMisTextBox ID="ctxtPrice" ReadOnly="true" SkinID="txt200" runat="server" Label="定价">
                    </utm:UTMisTextBox>
                </li>


                <li>
                    <utm:UTMisTextBox ID="ctxtType" ReadOnly="true" SkinID="txt200" runat="server" Label="教材类型">
                    </utm:UTMisTextBox>
                </li>

            </ul>
        </div>
    </form>
</body>
</html>
