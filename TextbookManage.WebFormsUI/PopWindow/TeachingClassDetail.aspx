<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeachingClassDetail.aspx.cs" Inherits="TextbookManage.WebUI.WindowForMessage.TeachingClassDetail" %>
<%@ OutputCache Duration="60" VaryByParam="TeachingClassNum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../App_Themes/CPMisTheme/CPMisTable.css" type="text/css" rel="Stylesheet" />
    <link href="../App_Themes/CPMisTheme/style.css" type="text/css" rel="Stylesheet" />
    <title>教学班详细信息</title>
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

</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
        </telerik:RadSkinManager>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline">
            <ClientEvents OnRequestStart="onRequestStart" />
        </telerik:RadAjaxManager>
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" AutoTooltipify="true">
        </telerik:RadToolTipManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>
        <div>
            <utm:UTMisGrid runat="server" ID="cgrdProfessionalClasses" SkinID="NoExport" OnBeforeDataBind="cgrdProfessionalClasses_BeforeDataBind"
                Height="220px" Width="350px">
                <MasterTableView>
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="序号" HeaderStyle-Width="40px">
                            <ItemTemplate>
                                <%#Container .DataSetIndex +1 %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn HeaderText="班级编号" DataField="ProfessionalClassNum" >
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="班级名称" DataField="ProfessionalClassName" >
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="班级人数" DataField="StudentCount" >
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
            </utm:UTMisGrid>
        </div>
    </form>
</body>
</html>
