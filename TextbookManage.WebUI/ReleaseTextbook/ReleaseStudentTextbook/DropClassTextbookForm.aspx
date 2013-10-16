<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DropClassTextbookForm.aspx.cs"
    Inherits="CPMis.WebPage.Tb_PSS.Tb_PSS_07.ClassDropTextbookForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>已领用学生名单</title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
    </telerik:RadSkinManager>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline">
        <ClientEvents OnRequestStart="onRequestStart" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdStudentList" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>            
              <telerik:AjaxSetting AjaxControlID="toolbar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdStudentList" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cgrdStudentList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdStudentList" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" AutoTooltipify="true">
    </telerik:RadToolTipManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
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
        <div style="margin-left: auto; margin-right: auto">
            <utm:UTMisGrid runat="server" ID="cgrdStudentList" OnBeforeDataBind="cgrdStudentList_OnBeforeDataBind"
                AutoGenerateColumns="False"  SkinID="Ordinary">
                <MasterTableView>
                    <Columns>                       
                        <telerik:GridTemplateColumn HeaderText="序号" HeaderStyle-Width="30px">
                            <ItemTemplate>
                                <%# Container .DataSetIndex +1 %></ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn HeaderText="学号" DataField="StudentNum">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="姓名" DataField="StudentName">
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
            </utm:UTMisGrid>
    </div>
    </form>
</body>
</html>
