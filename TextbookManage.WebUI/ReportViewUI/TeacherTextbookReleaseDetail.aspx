<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentTextbookCharge.aspx.cs"
    Inherits="CPMis.WebPage.ReportViewersUI.TeacherTextbookReleaseDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../App_Themes/CPMisTheme/style.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/CPMisTheme/CPMisTable.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">        //如果点击的是导出按钮则将AJAX禁用
        function onRequestStart(sender, args) {
            if (args.get_eventTarget().indexOf("ExportToExcelButton") >= 0 || args.get_eventTarget().indexOf("ExportToWordButton") >= 0 || args.get_eventTarget().indexOf("ExportToPdfButton") >= 0 || args.get_eventTarget().indexOf("ExportToCsvButton") >= 0) {
                args.set_enableAjax(false);
            }
        }
    </script>
    <style type="text/css">
        .reportview
        {
            text-align: center;
        }
        .textcol, .table, .controlcol
        {
            border: 0px;
            padding: 0px;
            margin: 0px;
        }
        .textcol
        {
            text-align: right;
        }
        .controlcol
        {
            text-align: left;
        }
        .table
        {
            width: 895px;
            background-color: Transparent;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
    </telerik:RadSkinManager>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline">
        <ClientEvents OnRequestStart="onRequestStart" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ccmbSchool">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ccmbDepartment"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ccmbTerm">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ccmbTerm"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" AutoTooltipify="true">
    </telerik:RadToolTipManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
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
    <div>
        <cp:CPMisToolBar ID="toolbar" runat="server" SkinID="Long">
            <Items>
                <telerik:RadToolBarButton Text="帮助" ImageUrl="~/Img/tlb_Help.png" runat="server">
                </telerik:RadToolBarButton>
            </Items>
        </cp:CPMisToolBar>
    </div>
    <div>
        <cp:CPMisTabStrip runat="server" MultiPageID="mp" SkinID="Long" SelectedIndex="0">
            <Tabs>
                <cp:CPMisTab runat="server" Text="打印教研室教材费用">
                </cp:CPMisTab>
            </Tabs>
        </cp:CPMisTabStrip>
        <cp:CPMisMultiPage runat="server" ID="mp" SkinID="Long">
            <cp:CPMisPageView ID="CPMisPageView1" runat="server">
                <div style="background-color: #D6E2F2;">
                    <table class="table" width="">
                        <tr>
                            <td class="textcol">
                                学年学期
                            </td>
                            <td class="controlcol">
                                &nbsp;&nbsp;
                                <cp:CPMisComboBox runat="server" ID="ccmbTerm" DataSourceID="DsTerm" DataTextField="Term"
                                    DataValueField="TermNum" AutoPostBack="true">
                                </cp:CPMisComboBox>
                            </td>
                            <td class="textcol">
                                学院
                            </td>
                            <td class="controlcol">
                                &nbsp;&nbsp;
                                <cp:CPMisComboBox runat="server" ID="ccmbSchool" DataSourceID="DsSchool" DataTextField="SchoolName"
                                    DataValueField="SchoolID" AutoPostBack="true" SkinID="cmb200">
                                </cp:CPMisComboBox>
                            </td>
                            <td class="textcol">
                                教研室
                            </td>
                            <td class="controlcol">
                                &nbsp;&nbsp;
                                <cp:CPMisComboBox runat="server" ID="ccmbDepartment" DataSourceID="DsDepartment"
                                    DataTextField="DepartmentName" DataValueField="DepartmentId" AutoPostBack="true"
                                    SkinID="cmb200">
                                </cp:CPMisComboBox>
                            </td>
                            <td class="controlcol">
                                &nbsp;&nbsp;
                                <cp:CPMisButton runat="server" ID="cbtnQuery" Text="查询" OnClick="cbtnQuery_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <rsweb:ReportViewer CssClass="reportview" ID="rvDepartmentTextbookCharge" runat="server"
                        Visible="false">
                        <LocalReport ReportPath="ReportViews\TeacherTextbookReleaseDetail.rdlc">
                            <DataSources>
                                <rsweb:ReportDataSource DataSourceId="DsDepartmentTextbookCharge" Name="DataSet1" />
                            </DataSources>
                        </LocalReport>
                    </rsweb:ReportViewer>
                    <asp:SqlDataSource ID="DsDepartmentTextbookCharge" runat="server" ConnectionString="<%$ ConnectionStrings:TbMISConnectionString %>"
                        SelectCommand="prReportReleaseTeacherTextbookDetail" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:Parameter Name="Term" Type="String" />
                            <asp:Parameter Name="DepartmentId" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="DsTerm" runat="server" ConnectionString="<%$ ConnectionStrings:TbMISConnectionString %>"
                        SelectCommand="prTermGetList" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="DsSchool" runat="server" ConnectionString="<%$ ConnectionStrings:TbMISConnectionString %>"
                        SelectCommand="prSchoolNameGetList" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="DsDepartment" runat="server" ConnectionString="<%$  ConnectionStrings:TbMISConnectionString %>"
                        SelectCommand="prDepartmentGetListBySchoolId" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ccmbSchool" Name="SchoolID" PropertyName="SelectedValue"
                                DbType="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </cp:CPMisPageView>
        </cp:CPMisMultiPage>
    </div>
    </form>
</body>
</html>
