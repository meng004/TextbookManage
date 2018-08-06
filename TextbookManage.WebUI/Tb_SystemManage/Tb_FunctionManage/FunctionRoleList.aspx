<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FunctionRoleList.aspx.cs"
    Inherits="CPMis.WebPage.SystemManageUI.FunctionManageUI.FunctionRoleList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>功能角色</title>

    <script language="javascript" type="text/javascript" src="../../JS/WebScript.js"></script>

    <script language="javascript" type="text/javascript">
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
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <ClientEvents OnRequestStart="onRequestStart" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="wg_FunctionRoleList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="wg_FunctionRoleList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="tb_FunctonRoleList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="wg_FunctionRoleList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="wg_FunctionRoleList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
    <div id="main">
        <cp:CPMisToolBar ID="tb_FunctonRoleList" 
            OnButtonClick="tb_FunctonRoleList_ButtonClicked" runat="Server">
            <Items>
                <telerik:RadToolBarButton Text="删 除" CommandName="Delete" ImageUrl="../../Img/tlb_Delete.png">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Text="帮 助" CommandName="Help" ImageUrl="../../Img/tlb_Help.png">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" Text="Button 1" DisplayName="TextBox1">
                    <ItemTemplate>
                        <cp:CPMisTextBox ID="txt_Query" runat="server">
                        </cp:CPMisTextBox>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Text="查 询" CommandName="Query">
                </telerik:RadToolBarButton>
            </Items>
        </cp:CPMisToolBar>
        <cp:CPMisTabStrip ID="tab_FunctionRoleList" runat="server" MultiPageID="mp_FunctionRoleList">
            <Tabs>
                <cp:CPMisTab Text="功能角色(F)" AccessKey="F" PageViewID="pv_FunctionRoleList">
                </cp:CPMisTab>
            </Tabs>
        </cp:CPMisTabStrip>
        <cp:CPMisMultiPage ID="mp_FunctionRoleList" runat="server">
            <cp:CPMisPageView ID="pv_FunctionRoleList" runat="server">
                <fieldset style="width: 780px; margin: 2px; padding: 2px;">
                    <legend>用户功能信息</legend>
                    <table>
                        <tr>
                            <td>
                                <cp:CPMisLabel ID="CPMisLabel1" runat="server" Text="功能编号:" SkinID="AutoSize" Font-Size="15px"
                                    Width="80px"></cp:CPMisLabel>
                                <cp:CPMisLabel ID="lbl_FunctionID" runat="server" Text="" SkinID="Paraset" Width="100px"
                                    Font-Size="15px" ForeColor="Red"></cp:CPMisLabel>
                            </td>
                            <td>
                                <cp:CPMisLabel ID="CPMisLabel2" Text="功能名称:" runat="server" Width="80px" SkinID="AutoSize"
                                    Font-Size="15px"></cp:CPMisLabel>
                                <cp:CPMisLabel ID="lbl_FunctionName" runat="server" Text="" SkinID="Paraset" Width="250px"
                                    Font-Size="15px" ForeColor="Red"></cp:CPMisLabel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <cp:CPMisLabel ID="CPMisLabel3" Text="功能路径:" runat="server" Width="80px" SkinID="AutoSize"
                                    Font-Size="15px"></cp:CPMisLabel>
                                <cp:CPMisLabel ID="lbl_FunctionURL" runat="server" Text="" SkinID="Paraset" Width="680px"
                                    Font-Size="15px" ForeColor="Red"></cp:CPMisLabel>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <cp:CPMisGrid ID="wg_FunctionRoleList" runat="server" CheckControlID="chb_RowCheck"
                    OnBeforeDataBind="wg_FunctionRoleList_BeforeDataBind" SkinID="normal" OnBeforePageIndexChanged="wg_FunctionRoleList_BeforePageIndexChanged">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="ID" UniqueName="ID" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="chk_SelectOne" DataField="CheckFlag" HeaderStyle-Width="30px">
                                <HeaderTemplate>
                                    <cp:CPMisCheckBox ID="chb_HeadCheck" OnCheckedChanged="chb_HeadCheck_CheckedChanged"
                                        AutoPostBack="true" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <cp:CPMisCheckBox ID="chb_RowCheck" Checked='<%#Eval("CheckFlag") %>' runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="RoleName" UniqueName="RoleName" HeaderText="角色名称">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </cp:CPMisGrid>
            </cp:CPMisPageView>
        </cp:CPMisMultiPage>
    </div>
    </form>
</body>
</html>
