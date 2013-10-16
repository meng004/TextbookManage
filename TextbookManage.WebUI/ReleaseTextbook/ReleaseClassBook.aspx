<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReleaseClassBook.aspx.cs" Inherits="TextbookManage.WebUI.ReleaseTextbook.ReleaseClassBook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadScriptManager runat="server" ID="RadScriptManager1">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline" DefaultLoadingPanelID="RadAjaxLoadingPanel1"
            OnAjaxRequest="RadAjaxManager1_AjaxRequest">
            <ClientEvents OnRequestStart="onRequestStart" />
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ccmbSchool" />
                        <telerik:AjaxUpdatedControl ControlID="ccmbGrade" />
                        <telerik:AjaxUpdatedControl ControlID="ccmbProfessionalClass" />
                        <telerik:AjaxUpdatedControl ControlID="ccmbStorage" />
                        <telerik:AjaxUpdatedControl ControlID="cgrdInventory" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbSchool">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ccmbGrade" />
                        <telerik:AjaxUpdatedControl ControlID="ccmbProfessionalClass" />
                        <telerik:AjaxUpdatedControl ControlID="cgrdInventory" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbGrade">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ccmbProfessionalClass" />
                        <telerik:AjaxUpdatedControl ControlID="cgrdInventory" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbProfessionalClass">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdInventory" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbStorage">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdInventory" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cgrdInventory">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdInventory" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
            <Windows>
                <telerik:RadWindow ID="wdw_TextbookDetailMessage" runat="server" Modal="true" ReloadOnShow="false">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
        <telerik:RadCodeBlock runat="server" ID="cbk">
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
                function OnRequestTextbook(textbookId) {
                    var oWnd = $find("<%=wdw_TextbookDetailMessage.ClientID%>");
                    oWnd.setUrl(encodeURI("../WindowForMessage/TextbookDetailMessage.aspx?TextbookID=" + textbookId)); //
                    oWnd.show();
                    oWnd.setSize(600, 300);
                }
                //领用人名单弹窗
                function OnRequestStudent() {
                    var oWnd = $find("<%=wdw_TextbookDetailMessage.ClientID%>");
                    oWnd.setUrl(encodeURI("StudentList.aspx")); //
                    oWnd.show();
                    oWnd.setSize(400, 430);
                    return false;
                }
                //打印报表弹窗
                function OnRequestPrint(schoolName, className) {
                    //var oWnd = $find("<%=wdw_TextbookDetailMessage.ClientID%>");
                    var oWnd = document.getElementById("wdw_TextbookDetailMessage");
                    oWnd.setUrl(encodeURI("../ReportViewUI/ReportForClassBook.aspx?SchoolName=" + schoolName + "&ClassName=" + className)); //
                    oWnd.show();
                    oWnd.setSize(400, 430);
                    return false;
                }
            </script>
        </telerik:RadCodeBlock>
        <div>
            <%--验证--%>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="联系电话1不能为空"
                ControlToValidate="ctxtTelephone1" Display="None" ValidationGroup="contactGroup"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="电话号码1不正确，请填写正确的号码，如：13875781794"
                ControlToValidate="ctxtTelephone1" Display="None" ValidationGroup="contactGroup" ValidationExpression="^1[1-9]\d{9}$"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="联系电话2不能为空"
                ControlToValidate="ctxtTelephone2" Display="None" ValidationGroup="contactGroup"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="电话号码2不正确，请填写正确的号码，如：13875781794"
                ControlToValidate="ctxtTelephone2" Display="None" ValidationGroup="contactGroup" ValidationExpression="^1[1-9]\d{9}$"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="学号1不能为空"
                ControlToValidate="ctxtStudentNum1" Display="None" ValidationGroup="contactGroup"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="学号2不能为空"
                ControlToValidate="ctxtStudentNum2" Display="None" ValidationGroup="contactGroup"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="姓名1不能为空"
                ControlToValidate="ctxtStudentName1" Display="None" ValidationGroup="contactGroup"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="姓名2不能为空"
                ControlToValidate="ctxtStudentName2" Display="None" ValidationGroup="contactGroup"></asp:RequiredFieldValidator>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="contactGroup" />
        </div>
        <div>
            <telerik:RadToolBar ID="toolbar" runat="server" SkinID="Long">
                <Items>
                    <telerik:RadToolBarButton Text="帮助" ImageUrl="~/Img/tlb_Help.png" runat="server">
                    </telerik:RadToolBarButton>
                </Items>
            </telerik:RadToolBar>
            <telerik:RadTabStrip ID="UTMisTabStrip1" runat="server" MultiPageID="mp">
                <Tabs>
                    <telerik:RadTab runat="server" Text="班级教材发放" PageViewID="pv" Selected="true">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage runat="server" ID="mp" SelectedIndex="0">
                <telerik:RadPageView runat="server" ID="pv">
                    <table>
                        <tr>
                            <td>
                                <telerik:RadComboBox runat="server" ID="ccmbSchool" AutoPostBack="True"
                                    DataTextField="Name" DataValueField="SchoolId" Label="学院"
                                    OnDataBinding="ccmbSchool_BeforeDataBind"
                                    OnDataBound="ccmbSchool_DataBound"
                                    OnSelectedIndexChanged="ccmbSchool_SelectedIndexChanged">
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                <telerik:RadComboBox runat="server" ID="ccmbGrade" AutoPostBack="True"
                                    Label="年级"
                                    OnDataBinding="ccmbGrade_BeforeDataBind"
                                    OnDataBound="ccmbGrade_DataBound"
                                    OnSelectedIndexChanged="ccmbGrade_SelectedIndexChanged">
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                <telerik:RadComboBox runat="server" ID="ccmbProfessionalClass" AutoPostBack="True"
                                    DataTextField="Name" DataValueField="ProfessionalClassId" Label="班级"
                                    OnDataBinding="ccmbProfessionalClass_BeforeDataBind"
                                    OnDataBound="ccmbProfessionalClass_DataBound"
                                    OnSelectedIndexChanged="ccmbProfessionalClass_SelectedIndexChanged">
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                <telerik:RadComboBox runat="server" ID="ccmbStorage" AutoPostBack="true"
                                    DataTextField="Name" DataValueField="StorageId" Label="仓库"
                                    OnDataBinding="ccmbStorage_BeforeDataBind"
                                    OnDataBound="ccmbStorage_DataBound"
                                    OnSelectedIndexChanged="ccmbStorage_SelectedIndexChanged">
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                <telerik:RadButton ID="cbtnQuery" runat="server" Text="查询" OnClick="cbtnQuery_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadTextBox runat="server" ID="ctxtStudentNum1" Width="180"
                                    Label="领用人1学号" LabelWidth="80">
                                </telerik:RadTextBox>
                                <telerik:RadButton ID="lbtnCheck1" runat="server" Text="检测"
                                    Width="40" OnClick="lbtnCheck1_Click">
                                </telerik:RadButton>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="ctxtStudentName1" runat="server" Width="180" Enabled="false"
                                    Label="领用人1姓名" LabelWidth="80">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="ctxtTelephone1" runat="server" Width="180"
                                    Label="联系电话" LabelWidth="80">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadTextBox runat="server" ID="ctxtStudentNum2" Width="180"
                                    Label="领用人2学号" LabelWidth="80">
                                </telerik:RadTextBox>
                                <telerik:RadButton ID="lbtnCheck2" runat="server" Text="检测"
                                    Width="40" OnClick="lbtnCheck2_Click">
                                </telerik:RadButton>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="ctxtStudentName2" runat="server" Width="180" Enabled="false"
                                    Label="领用人2姓名" LabelWidth="80">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="ctxtTelephone2" runat="server" Width="180"
                                    Label="联系电话" LabelWidth="80">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                <telerik:RadButton ID="cbtnRelease" runat="server" Text="发放" ToolTip="选择待发放的教材，然后再发放"
                                    ValidationGroup="contactGroup"
                                    OnClick="cbtnRelease_Click" />
                            </td>
                            <td colspan="2">
                                <utm:UTMisButton ID="cbtnPrint" runat="server" Text="打印"
                                    OnBeforeClick="cbtnPrint_Click" OnAfterClick="cbtnPrint_AfterClick" />
                            </td>
                        </tr>
                    </table>
                    <utm:UTMisGrid ID="cgrdInventory" runat="server" AutoGenerateColumns="False" CheckControlID="cchkRow"
                        OnBeforeDataBind="cgrdInventory_BeforeDataBind"
                        OnItemDataBound="cgrdInventory_ItemDataBound"
                        OnItemCommand="cgrdInventory_ItemCommand">
                        <MasterTableView>
                            <Columns>
                                <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" HeaderStyle-Width="40">
                                    <HeaderTemplate>
                                        <asp:CheckBox runat="server" ID="cchkCheckAll" AutoPostBack="true" OnCheckedChanged="cchkCheckAll_CheckedChanged" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <utm:UTMisCheckBox ID="cchkRow" runat="server" Checked='<% #Eval("CheckFlag")%>' />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="序号" HeaderStyle-Width="40">
                                    <ItemTemplate>
                                        <%#Container.ClientRowIndex +1 %>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn HeaderText="教材编号" DataField="Num" HeaderStyle-Width="60">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="教材名称" HeaderStyle-Width="150">
                                    <ItemTemplate>
                                        <a href="#" onclick="OnRequestTextbook('<%#Eval("TextbookId") %>')">
                                            <%# Eval("Name")%></a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn HeaderText="出版社" DataField="Press" HeaderStyle-Width="80">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="ISBN" DataField="ISBN" HeaderStyle-Width="80">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="作者" DataField="Author" HeaderStyle-Width="80">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="版本" DataField="Edition">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="版次" DataField="PrintCount">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="定价" DataField="Price">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="折后价" DataField="DiscountPrice">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="架位号" DataField="ShelfNumber">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="申报数" DataField="DeclarationCount">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="发放数" DataField="ReleaseCount">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="库存数" DataField="InventoryCount">
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn HeaderText="领用名单" ButtonType="LinkButton" Text="更改">
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                    </utm:UTMisGrid>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </div>
    </form>
</body>
</html>
