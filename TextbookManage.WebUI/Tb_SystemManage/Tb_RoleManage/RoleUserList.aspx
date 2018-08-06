<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleUserList.aspx.cs" Inherits="CPMis.WebPage.SystemManageUI.RoleManageUI.RoleUserList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>角色用户</title>
    <script language="javascript" type="text/javascript" src="../../JS/WebScript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadSkinManager ID="RadSkinManage1" runat="server"></telerik:RadSkinManager>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <script language="javascript" type="text/javascript">
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
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <ClientEvents OnRequestStart="onRequestStart" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="wg_RoleUserList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="wg_RoleUserList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="wg_RoleUserList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
    <div id="main">
        <%--ToolBar--%>
        <cp:CPMisToolBar ID="tb_RoleUserList" OnClientButtonClicking="OnToolBarButtonClicked"
             runat="Server">
            <Items>
                <telerik:RadToolBarButton Text="删 除" CommandName="Delete" ImageUrl="~/Img/tlb_Delete.png">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Text="帮 助" CommandName="Help" ImageUrl="~/Img/tlb_Help.png">
                </telerik:RadToolBarButton>
            </Items>
        </cp:CPMisToolBar>
        <%--TabStrip--%>
        <cp:CPMisTabStrip ID="tab_RoleUserList" runat="server" MultiPageID="mp_RoleUserList">
            <Tabs>
                <cp:CPMisTab Text="角色用户(F)" AccessKey="F">
                </cp:CPMisTab>
            </Tabs>
        </cp:CPMisTabStrip>
        <cp:CPMisMultiPage ID="mp_RoleUserList" runat="server" SelectedIndex="0">
            <cp:CPMisPageView ID="pv_RoleUserList" runat="server" Width="800px">
                <div style="padding:3px;">
                    <cp:CPMisLabel ID="lbl_CurrentRole" Text="您当前选择的角色为:" runat="server" SkinID="AutoSize" Font-Size="15px"></cp:CPMisLabel>
                    <cp:CPMisLabel ID="lbl_RoleName" runat="server" ForeColor="Red" SkinID="Paraset" Font-Size="15px"></cp:CPMisLabel>
                </div>
                <cp:CPMisGrid ID="wg_RoleUserList" runat="server" CheckControlID="chb_RowCheck"
                    SkinID="normal" OnBeforeDataBind="wg_RoleUserList_BeforeDataBind" 
                    OnBeforePageIndexChanged="wg_RoleUserList_BeforePageIndexChanged">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="SystemUserID" UniqueName="ID" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="UserID" UniqueName="UserID" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn DataField="CheckFlag" UniqueName="CheckFlag">
                                <HeaderTemplate>
                                    <cp:CPMisCheckBox ID="chb_HeadCheck" OnCheckedChanged="chb_HeadCheck_CheckedChanged"
                                        AutoPostBack="true" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <cp:CPMisCheckBox ID="chb_RowCheck" Checked='<%#Eval("CheckFlag") %>' runat="server" />
                                </ItemTemplate>
                                <HeaderStyle Width="30px" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="UserTruelyName" UniqueName="Name" HeaderText="姓 名">
                                <HeaderStyle Width="120px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Sex" UniqueName="Sex" HeaderText="性 别">
                                <HeaderStyle Width="50px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="StaffNum" UniqueName="StaffNum" HeaderText="用户编号"
                                HeaderStyle-Width="70px">
                            </telerik:GridBoundColumn>
                            <%--<telerik:GridBoundColumn DataField="Post" UniqueName="Post" HeaderText="职务名称"
                                HeaderStyle-Width="70px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="InstitutionName" UniqueName="InstitutionName" HeaderText="所在机构"
                                HeaderStyle-Width="100px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CommunityName" UniqueName="CommunityName" HeaderText="所在社区"
                                HeaderStyle-Width="100px">
                            </telerik:GridBoundColumn>--%>
                            <telerik:GridBoundColumn DataField="UserLevelName" UniqueName="UserLevelName" HeaderText="用户级别">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </cp:CPMisGrid>
            </cp:CPMisPageView>
        </cp:CPMisMultiPage>
    </div>
    </form>
</body>
</html>
