<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CPMis.WebPage.NewsList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>南华教务管理在线</title>
    </head>
    <body>
        <center>
            <form id="form1" runat="server">
                <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
                </telerik:RadSkinManager>
                <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                </telerik:RadScriptManager>
                <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
                <div id="main" style="width: 1024px; background-image: url(../Img/home_background.jpg); background-repeat: no-repeat;">
                    <div id="head" style=" font-size:15pt; width: 1024px; height: 160px;">
                        <div id="login" style="float:right; margin:95px 5px 0px 5px;">   
                            <table >
                                <tr>
                                    <td>
                                        <asp:LinkButton ID ="lnk_TableDown" runat ="server" Text ="表格下载" Font-Underline="True" 
                                                        Font-Size="Large" ForeColor="#D5D500" Font-Bold="True" OnClick="lnk_TableDown_Click"></asp:LinkButton> 
                                        <asp:LinkButton ID ="lnk_StudentList" runat ="server" Text ="学生名册" Font-Underline="True" 
                                                        Font-Size="Large" ForeColor="#D5D500" Font-Bold="True" OnClick="lnk_StudentList_Click"></asp:LinkButton> 
                                    </td>
                                    <td>                      
                                        <asp:ImageButton ID="btn_Login1" runat="server" OnClick="btn_Login_AfterClick" ImageUrl="~/Img/HomeLogButton.gif"/>  
                                    </td>
                                </tr>
                            </table>                                                                   
                        </div>           
                    </div> 
                    <table style="width:1024px;  height: 450px;  background-color:transparent;" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left" >
                                <table id="TableLeft"  style=" width:730px; height:450px; margin:0px; padding:0px; background-color:#e3f5ff;" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style=" width:15px; background-image: url(../Img/tab_topleft.gif); height:30px;">
                                        </td>   
                                        <td style=" width:700px; background-image: url(../Img/tab_headnews.gif); height:30px;">                                                                                                                                                                                                                                                                                                                                                                                                                               
                                            <table id="TableHeadNews" cellpadding="0" cellspacing="0">
                                                <tr>
           
                                                    <td>
                                                        <cp:CPMisLabel ID="keyword" runat="server" Text="关键字：" SkinID="AutoSize" Width="400px"></cp:CPMisLabel>
                                                    </td>
                                                    <td>
                                                        <cp:CPMisTextBox ID="txt_News" runat="server"></cp:CPMisTextBox>
                                                    </td>
                                                    <td>
                                                        <cp:CPMisButton ID="btn_Query" Text="搜索新闻" runat="server" OnAfterClick="btn_Query_AfterClick">
                                                        </cp:CPMisButton>
                                                    </td>
                                                    <td>
                                                        <cp:CPMisLinkButton ID="lb_MoreNews"  OnAfterClick="lb_MoreNews_AfterClick" runat="server" ToolTip="更多新闻" >
                                                            >>更多<%--<img  src="Img/More.gif"/ alt="更多新闻">--%>
                                                        </cp:CPMisLinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>    
                                        <td style=" width:13px;background-image: url(../Img/tab_topright.gif); height:30px;">                                    
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style=" width:15px; background-image: url(../Img/tab_left.gif);" align="left">
                                        </td>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
                                        <td >
                                            <cp:CPMisGrid ID="wg_News" runat="server" OnItemCommand="wg_News_ItemCommand" SkinID="News"
                                                           Width="695px" Height="403px" EnableHeaderContextFilterMenu="true">
                                                <FilterMenu>
                                                    <ItemTemplate>ds</ItemTemplate>
                                                </FilterMenu>
                                                <MasterTableView PageSize="12">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="NewsID" UniqueName="NewsID" Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn>
                                                            <HeaderStyle Width="25px"  HorizontalAlign="Center"/>
                                                            <ItemTemplate>
                                                                <img src="Img/NewsHot.gif" alt="热点新闻" />
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn DataField="NewsTitle" UniqueName="NewsTitle">
                                                            <ItemTemplate>
                                                                <cp:CPMisLinkButton ID="mlb_ScanNews" Text='<%# DataBinder.Eval(Container.DataItem,"NewsTitle") %>'
                                                                                     CommandName="ScanCommand" runat="server"></cp:CPMisLinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridBoundColumn DataField="NewsDepartment" UniqueName="NewsDepartment">
                                                            <HeaderStyle  Width="150px"/>
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="NewsReleaseDate" UniqueName="NewsReleaseDate">
                                                            <HeaderStyle  Width="135px"/>
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="NewsTypeName" UniqueName="NewsTypeName">
                                                            <HeaderStyle  Width="70px"/>
                                                        </telerik:GridBoundColumn>
                                                    </Columns>
                                                </MasterTableView>
                                            </cp:CPMisGrid>
                                        </td>
                                        <td style=" width:13px;   background-image: url(../Img/tab_right.gif); " align="right">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style=" width:15px;  background-image: url(../Img/tab_bottomleft.gif); height:15px;">
                                        </td>
                                        <td style=" background-image: url(../Img/tab_bottom.gif); height:15px;">
                                        </td>
                                        <td style=" width:13px; background-image: url(../Img/tab_bottomright.gif); height:15px;">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="right" >
                                <table id="TableRight"  style="width:290px;  height:450px; margin:0px; padding:0px;" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td valign="top">
                                            <table id="TableNotice" style="width:290px; margin:0px; padding:0px;" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style=" width:10px; background-image: url(../Img/tab_topleft.gif); height:30px">
                                                    </td>
                                                    <td style=" width:260px; background-image: url(../Img/tab_headnotice.gif); height:30px; text-align:right;" >
                                                        <cp:CPMisLinkButton ID="lb_MoreTeachingNews"
                                                                             OnAfterClick="lb_MoreTeachingNews_AfterClick" runat="server"  ToolTip="更多新闻" >
                                                            <%-->>更多--%><img  src="Img/More.gif" alt="更多新闻"/>
                                                        </cp:CPMisLinkButton>
                                                    </td>
                                                    <td style=" width:15px; background-image: url(../Img/tab_topright.gif); height:30px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:15px; background-image: url(../Img/tab_left.gif);" >
                                                    </td>
                                                    <td style=" width:220px; background-color:#eff7fe">
                                                        <marquee direction="up" onmouseover="stop()" vspace="10" hspace="10"  onmouseout="start()" scrollamount= "3" align="left" height="155px"
                                                                 width="250" loop="-1" behavior="SCROLL"   style="margin:0px; padding:0px;" >
                                                            <div id="Teaching" runat="server" >
                                                            </div>
                                                        </marquee> 
                                                    </td>
                                                    <td style=" width:10px; background-image: url(../Img/tab_right.gif);">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:15px; background-image: url(../Img/tab_bottomleft.gif); height:15px;">
                                                    </td>
                                                    <td style=" width:260px;  background-image: url(../Img/tab_bottom.gif);height:15px;">
                                                    </td>
                                                    <td style="width:13px; background-image: url(../Img/tab_bottomright.gif);height:15px;">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="bottom">
                                            <table id="TableClendar" cellpadding="0" cellspacing="0" style="background-color:#eff7fe">
                                                <tr>
                                                    <td style=" width:15px; background-image: url(../Img/tab_topleft.gif); height:30px">
                                                    </td>
                                                    <td style=" width:260px; background-image: url(../Img/tab_headcalendar.gif); height:30px" >
                                                    </td>
                                                    <td style=" width:13px; background-image: url(../Img/tab_topright.gif); height:30px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:15px; background-image: url(../Img/tab_left.gif);" >
                                                    </td>
                                                    <td></td>
                                                   <%-- <td style=" width:260px;" >
                                                        <ucc:Calendar ID="Calendar1" runat="server" ></ucc:Calendar>
                                                    </td>--%>
                                                    <td style=" width:13px; background-image: url(../Img/tab_right.gif);">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:15px; background-image: url(../Img/tab_bottomleft.gif); height:15px;">
                                                    </td>
                                                    <td style=" width:260px;  background-image: url(../Img/tab_bottom.gif);height:15px;">
                                                    </td>
                                                    <td style="width:13px; background-image: url(../Img/tab_bottomright.gif);height:15px;">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <div id="footer" style=" text-align:center; font-size:9pt; color:Gray; clear:both; background-color:#d8e5f4">   
                        友情链接：&nbsp;&nbsp;
                        <a>
                            精品课程&nbsp;&nbsp;
                        </a>
                        <a>
                            南华首页&nbsp;&nbsp;
                        </a>
                        <a>
                            图书馆&nbsp;&nbsp;
                        </a>
                        <a>教务处网站</a>
                        <br />
                        <div style="text-align:center; font-size:7pt; ">
                            <pre>
                                南华大学教务处 湖南衡阳常胜西路28号  邮编：421001
                            </pre>
                        </div>
                    </div> 
                </div>
            </form>
        </center>
    </body>
</html>