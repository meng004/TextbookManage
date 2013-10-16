<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentTextbookFee.aspx.cs"
    Inherits="CPMis.WebPage.ReportViewsUI.StudentTextbookFee" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <style type="text/css">
        .div1
        {
            float: left;
        }
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
            text-align:right;
            }
         .controlcol
         {
             text-align:center;
             }
          .table
          {
              width:990px;
            
              }   
       .Center
       {
          text-align:center;
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
                    <telerik:AjaxUpdatedControl ControlID="ccmbProfessionalClass" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ccmbGrade">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ccmbProfessionalClass" LoadingPanelID="RadAjaxLoadingPanel1">
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
    <div class="div1">
        <cp:CPMisToolBar runat="server" SkinID="Long">
            <Items>
                <telerik:RadToolBarButton runat="server" Text="帮助" ImageUrl="~/Img/tlb_Help.png">
                </telerik:RadToolBarButton>
            </Items>
        </cp:CPMisToolBar>
    </div>
    <div class="div1">
        <cp:CPMisTabStrip runat="server" MultiPageID="mp" SkinID="Long">
            <Tabs>
                <cp:CPMisTab runat="server" Text="查询学生教材费用">
                </cp:CPMisTab>
            </Tabs>
        </cp:CPMisTabStrip>
        <cp:CPMisMultiPage runat="server" ID="mp" SkinID="Long">
            <cp:CPMisPageView runat="server" SkinID="Long">
                <div style="background-color: #D6E2F2;">
                    <table class="table">
                        <tr>
                            <td class="textcol">
                                <cp:CPMisLabel runat="server" Text="学年学期"></cp:CPMisLabel>
                            </td>
                            <td class="controlcol">
                                <cp:CPMisComboBox runat="server" ID="ccmbTerm" DataSourceID="SqlDataSource_Term"
                                    DataTextField="Term">
                                </cp:CPMisComboBox>
                                <asp:SqlDataSource ID="SqlDataSource_Term" runat="server" ConnectionString="<%$ ConnectionStrings:TbMISConnectionString %>"
                                    ProviderName="System.Data.SqlClient" SelectCommand="prTermGetList" SelectCommandType="StoredProcedure">
                                </asp:SqlDataSource>
                            </td>
                            <td class="textcol">
                                <cp:CPMisLabel runat="server" Text="学院"></cp:CPMisLabel>
                            </td>
                            <td class="controlcol">
                                <cp:CPMisComboBox runat="server" ID="ccmbSchool" DataSourceID="SqlDataSource_School"
                                    DataTextField="SchoolName" DataValueField="SchoolID" AutoPostBack="true" SkinID="cmb200">
                                </cp:CPMisComboBox>
                                <asp:SqlDataSource ID="SqlDataSource_School" runat="server" ConnectionString="<%$ ConnectionStrings:TbMISConnectionString %>"
                                    ProviderName="System.Data.SqlClient" SelectCommand="prSchoolNameGetList" SelectCommandType="StoredProcedure">
                                </asp:SqlDataSource>
                            </td>
                            <td class="textcol">
                                <cp:CPMisLabel runat="server" Text="年级"></cp:CPMisLabel>
                            </td>
                            <td class="controlcol">
                                <cp:CPMisComboBox runat="server" ID="ccmbGrade" DataSourceID="SqlDataSource_Grade"
                                    DataTextField="Grade" AutoPostBack="true" SkinID="cmb80">
                                </cp:CPMisComboBox>
                                <asp:SqlDataSource ID="SqlDataSource_Grade" runat="server" ConnectionString="<%$ ConnectionStrings:TbMISConnectionString %>"
                                    ProviderName="System.Data.SqlClient" SelectCommand="prGradeGetList" SelectCommandType="StoredProcedure">
                                </asp:SqlDataSource>
                            </td>
                            <td class="textcol">
                                <cp:CPMisLabel runat="server" Text="专业班级"></cp:CPMisLabel>
                            </td>
                            <td class="controlcol">
                                <cp:CPMisComboBox runat="server" ID="ccmbProfessionalClass" DataSourceID="SqlDataSource_ProfessionalClass"
                                    DataTextField="ClassName" DataValueField="ClassID">
                                </cp:CPMisComboBox>
                                <asp:SqlDataSource ID="SqlDataSource_ProfessionalClass" runat="server" ConnectionString="<%$ ConnectionStrings:TbMISConnectionString %>"
                                    ProviderName="System.Data.SqlClient" SelectCommand="prProfessionalClassGetListByCondition"
                                    SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ccmbSchool" Name="SchoolID" DbType="Guid" PropertyName="SelectedValue" />
                                        <asp:ControlParameter ControlID="ccmbGrade" Name="Grade" DbType="String" PropertyName="SelectedText" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                            <td class="controlcol">
                               <cp:CPMisButton runat="server" ID="cbtnQuery" Text="查询" OnClick="cbtnQuery_Click"/>
                            </td>
                        </tr>
                    </table>
                </div>
                   <div style="width:851px; margin-left:auto;margin-right:auto;">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" SkinID="AutoSize" Width="850px">
                        <LocalReport ReportPath="ReportViews\StudentTextbookFee.rdlc">
                            <DataSources>
                                <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
                            </DataSources>
                        </LocalReport>
                    </rsweb:ReportViewer>
                   </div>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TbMISConnectionString %>"
                        SelectCommand="prReportStudentChargeGetByCondition" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="计算机科学与技术学院" Direction="InputOutput" Name="SchoolName"
                                Type="String" />
                            <asp:Parameter Name="ClassName" Type="String" />
                            <asp:Parameter Name="Term" Type="String" />
                            <asp:Parameter Name="StudentCount" Type="Int32" Direction="Output"/>
                        </SelectParameters>
                    </asp:SqlDataSource>
            </cp:CPMisPageView>
        </cp:CPMisMultiPage>
    </div>
    </form>
</body>
</html>
