<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IdentityCardTypeUpdate.aspx.cs"
    Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_22.IdentityCardTypeUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .Red
        {
            color: Red;
        }
        .Border
        {
            margin: 0;
            padding: 0;
            border: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:radskinmanager id="RadSkinManager1" runat="server">
    </telerik:radskinmanager>
    <telerik:radscriptmanager id="RadScriptManager1" runat="server">
    </telerik:radscriptmanager>
    <script type="text/javascript" language="javascript">
        function OnClientValidateClick(GroupName)
        {
            Page_ClientValidate(GroupName); //先验证
            if (Page_IsValid)
            {
                return confirm('确认更新?'); //之后进行更新
            } else
            {
                return false;
            }
        }
    </script>
    <telerik:radajaxmanager id="RadAjaxManager1" runat="server" updatepanelsrendermode="Inline">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cdlstRecipient">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ctxtRecipient" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:radajaxmanager>
    <telerik:radformdecorator id="RadFormDecorator1" runat="server" />
    <div id="tool" runat="server" class="sty_div">
        <cp:cpmistoolbar id="CPMisToolBar1" runat="server" skinid="Long">
            <Items>
                <telerik:RadToolBarButton runat="server" CommandName="help" Text="帮助" ImageUrl="~/Img/tlb_Help.png">
                </telerik:RadToolBarButton>
            </Items>
        </cp:cpmistoolbar>
    </div>
    <div class="Border">
        <cp:cpmistabstrip runat="server" id="tabStrip" multipageid="cterm" skinid="Long">
            <Tabs>
                <cp:CPMisTab Text="修改证件类型信息">
                </cp:CPMisTab>
            </Tabs>
        </cp:cpmistabstrip>
        <cp:cpmismultipage runat="server" id="cterm" skinid="Long">
            <cp:CPMisPageView ID="CPMisPageView1" runat="server">
                <table class="Border" style="text-align: center;">
                    <tr class="Border">
                        <td class="Border" style="text-align: center;">
                            <cp:CPMisLabel ID="clalIdentityCardType" runat="server" Text="证件类型：" SkinID="Auto">
                            </cp:CPMisLabel>
                        </td>
                        <td class="Border">
                            <cp:CPMisComboBox ID="clstIdentityCardType" DataTextField="IdentityCard" MarkFirstMatch="true"
                             DataValueField="IdentityCardTypeNum" AutoPostBack="true" 
                             OnSelectedIndexChanged="clstIdCardType_OnSelectedIndexChanged" 
                             runat="server">
                            </cp:CPMisComboBox>
                        </td>
                        <td class="Border">
                            <cp:CPMisLabel ID="clalIdentityCardTypeExample" runat="server" Enabled="False" IsCancelDataBind="False"
                                SkinID="Auto" Text=" "></cp:CPMisLabel>
                        </td>
                    </tr>
                    <tr class="Border">
                        <td class="Border" style="text-align: center;">
                            <cp:CPMisLabel ID="clalIdentityCardType1" runat="server" Text="证件类型：" SkinID="Auto">
                            </cp:CPMisLabel>
                        </td>
                        <td class="Border">
                            <cp:CPMisTextBox ID="ctxtIdentityCardType" runat="server">
                            </cp:CPMisTextBox>
                            <asp:RequiredFieldValidator ID="vldIdCardType" runat="server" ValidationGroup="BaseInfoGroup"
                                ErrorMessage="请输入证件名称!" ControlToValidate="ctxtIdentityCardType" Display="None"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="vldRegIdCardType" ValidationExpression="[\u4e00-\u9fa5]+"
                                ControlToValidate="ctxtIdentityCardType" ErrorMessage="请输入正确的证件名称或输入了非法字符." runat="server" Display="None"
                                ValidationGroup="BaseInfoGroup" />
                        </td>
                        <td class="Border">
                            <cp:CPMisLabel ID="clalIdentityCardTypeExample1" runat="server" Text="如：身份证、借书证" Enabled="False"
                                IsCancelDataBind="False" SkinID="Auto">
                            </cp:CPMisLabel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style=" text-align:center; border:0px; margin-top:6px;">
                         <cp:CPMisButton ID="cbtnSave" runat="server" Text="保存" SkinID="bt60" 
                         OnClientClick="return OnClientValidateClick('BaseInfoGroup')" ValidationGroup="BaseInfoGroup" 
                         OnClick="cbtnSave_Click"/>
                    &nbsp;&nbsp; &nbsp;&nbsp;
                    <cp:CPMisButton ID="cbtnCancle" runat="server" Text="取消" SkinID="bt60" OnClick="cbtnCancle_Click" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:ValidationSummary ID="vldSummary" runat="server"  ShowMessageBox="true" ShowSummary="false" ValidationGroup="BaseInfoGroup" />
                <br />                              
            </cp:CPMisPageView>
        </cp:cpmismultipage>
    </div>
    <telerik:radajaxloadingpanel id="RadAjaxLoadingPanel1" runat="server">
    </telerik:radajaxloadingpanel>
    </form>
</body>
</html>
