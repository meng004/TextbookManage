<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecipientUpdate.aspx.cs"
    Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_21.RecipientUpdate" %>

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
             margin-right:auto;
            margin-left:auto;
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
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cdlstRecipient">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ctxtRecipient" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" />
    <div id="tool" runat="server" class="sty_div">
        <cp:CPMisToolBar ID="CPMisToolBar1" runat="server" SkinID="Long">
            <Items>
                <telerik:RadToolBarButton runat="server" CommandName="help" Text="帮助" ImageUrl="~/Img/tlb_Help.png">
                </telerik:RadToolBarButton>
            </Items>
        </cp:CPMisToolBar>
    </div>
    <div class="Border">
        <cp:CPMisTabStrip runat="server" ID="tabStrip" MultiPageID="cterm" SkinID="Long">
            <Tabs>
                <cp:CPMisTab Text="修改领用人类型信息">
                </cp:CPMisTab>
            </Tabs>
        </cp:CPMisTabStrip>
        <cp:CPMisMultiPage runat="server" ID="cterm" SkinID="Long">
            <cp:CPMisPageView ID="CPMisPageView1" runat="server">
                <table class="Border" style="text-align: center;">
                    <tr class="Border">
                        <td class="Border" style="text-align: center;">
                            <cp:CPMisLabel ID="clalRecipient" runat="server" Text="领用人类型：" SkinID="Auto">
                            </cp:CPMisLabel>
                        </td>
                        <td class="Border">
                            <cp:CPMisComboBox ID="cdlstRecipient" runat="server" DataTextField="RecipientType"
                                DataValueField="RecipientTypeID" OnSelectedIndexChanged="cdlstRecipient_IndexChanged"
                                AutoPostBack="true">
                            </cp:CPMisComboBox>
                        </td>
                        <td class="Border">
                            <cp:CPMisLabel ID="clalRecipientExample" runat="server" Enabled="False" IsCancelDataBind="False"
                                SkinID="Auto" Text=" "></cp:CPMisLabel>
                        </td>
                    </tr>
                    <tr class="Border">
                        <td class="Border" style="text-align: center;">
                            <cp:CPMisLabel ID="clalRecipient1" runat="server" Text="领用人类型：" SkinID="Auto">
                            </cp:CPMisLabel>
                        </td>
                        <td class="Border">
                            <cp:CPMisTextBox ID="ctxtRecipient" runat="server">
                            </cp:CPMisTextBox>
                        </td>
                        <td class="Border">
                            <cp:CPMisLabel ID="clalRecipientExample1" runat="server" Text="如：老师、学生" Enabled="False"
                                IsCancelDataBind="False" SkinID="Auto">
                            </cp:CPMisLabel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style=" text-align:center; border:0px; margin-top:6px;">
                         <cp:CPMisButton ID="cbtnSave" runat="server" Text="保存" SkinID="bt60" OnClick="cbtnSave_Click"/>
                    &nbsp;&nbsp; &nbsp;&nbsp;
                    <cp:CPMisButton ID="cbtnCancle" runat="server" Text="取消" SkinID="bt60" OnClick="cbtnCancle_Click" />
                        </td>
                    </tr>
                    <%--<asp:ValidationSummary ID="vds_OverseasAdd" ValidationGroup="BaseInfoGroup" ShowSummary="false"
                        ShowMessageBox="true" HeaderText="验证信息出错!" runat="server" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="ctxtRecipient"
                        Display="None" ValidationGroup="BaseInfoGroup" ValidationExpression="[\u4e00-\u9fa5]+"
                        ErrorMessage="领用人类型格式错误，请输入正确的格式！">
                    </asp:RegularExpressionValidator>--%>
                </table>
              
                
            </cp:CPMisPageView>
        </cp:CPMisMultiPage>
    </div>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    </form>
</body>
</html>
