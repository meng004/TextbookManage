<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemUserUpdate.aspx.cs" Inherits="CPMis.WebPage.SystemManageUI.UserManageUI.TeacherUserUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>教师用户信息</title>
</head>
<body>
    <form id="form1" runat="server">
     
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
    </telerik:RadSkinManager>
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

            function CancelEdit() {
                GetRadWindow().close();
            }
        </script>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txt_Name" />
                    <telerik:AjaxUpdatedControl ControlID="txt_Institution" />
                    <telerik:AjaxUpdatedControl ControlID="txt_Sex" />
                    <telerik:AjaxUpdatedControl ControlID="txt_UserName" />
                    <telerik:AjaxUpdatedControl ControlID="txt_Password" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
      <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
    <div class="pop" style="margin-right:20px">
             
                <table style="margin-left:20px;">
                <tr>
                <td>
                 <cp:CPMisLabel ID="lbl_Name" Text="姓 名：" runat="server">
                    </cp:CPMisLabel>
                   
                </td>
                <td>
                 <cp:CPMisTextBox ID="txt_Name" runat="server"  Enabled="false" SkinID="tb160" >
                    </cp:CPMisTextBox>
                </td>
                <td>
                <cp:CPMisLabel ID="lbl_Sex" runat="server" Text="性 别：">
                    </cp:CPMisLabel> 
                    
                </td>
                <td>
                <cp:CPMisTextBox ID="txt_Sex" runat="server" SkinID="AutoSize" Width="86px" Enabled="false">
                    </cp:CPMisTextBox>
                </td>
                <td width="60px">
                <cp:CPMisLabel ID="lbl_School" runat="server" Text="所在学院（机构）：">
                    </cp:CPMisLabel>
                   
                </td>
                <td>
                 <cp:CPMisTextBox ID="txt_Institution" runat="server" SkinID="tb180"  Enabled="false">
                    </cp:CPMisTextBox>
                </td>
                </tr>
                <tr>
                <td>
                <cp:CPMisLabel ID="lbl_UserName" runat="server" Text="用户名："></cp:CPMisLabel>
                    
                </td>
                <td>
                <cp:CPMisTextBox ID="txt_UserName"  runat="server" SkinID="tb160">
                    </cp:CPMisTextBox>
                </td>
                <td >
                    <cp:CPMisLabel ID="lbl_Password" runat="server" Text="密 码："></cp:CPMisLabel>
                </td>
                <td  colspan="3" align="left">
                <cp:CPMisTextBox ID="txt_Password" runat="server" SkinID="AutoSize" Width="332px">
                    </cp:CPMisTextBox>
                    <%-- <asp:TextBox ID="txt_Password" runat="server" SkinID="AutoSize" Width="332px" TextMode="Password">
                    </asp:TextBox>--%>
                </td>
                </tr>
                <tr>
                <td>
                 <cp:CPMisLabel ID="lbl_UserLevel" runat="server" Text="用户级别："></cp:CPMisLabel>
                   
                </td>
                <td>
                 <cp:CPMisComboBox ID="ddl_UserLevel" runat="server" DataSourceID="sds_UserLevel"   
                  DataTextField="UserLevelName" DataValueField="UserLevelCode">
                    </cp:CPMisComboBox>
                <asp:SqlDataSource ID="sds_UserLevel" runat="server" ConnectionString="<%$ConnectionStrings:USCTAMisConnectionString %>"
                 ProviderName="System.Data.SqlClient" SelectCommandType="Text"
                  SelectCommand="SELECT UserLevelName,UserLevelCode From UserLevel" />
                </td>
                </tr>
                <tr>
                <td colspan="6">
                <div style="width: 100%; text-align: left; padding-left: 20px;">
                    <cp:CPMisLabel ID="lbl_Role" SkinID="AutoSize" runat="server" Text="用户角色列表："></cp:CPMisLabel><br />
                    <cp:CPMisCheckBoxList CssClass="cb" ID="cbl_Role" DataTextField="RoleName" DataValueField="RoleName"
                        runat="server" RepeatDirection="Horizontal" RepeatColumns="4" RepeatLayout="Table" DefaultIndex="-1" 
                        SplitString=',' SpecialValue="0" OnBeforeDataBind="cbl_Role_BeforeDataBind">
                    </cp:CPMisCheckBoxList>
                </div>
                </td>
                </tr>
                </table>
                <ul>
                <li>
                <cp:CPMisButton ID="btn_AddNews" runat="server" Text="添 加" OnBeforeClick="btn_AddNews_BeforeClick"
                        OnAfterClick="btn_AddNews_AfterClick" OnClientClick="return confirm('确认添加?')">
                    </cp:CPMisButton>
                    <cp:CPMisButton ID="btn_Save" runat="server" Text="保 存" Visible="false" OnAfterClick="btn_Save_AfterClick"
                        OnBeforeClick="btn_Save_BeforeClick" OnClientClick="return confirm('确认保存?')">
                    </cp:CPMisButton>
                    <cp:CPMisLabel ID="Lable1" runat="server" Text="" Width="30px"></cp:CPMisLabel>
                    <cp:CPMisButton ID="btn_Close" runat="server" Text="关 闭" OnClientClick="return CloseAndRebind()"></cp:CPMisButton>
                </li>
                </ul> 
    </div>
    </form>
</body>
</html>
