<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnableAlert.aspx.cs" Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_19.EnableAlert" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .border
        {
            border: 0;
            margin: 0;
            padding: 0;
            margin-left: auto;
            margin-right: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
    </telerik:RadSkinManager>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <script type="text/javascript" language="javascript">
        function OnClientValidateClick(GroupName) {
            Page_ClientValidate(GroupName); //先验证
            if (Page_IsValid) {
                return confirm('确认更新?'); //后更新
            } else {
                return false;
            }
        }
    </script>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline">
        <ClientEvents OnRequestStart="onRequestStart" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cdropAlertName">
                <UpdatedControls>
                    <%--<telerik:AjaxUpdatedControl ControlID="chkIsCurrentTerm" LoadingPanelID="RadAjaxLoadingPanel1" />--%>
                    <telerik:AjaxUpdatedControl ControlID="ctxtAlertName" />
                    <telerik:AjaxUpdatedControl ControlID="cdateBeginDate" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="cdateEndDate" />
                    <%--LoadingPanelID="RadAjaxLoadingPanel1"--%>
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
    <div id="tool" runat="server" class="sty_div">
        <cp:CPMisToolBar ID="CPMisToolBar1" runat="server" SkinID="Long">
            <Items>
                <telerik:RadToolBarButton runat="server" CommandName="help" Text="帮助" ImageUrl="~/Img/tlb_Help.png">
                </telerik:RadToolBarButton>
            </Items>
        </cp:CPMisToolBar>
    </div>
    <div>
        <cp:CPMisTabStrip runat="server" ID="tabStrip" MultiPageID="cterm" SkinID="Long">
            <Tabs>
                <cp:CPMisTab Text="修改提醒信息">
                </cp:CPMisTab>
            </Tabs>
        </cp:CPMisTabStrip>
        <cp:CPMisMultiPage runat="server" ID="cteacher" SkinID="Long">
            <cp:CPMisPageView ID="CPMisPageView1" runat="server">
                <table class="border">
                    <tr>
                        <td class="border" align="right">
                            <asp:Label ID="lblTerm" Text="提醒名称：" runat="server">
                            </asp:Label>
                        </td>
                        <td class="border" align="left">
                            <cp:CPMisComboBox runat="server" ID="cdropAlertName" SkinID="AutoSize" AutoPostBack="true">
                                <%--Width="125px"--%>
                            </cp:CPMisComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="border" align="right">
                            <asp:Label ID="Label1" Text="开始日期：" runat="server">
                            </asp:Label>
                        </td>
                        <td class="border" align="left">
                            <cp:CPMisTextBox runat="server" ID="ctxtStartDate" ReadOnly="true" SkinID="tb160">
                            </cp:CPMisTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="border" align="right">
                            <asp:Label ID="Label2" Text="结束日期：" runat="server">
                            </asp:Label>
                        </td>
                        <td class="border" align="left">
                            <cp:CPMisTextBox runat="server" ID="ctxtEndDate" ReadOnly="true" SkinID="tb160">
                            </cp:CPMisTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="border" align="right">
                            <cp:CPMisLabel runat="server" Text="状态："></cp:CPMisLabel>
                        </td>
                        <td class="border" align="left">
                            <cp:CPMisTextBox runat="server" ID="ctxtStatus" ReadOnly="true" SkinID="160">
                            </cp:CPMisTextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <div style="text-align: center">
                    <cp:CPMisButton ID="cbtnExchange" runat="server" Text="状态切换" />
                </div>
            </cp:CPMisPageView>
        </cp:CPMisMultiPage>
    </div>
    </form>
</body>
</html>
