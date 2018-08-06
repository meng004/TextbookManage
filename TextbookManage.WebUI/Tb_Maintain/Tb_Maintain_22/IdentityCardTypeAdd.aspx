<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IdentityCardTypeAdd.aspx.cs"
    Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_22.IdentityCardTypeAdd" %>

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
                return confirm('确认新增?'); //之后进行新增
            } else
            {
                return false;
            }
        }
    </script>
    <telerik:radajaxmanager id="RadAjaxManager1" runat="server" updatepanelsrendermode="Inline">
        <ClientEvents OnRequestStart="onRequestStart" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cdropTerm">
                <UpdatedControls>                    
                    <telerik:AjaxUpdatedControl ControlID="cdateBeginDate" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="cdateEndDate" />
                    <%--LoadingPanelID="RadAjaxLoadingPanel1"--%>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:radajaxmanager>
    <telerik:radformdecorator id="RadFormDecorator1" runat="server" decoratedcontrols="All" />
    <telerik:radstylesheetmanager id="RadStyleSheetManager1" runat="server">
    </telerik:radstylesheetmanager>
    <telerik:radtooltipmanager id="RadToolTipManager1" runat="server" autotooltipify="true">
    </telerik:radtooltipmanager>
    <telerik:radajaxloadingpanel id="RadAjaxLoadingPanel1" runat="server">
    </telerik:radajaxloadingpanel>
    <script type="text/javascript">
        //如果点击的是导出按钮则将AJAX禁用
        function onRequestStart(sender, args)
        {
            if (args.get_eventTarget().indexOf("ExportToExcelButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToWordButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToPdfButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToCsvButton") >= 0)
            {
                args.set_enableAjax(false);
            }
        }
    </script>
    <div id="tool" runat="server" class="sty_div">
        <cp:cpmistoolbar id="CPMisToolBar1" runat="server" skinid="Long">
            <Items>
                <telerik:RadToolBarButton runat="server" CommandName="help" Text="帮助" ImageUrl="~/Img/tlb_Help.png">
                </telerik:RadToolBarButton>
            </Items>
        </cp:cpmistoolbar>
    </div>
    <div>
        <cp:cpmistabstrip runat="server" id="tabStrip" multipageid="cterm" skinid="Long">
            <Tabs>
                <cp:CPMisTab Text="增加证件类型信息">
                </cp:CPMisTab>
            </Tabs>
        </cp:cpmistabstrip>
        <cp:cpmismultipage runat="server" id="cterm" skinid="Long">
            <cp:CPMisPageView ID="CPMisPageView1" runat="server">
        <table class="Border">
            <tr>
                <td class="Border" style="text-align:center;">
                    <cp:CPMisLabel ID="clalIdentityCardType" runat="server" Text="证件类型：" SkinID="Auto">
                    </cp:CPMisLabel>
                    <span style="color: Red">*</span>
                    <cp:CPMisTextBox ID="ctxtIdentityCardType" runat="server">
                    </cp:CPMisTextBox>
                    <asp:RequiredFieldValidator ID="vldIdCardType" runat="server" ValidationGroup="BaseInfoGroup"
                                ErrorMessage="请输入证件名称!" ControlToValidate="ctxtIdentityCardType" Display="None"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="vldRegIdCardType" ValidationExpression="[\u4e00-\u9fa5]+"
                                ControlToValidate="ctxtIdentityCardType" ErrorMessage="请输入正确的证件名称或输入了非法字符." runat="server" Display="None"
                                ValidationGroup="BaseInfoGroup" />
                    <cp:CPMisLabel ID="clalIdentityCardTypeExample" runat="server" Text="如：借书证、身份证" 
                        Enabled="False" IsCancelDataBind="False" SkinID="Auto"></cp:CPMisLabel>
                </td>
            </tr>
        </table>
        <br />
        <asp:ValidationSummary ID="vldSummary" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="BaseInfoGroup" />
        <br />
        <div>
            <cp:CPMisButton ID="cbtnSave" runat="server" Text="保存" SkinID="bt60" ValidationGroup="BaseInfoGroup" OnClientClick="return OnClientValidateClick('BaseInfoGroup')" OnClick="cbtnSave_Click"/> &nbsp;&nbsp;
            <cp:CPMisButton ID="cbtnCancle" runat="server" Text="取消" SkinID="bt60" OnClick="cbtnCancle_Click"/>
        </div>
       </cp:CPMisPageView>
      </cp:cpmismultipage>
    </div>
    </form>
</body>
</html>
