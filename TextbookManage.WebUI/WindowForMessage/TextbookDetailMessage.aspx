<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TextbookDetailMessage.aspx.cs" Inherits="TextbookManage.WebUI.WindowForMessage.TextbookDetailMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>教材详细信息</title>
    <style type="text/css">
        .style1 {
            color: red;
        }

        .border {
            border: 0;
            margin: 0;
            padding: 0;
        }

        .borderRight {
            border: 0;
            margin: 0;
            padding: 0;
            text-align: right;
        }
    </style>
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
        <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                //刷新父窗体，关闭自己
                function CloseAndRebind() {
                    GetRadWindow().BrowserWindow.refreshGrid();
                    GetRadWindow().close();
                    return false;
                }
                //获取父窗体RadWindow控制器
                function GetRadWindow() {
                    var oWindow = null;
                    if (window.radWindow)
                        oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                    else if (window.frameElement.radWindow)
                        oWindow = window.frameElement.radWindow; //IE (and Moz as well)
                    return oWindow;
                }
            </script>
        </telerik:RadCodeBlock>
        <div>
            <cp:CPMisMultiPage runat="server" ID="mp_Textbook">
                <cp:CPMisPageView ID="pv_Textbook" runat="server">
                    <table class="border">
                        <tr>
                            <td class="border">
                                <cp:CPMisLabel ID="clblTextbookName" runat="server" Text="教材名称">
                                </cp:CPMisLabel>
                            </td>
                            <td class="border" colspan="3">
                                <cp:CPMisTextBox ID="ctxtTextbookName" runat="server" SkinID="Changeable" Width="500">
                                </cp:CPMisTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="border">
                                <cp:CPMisLabel ID="clblAuthor" runat="server" Text="作者">
                                </cp:CPMisLabel>
                            </td>
                            <td class="border" colspan="3">
                                <cp:CPMisTextBox ID="ctxtAuthor" runat="server" SkinID="Changeable" Width="500">
                                </cp:CPMisTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="border">
                                <cp:CPMisLabel ID="clblISBN" runat="server" Text="ISBN">
                                </cp:CPMisLabel>
                            </td>
                            <td class="border">
                                <cp:CPMisTextBox ID="ctxtISBN" runat="server">
                                </cp:CPMisTextBox>
                            </td>
                            <td class="borderRight">
                                <cp:CPMisLabel ID="clblRetailPrice" runat="server" Text="定价">
                                </cp:CPMisLabel>
                            </td>
                            <td class="borderRight" >
                                <cp:CPMisTextBox ID="ctxtRetailPrice" runat="server">
                                </cp:CPMisTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="border">
                                <cp:CPMisLabel ID="clblPress" runat="server" Text="出版社">
                                </cp:CPMisLabel>
                            </td>
                            <td class="border">
                                <cp:CPMisTextBox ID="ctxtPress" runat="server"></cp:CPMisTextBox>
                            </td>
                            <td class="borderRight">
                                <cp:CPMisLabel ID="UTMisLabel1" runat="server" Text="出版地址">
                                </cp:CPMisLabel>
                            </td>
                            <td class="borderRight">
                                <cp:CPMisTextBox ID="ctxtPressAddress" runat="server" >
                                </cp:CPMisTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="border">
                                <cp:CPMisLabel ID="clblEdition" runat="server" Text="版本">
                                </cp:CPMisLabel>
                            </td>
                            <td class="border">
                                <cp:CPMisTextBox ID="ctxtEdition" runat="server">
                                </cp:CPMisTextBox>
                            </td>
                            <td class="borderRight">
                                <cp:CPMisLabel ID="clblPrintingCount" runat="server" Text="版次">
                                </cp:CPMisLabel>
                            </td>
                            <td class="borderRight">
                                <cp:CPMisTextBox ID="ctxtPrintingCount" runat="server">
                                </cp:CPMisTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="border">
                                <cp:CPMisLabel ID="clblPage" runat="server" Text="页数">
                                </cp:CPMisLabel>
                            </td>
                            <td class="border">
                                <cp:CPMisTextBox ID="ctxtPage" runat="server">
                                </cp:CPMisTextBox>
                            </td>
                            <td class="borderRight">
                                <cp:CPMisLabel ID="UTMisLabel2" runat="server" Text="出版日期">
                                </cp:CPMisLabel>
                            </td>
                            <td class="borderRight">
                                <cp:CPMisTextBox ID="ctxtPublishDate" runat="server">
                                </cp:CPMisTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="border">
                                <cp:CPMisLabel ID="clblTextbookId" runat="server" Text="教材ID" Visible="false">
                                </cp:CPMisLabel>
                                <cp:CPMisLabel ID="clblIsSelfCompile" runat="server" Text="自编教材">
                                </cp:CPMisLabel>
                            </td>
                            <td class="border">
                                <cp:CPMisTextBox runat="server" ID="ctxtIsSelfCompile"></cp:CPMisTextBox>
                            </td>
                            <td class="borderRight" >
                                <cp:CPMisLabel ID="UTMisLabel3" runat="server" Text="教材编号">
                                </cp:CPMisLabel>
                            </td>
                            <td class="borderRight"> 
                                <cp:CPMisTextBox ID="ctxtTextbookNum" runat="server"></cp:CPMisTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="border">
                                <cp:CPMisLabel ID="clblType" runat="server" Style="font-family: Arial; font-size: medium"
                                    Text="教材类型">
                                </cp:CPMisLabel>
                            </td>
                            <td class="border" align="left" colspan="3">
                                <cp:CPMisTextBox ID="ctxtType" runat="server" SkinID="Changeable" Width="500">
                                </cp:CPMisTextBox>
                            </td>
                        </tr>
                    </table>

                </cp:CPMisPageView>
            </cp:CPMisMultiPage>
        </div>
    </form>
</body>
</html>
