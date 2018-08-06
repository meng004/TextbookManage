<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FunctionManage.aspx.cs"
    Inherits="CPMis.WebPage.SystemMangageUI.FunctionManageUI.FunctionManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>功能管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
    </telerik:RadSkinManager>
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
            function OnToolBarButtonClicked(sender, args) {
                var button = args.get_item();
                var command = button.get_commandName();
                var a = true;
                if (command == "Add") {
                    var oWnd = $find("<%=wdw_FunctionManage.ClientID%>");
                    oWnd.setUrl("FunctionAdd.aspx?IsUpdate=" + "false" + "&ID=" + ""); //
                    oWnd.show();
                    oWnd.setSize(410, 190);
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
                else {
                    refreshGrid(command);
                }
            }
            function OnClientUpdateCommand(id) {
                var oWnd = $find("<%=wdw_FunctionManage.ClientID%>");
                oWnd.setUrl("FunctionAdd.aspx?IsUpdate=" + "true" + "&ID=" + id); //
                oWnd.show();
                oWnd.setSize(400, 180);
            }
            //异步回调,刷新grid
            function refreshGrid(arg) {
                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(arg);
            }
        </script>

    </telerik:RadCodeBlock>
    <div>
        <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
            <ClientEvents OnRequestStart="onRequestStart" />
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="wg_RootFunction" />
                        <telerik:AjaxUpdatedControl ControlID="wg_FunctionManage" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="wg_RootFunction">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="wg_RootFunction" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="wg_FunctionManage">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="wg_FunctionManage"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="wg_RootFunction">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="wg_FunctionManage"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" AutoTooltipify="true">
        </telerik:RadToolTipManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
        <cp:CPMisToolBar runat="server" ID="tb_FunctionManage" Width="100%"
            OnClientButtonClicking="OnToolBarButtonClicked" SkinID="Long">
            <Items>
                <telerik:RadToolBarButton Text="添加功能" CommandName="Add" ToolTip="点击弹出Window添加功能"
                    ImageUrl="../../Img/tlb_Add.png">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Text="删除功能" CommandName="Delete" ToolTip="在功能列表中选择功能，点击删除功能"
                    ImageUrl="../../Img/tlb_Delete.png">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Text="帮 助" CommandName="Help" ToolTip="点击获取帮助" ImageUrl="../../Img/tlb_Help.png">
                </telerik:RadToolBarButton>
            </Items>
        </cp:CPMisToolBar>
        <cp:CPMisTabStrip ID="tab_FunctionManage" runat="server" MultiPageID="mtp_FunctionManage"
            SkinID="Long">
            <Tabs>
                <cp:CPMisTab AccessKey="F" Text="功能管理(F)">
                </cp:CPMisTab>
            </Tabs>
        </cp:CPMisTabStrip>
        <cp:CPMisMultiPage ID="mtp_FunctionManage" runat="server" SkinID="Long">
            <cp:CPMisPageView ID="pv_FunctionManage" runat="server" Height="505px">
                <div style="float: left">
                    <cp:CPMisGrid ID="wg_RootFunction" runat="server" SkinID="AutoPages" Width="215px"
                        Height="500px" OnBeforeDataBind="wg_RootFunction_BeforeDataBind" OnAfterDataBind="wg_RootFunction_AfterDataBind"
                        OnItemCommand="wg_RootFunction_ItemCommand">
                        <MasterTableView Width="100%" PageSize="18">
                            <PagerStyle Mode="NumericPages" PagerTextFormat="{4}第{0}页 共{1}页" PageButtonCount="4" />
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="功能编号" DataField="FunctionID" UniqueName="FunctionID">
                                    <HeaderStyle Width="63px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn UniqueName="LinkButtonTemplateColumn" DataField="FunctionName">
                                    <HeaderTemplate>
                                        <cp:CPMisLabel ID="headerlbl" Text="功能名称" runat="server"></cp:CPMisLabel>
                                    </HeaderTemplate>
                                    <HeaderStyle Width="120px" />
                                    <ItemTemplate>
                                        <cp:CPMisLinkButton ID="lnk_OpenLeafFunction" CommandName="OpenLeafFunction" Text='<%# DataBinder.Eval(Container.DataItem,"FunctionName") %>'
                                            runat="server" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </cp:CPMisGrid>
                </div>
                <div style="float: right">
                    <cp:CPMisGrid ID="wg_FunctionManage" runat="server" Width="775px" Height="500px"
                        CheckControlID="chb_RowCheck" OnBeforeDataBind="wg_FunctionManage_BeforeDataBind"
                        OnItemCommand="wg_FunctionManage_ItemCommand" SkinID="NoPaging"
                        >
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn UniqueName="ID" DataField="ID" Visible="false">
                                    <HeaderStyle Width="0px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn UniqueName="UpdateCourse" HeaderText="编辑">
                                    <ItemTemplate>
                                        <img alt="编辑" src="../../Img/GridEdit.png" onclick="OnClientUpdateCommand('<%# Eval("ID") %>')" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="39px"></HeaderStyle>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn">
                                    <HeaderStyle Width="30px" />
                                    <HeaderTemplate>
                                        <cp:CPMisCheckBox ID="chb_HeadCheck" AutoPostBack="True" runat="server" OnCheckedChanged="chb_HeadCheck_CheckedChanged">
                                        </cp:CPMisCheckBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <cp:CPMisCheckBox ID="chb_RowCheck" OnCheckedChanged="chb_RowCheck_CheckedChanged"
                                            AutoPostBack="true" Checked='<% #Eval("CheckFlag") %>' runat="server" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn HeaderText="功能编号" UniqueName="FunctionID" DataField="FunctionID">
                                    <HeaderStyle Width="85px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="功能名称" UniqueName="FunctionName" DataField="FunctionName">
                                    <HeaderStyle Width="125px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="功能页面路径" DataField="FunctionUrl" UniqueName="FunctionUrl">
                                    <HeaderStyle Width="270px" />
                                </telerik:GridBoundColumn>
                                <%--<telerik:GridBoundColumn HeaderText="是否显示" DataField="IsShow" UniqueName="IsShow">
                                    <HeaderStyle Width="63px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="页面权值" DataField="PageWeight" UniqueName="PageWeight">
                                    <HeaderStyle Width="63px" />
                                </telerik:GridBoundColumn>--%>
                                <telerik:GridTemplateColumn HeaderText="功能角色" UniqueName="FunctionRole">
                                    <HeaderStyle Width="63px" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnk_LookFunctionRole" CommandName="LookRole" Text="查看" runat="server"></asp:LinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                               <%-- <telerik:GridTemplateColumn HeaderText="功能用户" UniqueName="FunctionUser">
                                    <HeaderStyle Width="63px" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnk_LookFunctionUser" CommandName="LookUser" Text="查看" runat="server"></asp:LinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>--%>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings>
                        <Scrolling ScrollHeight="444px" />
                        </ClientSettings>
                    </cp:CPMisGrid>
                </div>
            </cp:CPMisPageView>
        </cp:CPMisMultiPage>
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
            <Windows>
                <telerik:RadWindow ID="wdw_FunctionManage" runat="server" Top="150" Left="200">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </div>
    </form>
</body>
</html>
