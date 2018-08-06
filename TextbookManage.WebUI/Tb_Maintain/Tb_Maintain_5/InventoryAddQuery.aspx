<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryAddQuery.aspx.cs"
    Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_5.InventoryAddQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
    </telerik:RadSkinManager>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline">
        <ClientEvents OnRequestStart="onRequestStart" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cdlstBooksellerName">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cdlstStockName" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cbntQuery">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdStock" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cgrdStock">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdStock" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" AutoTooltipify="true">
    </telerik:RadToolTipManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
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
    </script>
    <div id="tool" runat="server" class="sty_div">
        <cp:CPMisToolBar ID="CPMisToolBar1" runat="server" SkinID="Long">
            <Items>
                <telerik:RadToolBarButton runat="server" CommandName="help" Text="帮助" ImageUrl="~\Img\tlb_Help.png">
                </telerik:RadToolBarButton>
            </Items>
        </cp:CPMisToolBar>
    </div>
    <div>
        <cp:CPMisTabStrip runat="server" ID="tabStrip" MultiPageID="cteacher" SkinID="Long">
            <Tabs>
                <cp:CPMisTab Text="查询库存教材信息">
                </cp:CPMisTab>
            </Tabs>
        </cp:CPMisTabStrip>
        <cp:CPMisMultiPage runat="server" ID="cteacher" SkinID="Long">
            <cp:CPMisPageView ID="CPMisPageView1" runat="server">
                <div id="div_choose" runat="server" style="padding-left: 5px; padding-top: 2px; text-align: left;
                    background-color: #E1EBF7;">
                    <cp:CPMisLabel  runat="server" Text="书商名称:" SkinID="AutoSize"></cp:CPMisLabel>
                    <cp:CPMisComboBox ID="cdlstBooksellerName" runat="server" AutoPostBack="true" DataTextField="BooksellerName"
                        DefaultIndex="0" IsCancelDataBind="False" IsMaintainSelectedValue="False" SelectedText=""
                        DataValueField="BooksellerID" OnPreRender="cdlstBooksellerName_PreRender">
                    </cp:CPMisComboBox>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>"
                        SelectCommand="SELECT [BooksellerName], [BooksellerID] FROM [Bookseller]"></asp:SqlDataSource>
                    &nbsp;&nbsp;
                    <cp:CPMisLabel ID="clalStockName" runat="server" SkinID="AutoSize" Text="仓库名称："></cp:CPMisLabel>
                    <cp:CPMisComboBox ID="cdlstStockName" runat="server" DataTextField="StockName" DefaultIndex="0"
                        IsCancelDataBind="False" IsMaintainSelectedValue="False" SelectedText="">
                    </cp:CPMisComboBox>
                    &nbsp;&nbsp;
                    <cp:CPMisLabel ID="clblTextbookName" runat="server" SkinID="AutoSize" Text="教材名称："></cp:CPMisLabel>
                    &nbsp;&nbsp;
                    <cp:CPMisTextBox ID="ctxtTextbookName" runat="server" SkinID="AutoSize">
                    </cp:CPMisTextBox>
                    &nbsp;&nbsp;
                    <cp:CPMisButton runat="server" ID="cbntQuery" Text="查询" OnClick="cbntQuery_Click">
                    </cp:CPMisButton>
                </div>
                <div>
                    <cp:CPMisGrid ID="cgrdStock" SkinID="Long" AutoGenerateColumns="False" OnBeforeDataBind="cgrdStock_BeforeDataBind"
                        runat="server" CellSpacing="0" GridLines="None" IsCancelDataBind="False" IsPersistCheckState="False"
                        OnItemCommand="cgrdStock_ItemCommand" PersistPageIndex="0">
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderStyle-Width="40px" HeaderText="序号">
                                    <ItemTemplate>
                                        <%#Container .DataSetIndex +1 %>
                                    </ItemTemplate>
                                    <HeaderStyle Width="40px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="TextbookName" HeaderStyle-Width="120px" HeaderText="教材名称">
                                    <HeaderStyle Width="120px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Isbn" HeaderStyle-Width="120px" HeaderText="ISBN">
                                    <HeaderStyle Width="120px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Author" HeaderText="作者">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Press" HeaderStyle-Width="120px" HeaderText="出版社">
                                    <HeaderStyle Width="120px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RetailPrice" HeaderText="零售价">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Edition" HeaderText="版本">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PrintingCount" HeaderText="版次">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TextbookType" HeaderStyle-Width="120px" HeaderText="教材类型">
                                    <HeaderStyle Width="120px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TextbookID" HeaderText="TextbookID" Visible="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TextbookNum" HeaderText="TextbookNum" Visible="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="新增库存">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="dtInsert" runat="server" CausesValidation="False" CommandArgument='<%# Eval("TextbookID")  %>'
                                            CommandName="insert" OnClientClick="if(confirm(&quot;您确定新增吗?&quot;))return true;else return false;"> 新增</asp:LinkButton>
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
            </cp:CPMisPageView>
        </cp:CPMisMultiPage>
    </div>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        <Windows>
            <telerik:RadWindow ID="wdw_BookMessage" runat="server" Top="150" Width="400" Left="350"
                Height="500">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    </form>
</body>
</html>
