<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InStock.aspx.cs" Inherits="TextbookManage.WebUI.Inventory.InStock" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
                        <telerik:AjaxUpdatedControl ControlID="ccbxStorage" />
                        <telerik:AjaxUpdatedControl ControlID="cgrdTextbook" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cgrdTextbook">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdTextbook" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadCodeBlock runat="server" ID="cbk">
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
                //教材入库弹窗
                function OnRequestInStock(TextbookId) {
                    var oWnd = $find("<%=wdw_TextbookDetailMessage.ClientID%>");
                    var StorageId = $find("<%=ccbxStorage.ClientID %>").get_value();//仓库id
                    oWnd.setUrl(encodeURI("InStockForm.aspx?StorageId=" + StorageId + "&TextbookId=" + TextbookId)); //
                    oWnd.show();
                    oWnd.setSize(400, 380);
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
            <utm:UTMisTabStrip runat="server" ID="tabStrip" MultiPageID="mp_InStock" SkinID="Long">
                <Tabs>
                    <utm:UTMisTab runat="server" Text="教材入库" PageViewID="pv_Textbook" Selected="true"></utm:UTMisTab>
                </Tabs>
            </utm:UTMisTabStrip>
            <utm:UTMisMultiPage runat="server" ID="mp_InStock" SkinID="Long">
                <utm:UTMisPageView runat="server" ID="pv_Textbook">
                    <table>
                        <tr>
                            <td>
                                <utm:UTMisTextBox ID="ctxtTextbookName" runat="server" Label="教材名称"></utm:UTMisTextBox></td>
                            <td>
                                <utm:UTMisTextBox ID="ctxtIsbn" runat="server" Label="ISBN"></utm:UTMisTextBox></td>
                            <td>
                                <utm:UTMisButton ID="cbtnQuery" runat="server" Text="查询" OnClick="cbtnQuery_Click" /></td>
                            <td>
                                <utm:UTMisComboBox ID="ccbxStorage" runat="server" Label="仓库" DataValueField="StorageId" DataTextField="Name" 
                                    OnBeforeDataBind="ccbxStorage_BeforeDataBind"></utm:UTMisComboBox>
                            </td>
                        </tr>
                    </table>
                    <utm:UTMisGrid ID="cgrdTextbook" runat="server" SkinID="Long"
                        OnBeforeDataBind="cgrdTextbook_BeforeDataBind">
                        <MasterTableView NoMasterRecordsText="没有要显示的记录">
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="序号" HeaderStyle-Width="40px">
                                    <ItemTemplate>
                                        <%#Container .DataSetIndex +1 %>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn HeaderText="教材编号" DataField="Num" HeaderStyle-Width="60">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="教材名称" HeaderStyle-Width="150">
                                    <ItemTemplate>
                                        <a href="#" onclick="OnRequestTextbook('<%#Eval("TextbookId") %>')">
                                            <%# Eval("Name")%></a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn HeaderText="出版社" DataField="Press" HeaderStyle-Width="100">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="ISBN" DataField="ISBN" HeaderStyle-Width="80">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="作者" DataField="Author" HeaderStyle-Width="120">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="版本" DataField="Edition" >
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="版次" DataField="PrintCount" >
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="定价" DataField="Price" HeaderStyle-Width="60">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="教材类型" DataField="TextbookType" HeaderStyle-Width="80">
                                </telerik:GridBoundColumn>
                                <%--OnRequestInStock--%>
                                <telerik:GridTemplateColumn HeaderText="入库">
                                    <ItemTemplate>                                        
                                        <a href="#" onclick="OnRequestInStock('<%#Eval("TextbookId")%>')">入库</a>
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
                <telerik:RadWindow ID="wdw_TextbookDetailMessage" runat="server" Top="100" Left="480" Title="入库表单" Modal="true"
                    ReloadOnShow="true">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </form>
</body>
</html>
