<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseTypeUpdate.aspx.cs"
    Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_20.CourseTypeUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .Red
        {
            color: Red;
        }
        .Border
        {
            margin: 0;
            border: 0;
            padding: 0;
            margin-right:auto;
            margin-left:auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
    </telerik:RadSkinManager>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cdlstCourseType">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ctxtCourseType" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" />
    <div id="tool" runat="server" class="sty_div">
        <cp:CPMisToolBar ID="CPMisToolBar1" runat="server" SkinID="Long">
            <Items>
                <telerik:RadToolBarButton runat="server" CommandName="help" Text="帮助" ImageUrl="~/Img/tlb_Help.png">
                </telerik:RadToolBarButton>
            </Items>
        </cp:CPMisToolBar>
    </div>
    <div>
        <cp:CPMisTabStrip runat="server" ID="tabStrip" MultiPageID="cterm" SkinID="Long">
            <Tabs>
                <cp:CPMisTab Text="修改课程类型信息">
                </cp:CPMisTab>
            </Tabs>
        </cp:CPMisTabStrip>
        <cp:CPMisMultiPage runat="server" ID="cterm" SkinID="Long">
            <cp:CPMisPageView ID="CPMisPageView1" runat="server">
                <table class="Border">
                    <tr>
                        <td class="Border" style="text-align: center;">
                            <cp:CPMisLabel ID="clalCourseType" runat="server" Text="课程类型：">
                            </cp:CPMisLabel>
                        </td>
                        <td class="Border">
                            <cp:CPMisComboBox ID="cdlstCourseType" runat="server" DataTextField="CourseTypeName"
                                DataValueField="CourseTypeNum" AutoPostBack="true" OnSelectedIndexChanged="cdlstCourseType_IndexChanged">
                            </cp:CPMisComboBox>
                        </td>
                        <td class="Border">
                            <cp:CPMisLabel ID="clalCourseTypeExample" runat="server" Enabled="False" IsCancelDataBind="False"
                                SkinID="Auto" Text=" "></cp:CPMisLabel>
                        </td>
                    </tr>
                    <tr class="Border">
                        <td class="Border" style="text-align: center;">
                            <cp:CPMisLabel ID="clalCourseType1" runat="server" Text="课程类型：">
                            </cp:CPMisLabel>
                        </td>
                        <td class="Border">
                            <cp:CPMisTextBox ID="ctxtCourseType" runat="server">
                            </cp:CPMisTextBox>
                        </td>
                        <td class="Border">
                            <cp:CPMisLabel ID="clalCourseTypeExample1" runat="server" Text="如：实践、理论" Enabled="False"
                                IsCancelDataBind="False" SkinID="Auto">
                            </cp:CPMisLabel>
                        </td>
                    </tr>
                    </asp:RegularExpressionValidator>
                    <tr>
                        <td colspan="3" style="text-align: center; border: 0px; padding-top:10px;">
                            <cp:CPMisButton ID="cbtnSave" runat="server" Text="保存" SkinID="bt60" OnClick="cbtnSave_click"
                                ValidationGroup="BaseInfoGroup" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <cp:CPMisButton ID="cbtnCancle" runat="server" Text="取消" SkinID="bt60" OnClick="cbtnCancle_click" />
                        </td>
                    </tr>
                </table>
                <br />
            </cp:CPMisPageView>
        </cp:CPMisMultiPage>
    </div>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    </form>
</body>
</html>
