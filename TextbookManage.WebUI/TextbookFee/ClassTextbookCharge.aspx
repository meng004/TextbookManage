<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassTextbookCharge.aspx.cs" Inherits="TextbookManage.WebUI.TextbookFee.ClassTextbookCharge" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .reportview
        {
            text-align: center;
        }
        .textcol, .table, .controlcol
        {
            border: 0px;
            padding: 0px;
            margin: 0px;
        }
        .textcol
        {
            text-align: right;
        }
        .controlcol
        {
            text-align: left;
        }
        .table
        {
            width: 995px;
            background-color: #E1EBF7;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
    </telerik:RadSkinManager>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
         <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </Scripts>
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
    <div>
        <utm:UTMisToolBar ID="toolbar" runat="server" SkinID="Long">
            <Items>
                <telerik:RadToolBarButton Text="帮助" ImageUrl="~/Img/tlb_Help.png" runat="server">
                </telerik:RadToolBarButton>
            </Items>
        </utm:UTMisToolBar>
    </div>
    <div style="width: 1000px">
        <utm:UTMisTabStrip ID="UTMisTabStrip1"  runat="server" SelectedIndex="0">
            <Tabs>
                <utm:UTMisTab runat="server" Text="打印班级教材费用结算単">
                </utm:UTMisTab>
            </Tabs>
        </utm:UTMisTabStrip>
      
                <table class="table">
                    <tr>
                        <td class="textcol">
                            学年学期
                        </td>
                        <td class="controlcol">&nbsp;&nbsp;
                            <utm:UTMisComboBox runat="server" ID="ccmbTerm"  DataTextField="YearTerm" OnBeforeDataBind="ccmbTerm_BeforeDataBind"
                                 AutoPostBack="true">
                            </utm:UTMisComboBox>
                         
                        </td>
                        <td class="textcol">
                            学院
                        </td>
                        <td class="controlcol">&nbsp;&nbsp;
                            <utm:UTMisComboBox runat="server" ID="ccmbSchool"  DataTextField="Name" OnBeforeDataBind="ccmbSchool_BeforeDataBind"  IsMaintainSelectedValue="true" OnAfterDataBind="ccmbSchool_AfterDataBind" OnSelectedIndexChanged="ccmbSchool_AfterDataBind"
                                DataValueField="SchoolId" AutoPostBack="true">
                            </utm:UTMisComboBox>
                        </td>
                        <td class="textcol">
                            年级
                        </td>
                        <td class="controlcol">&nbsp;&nbsp;
                            <utm:UTMisComboBox runat="server" ID="ccmbGrade" 
                                DataTextField="Grade"  AutoPostBack="true" IsMaintainSelectedValue="true" OnBeforeDataBind="ccmbGrade_BeforeDataBind" OnAfterDataBind="ccmbGrade_AfterDataBind" OnSelectedIndexChanged="ccmbGrade_AfterDataBind">
                            </utm:UTMisComboBox>
                        </td>
                         <td class="textcol">
                            专业班级
                        </td>
                        <td class="controlcol">&nbsp;&nbsp;
                            <utm:UTMisComboBox runat="server" ID="ccmbProfessionalClass" 
                                DataTextField="Name" DataValueField="ProfessionalClassId" IsMaintainSelectedValue="true" AutoPostBack="true" OnBeforeDataBind="ccmbProfessionalClass_BeforeDataBind">
                            </utm:UTMisComboBox>
                        </td>
                        <td class="controlcol">&nbsp;&nbsp;
                            <utm:UTMisButton runat="server" ID="cbtnQuery" Text="查询" />
                        </td>
                    </tr>
                </table>
    <div>
    <%--<div>
        <utm:UTMisGrid ID="rg_grid" runat="server" SkinID="AutoPages">
            <MasterTableView>
                <Columns>
                    <telerik:GridBoundColumn HeaderText="学号" DataField="StudentNum" HeaderStyle-Width="70">
                                </telerik:GridBoundColumn>
                               
                                <telerik:GridBoundColumn HeaderText="姓名" DataField="StudentName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="总数量" DataField="TotalCount">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="码洋" DataField="TotalRetailPrice">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="实洋" DataField="DiscountTotalPrice">
                                </telerik:GridBoundColumn>
                               
                </Columns>
            </MasterTableView>
        </utm:UTMisGrid>

    </div>--%>
    </div>
   
    </div>
    </form>
</body>
</html>
