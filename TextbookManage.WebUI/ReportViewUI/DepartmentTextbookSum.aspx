<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentTextbookSum.aspx.cs" Inherits="TextbookManage.WebUI.ReprotViewUI.DepartmentTextbookOrderForStudent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>教研室报表打印</title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>

        <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1" UpdatePanelsRenderMode="Inline">
            <ClientEvents OnRequestStart="onRequestStart" />
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ccmbTerm" />
                        <telerik:AjaxUpdatedControl ControlID="ccmbDataSign" />
                        <telerik:AjaxUpdatedControl ControlID="ccmbSchool" />
                        <telerik:AjaxUpdatedControl ControlID="ccmbDepartment" />
                        <telerik:AjaxUpdatedControl ControlID="ccmbRecipientType" />
                        <telerik:AjaxUpdatedControl ControlID="cbtnPreview" />
                        <telerik:AjaxUpdatedControl ControlID="rptDepartment" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbDataSign">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ccmbSchool" />
                        <telerik:AjaxUpdatedControl ControlID="ccmbDeparment" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbSchool">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ccmbDepartment" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cbtnPreview">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="rptDepartment" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>

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
            <utm:UTMisTabStrip runat="server" ID="tb_DepartmentReport" MultiPageID="mp_DepartmentReport">
                <Tabs>
                    <utm:UTMisTab runat="server" PageViewID="pv_DepartmentReport" Text="教研室报表打印"></utm:UTMisTab>
                </Tabs>
            </utm:UTMisTabStrip>
            <utm:UTMisMultiPage runat="server" ID="mp_DepartmentReport">
                <utm:UTMisPageView runat="server" ID="pv_DepartmentReport">
                    <div>
                        <table>
                            <tr style="height:50px">
                                <td><%--OnBeforeDataBind="ccmbTerm_BeforeDataBind"--%>
                                    <utm:UTMisComboBox runat="server" ID="ccmbTerm" AutoPostBack="true" IsMaintainSelectedValue="true" SkinID="cmb100" Label="学年学期:"
                                        DataTextField="TermYear" DataValueField="TermYear" >
                                        <%--OnAfterDataBind="ccmbTerm_AfterDataBind" OnSelectedIndexChanged="ccmbTerm_AfterDataBind">--%>
                                    </utm:UTMisComboBox>
                                </td>
                                <td>
                                    <utm:UTMisComboBox runat="server" ID="ccmbDataSign" AutoPostBack="true" IsMaintainSelectedValue="true" SkinID="cmb100" Label="数据标识:" >
                                    </utm:UTMisComboBox>
                                </td>
                                <td>
                                    <utm:UTMisComboBox runat="server" ID="ccmbSchool" AutoPostBack="true" IsMaintainSelectedValue="true" SkinID="cmb180" Label="学院:"
                                        DataTextField="SchoolName" DataValueField="SchoolId"> <%--OnBeforeDataBind="ccmbSchool_BeforeDataBind"
                                        OnAfterDataBind="ccmbSchool_AfterDataBind" OnSelectedIndexChanged="ccmbSchool_AfterDataBind">--%>
                                    </utm:UTMisComboBox>
                                </td>
                                <td>
                                    <utm:UTMisComboBox runat="server" ID="ccmbDepartment" AutoPostBack="true" IsMaintainSelectedValue="true" SkinID="cmb160" Label="教研室:"
                                        DataTextField="DepartmentName" DataValueField="DepartmentId"> <%--OnBeforeDataBind="ccmbDepartment_BeforeDataBind"
                                        OnAfterDataBind="ccmbDepartment_AfterDataBind" OnSelectedIndexChanged="ccmbDepartment_AfterDataBind">--%>
                                    </utm:UTMisComboBox>
                                </td>
                                <td>
                                    <utm:UTMisComboBox runat="server" ID="ccmbRecipientType" AutoPostBack="true" IsMaintainSelectedValue="true" SkinID="cmb100" Label="领用人类型:"
                                        DataTextField="RecipientName" DataValueField="RecipientTypeId"><%-- OnBeforeDataBind="ccmbRecipientType_BeforeDataBind"
                                        OnAfterDataBind="ccmbRecipientType_AfterDataBind" OnSelectedIndexChanged="ccmbRecipientType_AfterDataBind">--%>
                                    </utm:UTMisComboBox>
                                </td>
                                <td>
                                    <utm:UTMisButton runat="server" ID="cbtnPreview" Text="预览"> <%--OnClick="cbtnPreview_Click"--%></utm:UTMisButton>
                                    
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div>
                        <utm:UTMisReportViewer runat="server" ID="rptDepartment" Visible="true" ReportName="DepartmentTextbookSum" >
                            <LocalReport ReportPath="ReportView\SchoolTextbookSum.rdlc">
                                <DataSources >
                                   
                                </DataSources>
                            </LocalReport>
                            <%--<ServerReport />--%>
                        </utm:UTMisReportViewer>
                    </div>
                </utm:UTMisPageView>
            </utm:UTMisMultiPage>
        </div>
    </form>
</body>
</html>
