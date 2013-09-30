<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryDeclaration.aspx.cs" Inherits="TextbookManage.WebUI.Declaration.QueryDeclaration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查询用书申报</title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
            <ClientEvents OnRequestStart="onRequestStart" />
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ccmbTerm" />
                        <telerik:AjaxUpdatedControl ControlID="ccmbSchool" />
                        <telerik:AjaxUpdatedControl ControlID="ccmbDepartment" />
                        <telerik:AjaxUpdatedControl ControlID="ccmbCourse" />
                        <telerik:AjaxUpdatedControl ControlID="ccmbRecipientType" />
                        <telerik:AjaxUpdatedControl ControlID="cgrdDeclarationList" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbSchool">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ccmbDepartment" />
                        <telerik:AjaxUpdatedControl ControlID="ccmbCourse" />
                        <telerik:AjaxUpdatedControl ControlID="cgrdDeclarationList" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbDepartment">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ccmbCourse" />
                        <telerik:AjaxUpdatedControl ControlID="cgrdDeclarationList" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbCourse">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdDeclarationList" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbRecipientType">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdDeclarationList" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbTerm">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdDeclarationList" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>

                <telerik:AjaxSetting AjaxControlID="cgrdDeclarationList">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdDeclarationList" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadCodeBlock runat="server">
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
                //工具栏
                function OnToolBarButtonClicked(sender, args) {
                    var button = args.get_item();
                    var command = button.get_commandName();
                    var a = true;
                    var oWnd = $find("<%=wdw_TextbookDetailMessage.ClientID%>");
                    switch (command) {
                        case "student":
                            oWnd.setUrl("StudentTextbookDeclaration.aspx");
                            //window.open("StudentTextbookDeclaration.aspx");
                            break;
                        case "teacher":
                            oWnd.setUrl("TeacherTextbookDeclaration.aspx");
                            //window.open("TeacherTextbookDeclaration.aspx");
                            break;
                        default:
                            break;
                    }
                    oWnd.show();
                    oWnd.setSize(1000, 650);
                }

                //教材详单弹窗
                function OnRequestTextbook(TextbookId) {
                    var oWnd = $find("<%=wdw_TextbookDetailMessage.ClientID%>");
                    oWnd.setUrl(encodeURI("../WindowForMessage/TextbookDetailMessage.aspx?TextbookID=" + TextbookId)); //
                    oWnd.show();
                    oWnd.setSize(400, 380);
                }
                //查看审核记录
                function OnRequestApproval(declarationId) {
                    var oWnd = $find("<%=wdw_TextbookDetailMessage.ClientID%>");
                    oWnd.setUrl(encodeURI("../WindowForMessage/ApprovalRecordDetail.aspx?DeclarationID=" + declarationId)); //
                    oWnd.show();
                    oWnd.setSize(600, 400);
                }
                //查看回告记录
                function OnRequestFeedback(declarationId) {
                    var oWnd = $find("<%=wdw_TextbookDetailMessage.ClientID%>");
                    oWnd.setUrl(encodeURI("../WindowForMessage/FeedbackForDeclaration.aspx?DeclarationID=" + declarationId)); //
                    oWnd.show();
                    oWnd.setSize(400, 300);
                }
            </script>
        </telerik:RadCodeBlock>
        <div>
            <utm:UTMisToolBar ID="ctlbDeclaration" runat="server" OnClientButtonClicked="OnToolBarButtonClicked">
                <Items>
                    <telerik:RadToolBarButton Text="我要申报学生用书" ToolTip="添加学生用书申报" CommandName="student" ImageUrl="~/Img/tlb_Add.png">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton Text="我要申报教师用书" ToolTip="添加教师用书申报" CommandName="teacher" ImageUrl="~/Img/tlb_Add.png">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" Text="帮助" ImageUrl="~/Img/tlb_Help.png">
                    </telerik:RadToolBarButton>
                </Items>
            </utm:UTMisToolBar>
            <utm:UTMisTabStrip ID="CPMisTabStrip1" runat="server" MultiPageID="mp_QueryDeclaration">
                <Tabs>
                    <utm:UTMisTab runat="server" Text="查询用书申报" PageViewID="pv_QueryDeclaration" Selected="true">
                    </utm:UTMisTab>
                </Tabs>
            </utm:UTMisTabStrip>
            <utm:UTMisMultiPage runat="server" ID="mp_QueryDeclaration">
                <utm:UTMisPageView ID="pv_QueryDeclaration" runat="server">
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <utm:UTMisComboBox runat="server" ID="ccmbSchool" AutoPostBack="True" IsMaintainSelectedValue="true" SkinID="cmb200" Label="学院"
                                        DataTextField="SchoolName" DataValueField="SchoolID" OnBeforeDataBind="ccmbSchool_BeforeDataBind"
                                        OnAfterDataBind="ccmbSchool_AfterDataBind" OnSelectedIndexChanged="ccmbSchool_AfterDataBind">
                                    </utm:UTMisComboBox>
                                </td>
                                <td>
                                    <utm:UTMisComboBox runat="server" ID="ccmbDepartment" AutoPostBack="true" IsMaintainSelectedValue="true" SkinID="cmb200" Label="教研室"
                                        DataTextField="DepartmentName" DataValueField="DepartmentID" OnBeforeDataBind="ccmbDepartment_BeforeDataBind"
                                        OnAfterDataBind="ccmbDepartment_AfterDataBind" OnSelectedIndexChanged="ccmbDepartment_AfterDataBind">
                                    </utm:UTMisComboBox>
                                </td>
                                <td>
                                    <utm:UTMisComboBox runat="server" ID="ccmbCourse" AutoPostBack="True" IsMaintainSelectedValue="true" SkinID="cmb200" Label="课程"
                                        DataTextField="CourseNumAndName" DataValueField="CourseID" OnBeforeDataBind="ccmbCourse_BeforeDataBind"
                                        OnAfterDataBind="ccmbRecipientType_AfterDataBind" OnSelectedIndexChanged="ccmbRecipientType_SelectedIndexChanged">
                                    </utm:UTMisComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <utm:UTMisComboBox runat="server" ID="ccmbTerm" AutoPostBack="True" IsMaintainSelectedValue="true" SkinID="cmb120" Label="学年学期"
                                        DataTextField="YearTerm" DataValueField="YearTerm" OnBeforeDataBind="ccmbTerm_BeforeDataBind"
                                        OnSelectedIndexChanged="ccmbRecipientType_SelectedIndexChanged">
                                    </utm:UTMisComboBox>
                                </td>
                                <td>
                                    <utm:UTMisComboBox runat="server" ID="ccmbRecipientType" AutoPostBack="True" IsMaintainSelectedValue="true" SkinID="cmb120" Label="领用人类型"
                                        DataTextField="RecipientName" DataValueField="RecipientTypeID" OnBeforeDataBind="ccmbRecipientType_BeforeDataBind"
                                        OnSelectedIndexChanged="ccmbRecipientType_SelectedIndexChanged">
                                    </utm:UTMisComboBox>
                                </td>
                                <td>
                                    <utm:UTMisButton runat="server" ID="cbtnQuery" Text="查询" OnClick="cbtnQuery_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <utm:UTMisGrid runat="server" ID="cgrdDeclarationList" SkinID="AutoPages" OnBeforeDataBind="cgrdDeclarationList_BeforeDataBind">
                        <MasterTableView>
                            <Columns>
                                <%--<telerik:GridTemplateColumn HeaderText="编辑" HeaderStyle-Width="60px" UniqueName="UpdateCourse">
                                    <ItemTemplate>
                                        <img alt="编辑" src="../../Img/GridEdit.png" onclick="OnRequestTextbook('<%#Eval("TextbookID") %>')" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="cchkCheck" DataField="CheckFlag" HeaderStyle-Width="30px" Visible="true">
                                    <HeaderTemplate>
                                        <utm:UTMisCheckBox runat="server" ID="cchkCheckAll" AutoPostBack="true" OnCheckedChanged="cchkCheckAll_CheckedChanged" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <utm:UTMisCheckBox runat="server" ID="cchkRowCheck" AutoPostBack="true" Checked='<%#Eval("CheckFlag")%>' OnCheckedChanged="cchkRowCheck_CheckedChanged" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>--%>
                                <telerik:GridTemplateColumn HeaderText="序号" HeaderStyle-Width="40">
                                    <ItemTemplate>
                                        <%#Container .DataSetIndex +1 %>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn HeaderText="教材编号" DataField="TextbookNum" HeaderStyle-Width="70">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="教材名称" HeaderStyle-Width="200">
                                    <ItemTemplate>
                                        <a href="#" onclick="OnRequestTextbook('<%#Eval("TextbookID") %>')">
                                            <%# Eval("TextbookName")%></a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn HeaderText="申报数量" DataField="DeclarationCount">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="申报人" DataField="Declarant">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="手机号码" DataField="MobilePhone">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="联系电话" DataField="HomePhone">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="申报日期" DataField="DeclarationDate">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="审核状态">
                                    <ItemTemplate>
                                        <a href="#" onclick="OnRequestApproval('<%#Eval("DeclarationID")%>')">
                                            <%# Eval("ApprovalState") %></a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="回告状态">
                                    <ItemTemplate>
                                        <a href="#" onclick="OnRequestFeedback('<%#Eval("DeclarationID") %>')">
                                            <%# Eval("FeedbackState") %></a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </utm:UTMisGrid>
                </utm:UTMisPageView>
            </utm:UTMisMultiPage>
        </div>
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
            <Windows>
                <telerik:RadWindow ID="wdw_TextbookDetailMessage" runat="server" Top="50" Left="150" Modal="true" Animation="Fade" ReloadOnShow="true">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </form>
</body>
</html>
