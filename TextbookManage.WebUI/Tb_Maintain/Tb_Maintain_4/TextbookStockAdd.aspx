<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TextbookStockAdd.aspx.cs"
    Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_4.TextbookStockAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            border:0px;
            margin: 0;
            padding: 0;
        }
        .style2
        {
            color: Red;
        }
        .style3
        {
            border: 0;
            margin: 0;
            padding: 0;
        }
        .style4
        {
            color: Gray;
            border: 0;
            margin: 0;
            padding: 0;
        }
        .style5
        {
            height: 20px;
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
    </telerik:RadAjaxManager>
    <telerik:RadFormDecorator ID="RadFormDecorator2" runat="server" DecoratedControls="All" />
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
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" />
    <cp:CPMisTabStrip ID="CPMisTabStrip1" runat="server" SkinID="Long">
        <Tabs>
            <telerik:RadTab Text="新增仓库信息">
            </telerik:RadTab>
        </Tabs>
    </cp:CPMisTabStrip>
    <cp:CPMisMultiPage ID="CPMisMultiPage1" runat="server" SkinID="Long">
        <telerik:RadPageView ID="RadPageView1" runat="server">
            <table class="style1">
                <tr class="style5">
                    <td class="style3" align="right">
                        <cp:CPMisLabel ID="clalBooksellerName" runat="server" Text="书商名称：" SkinID="AutoSize"></cp:CPMisLabel>
                        <span class="style2">*</span>
                    </td>
                    <td class="style3">
                        <cp:CPMisComboBox ID="cdlstBooksellerName" runat="server" DataTextField="BookSellerName" DataValueField="BookSellerId">                                                        
                        </cp:CPMisComboBox>                      
                    </td>
                    <td class="style4" align="left">
                        <cp:CPMisLabel ID="CPMisLabel2" runat="server" Text="如：新华书店" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                </tr>
                <tr class="style5">
                    <td class="style3" align="right">
                        <cp:CPMisLabel ID="clalStockName" runat="server" Text="仓库名称：" SkinID="AutoSize"></cp:CPMisLabel>
                        <span class="style2">*</span>
                    </td>
                    <td class="style3">
                        <cp:CPMisTextBox ID="ctxtStockName" runat="server">
                        </cp:CPMisTextBox>
                    </td>
                    <td class="style4" align="left">
                        <cp:CPMisLabel ID="clalStockNameExample" runat="server" Text="如：北校仓库" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                </tr>
                <tr class="style5">
                    <td class="style3" align="right">
                        <cp:CPMisLabel ID="clalStockAddress" runat="server" Text="仓库地址：" SkinID="AutoSize"></cp:CPMisLabel>
                        <span class="style2">*</span>
                    </td>
                    <td class="style3">
                        <cp:CPMisTextBox ID="ctxtStockAddress" runat="server">
                        </cp:CPMisTextBox>
                    </td>
                    <td class="style4" align="left">
                        <cp:CPMisLabel ID="clalStockAddressExample" runat="server" Text="如：北校一栋0层" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                </tr>
                <tr class="style5">
                    <td class="style3" align="right">
                        <cp:CPMisLabel ID="clalTelephone" runat="server" Text="联系电话：" SkinID="AutoSize"></cp:CPMisLabel>
                        <span class="style2">*</span>
                    </td>
                    <td class="style3">
                        <cp:CPMisTextBox ID="ctxtTelephone" runat="server">
                        </cp:CPMisTextBox>
                    </td>
                    <td class="style4" align="left">
                        <cp:CPMisLabel ID="clalTelephoneExample" runat="server" Text="如：07348830876" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                </tr>
                <tr class="style5">
                    <td class="style3" align="right">
                        <cp:CPMisLabel ID="clalAccountBeginDate" runat="server" Text="账务开始时间：" SkinID="AutoSize"></cp:CPMisLabel>
                        <span class="style2">*</span>
                    </td>
                    <td style="width: 178px;" class="style3">
                        <cp:CPMisDatePicker ID="CPMisDatePicker1" runat="server" Style="margin-left: 4px;" Width="160px">
                        </cp:CPMisDatePicker>
                    </td>
                    <td class="style4" align="left">
                        <cp:CPMisLabel ID="clalAccountBeginDateExample" runat="server" Text="如：2009/09/18 "
                            SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                    <tr>
                        <td align="center" colspan="3">
                            <cp:CPMisButton ID="cbtnSave" runat="server" Text="保存" SkinID="bt40" OnClick="cbtnSave_Click"
                                ValidationGroup="BaseInfoGroup" />&nbsp; &nbsp;
                            <cp:CPMisButton ID="cbtnCancle" runat="server" Text="取消" SkinID="bt40" OnClick="cbtnCancle_Click" />
                        </td>
                    </tr>
            </table>
            <asp:ValidationSummary ID="vds_OverseasAdd" ValidationGroup="BaseInfoGroup" ShowSummary="false"
                ShowMessageBox="true" HeaderText="验证信息出错!" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="None"
                ValidationGroup="BaseInfoGroup" ErrorMessage="仓库名称不能为空，请填写仓库名称！" ControlToValidate="ctxtStockName">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="ctxtStockName"
                Display="None" ValidationGroup="BaseInfoGroup" ValidationExpression="[a-zA-Z0-9\u4e00-\u9fa5]+"
                ErrorMessage="仓库名格式错误，请输入正确的仓库名！">
            </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None"
                ValidationGroup="BaseInfoGroup" ErrorMessage="仓库地址不能为空，请填写仓库地址！" ControlToValidate="ctxtStockAddress">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="ctxtStockAddress"
                Display="None" ValidationGroup="BaseInfoGroup" ValidationExpression="[a-zA-Z0-9\u4e00-\u9fa5]+"
                ErrorMessage="仓库地址格式错误，请输入正确的仓库地址！">
            </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None"
                ValidationGroup="BaseInfoGroup" ErrorMessage="联系方式不能为空，请填写联系方式！" ControlToValidate="ctxtTelephone">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="ctxtTelephone"
                Display="None" ValidationGroup="BaseInfoGroup" ValidationExpression="^[0-9]{5,12}$"
                ErrorMessage="联系方式格式错误，请输入正确的联系方式！">
            </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None"
                ValidationGroup="BaseInfoGroup" ErrorMessage="账务开始时间不能为空，请填写账务开始时间！" ControlToValidate="CPMisDatePicker1">
            </asp:RequiredFieldValidator>
            <br />
        </telerik:RadPageView>
    </cp:CPMisMultiPage>
    </form>
</body>
</html>
