<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateBooksellerStaff.aspx.cs" Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_7.UpdateBooksellerStaff" %>

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
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>                    
                    <telerik:AjaxUpdatedControl ControlID="cgrdUpdateBooksellerStaff" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cbtnQuery">
               <UpdatedControls>
                 <telerik:AjaxUpdatedControl ControlID="cgrdUpdateBooksellerStaff" LoadingPanelID="RadAjaxLoadingPanel1"/>
               </UpdatedControls>
            </telerik:AjaxSetting>
             <telerik:AjaxSetting AjaxControlID="lbtnDelete">
               <UpdatedControls>
                 <telerik:AjaxUpdatedControl ControlID="cgrdUpdateBooksellerStaff" LoadingPanelID="RadAjaxLoadingPanel1"/>
               </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lbtnUpdate">
               <UpdatedControls>
                 <telerik:AjaxUpdatedControl ControlID="cgrdUpdateBooksellerStaff" LoadingPanelID="RadAjaxLoadingPanel1"/>
               </UpdatedControls>
            </telerik:AjaxSetting>
              <telerik:AjaxSetting AjaxControlID="cgrdUpdateBooksellerStaff">
               <UpdatedControls>
                 <telerik:AjaxUpdatedControl ControlID="cgrdUpdateBooksellerStaff" LoadingPanelID="RadAjaxLoadingPanel1"/>
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
        function OnClientBooksellerStaff(BooksellerStaffId,BooksellerName) {
            var oWnd = $find("<%=wdw_BooksellerStaff.ClientID%>");
            oWnd.setUrl(encodeURI("UpdateBooksellerStaffForms.aspx?BooksellerStaffId=" + BooksellerStaffId + "&BooksellerName=" + BooksellerName)); //
            oWnd.show();
            oWnd.setSize(420, 250);
        }
    </script>
    <div>
        <cp:CPMisToolBar ID="toolbar" runat="server" SkinID="Long">
            <Items>
                <telerik:RadToolBarButton Text="帮助" ImageUrl="~/Img/tlb_Help.png" runat="server">
                </telerik:RadToolBarButton>
            </Items>
        </cp:CPMisToolBar>
    </div>
    <div>
        <cp:CPMisTabStrip ID="CPMisTabStrip1" runat="server" MultiPageID="mp" SkinID="Long">
            <Tabs>
                <cp:CPMisTab runat="server" Text="修改和删除书商员工" SkinID="AutoSize">
                </cp:CPMisTab>
            </Tabs>
        </cp:CPMisTabStrip>
        <cp:CPMisMultiPage runat="server" ID="mp" SkinID="Long">
            <cp:CPMisPageView ID="CPMisPageView1" runat="server" SkinID="Long">
                <div id="Div1" runat="server" style="padding-left: 5px; padding-top: 2px; text-align: left;
                    background-color: #E1EBF7;">
                    <cp:CPMisLabel ID="CPMisLabel1" runat="server" Text="书商名称：" SkinID="AutoSize"></cp:CPMisLabel>&nbsp;
                    <cp:CPMisComboBox runat="server" ID="ccmbBooksellerName"  DataTextField="BooksellerName"
                     DataValueField="BooksellerID">
                    </cp:CPMisComboBox>
                    <asp:SqlDataSource ID="SqlDataSource_Bookseller" runat="server" ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>"
                        ProviderName="System.Data.SqlClient" SelectCommand="prBookSellerNameGetList" SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <cp:CPMisButton runat="server" ID="cbtnQuery" Text="查询" OnClick="cbtnQuery_Click" />
                </div>
                <div>
                    <cp:CPMisGrid runat="server" ID="cgrdUpdateBooksellerStaff" SkinID="Long" OnBeforeDataBind="cgrdUpdateBooksellerStaff_OnBeforeDataBind">
                        <MasterTableView DataKeyNames="BooksellerStaffId">
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="序号" HeaderStyle-Width="60px">
                                    <ItemTemplate>
                                        <%#Container .DataSetIndex +1 %>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn HeaderText="员工编号" HeaderStyle-Width="200px" DataField="StaffNum">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="员工姓名" HeaderStyle-Width="300px" DataField="StaffName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="性别" HeaderStyle-Width="100px" DataField="Sex">
                                </telerik:GridBoundColumn>                                
                                <telerik:GridTemplateColumn HeaderText="修改">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <cp:CPMisLinkButton runat="server" ID="lbtnUpdate" Text="修改" OnClick="lbtnUpdate_Click"></cp:CPMisLinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                  <telerik:GridTemplateColumn HeaderText="删除">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <cp:CPMisLinkButton runat="server" ID="lbtnDelete" Text="删除" OnClick="lbtnDelete_Click" ></cp:CPMisLinkButton>
                                     </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </cp:CPMisGrid>
                </div>
            </cp:CPMisPageView>
        </cp:CPMisMultiPage>
    </div>
     <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        <Windows>
            <telerik:RadWindow ID="wdw_BooksellerStaff" runat="server" Top="120" Left="470"
                ReloadOnShow="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    </form>
</body>
</html>
