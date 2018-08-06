<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryQuery.aspx.cs" Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_5.InventoryQuery" %>

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
                        <telerik:AjaxUpdatedControl ControlID="cgrdStock" 
                            LoadingPanelID="RadAjaxLoadingPanel1" UpdatePanelRenderMode="Inline"> 
                        </telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
    </telerik:RadAjaxManager>
  
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All"/>

    <telerik:RadToolTipManager  ID="RadToolTipManager1" runat="server" AutoTooltipify="true"></telerik:RadToolTipManager>
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
              function OnClientGetBookMessage(InventoryID, StockName, TextbookName, StockInCount, StoreCount, ReleaseCount) {
                  var oWnd = $find("<%=wdw_BookMessage.ClientID%>");
                  oWnd.setUrl("InventoryUpdate.aspx?inventoryID=" + InventoryID + "&stockName=" + escape(StockName) + "&textbookName=" + escape(TextbookName) + "&stockInCount=" + escape(StockInCount) + "&storeCount=" + escape(StoreCount) + "&releaseCount=" + escape(ReleaseCount)); //
                  oWnd.show();
              }
     </script>
</telerik:RadCodeBlock>
      <div id="tool" runat="server" class ="sty_div">
       <cp:CPMisToolBar ID="CPMisToolBar1"  runat="server" SkinID="Long">
         <Items> 
            <telerik:RadToolBarButton runat="server" CommandName="help" Text="帮助" ImageUrl ="~/Img/tlb_Help.png"> </telerik:RadToolBarButton>
         </Items> 
      </cp:CPMisToolBar>
    </div>
   <div >
     <cp:CPMisTabStrip runat="server" ID="tabStrip" MultiPageID="cstock" SkinID="Long" 
           SelectedIndex="0">
        <Tabs>
          <cp:CPMisTab  Text="查询库存教材信息"></cp:CPMisTab>
        </Tabs>
     </cp:CPMisTabStrip>
     <cp:CPMisMultiPage  runat="server" ID="cstock" SkinID="Long">
       <cp:CPMisPageView ID="CPMisPageView1" runat="server" >
          <div id="div_choose" runat="server" style="padding-left:5px;padding-top:2px;text-align:left;background-color: #E1EBF7;"  > 
             <cp:CPMisLabel ID="clalBooksellerName" runat="server" Text="书商名称：" SkinID="AutoSize"></cp:CPMisLabel>
              <cp:CPMisComboBox ID="cdlstBooksellerName" runat="server" AutoPostBack="true"
                    DataTextField="BooksellerName" DefaultIndex="0" 
                    IsCancelDataBind="False" IsMaintainSelectedValue="False" SelectedText="" 
                        DataValueField="BooksellerID" 
                  onprerender="cdlstBooksellerName_PreRender"></cp:CPMisComboBox>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>" 
                    SelectCommand="SELECT [BooksellerName], [BooksellerID] FROM [Bookseller]">
                </asp:SqlDataSource>
                  &nbsp;&nbsp;
                  <cp:CPMisLabel ID="clalStockName" runat="server" SkinID="AutoSize" Text="仓库名称："></cp:CPMisLabel>
                  <cp:CPMisComboBox ID="cdlstStockName" runat="server" DataTextField="StockName" 
                      DefaultIndex="0" IsCancelDataBind="False" IsMaintainSelectedValue="False" 
                      SelectedText="">
                  </cp:CPMisComboBox>&nbsp;&nbsp;
              <cp:CPMisLabel ID="clblTextbookName"  runat="server" Text="教材名称：" SkinID="AutoSize" ></cp:CPMisLabel>&nbsp;&nbsp
              <cp:CPMisTextBox runat="server" ID="ctxtTextbookName" SkinID="AutoSize"></cp:CPMisTextBox>&nbsp;&nbsp
              <cp:CPMisTextBox runat="server" ID="ctxtSaveTextbookName" SkinID="AutoSize" Visible="false"></cp:CPMisTextBox>
              <cp:CPMisTextBox runat="server" ID="ctxtSaveStockName" SkinID="AutoSize" Visible="false"></cp:CPMisTextBox>
              <cp:CPMisButton  runat="server" ID="cbntQuery" Text="查询"  OnClick="cbntQuery_Click"></cp:CPMisButton>
              <cp:CPMisGrid ID="cgrdStock" runat="server" CellSpacing="0" 
                   OnBeforeDataBind="cgrdStock_BeforeDataBind" GridLines="None" IsCancelDataBind="False" 
                  IsPersistCheckState="False" PersistPageIndex="0" 
                  onitemcommand="cgrdStock_ItemCommand">
                  <MasterTableView AutoGenerateColumns="False" DataKeyNames="InventoryID">
                      <Columns>
                            <telerik:GridTemplateColumn HeaderText="序号"  HeaderStyle-Width="40px"> 
                           
                            <ItemTemplate><%#Container .DataSetIndex +1 %></ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="TextbookName"  HeaderText="教材名称">
                          </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="StockName"  HeaderText="仓库名称" >
                          </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="InventoryID"  HeaderText="InventoryID" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="StockInCount" HeaderText="入库数量" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="StoreCount"  HeaderText="库存数量" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ReleaseCount"  HeaderText="发放数量" >
                            </telerik:GridBoundColumn>
                          <telerik:GridTemplateColumn HeaderText="修改">
                           <ItemTemplate>
                                   <a href="#"  onclick="OnClientGetBookMessage('<%# Eval("InventoryID")  %>','<%# Eval("StockName")  %>','<%# Eval("TextbookName")  %>','<%# Eval("StockInCount")  %>','<%# Eval("StoreCount")  %>','<%# Eval("ReleaseCount")  %>')" >修改</a>
                           </ItemTemplate>
                           </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn  HeaderText="删除"> 
                            <ItemTemplate>
                                    <asp:LinkButton ID="dtDelete" runat="server" CausesValidation="False" CommandName="delete"     
                                        CommandArgument='<%# Eval("InventoryID")  %>' OnClientClick='if(confirm("您确定删除吗?"))return true;else return false;'>删除</asp:LinkButton> 
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
       </cp:CPMisPageView >
     </cp:CPMisMultiPage>
   </div>
       <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        <Windows>
            <telerik:RadWindow ID="wdw_BookMessage" runat="server" Top="150" Width="400" Left="350" Height="250" Title="修改库存信息" >
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>    
    </form>
</body>
</html>
