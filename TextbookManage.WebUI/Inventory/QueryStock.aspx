<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryStock.aspx.cs" Inherits="TextbookManage.WebUI.Inventory.QueryStock" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>出入库查询</title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager runat="server" ID="RadScriptManager1">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
            <ClientEvents OnRequestStart="onRequestStart" />
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ccbxStorageByTime" />
                        <telerik:AjaxUpdatedControl ControlID="ccbxStorageByTextbook" />
                        <telerik:AjaxUpdatedControl ControlID="cgrdQueryByTime" />
                        <telerik:AjaxUpdatedControl ControlID="cgrdQueryByTextbook" />
                        <telerik:AjaxUpdatedControl ControlID="dtpBeginTime" />
                        <telerik:AjaxUpdatedControl ControlID="dtpEndTime" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cgrdQueryByTime">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdQueryByTime" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cgrdQueryByTextbook">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdQueryByTextbook" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadCodeBlock runat="server" ID="RadCodeBlock1">
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
            </script>
        </telerik:RadCodeBlock>

        <div>
            <utm:UTMisToolBar runat="server" SkinID="Long" ID="ctlb">
                <Items>
                    <telerik:RadToolBarButton runat="server" CommandName="help" Text="帮助" ImageUrl="~/Img/tlb_Help.png">
                    </telerik:RadToolBarButton>
                </Items>
            </utm:UTMisToolBar>
            <utm:UTMisTabStrip runat="server" ID="tabStrip" MultiPageID="mp_Stock" SkinID="Long">
                <Tabs>
                    <utm:UTMisTab runat="server" Text="按时间查询" PageViewID="pv_Time" Selected="true"></utm:UTMisTab>
                    <utm:UTMisTab runat="server" Text="按教材查询" PageViewID="pv_Textbook"></utm:UTMisTab>
                </Tabs>
            </utm:UTMisTabStrip>
            <utm:UTMisMultiPage runat="server" ID="mp_Stock" SkinID="Long">
                <utm:UTMisPageView runat="server" ID="pv_Time" SkinID="Long">
                    <table>
                        <tr>
                            <td>
                                <telerik:RadComboBox runat="server" ID="ccbxStorageByTime" DataValueField="StorageId" DataTextField="Name"
                                    OnDataBinding="ccbxStorageByTime_DataBinding">
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rblStockTypeByTime" runat="server" RepeatColumns="2" Width="100" BorderWidth="1">
                                    <asp:ListItem Text="入库" Value="1" Selected="True">
                                    </asp:ListItem>
                                    <asp:ListItem Text="出库" Value="0">
                                    </asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <telerik:RadDatePicker runat="server" ID="dtpBeginTime" DateInput-Label="开始日期">
                                </telerik:RadDatePicker>
                            </td>
                            <td>
                                <telerik:RadDatePicker runat="server" ID="dtpEndTime" DateInput-Label="结束日期">
                                </telerik:RadDatePicker>
                            </td>
                            <td>
                                <telerik:RadButton runat="server" ID="cbtnQueryByTime" Text="查询" OnClick="cbtnQueryByTime_Click" />
                            </td>
                        </tr>
                    </table>
                    <telerik:RadGrid runat="server" ID="cgrdQueryByTime" AutoGenerateColumns="false" SkinID="Long" OnDataBinding="cgrdQueryByTime_DataBinding">
                        <MasterTableView NoMasterRecordsText="没有要显示的记录">
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="序号" HeaderStyle-Width="40px">
                                    <ItemTemplate>
                                        <%#Container.DataSetIndex +1 %>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn HeaderText="教材编号" DataField="Num">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="教材名称" HeaderStyle-Width="150">
                                    <ItemTemplate>
                                        <a href="#" onclick="OnRequestTextbook('<%#Eval("TextbookId") %>')">
                                            <%# Eval("Name")%></a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn HeaderText="ISBN" HeaderStyle-Width="80" DataField="Isbn">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="作者" DataField="Author">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="出版社" DataField="Press">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="版本" DataField="Edition">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="版次" DataField="PrintCount">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="定价" DataField="Price">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="教材类型" DataField="TextbookType">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="入库数量" DataField="StockCount">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="入库时间" DataField="StockDate">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="入库人" DataField="Operator">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="架位号" DataField="ShelfNumber">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </utm:UTMisPageView>
                <utm:UTMisPageView runat="server" ID="pv_Textbook" SkinID="Long">
                    <table>
                        <tr>
                            <td>
                                <telerik:RadComboBox runat="server" ID="ccbxStorageByTextbook" DataValueField="StorageId" DataTextField="Name"
                                    OnDataBinding="ccbxStorageByTextbook_DataBinding">
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rblStockTypeByTextbook" runat="server" RepeatColumns="2" Width="100" BorderWidth="1">
                                    <asp:ListItem Text="入库" Value="1" Selected="True">
                                    </asp:ListItem>
                                    <asp:ListItem Text="出库" Value="0">
                                    </asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <telerik:RadTextBox runat="server" ID="ctxtTextbookName" Label="教材名称">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                <telerik:RadTextBox runat="server" ID="ctxtISBN" Label="ISBN">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                <telerik:RadButton runat="server" ID="cbtnQueryByTextbook" Text="查询" OnClick="cbtnQueryByTextbook_Click" />
                            </td>
                        </tr>
                    </table>
                    <telerik:RadGrid runat="server" ID="cgrdQueryByTextbook" AutoGenerateColumns="false" SkinID="Long" OnDataBinding="cgrdQueryByTextbook_DataBinding">
                        <MasterTableView NoMasterRecordsText="没有要显示的记录">
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="序号" HeaderStyle-Width="40px">
                                    <ItemTemplate>
                                        <%#Container.DataSetIndex +1 %>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn HeaderText="教材编号" DataField="Num">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="教材名称" HeaderStyle-Width="150">
                                    <ItemTemplate>
                                        <a href="#" onclick="OnRequestTextbook('<%#Eval("TextbookId") %>')">
                                            <%# Eval("Name")%></a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn HeaderText="ISBN" HeaderStyle-Width="80" DataField="Isbn">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="作者" DataField="Author">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="出版社" DataField="Press">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="版本" DataField="Edition">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="版次" DataField="PrintCount">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="定价" DataField="Price">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="教材类型" DataField="TextbookType">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="入库数量" DataField="StockCount">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="入库时间" DataField="StockDate">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="入库人" DataField="Operator">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="架位号" DataField="ShelfNumber">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </utm:UTMisPageView>
            </utm:UTMisMultiPage>
        </div>
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
            <Windows>
                <telerik:RadWindow ID="wdw_TextbookDetailMessage" runat="server" Top="100" Left="480" Title="入库表单" Modal="true"
                    ReloadOnShow="true">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </form>
</body>
</html>
