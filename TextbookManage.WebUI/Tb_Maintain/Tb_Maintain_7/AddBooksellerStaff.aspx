<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBooksellerStaff.aspx.cs"
    Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_7.AddBooksellerStaff" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .fieldset
        {
            margin-top: 80px;
            margin-left: 300px;
            margin-bottom: 300px;
            width: 360px;
        }
        .table
        {
            border: 0;
            padding: 0;
            margin: 0;
            width: 350px;
            margin-left:auto;
            margin-right:auto;
        }
        
        .style2
        {
            padding: 0;
            margin: 0;
            border: 0;
            text-align: left;
        }
        .style3
        {
            padding: 0;
            margin: 0;
            border: 0;
            text-align: right;
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
            <telerik:AjaxSetting AjaxControlID="cbtnAdd">
                <UpdatedControls>
                   <telerik:AjaxUpdatedControl ControlID="ctxtStaffName" />
                    <telerik:AjaxUpdatedControl ControlID="ccmbBooksellerName" />
                    <telerik:AjaxUpdatedControl ControlID="ccmbSex" />
                </UpdatedControls>
            </telerik:AjaxSetting>
              <telerik:AjaxSetting AjaxControlID="btnCancel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ctxtStaffName" />
                    <telerik:AjaxUpdatedControl ControlID="ccmbBooksellerName" />
                    <telerik:AjaxUpdatedControl ControlID="ccmbSex" />
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
        <cp:CPMisTabStrip ID="CPMisTabStrip1" runat="server" MultiPageID="mp" SkinID="Long">
            <Tabs>
                <cp:CPMisTab runat="server" Text="新增书商员工">
                </cp:CPMisTab>
            </Tabs>
        </cp:CPMisTabStrip>
        <div>
            <cp:CPMisMultiPage runat="server" SkinID="Long">
                <cp:CPMisPageView runat="server" SkinID="Long">
                    <div style="text-align: center">
                        <table class="table">
                            <tr>
                                <td class="style3" align="right">
                                    <cp:CPMisLabel ID="CPMisLabel1" runat="server" Text="书商名称" SkinID="AutoSize"></cp:CPMisLabel>
                                    <cp:CPMisLabel ID="CPMisLabel2" runat="server" SkinID="Xing" Text="*"></cp:CPMisLabel>
                                </td>
                                <td class="style2" colspan="3">
                                    <cp:CPMisComboBox runat="server" ID="ccmbBooksellerName"
                                        DataTextField="BooksellerName" DataValueField="BooksellerID">
                                    </cp:CPMisComboBox>
                                    <asp:SqlDataSource ID="SqlDataSource_Bookseller" runat="server" ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>"
                                        ProviderName="System.Data.SqlClient" SelectCommand="prBookSellerNameGetList"
                                        SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="style3" align="right">
                                    <cp:CPMisLabel ID="CPMisLabel3" runat="server" Text="姓名" SkinID="AutoSize" Enabled="True"></cp:CPMisLabel>
                                    <cp:CPMisLabel ID="CPMisLabel4" runat="server" SkinID="Xing" Text="*"></cp:CPMisLabel>
                                </td>
                                <td class="style2" colspan="3">
                                    <cp:CPMisTextBox ID="ctxtStaffName" SkinID="tb160" runat="server">
                                    </cp:CPMisTextBox><cp:CPMisLabel ID="CPMisLabel5" runat="server" SkinID="Paraset"
                                        Text="如:张三"></cp:CPMisLabel>
                                </td>
                            </tr>
                            <tr>
                                <td class="style3" align="right">
                                    <cp:CPMisLabel ID="CPMisLabel6" runat="server" Text="性别" SkinID="AutoSize"></cp:CPMisLabel>
                                    <cp:CPMisLabel ID="CPMisLabel7" runat="server" SkinID="Xing" Text="*"></cp:CPMisLabel>
                                </td>
                                <td class="style2" colspan="3">
                                    <cp:CPMisComboBox runat="server" ID="ccmbSex">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="男" />
                                            <telerik:RadComboBoxItem Text="女" />
                                            <telerik:RadComboBoxItem Text="未知" />
                                        </Items>
                                    </cp:CPMisComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="text-align: center;">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
                                    <cp:CPMisButton ID="cbtnAdd" runat="server" Text="新增" OnClick="cbtnAdd_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
                                    <cp:CPMisButton ID="btnCancel" runat="server" Text="取消"  OnClick="btnCancel_Click"/>
                                </td>
                            </tr>
                        </table>
                    </div>
                </cp:CPMisPageView>
            </cp:CPMisMultiPage>
        </div>
    </div>
    </form>
</body>
</html>
