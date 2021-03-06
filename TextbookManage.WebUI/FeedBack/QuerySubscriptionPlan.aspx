﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuerySubscriptionPlan.aspx.cs" Inherits="TextbookManage.WebUI.FeedBack.QuerySubscriptionPlan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>书商订单查询</title>
</head>
<body>
    <form id="form1" runat="server">

        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline">
            <ClientEvents OnRequestStart="onRequestStart" />
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ccmbTerm" />
                        <telerik:AjaxUpdatedControl ControlID="ccmbBookseller" />
                        <telerik:AjaxUpdatedControl ControlID="ccmbFeedbackState" />
                        <telerik:AjaxUpdatedControl ControlID="cgrdOrderSet" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbTerm">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdOrderSet" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbBookseller">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdOrderSet" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbFeedbackState">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdOrderSet" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cgrdOrderSet">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdOrderSet" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
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
                //教材详单弹窗
                function OnRequestTextbook(TextbookId) {
                    var oWnd = $find("<%=wdw_TextbookDetailMessage.ClientID%>");
                    oWnd.setUrl(encodeURI("../WindowForMessage/TextbookDetailMessage.aspx?TextbookID=" + TextbookId)); //
                    oWnd.show();
                    oWnd.setSize(600, 300);
                }
                //回告
                function OnRequestFeedback(SubscriptionPlanId) {
                    var oWnd = $find("<%=wdw_TextbookDetailMessage.ClientID%>");
                    oWnd.setUrl(encodeURI("../WindowForMessage/FeedbackForSubscriptionPlan.aspx?SubscriptionPlanId=" + SubscriptionPlanId)); //
                    oWnd.show();
                    oWnd.setSize(400, 400);
                }
            </script>
        </telerik:RadCodeBlock>

        <div>
            <utm:UTMisToolBar ID="CPMisToolBar1" runat="server" SkinID="Long">
                <Items>
                    <telerik:RadToolBarButton runat="server" Text="帮助" ImageUrl="~/Img/tlb_Help.png">
                    </telerik:RadToolBarButton>
                </Items>
            </utm:UTMisToolBar>
            <utm:UTMisTabStrip runat="server" ID="ctspHead" MultiPageID="mp_Feedback" SkinID="Long">
                <Tabs>
                    <utm:UTMisTab runat="server" Text="书商订单查询" PageViewID="pv_Feedback" Selected="true">
                    </utm:UTMisTab>
                </Tabs>
            </utm:UTMisTabStrip>
            <utm:UTMisMultiPage runat="server" ID="mp_Feedback" SkinID="Long">
                <utm:UTMisPageView runat="server" ID="pv_Feedback">
                    <table>
                        <tr>
                            <td>
                                <utm:UTMisComboBox runat="server" ID="ccmbTerm" Label="学期：" SkinID="cmb200" AutoPostBack="true" IsMaintainSelectedValue="true"
                                    DataTextField="Description" DataValueField="YearTerm"
                                    OnDataBinding="ccmbTerm_DataBinding"
                                    OnSelectedIndexChanged="ccmbTerm_SelectedIndexChanged">
                                </utm:UTMisComboBox>
                            </td>
                            <td>
                                <utm:UTMisComboBox runat="server" ID="ccmbBookseller" Label="书商：" SkinID="cmb200" AutoPostBack="true" IsMaintainSelectedValue="true"
                                    DataTextField="Name" DataValueField="BooksellerId"
                                    OnDataBinding="ccmbBookseller_BeforeDataBind"
                                    OnSelectedIndexChanged="ccmbFeedbackState_SelectedIndexChanged">
                                </utm:UTMisComboBox>
                            </td>
                            <td>
                                <utm:UTMisComboBox runat="server" ID="ccmbFeedbackState" Label="回告状态：" SkinID="cmb200" AutoPostBack="true" IsMaintainSelectedValue="true"
                                    DataTextField="Name" DataValueField="Id"
                                    OnDataBinding="ccmbFeedbackState_BeforeDataBind"
                                    OnAfterDataBind="cbtnQuery_Click"
                                    OnSelectedIndexChanged="ccmbFeedbackState_SelectedIndexChanged">
                                </utm:UTMisComboBox>
                            </td>
                            <td>
                                <utm:UTMisButton runat="server" ID="cbtnQuery" Text="查询" Width="60" OnClick="cbtnQuery_Click" />
                            </td>
                        </tr>
                    </table>
                    <utm:UTMisGrid runat="server" ID="cgrdOrderSet" SkinID="AutoPages" 
                        OnBeforeDataBind="cgrdOrderSet_BeforeDataBind"
                        OnBeforePageIndexChanged="cgrdOrderSet_BeforePageIndexChanged">
                        <MasterTableView AllowPaging="true" PageSize="10" EnableNoRecordsTemplate="true" NoMasterRecordsText="没有数据可以显示">
                            <PagerStyle Mode="NextPrevAndNumeric" PagerTextFormat="{4}第{0}页 共{1}页" PageButtonCount="4" />
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="序号" HeaderStyle-Width="40">
                                    <ItemTemplate>
                                        <%#Container .DataSetIndex +1 %>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn HeaderText="教材编号" DataField="Num" HeaderStyle-Width="80">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="教材名称" DataField="Name" HeaderStyle-Width="200">
                                    <ItemTemplate>
                                        <a href="#" onclick="OnRequestTextbook('<%#Eval ("TextbookId") %>')">
                                            <%# Eval("Name")%></a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn HeaderText="申报数量" DataField="DeclarationCount" HeaderStyle-Width="80">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="上抛数量" DataField="SpareCount" HeaderStyle-Width="80">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="征订总数" DataField="TotalCount" HeaderStyle-Width="80">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="征订日期" DataField="SubscriptionDate" HeaderStyle-Width="120">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="回告状态" HeaderStyle-Width="200">
                                    <ItemTemplate>
                                        <a href="#" onclick="OnRequestFeedback('<%#Eval ("SubscriptionId") %>')">回告状态</a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </utm:UTMisGrid>
                </utm:UTMisPageView>
            </utm:UTMisMultiPage>
        </div>
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
            <Windows>
                <telerik:RadWindow ID="wdw_TextbookDetailMessage" runat="server" Top="150" Left="400" Modal="true"
                    ReloadOnShow="true">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </form>
</body>
</html>
