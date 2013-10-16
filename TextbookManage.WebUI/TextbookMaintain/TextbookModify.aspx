<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TextbookModify.aspx.cs" Inherits="TextbookManage.WebUI.TextbookMaintain.TextbookModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑教材</title>
    <style type="text/css">
        .style1 {
            color: red;
        }

        .border {
            border: 0;
            margin: 0;
            padding: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ValidationSummary ID="vds_OverseasAdd" ValidationGroup="BaseInfoGroup" ShowSummary="false"
            ShowMessageBox="true" HeaderText="验证信息出错!" runat="server" />
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                //刷新父窗体，关闭自己
                function CloseAndRebind() {
                    GetRadWindow().BrowserWindow.refreshGrid();
                    GetRadWindow().close();
                    return false;
                }
                //获取父窗体RadWindow控制器
                function GetRadWindow() {
                    var oWindow = null;
                    if (window.radWindow)
                        oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                    else if (window.frameElement.radWindow)
                        oWindow = window.frameElement.radWindow; //IE (and Moz as well)
                    return oWindow;
                }
            </script>
        </telerik:RadCodeBlock>
        <div>
            <utm:UTMisToolBar ID="ctlbTextbook" runat="server">
                <Items>
                    <telerik:RadToolBarButton runat="server" CommandName="help" Text="帮助" ImageUrl="~/Img/tlb_Help.png">
                    </telerik:RadToolBarButton>
                </Items>
            </utm:UTMisToolBar>
        </div>
        <div>
            <utm:UTMisTabStrip runat="server" ID="tabStrip" MultiPageID="mp_Textbook">
                <Tabs>
                    <utm:UTMisTab runat="server" Text="新增教材信息" PageViewID="pv_Textbook" Selected="true">
                    </utm:UTMisTab>
                </Tabs>
            </utm:UTMisTabStrip>
            <utm:UTMisMultiPage runat="server" ID="mp_Textbook">
                <utm:UTMisPageView ID="pv_Textbook" runat="server">
                    <table class="border">
                        <tr>
                            <td class="border">
                                <utm:UTMisLabel ID="clblTextbookName" runat="server" Text="教材名称">
                                </utm:UTMisLabel>
                            </td>
                            <td class="border">
                                <span class="style1">* </span>
                            </td>
                            <td class="border" colspan="5">
                                <utm:UTMisTextBox ID="ctxtTextbookName" runat="server" SkinID="Changeable" Width="500">
                                </utm:UTMisTextBox>
                            </td>
                            <td class="border" align="left" style="color: Gray;">
                                <asp:Label ID="CPMisLabel1" runat="server" Text="如：UML和模式应用">
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="border">
                                <utm:UTMisLabel ID="clblAuthor" runat="server" Text="作者">
                                </utm:UTMisLabel>
                            </td>
                            <td class="border">
                                <span class="style1">*</span>
                            </td>
                            <td class="border" colspan="5">
                                <utm:UTMisTextBox ID="ctxtAuthor" runat="server" SkinID="Changeable" Width="500">
                                </utm:UTMisTextBox>
                            </td>
                            <td class="border" style="color: Gray;" align="left">
                                <asp:Label ID="CPMisLabel3" runat="server" Text="如：王红梅，胡明 ">
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="border">
                                <utm:UTMisLabel ID="clblISBN" runat="server" Text="ISBN">
                                </utm:UTMisLabel>
                            </td>
                            <td class="border"><span class="style1">*</span> </td>
                            <td class="border">
                                <utm:UTMisTextBox ID="ctxtISBN" runat="server">
                                </utm:UTMisTextBox>
                            </td>
                            <td align="left" class="border" style="color: Gray;">
                                <asp:Label ID="lal1" runat="server" Text="如：9787302112587">
                                </asp:Label>
                            </td>
                            <td class="border">
                                <utm:UTMisLabel ID="clblRetailPrice" runat="server" Text="定价">
                                </utm:UTMisLabel>
                            </td>
                            <td class="border"><span class="style1">*</span> </td>
                            <td class="border">
                                <utm:UTMisTextBox ID="ctxtRetailPrice" runat="server">
                                </utm:UTMisTextBox>
                            </td>
                            <td align="left" class="border" style="color: Gray;">
                                <asp:Label ID="CPMisLabel4" runat="server" Text="如：33.22(至多两位小数)">
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="border">
                                <utm:UTMisLabel ID="clblPress" runat="server" Text="出版社">
                                </utm:UTMisLabel>
                            </td>
                            <td class="border"><span class="style1">*</span> </td>
                            <td class="border">
                                <utm:UTMisComboBox ID="ccmbPress" runat="server" DataValueField="PressId" DataTextField="Name" AutoPostBack="true" MaxLength="10"
                                    OnBeforeDataBind="ccmbPress_BeforeDataBind"
                                    OnAfterDataBind="ccmbPress_AfterDataBind"
                                    OnSelectedIndexChanged="ccmbPress_SelectedIndexChanged">
                                </utm:UTMisComboBox>
                            </td>
                            <td align="left" class="border" style="color: Gray;">
                                <asp:Label ID="CPMisLabel5" runat="server" Text="如：清华大学出版社" Width="110">
                                </asp:Label>
                            </td>
                            <td class="border">
                                <utm:UTMisLabel ID="UTMisLabel1" runat="server" Text="出版地址">
                                </utm:UTMisLabel>
                            </td>
                            <td class="border"><span class="style1">*</span> </td>
                            <td class="border">
                                <utm:UTMisTextBox ID="ctxtPressAddress" runat="server" ReadOnly="true" BackColor="LightGray">
                                </utm:UTMisTextBox>
                            </td>
                            <td align="left" class="border" style="color: Gray;">如：北京</td>
                        </tr>
                        <tr>
                            <td class="border">
                                <utm:UTMisLabel ID="clblEdition" runat="server" Text="版本">
                                </utm:UTMisLabel>
                            </td>
                            <td class="border">
                                <span class="style1">*</span>
                            </td>
                            <td class="border">
                                <utm:UTMisTextBox ID="ctxtEdition" runat="server">
                                </utm:UTMisTextBox>
                            </td>
                            <td class="border" align="left" style="color: Gray;">
                                <asp:Label ID="CPMisLabel6" runat="server" Text="第五版，如：5">
                                </asp:Label>
                            </td>
                            <td class="border">
                                <utm:UTMisLabel ID="clblPrintingCount" runat="server" Text="版次">
                                </utm:UTMisLabel>
                            </td>
                            <td class="border">
                                <span class="style1">*</span>
                            </td>
                            <td class="border">
                                <utm:UTMisTextBox ID="ctxtPrintingCount" runat="server">
                                </utm:UTMisTextBox>
                            </td>
                            <td class="border" style="color: Gray;" align="left">
                                <asp:Label ID="CPMisLabel7" runat="server" Text="第6次印刷，如：6">
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="border">
                                <utm:UTMisLabel ID="clblPage" runat="server" Text="页数">
                                </utm:UTMisLabel>
                            </td>
                            <td class="border"><span class="style1">*</span></td>
                            <td class="border">
                                <utm:UTMisTextBox ID="ctxtPage" runat="server">
                                </utm:UTMisTextBox>
                            </td>
                            <td class="style6" align="left">
                                <asp:Label ID="Label1" runat="server" Text="如：600">
                                </asp:Label>
                            </td>
                            <td class="border">出版日期</td>
                            <td class="border"><span class="style1">*</span></td>
                            <td class="border">
                                <utm:UTMisDatePicker ID="ctxtPublishDate" runat="server">
                                </utm:UTMisDatePicker>
                            </td>
                            <td class="border" style="color: Gray;" align="left">
                                <asp:Label ID="Label3" runat="server" Text="如：2011-11-1">
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="border">
                                <utm:UTMisLabel ID="clblTextbookId" runat="server" Text="教材ID" Visible="false">
                                </utm:UTMisLabel>
                                <utm:UTMisLabel ID="clblIsSelfCompile" runat="server" Text="自编教材">
                                </utm:UTMisLabel>
                            </td>
                            <td class="border"><span class="style1">*</span></td>
                            <td class="border" align="left" colspan="4">
                                <utm:UTMisCheckBox runat="server" ID="chkIsSelfCompile"></utm:UTMisCheckBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="border">
                                <utm:UTMisLabel ID="clblType" runat="server" Style="font-family: Arial; font-size: medium"
                                    Text="教材类型">
                                </utm:UTMisLabel>
                            </td>
                            <td class="border"><span class="style1">*</span></td>
                            <td class="border" align="left" colspan="5">
                                <utm:UTMisTextBox ID="ctxtType" runat="server" SkinID="Changeable" Width="500">
                                </utm:UTMisTextBox>
                            </td>
                            <td class="border" style="color: Gray;" align="left">
                                <asp:Label ID="Label2" runat="server" Text="如：普通高等教育“十一五”国家级规划教材">
                                </asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table class="border" width="600px">
                        <tr>
                            <td class="border" align="right" width="90">
                                <utm:UTMisButton SkinID="bt60" ID="cbtnSubmit" runat="server" Text="确定"
                                    OnBeforeClick="cbtnSubmit_Click" OnAfterClick="cbtnSubmit_AfterClick"
                                    ValidationGroup="BaseInfoGroup"></utm:UTMisButton>
                            </td>
                            <td align="center" class="border" width="90">
                                <utm:UTMisButton ID="cbtnCancle" runat="server" OnClick="cbtnCancle_Click" SkinID="bt60"
                                    Text="取消" />
                            </td>
                        </tr>
                    </table>
                    <br />
                </utm:UTMisPageView>
            </utm:UTMisMultiPage>
        </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None"
            ValidationGroup="BaseInfoGroup" ErrorMessage="教材名称不能为空，请填写教材名称！" ControlToValidate="ctxtTextbookName"> 
        </asp:RequiredFieldValidator>
        <%--        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="ctxtTextbookName"
            Display="None" ValidationGroup="BaseInfoGroup" ValidationExpression="^[a-zA-Z0-9\u4e00-\u9fa5]+$"
            ErrorMessage="输入的教材名称格式错误，请重新输入！"> 
        </asp:RegularExpressionValidator>--%>
        <asp:RequiredFieldValidator
            ID="RequiredFieldValidator3" runat="server" Display="None" ValidationGroup="BaseInfoGroup"
            ErrorMessage="作者不能为空，请填写作者！" ControlToValidate="ctxtAuthor"> 
        </asp:RequiredFieldValidator>
        <%--        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="ctxtAuthor"
            Display="None" ValidationGroup="BaseInfoGroup" ValidationExpression="^[a-zA-Z0-9\u4e00-\u9fa5]+$"
            ErrorMessage="输入的作者格式错误，请重新输入！">
        </asp:RegularExpressionValidator>--%>
        <asp:RequiredFieldValidator
            ID="RequiredFieldValidator2" runat="server" Display="None" ValidationGroup="BaseInfoGroup"
            ErrorMessage="ISBN不能为空，请填写ISBN！" ControlToValidate="ctxtISBN"> 
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator
            ID="RegularExpressionValidator4" runat="server" ControlToValidate="ctxtISBN"
            Display="None" ValidationGroup="BaseInfoGroup" ValidationExpression="^[1-9][0-9]{10,15}$"
            ErrorMessage="输入的ISBN格式错误，请重新输入！"> 
        </asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="None" ValidationGroup="BaseInfoGroup"
            ErrorMessage="定价不能为空，请填写定价！" ControlToValidate="ctxtRetailPrice"> 
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator
            ID="RegularExpressionValidator2" runat="server" ControlToValidate="ctxtRetailPrice"
            Display="None" ValidationGroup="BaseInfoGroup" ValidationExpression="^[1-9]?[0-9]+(.[0-9]{0,2})?$"
            ErrorMessage="输入的定价格式错误，请重新输入！"> 
        </asp:RegularExpressionValidator>
<%--        <asp:RequiredFieldValidator
            ID="RequiredFieldValidator6" runat="server" Display="None" ValidationGroup="BaseInfoGroup"
            ErrorMessage="出版社不能为空，请填写出版社！" ControlToValidate="ctxtPress"> 
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="ctxtPress"
            Display="None" ValidationGroup="BaseInfoGroup" ValidationExpression="^[a-zA-Z0-9\u4e00-\u9fa5]+$"
            ErrorMessage="输入的出版社格式错误，请重新输入！"> 
        </asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator
            ID="RequiredFieldValidator9" runat="server" Display="None" ValidationGroup="BaseInfoGroup"
            ErrorMessage="出版社地址不能为空，请填写出版社地址！" ControlToValidate="ctxtPressAddress"> 
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="ctxtPressAddress"
            Display="None" ValidationGroup="BaseInfoGroup" ValidationExpression="^[a-zA-Z0-9\u4e00-\u9fa5]+$"
            ErrorMessage="输入的出版社地址格式错误，请重新输入！"> 
        </asp:RegularExpressionValidator>--%>
        <asp:RequiredFieldValidator
            ID="RequiredFieldValidator7" runat="server" Display="None" ValidationGroup="BaseInfoGroup"
            ErrorMessage="版本不能为空，请填写版本！" ControlToValidate="ctxtEdition">
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="ctxtEdition"
            Display="None" ValidationGroup="BaseInfoGroup" ValidationExpression="[1-9]+[0-9]*$"
            ErrorMessage="输入的版本格式错误，请重新输入！"> 
        </asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="None"
            ValidationGroup="BaseInfoGroup" ErrorMessage="版次不能为空，请填写版次！" ControlToValidate="ctxtPrintingCount">
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator
            ID="RegularExpressionValidator1" runat="server" ControlToValidate="ctxtPrintingCount"
            Display="None" ValidationGroup="BaseInfoGroup" ValidationExpression="[1-9]+[0-9]*$"
            ErrorMessage="输入的版次格式错误，请重新输入！"> 
        </asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="None"
            ValidationGroup="BaseInfoGroup" ErrorMessage="页数不能为空，请填写页数！" ControlToValidate="ctxtPage">
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="ctxtPage"
            Display="None" ValidationGroup="BaseInfoGroup" ValidationExpression="[1-9]+[0-9]*$"
            ErrorMessage="输入的页数格式错误，请重新输入！"> 
        </asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="None"
            ValidationGroup="BaseInfoGroup" ErrorMessage="出版日期不能为空，请填写出版日期！" ControlToValidate="ctxtPublishDate">
        </asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="None"
            ValidationGroup="BaseInfoGroup" ErrorMessage="教材类型不能为空，请填写教材类型！" ControlToValidate="ctxtType">
        </asp:RequiredFieldValidator>
    </form>
</body>
</html>
