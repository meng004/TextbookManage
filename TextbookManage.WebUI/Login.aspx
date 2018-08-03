<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CPMis.WebPage.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
 
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"/>  
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="bt_Login">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="bt_Login" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div class="container" style="height:100%; background-image: url(../Images/uscbackgroud.jpg); background-repeat: no-repeat;">
        <div class="row" style="height:100px"></div>
        <div class="row" >
            <div id="logPanel" class="span6  login form-horizontal  offset3" >
                <h2 class="offset1">南华大学教务管理系统 <small>欢迎您  </small>
                </h2>
                <hr />
<%--                <div class="control-group">
                    <label class="control-label" for="txt_UserName">用户名：</label>
                    <div class="controls">
                        <cp:CPMisTextBox ID="txt_UserName" runat="server" DisplayText=""
                            IsCancelDataBind="False" LabelWidth="64px" type="text" value="" Width="160px" />             
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="txt_Password">
                        密  码：
                    </label>
                    <div class="controls">
                        <cp:CPMisTextBox ID="txt_Password" runat="server" TextMode="Password" />
                    </div>
                </div>               
                <div class="control-group">
                    <div class="controls">
                         <cp:CPMisButton ID="bt_Login" runat="server"  ButtonType="LinkButton" Text="登录教务系统" Icon-PrimaryIconUrl="~\images\application_go.png" OnClick="bt_Login_Click" />
                    </div>
                </div>--%>
                <asp:Login ID="LoginCPMis" runat="server" DestinationPageUrl="~/Main.aspx"
                           OnLoggedIn="LoginCPMis_OnLoggedIn" OnLoginError="LoginCPMis_OnLoginError"
                           CssClass="noborder" >
                </asp:Login>
                <hr />
                <p>
                    版权所有：南华大学教务处 地址：湖南省衡阳市常胜西路28号 邮编：421001
                </p>
            </div>
        </div>
    </div>

    </form>
</body>
</html>
