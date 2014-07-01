﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderByPress.aspx.cs"
    Inherits="TextbookManage.WebUI.SubscriptionPlan.OrderByPress" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>按出版社制订订单</title>
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
                        <telerik:AjaxUpdatedControl ControlID="ccmbPress" />
                        <telerik:AjaxUpdatedControl ControlID="ccmbBookseller" />
                        <telerik:AjaxUpdatedControl ControlID="cgrdPlanSet" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbTerm">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ccmbPress" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbPress">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdPlanSet" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cgrdPlanSet">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdPlanSet" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
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
                    oWnd.setSize(600, 400);
                }
            </script>
        </telerik:RadCodeBlock>

        <div>
            <utm:UTMisToolBar ID="UTMisToolBar1" runat="server" SkinID="Long">
                <Items>
                    <telerik:RadToolBarButton runat="server" Text="帮助" ImageUrl="~/Img/tlb_Help.png">
                    </telerik:RadToolBarButton>
                </Items>
            </utm:UTMisToolBar>
            <utm:UTMisTabStrip ID="UTMisTabStrip1" runat="server" MultiPageID="mp_OrderBySchool" SkinID="Long">
                <Tabs>
                    <utm:UTMisTab runat="server" Text="按出版社制订订单" PageViewID="pv_OrderBySchool" Selected="true">
                    </utm:UTMisTab>
                </Tabs>
            </utm:UTMisTabStrip>
            <utm:UTMisMultiPage ID="mp_OrderBySchool" runat="server" SkinID="Long">
                <utm:UTMisPageView ID="pv_OrderBySchool" runat="server">
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <utm:UTMisComboBox runat="server" ID="ccmbTerm" Label="学期：" SkinID="cmb200" AutoPostBack="true" IsMaintainSelectedValue="true"
                                        DataTextField="Description" DataValueField="YearTerm"
                                        OnDataBinding="ccmbTerm_DataBinding" 
                                        OnDataBound="ccmbTerm_DataBound" 
                                        OnSelectedIndexChanged="ccmbTerm_SelectedIndexChanged">
                                    </utm:UTMisComboBox>
                                </td>
                                <td>
                                    <utm:UTMisComboBox runat="server" ID="ccmbPress" Label="出版社：" SkinID="cmb200" AutoPostBack="true" IsMaintainSelectedValue="true"
                                        OnDataBinding="ccmbPress_BeforeDataBind"
                                        OnDataBound="ccmbPress_AfterDataBind"
                                        OnSelectedIndexChanged="ccmbPress_SelectedIndexChanged">
                                    </utm:UTMisComboBox>
                                </td>
                                <td>
                                    <utm:UTMisButton runat="server" ID="cbtnQuery" Text="查询" OnClick="ccmbPress_AfterDataBind" />
                                </td>
                                <td>
                                    <utm:UTMisComboBox runat="server" ID="ccmbBookseller" Label="书商：" SkinID="cmb200" IsMaintainSelectedValue="true"
                                        DataTextField="Name" DataValueField="BooksellerId"
                                        OnDataBinding="ccmbBookseller_BeforeDataBind">
                                    </utm:UTMisComboBox>
                                </td>
                                <td>
                                    <utm:UTMisTextBox runat="server" ID="ctxtSpareCount" Text="0" Label="上抛数量：" LabelWidth="80" SkinID="txt200">
                                    </utm:UTMisTextBox>
                                </td>
                                <td>
                                    <utm:UTMisButton runat="server" ID="cbtnOrder" Text="生成订单" 
                                        OnClick="cbtnOrder_Click" 
                                        OnAfterClick="cbtnOrder_AfterClick" />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="上抛数量不能为空" ControlToValidate="ctxtSpareCount"
                                        Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="上抛数量应大于0小于1000，如：1" ControlToValidate="ctxtSpareCount"
                                        ForeColor="Red" Display="Dynamic" Type="Integer" MinimumValue="0" MaximumValue="1000"></asp:RangeValidator>
                                </td>

                            </tr>
                        </table>
                    </div>
                    <utm:UTMisGrid runat="server" ID="cgrdPlanSet" SkinID="NoExport" CheckControlID="cchkRowCheck"
                        OnBeforeDataBind="cgrdPlanSet_BeforeDataBind" OnBeforePageIndexChanged="cgrdPlanSet_BeforePageIndexChanged">
                        <MasterTableView AllowPaging="true" PageSize="10" EnableNoRecordsTemplate="true" NoMasterRecordsText="没有数据可以显示">
                            <PagerStyle Mode="NextPrevAndNumeric" PagerTextFormat="{4}第{0}页 共{1}页" PageButtonCount="4" />
                            <Columns>
                                <telerik:GridTemplateColumn HeaderStyle-Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <HeaderTemplate>
                                        <utm:UTMisCheckBox runat="server" ID="cchkSelectAll" AutoPostBack="true" OnCheckedChanged="cchkSelectAll_CheckedChanged" />
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <utm:UTMisCheckBox runat="server" ID="cchkRowCheck" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="序号" HeaderStyle-Width="40">
                                    <ItemTemplate>
                                        <%#Container .DataSetIndex +1 %>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn HeaderText="教材编号" DataField="Num" HeaderStyle-Width="100">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="教材名称">
                                    <ItemTemplate>
                                        <a href="#" onclick="OnRequestTextbook('<%#Eval("TextbookId") %>')">
                                            <%# Eval("Name")%></a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn HeaderText="申报数量" DataField="DeclarationCount" HeaderStyle-Width="100">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </utm:UTMisGrid>
                </utm:UTMisPageView>
            </utm:UTMisMultiPage>
        </div>
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
            <Windows>
                <telerik:RadWindow ID="wdw_TextbookDetailMessage" runat="server" Top="50" Left="150" Modal="true" Animation="Fade" ReloadOnShow="true">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </form>
</body>
</html>
