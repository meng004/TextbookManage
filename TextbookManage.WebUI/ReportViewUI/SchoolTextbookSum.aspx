<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolTextbookSum.aspx.cs" Inherits="TextbookManage.WebUI.ReprotViewUI.SchoolTextbookSum" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学校报表打印</title>
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
            <ClientEvents OnRequestStart="onRequestStart" />
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ccmbTerm" />
                        <telerik:AjaxUpdatedControl ControlID="rptSchool" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
         <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
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
            <utm:UTMisTabStrip ID="tb_SchoolReport" runat="server" MultiPageID="mp_SchoolReport">
                <Tabs>
                    <utm:UTMisTab runat="server" PageViewID="pv_SchoolReport" Text="学校报表打印"></utm:UTMisTab>
                </Tabs>
            </utm:UTMisTabStrip>
            <utm:UTMisMultiPage runat="server" ID="mp_SchoolReport">
                <utm:UTMisPageView runat="server" ID="pv_SchoolReport">
                    <div>
                        <table>
                            <tr style="height:50px">
                                <td>
                                    <utm:UTMisComboBox runat="server" ID="ccmbTerm" AutoPostBack="True" IsMaintainSelectedValue="true" SkinID="cmb120" Label="学年学期"
                                        DataTextField="TermYear" DataValueField="TermYear" OnBeforeDataBind="ccmbTerm_BeforeDataBind"
                                        >
                                    </utm:UTMisComboBox>
                                </td>
                                <td>
                                    <utm:UTMisButton runat="server" ID="cbtnPreview" Text="预览" OnClick="cbtnPreview_Click"></utm:UTMisButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div>
                        <utm:UTMisReportViewer runat="server" ID="rptSchool">
                               <LocalReport ReportPath="ReportView\SchoolTextbookSum.rdlc">
                                <DataSources>
                                   
                                </DataSources>
                            </LocalReport>
                            <ServerReport />
                        </utm:UTMisReportViewer>
                    </div>
                </utm:UTMisPageView>
            </utm:UTMisMultiPage>
        </div>
    
    </form>
</body>
</html>
