<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleFunctionList.aspx.cs"
    Inherits="CPMis.WebPage.SystemManageUI.RoleManageUI.RoleFunctionList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>角色功能</title>

    <script language="javascript" type="text/javascript" src="../../JS/WebScript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadSkinManager ID="RadSkinManage1" runat="server"></telerik:RadSkinManager>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
     <script language="javascript" type="text/javascript">
         //如果点击的是导出按钮则将AJAX禁用
         function onRequestStart(sender, args) {
             if (args.get_eventTarget().indexOf("ExportToExcelButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToWordButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToPdfButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToCsvButton") >= 0) {

                 args.set_enableAjax(false);
             }
         }
         function OnToolBarButtonClicked(sender, args) {
             var button = args.get_item();
             var command = button.get_commandName();
             var a = true;
             if (command == "Query") {
                 refreshGrid("Query");
                 args.set_cancel(true);
             }
             else if (command == "Delete") {
                 a = confirm("确认删除?");
                 if (a == true) {
                     refreshGrid("Delete");
                     args.set_cancel(true);
                 }
                 else {
                     args.set_cancel(true);
                 }
             }
             else if (command == "Help") {
                 refreshGrid("Help");
                 args.set_cancel(true);
             }
         }
         //异步回调,刷新grid
         function refreshGrid(arg) {
             $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(arg);
         }
    </script>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server"  OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <ClientEvents OnRequestStart="onRequestStart" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="wg_FunctionRoleList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="wg_FunctionRoleList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="wg_FunctionRoleList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
    <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" AutoTooltipify="true">
    </telerik:RadToolTipManager>
    <div id="main">
        <%-- ToolBar OnClientButtonClicking="OnToolBarButtonClicked"--%>
        <cp:CPMisToolBar ID="tb_RoleFunctionUserList" OnClientButtonClicking="OnToolBarButtonClicked" runat="Server">
            <Items>
                <telerik:RadToolBarButton Text="删 除" CommandName="Delete" ToolTip="选择角色功能，点击删除，删除所选的角色功能"
                    ImageUrl="~/Img/tlb_Delete.png">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Text="帮 助" ToolTip="点击获取帮助" CommandName="Help" ImageUrl="~/Img/tlb_Help.png">
                </telerik:RadToolBarButton>
            </Items>
        </cp:CPMisToolBar>
        <%--TabStrip--%>
        <cp:CPMisTabStrip ID="tab_RoleFunctionUserList" runat="server" MultiPageID="mp_RoleFunctionUserList">
            <Tabs>
                <cp:CPMisTab Text="角色功能(F)" AccessKey="F">
                </cp:CPMisTab>
            </Tabs>
        </cp:CPMisTabStrip>
        <cp:CPMisMultiPage ID="mp_RoleFunctionUserList" runat="server">
            <cp:CPMisPageView ID="pv_RoleFunctionUserList" runat="server">
            <div style="padding:2px;">
            <cp:CPMisLabel Text="您当前选择的角色为:" runat="server" ID="lbl_CurrentRole" SkinID="AutoSize"
                    Font-Size="15px"></cp:CPMisLabel>
                <cp:CPMisLabel ID="lbl_RoleName" runat="server" SkinID="Paraset" Font-Size="15px"
                    ForeColor="Red"></cp:CPMisLabel>
            </div>
                
                <cp:CPMisGrid ID="wg_FunctionRoleList" runat="server" CheckControlID="chb_RowCheck"
                    Width="795px" SkinID="NoPaging" OnBeforeDataBind="wg_FunctionRoleList_BeforeDataBind" 
                    Height="500px" >
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn UniqueName="ID" DataField="ID" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="chk_SelectOne" DataField="CheckFlag">
                                <HeaderStyle Width="30px" />
                                <HeaderTemplate>
                                    <cp:CPMisCheckBox ID="chb_HeadCheck" OnCheckedChanged="chb_HeadCheck_CheckedChanged"
                                        AutoPostBack="true" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <cp:CPMisCheckBox ID="chb_RowCheck" Checked='<%#Eval("CheckFlag") %>' runat="server"
                                        OnCheckedChanged="chb_RowCheck_CheckedChanged" AutoPostBack="true" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="FunctionID" UniqueName="FunctionNum" HeaderText="功能编号">
                                <HeaderStyle Width="85px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FunctionName" UniqueName="FunctionName" HeaderText="功能名称">
                                <HeaderStyle Width="120px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FunctionURL" UniqueName="FunctionURL" HeaderText="功能路径">
                            </telerik:GridBoundColumn>
                           <%-- <telerik:GridBoundColumn DataField="IsShow" UniqueName="IsShow" HeaderText="是否显示">
                            <HeaderStyle Width="70px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PageWeight" UniqueName="PageWeight" HeaderText="页面权值"
                            HeaderStyle-Width="70px">
                            </telerik:GridBoundColumn>--%>
                        </Columns>
                    </MasterTableView>
                    <ClientSettings>
                    <Scrolling ScrollHeight="444px" />
                    </ClientSettings>
                </cp:CPMisGrid>
            </cp:CPMisPageView>
        </cp:CPMisMultiPage>
    </div>
    </form>
</body>
</html>
