<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="USCTAMis.WebPage.Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
            <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
            </telerik:RadSkinManager>
            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                <script language="javascript" type="text/javascript">
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
            </telerik:RadCodeBlock>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline">
                <ClientEvents OnRequestStart="onRequestStart" />
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="wg_News" />
                            <telerik:AjaxUpdatedControl ControlID="wd_MailList" />
                            <telerik:AjaxUpdatedControl ControlID="txt_OldPass" />
                            <telerik:AjaxUpdatedControl ControlID="txt_NewPass" />
                            <telerik:AjaxUpdatedControl ControlID="txt_CheckPass" />
                            <telerik:AjaxUpdatedControl ControlID="txt_OldName" />
                            <telerik:AjaxUpdatedControl ControlID="txt_NewName" />
                            <telerik:AjaxUpdatedControl ControlID="btn_Cancel" />
                            <telerik:AjaxUpdatedControl ControlID="btn_SavePass" />
                            <telerik:AjaxUpdatedControl ControlID="btn_SaveName" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="btn_Cancel">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="txt_OldPass" />
                            <telerik:AjaxUpdatedControl ControlID="txt_NewPass" />
                            <telerik:AjaxUpdatedControl ControlID="txt_CheckPass" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="wg_News">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="wg_News" LoadingPanelID="RadAjaxLoadingPanel1" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="wd_MailList">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="wd_MailList" LoadingPanelID="RadAjaxLoadingPanel1" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>
            <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" AutoTooltipify="true">
            </telerik:RadToolTipManager>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
            </telerik:RadAjaxLoadingPanel>
            <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
            <div>
                <utm:UTMisTabStrip ID="tab_News" runat="server" MultiPageID="mtp_News">
                    <Tabs>
                        <utm:UTMisTab Text="收信箱(D)" AccessKey="D" />
                        <utm:UTMisTab Text="部门要闻(A)" AccessKey="A" />
                        <utm:UTMisTab Text="个人信息(E)" AccessKey="E" />
                    </Tabs>
                </utm:UTMisTabStrip>
                <utm:UTMisMultiPage ID="mtp_News" runat="server">
                    <utm:UTMisPageView ID="mtv_MailBox" runat="server">
                        <utm:UTMisGrid ID="wd_MailList" runat="server" OnItemCommand="wd_MailList_ItemCommand"
                                       OnBeforeDataBind="wd_MailList_BeforeDataBind">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridTemplateColumn  HeaderStyle-Width="25px">
                                        <ItemTemplate>
                                            <img src="Img/Openmail.png" alt="Email" />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>                         
                                    <telerik:GridTemplateColumn DataField="EmailTitle" UniqueName="EmailTitle" HeaderText="邮件主题">
                                        <ItemTemplate>
                                            <utm:UTMisLinkButton ID="mlb_ScanNews" Text='<%# DataBinder.Eval(Container.DataItem,"EmailTitle") %>'
                                                                 CommandName="ViewEmail" runat="server"></utm:UTMisLinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="EmailSenderName" UniqueName="EmailSenderName"
                                                             HeaderText="发件人" HeaderStyle-Width="100px" />
                                    <telerik:GridBoundColumn DataField="EmailSendDate" UniqueName="EmailSendDate" HeaderText="发件日期"
                                                             HeaderStyle-Width="135px" />
                                    <telerik:GridBoundColumn DataField="EmailSendDepartment" UniqueName="EmailSendDepartment"
                                                             HeaderText="发件部门" HeaderStyle-Width="120px" />
                                    <telerik:GridBoundColumn DataField="EmailID" UniqueName="EmailID" Visible="false" />
                                    <telerik:GridBoundColumn DataField="EmailReveivedTag" UniqueName="EmailReveivedTag"
                                                             Visible="false" />
                                </Columns>
                            </MasterTableView>
                        </utm:UTMisGrid>
                    </utm:UTMisPageView>
                    <utm:UTMisPageView ID="mtv_News" runat="server">
                        <utm:UTMisGrid ID="wg_News" runat="server" OnItemCommand="wg_News_ItemCommand" OnBeforeDataBind="wg_News_BeforeDataBind">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="NewsID" UniqueName="NewsID" Visible="false">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn>
                                        <HeaderStyle Width="25px" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <img src="Img/NewsHot.gif" alt="热点新闻" />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="NewsTitle" UniqueName="NewsTitle" HeaderText="标题">
                                        <ItemTemplate>
                                            <utm:UTMisLinkButton ID="mlb_ScanNews" Text='<%# DataBinder.Eval(Container.DataItem,"NewsTitle") %>'
                                                                 CommandName="ViewNews" runat="server"></utm:UTMisLinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="NewsReleaseDepartmentName" UniqueName="NewsReleaseDepartmentName"
                                                             HeaderText="部门" HeaderStyle-Width="200px" />
                                    <telerik:GridBoundColumn DataField="NewsReleaseDate" UniqueName="NewsReleaseDate"
                                                             HeaderText="发布日期" HeaderStyle-Width="135px" />
                                    <telerik:GridBoundColumn DataField="NewsTypeName" UniqueName="NewsTypeName" HeaderText="类型"
                                                             HeaderStyle-Width="80px" />
                                </Columns>
                            </MasterTableView>
                        </utm:UTMisGrid>
                    </utm:UTMisPageView>
                    <utm:UTMisPageView ID="upv_PersonelInfo" runat="server">
                        <div>
                            <asp:Panel ID="pnl_PassEdit" runat="server">
                                <center>
                                    <div style="padding-top: 20px; padding-bottom: 40px;">
                                        <fieldset style="width: 400px;">
                                            <legend>修改密码</legend>
                                            <center>
                                                <table style="width: 320px; text-align: left;">
                                                    <tr>
                                                        <td>
                                                            <utm:UTMisLabel ID="lbl_OldPass" runat="server" Text="原密码:"></utm:UTMisLabel>
                                                        </td>
                                                        <td>
                                                            <utm:UTMisTextBox ID="txt_OldPass" runat="server" SkinID="tb160" Width="200px" TextMode="Password">
                                                            </utm:UTMisTextBox>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <utm:UTMisLabel ID="lbl_NewPass" runat="server" Text="新密码:"></utm:UTMisLabel>
                                                        </td>
                                                        <td>
                                                            <utm:UTMisTextBox ID="txt_NewPass" runat="server" SkinID="tb160" Width="200px" TextMode="Password">
                                                            </utm:UTMisTextBox>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <utm:UTMisLabel ID="lbl_CheckPass" runat="server" Text="确定密码:"></utm:UTMisLabel>
                                                        </td>
                                                        <td>
                                                            <utm:UTMisTextBox ID="txt_CheckPass" runat="server" SkinID="tb160" Width="200px"
                                                                              TextMode="Password">
                                                            </utm:UTMisTextBox>
                                                        </td>
                                                        <td>
                                                            <asp:CompareValidator ID="cpv_True" runat="server" ErrorMessage="*两次输入的密码不一样!" ControlToCompare="txt_NewPass"
                                                                                  ControlToValidate="txt_CheckPass" SetFocusOnError="true" Display="Dynamic">
                                                            </asp:CompareValidator>
                                           
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" align="center">
                                                            <utm:UTMisButton ID="btn_SavePass" runat="server" Text="修 改" OnClick="btn_SavePass_Click" />
                                                            <asp:Label ID="id" runat="server" Text="" Width="30px"></asp:Label>
                                                            <utm:UTMisButton ID="btn_Cancel" runat="server" Text="取 消" CausesValidation="False"
                                                                             OnClick="btn_Cancel_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </center>
                                        </fieldset>
                                        <table>
                                        </table>
                                    </div>
                                </center>
                            </asp:Panel>
                        </div>
                        <div>
                            <asp:Panel ID="pnl_UserNameEdit" runat="server">
                                <center>
                                    <fieldset style="width: 400px;">
                                        <legend>用户名修改</legend>
                                        <center>
                                            <table style="width: 320px; text-align: left;">
                                                <tr>
                                                    <td>
                                                        <utm:UTMisLabel ID="lbl_OldName" runat="server" Text="现用户名:"></utm:UTMisLabel>
                                                    </td>
                                                    <td>
                                                        <utm:UTMisTextBox ID="txt_OldName" runat="server" SkinID="tb160" Width="200px">
                                                        </utm:UTMisTextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <utm:UTMisLabel ID="lbl_NewName" runat="server" Text="新用户名:"></utm:UTMisLabel>
                                                    </td>
                                                    <td>
                                                        <utm:UTMisTextBox ID="txt_NewName" runat="server" SkinID="tb160">
                                                        </utm:UTMisTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" align="center">
                                                        <utm:UTMisButton ID="btn_SaveName" runat="server" Text="修 改" CausesValidation="False"
                                                                         OnClick="btn_SaveName_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </center>
                                    </fieldset>
                                </center>
                            </asp:Panel>
                        </div>
                    </utm:UTMisPageView>
                </utm:UTMisMultiPage>
            </div>
        </form>
    </body>
</html>
