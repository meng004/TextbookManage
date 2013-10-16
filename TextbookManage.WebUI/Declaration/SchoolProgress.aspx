<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolProgress.aspx.cs" Inherits="TextbookManage.WebUI.Declaration.SchoolProgress" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>学院申报进度</title>
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
                        <telerik:AjaxUpdatedControl ControlID="ccmbTerm" />
                        <telerik:AjaxUpdatedControl ControlID="ccmbDataSign" />
                        <telerik:AjaxUpdatedControl ControlID="cgrdDeclarationList" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbTerm">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdDeclarationList" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbDataSign">
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
                //未完成申报的课程列表
                function OnRequestDepartment(SchoolId) {
                    var oWnd = $find("<%=wdw_TextbookDetailMessage.ClientID%>");
                    var DataSignId = $find("<%=ccmbDataSign.ClientID %>").get_value();//数据标识
                    oWnd.setUrl(encodeURI("../Declaration/DepartmentProgress.aspx?SchoolId=" + SchoolId + "&DataSignId=" + DataSignId)); //
                    oWnd.show();
                    oWnd.setSize(840, 540);
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
                    <utm:UTMisTab runat="server" Text="学院申报进度" PageViewID="pv_QueryDeclaration" Selected="true">
                    </utm:UTMisTab>
                </Tabs>
            </utm:UTMisTabStrip>
            <utm:UTMisMultiPage runat="server" ID="mp_QueryDeclaration">
                <utm:UTMisPageView ID="pv_QueryDeclaration" runat="server">
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <utm:UTMisComboBox runat="server" ID="ccmbDataSign" AutoPostBack="True" IsMaintainSelectedValue="true" SkinID="cmb120" Label="数据标识"
                                        DataTextField="Name" DataValueField="DataSignId" OnBeforeDataBind="ccmbDataSign_BeforeDataBind" OnAfterDataBind="cbtnQuery_Click"
                                        OnSelectedIndexChanged="ccmbDataSign_SelectedIndexChanged">
                                    </utm:UTMisComboBox>
                                </td>
                                <td>
                                    <utm:UTMisButton runat="server" ID="cbtnQuery" Text="查询" OnClick="cbtnQuery_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <utm:UTMisGrid runat="server" ID="cgrdDeclarationList" SkinID="AutoHeight"
                        OnBeforeDataBind="cgrdDeclarationList_BeforeDataBind" OnItemDataBound="cgrdDeclarationList_ItemDataBound" OnItemCommand="cgrdDeclarationList_ItemCommand">
                        <MasterTableView EnableNoRecordsTemplate="true" NoMasterRecordsText="没有数据可以显示">
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
                                    <HeaderStyle Width="40px" />
                                </telerik:GridTemplateColumn>
                                <%--<telerik:GridBoundColumn DataField="Name" HeaderStyle-Width="200" HeaderText="学院名称">
                                    <HeaderStyle Width="200px" />
                                </telerik:GridBoundColumn>--%>
                                <telerik:GridTemplateColumn HeaderText="学院名称" DataField="Name" HeaderStyle-Width="200" >
                                    <ItemTemplate>
                                        <a href="#" onclick="OnRequestDepartment('<%#Eval("SchoolId") %>')">
                                            <%# Eval("Name") %></a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="TotalCount" HeaderText="教学班总数">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FinishedCount" HeaderText="已完成申报数">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RestCount" HeaderText="未完成申报数">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="未完成申报数" DataField="RestCount">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Proportion" HeaderText="完成比例（%）">
                                </telerik:GridBoundColumn>
                                <%-- 因从griditem中取schoolId，所以添加参数 --%>
<%--                                <telerik:GridBoundColumn DataField="SchoolId" HeaderText="学院ID" Visible="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn>
                                    <ItemTemplate>
                                        <asp:Button ID="btn" runat="server" PostBackUrl="~/Declaration/DepartmentProgress.aspx" Text="查看" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>--%>
                            </Columns>
                        </MasterTableView>
                    </utm:UTMisGrid>
                </utm:UTMisPageView>
            </utm:UTMisMultiPage>
        </div>
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
            <Windows>
                <telerik:RadWindow ID="wdw_TextbookDetailMessage" runat="server" Top="100" Left="150" Modal="true" Animation="Fade" ReloadOnShow="true">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </form>
</body>
</html>
