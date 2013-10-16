<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AcadamicBooksellerOrder.aspx.cs"
    Inherits="CPMis.WebPage.ReportViewsUI.Orders.AcadamicBooksellerOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../App_Themes/CPMisTheme/style.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/CPMisTheme/CPMisTable.css" rel="Stylesheet" type="text/css" />
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
         
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" AutoTooltipify="true">
    </telerik:RadToolTipManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <div class="div1">
        <cp:CPMisToolBar ID="CPMisToolBar1" runat="server" SkinID="Long">
            <Items>
                <telerik:RadToolBarButton runat="server" Text="帮助" ImageUrl="~/Img/tlb_Help.png">
                </telerik:RadToolBarButton>
            </Items>
        </cp:CPMisToolBar>
    </div>
    <div class="div1">
        <cp:CPMisTabStrip ID="CPMisTabStrip1" runat="server" MultiPageID="mp" SkinID="Long">
            <Tabs>
                <cp:CPMisTab runat="server" Text="查询书商订单">
                </cp:CPMisTab>
            </Tabs>
        </cp:CPMisTabStrip>
        <cp:CPMisMultiPage runat="server" ID="mp" SkinID="Long">
            <cp:CPMisPageView runat="server" SkinID="Long">
                <div class="condition">
                    <cp:CPMisLabel ID="CPMisLabel1" runat="server" Text="学年学期"></cp:CPMisLabel>
                    <cp:CPMisComboBox runat="server" ID="ccmbTerm" DataSourceID="SqlDataSource_Term"
                        DataTextField="Term">
                    </cp:CPMisComboBox>
                    <asp:SqlDataSource ID="SqlDataSource_Term" runat="server" ConnectionString="<%$ ConnectionStrings:TbMISConnectionString %>"
                        ProviderName="System.Data.SqlClient" SelectCommand="prTermGetList" SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource>
                    <cp:CPMisLabel ID="CPMisLabel2" runat="server" Text="学院"></cp:CPMisLabel>
                    <cp:CPMisComboBox runat="server" ID="ccmbSchool" DataTextField="SchoolName" DataValueField="SchoolID"
                      SkinID="cmb200">
                    </cp:CPMisComboBox>
                    <asp:SqlDataSource ID="SqlDataSource_School" runat="server" ConnectionString="<%$ ConnectionStrings:TbMISConnectionString %>"
                        ProviderName="System.Data.SqlClient" SelectCommand="prSchoolNameGetList" SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource>
                    &nbsp;&nbsp
                    <cp:CPMisButton runat="server" ID="cbtnQuery" Text="查询" OnClick="cbtnQuery_Click"/>
                </div>
                <div>
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server">
                        <LocalReport ReportPath="ReportViews\Orders\AcadamicBooksellerOrder.rdlc">
                            <DataSources>
                                <rsweb:ReportDataSource DataSourceId="sqlBooksellerOrderBySchoolID" Name="DataSet1" />
                            </DataSources>
                        </LocalReport>
                    </rsweb:ReportViewer>
                    <asp:SqlDataSource ID="sqlBooksellerOrderBySchoolID" runat="server" ConnectionString="<%$ ConnectionStrings:TbMISConnectionString %>"
                        SelectCommand="prReportGetBooksellerOrderBySchoolID" SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="sqlBooksellerOrderBySchool" runat="server" ConnectionString="<%$ ConnectionStrings:TbMISConnectionString %>"
                        SelectCommand="prReportGetBooksellerOrderBySchool" SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource>
                </div>
            </cp:CPMisPageView>
        </cp:CPMisMultiPage>
    </div>
    </form>
</body>
</html>
