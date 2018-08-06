<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserFunctionList.aspx.cs"
    Inherits="CPMis.WebPage.SystemManageUI.UserManageUI.TeacherUserFunctionList" %>

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
                    <telerik:AjaxUpdatedControl ControlID="wg_UserFunction" />
                </UpdatedControls>
            </telerik:AjaxSetting>
             <telerik:AjaxSetting AjaxControlID="wg_UserFunction">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="wg_UserFunction" LoadingPanelID="RadAjaxLoadingPanel1"/>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
    <div id="main"><%--OnButtonClick="tb_UserFunction_ButtonClicked"--%>
        <cp:CPMisToolBar ID="tb_UserFunction" runat="server" OnClientButtonClicking="OnToolBarButtonClicked">
            <Items>
                <telerik:RadToolBarButton Text="帮 助" CommandName="Help" ImageUrl="~/Img/tlb_Help.png">
                </telerik:RadToolBarButton>
            </Items>
        </cp:CPMisToolBar>
        <cp:CPMisTabStrip ID="tab_UserFunction" runat="server" MultiPageID="mp_UserFunction">
            <Tabs>
                <cp:CPMisTab Text="功能管理(F)" AccessKey="F">
                </cp:CPMisTab>
            </Tabs>
        </cp:CPMisTabStrip>
        <cp:CPMisMultiPage ID="mp_UserFunction" runat="server">
            <cp:CPMisPageView ID="pv_UserFunction" runat="server">
                <div style="padding:3px;">
                    <cp:CPMisLabel ID="lbl_brif" runat="server" Text="用户 " SkinID="AutoSize" Font-Size="15px"></cp:CPMisLabel>
                    <cp:CPMisLabel ID="lbl_UserName" runat="server" ForeColor="Red" SkinID="Paraset"
                        Font-Size="15px"></cp:CPMisLabel>
                    <cp:CPMisLabel ID="lbl_text" runat="server" Text="所具有的功能如下：" SkinID="AutoSize" Font-Size="15px">
                    </cp:CPMisLabel>
                </div>
                <cp:CPMisGrid ID="wg_UserFunction" runat="server" OnBeforeDataBind="wg_UserFunction_BeforeDataBind"
                    SkinID="normal">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="FunctionID" UniqueName="FunctionID" HeaderText="功能编号"
                                HeaderStyle-Width="65px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FunctionName" UniqueName="FunctionName" HeaderText="功能名称"
                                HeaderStyle-Width="140px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FunctionURL" UniqueName="FunctionURL" HeaderText="功能页面路径">
                            </telerik:GridBoundColumn>
                            <%--<telerik:GridBoundColumn DataField="IsShow" UniqueName="IsShow" HeaderText="是否显示"
                            HeaderStyle-Width="75px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="页面权值" DataField="PageWeight" UniqueName="PageWeight">
                                <HeaderStyle Width="63px" />
                            </telerik:GridBoundColumn>--%>
                        </Columns>
                    </MasterTableView>
                </cp:CPMisGrid>
            </cp:CPMisPageView>
        </cp:CPMisMultiPage>
    </div>
    </form>
</body>
</html>
