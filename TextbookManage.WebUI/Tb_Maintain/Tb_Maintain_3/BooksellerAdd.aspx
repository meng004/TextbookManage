<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BooksellerAdd.aspx.cs"
    Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_3.BooksellerAdd" %>

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
            margin-left:auto;
            margin-right:auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ValidationSummary ID="vds_OverseasAdd" ValidationGroup="BaseInfoGroup" ShowSummary="false"
        ShowMessageBox="true" HeaderText="验证信息出错!" runat="server" />
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
    <cp:CPMisTabStrip runat="server" ID="tabStrip" MultiPageID="cbooksellerUpdate" TabIndex="0" SkinID="Long">
        <Tabs>
            <cp:CPMisTab Text="新增书商信息">
            </cp:CPMisTab>
        </Tabs>
    </cp:CPMisTabStrip>
    <cp:CPMisMultiPage runat="server" ID="cbooksellerUpdate" SkinID="Long">
        <cp:CPMisPageView ID="CPMisPageView1" runat="server" Selected="true"> 
            <table class="border">
                <tr>
                    <td class="border" align="right">
                        书商名称：
                    </td>
                    <td class="border">
                        <span style="color: Red" class="border">*</span>
                    </td>
                    <td class="border">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="None"
                            ValidationGroup="BaseInfoGroup" ErrorMessage="书商名称不能为空，请填写书商名称！" ControlToValidate="ctxtBooksellerName">
                        </asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="ctxtBooksellerName" 
                            Display="None" ValidationGroup="BaseInfoGroup" ValidationExpression="[a-zA-Z0-9\u4e00-\u9fa5]+" ErrorMessage="书商名称格式错误，请填重新写书商名称！"></asp:RegularExpressionValidator>
                        <cp:CPMisTextBox ID="ctxtBooksellerName" runat="server" SkinID="txt200">
                        </cp:CPMisTextBox>
                    </td>
                    <td class="border" style="color: Gray" align="left">
                        如:新华书店
                    </td>
                </tr>
                <tr>
                    <td class="border" align="right">
                        联系人：
                    </td>
                    <td class="border">
                    </td>
                    <td class="border">
                        <cp:CPMisTextBox ID="ctxtContact" runat="server" SkinID="txt200">
                        </cp:CPMisTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="border" align="right">
                        联系电话：
                    </td>
                    <td class="border">
                    </td>
                    <td class="border">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="ctxtTelephone" 
                    Display="None" ValidationGroup="BaseInfoGroup" ValidationExpression="^\d{5,13}$" ErrorMessage="电话号码格式错误，请输入正确的电话号码！"></asp:RegularExpressionValidator>
                        <cp:CPMisTextBox ID="ctxtTelephone" runat="server" SkinID="txt200">
                        </cp:CPMisTextBox>
                    </td>
                    <td class="border" align="left"> 
                    </td>
                </tr>
            </table>
            <br />
            <div style="text-align: center">
                <cp:CPMisButton ID="cbtnSumbit" runat="server" OnClick="cbtnSumbit_Click" Text="确定"
                    SkinID="bt40" ValidationGroup="BaseInfoGroup" />
                &nbsp; &nbsp;
                <cp:CPMisButton ID="cbtnCancle" runat="server" OnClick="cbtnCancle_Click" Text="取消"
                    SkinID="bt40" />
                <br />
            </div>
            <%--   </fieldset>--%>
        </cp:CPMisPageView>
    </cp:CPMisMultiPage>
    </form>
</body>
</html>