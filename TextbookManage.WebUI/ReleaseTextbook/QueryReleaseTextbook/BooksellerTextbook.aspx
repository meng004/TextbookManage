<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BooksellerTextbook.aspx.cs"
    Inherits="CPMis.WebPage.Tb_Query.Tb_Query_3.BooksellerTextbook" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .border
        {
            margin: 0;
            border: 0;
            padding: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" />
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
    </telerik:RadSkinManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <ClientEvents OnRequestStart="onRequestStart" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cdlstBooksellerName">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cdlstBooksellerName" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cdlstTerm">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cdlstTerm"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cbntQuery">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdBookSeller" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
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
        function OnClientTextbookMessage(TextbookID) {
            var oWnd = $find("<%=wdwInventoryTextbookDiscountMessage.ClientID%>");
            oWnd.setUrl("../../Tb_Query/TextbookDetailMessage.aspx?TextbookId=" + TextbookID); //
            oWnd.show();
            oWnd.setSize(450, 290);
        }
    </script>
    <div id="tool" runat="server" class="sty_div">
        <cp:CPMisToolBar ID="CPMisToolBar1" runat="server" SkinID="Long">
            <Items>
                <telerik:RadToolBarButton runat="server" CommandName="help" Text="帮助" ImageUrl="~/Img/tlb_Help.png">
                </telerik:RadToolBarButton>
            </Items>
        </cp:CPMisToolBar>
    </div>
    <div>
        <cp:CPMisTabStrip runat="server" ID="tabStrip" MultiPageID="cStock" SkinID="Long">
            <Tabs>
                <cp:CPMisTab Text="查询书商教材信息">
                </cp:CPMisTab>
            </Tabs>
        </cp:CPMisTabStrip>
        <cp:CPMisMultiPage ID="cMultiPageTeacherTextbookQuery" runat="server" SkinID="Long">
            <telerik:RadPageView ID="RadPageViewTeacherTextbookQuery" runat="server" SkinID="Long">
                <div id="div_choose" runat="server" style="padding-left: 5px; padding-top: 2px; text-align: left;
                    background-color: #E1EBF7;">
                    <table class="border">
                        <tr class="border">
                            <td class="border">
                                <cp:CPMisLabel ID="clalBooksellerName" runat="server" SkinID="AutoSize" Text="书商名称："></cp:CPMisLabel>
                            </td>
                            <td class="border">
                                <cp:CPMisComboBox ID="cdlstBooksellerName" runat="server" DataTextField="BooksellerName"
                                    DataValueField="BooksellerID" DefaultIndex="0" IsCancelDataBind="False" IsMaintainSelectedValue="False"
                                    SelectedText="">
                                </cp:CPMisComboBox>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>"
                                    SelectCommand="SELECT [BooksellerName], [BooksellerID] FROM [Bookseller] ORDER BY [BooksellerName] DESC">
                                </asp:SqlDataSource>
                            </td>
                            <td class="border">
                                <cp:CPMisLabel ID="clalTerm" runat="server" Text="学年学期：" SkinID="AutoSize"></cp:CPMisLabel>
                            </td>
                            <td class="border">
                                <cp:CPMisComboBox ID="cdlstTerm" runat="server" DataSourceID="SqlDataSource3" DataTextField="Term"
                                    DefaultIndex="0" IsCancelDataBind="False" IsMaintainSelectedValue="False" SelectedText="">
                                </cp:CPMisComboBox>
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>"
                                    SelectCommand="SELECT [Term] FROM [Term] ORDER BY [Term] DESC"></asp:SqlDataSource>
                            </td>
                            <td class="border">
                                <cp:CPMisButton ID="cbntQuery" runat="server" Text="查询" OnClick="cbntQuery_Click">
                                </cp:CPMisButton>
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <cp:CPMisGrid ID="cgrdBookSeller" runat="server" CellSpacing="0" Culture="zh-CN"
                        GridLines="None" IsCancelDataBind="False" IsPersistCheckState="False" PersistPageIndex="0"
                        OnBeforeDataBind="cgrdSeller_BeforeDataBind">
                        <MasterTableView SkinID="Long">
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
                                    <HeaderStyle Width="40px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="BooksellerName" HeaderText="书商名称">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Telephone" HeaderText="联系电话">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Term" HeaderText="学年学期">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="教材名称" DataField="TextbookName" HeaderStyle-Width="160px">
                                    <ItemTemplate>
                                        <a href="#" onclick='<%# "OnClientBookDetailMessageCommand(\""+Eval("TextbookId")+"\")" %>'>
                                            <%# Eval("TextbookName")%></a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="TotalCount" HeaderText="出货总量">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RetailPrice" HeaderText="零售价">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Discount" HeaderText="折扣">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TotalRetailCharge" HeaderText="码洋">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TotalDiscountCharge" HeaderText="实洋">
                                </telerik:GridBoundColumn>
                                <%--<telerik:GridTemplateColumn HeaderText="查看教材情况">
                                        <ItemTemplate>
                                           <a href="TextbookList.aspx" target="_self">详情</a>
                                        </ItemTemplate>
                                   </telerik:GridTemplateColumn>--%>
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
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>"
                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Bookseller]">
                    </asp:SqlDataSource>
                </div>
            </telerik:RadPageView>
        </cp:CPMisMultiPage>
    </div>
    <telerik:RadWindowManager ID="RadWindowManag000er1" runat="server">
        <Windows>
            <telerik:RadWindow ID="wdwInventoryTextbookDiscountMessage" runat="server" Width="380"
                Height="350">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    </div>
    </form>
</body>
</html>
