<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeclarationsForTeachingClass.aspx.cs" Inherits="TextbookManage.WebUI.WindowForMessage.DeclarationsForTeachingClass" %>

<%@ OutputCache Duration="60" VaryByParam="TeachingClassNum" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../App_Themes/CPMisTheme/CPMisTable.css" type="text/css" rel="Stylesheet" />
    <link href="../App_Themes/CPMisTheme/style.css" type="text/css" rel="Stylesheet" />
    <title>教材详细信息</title>
</head>
<body style="text-align: center;">
    <form id="form1" runat="server">
        <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
        </telerik:RadSkinManager>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline">
        </telerik:RadAjaxManager>
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" AutoTooltipify="true">
        </telerik:RadToolTipManager>
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
            <utm:UTMisGrid runat="server" ID="cgrdDeclarations" SkinID="AutoHeight" OnBeforeDataBind="cgrdDeclarations_BeforeDataBind"
                 Width="700">
                <MasterTableView>
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="序号" HeaderStyle-Width="40">
                            <ItemTemplate>
                                <%#Container .DataSetIndex +1 %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn HeaderText="教材编号" DataField="TextbookNum" HeaderStyle-Width="70">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="教材名称" DataField="TextbookName" HeaderStyle-Width="100">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="申报数量" DataField="DeclarationCount" HeaderStyle-Width="40">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="申报人" DataField="Declarant" HeaderStyle-Width="60">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="申报日期" DataField="DeclarationDate" HeaderStyle-Width="80">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="联系电话" DataField="MobilePhone" HeaderStyle-Width="80">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="作者" DataField="Author" HeaderStyle-Width="80">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="出版社" DataField="Press" HeaderStyle-Width="60">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="定价" DataField="Price" HeaderStyle-Width="40">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="ISBN" DataField="ISBN" HeaderStyle-Width="100">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="版本" DataField="Edition" HeaderStyle-Width="50">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="版次" DataField="PrintCount" HeaderStyle-Width="50">
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
            </utm:UTMisGrid>
        </div>
    </form>
</body>
</html>
