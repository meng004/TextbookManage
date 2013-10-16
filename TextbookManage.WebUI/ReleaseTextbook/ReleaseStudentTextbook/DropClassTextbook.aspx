<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DropClassTextbook.aspx.cs"
    Inherits="CPMis.WebPage.Tb_PSS.Tb_PSS_07.ClassDropTextbook" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .border
        {
            border: 0;
            margin: 0;
            padding: 0;
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
                    <telerik:AjaxUpdatedControl ControlID="cgrdClassReleaseQuery" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cbtnQuery">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdClassReleaseQuery" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ccmbSchool">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ccmbProfessionalClass" />
                    <telerik:AjaxUpdatedControl ControlID="ccmbGrade" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cbtnDrop">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdClassReleaseQuery" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ccmbGrade">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ccmbProfessionalClass" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ccmbProfessionalClass">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdClassReleaseQuery" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cgrdClassReleaseQuery">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdClassReleaseQuery" LoadingPanelID="RadAjaxLoadingPanel1" />
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
        function OnClientBookDetailMessageCommand(TextbookId) {
            var oWnd = $find("<%=wdw_TextbookDetailMessage.ClientID%>");
            oWnd.setUrl(encodeURI("../../Tb_Query/TextbookDetailMessage.aspx?TextbookId=" + TextbookId)); //
            oWnd.show();
            oWnd.setSize(450, 280);
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
        //领用名单
        function OnRecipientStudent(TextbookId, ClassId,CommandName) {
            var oWnd = $find("<%=wdw_TextbookDetailMessage.ClientID%>");
            oWnd.setUrl(encodeURI("ClassDropTextbookForm.aspx?TextbookId=" + TextbookId + "&ClassId=" + ClassId + "&CommandName=" + CommandName)); //
            oWnd.show();
            oWnd.setSize(440, 400);
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
        <utm:UTMisTabStrip runat="server" ID="tabStrip" MultiPageID="cClassReleasePlan" SkinID="Long">
            <Tabs>
                <utm:UTMisTab Text="班级教材退回">
                </utm:UTMisTab>
            </Tabs>
        </utm:UTMisTabStrip>
        <utm:UTMisMultiPage runat="server" ID="cClassReleasePlan" SkinID="Long">
            <utm:UTMisPageView ID="CPMisPageView1" runat="server">
                <div id="div_choose" runat="server" style="padding-left: 5px; padding-top: 2px; text-align: left;
                    background-color: #E1EBF7;">
                    <table class="border">
                        <tr>
                            <td class="border">
                                <utm:UTMisLabel ID="clblSchool" runat="server" Text="学院：" SkinID="AutoSize">
                                </utm:UTMisLabel>
                            </td>
                            <td class="border">
                                <utm:UTMisComboBox runat="server" ID="ccmbSchool" AutoPostBack="True" DataTextField="SchoolName"
                                    DataValueField="SchoolID" OnSelectedIndexChanged="ccmbSchool_SelectedIndexChanged">
                                </utm:UTMisComboBox>
                                <asp:SqlDataSource ID="SqlDataSource_School" runat="server" ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>"
                                    ProviderName="System.Data.SqlClient" SelectCommand="prStudentSubscriptionPlanGetSchoolNameListByBooksellerID"
                                    SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:ProfileParameter Name="BooksellerID" PropertyName="UserInGroupID" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                            <td class="border">
                                <utm:UTMisLabel ID="clblGrade" runat="server" Text="年级：" SkinID="AutoSize">
                                </utm:UTMisLabel>
                            </td>
                            <td class="border">
                                <utm:UTMisComboBox runat="server" ID="ccmbGrade" AutoPostBack="True" SkinID="cmb120"
                                    DataTextField="grade" DataValueField="grade" OnSelectedIndexChanged="ccmbGrade_SelectedIndexChanged"
                                    DefaultIndex="0" IsCancelDataBind="False" IsMaintainSelectedValue="False" SelectedText="">
                                </utm:UTMisComboBox>
                                <asp:SqlDataSource ID="SqlDataSource_Grade" runat="server" ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>"
                                    ProviderName="System.Data.SqlClient" SelectCommand="prGradeGetList" SelectCommandType="StoredProcedure">
                                </asp:SqlDataSource>
                            </td>
                            <td class="border">
                                <utm:UTMisLabel ID="clblProfessionalClass" runat="server" Text="专业班级：" SkinID="AutoSize">
                                </utm:UTMisLabel>
                            </td>
                            <td class="border">
                                <utm:UTMisComboBox runat="server" ID="ccmbProfessionalClass" OnSelectedIndexChanged="ccmbProfessionalClass_SelectedIndexChanged"
                                    AutoPostBack="True" SkinID="cmb120" DataTextField="ClassName" DataValueField="ClassID">
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
                            <td class="border" style="width: 100px" align="right">
                                <utm:UTMisButton runat="server" ID="cbtnQuery" Text="查询" OnClick="cbtnQuery_Click">
                                </utm:UTMisButton>
                            </td>
                            <td>
                                <utm:UTMisButton runat="server" ID="cbtnDrop" Text="退还教材" OnClick="cbtnDrop_Click">
                                </utm:UTMisButton>
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <utm:UTMisGrid ID="cgrdClassReleaseQuery" runat="server" SkinID="Long"
                        OnBeforeDataBind="cgrdClassReleaseQuery_BeforeDataBind">
                        <MasterTableView DataKeyNames="TextbookId">
                            <Columns>
                                <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" HeaderStyle-Width="40px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="headerchb" runat="server" onclick="javascript:selectAll('cgrdClassReleaseQuery',this.checked);">
                                        </asp:CheckBox>
                                        <%--<asp:CheckBox ID="headerchb" runat="server" OnCheckedChanged="chbHeader_OnCheckedChanged" AutoPostBack="true">
                                    </asp:CheckBox>--%>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chbTemplate" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="序号" HeaderStyle-Width="40px">
                                    <ItemTemplate>
                                        <%#Container .DataSetIndex +1 %></ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn HeaderText="学年学期" DataField="Term" HeaderStyle-Width="100px">
                                </telerik:GridBoundColumn>
                               <%-- <telerik:GridBoundColumn HeaderText="学院" DataField="SchoolName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="专业班级" DataField="ProfessionalClass">
                                </telerik:GridBoundColumn>--%>
                                <telerik:GridBoundColumn HeaderText="课程名" DataField="CourseName" HeaderStyle-Width="120px">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="教材名称">
                                    <ItemTemplate>
                                        <a href="javascript:void(0)" onclick='<%# "OnClientBookDetailMessageCommand(\""+Eval("TextbookId")+"\")" %>'>
                                            <%# Eval("TextbookName")%></a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn HeaderText="已发数量" DataField="ReleaseCount" HeaderStyle-Width="70px">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="领用名单" DataField="TextbookName" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <a href="javascript:void(0)" onclick="javascript:OnRecipientStudent('<%# Eval("TextbookId") %>','<%=ccmbProfessionalClass.SelectedValue %>','Reset')">查看</a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </utm:UTMisGrid>
                </div>
            </utm:UTMisPageView>
        </utm:UTMisMultiPage>
    </div>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        <Windows>
            <telerik:RadWindow ID="wdw_TextbookDetailMessage" runat="server" Top="100" Left="200"
                ReloadOnShow="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    </form>
</body>
</html>
