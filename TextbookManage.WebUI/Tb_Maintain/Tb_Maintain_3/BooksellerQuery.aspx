<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BooksellerQuery.aspx.cs" Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_3.BooksellerQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
      <style type="text/css">
    .border
       {
        border:0;
        margin:0;
        padding:0; 

        
        }
   </style>
</head>
<body>
    <form id="form1" runat="server">
      <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
    </telerik:RadSkinManager>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
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
              function OnClientGetBookMessage(booksellerID) {
                  var oWnd = $find("<%=wdw_BookMessage.ClientID%>");
                  oWnd.setUrl("BooksellerUpdate.aspx?booksellerID=" + booksellerID);

                  oWnd.show();
              }
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

        </script>
        </telerik:RadCodeBlock>
         <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <ClientEvents OnRequestStart="onRequestStart" />
          <AjaxSettings>
         <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdbooksellerQuery" />
                    <telerik:AjaxUpdatedControl ControlID="ctxtBooksellerName" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cbntQuery">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdbooksellerQuery" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cgrdbooksellerQuery">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdbooksellerQuery" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>


            <telerik:AjaxSetting AjaxControlID="lbtnDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ctxtBooksellerName" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>


        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" AutoTooltipify="true">
    </telerik:RadToolTipManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
      <div id="tool" runat="server" class ="sty_div">
       <cp:CPMisToolBar ID="CPMisToolBar1"  runat="server" SkinID="Long">
         <Items> 
            <telerik:RadToolBarButton runat="server" CommandName="help" Text="帮助" ImageUrl ="~/Img/tlb_Help.png"> </telerik:RadToolBarButton>
         </Items> 
      </cp:CPMisToolBar>
    </div>

     
   <div>
     <cp:CPMisTabStrip runat="server" ID="tabStrip" MultiPageID="cbookseller" SkinID="Long">
        <Tabs>
          <cp:CPMisTab  Text="查询书商信息"></cp:CPMisTab>
        </Tabs>
     </cp:CPMisTabStrip>
     <cp:CPMisMultiPage  runat="server" ID="cbookseller" SkinID="Long">
       <cp:CPMisPageView ID="CPMisPageView1" runat="server" >
          <div id="div_choose" runat="server" style="padding-left:5px;padding-top:2px;text-align:left;background-color: #E1EBF7;"  > 
 
              
              <table class="border">
              <tr>
              <td class="border">
              <cp:CPMisLabel ID="clblBooksellerName" runat="server" Text="书商名称：" SkinID="AutoSize" >
              </cp:CPMisLabel>
              </td>
             <%--<cpbc:CodeDropDownList ID="ctxtBooksellerName" runat="server" RecordSetField="*" SkinID="AutoSize" Width="123px" RecordSetName="Bookseller"
                     DataTextField="BooksellerName" DataValueField="BooksellerID" ExtraListItem="---请选择---,"></cpbc:CodeDropDownList>--%>
               <td class="border">
              <asp:DropDownList ID="ctxtBooksellerName" runat="server" SkinID="AutoSize" Width="100px">
              </asp:DropDownList>
              </td>
              <td class="border" style="Width:100px" align="right" >
              
              <cp:CPMisButton  runat="server" ID="cbntQuery" Text="查询"  OnClick="cbntQuery_Click"></cp:CPMisButton>
             </td> 
             </tr>
             </table>           
            </div>
            <div>
                <cp:CPMisGrid ID="cgrdbooksellerQuery" runat="server"  OnBeforeDataBind="cgrdbooksellerQuery_BeforeDataBind"
                    IsCancelDataBind="False" IsPersistCheckState="False" PersistPageIndex="0">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="BooksellerID" AllowSorting="true">
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        
                       <Columns >
                            <telerik:GridTemplateColumn HeaderText="序号"  HeaderStyle-Width="40px">
                            <ItemTemplate><%#Container .DataSetIndex +1 %></ItemTemplate>
                                <HeaderStyle Width="40px" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="BooksellerID"  Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BooksellerNum"  HeaderText="书商编号">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BooksellerName"  HeaderText="书商名称">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Contact"  HeaderText="联系人">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Telephone"  HeaderText="联系电话">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="编辑">
                           <ItemTemplate>                           
                                <a href="#"  onclick="return OnClientGetBookMessage('<%#Eval("BooksellerID")%>')" >编辑</a>
                           </ItemTemplate>
                           </telerik:GridTemplateColumn>
                           <telerik:GridTemplateColumn HeaderText="删除">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnDelete" runat="server" Text="删除"   OnClick="lbtnDelete_Click" CommandArgument='<%#Eval("BooksellerID")%>'></asp:LinkButton>
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
            <telerik:RadWindow ID="wdw_BookMessage" runat="server" Top="150px" Left="350px" Width="420" Height="230"  Title="修改书商信息">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    </form>
</body>
</html>