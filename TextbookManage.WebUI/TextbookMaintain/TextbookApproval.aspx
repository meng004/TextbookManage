<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TextbookApproval.aspx.cs" Inherits="TextbookManage.WebUI.TextbookMaintain.TextbookApproval" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>审核教材</title>
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
                //异步回调,刷新grid
                function refreshGrid(arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(arg);
                }
                //教材详单弹窗
                function OnRequestTextbook(TextbookId) {
                    var oWnd = $find("<%=wdw_TextbookDetailMessage.ClientID%>");
                    oWnd.setUrl(encodeURI("../WindowForMessage/TextbookDetailMessage.aspx?TextbookID=" + TextbookId)); //
                    oWnd.show();
                    oWnd.setSize(600, 300);
                }
            </script>
        </telerik:RadCodeBlock>
        <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1" UpdatePanelsRenderMode="Inline" 
            OnAjaxRequest="RadAjaxManager1_AjaxRequest" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
            <ClientEvents OnRequestStart="onRequestStart" />
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ccmbSchool"></telerik:AjaxUpdatedControl>
                        <telerik:AjaxUpdatedControl ControlID="cgrdDeclaration" ></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbSchool">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdDeclaration" ></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cgrdDeclaration">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdDeclaration" ></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>

        <cp:CPMisToolBar ID="CPMisToolBar1" runat="server" SkinID="Long">
            <Items>
                <telerik:RadToolBarButton runat="server" CommandName="help" Text="帮助" ImageUrl="~\Img\tlb_Help.png">
                </telerik:RadToolBarButton>
            </Items>
        </cp:CPMisToolBar>

        <cp:CPMisTabStrip ID="CPMisTabStrip1" runat="server" MultiPageID="mp_Approval">
            <Tabs>
                <cp:CPMisTab runat="server" Text="审核用书申报" PageViewID="pv_Approval" Selected="true">
                </cp:CPMisTab>
            </Tabs>
        </cp:CPMisTabStrip>

        <cp:CPMisMultiPage ID="mp_Approval" runat="server" SkinID="Long">
            <cp:CPMisPageView ID="pv_Approval" runat="server" >
                <table>
                    <tr>
                        <td>
                            <cp:CPMisLabel ID="lbl_School" runat="server" Text="学院：">
                            </cp:CPMisLabel>
                        </td>
                        <td>
                            <cp:CPMisComboBox ID="ccmbSchool" runat="server" AutoPostBack="true" DataTextField="Name" DataValueField="SchoolId"
                                OnBeforeDataBind="ccmbSchool_BeforeDataBind"
                                OnAfterDataBind="ccmbSchool_AfterDataBind" 
                                OnSelectedIndexChanged="ccmbSchool_SelectedIndexChanged">
                            </cp:CPMisComboBox>
                        </td>
                        <td>
                            <cp:CPMisLabel ID="spare" runat="server" SkinID="AutoSize" Text="" Width="30px">
                            </cp:CPMisLabel>
                            <cp:CPMisButton ID="cbtnQuery" runat="server" Text="查 询" OnClick="ccmbSchool_AfterDataBind">
                            </cp:CPMisButton>
                        </td>
                    </tr>
                </table>
                <fieldset style="margin: 2px; position: relative;">
                    <legend>审核意见</legend>
                    <table>
                        <tr>
                            <td>
                                <cp:CPMisLabel ID="lbl_Choise" runat="server" Text="请选择：">
                                </cp:CPMisLabel>
                            </td>
                            <td>
                                <cp:CPMisRadioButtonList ID="crdlSuggestion" runat="server" RepeatColumns="2">
                                    <asp:ListItem Text="同意" Value="1" Selected="True">
                                    </asp:ListItem>
                                    <asp:ListItem Text="不同意" Value="0">
                                    </asp:ListItem>
                                </cp:CPMisRadioButtonList>
                            </td>
                            <td style="width: 20px;"></td>
                            <td>
                                <cp:CPMisLabel ID="lbl_CheckOpinion" runat="server" Text="审核意见：">
                                </cp:CPMisLabel>
                            </td>
                            <td>
                                <cp:CPMisTextBox ID="ctxtRemark" runat="server" Width="390px" SkinID="AutoSize">
                                </cp:CPMisTextBox>
                            </td>
                            <td>
                                <cp:CPMisLabel ID="lbl_Sign" runat="server" Text="签名：">
                                </cp:CPMisLabel>
                            </td>
                            <td>
                                <cp:CPMisTextBox ID="txt_Sign" runat="server" Enabled="false">
                                </cp:CPMisTextBox>
                            </td>
                            <td>
                                <cp:CPMisButton ID="cbtnSubmit" runat="server" Text="审核确认" OnClick="cbtnSubmit_Click" OnAfterClick="cbtnSubmit_AfterClick">
                                </cp:CPMisButton>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <cp:CPMisGrid ID="cgrdDeclaration" SkinID="NoExport" runat="server" CheckControlID="cchkRowCheck" 
                    OnBeforeDataBind="cgrdDeclaration_BeforeDataBind" OnPageIndexChanged="cgrdDeclaration_PageIndexChanged">
                    <MasterTableView EnableNoRecordsTemplate="true" NoMasterRecordsText="没有数据可以显示" AllowPaging="true" PageSize="10">
                        <PagerStyle Mode="NumericPages" PagerTextFormat="{4}第{0}页 共{1}页" PageButtonCount="4" />
                        <HeaderStyle Height="18px" VerticalAlign="Middle" HorizontalAlign="Center" />
                        <Columns>
                            <telerik:GridTemplateColumn DataField="CheckFlag" HeaderStyle-Width="30px" UniqueName="cchkCheck" Visible="true">
                                <HeaderTemplate>
                                    <cp:CPMisCheckBox ID="cchkCheckAll" runat="server" AutoPostBack="true" OnCheckedChanged="cchkCheckAll_CheckedChanged" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <cp:CPMisCheckBox ID="cchkRowCheck" runat="server" Checked='<%#Eval("CheckFlag")%>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderStyle-Width="40px" HeaderText="序号">
                                <ItemTemplate>
                                    <%#Container .DataSetIndex +1 %>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="Num" HeaderText="编号">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Name" HeaderStyle-Width="120px" HeaderText="名称">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Isbn" HeaderStyle-Width="120px" HeaderText="ISBN">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Author" HeaderText="作者">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Press" HeaderStyle-Width="120px" HeaderText="出版社">
                            </telerik:GridBoundColumn>
 <%--                           <telerik:GridBoundColumn DataField="PressAddress" HeaderStyle-Width="120px" HeaderText="出版社地址">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PublishDate" HeaderText="出版日期">
                            </telerik:GridBoundColumn>--%>
                            <telerik:GridBoundColumn DataField="Price" HeaderText="定价">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Edition" HeaderText="版本">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PrintCount" HeaderText="版次">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PageCount" HeaderText="页数">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TextbookType" HeaderStyle-Width="120px" HeaderText="教材类型">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="IsSelfCompile" HeaderText="自编教材">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Declarant" HeaderText="申报人">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DeclarationDate" HeaderText="申报日期">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </cp:CPMisGrid>
            </cp:CPMisPageView>
        </cp:CPMisMultiPage>

        <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
            <Windows>
                <telerik:RadWindow ID="wdw_TextbookDetailMessage" runat="server" Top="100" Left="150" Modal="true" ReloadOnShow="true">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </form>
</body>
</html>
