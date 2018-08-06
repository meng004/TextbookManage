<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiscountQuery.aspx.cs"
    Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_6.DiscountQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        
    </style>
</head>
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
    function OnClientGetDiscountMessage(InventoryTextbookDiscountID) {
        var oWnd = $find("<%=wdwInventoryTextbookDiscountMessage.ClientID%>");
        oWnd.setUrl("DiscountUpdate.aspx?id=" + InventoryTextbookDiscountID); //
        oWnd.show();
    }
    //教材详单弹窗
    function OnClientBookDetailMessageCommand(TextbookId) {
        var oWnd = $find("<%=wdwInventoryTextbookDiscountMessage.ClientID%>");
        oWnd.setUrl(encodeURI("../../Tb_Query/TextbookDetailMessage.aspx?TextbookId=" + TextbookId)); //
        oWnd.show();
        oWnd.setSize(450, 290);
    }
</script>
<body>
    <form id="form1" runat="server">
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" />
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
    </telerik:RadSkinManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cdlstBooksellerName">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cdlstStockName" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cbtnQuery">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cdgrdList" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cdgrdList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cdgrdList" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div id="tool" runat="server" class="sty_div">
        <cp:CPMisToolBar ID="CPMisToolBar1" runat="server" SkinID="Long">
            <Items>
                <telerik:RadToolBarButton runat="server" CommandName="help" Text="帮助" ImageUrl="~/Img/tlb_Help.png">
                </telerik:RadToolBarButton>
            </Items>
        </cp:CPMisToolBar>
    </div>
    <div>
        <cp:CPMisTabStrip runat="server" ID="tabStrip" MultiPageID="cStock" SkinID="Long"
            SelectedIndex="0">
            <Tabs>
                <cp:CPMisTab Text="查询库存教材折扣信息" Selected="True">
                </cp:CPMisTab>
            </Tabs>
        </cp:CPMisTabStrip>
        <cp:CPMisMultiPage ID="cMultiPageDiscount" runat="server" SkinID="Long">
            <telerik:RadPageView ID="RadPageViewDiscount" runat="server" SkinID="Long">
                <div id="divChoose" style="padding-left: 5px; padding-top: 2px; text-align: left;
                    background-color: #E1EBF7; width: 995px; margin-bottom: 0px;">
                    <table style="border: 0px;">
                        <tr>
                            <td style="border: 0px;">
                                <cp:CPMisLabel ID="clalTerm" runat="server" Text="学年学期：" SkinID="AutoSize"></cp:CPMisLabel>
                            </td>
                            <td style="border: 0px;">
                                <cp:CPMisComboBox ID="cdlstTerm" runat="server" DataSourceID="SqlDataSource2" DataTextField="Term"
                                    DefaultIndex="0" IsCancelDataBind="False" IsMaintainSelectedValue="False" SelectedText="">
                                </cp:CPMisComboBox>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>"
                                    SelectCommand="SELECT [Term] FROM [Term] ORDER BY [Term] DESC"></asp:SqlDataSource>
                            </td>
                            <td style="border: 0px;">
                                <cp:CPMisLabel ID="clalBooksellerName" runat="server" Text="书商名称:" SkinID="AutoSize"></cp:CPMisLabel>
                            </td>
                            <td style="border: 0px;">
                                <cp:CPMisComboBox ID="cdlstBooksellerName" runat="server" AutoPostBack="true" DataTextField="BooksellerName"
                                    DefaultIndex="0" IsCancelDataBind="False" IsMaintainSelectedValue="False" SelectedText=""
                                    DataValueField="BooksellerID" OnPreRender="cdlstBooksellerName_PreRender">
                                </cp:CPMisComboBox>
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>"
                                    SelectCommand="SELECT [BooksellerName], [BooksellerID] FROM [Bookseller]"></asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td style="border: 0px;">
                                <cp:CPMisLabel ID="clalStockName" runat="server" Text="仓库名称：" SkinID="AutoSize"></cp:CPMisLabel>
                            </td>
                            <td style="border: 0px;">
                                <cp:CPMisComboBox ID="cdlstStockName" runat="server" DataTextField="StockName" DefaultIndex="0"
                                    IsCancelDataBind="False" IsMaintainSelectedValue="False" SelectedText="">
                                </cp:CPMisComboBox>
                            </td>
                            <td style="border: 0px;">
                                <cp:CPMisLabel ID="clalTextbookName" runat="server" Text="教材名称:" SkinID="AutoSize"></cp:CPMisLabel>
                            </td>
                            <td style="border: 0px;">
                                <cp:CPMisTextBox ID="ctxtTextbookName" runat="server" SkinID="tb160">
                                </cp:CPMisTextBox>
                            </td>
                            <td style="border: 0px;">
                                <cp:CPMisButton ID="cbtnQuery" runat="server" Text="查询" OnClick="cbtnQuery_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <cp:CPMisGrid ID="cdgrdList" runat="server" AllowCustomPaging="True" AllowPaging="True"
                        AutoGenerateColumns="False" CellSpacing="0" GridLines="None" IsCancelDataBind="False"
                        IsPersistCheckState="False" OnBeforeDataBind="cdgrdList_BeforeDataBind" OnPageIndexChanged="cdgrdList_PageIndexChanged"
                        OnPageSizeChanged="cdgrdList_PageSizeChanged" OnItemCommand="cdgrdList_ItemCommand"
                        PersistPageIndex="0">
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderStyle-Width="40px" HeaderText="序号">
                                    <ItemTemplate>
                                        <%#Container.DataSetIndex + 1%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="Term" HeaderText="学年学期">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="BooksellerName" HeaderText="书商名称">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="StockName" HeaderText="仓库名称">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="教材名称" DataField="TextbookName" HeaderStyle-Width="160px">
                                    <ItemTemplate>
                                        <a href="#" onclick='<%# "OnClientBookDetailMessageCommand(\""+Eval("TextbookID")+"\")" %>'>
                                            <%# Eval("TextbookName")%></a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="StoreCount" HeaderText="库存数量">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RetailPrice" HeaderText="零售价">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Discount" HeaderText="折扣">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DiscountPrice" HeaderText="折后价">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="修改" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <a href="#" onclick='OnClientGetDiscountMessage(&#039;<%# Eval("InventoryTextbookDiscountID")  %>&#039;)'>
                                            修改</a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="删除" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="dtDelete" runat="server" CausesValidation="False" CommandName="delete"
                                            CommandArgument='<%# Eval("InventoryTextbookDiscountID")  %>' OnClientClick='if(confirm("您确定删除吗?"))return true;else return false;'>删除</asp:LinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                        </HeaderContextMenu>
                    </cp:CPMisGrid>
                </div>
            </telerik:RadPageView>
        </cp:CPMisMultiPage>
        <telerik:RadWindowManager ID="RadWindowManag000er1" runat="server">
            <Windows>
                <telerik:RadWindow ID="wdwInventoryTextbookDiscountMessage" runat="server" Width="380"
                    Height="350">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </div>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    </form>
</body>
</html>
