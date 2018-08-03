﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TextbookQuery.aspx.cs" Inherits="TextbookManage.WebUI.TextbookMaintain.TextbookQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查询教材</title>
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
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline"
            OnAjaxRequest="RadAjaxManager1_AjaxRequest" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
            <ClientEvents OnRequestStart="onRequestStart" />
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdBookQuery"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cbtnQuery">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdBookQuery"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cgrdBookQuery">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdBookQuery"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadCodeBlock runat="server">
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
                //异步回调,刷新grid
                function refreshGrid(arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(arg);
                }
                //工具栏
                function OnToolBarButtonClicked(sender, args) {
                    var button = args.get_item();
                    var command = button.get_commandName();
                    var a = true;
                    var oWnd = $find("<%=wdw_BookMessage.ClientID%>");
                    if (command == "Delete") {
                        a = confirm("确认删除？");
                        if (a == true) {
                            refreshGrid("Delete");
                        }
                        else {
                            args.set_cancel(true);
                        }
                    }
                    if (command == "Add") {
                        oWnd.setUrl("TextbookAdd.aspx");
                        oWnd.show();
                        oWnd.setSize(800, 380);
                    }
                }
                //教材编辑弹窗
                function OnRequestBookModify(bookId) {
                    var oWnd = $find("<%=wdw_BookMessage.ClientID%>");
                    oWnd.setUrl(encodeURI("TextbookModify.aspx?Id=" + bookId));
                    oWnd.show();
                    oWnd.setSize(800, 380);
                }

            </script>
        </telerik:RadCodeBlock>
        <div>
            <cp:CPMisToolBar ID="ctlb_book" runat="server" SkinID="Long" OnClientButtonClicked="OnToolBarButtonClicked">
                <Items>
                    <telerik:RadToolBarButton Text="添加教材" ToolTip="添加教材" CommandName="Add" ImageUrl="../Img/tlb_Add.png">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton Text="删除教材" ToolTip="删除选中的教材" CommandName="Delete" ImageUrl="../Img/tlb_Delete.png">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" CommandName="help" Text="帮助" ImageUrl="~\Img\tlb_Help.png">
                    </telerik:RadToolBarButton>
                </Items>
            </cp:CPMisToolBar>
        </div>
        <div>
            <cp:CPMisTabStrip runat="server" ID="tab_Main" MultiPageID="mp_Textbook" SkinID="Long">
                <Tabs>
                    <cp:CPMisTab runat="server" Text="查询教材" PageViewID="pv_TextbookQuery" Selected="true">
                    </cp:CPMisTab>
                </Tabs>
            </cp:CPMisTabStrip>
            <cp:CPMisMultiPage runat="server" ID="mp_Textbook" SkinID="Long">
                <telerik:RadPageView ID="pv_TextbookQuery" runat="server">
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <cp:CPMisLabel ID="UTMisLabel1" runat="server" Text="教材名称："></cp:CPMisLabel>
                                </td>
                                <td>
                                    <cp:CPMisTextBox runat="server" ID="ctxtTextbookName"></cp:CPMisTextBox>
                                </td>
                                <td>
                                    <cp:CPMisLabel ID="UTMisLabel2" runat="server" Text="ISBN："></cp:CPMisLabel>
                                </td>
                                <td>
                                    <cp:CPMisTextBox runat="server" ID="ctxtIsbn"></cp:CPMisTextBox>
                                </td>
                                <td>
                                    <cp:CPMisButton runat="server" ID="cbtnQuery" Text="查询" OnClick="cbtnQuery_Click"></cp:CPMisButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div>
                        <cp:CPMisGrid ID="cgrdBookQuery" runat="server" AutoGenerateColumns="false" CheckControlID="cchkRowCheck"
                            OnBeforeDataBind="cgrdBookQuery_BeforeDataBind" 
                            OnPageIndexChanged="cgrdBookQuery_PageIndexChanged">
                            <MasterTableView EnableNoRecordsTemplate="true" NoMasterRecordsText="没有数据可以显示" AllowPaging="true" PageSize="10">
                                <PagerStyle Mode="NumericPages" PagerTextFormat="{4}第{0}页 共{1}页" PageButtonCount="4" />
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="编辑" HeaderStyle-Width="30">
                                        <ItemTemplate>
                                            <img alt="编辑" src="../../Img/GridEdit.png" onclick="OnRequestBookModify('<%#Eval("TextbookId") %>')" />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="CheckFlag" HeaderStyle-Width="40" UniqueName="cchkCheck" Visible="true">
                                        <HeaderTemplate>
                                            <cp:CPMisCheckBox ID="cchkCheckAll" runat="server" AutoPostBack="true" OnCheckedChanged="cchkCheckAll_CheckedChanged" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <cp:CPMisCheckBox ID="cchkRowCheck" runat="server" Checked='<%#Eval("CheckFlag")%>' />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderStyle-Width="40" HeaderText="序号">
                                        <ItemTemplate>
                                            <%#Container .DataSetIndex +1 %>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="Num" HeaderStyle-Width="80"  HeaderText="编号">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Name" HeaderText="名称">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Isbn"  HeaderText="ISBN">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Author"  HeaderText="作者">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Press" HeaderStyle-Width="120" HeaderText="出版社">
                                    </telerik:GridBoundColumn>
<%--                                    <telerik:GridBoundColumn DataField="PressAddress" HeaderText="出版社地址">
                                    </telerik:GridBoundColumn>--%>
<%--                                    <telerik:GridBoundColumn DataField="PublishDate" HeaderStyle-Width="80" HeaderText="出版日期">
                                    </telerik:GridBoundColumn>--%>
                                    <telerik:GridBoundColumn DataField="Price" HeaderStyle-Width="40" HeaderText="定价">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Edition" HeaderStyle-Width="40" HeaderText="版本">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PrintCount" HeaderStyle-Width="40" HeaderText="版次">
                                    </telerik:GridBoundColumn>
<%--                                    <telerik:GridBoundColumn DataField="PageCount" HeaderText="页数">
                                    </telerik:GridBoundColumn>--%>
                                    <telerik:GridBoundColumn DataField="TextbookType" HeaderStyle-Width="100" HeaderText="教材类型">
                                    </telerik:GridBoundColumn>
<%--                                    <telerik:GridBoundColumn DataField="IsSelfCompile" HeaderText="自编教材">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Declarant" HeaderText="申报人">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DeclarationDate" HeaderStyle-Width="80" HeaderText="申报日期">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ApprovalState" HeaderText="审核状态">
                                    </telerik:GridBoundColumn>--%>
                                </Columns>
                            </MasterTableView>
                        </cp:CPMisGrid>
                    </div>
                </telerik:RadPageView>
            </cp:CPMisMultiPage>
        </div>
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
            <Windows>
                <telerik:RadWindow ID="wdw_BookMessage" runat="server" Top="20" Left="20" Modal="true">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </form>
</body>
</html>
