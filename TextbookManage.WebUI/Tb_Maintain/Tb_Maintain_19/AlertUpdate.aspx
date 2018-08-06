<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlertUpdate.aspx.cs" Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_19.AlertUpdate" %>

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
            margin-left:auto;
            margin-right:auto;
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
                return confirm('确认更新?'); //后更新
            } else
            {
                return false;
            }
        }
    </script>
    <telerik:radajaxmanager id="RadAjaxManager1" runat="server" updatepanelsrendermode="Inline">
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
                <cp:CPMisTab Text="修改提醒信息">
                </cp:CPMisTab>
            </Tabs>
        </cp:cpmistabstrip>
        <cp:cpmismultipage runat="server" id="cteacher" skinid="Long">
            <cp:CPMisPageView ID="CPMisPageView1" runat="server">
                <table class="border">
                    <tr>
                        <td class="border" align="right">
                            <asp:Label ID="lblTerm" Text="提醒名称：" runat="server">
                            </asp:Label>
                        </td>
                        <td class="border">
                            <span style="color: Red">*</span>
                        </td>
                        <td class="border" align="left">
                            <cp:CPMisComboBox runat="server" ID="cdropAlertName" SkinID="AutoSize" AutoPostBack="true"
                                Skin="Office2007" OnSelectedIndexChanged="ccmbAlert_OnSelectedIndexChanged" MarkFirstMatch="true">
                                <%--Width="125px"--%>
                            </cp:CPMisComboBox>
                        </td>
                        <td class="border" align="left">
                            <asp:Label ID="lblAlert" Text="修改为：" runat="server">
                            </asp:Label>
                        </td>
                        <td class="border" align="right">
                            <cp:CPMisTextBox ID="ctxtAlertName" runat="server" SkinID="Auto" Width="150px">
                            </cp:CPMisTextBox>
                            <asp:RequiredFieldValidator ID="vldRequiredAlertName" runat="server" ValidationGroup="BaseInfoGroup"
                                ErrorMessage="请输入新提醒名称或保留原提醒名称!" ControlToValidate="ctxtAlertName" Display="None"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="vldRegAlertName" ValidationExpression="[0-9\u4e00-\u9fa5]+"
                                ControlToValidate="ctxtAlertName" ErrorMessage="请输入正确的提醒名称或输入了非法字符." runat="server" Display="None"
                                ValidationGroup="BaseInfoGroup" />
                            <%--Width="121px"--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="border" align="right">
                            <asp:Label ID="Label1" Text="开始日期：" runat="server">
                            </asp:Label>
                        </td>
                        <td class="border">
                            <span style="color: Red">*</span>
                        </td>
                        <td class="border" align="left">
                            <cp:CPMisDatePicker ID="cdateBeginDate" runat="server">
                            </cp:CPMisDatePicker>
                            <asp:RequiredFieldValidator ID="vldBeginDate" runat="server" ValidationGroup="BaseInfoGroup"
                                ErrorMessage="开始日期不可以为空或格式不正确,请用日历控件选择日期!" ControlToValidate="cdateBeginDate" Display="None"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="border" align="right">
                            <asp:Label ID="Label2" Text="结束日期：" runat="server">
                            </asp:Label>
                        </td>
                        <td class="border">
                            <span style="color: Red">*</span>
                        </td>
                        <td class="border" align="left">
                            <cp:CPMisDatePicker ID="cdateEndDate" runat="server">
                            </cp:CPMisDatePicker>
                            <asp:RequiredFieldValidator ID="vldEndDate" runat="server" ValidationGroup="BaseInfoGroup"
                                ErrorMessage="结束日期不可以为空或格式不正确,请用日历控件选择日期!" ControlToValidate="cdateEndDate" Display="None"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="vldDate" ControlToValidate="cdateBeginDate" ControlToCompare="cdateEndDate"
                                Operator="LessThan" Type="Date" ErrorMessage="日期请按时间先后顺序输入!" runat="server" Display="None"
                                ValidationGroup="BaseInfoGroup" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:ValidationSummary ID="vldSummary" runat="server" ShowMessageBox="true" ShowSummary="false"
                    ValidationGroup="BaseInfoGroup" />
                <div style="text-align: center">
                    <cp:CPMisButton ID="cbtnUpdate" runat="server" OnClick="cbtnUpdate_Click" Text="确定"
                        SkinID="bt60" ValidationGroup="BaseInfoGroup" OnClientClick="return OnClientValidateClick('BaseInfoGroup')" />
                        <%--OnClientClick="return confirm('是否修改？')"--%>
                    &nbsp; &nbsp;
                    <cp:CPMisButton ID="cbtnCancle" runat="server" OnClick="cbtnCancle_Click" Text="取消"
                        SkinID="bt60" />
                    <br />
                </div>
            </cp:CPMisPageView>
        </cp:cpmismultipage>
    </div>
    </form>
</body>
</html>
