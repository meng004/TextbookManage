<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentTextbookDeclaration.aspx.cs" Inherits="TextbookManage.WebUI.Declaration.StudentTextbookDeclaration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学生用书申报</title>
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
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline">
            <ClientEvents OnRequestStart="onRequestStart" />
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="ccmbSchool">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ccmbDepartment" />
                        <telerik:AjaxUpdatedControl ControlID="ccmbCourse" />
                        <telerik:AjaxUpdatedControl ControlID="cgrdTeachingClassList" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbDepartment">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ccmbCourse" />
                        <telerik:AjaxUpdatedControl ControlID="cgrdTeachingClassList" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbCourse">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdTeachingClassList" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cbtnQuery">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdTeachingClassList" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cgrdTeachingClassList">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdTeachingClassList" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cgrdTeachingClassList">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ctxtAmount" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cbtnQueryBook">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdTextbookList" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cgrdTextbookList">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdTextbookList" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadCodeBlock runat="server" ID="RadCodeBlock1">
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
                //刷新父窗体，关闭自己
                function CloseAndRebind() {                    
                        GetRadWindow().BrowserWindow.refreshGrid();
                        GetRadWindow().close();
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
                    oWnd.setSize(400, 300);
                }
                //已申报用书详情弹窗
                function OnRequestDeclaration(TeachingClassNum) {
                    var oWnd = $find("<%=wdw_TextbookDetailMessage.ClientID%>");
                    oWnd.setUrl(encodeURI("../WindowForMessage/DeclarationsForTeachingClass.aspx?TeachingClassNum=" + TeachingClassNum)); //
                    oWnd.show();
                    oWnd.setSize(900, 400);
                }
            </script>
        </telerik:RadCodeBlock>

        <utm:UTMisToolBar runat="server" ID="tlb_Help">
            <Items>
                <telerik:RadToolBarButton runat="server" CommandName="help" Text="帮助" ImageUrl="~/Img/tlb_Help.png"></telerik:RadToolBarButton>
            </Items>
        </utm:UTMisToolBar>

        <utm:UTMisTabStrip runat="server" ID="mp_StudentDaclaration" MultiPageID="mp_Student">
            <Tabs>
                <utm:UTMisTab runat="server" PageViewID="pv_Student" Text="学生用书申报" Selected="True"></utm:UTMisTab>
            </Tabs>
        </utm:UTMisTabStrip>

        <utm:UTMisMultiPage runat="server" ID="mp_Student" SelectedIndex="0">
            <utm:UTMisPageView runat="server" ID="pv_Student">
                <table>
                    <tr>
                        <td rowspan="2">
                            <b style="color: red">1.选教学班</b>
                            <div>
                                <ul>
                                    <li>
                                        <utm:UTMisComboBox runat="server" ID="ccmbSchool" SkinID="cmb200" AutoPostBack="true"
                                            DataTextField="SchoolName" DataValueField="SchoolID" Label="学院" IsMaintainSelectedValue="true"
                                            OnBeforeDataBind="ccmbSchool_BeforeDataBind" OnAfterDataBind="ccmbSchool_SelectedIndexChanged"
                                            OnSelectedIndexChanged="ccmbSchool_SelectedIndexChanged">
                                        </utm:UTMisComboBox>
                                        <utm:UTMisComboBox runat="server" ID="ccmbDepartment" SkinID="cmb180" AutoPostBack="true"
                                            DataTextField="DepartmentName" DataValueField="DepartmentID" Label="教研室" IsMaintainSelectedValue="true"
                                            OnBeforeDataBind="ccmbDepartment_BeforeDataBind" OnAfterDataBind="ccmbDepartment_SelectedIndexChanged"
                                            OnSelectedIndexChanged="ccmbDepartment_SelectedIndexChanged">
                                        </utm:UTMisComboBox>
                                    </li>
                                    <li>
                                        <utm:UTMisComboBox runat="server" ID="ccmbCourse" SkinID="cmb200" AutoPostBack="true"
                                            DataTextField="CourseNumAndName" DataValueField="CourseID" Label="课程" IsMaintainSelectedValue="true"
                                            OnBeforeDataBind="ccmbCourse_BeforeDataBind" OnAfterDataBind="ccmbCourse_SelectedIndexChanged"
                                            OnSelectedIndexChanged="ccmbCourse_SelectedIndexChanged">
                                        </utm:UTMisComboBox>
                                        <utm:UTMisButton runat="server" ID="dbtnQuery" Text="查询" OnClick="cbtnQuery_Click" CausesValidation="false" />
                                    </li>
                                </ul>

                                <utm:UTMisGrid runat="server" ID="cgrdTeachingClassList" SkinID="NoExport" Height="420" Width="500" CheckControlID="cchkTeachingClass"
                                    OnBeforeDataBind="cgrdTeachingClassList_BeforeDataBind">
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" HeaderStyle-Width="40">
                                                <HeaderTemplate>
                                                    <utm:UTMisCheckBox runat="server" ID="cchkCheckAll" AutoPostBack="true" OnCheckedChanged="cchkCheckAll_CheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <utm:UTMisCheckBox ID="cchkTeachingClass" runat="server" AutoPostBack="true" Checked='<% #Eval("CheckFlag")%>' OnCheckedChanged="cchkTeachingClass_CheckedChanged" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="序号" HeaderStyle-Width="40">
                                                <ItemTemplate>
                                                    <%#Container .DataSetIndex+1 %>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="教学班编号" DataField="TeachingClassNum">
                                                <ItemTemplate>
                                                    <a href="#" onclick="OnRequestTeachingClass('<%#Eval("TeachingClassNum") %>')">
                                                        <%# Eval("TeachingClassNum")%></a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn HeaderText="数据标识" DataField="DataSignName"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="班级人数" DataField="StudentCount">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="授课教师" DataField="TeacherName">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn HeaderText="学生用书">
                                                <ItemTemplate>
                                                    <a href="#" onclick="OnRequestDeclaration('<%#Eval("TeachingClassNum")%>')">
                                                        <%# Eval("DeclarationState")%></a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                </utm:UTMisGrid>
                            </div>
                        </td>
                        <td>
                            <b style="color: red">2.选教材</b>
                            <div>
                                <utm:UTMisTextBox runat="server" ID="ctxtTextBookName" Label="教材名称" SkinID="txt200">
                                </utm:UTMisTextBox>
                                <utm:UTMisTextBox runat="server" ID="ctxtISBN" Label="ISBN" SkinID="txt200">
                                </utm:UTMisTextBox>
                                <utm:UTMisButton runat="server" ID="cbtnQueryBook" Text="查询" OnClick="cbtnQueryBook_Click" CausesValidation="false" />

                                <utm:UTMisGrid runat="server" ID="cgrdTextbookList" SkinID="NoExport" Height="380" CheckControlID="cchkTextbook"
                                    OnBeforeDataBind="cgrdTextbookList_BeforeDataBind">
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridTemplateColumn HeaderText="选择" HeaderStyle-Width="40">
                                                <ItemTemplate>
                                                    <utm:UTMisCheckBox runat="server" ID="cchkTextbook" AutoPostBack="true" Checked='<% #Eval("CheckFlag")%>' OnCheckedChanged="cchkTextbook_CheckedChanged" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="序号" HeaderStyle-Width="40">
                                                <ItemTemplate>
                                                    <%#Container .DataSetIndex+1 %>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn HeaderText="教材编号" DataField="TextbookNum" HeaderStyle-Width="70">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="ISBN" DataField="ISBN" HeaderStyle-Width="100">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn HeaderText="教材名称">
                                                <ItemTemplate>
                                                    <a href="#" onclick="OnRequestTextbook('<%#Eval("TextbookID") %>')">
                                                        <%#Eval("TextbookName") %></a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>

                                            <%--其他还有教材信息为添加到列中--%>
                                        </Columns>
                                    </MasterTableView>
                                </utm:UTMisGrid>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b style="color: red">3.填写申报信息</b>
                            <div>
                                <ul>
                                    <li>
                                        <b style="color: red">*</b>
                                        <utm:UTMisTextBox runat="server" ID="ctxtMobile" SkinID="txt200" Label="手机号码" ToolTip="11位手机号码，如：13875781794">
                                        </utm:UTMisTextBox>

                                        <b style="color: red">*</b>
                                        <utm:UTMisTextBox runat="server" ID="ctxtHomePhone" SkinID="txt200" Label="固定电话" ToolTip="区号+座机号，如：0734-8282561">
                                        </utm:UTMisTextBox>
                                    </li>
                                    <li>
                                        <b style="color: red">*</b>
                                        <utm:UTMisTextBox runat="server" ID="ctxtAmount" SkinID="txt200" Label="申报数量" Text="1" EmptyMessage="1" ReadOnly="true" BackColor="LightGray">
                                        </utm:UTMisTextBox>

                                        <utm:UTMisButton runat="server" ID="cbtnConfirm" Text="保存" OnClick="cbtnConfirm_Click" OnAfterClick="cbtnConfirm_AfterClick" ValidationGroup="contactGroup"
                                            ToolTip="保存前，请确保选了教材和教学班" />
                                    </li>
                                    <li>
                                        <%--验证--%>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="手机号不能为空"
                                            ControlToValidate="ctxtMobile" Display="None" ValidationGroup="contactGroup"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="手机号码不正确，请填写正确的号码，如：13875781794"
                                            ControlToValidate="ctxtMobile" Display="None" ValidationGroup="contactGroup" ValidationExpression="^1[1-9]\d{9}$"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="固定电话号不能为空"
                                            ControlToValidate="ctxtHomePhone" Display="None" ValidationGroup="contactGroup"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="固定电话号码不正确，请填写正确的号码，如：0734-8282561"
                                            ControlToValidate="ctxtHomePhone" Display="None" ValidationGroup="contactGroup" ValidationExpression="^[0][1-9]\d{1,2}-[1-9]\d{6,7}$"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="申报数量不能为空"
                                            ControlToValidate="ctxtAmount" Display="None" ValidationGroup="contactGroup"></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="申报数量应大于0小于20000，如：1"
                                            ControlToValidate="ctxtAmount" Display="None" ValidationGroup="contactGroup" MinimumValue="1" MaximumValue="20000" Type="Integer"></asp:RangeValidator>
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="contactGroup" />

                                    </li>
                                </ul>
                            </div>
                        </td>
                    </tr>
                </table>
            </utm:UTMisPageView>
        </utm:UTMisMultiPage>

        <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
            <Windows>
                <telerik:RadWindow ID="wdw_TextbookDetailMessage" runat="server" Top="150" Left="350" Modal="true"
                    ReloadOnShow="true">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </form>
</body>
</html>
