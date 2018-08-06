<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TermDelete.aspx.cs" Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_2.TermDelete" %>

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
    <telerik:radajaxmanager id="RadAjaxManager1" runat="server" updatepanelsrendermode="Inline">
        <ClientEvents OnRequestStart="onRequestStart" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cdropTerm">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkIsCurrentTerm" LoadingPanelID="RadAjaxLoadingPanel1" />
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
    <div>
        <cp:CPMisToolBar  ID="CPMisToolBar1" runat="server" SkinID="Long">
            <Items>
                <telerik:RadToolBarButton runat="server" CommandName="help" Text="帮助" ImageUrl="~/Img/tlb_Help.png">
                </telerik:RadToolBarButton>
            </Items>
        </cp:CPMisToolBar>
    </div>
    <div>
        <cp:CPMisTabstrip runat="server" ID="tabStrip" MultiPageID="cterm" SkinID="Long">
            <Tabs>
                <cp:CPMisTab Text="删除学年学期信息">
                </cp:CPMisTab>
            </Tabs>
        </cp:CPMisTabstrip>
        <cp:CPMisMultiPage runat="server" ID="cteacher" SkinID="Long">
            <cp:CPMisPageView ID="CPMisPageView1" runat="server">
                <table class="border">
                    <tr>
                        <td class="border" align="right">
                            <cp:CPMisLabel ID="lblTerm" Text="学年学期：" runat="server">
                            </cp:CPMisLabel>
                        </td>
                        <td class="border" align="left">
                            <cp:CPMisComboBox runat="server" ID="cdropTerm" SkinID="AutoSize" AutoPostBack="true"
                                Skin="Office2007"  DataTextField="Term" DataValueField="TermNum"
                                OnSelectedIndexChanged="ccmbTerm_OnSelectedIndexChanged" MarkFirstMatch="true">
                            </cp:CPMisComboBox>
                            <%--DataSourceID="SqlDataSource_Term"--%>
                            <asp:SqlDataSource ID="SqlDataSource_Term" runat="server" ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>"
                                SelectCommand="prTermGetList" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr style="height: 30px">
                        <td class="border" align="right">
                            <asp:Label ID="lblIsCurrentTerm" Text="是否为当前学期：" runat="server">
                            </asp:Label>
                        </td>
                        <td class="border" align="left">
                            <%-- <cp:CPMisCheckBox ID="chkIsCurrentTerm" runat="server" Text="勾选表示是当前学期." EnableViewState="false" />--%>
                            <asp:Label ID="lblStatus" Text="" runat="server" EnableViewState="true">
                            </asp:Label>
                            <%--EnableViewState="false" --%>
                        </td>
                    </tr>
                    <tr>
                        <td class="border" colspan="2" style="text-align:center;">
                         &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                            <cp:CPMisButton ID="cbtnDelete" runat="server" OnClick="cbtnDelete_Click" Text="确定"
                                SkinID="bt60" OnClientClick="return confirm('是否删除?')" /> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                 <cp:CPMisButton ID="cbtnCancle" runat="server" OnClick="cbtnCancle_Click" SkinID="bt60"
                                Text="取消" />
                        </td>
                    </tr>
                </table>
            </cp:CPMisPageView>
        </cp:CPMisMultiPage>
    </div>
    </form>
</body>
</html>
