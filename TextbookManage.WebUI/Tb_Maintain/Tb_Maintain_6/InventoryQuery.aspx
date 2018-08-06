<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryQuery.aspx.cs"
    Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_6.InventoryQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                    <telerik:AjaxUpdatedControl ControlID="cdlstStockName" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cbtnQuery">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cdgrdList" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
    <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" AutoTooltipify="true">
    </telerik:RadToolTipManager>
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
            function OnClientGetDiscountMessage(InventoryID) {
                var oWnd = $find("<%=wdw_BookMessage.ClientID%>");
                oWnd.setUrl("DiscountAdd.aspx?id=" + InventoryID); //
                oWnd.show();
            }
            function OnClientTextbookMessage(TextbookID) {
                var oWnd = $find("<%=wdw_BookMessage.ClientID%>");
                oWnd.setUrl("../../Tb_Query/TextbookDetailMessage.aspx?TextbookId=" + TextbookID); //
                oWnd.show();
                oWnd.setSize(450, 290);
            }
            function selectAll(ctlName, bool) {
                var ctl = document.getElementById(ctlName); //根据控件的在客户端所呈现的ID获取控件
                var checkbox = ctl.getElementsByTagName('input'); //获取该控件内标签为input的控件
                /*所有Button、TextBox、CheckBox、RadioButton类型的服务器端控件在解释成Html控件后，都为<input type=''./>，通过type区分它们的类型。*/
                for (var i = 0; i < checkbox.length; i++) {
                    if (checkbox[i].type == 'checkbox') {
                        checkbox[i].checked = bool;
                    }
                }
            }

            function check() {
                var temp = $get("<%=ctxtDiscount.ClientID %>");
                var reg = /^[1]|([0][.][0-9]{1,2}?$)/;
                if (!reg.test(temp.value)) {
                    alert("折扣应该是0到1之间的两位小数");
                    return false;
                }
            }


        </script>
    </telerik:RadCodeBlock>
    <div id="tool" runat="server" class="sty_div">
        <cp:CPMisToolBar ID="CPMisToolBar1" runat="server" SkinID="Long">
            <Items>
                <telerik:RadToolBarButton runat="server" CommandName="help" Text="帮助" ImageUrl="~/Img/tlb_Help.png">
                </telerik:RadToolBarButton>
            </Items>
        </cp:CPMisToolBar>
    </div>
    <div>
        <cp:CPMisTabStrip runat="server" ID="tabStrip" MultiPageID="cstock" SkinID="Long"
            SelectedIndex="0">
            <Tabs>
                <cp:CPMisTab Text="查询库存信息">
                </cp:CPMisTab>
            </Tabs>
        </cp:CPMisTabStrip>
        <cp:CPMisMultiPage runat="server" ID="cstock" SkinID="Long" Width="100%">
            <cp:CPMisPageView ID="CPMisPageView1" runat="server" Style="float: left">
                <div style="padding-left: 5px; padding-top: 2px; text-align: left; background-color: #E1EBF7;
                    width: 995px;">
                    <table style="border: 0px;">
                        <tr>
                            <td style="border: 0px;">
                                <cp:CPMisLabel ID="CPMisLabel4" runat="server" IsCancelDataBind="False">学年学期：</cp:CPMisLabel>
                            </td>
                            <td style="border: 0px;">
                                <cp:CPMisComboBox ID="cdlstTrem" runat="server" DataSourceID="SqlDataSource1" DataTextField="Term"
                                    DataValueField="Term" DefaultIndex="0" IsCancelDataBind="False" IsMaintainSelectedValue="False"
                                    SelectedText="" SkinID="cmb120">
                                </cp:CPMisComboBox>
                            </td>
                            <td style="border: 0px;">
                                <cp:CPMisLabel ID="CPMisLabel1" runat="server" IsCancelDataBind="False">书商名称：</cp:CPMisLabel>
                            </td>
                            <td style="border: 0px;">
                                <cp:CPMisComboBox ID="cdlstBooksellerName" runat="server" AutoPostBack="true" DataTextField="BooksellerName"
                                    DataValueField="BooksellerID" DefaultIndex="0" IsCancelDataBind="False" IsMaintainSelectedValue="False"
                                    SelectedText="" SkinID="cmb120" OnPreRender="cdlstBooksellerName_PreRender">
                                </cp:CPMisComboBox>
                            </td>
                            <td style="border: 0px;">
                                <cp:CPMisLabel ID="CPMisLabel2" runat="server" IsCancelDataBind="False">仓库名：</cp:CPMisLabel>
                            </td>
                            <td style="border: 0px;">
                                <cp:CPMisComboBox ID="cdlstStockName" runat="server" SkinID="cmb120">
                                </cp:CPMisComboBox>
                            </td>
                            <td style="border: 0px;">
                                <cp:CPMisLabel ID="CPMisLabel3" runat="server" IsCancelDataBind="False">教材名称：</cp:CPMisLabel>
                            </td>
                            <td style="border: 0px;">
                                <cp:CPMisTextBox ID="ctxtTextbookName" runat="server" SkinID="cmb120">
                                </cp:CPMisTextBox>
                            </td>
                            <td style="border: 0px;">
                                <cp:CPMisButton ID="cbtnQuery" runat="server" Text="查询" OnClick="cbntQuery_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="border: 0px;">
                                <cp:CPMisLabel ID="CPMisLabel5" runat="server" IsCancelDataBind="False">折扣：</cp:CPMisLabel>
                            </td>
                            <td style="border: 0px;">
                                <cp:CPMisTextBox ID="ctxtDiscount" runat="server" SkinID="cmb120" IsCancelDataBind="False"
                                    Text="0.9" Width="125px">
                                </cp:CPMisTextBox>
                            </td>
                            <td style="border: 0px;">
                                &nbsp;
                            </td>
                            <td style="border: 0px;">
                                <cp:CPMisButton ID="cbtnDiscountAdd" runat="server" OnClick="cbtnDiscountAdd_Click"
                                    OnClientClick="javascript:return check()" Text="添加折扣" />
                            </td>
                            <td style="border: 0px;" colspan="5">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="ctxtDiscount"
                                    Display="Dynamic" EnableClientScript="true" ErrorMessage="折扣应该是0到1之间的两位小数" ValidationExpression="^1|(0\.[0-9]{1,2}?$)"
                                    ValidationGroup="BaseInfoGroup"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </table>
                </div>
                <cp:CPMisGrid ID="cdgrdList" runat="server" AutoGenerateColumns="False" Culture="zh-CN"
                    IsCancelDataBind="False" IsPersistCheckState="False" PersistPageIndex="0" CellSpacing="0"
                    GridLines="None" OnBeforeDataBind="cdgrdList_BeforeDataBind">
                    <MasterTableView>
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderStyle-Width="30px">
                                <HeaderTemplate>
                                    <cp:CPMisCheckBox runat="server" ID="cchkSelectAll" onclick="javascript:selectAll('cdgrdList',this.checked);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <cp:CPMisCheckBox runat="server" ID="cchk" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderStyle-Width="30px" HeaderText="序号">
                                <ItemTemplate>
                                    <%#Container .DataSetIndex +1 %>
                                </ItemTemplate>
                                <HeaderStyle Width="40px" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="StockName" HeaderText="仓库名称">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="教材名称" DataField="TextbookName">
                                <ItemTemplate>
                                    <a href="#" onclick='<%# "OnClientTextbookMessage(\""+Eval("TextbookID")+"\")" %>'>
                                        <%# Eval("TextbookName")%></a>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                             <telerik:GridBoundColumn DataField="RetailPrice" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="InventoryID" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="InputCount" HeaderText="入库数量">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="StoreCount" HeaderText="库存">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ReleaseCount" HeaderText="发放数量">
                            </telerik:GridBoundColumn>
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
            </cp:CPMisPageView>
        </cp:CPMisMultiPage>
    </div>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        <Windows>
            <telerik:RadWindow ID="wdw_BookMessage" runat="server" Top="20" Width="400" Left="300"
                Height="550">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>"
        SelectCommand="SELECT [Term] FROM [Term] ORDER BY [Term] DESC"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>"
        SelectCommand="SELECT [BooksellerName], [BooksellerID] FROM [Bookseller]"></asp:SqlDataSource>
    <asp:ValidationSummary ID="vds_OverseasAdd" ValidationGroup="BaseInfoGroup" ShowSummary="false"
        ShowMessageBox="true" HeaderText="验证信息出错!" runat="server" />
    </form>
</body>
</html>
