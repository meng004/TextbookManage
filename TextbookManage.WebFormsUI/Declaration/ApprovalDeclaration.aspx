<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApprovalDeclaration.aspx.cs" Inherits="TextbookManage.WebUI.Declaration.ApprovalDeclaration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>审核用书申报</title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
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
                //教材详单弹窗
                function OnRequestTextbook(TextbookId) {
                    var oWnd = $find("<%=wdw_TextbookDetailMessage.ClientID%>");
                    oWnd.setUrl(encodeURI("../WindowForMessage/TextbookDetailMessage.aspx?TextbookID=" + TextbookId)); //
                    oWnd.show();
                    oWnd.setSize(400, 400);
                }
                //教学班详情弹窗
                function OnRequestTeachingClass(TeachingClassNum) {
                    var oWnd = $find("<%=wdw_TextbookDetailMessage.ClientID%>");
                    oWnd.setUrl(encodeURI("../WindowForMessage/TeachingClassDetail.aspx?TeachingClassNum=" + TeachingClassNum)); //
                    oWnd.show();
                    oWnd.setSize(400, 290);
                }
            </script>
        </telerik:RadCodeBlock>
        <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1" UpdatePanelsRenderMode="Inline" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
            <ClientEvents OnRequestStart="onRequestStart" />
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ccmbSchool"></telerik:AjaxUpdatedControl>
                        <telerik:AjaxUpdatedControl ControlID="cgrdDeclaration" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbSchool">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdDeclaration" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cgrdDeclaration">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdDeclaration" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>

        <telerik:RadToolBar ID="CPMisToolBar1" runat="server" SkinID="Long">
            <Items>
                <telerik:RadToolBarButton runat="server" CommandName="help" Text="帮助" ImageUrl="~\Img\tlb_Help.png">
                </telerik:RadToolBarButton>
            </Items>
        </telerik:RadToolBar>

        <telerik:RadTabStrip ID="CPMisTabStrip1" runat="server" MultiPageID="mp_Approval">
            <Tabs>
                <telerik:RadTab runat="server" Text="审核用书申报" PageViewID="pv_Approval" Selected="true">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>

        <telerik:RadMultiPage ID="mp_Approval" runat="server">
            <telerik:RadPageView ID="pv_Approval" runat="server">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_School" runat="server" Text="学院：">
                            </asp:Label>
                        </td>
                        <td>
                            <tbmis:TbComboBox ID="ccmbSchool" runat="server" AutoPostBack="true" DataTextField="SchoolName" DataValueField="SchoolId"
                                OnDataBinding="ccmbSchool_BeforeDataBind"
                                OnDataBound="ccmbSchool_AfterDataBind" OnSelectedIndexChanged="ccmbSchool_SelectedIndexChanged">
                            </tbmis:TbComboBox>
                        </td>
                        <td>
                            <asp:Label ID="spare" runat="server" SkinID="AutoSize" Text="" Width="30px">
                            </asp:Label>
                            <telerik:RadButton ID="cbtnQuery" runat="server" Text="查 询" OnClick="ccmbSchool_AfterDataBind">
                            </telerik:RadButton>
                        </td>
                    </tr>
                </table>
                <fieldset style="margin: 2px; position: relative;">
                    <legend>审核意见</legend>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lbl_Choise" runat="server" Text="请选择：">
                                </asp:Label>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="crdlSuggestion" runat="server" RepeatColumns="2">
                                    <asp:ListItem Text="同意" Value="1" Selected="True">
                                    </asp:ListItem>
                                    <asp:ListItem Text="不同意" Value="0">
                                    </asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td style="width: 20px;"></td>
                            <td>
                                <asp:Label ID="lbl_CheckOpinion" runat="server" Text="审核意见：">
                                </asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="ctxtRemark" runat="server" Width="390px" SkinID="AutoSize">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                <asp:Label ID="lbl_Sign" runat="server" Text="签名：">
                                </asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txt_Sign" runat="server" Enabled="false">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                <tbmis:TbButton ID="cbtnSubmit" runat="server" Text="审核确认" OnBeforeClick="cbtnSubmit_Click" OnClick="cbtnSubmit_AfterClick">
                                </tbmis:TbButton>
                            </td>
                        </tr>
                    </table>
                </fieldset>


                <telerik:RadGrid ID="cgrdDeclaration" SkinID="NoExport" runat="server" CheckControlID="cchkSelectSingle" OnDataBinding="cgrdDeclaration_BeforeDataBind">
                    <MasterTableView  EnableNoRecordsTemplate="true" NoMasterRecordsText="没有数据可以显示" AllowPaging="true" PageSize="10">
                        <PagerStyle Mode="NumericPages" PagerTextFormat="{4}第{0}页 共{1}页" PageButtonCount="4" />
                        <HeaderStyle Height="18px" VerticalAlign="Middle" HorizontalAlign="Center" />
                        <Columns>
                            <telerik:GridTemplateColumn HeaderStyle-Width="40">
                                <HeaderTemplate>
                                    <asp:CheckBox runat="server" ID="cchkSelectAll" AutoPostBack="true" OnCheckedChanged="cchkCheckAll_CheckedChanged" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="cchkSelectSingle" Checked='<% #Eval("CheckFlag")%>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="序号" HeaderStyle-Width="40">
                                <ItemTemplate>
                                    <%#Container .DataSetIndex +1 %>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn HeaderText="课程编号" DataField="CourseNum" HeaderStyle-Width="60">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="课程名称" DataField="CourseName" HeaderStyle-Width="60">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="教学班编号" DataField="TeachingClassNum" HeaderStyle-Width="60">
                                <ItemTemplate>
                                    <a href="#" onclick="OnRequestTeachingClass('<%#Eval("TeachingClassNum") %>')">
                                        <%# Eval("TeachingClassNum")%></a>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn HeaderText="数据标识" DataField="DataSignName" HeaderStyle-Width="50"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="教材编号" DataField="TextbookNum" HeaderStyle-Width="50">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="教材名称" HeaderStyle-Width="120">
                                <ItemTemplate>
                                    <a href="#" onclick="OnRequestTextbook('<%#Eval("TextbookID") %>')">
                                        <%# Eval("TextbookName")%></a>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn HeaderText="领用人" DataField="RecipientType" HeaderStyle-Width="50">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="申报数量" DataField="DeclarationCount" HeaderStyle-Width="50">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="申报人" DataField="Declarant" HeaderStyle-Width="60">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="申报日期" DataField="DeclarationDate" HeaderStyle-Width="70">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="手机" DataField="MobilePhone" HeaderStyle-Width="60">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="联系方式" DataField="Homephone" HeaderStyle-Width="60">
                            </telerik:GridBoundColumn>                            
                        </Columns>
                    </MasterTableView>

                </telerik:RadGrid>

                <%--<utm:UTMisGrid runat="server" ID="cgrdDeclaration" SkinID="AutoPages" PageSize="10" CheckControlID="cchkSelectSingle" OnBeforeDataBind="cgrdDeclaration_BeforeDataBind">
                    <MasterTableView >
                        <Columns>
                            <telerik:GridTemplateColumn HeaderStyle-Width="40">
                                <HeaderTemplate>
                                    <utm:UTMisCheckBox runat="server" ID="cchkSelectAll" AutoPostBack="true" OnCheckedChanged="cchkCheckAll_CheckedChanged" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <utm:UTMisCheckBox runat="server" ID="cchkSelectSingle" Checked='<% #Eval("CheckFlag")%>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="序号" HeaderStyle-Width="40">
                                <ItemTemplate>
                                    <%#Container .DataSetIndex +1 %>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn HeaderText="课程编号" DataField="CourseNum">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="课程名称" DataField="CourseName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="教学班编号" DataField="TeachingClassNum">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="教材编号" DataField="TextbookNum" HeaderStyle-Width="80">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="教材名称" HeaderStyle-Width="100">
                                <ItemTemplate>
                                    <a href="#" onclick="OnRequestTextbook('<%#Eval("TextbookID") %>')">
                                        <%# Eval("TextbookName")%></a>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn HeaderText="领用人" DataField="RecipientType" HeaderStyle-Width="50">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="申报数量" DataField="DeclarationCount"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="申报人" DataField="TeacherName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="申报日期" DataField="DeclarationDate">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="手机" DataField="MobilePhone">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="联系方式" DataField="Homephone">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="审核状态" DataField="ApprovalState"></telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </utm:UTMisGrid>--%>
            </telerik:RadPageView>
        </telerik:RadMultiPage>

        <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
            <Windows>
                <telerik:RadWindow ID="wdw_TextbookDetailMessage" runat="server" Top="100" Left="150" Modal="true" ReloadOnShow="true">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </form>
</body>
</html>
