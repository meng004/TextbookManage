<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TextbookStockQuery.aspx.cs" Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_4.TextbookStockQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
 <body>
    <form id="form1" runat="server">
    <telerik:RadSkinManager ID="RadSkinManager2" runat="server">
    </telerik:RadSkinManager>
    <telerik:RadScriptManager ID="RadScriptManager2" runat="server">
    </telerik:RadScriptManager>   
    <telerik:RadAjaxManager ID="RadAjaxManager2" runat="server" UpdatePanelsRenderMode="Inline">
        <ClientEvents OnRequestStart="onRequestStart" />
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="cbntQuery">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdTeacherQuery" LoadingPanelID="RadAjaxLoadingPanel1"> 
                        </telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="CPMisLinkButton1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cdlstStockName" LoadingPanelID="RadAjaxLoadingPanel1"> 
                        </telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>                  
                <telerik:AjaxSetting AjaxControlID="cdlstBookSellerName">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cdlstStockName" LoadingPanelID="RadAjaxLoadingPanel1"> 
                        </telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cgrdTeacherQuery">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdTeacherQuery" LoadingPanelID="RadAjaxLoadingPanel1"> 
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
              function OnClientGetStockMessage(StockID) {
                  var oWnd = $find("<%=wdwStockMessage.ClientID%>");
                  oWnd.setUrl("TextBookStockUpdate.aspx?StockID=" + StockID);  //
                  oWnd.show();
              }
      </script>
    </telerik:RadCodeBlock>
      <div id="tool" runat="server" class ="sty_div">
       <cp:CPMisToolBar ID="CPMisToolBar1"  runat="server" SkinID="Long">
         <Items> 
            <telerik:RadToolBarButton runat="server" CommandName="help" Text="帮助" ImageUrl ="~\Img\tlb_Help.png"> </telerik:RadToolBarButton>
         </Items> 
      </cp:CPMisToolBar>
    </div>

     
   <div >
     <cp:CPMisTabStrip runat="server" ID="tabStrip" MultiPageID="cteacher" SkinID="Long">
        <Tabs>
          <cp:CPMisTab  Text="查询仓库信息"></cp:CPMisTab>
        </Tabs>
     </cp:CPMisTabStrip>
     <cp:CPMisMultiPage  runat="server" ID="cteacher" SkinID="Long">
       <cp:CPMisPageView ID="CPMisPageView1" runat="server" >
          <div id="div_choose" runat="server" style="padding-left:5px;padding-top:2px;text-align:left;background-color: #E1EBF7;">              
              <cp:CPMisLabel ID="CPMisLabel2" runat="server" Text="书商名：" SkinID="AutoSize"  ></cp:CPMisLabel>&nbsp;&nbsp
              <cp:CPMisComboBox runat="server" ID="cdlstBookSellerName" SkinID="AutoSize" AutoPostBack="true"
                 DataTextField="BookSellerName" DataValueField="BookSellerId"></cp:CPMisComboBox>
            &nbsp;&nbsp;
              <cp:CPMisButton  runat="server" ID="cbntQuery" Text="查询"  OnClick="cbntQuery_Click"></cp:CPMisButton>
            </div>
            <div>
            <cp:CPMisGrid  ID="cgrdStockQuery" runat="server" SkinID="Long" 
                    AutoGenerateColumns="false" OnBeforeDataBind="cgrdStockQuery_BeforeDataBind" 
                    OnItemCommand="cgrdDelete_Click" AllowSorting="True">
              <MasterTableView>
                <Columns >
                  <telerik:GridTemplateColumn HeaderText="序号"  HeaderStyle-Width="40px">
                  <ItemTemplate><%#Container .DataSetIndex +1 %></ItemTemplate>
                  </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn HeaderText="仓库ID" DataField="StockId" HeaderStyle-Width="120px" Visible="false"></telerik:GridBoundColumn>
                  <telerik:GridBoundColumn HeaderText="书商名称" DataField="BookSellerName" HeaderStyle-Width="120px"></telerik:GridBoundColumn>
                  <telerik:GridBoundColumn  HeaderText="仓库名称" DataField="StockName"  HeaderStyle-Width="120px" ></telerik:GridBoundColumn>                 
                  <telerik:GridBoundColumn  HeaderText ="仓库编号"  DataField="StockNum" HeaderStyle-Width="120px" Visible="false"></telerik:GridBoundColumn>
                  <telerik:GridBoundColumn  HeaderText ="仓库地址"  DataField="StockAddress" ></telerik:GridBoundColumn>
                  <telerik:GridBoundColumn  HeaderText="联系电话" DataField="Telephone" HeaderStyle-Width="120px"  ></telerik:GridBoundColumn>
                  <telerik:GridBoundColumn  HeaderText ="账务开始时间"  DataField="AccountBeginDate"></telerik:GridBoundColumn>                                 
                  <telerik:GridTemplateColumn HeaderStyle-Width="80px" HeaderText="修改"> 
                            <ItemTemplate>
                            <a href="#" onclick="OnClientGetStockMessage('<%# Eval("StockID")  %>')">修改</a>
                            </ItemTemplate>
                  </telerik:GridTemplateColumn>
                  <telerik:GridTemplateColumn HeaderStyle-Width="80px" HeaderText="删除">
                    <ItemTemplate>
                    <cp:CPMisLinkButton ID="CPMisLinkButton1"  runat="server" Text="删除" OnClientClick="return confirm('确定删除?')" CommandName="Delete_Click"></cp:CPMisLinkButton>
                    </ItemTemplate>
                  </telerik:GridTemplateColumn>
                </Columns>
             </MasterTableView>
            </cp:CPMisGrid>
          </div>
       </cp:CPMisPageView >
     </cp:CPMisMultiPage>
   </div>
       <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        <Windows >
            <telerik:RadWindow ID="wdwStockMessage" runat="server" Top="150"  Width="400" Left="350" Height="250" title="仓库信息修改">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>                   
   </form>
</body>
</html>
