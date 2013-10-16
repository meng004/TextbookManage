<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InStockForm.aspx.cs" Inherits="TextbookManage.WebUI.Inventory.InStockForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>入库单</title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                //关闭自己
                function Close() {
                    //GetRadWindow().BrowserWindow.refreshGrid();
                    GetRadWindow().close();
                    return false;
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
            <ul>
                <li>
                    <utm:UTMisTextBox ID="ctxtInventoryId" ReadOnly="True" Display="false" SkinID="txt200" runat="server" Label="库存ID">
                    </utm:UTMisTextBox>
                    <utm:UTMisTextBox ID="ctxtStorageId" ReadOnly="True" Visible="false" SkinID="txt200" runat="server" Label="仓库ID">
                    </utm:UTMisTextBox>
                    <utm:UTMisTextBox ID="ctxtTextbookId" ReadOnly="True" Visible="false" SkinID="txt200" runat="server" Label="教材ID">
                    </utm:UTMisTextBox>
                </li>
                <li>
                    <utm:UTMisTextBox ID="ctxtTextbookNum" ReadOnly="True" BackColor="LightGray" SkinID="txt200" runat="server" Label="教材编号">
                    </utm:UTMisTextBox>
                </li>
                <li>
                    <utm:UTMisTextBox ID="ctxtTextbookName" ReadOnly="true" BackColor="LightGray" SkinID="txt200" runat="server" Label="教材名称"
                        TextMode="MultiLine" Rows="5">
                    </utm:UTMisTextBox>
                </li>
                <li>
                    <utm:UTMisTextBox ID="ctxtAuthor" ReadOnly="true" BackColor="LightGray" SkinID="txt200" runat="server" Label="作者" TextMode="MultiLine" Rows="2">
                    </utm:UTMisTextBox>
                </li>
                <li>
                    <utm:UTMisTextBox ID="ctxtPress" ReadOnly="true" BackColor="LightGray" SkinID="txt200" runat="server" Label="出版社" TextMode="MultiLine" Rows="2">
                    </utm:UTMisTextBox>
                </li>
                <li>
                    <utm:UTMisTextBox ID="ctxtISBN" ReadOnly="true" BackColor="LightGray" SkinID="txt200" runat="server" Label="ISBN">
                    </utm:UTMisTextBox>
                </li>
                <li>
                    <utm:UTMisTextBox ID="ctxtInventoryCount" ReadOnly="true" BackColor="LightGray" SkinID="txt200" runat="server" Label="库存数量">
                    </utm:UTMisTextBox>
                </li>
                <li>
                    <utm:UTMisTextBox ID="ctxtShelfNumber" SkinID="txt200" runat="server" Label="架位号">
                    </utm:UTMisTextBox>
                </li>
                <li>
                    <utm:UTMisTextBox ID="ctxtInStockCount" SkinID="txt200" runat="server" Label="入库数量">
                    </utm:UTMisTextBox>
                </li>
                <li>
                    <utm:UTMisButton ID="cbtnSubmit" runat="server" Text="入库" ValidationGroup="InStockGroup"
                        OnBeforeClick="cbtnSubmit_BeforeClick"
                        OnAfterClick="cbtnSubmit_AfterClick"></utm:UTMisButton>
                </li>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="入库数量不能为空"
                    ControlToValidate="ctxtInStockCount" Display="None" ValidationGroup="InStockGroup"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="入库数量应大于0小于20000，如：1"
                    ControlToValidate="ctxtInStockCount" Display="None" ValidationGroup="InStockGroup" MinimumValue="1" MaximumValue="20000" Type="Integer"></asp:RangeValidator>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="InStockGroup" />

            </ul>
        </div>
    </form>
</body>
</html>
