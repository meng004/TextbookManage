<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookSellerTextbookSum.aspx.cs" Inherits="TextbookManage.WebUI.ReprotViewUI.BookSellerTextbookSum" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>书商报表打印</title>
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
        <div>
            <utm:UTMisTabStrip ID="tb_BooksellerReport" runat="server" MultiPageID="mp_BookSellerReport">
                <Tabs><utm:UTMisTab runat="server" PageViewID="pv_BookSellerReport" Text="书商报表打印"></utm:UTMisTab></Tabs>
            </utm:UTMisTabStrip>
            <utm:UTMisMultiPage ID="mp_BookSellerReport" runat="server">
                <utm:UTMisPageView ID="pv_BookSellerReport" runat="server">
                    <table>
                        <tr>
                            <td>
                                <utm:UTMisComboBox ID="ccmbTerm" runat="server" AutoPostBack="true"
                                    IsMaintainSelectedValue="true" Label="学年学期" SkinID="cmb100"
                                    DataTextField="TermYear" DataValueField="TermYear" OnBeforeDataBind="ccmbTerm_BeforeDataBind">
                                </utm:UTMisComboBox>
                            </td> 
                            <td>
                                <utm:UTMisComboBox ID="ccmbBookSellerName" runat="server" Label="书商名称" SkinID="cmb100"
                                    AutoPostBack="true" DataTextField="BookSellerName" DataValueField="BookSellerID" OnBeforeDataBind="ccmbBookSellerName_BeforeDataBind">
                                </utm:UTMisComboBox>
                            </td>
                            <td>
                                <utm:UTMisButton ID="btnPreview" runat="server" Text="预览" OnClick="btnPreview_Click"></utm:UTMisButton>
                            </td>
                        </tr>
                    </table>
                    <utm:UTMisReportViewer ID="rpv_CourseTextBookPrint" runat="server"  Width="990px" Height="500px" OnBeforeReportPrint="rpv_CourseTextBookPrint_BeforeReportPrint">
                         <LocalReport ReportPath="ReportView\BookSellerTextbookSum.rdlc">
                               
                            </LocalReport>
                    </utm:UTMisReportViewer>
                </utm:UTMisPageView>
            </utm:UTMisMultiPage>
        </div>
    </form>
</body>
</html>
