<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateBooksellerStaffForms.aspx.cs"
    Inherits="CPMis.WebPage.Tb_Maintain.UpdateBooksellerStaffForms" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../App_Themes/CPMisTheme/style.css" type="text/css" rel="Stylesheet" />
    <style type="text/css">
        .table
        {
            border: 0;
            padding: 0;
            margin: 0;
            height: 200px;
            margin-left: auto;
            margin-right: auto;
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
        #form1
        {
            width: 400px;
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
            <telerik:AjaxSetting AjaxControlID="btnCancel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ctxtWorkerName" />
                    <telerik:AjaxUpdatedControl ControlID="ccmbSex" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnConfirm">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ctxtWorkerName" />
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
        <table class="table">
            <tr>
                <td class="style3" align="right">
                    <cp:CPMisLabel runat="server" Text="书商名称" SkinID="AutoSize"></cp:CPMisLabel>&nbsp;&nbsp;
                </td>
                <td class="style2" colspan="3">
                    <cp:CPMisTextBox runat="server" ID="ctxtBooksellerName" Enabled="false" SkinID="Disabled"
                        Width="156">
                    </cp:CPMisTextBox>
                </td>
            </tr>
            <tr>
                <td class="style3" align="right">
                    <cp:CPMisLabel runat="server" Text="员工姓名" SkinID="AutoSize" Enabled="True"></cp:CPMisLabel>
                    <cp:CPMisLabel runat="server" SkinID="Xing" Text="*"></cp:CPMisLabel>
                </td>
                <td class="style2" colspan="3">
                    <cp:CPMisTextBox ID="ctxtWorkerName" SkinID="tb160" runat="server">
                    </cp:CPMisTextBox><cp:CPMisLabel ID="CPMisLabel5" runat="server" SkinID="Paraset"
                        Text="如:张三"></cp:CPMisLabel>
                </td>
            </tr>
            <tr>
                <td class="style3" align="right">
                    <cp:CPMisLabel runat="server" Text="性别" SkinID="AutoSize"></cp:CPMisLabel>
                    <cp:CPMisLabel runat="server" SkinID="Xing" Text="*"></cp:CPMisLabel>
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
                    <cp:CPMisButton ID="btnConfirm" runat="server" Text="确定" OnClick="btnConfirm_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
                    <cp:CPMisButton ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
