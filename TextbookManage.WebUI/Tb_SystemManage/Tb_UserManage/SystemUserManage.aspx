<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemUserManage.aspx.cs"
    Inherits="CPMis.WebPage.SystemManageUI.UserManageUI.UserManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户管理</title>
    <%--<script language="javascript" type="text/javascript" src="../../JS/WebScript.js">
    </script>--%>
    <style type="text/css">
        .table, .cell11, .cell12
        {
            border:0px;
            margin: 0px;
            padding: 0px;
            
        }
        .cell11
        {
            text-align: right;
        }
        .cell12
        {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
    </telerik:RadSkinManager>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript" language="javascript">
            function OnButtonClientClick(commandName) {
                refreshGrid(commandName);
                return false;
            }
            function OnToolBarButtonClicked(sender, args) {
                var button = args.get_item();
                var command = button.get_commandName();
                refreshGrid(commandName);
                args.set_cancel(true);
            }
            //如果点击的是导出按钮则将AJAX禁用
            function onRequestStart(sender, args) {
                if (args.get_eventTarget().indexOf("ExportToExcelButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToWordButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToPdfButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToCsvButton") >= 0) {

                    args.set_enableAjax(false);
                }
            }
            function OnClientUpdateCommand(sysUserID, userName, IsLockedOut) {
                if (IsLockedOut == "0") {
                    var oWnd = $find("<%=wdw_NewsRelease.ClientID%>");
                    oWnd.setUrl("SystemUserUpdate.aspx?UserName=" + escape(userName) + "&SysUserID=" + sysUserID); //
                    oWnd.show();
                    oWnd.setSize(710, 490);
                }
                else {
                    alert("该用户已被锁定，请先解锁再进行操作！");
                    return;
                }
            }
            //异步回调,刷新grid
            function refreshGrid(arg) {
                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(arg);
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <ClientEvents OnRequestStart="onRequestStart" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="wg_StudentManage" />
                    <telerik:AjaxUpdatedControl ControlID="wg_TeacherManage" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cmb_School">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cmb_ProfessionalClass" />
                    <telerik:AjaxUpdatedControl ControlID="wg_StudentManage" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cmb_Grade">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cmb_ProfessionalClass" />
                    <telerik:AjaxUpdatedControl ControlID="wg_StudentManage" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cmb_ProfessionalClass">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="wg_StudentManage" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Query">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="wg_StudentManage" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cmb_SchoolTeacher">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cmb_Department" />
                    <telerik:AjaxUpdatedControl ControlID="wg_TeacherManage" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cmb_Department">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="wg_TeacherManage" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_TeacherQuery">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="wg_TeacherManage" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_BooksellerQuery">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="wg_Bookseller" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cmb_Bookseller">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="wg_Bookseller" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="wg_Bookseller">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="wg_Bookseller" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <div>
        <cp:CPMisToolBar ID="tb_UserManage" runat="server" OnClientButtonClicking="OnToolBarButtonClicked"
            SkinID="Long">
            <Items>
                <telerik:RadToolBarButton Text="帮 助" CommandName="Help" ImageUrl="~/Img/tlb_Help.png">
                </telerik:RadToolBarButton>
            </Items>
        </cp:CPMisToolBar>
        <cp:CPMisTabStrip ID="tab_UserManage" runat="server" MultiPageID="mtp_UserManage"
            SkinID="Long" SelectedIndex="2">
            <Tabs>
                <cp:CPMisTab AccessKey="F" Text="学生信息(F)" PageViewID="pv_StudentManage">
                </cp:CPMisTab>
                <cp:CPMisTab AccessKey="T" Text="教师信息(T)" PageViewID="pv_TeacherManage">
                </cp:CPMisTab>
                <cp:CPMisTab AccessKey="B" Text="书商信息(B)" PageViewID="pv_BooksellerManage" 
                    Selected="True">
                </cp:CPMisTab>
            </Tabs>
        </cp:CPMisTabStrip>
        <cp:CPMisMultiPage ID="mtp_UserManage" runat="server" SkinID="Long" 
            SelectedIndex="2">
            <cp:CPMisPageView ID="pv_StudentManage" runat="server">
                <table cellspacing="0px" cellpadding="0px" class="table" width="800px">
                    <tr>
                        <td class="cell11">
                            <cp:CPMisLabel runat="server" ID="lbl_School" Text="学院" SkinID="Average">
                            </cp:CPMisLabel>
                        </td>
                        <td class="cell12">
                            <cp:CPMisComboBox runat="server" ID="cmb_School" AutoPostBack="True" DataSourceID="SqlDataSource_School"
                                DataTextField="SchoolName" DataValueField="SchoolID" DefaultIndex="0" IsCancelDataBind="False"
                                IsMaintainSelectedValue="False" SelectedText="" SkinID="cmb180">
                            </cp:CPMisComboBox>
                            <asp:SqlDataSource ID="SqlDataSource_School" runat="server" ConnectionString="<%$ConnectionStrings:USCTAMisConnectionString %>"
                                ProviderName="System.Data.SqlClient" SelectCommand="prSchoolNameGetList" SelectCommandType="StoredProcedure">
                            </asp:SqlDataSource>
                        </td>
                        <td class="cell11">
                            <cp:CPMisLabel runat="server" ID="lbl_Grade" Text="年级">
                            </cp:CPMisLabel>
                        </td>
                        <td class="cell12">
                            <cp:CPMisComboBox runat="server" ID="cmb_Grade" AutoPostBack="True" SkinID="cmb80"
                                DataSourceID="SqlDataSource_Grade" DataTextField="Grade" DataValueField="Grade"
                                DefaultIndex="0" IsCancelDataBind="False" IsMaintainSelectedValue="False" SelectedText="">
                            </cp:CPMisComboBox>
                            <asp:SqlDataSource ID="SqlDataSource_Grade" runat="server" ConnectionString="<%$ConnectionStrings:USCTAMisConnectionString %>"
                                ProviderName="System.Data.SqlClient" SelectCommand="prGradeGetList" SelectCommandType="StoredProcedure">
                            </asp:SqlDataSource>
                        </td>
                        <td class="cell11">
                            <cp:CPMisLabel runat="server" ID="clblProfessionalClass" Text="专业班级">
                            </cp:CPMisLabel>
                        </td>
                        <td class="cell12">
                            <cp:CPMisComboBox runat="server" ID="cmb_ProfessionalClass" AutoPostBack="True" SkinID="cmb180"
                                DataSourceID="ControlDataSource_Class" DataTextField="ClassName" DataValueField="ClassID">
                            </cp:CPMisComboBox>
                            <asp:SqlDataSource ID="ControlDataSource_Class" runat="server" ConnectionString="<%$ConnectionStrings:USCTAMisConnectionString %>"
                                ProviderName="System.Data.SqlClient" SelectCommand="prProfessionalClassGetListByCondition"
                                SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="cmb_School" Name="SchoolId" PropertyName="SelectedValue"
                                        DbType="String" />
                                    <asp:ControlParameter ControlID="cmb_Grade" Name="Grade" PropertyName="SelectedValue"
                                        Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                        <td class="cell12">
                            <cp:CPMisButton ID="btn_Query" runat="server" Text="查询" OnClick="btn_Query_Click" />
                        </td>
                    </tr>
                </table>
                <%--DataSourceID="sds_StudentManage"--%>
                <cp:CPMisGrid ID="wg_StudentManage"  runat="server" DataSourceID="sds_StudentManage"
                    AutoGenerateColumns="false" OnItemCommand="wg_StudentManage_ItemCommand" SkinID="Long">
                    <MasterTableView DataKeyNames="StudentID" AllowPaging="true" AllowSorting="true">
                        <Columns>
                            <telerik:GridBoundColumn DataField="UserID" DataType="System.Guid" UniqueName="UserID"
                                Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="StudentID" DataType="System.String" UniqueName="StudentID"
                                Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="UpdateCourse" HeaderText="编辑">
                                <ItemTemplate>
                                    <img alt="编辑" src="../../Img/GridEdit.png" onclick="OnClientUpdateCommand('<%# Eval("StudentID") %>','<%# Eval("UserName") %>','<%# Eval("IsLockedOut") %>')" />
                                </ItemTemplate>
                                <HeaderStyle Width="40px"></HeaderStyle>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="Name" DataType="System.String" UniqueName="Name"
                                HeaderText="姓名">
                                <HeaderStyle Width="116px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Sex" DataType="System.String" UniqueName="Sex"
                                HeaderText="性 别">
                                <HeaderStyle Width="40px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="StudentNum" DataType="System.String" UniqueName="StudentNum"
                                HeaderText="学号" HeaderStyle-Width="70px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SchoolName" DataType="System.String" UniqueName="SchoolName"
                                HeaderText="学院" HeaderStyle-Width="100px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ClassName" DataType="System.String" UniqueName="ClassName"
                                HeaderText="班级" HeaderStyle-Width="100px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="UserName" DataType="System.String" UniqueName="UserName"
                                HeaderText="用户名">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="UserLevelName" DataType="System.String" UniqueName="UserLevelName"
                                HeaderText="用户级别">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="UserFunction" HeaderText="功 能">
                                <HeaderStyle Width="50px" />
                                <ItemTemplate>
                                    <cp:CPMisLinkButton ID="lnk_UserFunction" CommandName="UserFunction" Text="查看" runat="server">
                                    </cp:CPMisLinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="IsLockedOut" HeaderText="是否锁定" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_IsLockedOut" runat="server" Text='<%# Convert.ToInt32(DataBinder.Eval(Container.DataItem,"IsLockedOut"))==0 ? "未锁定" : "锁定" %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </cp:CPMisGrid>
                <asp:SqlDataSource ID="sds_StudentManage" runat="server" ConnectionString="<%$ConnectionStrings:USCTAMisConnectionString %>"
                    ProviderName="System.Data.SqlClient" SelectCommand="prSystemGetStudentInfoListByClassID"
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="cmb_ProfessionalClass" Name="ClassID" PropertyName="SelectedValue"
                            DbType="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </cp:CPMisPageView>
            <cp:CPMisPageView ID="pv_TeacherManage" runat="server">
                <table cellspacing="0px" cellpadding="0px" class="table" width="650px">
                    <tr>
                        <td class="cell11">
                            <cp:CPMisLabel runat="server" ID="lbl_SchoolTeacher" Text="学院" SkinID="Average">
                            </cp:CPMisLabel>
                        </td>
                        <td class="cell12">
                            <cp:CPMisComboBox runat="server" ID="cmb_SchoolTeacher" AutoPostBack="True" DataSourceID="sds_SchoolTeacher"
                                DataTextField="SchoolName" DataValueField="SchoolID" DefaultIndex="0" IsCancelDataBind="False"
                                IsMaintainSelectedValue="False" SelectedText="" SkinID="cmb180">
                            </cp:CPMisComboBox>
                            <asp:SqlDataSource ID="sds_SchoolTeacher" runat="server" ConnectionString="<%$ConnectionStrings:USCTAMisConnectionString %>"
                                ProviderName="System.Data.SqlClient" SelectCommand="prSchoolNameGetList" SelectCommandType="StoredProcedure">
                            </asp:SqlDataSource>
                        </td>
                        <td class="cell11">
                            <cp:CPMisLabel runat="server" ID="lbl_Department" Text="系教研室">
                            </cp:CPMisLabel>
                        </td>
                        <td class="cell12">
                            <cp:CPMisComboBox runat="server" ID="cmb_Department" AutoPostBack="True" SkinID="cmb180"
                                DataSourceID="sds_Department" DataTextField="DepartmentName" DataValueField="DepartmentID"
                                DefaultIndex="0" IsCancelDataBind="False" IsMaintainSelectedValue="False" SelectedText="">
                            </cp:CPMisComboBox>
                            <asp:SqlDataSource ID="sds_Department" runat="server" ConnectionString="<%$ConnectionStrings:USCTAMisConnectionString %>"
                                ProviderName="System.Data.SqlClient" SelectCommand="prDepartmentGetListBySchoolId"
                                SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="cmb_SchoolTeacher" Name="SchoolId" PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                        <td class="cell12">
                            <cp:CPMisButton ID="btn_TeacherQuery" runat="server" Text="查询" OnClick="btn_TeacherQuery_Click" />
                        </td>
                    </tr>
                </table>
                <%--DataSourceID="sds_TeacherManage"--%>
                <cp:CPMisGrid ID="wg_TeacherManage"  runat="server" DataSourceID="sds_TeacherManage"
                    OnItemCommand="wg_TeacherManage_ItemCommand" AutoGenerateColumns="false" SkinID="Long">
                    <MasterTableView DataKeyNames="TeacherID" AllowPaging="true" AllowSorting="true"
                        PageSize="10">
                        <Columns>
                            <telerik:GridBoundColumn DataField="UserID" DataType="System.Guid" UniqueName="UserID"
                                Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TeacherID" DataType="System.String" UniqueName="TeacherID"
                                Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="UpdateCourse" HeaderText="编辑">
                                <ItemTemplate>
                                    <img alt="编辑" src="../../Img/GridEdit.png" onclick="OnClientUpdateCommand('<%# Eval("TeacherID") %>','<%# Eval("UserName") %>','<%# Eval("IsLockedOut") %>')" />
                                </ItemTemplate>
                                <HeaderStyle Width="40px"></HeaderStyle>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="Name" DataType="System.String" UniqueName="Name"
                                HeaderText="姓名">
                                <HeaderStyle Width="116px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Sex" DataType="System.String" UniqueName="Sex"
                                HeaderText="性 别">
                                <HeaderStyle Width="40px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TeacherNum" DataType="System.String" UniqueName="StudentNum"
                                HeaderText="教师编号" HeaderStyle-Width="70px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SchoolName" DataType="System.String" UniqueName="SchoolName"
                                HeaderText="学院" HeaderStyle-Width="100px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DepartmentName" DataType="System.String" UniqueName="ClassName"
                                HeaderText="系教研室" HeaderStyle-Width="100px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="UserName" DataType="System.String" UniqueName="UserName"
                                HeaderText="用户名">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="UserLevelName" DataType="System.String" UniqueName="UserLevelName"
                                HeaderText="用户级别">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="UserFunction" HeaderText="功 能">
                                <HeaderStyle Width="50px" />
                                <ItemTemplate>
                                    <cp:CPMisLinkButton ID="lnk_TeacherUserFunction" CommandName="UserFunction" Text="查看"
                                        runat="server">
                                    </cp:CPMisLinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="IsLockedOut" HeaderText="是否锁定" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_TeacherIsLockedOut" runat="server" Text='<%# Convert.ToInt32(DataBinder.Eval(Container.DataItem,"IsLockedOut"))==0 ? "未锁定" : "锁定" %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </cp:CPMisGrid>
                <%--''--%>
                <asp:SqlDataSource ID="sds_TeacherManage" runat="server" ConnectionString="<%$ConnectionStrings:USCTAMisConnectionString %>"
                    ProviderName="System.Data.SqlClient" SelectCommand="prSystemGetTeacherInfoListByDepartmentID"
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="cmb_Department" Name="DepartmentID" PropertyName="SelectedValue"
                            DbType="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </cp:CPMisPageView>
            <cp:CPMisPageView ID="pv_BooksellerManage" runat="server">
                <table cellspacing="0px" cellpadding="0px" class="table" width="350px">
                    <tr>
                        <td class="cell11">
                            <cp:CPMisLabel runat="server" ID="lbl_Bookeseller" Text="书商" SkinID="Average">
                            </cp:CPMisLabel>
                        </td>
                        <td class="cell12">
                            <cp:CPMisComboBox runat="server" ID="cmb_Bookseller" AutoPostBack="True" DataSourceID="sds_Bookseller"
                                DataTextField="BooksellerName" DataValueField="BooksellerID" DefaultIndex="0"
                                IsCancelDataBind="False" IsMaintainSelectedValue="False" SelectedText="" SkinID="cmb180">
                            </cp:CPMisComboBox>
                            <asp:SqlDataSource ID="sds_Bookseller" runat="server" ConnectionString="<%$ConnectionStrings:USCTAMisConnectionString %>"
                                ProviderName="System.Data.SqlClient" SelectCommand="prBookSellerNameGetList"
                                SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        </td>
                        <td class="cell12">
                            <cp:CPMisButton ID="btn_BooksellerQuery" runat="server" Text="查询" OnClick="btn_BooksellerQuery_Click" />
                        </td>
                    </tr>
                </table>
                <%--DataSourceID="sds_BooksellerManage"--%>
                <cp:CPMisGrid ID="wg_Bookseller"  runat="server" DataSourceID="sds_BooksellerManage"
                    OnItemCommand="wg_Bookseller_ItemCommand" AutoGenerateColumns="false" SkinID="Long">
                    <MasterTableView DataKeyNames="BooksellerStaffID" AllowPaging="true" AllowSorting="true" PageSize="10">
                        <Columns>
                            <telerik:GridBoundColumn DataField="UserID" DataType="System.Guid" UniqueName="UserID"
                                Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BooksellerStaffID" DataType="System.Guid" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="UpdateCourse" HeaderText="编辑">
                                <ItemTemplate>
                                    <img alt="编辑" src="../../Img/GridEdit.png" onclick="OnClientUpdateCommand('<%# Eval("BooksellerStaffID") %>','<%# Eval("UserName") %>','<%# Eval("IsLockedOut") %>')" />
                                </ItemTemplate>
                                <HeaderStyle Width="40px"></HeaderStyle>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="Name" DataType="System.String" UniqueName="Name"
                                HeaderText="姓名">
                                <HeaderStyle Width="116px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Sex" DataType="System.String" UniqueName="Sex"
                                HeaderText="性 别">
                                <HeaderStyle Width="40px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="StaffNum" DataType="System.String" UniqueName="StudentNum"
                                HeaderText="员工编号" HeaderStyle-Width="70px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BooksellerName" DataType="System.String" UniqueName="SchoolName"
                                HeaderText="书商名" HeaderStyle-Width="100px">
                            </telerik:GridBoundColumn>
                            <%-- <telerik:GridBoundColumn DataField="DepartmentName" DataType="System.String" UniqueName="ClassName" HeaderText="班级"
                                HeaderStyle-Width="100px">
                            </telerik:GridBoundColumn>--%>
                            <telerik:GridBoundColumn DataField="UserName" DataType="System.String" UniqueName="UserName"
                                HeaderText="用户名">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="UserLevelName" DataType="System.String" UniqueName="UserLevelName"
                                HeaderText="用户级别">
                                <HeaderStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="UserFunction" HeaderText="功 能">
                                <HeaderStyle Width="50px" />
                                <ItemTemplate>
                                    <cp:CPMisLinkButton ID="lnk_BooksellerUserFunction" CommandName="UserFunction" Text="查看"
                                        runat="server">
                                    </cp:CPMisLinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="IsLockedOut" HeaderText="是否锁定" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Convert.ToInt32(DataBinder.Eval(Container.DataItem,"IsLockedOut"))==0 ? "未锁定" : "锁定" %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </cp:CPMisGrid>
                <%--''--%>
                <asp:SqlDataSource ID="sds_BooksellerManage" runat="server" ConnectionString="<%$ConnectionStrings:USCTAMisConnectionString %>"
                    ProviderName="System.Data.SqlClient" SelectCommand="prSystemGetBooksellerInfoListByBooksellerID"
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="cmb_Bookseller" Name="BooksellerID" PropertyName="SelectedValue" DbType="Guid" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </cp:CPMisPageView>
        </cp:CPMisMultiPage>
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
            <Windows>
                <telerik:RadWindow ID="wdw_NewsRelease" runat="server" Top="30px" Left="45px">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </div>
    </form>
</body>
</html>
