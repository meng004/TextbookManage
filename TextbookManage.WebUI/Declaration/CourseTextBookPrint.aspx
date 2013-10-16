<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseTextbookPrint.aspx.cs"
Inherits="TextbookManage.WebUI.Declaration.CourseTextbookPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>课程教材打印</title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div id="main">
       
                <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                </telerik:RadScriptManager>
                <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
                </telerik:RadSkinManager>
                <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
                <%--TabStrip--%>
                <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
                </telerik:RadStyleSheetManager>
                <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="ddl_Yea1rTerm" />
                                <telerik:AjaxUpdatedControl ControlID="ddl_Office" />
                                <telerik:AjaxUpdatedControl ControlID="ddl_School" />
                                <telerik:AjaxUpdatedControl ControlID="btn_Preveiw" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="ddl_Yea1rTerm">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="ddl_Office" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                <telerik:AjaxUpdatedControl ControlID="ddl_School"/>
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="cb_DataSign">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="ddl_Office" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                <telerik:AjaxUpdatedControl ControlID="ddl_School"/>
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="ddl_School">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="ddl_Office" LoadingPanelID="RadAjaxLoadingPanel1"/>
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManager>
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
                </telerik:RadAjaxLoadingPanel>
                <utm:UTMisTabStrip ID="tab_CourseTextBookPrint" runat="server" MultiPageID="mp_CourseTextBookPrint">
                    <Tabs>
                        <utm:UTMisTab Text="课程教材打印(P)" AccessKey="P" PageViewID="pv_CourseTextBookPrint">
                        </utm:UTMisTab>
                    </Tabs>
                </utm:UTMisTabStrip>
                <utm:UTMisMultiPage ID="mp_CourseTextBookPrint" runat="server">
                    <utm:UTMisPageView ID="pv_CourseTextBookPrint" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <utm:UTMisLabel ID="lbl_YearTerm" runat="server" Text="学年学期：" >
                                    </utm:UTMisLabel>
                                </td>
                                <td>
                                    <utmbc:TermDropDownList ID="ddl_Yea1rTerm" runat="server" AutoPostBack="true" CssClass="DDL160"
                                                            OnAfterDataBind="ddl_Yea1rTerm_Bind" OnSelectedIndexChanged="ddl_Yea1rTerm_Bind" >
                                    </utmbc:TermDropDownList>
                                </td>
                                <td>
                                    <utm:UTMisLabel ID="lbl_DataSign" runat="server" Text="数据标识：">
                                    </utm:UTMisLabel>
                            
                                </td>
                                <td>
                                    <utmbc:DataIdentityDropDownList ID="cb_DataSign" runat="server" AutoPostBack="true" 
                                                                    OnSelectedIndexChanged="ddl_Yea1rTerm_Bind" OnAfterDataBind="ddl_Yea1rTerm_Bind" >
                                    </utmbc:DataIdentityDropDownList>
                                </td>
                                <td>
                                    <utm:UTMisLabel ID="lbl_School" runat="server" Text="学院：" >
                                    </utm:UTMisLabel>
                                </td>
                                <td>
                                    <utm:UTMisComboBox ID="ddl_School"  AutoPostBack="true" OnBeforeDataBind="ddl_School_beforeBind" 
                                                       OnAfterDataBind="ddl_Office_Bind" OnSelectedIndexChanged="ddl_Office_Bind" runat="server" 
                                                       CssClass="DDL160" IsShowAllSchool="true">
                                    </utm:UTMisComboBox>
                                </td>
                                <td>
                                    <utm:UTMisLabel ID="lbl_Office" runat="server" Text="教研室：" >
                                    </utm:UTMisLabel>
                                </td>
                                <td>
                                    <utm:UTMisComboBox ID="ddl_Office" OnBeforeDataBind="ddl_Office_BeforeDataBind" 
                                                       runat="server" CssClass="DDL160">
                                    </utm:UTMisComboBox>
                                    <utmbc:ReportDropDownList ID="ddl_ReportType" Visible="false" runat="server" CssClass="DDL180" ReportID="a40102">
                                    </utmbc:ReportDropDownList>
                                </td>
                                <td>
                                    <utm:UTMisButton ID="btn_Preveiw" runat="server" Text="预 览" OnClick="btn_Preveiw_Click" />
                                </td>
                            </tr>
                        </table>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <utm:UTMisReportViewer  ID="rpv_CourseTextBookPrint" runat="server" Width="990px" Height="500px" OnBeforeReportPrint="rpv_CourseTextBookPrint_beforeDataBind">
                                </utm:UTMisReportViewer>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </utm:UTMisPageView>
                </utm:UTMisMultiPage>
            </div>
        </form>
    </body>
</html>
