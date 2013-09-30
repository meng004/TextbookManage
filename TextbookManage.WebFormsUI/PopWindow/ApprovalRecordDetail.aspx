<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApprovalRecordDetail.aspx.cs" Inherits="TextbookManage.WebUI.WindowForMessage.ApprovalRecordDetail" %>
<%@ OutputCache Duration="60" VaryByParam="DeclarationID" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../App_Themes/CPMisTheme/CPMisTable.css" type="text/css" rel="Stylesheet" />
    <link href="../App_Themes/CPMisTheme/style.css" type="text/css" rel="Stylesheet" />
    <title>审核详细信息</title>
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
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
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
            </script>
        </telerik:RadCodeBlock>
        <div>
            <utm:UTMisGrid runat="server" ID="cgrdApprovalRecord" SkinID="NoExport" OnBeforeDataBind="cgrdApprovalRecord_BeforeDataBind" >
                <MasterTableView>
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="序号" HeaderStyle-Width="40px">
                            <ItemTemplate>
                                <%#Container .DataSetIndex +1 %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn HeaderText="审核部门" DataField="ApprovalDivision">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="审核人" DataField="ApprovalPerson">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="审核日期" DataField="ApprovalDate">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="审核意见" DataField="ApprovalSuggestion">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="审核说明" DataField="Remark">
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
            </utm:UTMisGrid>
        </div>
    </form>
</body>
</html>
