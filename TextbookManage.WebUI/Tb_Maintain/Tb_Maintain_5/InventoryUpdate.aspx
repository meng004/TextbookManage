<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryUpdate.aspx.cs"
    Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_5.InventoryUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .border
        {
            border: 0;
            margin: 0;
            padding: 0;
        }
    </style>
</head>
<script type="text/javascript" language="javascript">
    function CloseAndRebind() {
        GetRadWindow().BrowserWindow.refreshGrid();
        GetRadWindow().close();
        return false;
    }
    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

        return oWindow;
    }
    function OnInputCount() {
        var txt = $find("<%=ctxtInputCount.ClientID%>");
        var reg = /^[0-9]+$/;
        var re = reg.test(txt.get_value());
        if (txt.get_value().length == 0 || re == false) {
            alert("入库数量不正确或不能为空！");
            txt.set_value("");
            txt.focus();
        }

    }
    function OnStoreCount() {
        var txt = $find("<%=ctxtStoreCount.ClientID%>");
        var reg = /^[0-9]+$/;
        var re = reg.test(txt.get_value());
        if (txt.get_value().length == 0 || re == false) {
            alert("库存数量不正确或不能为空！");
            txt.set_value("");
            txt.focus();
        }
    }
    function OnReleseCount() {
        var txt = $find("<%=ctxtReleseCount.ClientID%>");
        var reg = /^[0-9]+$/;
        var re = reg.test(txt.get_value());
        if (txt.get_value().length == 0 || re == false) {
            alert("发放数量不正确或不能为空！");
            txt.set_value("");
            txt.focus();
        }
    }
    function warning() {
        var inputCount = new Number($find("<%=ctxtInputCount.ClientID%>").get_value());
        var storeCount = new Number($find("<%=ctxtStoreCount.ClientID%>").get_value());
        var releseCount = new Number($find("<%=ctxtReleseCount.ClientID%>").get_value());
        if (inputCount - releseCount != storeCount) {
            return confirm('库存数量≠入库数量-发放数量！！是否继续保存？？');
        }
    }
</script>
<body>
    <form id="form1" runat="server">
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
    </telerik:RadSkinManager>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline">
        <ClientEvents OnRequestStart="onRequestStart" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cbntQuery">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdTeacherQuery" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cgrdTeacherQuery">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdTeacherQuery" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
    <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" AutoTooltipify="true">
    </telerik:RadToolTipManager>
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
        <table class="border">
            <tr style="height: 30px">
                <td class="border" align="right">
                    教材名称：
                </td>
                <td class="border">
                    <span style="color: Red">*</span>
                </td>
                <td class="border">
                    <cp:CPMisTextBox ID="ctxtTextbookName" runat="server" SkinID="Disabled" Enabled="false" Width="196">
                    </cp:CPMisTextBox>
                </td>
            </tr>
            <tr style="height: 30px">
                <td class="border" align="right">
                    仓库名称：
                </td>
                <td class="border">
                    <span style="color: Red">*</span>
                </td>
                <td class="border">
                    <cp:CPMisTextBox ID="ctxtStockName" runat="server" SkinID="Disabled" Enabled="false" Width="196">
                    </cp:CPMisTextBox>
                </td>
            </tr>
            <tr style="height: 30px">
                <td class="border" align="right">
                    入库数量：
                </td>
                <td class="border">
                    <span style="color: Red">*</span>
                </td>
                <td class="border">
                    <cp:CPMisTextBox ID="ctxtInputCount" runat="server" onblur="OnInputCount();return false;"
                        SkinID="txt200">
                    </cp:CPMisTextBox>
                </td>
                <td class="border" style="color: Gray">
                    如：234
                </td>
            </tr>
            <tr style="height: 30px">
                <td class="border" align="right">
                    库存数量：
                </td>
                <td class="border">
                    <span style="color: Red" class="border">*</span>
                </td>
                <td class="border">
                    <cp:CPMisTextBox ID="ctxtStoreCount" runat="server" onblur="OnStoreCount();return false;"
                        SkinID="txt200">
                    </cp:CPMisTextBox>
                </td>
                <td class="border" style="color: Gray" align="left">
                    如：34
                </td>
            </tr>
            <tr style="height: 30px">
                <td class="border" align="right">
                    发放数量：
                </td>
                <td class="border">
                    <span style="color: Red">*</span>
                </td>
                <td class="border">
                    <cp:CPMisTextBox ID="ctxtReleseCount" runat="server" onblur="OnReleseCount();return false;"
                        SkinID="txt200">
                    </cp:CPMisTextBox>
                </td>
                <td class="border" style="color: Gray">
                    如：200
                </td>
            </tr>
        </table>
        <br />
        <div style="text-align: center">
            <cp:CPMisButton ID="cbtnSumbit" runat="server" OnClick="cbtnSumbit_Click" OnClientClick="return warning();"
                Text="确定" SkinID="bt40" />
            &nbsp;
            <cp:CPMisButton ID="cbtnCancle" runat="server" OnClick="cbtnCancle_Click" Text="取消"
                SkinID="bt40" />
        </div>
    </div>
    </form>
</body>
</html>
