<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="USCTAMisLogin.aspx.cs"
Inherits="USCTAMis.WebPage.USCTAMisLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
        <title>南华大学教务系统_用户登录</title>
        <style type="text/css">
      
            html,body,form
            {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            background-image: url(Img/Login_Images/login_01.gif);
            overflow: hidden;
            vertical-align:middle;
            text-align:center;
            width:100%;
            height:100%;
            }
            .STYLE3
            {
            font-size: 12px;
            color: #FFFFFF;
            }
            .STYLE4
            {
            color: #FFFFFF;
            font-family: "方正大黑简体";
            font-size: 50px;
            }
        </style>
    </head>
    <body>
        <form id="form1" runat="server">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
            <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
            </telerik:RadStyleSheetManager>
            <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
            </telerik:RadSkinManager>
            <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
  
            <table width="100%"  style="height:100%;" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="middle">
                        <table width="100%" style="height:100%; vertical-align:middle;"  border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td style="background-image: url(Img/Login_Images/login_03.gif);">
                                    &nbsp;
                                </td>
                                <td width="876">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="299" valign="top" style="background-image: url(Img/Login_Images/login_04.gif);">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="69">
                                                <asp:Login ID="Login" runat="server" BackColor="#2B589B" BorderColor="#3C64A2" BorderStyle="Double"
                                                           DestinationPageUrl="~/Main.aspx" OnLoggedIn="Login_LoggedIn"  OnLoginError="Login_LoginError"   style="padding:0px; margin:0px;  border-width:0px;">
                                                    <LayoutTemplate>
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="padding:0px; margin:0px; ">
                                                            <tr>
                                                                <td width="394" height="69" style="background-image: url(Img/Login_Images/login_06.gif);">
                                                                    &nbsp;
                                                                </td>
                                                                <td width="199" style="background-image: url(Img/Login_Images/login_07.gif);">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td style="width: 40px; height: 22px;">
                                                                                <utm:UTMisLabel ID="lbl_UserName" runat="server" Text="用户名" SkinID="AutoSize" >
                                                                                </utm:UTMisLabel>
                                                                            </td>
                                                                            <td style="width: 115px; height: 22px;">
                                                                                <utm:UTMisTextBox ID="UserName" TabIndex="1" runat="server" SkinID="AutoSize" Width="110px" 
                                                                                                  BackColor="#032e49" ForeColor="#ffffff">
                                                                                </utm:UTMisTextBox>
                                                                            </td>
                                                                            <td style="width: 45px; height: 55px" rowspan="2">
                                                                                <asp:ImageButton TabIndex="3" CommandName="Login" runat="server" ImageUrl="~/Img/Login_Images/btn_Login.png"
                                                                                                 ID="Img_Login" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 36px; height: 22px;">
                                                                                <utm:UTMisLabel ID="lbl_Password" runat="server" Text="密  码" SkinID="AutoSize">
                                                                                </utm:UTMisLabel>
                                                                            </td>
                                                                            <td style="width: 115px; height: 22px;">
                                                                                <utm:UTMisTextBox ID="Password" TabIndex="2" BackColor="#032e49" ForeColor="#ffffff"
                                                                                                  runat="server" SkinID="AutoSize" Width="110px" TextMode="Password" >
                                                                                </utm:UTMisTextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td width="283" style="background-image: url(Img/Login_Images/login_08.gif);">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </LayoutTemplate>
                                                </asp:Login>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="225" style="background-image: url(Img/Login_Images/login_09.png);">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="background-image: url(Img/Login_Images/login_03.gif);">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
   
        </form>
    </body>
</html>
