<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleAdd.aspx.cs" Inherits="CPMis.WebPage.SystemManageUI.RoleManageUI.RoleAdd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>角色</title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                //刷新父窗体，关闭自己
                function CloseAndRebind() {
                    GetRadWindow().BrowserWindow.refreshGrid();
                    GetRadWindow().close();
                    return false;
                }
                function AddAndRebind() {
                    GetRadWindow().BrowserWindow.refreshGrid();
                    return false;
                }
                function UpdateAndRebind() {
                    GetRadWindow().BrowserWindow.refreshGrid();
                    return false;
                }
                //获取父窗体RadWindow控制器
                function GetRadWindow() {
                    var oWindow = null;
                    if (window.radWindow)
                        oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                    else if (window.frameElement.radWindow)
                        oWindow = window.frameElement.radWindow; //IE (and Moz as well)
                    return oWindow;
                }

                function CancelEdit() {
                    GetRadWindow().close();
                }
            </script>
        </telerik:RadCodeBlock>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
        <div class="pop">
            <ul>
                <li style="width: 260px;">
                    <cp:CPMisLabel ID="lbl_FunctionName" runat="server" Text="角色名称："></cp:CPMisLabel>
                    <cp:CPMisTextBox ID="txt_RoleName" runat="server">
                    </cp:CPMisTextBox>
                </li>

                <li style="width: 260px;">
                    <cp:CPMisButton ID="btn_Add" runat="server" Text="添 加" OnAfterClick="btn_Add_AfterClick"
                        OnBeforeClick="btn_Add_BeforeClick" OnClientClick="return confirm('确认添加?')"></cp:CPMisButton>
                    <cp:CPMisButton ID="btn_Save" runat="server" Text="保 存" OnAfterClick="btn_Save_AfterClick"
                        OnBeforeClick="btn_Save_BeforeClick" OnClientClick="return confirm('确认保存?')"></cp:CPMisButton>
                    <cp:CPMisLabel ID="CPMisLabel1" Text="" Width="30px" runat="server"></cp:CPMisLabel>
                    <cp:CPMisButton ID="btn_Close" runat="server" Text="关 闭" OnClientClick="return CloseAndRebind()"></cp:CPMisButton>
                </li>
            </ul>
        </div>
    </form>
</body>
</html>
