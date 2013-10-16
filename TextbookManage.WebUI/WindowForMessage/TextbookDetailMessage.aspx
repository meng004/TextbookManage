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
            <utm:UTMisMultiPage runat="server" ID="mp_Textbook">
                <utm:UTMisPageView ID="pv_Textbook" runat="server">
                    <table class="border">
                        <tr>
                            <td class="border">
                                <utm:UTMisLabel ID="clblTextbookName" runat="server" Text="教材名称">
                                </utm:UTMisLabel>
                            </td>
                            <td class="border" colspan="3">
                                <utm:UTMisTextBox ID="ctxtTextbookName" runat="server" SkinID="Changeable" Width="500">
                                </utm:UTMisTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="border">
                                <utm:UTMisLabel ID="clblAuthor" runat="server" Text="作者">
                                </utm:UTMisLabel>
                            </td>
                            <td class="border" colspan="3">
                                <utm:UTMisTextBox ID="ctxtAuthor" runat="server" SkinID="Changeable" Width="500">
                                </utm:UTMisTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="border">
                                <utm:UTMisLabel ID="clblISBN" runat="server" Text="ISBN">
                                </utm:UTMisLabel>
                            </td>
                            <td class="border">
                                <utm:UTMisTextBox ID="ctxtISBN" runat="server">
                                </utm:UTMisTextBox>
                            </td>
                            <td class="borderRight">
                                <utm:UTMisLabel ID="clblRetailPrice" runat="server" Text="定价">
                                </utm:UTMisLabel>
                            </td>
                            <td class="borderRight" >
                                <utm:UTMisTextBox ID="ctxtRetailPrice" runat="server">
                                </utm:UTMisTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="border">
                                <utm:UTMisLabel ID="clblPress" runat="server" Text="出版社">
                                </utm:UTMisLabel>
                            </td>
                            <td class="border">
                                <utm:UTMisTextBox ID="ctxtPress" runat="server"></utm:UTMisTextBox>
                            </td>
                            <td class="borderRight">
                                <utm:UTMisLabel ID="UTMisLabel1" runat="server" Text="出版地址">
                                </utm:UTMisLabel>
                            </td>
                            <td class="borderRight">
                                <utm:UTMisTextBox ID="ctxtPressAddress" runat="server" >
                                </utm:UTMisTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="border">
                                <utm:UTMisLabel ID="clblEdition" runat="server" Text="版本">
                                </utm:UTMisLabel>
                            </td>
                            <td class="border">
                                <utm:UTMisTextBox ID="ctxtEdition" runat="server">
                                </utm:UTMisTextBox>
                            </td>
                            <td class="borderRight">
                                <utm:UTMisLabel ID="clblPrintingCount" runat="server" Text="版次">
                                </utm:UTMisLabel>
                            </td>
                            <td class="borderRight">
                                <utm:UTMisTextBox ID="ctxtPrintingCount" runat="server">
                                </utm:UTMisTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="border">
                                <utm:UTMisLabel ID="clblPage" runat="server" Text="页数">
                                </utm:UTMisLabel>
                            </td>
                            <td class="border">
                                <utm:UTMisTextBox ID="ctxtPage" runat="server">
                                </utm:UTMisTextBox>
                            </td>
                            <td class="borderRight">
                                <utm:UTMisLabel ID="UTMisLabel2" runat="server" Text="出版日期">
                                </utm:UTMisLabel>
                            </td>
                            <td class="borderRight">
                                <utm:UTMisTextBox ID="ctxtPublishDate" runat="server">
                                </utm:UTMisTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="border">
                                <utm:UTMisLabel ID="clblTextbookId" runat="server" Text="教材ID" Visible="false">
                                </utm:UTMisLabel>
                                <utm:UTMisLabel ID="clblIsSelfCompile" runat="server" Text="自编教材">
                                </utm:UTMisLabel>
                            </td>
                            <td class="border">
                                <utm:UTMisTextBox runat="server" ID="ctxtIsSelfCompile"></utm:UTMisTextBox>
                            </td>
                            <td class="borderRight" >
                                <utm:UTMisLabel ID="UTMisLabel3" runat="server" Text="教材编号">
                                </utm:UTMisLabel>
                            </td>
                            <td class="borderRight"> 
                                <utm:UTMisTextBox ID="ctxtTextbookNum" runat="server"></utm:UTMisTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="border">
                                <utm:UTMisLabel ID="clblType" runat="server" Style="font-family: Arial; font-size: medium"
                                    Text="教材类型">
                                </utm:UTMisLabel>
                            </td>
                            <td class="border" align="left" colspan="3">
                                <utm:UTMisTextBox ID="ctxtType" runat="server" SkinID="Changeable" Width="500">
                                </utm:UTMisTextBox>
                            </td>
                        </tr>
                    </table>

                </utm:UTMisPageView>
            </utm:UTMisMultiPage>
        </div>
    </form>
</body>
</html>
