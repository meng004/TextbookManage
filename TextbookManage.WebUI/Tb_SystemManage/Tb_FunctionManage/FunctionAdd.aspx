<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FunctionAdd.aspx.cs" 
Inherits="CPMis.WebPage.SystemManageUI.FunctionManageUI.FunctionAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>功能</title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
    <script  language="javascript" type="text/javascript" >
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
            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

                return oWindow;
            }
            function OnButtonClick(arg) {
                var a = confirm(arg);
                return a;
            }
            function CancelEdit() {
                GetRadWindow().close();
            }
        </script>
        <telerik:RadFormDecorator ID="formdecorator" runat="server"  DecoratedControls="All" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server"></telerik:RadAjaxManager>
    <div class="pop" >
                <ul>
                    <li style="width:350px;">
                        <cp:CPMisLabel ID="lbl_FunctionID" runat="server" Text="功能编号：" />
                        <cp:CPMisTextBox ID="txt_FunctionID" runat="server" SkinID="AutoSize" Width="260px"/>
                    </li>
                    <li style="width:350px;">
                        <cp:CPMisLabel ID="lbl_FunctionName" runat="server" Text="功能名称：" />
                        <cp:CPMisTextBox ID="txt_FunctionName" runat="server" SkinID="AutoSize" Width="260px" />
                    </li>
                    <li style="width:350px;">
                        <cp:CPMisLabel ID="lbl_FunctionURL" runat="server" Text="功能路径：" />
                        <cp:CPMisTextBox ID="txt_FunctionURL" runat="server"  SkinID="AutoSize" Width="260px" />
                    </li>
                    <%--<li style="width:350px;">
                        <cp:CPMisLabel ID="CPMisLabel1" runat="server" Text="是否显示：" />
                        <cpbc:YesOrNoDropDownList ID="ddl_IsShow" runat="server">
                        </cpbc:YesOrNoDropDownList>
                    </li>
                    <li style="width:350px;">
                        <cp:CPMisLabel ID="CPMisLabel2" runat="server" Text="页面权值：" />
                        <cp:CPMisTextBox ID="txt_PageWeight" runat="server"></cp:CPMisTextBox>
                    </li>--%>
                    <li style="width:350px;">
                        <cp:CPMisButton ID="btn_Add" runat="server" OnBeforeClick="btn_Add_BeforeClick" Text="添 加"
                          OnClientClick="return OnButtonClick('确认添加?')" OnAfterClick="btn_Add_AfterClick"/>
                          <cp:CPMisButton ID="btn_Save" runat="server" OnBeforeClick="btn_Save_BeforeClick" Text="保 存"
                          OnClientClick="return OnButtonClick('确认保存?')" OnAfterClick="btn_Save_AfterClick"/>
                        <cp:CPMisButton ID="btn_Close" runat="server" Text="关 闭" OnClientClick="return CloseAndRebind()" />
                    </li>
                </ul>
                </div>
    </form>
</body>
</html>
