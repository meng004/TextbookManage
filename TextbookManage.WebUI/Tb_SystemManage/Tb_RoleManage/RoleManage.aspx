<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleManage.aspx.cs" Inherits="CPMis.WebPage.SystemManageUI.RoleManageUI.PoleManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>角色管理</title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
        </telerik:RadSkinManager>
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

            <script type="text/javascript" language="javascript">
                function OnToolBarButtonClicked(sender, args) {
                    var button = args.get_item();
                    var command = button.get_commandName();
                    var a = true;
                    if (command == "Add") {
                        var oWnd = $find("<%=wdw_RoleManage.ClientID%>");
                        oWnd.setUrl("RoleAdd.aspx?IsUpdate=" + "false" + "&OldRoleName=" + ""); //
                        oWnd.show();
                        oWnd.setSize(320, 120);
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
                //如果点击的是导出按钮则将AJAX禁用
                function onRequestStart(sender, args) {
                    if (args.get_eventTarget().indexOf("ExportToExcelButton") >= 0 ||
                        args.get_eventTarget().indexOf("ExportToWordButton") >= 0 ||
                        args.get_eventTarget().indexOf("ExportToPdfButton") >= 0 ||
                        args.get_eventTarget().indexOf("ExportToCsvButton") >= 0) {

                        args.set_enableAjax(false);
                    }
                }
                function OnClientUpdateCommand(oldRoleName) {
                    var oWnd = $find("<%=wdw_RoleManage.ClientID%>");
                    oWnd.setUrl("RoleAdd.aspx?IsUpdate=" + "true" + "&OldRoleName=" + escape(oldRoleName)); //
                    oWnd.show();
                    oWnd.setSize(300, 120);
                }
                //异步回调,刷新grid
                function refreshGrid(arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(arg);
                }
            </script>

        </telerik:RadCodeBlock>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
            <ClientEvents OnRequestStart="onRequestStart" />
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="wg_RoleManage" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="wg_RoleManage">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="wg_RoleManage" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" AutoTooltipify="true">
        </telerik:RadToolTipManager>
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
        <div>
            <cp:CPMisToolBar ID="tb_RoleManage" OnClientButtonClicking="OnToolBarButtonClicked"
                runat="server" SkinID="Long">
                <Items>
                    <telerik:RadToolBarButton Text="添加角色" CommandName="Add" ToolTip="点击弹出添加角色Window，添加角色" ImageUrl="../../Img/tlb_Add.png">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton Text="删除角色" CommandName="Delete" ToolTip="在角色列表中选择角色，点击删除，删除相应的角色" ImageUrl="../../Img/tlb_Delete.png">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton Text="帮 助" CommandName="Help" ToolTip="点击获取帮助" ImageUrl="../../Img/tlb_Help.png">
                    </telerik:RadToolBarButton>
                </Items>
            </cp:CPMisToolBar>
            <cp:CPMisTabStrip ID="tab_RoleManage" runat="server" MultiPageID="mp_RoleManage" SkinID="Long">
                <Tabs>
                    <cp:CPMisTab Text="角色管理(F)" AccessKey="F">
                    </cp:CPMisTab>
                </Tabs>
            </cp:CPMisTabStrip>
            <cp:CPMisMultiPage ID="mp_RoleManage" runat="server" SkinID="Long">
                <cp:CPMisPageView ID="pv_RoleManage" runat="server">
                    <cp:CPMisGrid ID="wg_RoleManage" runat="server" CheckControlID="chb_RowCheck" SkinID="Long"
                        OnBeforeDataBind="wg_RoleManage_BeforeDataBind" OnItemCommand="wg_RoleManage_ItemCommand"
                        OnBeforePageIndexChanged="wg_RoleManage_BeforePageIndexChanged">
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn DataField="ID" Visible="false" UniqueName="ID">
                                </telerik:GridBoundColumn>
                                <%--<telerik:GridButtonColumn ButtonType="ImageButton" CommandName="RoleName" ImageUrl="../../Img/GridEdit.png">
                                            </telerik:GridButtonColumn>--%>
                                <telerik:GridTemplateColumn UniqueName="UpdateCourse" HeaderText="编辑">
                                    <ItemTemplate>
                                        <img alt="编辑角色" src="../../Img/GridEdit.png" onclick="OnClientUpdateCommand('<%# Eval("RoleName") %>')" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="40px"></HeaderStyle>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="CheckFlag" DataField="CheckFlag">
                                    <HeaderTemplate>
                                        <cp:CPMisCheckBox ID="chb_HeadCheck" AutoPostBack="true" runat="server" OnCheckedChanged="chb_HeadCheck_CheckedChanged" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <cp:CPMisCheckBox ID="chb_RowCheck" runat="server" Checked='<% #Eval("CheckFlag") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle Width="30px"></HeaderStyle>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="RoleName" UniqueName="RoleName" HeaderText="角色名称">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn UniqueName="RoleFunction" HeaderText="角色功能">
                                    <ItemTemplate>
                                        <cp:CPMisLinkButton ID="lnk_LookRoleFunction" CommandName="RoleFunction" Text="查看"
                                            runat="server"></cp:CPMisLinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="RoleUser" HeaderText="角色用户">
                                    <ItemTemplate>
                                        <cp:CPMisLinkButton ID="lnk_LookRoleUser" CommandName="RoleUser" Text="查看" runat="server"></cp:CPMisLinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </cp:CPMisGrid>
                </cp:CPMisPageView>
            </cp:CPMisMultiPage>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
                <Windows>
                    <telerik:RadWindow ID="wdw_RoleManage" runat="server" Top="150" Left="200">
                    </telerik:RadWindow>
                </Windows>
            </telerik:RadWindowManager>
        </div>
    </form>

</body>
</html>
