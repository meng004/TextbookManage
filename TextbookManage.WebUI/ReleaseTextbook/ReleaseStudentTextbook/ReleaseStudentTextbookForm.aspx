<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReleaseStudentTextbookForm.aspx.cs"
    Inherits="TextbookManage.WebUI.ReleaseTextbook.ReleaseStudentTextbook.ReleaseStudentTextbookForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>选择领用名单</title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server"></telerik:RadSkinManager>
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
        //复选框全选或反选
        function selectAll(ctlName, bool) {
            var ctl = document.getElementById(ctlName); //根据控件的在客户端所呈现的ID获取控件
            var checkbox = ctl.getElementsByTagName('input'); //获取该控件内标签为input的控件
            /*所有Button、TextBox、CheckBox、RadioButton类型的服务器端控件在解释成Html控件后，都为<input type=''./>，通过type区分它们的类型。*/
            for (var i = 0; i < checkbox.length; i++) {
                if (checkbox[i].type == 'checkbox') {
                    checkbox[i].checked = bool;
                }
            }
        }
        function OnToolBarButton_Clicked(sender, args) {
            var button = args.get_item();
            var command = button.get_commandName();
            var a = true;
            if (command == "Close") {
               GetRadWindow().BrowserWindow.refreshGrid("Rebind");
               GetRadWindow().close();
            }
            return false;
        }
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow; //IE (and Moz as well)
            return oWindow;
        }
    </script>
    <div style="width: 400px">
        <utm:UTMisToolBar ID="toolbar" runat="server" SkinID="toolbar" OnButtonClick="toolBar_Click" OnClientButtonClicked="OnToolBarButton_Clicked">
            <Items>
                <telerik:RadToolBarButton Text="帮助" CommandName="Help" ImageUrl="~/Img/tlb_Help.png" runat="server">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Text="确定" CommandName="Confirm" runat="server" ImageUrl="~/Img/tl_ok.png"></telerik:RadToolBarButton>
                <telerik:RadToolBarButton Text="关闭" CommandName="Close" runat="server" ImageUrl="~/Img/tlb_Delete.png"></telerik:RadToolBarButton>
            </Items>
        </utm:UTMisToolBar>
        <utm:UTMisCheckBox ID="cchkApplyToAll" runat="server" Text="适用本班所有教材" /><br />
        </div>
        <div style="margin-left: auto; margin-right: auto">
            <utm:UTMisGrid runat="server" ID="cgrdStudentList" OnBeforeDataBind="cgrdStudentList_OnBeforeDataBind"
                AutoGenerateColumns="False" AllowMultiRowSelection="true" SkinID="Ordinary" OnItemDataBound="cgrdStudentList_OnItemDataBound">
                <MasterTableView DataKeyNames="StudentSubscriptionPlanId,IsChecked">
                    <Columns>
                        <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" HeaderStyle-Width="40px">
                            <HeaderTemplate>
                                <asp:CheckBox ID="headerchb" runat="server" onclick="javascript:selectAll('cgrdStudentList',this.checked);">
                                </asp:CheckBox>
                                <%--<asp:CheckBox ID="headerchb" runat="server" OnCheckedChanged="chbHeader_OnCheckedChanged" AutoPostBack="true">
                                    </asp:CheckBox>--%>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chbTemplate" runat="server" Checked="true"></asp:CheckBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="序号" HeaderStyle-Width="40px">
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
