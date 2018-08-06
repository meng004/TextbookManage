<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlertDelete.aspx.cs" Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_19.AlertDelete" %>

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
            margin-right:auto;
            margin-left:auto;
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
    </script>
    <telerik:radajaxmanager id="RadAjaxManager1" runat="server" updatepanelsrendermode="Inline">
        <ClientEvents OnRequestStart="onRequestStart" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cdropAlertName">
                <UpdatedControls>
                    <%--<telerik:AjaxUpdatedControl ControlID="chkIsCurrentTerm" LoadingPanelID="RadAjaxLoadingPanel1" />--%>
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
                <cp:CPMisTab Text="删除提醒信息">
                </cp:CPMisTab>
            </Tabs>
        </cp:cpmistabstrip>
        <cp:cpmismultipage runat="server" id="cteacher" skinid="Long">
            <cp:CPMisPageView ID="CPMisPageView1" runat="server">
                
                    <table class="border">
                        <tr>
                            <td class="border" align="right">
                                <asp:Label ID="lblAlerName" Text="提醒名称：" runat="server">
                                </asp:Label>
                            </td>
                            <td class="border" align="left">
                                <cp:CPMisComboBox runat="server" ID="cdropAlertName" SkinID="AutoSize" AutoPostBack="true"
                                    Skin="Office2007" OnSelectedIndexChanged="ccmbAlert_OnSelectedIndexChanged" MarkFirstMatch="true">
                                </cp:CPMisComboBox>
                                <%--Width="125px"--%>
                            </td>
                        </tr>
                        <tr>
                        <td class="border" align="right">
                            <asp:Label ID="Label1" Text="开始日期：" runat="server">
                            </asp:Label>
                        </td>
                        
                        <td class="border" align="left">
                            <cp:CPMisDatePicker ID="cdateBeginDate" runat="server" readonly="true">
                            </cp:CPMisDatePicker>
                            <%--readonly="true"--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="border" align="right">
                            <asp:Label ID="Label2" Text="结束日期：" runat="server">
                            </asp:Label>
                        </td>
                        
                        <td class="border" align="left">
                            <cp:CPMisDatePicker ID="cdateEndDate" runat="server" readonly="true">
                            </cp:CPMisDatePicker>
                            <%--readonly="true"--%>
                        </td>
                    </tr>
                    </table>
                   
                    <br />
                       <div align="center">
                                <cp:CPMisButton ID="cbtnDelete" runat="server" OnClick="cbtnDelete_Click" Text="删除"
                                    SkinID="bt60" OnClientClick="return confirm('是否删除？')" />
                            &nbsp;&nbsp;
                                <cp:CPMisButton ID="cbtnCancle" runat="server" OnClick="cbtnCancle_Click" Text="取消"
                                    SkinID="bt60" />
                    
                    </div>

                <asp:ValidationSummary ID="vldSummary" runat="server" ShowMessageBox="true" ShowSummary="false"
                    ValidationGroup="BaseInfoGroup" />
            </cp:CPMisPageView>
        </cp:cpmismultipage>
    </div>
    </form>
</body>
</html>
