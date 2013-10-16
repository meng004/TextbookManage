<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="USCTAMis.WebPage.Navigation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <script language="javascript" type="text/javascript">
            function btnAlert() {

                //    parent.window.location.href='../Home.aspx'; 
                top.window.location.href = '../Home.aspx';
            }
        </script>
    </head>
    <body>
        <%-- style="width: 205x;"--%>
        <form id="leftform" runat="server">
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
            <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
            </telerik:RadSkinManager>
            <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
            <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
            </telerik:RadStyleSheetManager>
            <div style="width: 205px; float: left; padding-left: 5px;">
                <table>
                    <tr>
                        <td>
                            <div id="UserName">
                                <utm:UTMisLabel ID="lbl_UserName" runat="server" SkinID="Paraset" Style="text-align: left;
                                                width: 200px;" Text="载入中..." Font-Size="10pt" ForeColor="Red" Font-Bold="true"></utm:UTMisLabel>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="whole">
                                <a id="personal_info" href="Default.aspx" target="mainFrame" style="font-size:10pt">【个人信息管理】</a>
                                <asp:LinkButton ID="exit_button" runat="server" class="linkStyle" OnClick="exit_button_Click"
                                                Text="【退出】" Font-Size="10pt"></asp:LinkButton>
                                <hr />
                                <utm:UTMisTreeView ID="tv_Function" runat="server">
                                </utm:UTMisTreeView>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </form>
    </body>
</html>
