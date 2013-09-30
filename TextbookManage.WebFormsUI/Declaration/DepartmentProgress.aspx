<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentProgress.aspx.cs" Inherits="TextbookManage.WebUI.Declaration.DepartmentProgress" %>

<%@ Reference Page="~/Declaration/SchoolProgress.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>教研室申报进度</title>
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
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
            <ClientEvents OnRequestStart="onRequestStart" />
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
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
            </script>
        </telerik:RadCodeBlock>
        <div>
            <utm:UTMisToolBar ID="ctlbDeclaration" runat="server">
                <Items>
                    <telerik:RadToolBarButton runat="server" Text="帮助" ImageUrl="~/Img/tlb_Help.png">
                    </telerik:RadToolBarButton>
                </Items>
            </utm:UTMisToolBar>
            <utm:UTMisTabStrip ID="CPMisTabStrip1" runat="server" MultiPageID="mp_QueryDeclaration">
                <Tabs>
                    <utm:UTMisTab runat="server" Text="教研室申报进度" PageViewID="pv_QueryDeclaration" Selected="true">
                    </utm:UTMisTab>
                </Tabs>
            </utm:UTMisTabStrip>
            <utm:UTMisMultiPage runat="server" ID="mp_QueryDeclaration">
                <utm:UTMisPageView ID="pv_QueryDeclaration" runat="server">
                    <utm:UTMisGrid runat="server" ID="cgrdDeclarationList" SkinID="NoExport" Height="500" OnBeforeDataBind="cgrdDeclarationList_BeforeDataBind" OnItemDataBound="cgrdDeclarationList_ItemDataBound">
                        <MasterTableView AllowPaging="true" PageSize="10" EnableNoRecordsTemplate="true" NoMasterRecordsText="没有数据可以显示">
                            <PagerStyle Mode="NextPrevAndNumeric" PagerTextFormat="{4}第{0}页 共{1}页" PageButtonCount="4" />
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
                                <telerik:GridTemplateColumn HeaderStyle-Width="40" HeaderText="序号">
                                    <ItemTemplate>
                                        <%#Container.DataSetIndex +1 %>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="DepartmentName" HeaderText="教研室名称" HeaderStyle-Width="120">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CourseNum" HeaderText="课程编号">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CourseName" HeaderText="课程名称">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DataSignName" HeaderText="数据标识">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TotalCount" HeaderText="教学任务总数">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FinishedCount" HeaderText="已完成申报数">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Proportion" HeaderText="完成比例">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RestCount" HeaderText="未完成申报数">
                                </telerik:GridBoundColumn>
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
