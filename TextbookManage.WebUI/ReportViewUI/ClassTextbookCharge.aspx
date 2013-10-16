<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassTextbookCharge.aspx.cs" Inherits="CPMis.WebPage.ReportViewersUI.ClassTextbookCharge" %>

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
            width: 995px;
            background-color: #E1EBF7;
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
                  
            <telerik:AjaxSetting AjaxControlID="ccmbTerm">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ccmbTerm">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>

            <telerik:AjaxSetting AjaxControlID="ccmbSchool">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ccmbProfessionalClass">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbGrade">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ccmbProfessionalClass">
                    </telerik:AjaxUpdatedControl>
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
    <div style="width: 1000px">
        <cp:CPMisTabStrip ID="CPMisTabStrip1"  runat="server" MultiPageID="mp" SkinID="Long"
            SelectedIndex="0">
            <Tabs>
                <cp:CPMisTab runat="server" Text="打印班级教材费用结算単" SkinID="AutoSize">
                </cp:CPMisTab>
            </Tabs>
        </cp:CPMisTabStrip>
        <cp:CPMisMultiPage runat="server" ID="mp" SkinID="Long">
            <cp:CPMisPageView ID="CPMisPageView1" runat="server" SkinID="Long">
                <table class="table">
                    <tr>
                        <td class="textcol">
                            学年学期
                        </td>
                        <td class="controlcol">&nbsp;&nbsp;
                            <cp:CPMisComboBox runat="server" ID="ccmbTerm" DataSourceID="DsTerm" DataTextField="Term"
                                DataValueField="TermNum" AutoPostBack="true">
                            </cp:CPMisComboBox>
                        </td>
                        <td class="textcol">
                            学院
                        </td>
                        <td class="controlcol">&nbsp;&nbsp;
                            <cp:CPMisComboBox runat="server" ID="ccmbSchool" DataSourceID="DsSchool" DataTextField="SchoolName"
                                DataValueField="SchoolID" AutoPostBack="true">
                            </cp:CPMisComboBox>
                        </td>
                        <td class="textcol">
                            年级
                        </td>
                        <td class="controlcol">&nbsp;&nbsp;
                            <cp:CPMisComboBox runat="server" ID="ccmbGrade" DataSourceID="DsGrade"
                                DataTextField="Grade"  AutoPostBack="true">
                            </cp:CPMisComboBox>
                        </td>
                         <td class="textcol">
                            专业班级
                        </td>
                        <td class="controlcol">&nbsp;&nbsp;
                            <cp:CPMisComboBox runat="server" ID="ccmbProfessionalClass" DataSourceID="DsProfessionalClass"
                                DataTextField="ClassName" DataValueField="ClassID" AutoPostBack="true">
                            </cp:CPMisComboBox>
                        </td>
                        <td class="controlcol">&nbsp;&nbsp;
                            <cp:CPMisButton runat="server" ID="cbtnQuery" Text="查询" OnClick="cbtnQuery_Click" />
                        </td>
                    </tr>
                </table>
    <div>
    <rsweb:ReportViewer runat="server" ID="rvClassTextbookCharge" Font-Names="Verdana" CssClass="reportview"
            Font-Size="8pt" InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana" >
          
        <LocalReport ReportPath="ReportViews\ClassTextbookCharge.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="DsClassTextbookCharge" Name="DataSet1" />
            </DataSources>
        </LocalReport>
        </rsweb:ReportViewer>
        <asp:SqlDataSource ID="DsClassTextbookCharge" runat="server" 
            ConnectionString="<%$ ConnectionStrings:TbMISConnectionString %>" 
            SelectCommand="prReportClassChargeGetByCondition" 
            SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter Name="ClassId" Type="String" />
                <asp:Parameter Name="Term" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
         <asp:SqlDataSource ID="DsTerm" runat="server" ConnectionString="<%$ ConnectionStrings:TbMISConnectionString %>"
                        SelectCommand="prTermGetList" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
         <asp:SqlDataSource ID="DsSchool" runat="server" ConnectionString="<%$ ConnectionStrings:TbMISConnectionString %>"
                        SelectCommand="prSchoolNameGetList" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
         <asp:SqlDataSource ID="DsGrade" runat="server" 
            ConnectionString="<%$ ConnectionStrings:TbMISConnectionString %>" 
            SelectCommand="prGradeGetList" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
         <asp:SqlDataSource ID="DsProfessionalClass" runat="server" 
            ConnectionString="<%$ ConnectionStrings:TbMISConnectionString %>" 
            SelectCommand="prProfessionalClassGetListByCondition" 
            SelectCommandType="StoredProcedure">
             <SelectParameters>
                <asp:ControlParameter ControlID="ccmbSchool" Name="SchoolID" PropertyName="SelectedValue" DbType="String" />
                <asp:ControlParameter ControlID="ccmbGrade" Name="Grade" PropertyName="SelectedText" DbType="String" />
             </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </cp:CPMisPageView>
    </cp:CPMisMultiPage>
    </div>
    </form>
</body>
</html>
