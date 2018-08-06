<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleFunction.aspx.cs" Inherits="CPMis.WebPage.SystemManageUI.RoleManageUI.RoleFunction" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>角色权限管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadSkinManager ID="RadSkinManage1" runat="server"></telerik:RadSkinManager>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

        <script type="text/javascript" language="javascript">
            //如果点击的是导出按钮则将AJAX禁用
            function onRequestStart(sender, args) {
                if (args.get_eventTarget().indexOf("ExportToExcelButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToWordButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToPdfButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToCsvButton") >= 0) {

                    args.set_enableAjax(false);
                }
            }
            function OnButtonClientClick() {
                refreshGrid("OK");
                return false;
            }
            function OnToolBarButtonClicked(sender, args) {
                var button = args.get_item();
                var command = button.get_commandName();
                var a = true;
                if (command == "Save") {
                    a = confirm("确认保存?");
                    if (a == true) {
                        refreshGrid("Save");
                        args.set_cancel(true);
                    }
                    else {
                        args.set_cancel(true);
                        return false;
                    }
                }
                refreshGrid(command);
                args.set_cancel(true);
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
                    <telerik:AjaxUpdatedControl ControlID="wg_RootFunctionList" />
                    <telerik:AjaxUpdatedControl ControlID="wg_FunctionRoleList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="wg_RootFunctionList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="wg_RootFunctionList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="wg_FunctionRoleList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="wg_FunctionRoleList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="wg_RootFunctionList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="wg_FunctionRoleList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddl_RoleName">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="wg_RootFunctionList" />
                    <telerik:AjaxUpdatedControl ControlID="wg_FunctionRoleList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
    <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" AutoTooltipify="true">
    </telerik:RadToolTipManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <div>
        <%--ToolBar--%>
        <cp:CPMisToolBar ID="tb_RoleFunction"
            SkinID="Long" runat="Server" OnClientButtonClicking="OnToolBarButtonClicked">
            <Items>
                <telerik:RadToolBarButton Text="授 权" CommandName="Save" ToolTip="为角色选择功能，点击为角色授权"
                    ImageUrl="~/Img/tlb_Save.png">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Text="帮 助" CommandName="Help" ToolTip="点击获取帮助" ImageUrl="~/Img/tlb_Help.png">
                </telerik:RadToolBarButton>
            </Items>
        </cp:CPMisToolBar>
        <%--TabStrip--%>
        <cp:CPMisTabStrip ID="tab_RoleFunction" runat="server" SkinID="Long" MultiPageID="mp_RoleFunction">
            <Tabs>
                <cp:CPMisTab Text="角色权限(F)" AccessKey="F">
                </cp:CPMisTab>
            </Tabs>
        </cp:CPMisTabStrip>
        <cp:CPMisMultiPage ID="mp_RoleFunction" runat="server" SkinID="Long">
            <%--角色权限管理--%>
            <cp:CPMisPageView ID="pv_RoleFunction" runat="server">
                <table width="1000px">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <cp:CPMisLabel ID="lbl_RoleName" runat="server" Text="角色名称："></cp:CPMisLabel>
                                    </td>
                                    <td>
                                        <cp:CPMisComboBox ID="ddl_RoleName" DataTextField="RoleName" DataValueField="ID"
                                            OnBeforeDataBind="ddl_RoleName_BeforeDataBind" runat="server" OnAfterDataBind="ddl_RoleName_AfterDataBind"
                                            OnSelectedIndexChanged="ddl_RoleName_AfterDataBind" AutoPostBack="true">
                                        </cp:CPMisComboBox>
                                    </td>
                                    <td>
                                        <cp:CPMisLabel runat="server" Text="" Width="20px" SkinID="AutoSize"></cp:CPMisLabel>
                                    </td>
                                    <td>
                                        <cp:CPMisButton ID="btn_Sure" runat="server" Text="确 定" OnBeforeClick="btn_Sure_BeforeClick"
                                            OnAfterClick="btn_Sure_AfterClick" OnClientClick="return OnButtonClientClick()">
                                        </cp:CPMisButton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="float: left;">
                                <cp:CPMisGrid ID="wg_RootFunctionList" runat="server" SkinID="NoPaging" OnBeforeDataBind="wg_RootFunctionList_BeforeDataBind"
                                    OnItemCommand="wg_RootFunctionList_ItemCommand" OnAfterDataBind="wg_RootFunctionList_AfterDataBind"
                                    Width="210px" Height="460px">
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="FunctionID" UniqueName="FunctionID" HeaderText="功能编号"
                                                HeaderStyle-Width="65px">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn DataField="FunctionName" UniqueName="FunctionName" HeaderText="功能名称">
                                                <ItemTemplate>
                                                    <cp:CPMisLinkButton ID="lnk_UpdateFunction" Text='<%# DataBinder.Eval(Container.DataItem,"FunctionName") %>'
                                                        runat="server" CommandName="FunctionName"></cp:CPMisLinkButton>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                </cp:CPMisGrid>
                            </div>
                            <div style="float: left;">
                                <cp:CPMisGrid ID="wg_FunctionRoleList" runat="server" CheckControlID="chb_RowCheck"
                                    Height="460px" Width="778px" SkinID="NoPaging" OnBeforeDataBind="wg_FunctionRoleList_BeforeDataBind"
                                    OnAfterDataBind="wg_FunctionRoleList_AfterDataBind" >
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridBoundColumn UniqueName="ID" DataField="ID" Visible="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn DataField="CheckFlag" UniqueName="CheckFlag" HeaderStyle-Width="30px">
                                                <HeaderTemplate>
                                                    <cp:CPMisCheckBox ID="chb_HeadCheck" OnCheckedChanged="chb_HeadCheck_CheckedChanged"
                                                        AutoPostBack="true" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <cp:CPMisCheckBox ID="chb_RowCheck" runat="server" AutoPostBack="true" Checked='<%#Eval("CheckFlag") %>'
                                                        OnCheckedChanged="wg_FunctionRoleList_CheckedChanged" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="FunctionID" UniqueName="FunctionID" HeaderText="功能编号"
                                                HeaderStyle-Width="85px">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FunctionName" UniqueName="FunctionName" HeaderText="功能名称"
                                                HeaderStyle-Width="140px">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FunctionURL" UniqueName="FunctionURL" HeaderText="功能路径">
                                            </telerik:GridBoundColumn>
                                           <%-- <telerik:GridBoundColumn DataField="IsShow" UniqueName="IsShow" HeaderText="是否显示"
                                            HeaderStyle-Width="70px">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PageWeight" UniqueName="PageWeight" HeaderText="页面权值"
                                            HeaderStyle-Width="70px">
                                            </telerik:GridBoundColumn>--%>
                                        </Columns>
                                    </MasterTableView>
                                    <ClientSettings>
                                        <Scrolling ScrollHeight="373px" />
                                    </ClientSettings>
                                </cp:CPMisGrid>
                            </div>
                        </td>
                    </tr>
                </table>
            </cp:CPMisPageView>
        </cp:CPMisMultiPage>
    </div>
    </form>
</body>
</html>
