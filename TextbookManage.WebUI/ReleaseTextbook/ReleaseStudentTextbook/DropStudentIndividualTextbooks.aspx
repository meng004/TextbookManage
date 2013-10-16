<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DropStudentIndividualTextbooks.aspx.cs"
    Inherits="CPMis.WebPage.Tb_PSS.Tb_PSS_07.IndividualDropTextbooks" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
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
        
        .cell11, .cell12, .cell21, .cell22
        {
            border: 0px margin: 0px;
            padding: 0px;
            height: 30px;
        }
        
        .cell11, .cell21
        {
            text-align: right;
        }
        .cell12, .cell22
        {
            text-align: center;
            width: 180px;
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
        <ClientEvents OnRequestStart="onRequestStart" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdReleaseStudentTextbook" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ccmbSchool">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ccmbProfessionalClass" />
                    <telerik:AjaxUpdatedControl ControlID="ccmbStudentName" />
                    <telerik:AjaxUpdatedControl ControlID="ctxtTelephone" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ccmbGrade">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ccmbProfessionalClass" />
                    <telerik:AjaxUpdatedControl ControlID="ccmbStudentName" />
                    <telerik:AjaxUpdatedControl ControlID="ctxtTelephone" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ccmbProfessionalClass">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ccmbStudentName" />
                    <telerik:AjaxUpdatedControl ControlID="ctxtTelephone" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ccmbStudentName">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdReleaseStudentTextbook" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ccmbStockName">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdReleaseStudentTextbook" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cbtnQuery">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdReleaseStudentTextbook" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cbtnDrop">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdReleaseStudentTextbook" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cgrdReleaseStudentTextbook">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdReleaseStudentTextbook" LoadingPanelID="RadAjaxLoadingPanel1" />
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
        //教材详单弹窗
        function OnClientBookDetailMessageCommand(TextbookId) {
            var oWnd = $find("<%=wdw_TextbookDetailMessage.ClientID%>");
            oWnd.setUrl(encodeURI("../../Tb_Query/TextbookDetailMessage.aspx?TextbookId=" + TextbookId)); //
            oWnd.show();
            oWnd.setSize(450, 290);
        }
        //复选框全选或反选
        function selectAll(ctlName, bool) {
            var ctl = document.getElementById(ctlName); //根据控件的在客户端所呈现的ID获取控件
            var checkbox = ctl.getElementsByTagName('input'); //获取该控件内标签为input的控件          
            for (var i = 0; i < checkbox.length; i++) {
                if (checkbox[i].type == 'checkbox') {
                    checkbox[i].checked = bool;
                }
            }
        }

    </script>
    <div id="tool" runat="server" class="sty_div">
        <utm:UTMisToolBar ID="CPMisToolBar1" runat="server" SkinID="Long">
            <Items>
                <telerik:RadToolBarButton runat="server" CommandName="help" Text="帮助" ImageUrl="~/Img/tlb_Help.png">
                </telerik:RadToolBarButton>
            </Items>
        </utm:UTMisToolBar>
    </div>
    <div>
        <utm:UTMisTabStrip runat="server" ID="tabStrip" MultiPageID="cmtpTeacherTextbook"
            SkinID="Long">
            <Tabs>
                <utm:UTMisTab Text="个人教材退回">
                </utm:UTMisTab>
            </Tabs>
        </utm:UTMisTabStrip>
        <utm:UTMisMultiPage runat="server" ID="cmtpStudentTextbook" SkinID="Long">
            <utm:UTMisPageView ID="CPMisPageView1" runat="server">
                <div id="div_choose" runat="server" style="padding-left: 5px; padding-top: 2px; text-align: left;
                    background-color: #E1EBF7;">
                    <table class="table" cellpadding="0px" cellspacing="0px">
                        <tr>                           
                            <td class="cell12" style="width: 210px">
                                <utm:UTMisComboBox runat="server" ID="ccmbSchool" Label="学院" AutoPostBack="True" DataTextField="SchoolName"
                                    DataValueField="SchoolID" OnSelectedIndexChanged="ccmbSchool_OnSelectedIndexChanged"
                                    SkinID="cmb200">
                                </utm:UTMisComboBox>
                                <asp:SqlDataSource ID="SqlDataSource_School" runat="server" ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>"
                                    ProviderName="System.Data.SqlClient" SelectCommand="prStudentSubscriptionPlanGetSchoolNameListByBooksellerID"
                                    SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:ProfileParameter Name="BooksellerID" PropertyName="UserInGroupID" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>                           
                            <td class="cell12" style="width: 100px">
                                <utm:UTMisComboBox runat="server" ID="ccmbGrade" Label="年级" AutoPostBack="True" SkinID="cmb80"
                                    DataSourceID="SqlDataSource_Grade" DataTextField="grade" DataValueField="grade"
                                    SelectedText="" OnSelectedIndexChanged="ccmbGrade_OnSelectedIndexChanged">
                                </utm:UTMisComboBox>
                                <asp:SqlDataSource ID="SqlDataSource_Grade" runat="server" ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>"
                                    ProviderName="System.Data.SqlClient" SelectCommand="prGradeGetList" SelectCommandType="StoredProcedure">
                                </asp:SqlDataSource>
                            </td>                          
                            <td class="cell12">
                                <utm:UTMisComboBox runat="server" ID="ccmbProfessionalClass" Label="专业班级" AutoPostBack="True" DataTextField="ClassName"
                                    DataValueField="ClassID" OnSelectedIndexChanged="ccmbProfessionalClass_OnSelectedIndexChanged">
                                </utm:UTMisComboBox>
                                <asp:SqlDataSource ID="ControlDataSource_Class" runat="server" ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>"
                                    ProviderName="System.Data.SqlClient" SelectCommand="prProfessionalClassGetListByCondition"
                                    SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ccmbSchool" Name="SchoolID" PropertyName="SelectedValue"
                                            DbType="Guid" />
                                        <asp:ControlParameter ControlID="ccmbGrade" Name="Grade" PropertyName="SelectedValue"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>                           
                            <td class="cell12" style="width: 190px">
                                <utm:UTMisComboBox runat="server" ID="ccmbStudentName" Label="学生" AutoPostBack="true" SkinID="cmb180"
                                    OnSelectedIndexChanged="ccmbStudentName_OnSelectedIndexChanged" DataTextField="StudentNumAndName"
                                    DataValueField="StudentID">
                                </utm:UTMisComboBox>
                                <asp:SqlDataSource ID="SessionDataSource_ccmbStudentName" runat="server" ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>"
                                    ProviderName="System.Data.SqlClient" SelectCommand="prStudentGetInfoByClassID"
                                    SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ccmbProfessionalClass" Name="ClassID" PropertyName="SelectedValue"
                                            DbType="Guid" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                            <td>
                                <utm:UTMisButton ID="cbtnQuery" runat="server" Text="查询" OnClick="cbtnQuery_Click" />&nbsp;&nbsp;
                                <utm:UTMisButton ID="cbtnDrop" runat="server" Text="退还教材" OnClick="cbtnDrop_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <utm:UTMisGrid runat="server" ID="cgrdReleaseStudentTextbook" SkinID="Long" AutoGenerateColumns="False"
                        AllowMultiRowSelection="true" OnBeforeDataBind="cgrdReleaseStudentTextbook_OnBeforeDataBind">
                        <MasterTableView DataKeyNames="StudentReleaseDetailID">
                            <Columns>
                                <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" HeaderStyle-Width="40px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="headerchb" runat="server" onclick="javascript:selectAll('cgrdReleaseStudentTextbook',this.checked);">
                                        </asp:CheckBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chbTemplate" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="序号" HeaderStyle-Width="40px">
                                    <ItemTemplate>
                                        <%#Container .DataSetIndex +1 %></ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn HeaderText="学年学期" DataField="Term" UniqueName="Term">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="书商名称" DataField="BooksellerName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="仓库名称" DataField="StockName" UniqueName="StockName">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="教材名称" DataField="TextbookName" HeaderStyle-Width="160px">
                                    <ItemTemplate>
                                        <a href="#" onclick='<%# "OnClientBookDetailMessageCommand(\""+Eval("TextbookId")+"\")" %>'>
                                            <%# Eval("TextbookName")%></a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn HeaderText="发放数量" DataField="ReleaseCount">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="发放日期" DataField="ReleaseDate" UniqueName="ReleaseDate">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="发放人" DataField="ReleasePerson" UniqueName="ReleasePerson">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="领用人" DataField="Recipient" UniqueName="Recipient">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="联系方式" DataField="Telephone" UniqueName="Telephone">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </utm:UTMisGrid>
                </div>
            </utm:UTMisPageView>
        </utm:UTMisMultiPage>
    </div>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        <Windows>
            <telerik:RadWindow ID="wdw_TextbookDetailMessage" runat="server" Top="150" Left="350"
                ReloadOnShow="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    </form>
</body>
</html>
