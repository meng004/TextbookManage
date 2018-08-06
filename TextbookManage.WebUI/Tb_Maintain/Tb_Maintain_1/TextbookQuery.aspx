<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TextbookQuery.aspx.cs" Inherits="TextbookManage.WebUI.Tb_Maintain.Tb_Maintain_1.TextbookQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>教材管理</title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadStyleSheetManager runat="server" ID="RadStyleSheetManager1">
        </telerik:RadStyleSheetManager>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
        </telerik:RadSkinManager>
        <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" AutoTooltipify="true">
        </telerik:RadToolTipManager>
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All">
        </telerik:RadFormDecorator>

        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

            <script type="text/javascript" >
                //如果点击的是导出按钮则将AJAX禁用
                function onRequestStart(sender, args) {
                    if (args.get_eventTarget().indexOf("ExportToExcelButton") >= 0 ||
                        args.get_eventTarget().indexOf("ExportToWordButton") >= 0 ||
                        args.get_eventTarget().indexOf("ExportToPdfButton") >= 0 ||
                        args.get_eventTarget().indexOf("ExportToCsvButton") >= 0) {

                        args.set_enableAjax(false);
                    }
                }
                //工具栏
                function OnToolBarButtonClicked(sender, args) {
                    var button = args.get_item();
                    var command = button.get_commandName();
                    var a = true;
                    if (command == "Add") {
                        var oWnd = $find("<%=RadWindow1.ClientID%>");
                        oWnd.setUrl(encodeURI("TextbookAdd.aspx?Id=" + "")); //
                        oWnd.show();
                        //oWnd.setSize(800, 380);
                        args.set_cancel(true);
                    }
                    else if (command == "Delete") {
                        a = confirm("确认删除?");
                        if (a == true) {
                            refreshGrid("Delete");
                            args.set_cancel(true);
                        }
                        else {
                            args.set_cancel(true);
                        }
                    }
                    else if (command == "Help") {
                        refreshGrid("Help");
                        args.set_cancel(true);
                    }
                }
                //Grid编辑
                function OnClientUpdateCommand(textbookId) {
                    var oWnd = $find("<%=RadWindow1.ClientID%>");
                    oWnd.setUrl(encodeURI("TextbookAdd.aspx?Id=" + textbookId)); //
                    oWnd.show();
                    //oWnd.setSize(800, 380);
                }
                //异步回调,刷新Grid
                function refreshGrid(arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(arg);
                }
            </script>
        </telerik:RadCodeBlock>

        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1" UpdatePanelsRenderMode="Inline"
                                OnAjaxRequest="RadAjaxManager1_OnAjaxRequest">
            <ClientEvents OnRequestStart="onRequestStart" />
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="GdTextbooks" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="GdTextbooks">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="GdTextbooks" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>

        <div>
            <cp:CPMisToolBar ID="ToolBar1" OnClientButtonClicking="OnToolBarButtonClicked" runat="server" SkinID="Auto">
                <Items>
                    <telerik:RadToolBarButton Text="添加" CommandName="Add" ToolTip="新建教材" ImageUrl="../../Img/tlb_Add.png">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton Text="删除" CommandName="Delete" ToolTip="删除选中的教材" ImageUrl="../../Img/tlb_Delete.png">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton Text="帮助" CommandName="Help" ToolTip="点击获取帮助" ImageUrl="../../Img/tlb_Help.png">
                    </telerik:RadToolBarButton>
                </Items>
            </cp:CPMisToolBar>

            <cp:CPMisTabStrip ID="TabStrip1" runat="server" MultiPageID="MpTextbookManage" >
                <Tabs>
                    <cp:CPMisTab Text="教材管理(F)" AccessKey="F">
                    </cp:CPMisTab>
                </Tabs>
            </cp:CPMisTabStrip>
            <cp:CPMisMultiPage ID="MpTextbookManage" runat="server" SkinID="Auto">
                <cp:CPMisPageView ID="PvTextbookManage" runat="server">
                    <%--查询--%>
                    <div id="div1" runat="server" style="padding-left: 5px; padding-top: 2px; text-align: left; background-color: #E1EBF7;">
                        <cp:CPMisLabel ID="CPMisLabel3" runat="server" Text="教材名称：" SkinID="AutoSize"></cp:CPMisLabel>&nbsp;&nbsp;
                        <cp:CPMisTextBox runat="server" ID="TxtTextbookName" SkinID="AutoSize"></cp:CPMisTextBox>&nbsp;&nbsp;
                        <cp:CPMisLabel ID="CPMisLabel4" runat="server" Text="ISBN：" SkinID="AutoSize"></cp:CPMisLabel>&nbsp;&nbsp;
                        <cp:CPMisTextBox runat="server" ID="TxtIsbn" SkinID="AutoSize"></cp:CPMisTextBox>&nbsp;&nbsp;
                        <cp:CPMisButton runat="server" ID="BtnQuery" Text="查询" OnClick="BtnQuery_OnClick"></cp:CPMisButton>
                    </div>
                    <%--查询结果"--%>
                    <cp:CPMisGrid ID="GdTextbooks" runat="server" CheckControlID="ChkRow" SkinID="AutoPages" 
                        OnBeforeDataBind="GdTextbooks_OnBeforeDataBind" OnItemCommand="GdTextbooks_OnItemCommand"
                        OnBeforePageIndexChanged="GdTextbooks_OnBeforePageIndexChanged">
                        <MasterTableView>
                            <Columns>
                                <%--序号--%>
                                <telerik:GridTemplateColumn HeaderText="序号" HeaderStyle-Width="40px">
                                    <ItemTemplate><%#Container .DataSetIndex +1 %></ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <%--复选框--%>
                                <telerik:GridTemplateColumn UniqueName="CheckFlag" DataField="CheckFlag">
                                    <HeaderTemplate>
                                        <cp:CPMisCheckBox ID="ChkAll" AutoPostBack="true" runat="server" OnCheckedChanged="ChkAll_OnCheckedChanged" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <cp:CPMisCheckBox ID="ChkRow" runat="server" Checked='<% #Eval("CheckFlag") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle Width="30px"></HeaderStyle>
                                </telerik:GridTemplateColumn>
                                <%--编辑按钮--%>
                                <telerik:GridTemplateColumn HeaderText="编辑" >
                                    <ItemTemplate>
                                        <img alt="编辑教材" src="../../Img/GridEdit.png" onclick="OnClientUpdateCommand('<%# Eval("TextbookId") %>')" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="40px"></HeaderStyle>
                                </telerik:GridTemplateColumn>
                                <%--数据列--%>
                                <telerik:GridBoundColumn DataField="TextbookId" UniqueName="TextbookId" Visible="false"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="教材名称" DataField="Name" HeaderStyle-Width="120px"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="ISBN" DataField="ISBN" HeaderStyle-Width="120px"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="作者" DataField="Author"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="出版社" DataField="Press" HeaderStyle-Width="120px"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="定价" DataField="Price" DataFormatString="{0:C}"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="版本" DataField="Edition"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="版次" DataField="PrintCount"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="教材类型" DataField="TextbookType" HeaderStyle-Width="120px"></telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="功能">
                                    <ItemTemplate>
                                        <cp:CPMisLinkButton ID="LnkShow"  CommandName="Show" Text="查看" runat="server"></cp:CPMisLinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                            </Columns>
                        </MasterTableView>
                    </cp:CPMisGrid>
                </cp:CPMisPageView>
            </cp:CPMisMultiPage>


            <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
                <Windows>
                    <telerik:RadWindow ID="RadWindow1" runat="server" Top="100" Left="100" Width="800" Height="380">
                    </telerik:RadWindow>
                </Windows>
            </telerik:RadWindowManager>
        </div>
    </form>
</body>
</html>





