<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="TextbookManage.WebUI.ReleaseTextbook.StudentList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>领书学生名单</title>
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
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                //关闭自己并刷新主页面
                function CloseAndRebind() {
                    var oWnd = GetRadWindow();
                    oWnd.Close();
                    oWnd.BrowserWindow.refreshGrid("update");
                }
                //关闭自己
                function CloseWindow() {
                    var oWnd = GetRadWindow();
                    oWnd.Close();
                }
                //获取父窗体RadWindow控制器
                function GetRadWindow() {
                    var oWindow = null;
                    if (window.radWindow)
                        oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                    else if (window.frameElement.radWindow)
                        oWindow = window.frameElement.radWindow; //IE (and Moz as well)
                    return oWindow;
                }
            </script>
        </telerik:RadCodeBlock>
        <div>
            <telerik:RadButton runat="server" ID="btnOk" Text="确定" Icon-PrimaryIconUrl="~/Img/tlb_Choose.png"
                OnClick="btnOk_Click">
            </telerik:RadButton>
            <telerik:RadButton runat="server" ID="btnCancel" Text="取消" Icon-PrimaryIconUrl="~/Img/tlb_Delete.png"
                OnClick="btnCancel_Click">
            </telerik:RadButton>
            <asp:CheckBox ID="cchkApplyToAll" runat="server" Text="适用本班所有教材" AutoPostBack="true"
                OnCheckedChanged="cchkApplyToAll_CheckedChanged" />
        </div>
        <utm:UTMisGrid runat="server" ID="cgrdStudentList" SkinID="NoExport" AutoGenerateColumns="False" CheckControlID="cchkRow"
            OnBeforeDataBind="cgrdStudentList_BeforeDataBind">
            <MasterTableView>
                <Columns>
                    <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" HeaderStyle-Width="40px">
                        <HeaderTemplate>
                            <utm:UTMisCheckBox ID="cchkAll" runat="server" AutoPostBack="true" OnCheckedChanged="cchkAll_CheckedChanged"></utm:UTMisCheckBox>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <utm:UTMisCheckBox ID="cchkRow" runat="server" Checked='<% #Eval("CheckFlag")%>'></utm:UTMisCheckBox>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="序号" HeaderStyle-Width="40">
                        <ItemTemplate>
                            <%# Container .DataSetIndex +1 %>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn HeaderText="学号" DataField="Num" HeaderStyle-Width="80">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="姓名" DataField="Name" HeaderStyle-Width="80">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="性别" DataField="Gender" HeaderStyle-Width="40">
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </utm:UTMisGrid>
    </form>
</body>
</html>
