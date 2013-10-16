<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReleaseStudentTextbook.aspx.cs"
    Inherits="CPMis.WebPage.Tb_PSS.Tb_PSS_02.ReleaseStudentTextbook" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .table {
            border: 0px;
            margin: 0px;
            padding: 0px;
            width: 990px;
        }

        .cell11, .cell12, .cell21, .cell22 {
            margin: 0px;
            padding: 0px;
            height: 35px;
        }

        .cell11, .cell12 {
            border: 1px;
            border-style: none none solid none;
        }

        .cell11, .cell21 {
            text-align: right;
        }

        .cell21, .cell22 {
            border: 0px;
        }

        .cell12, .cell22 {
            text-align: center;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
        </telerik:RadSkinManager>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline" OnAjaxRequest="RebindGridView">
            <ClientEvents OnRequestStart="onRequestStart" />
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdStudentTbSet" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbSchool">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ccmbProfessionalClass" />
                        <telerik:AjaxUpdatedControl ControlID="ccmbGrade" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbGrade">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ccmbProfessionalClass" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbProfessionalClass">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdStudentTbSet" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="ctxtStudentName1" />
                        <telerik:AjaxUpdatedControl ControlID="ctxtStudentNum1" />
                        <telerik:AjaxUpdatedControl ControlID="ctxtStudentName2" />
                        <telerik:AjaxUpdatedControl ControlID="ctxtStudentNum2" />
                        <telerik:AjaxUpdatedControl ControlID="ctxtTelephone1" />
                        <telerik:AjaxUpdatedControl ControlID="ctxtTelephone2" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ccmbStockName">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdStudentTbSet" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cbtnQuery">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdStudentTbSet" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="lbtnCheck1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ctxtStudentName1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="lbtnCheck2">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ctxtStudentName2" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cbtnRelease">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cbtnRelease" />
                        <telerik:AjaxUpdatedControl ControlID="cgrdStudentTbSet" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cgrdStudentTbSet">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cgrdStudentTbSet" LoadingPanelID="RadAjaxLoadingPanel1" />
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
        function OnRecipientStudent(InventoryId, TextbookId, ClassId, CommandName) {
            var oWnd = $find("<%=wdw_TextbookDetailMessage.ClientID%>");
            oWnd.setUrl(encodeURI("ReleaseStudentTextbookForm.aspx?InventoryId=" + InventoryId + "&TextbookId=" + TextbookId + "&ClassId=" + ClassId + "&CommandName=" + CommandName)); //
            oWnd.show();
            oWnd.setSize(440, 400);
        }
        //复选框全选或反选
        function selectAll(ctlName, bool) {
            var ctl = document.getElementById(ctlName); //根据控件的在客户端所呈现的ID获取控件
            var checkbox = ctl.getElementsByTagName('input'); //获取该控件内标签为input的控件
            /*所有Button、TextBox、CheckBox、RadioButton类型的服务器端控件在解释成Html控件后，都为<input type=''./>，通过type区分它们的类型。*/
            for (var i = 0; i < checkbox.length; i++) {
                if (checkbox[i].type == 'checkbox') {
                    checkbox[i].checked = bool;
                }
            }
        }
        function OnLostFocus1() {
            var temp = document.getElementById("<%=ctxtStudentNum1.ClientID%>").value;
            if (temp.length == 0) {
                alert("请输入领用人学号！");
            }
            else {
                document.getElementById("lbtnCheck1").click();
            }
        }

        function OnLostFocus2() {
            var temp = document.getElementById("<%=ctxtStudentNum2.ClientID%>").value;
            if (temp.length == 0) {
                alert("请输入领用人学号！");
            }
            else {
                document.getElementById("lbtnCheck2").click();
            }
        }

        function CheckTelephone1() {
            var temp = $find("<%=ctxtTelephone1.ClientID%>");
            var reg = /^[0-9]{11}$/;
            if (temp.get_value().length == 0) {
                alert("请输入联系方式！");
            }
            else if (reg.test(temp.get_value()) == false) {
                alert("你的联系方式格式不正确！");
                temp.set_value("");
                temp.focus();
            }
        }
        function CheckTelephone2() {
            var temp = $find("<%=ctxtTelephone2.ClientID%>");
            var reg = /^[0-9]{11}$/;
            if (temp.get_value().length == 0) {
                alert("请输入联系方式！");
            }
            else if (reg.test(temp.get_value()) == false) {
                alert("你的联系方式格式不正确！");
                temp.set_value("");
                temp.focus();
            }
        }
        function popPrintWindow() {
            window.open("../../ReportViewsUI/StudentTextbookReleasePrint.aspx", "_blank");
            //            var oWnd = $find("<%=wdw_TextbookDetailMessage.ClientID%>");
            //            oWnd.setUrl(encodeURI("~/ReportViewsUI/StudentTextbookReleasePrint.aspx"));
            //            oWnd.Title = "学生教材发放单打印预览";
            //            oWnd.show();
            //            oWnd.setSize(980, 550);
            //            oWnd.top = 10;
            //            oWnd.left = 10;
        }
            //异步回调,刷新grid
            function refreshGrid(arg) {
                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(arg);
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
        <div>
            <utm:UTMisTabStrip runat="server" MultiPageID="mp" SkinID="Long">
                <Tabs>
                    <utm:UTMisTab runat="server" Text="发放学生教材" Selected="true">
                    </utm:UTMisTab>
                </Tabs>
            </utm:UTMisTabStrip>
            <utm:UTMisMultiPage runat="server" ID="mp" SkinID="Long">
                <utm:UTMisPageView Selected="true" runat="server" ID="ReleaseStudentTbPage">
                    <div id="Div1" runat="server" style="padding-left: 5px; padding-top: 2px; text-align: left; background-color: #E1EBF7;">
                        <table class="table" cellpadding="0px" cellspacing="0px">
                            <tr>
                                <td class="cell11">
                                    <utm:UTMisLabel runat="server" Text="学院" SkinID="Average">
                                    </utm:UTMisLabel>
                                </td>
                                <td class="cell12">
                                    <utm:UTMisComboBox runat="server" ID="ccmbSchool" AutoPostBack="True"
                                        DataTextField="SchoolName" DataValueField="SchoolID" OnSelectedIndexChanged="ccmbSchool_OnSelectedIndexChanged">
                                    </utm:UTMisComboBox>
                                    <asp:SqlDataSource ID="SqlDataSource_School" runat="server" ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>"
                                        ProviderName="System.Data.SqlClient" SelectCommand="prStudentSubscriptionPlanGetSchoolNameListByBooksellerID" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:ProfileParameter Name="BooksellerID" PropertyName="UserInGroupID" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                                <td class="cell11">
                                    <utm:UTMisLabel runat="server" Text="年级">
                                    </utm:UTMisLabel>
                                </td>
                                <td class="cell12">
                                    <utm:UTMisComboBox runat="server" ID="ccmbGrade" AutoPostBack="True" SkinID="cmb120"
                                        DataTextField="grade" DataValueField="grade" OnSelectedIndexChanged="ccmbGrade_OnSelectedIndexChanged"
                                        DefaultIndex="0" IsCancelDataBind="False" IsMaintainSelectedValue="False" SelectedText="">
                                    </utm:UTMisComboBox>
                                    <asp:SqlDataSource ID="SqlDataSource_Grade" runat="server" ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>"
                                        ProviderName="System.Data.SqlClient" SelectCommand="prGradeGetList" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                </td>
                                <td class="cell11">
                                    <utm:UTMisLabel runat="server" Text="专业班级">
                                    </utm:UTMisLabel>
                                </td>
                                <td class="cell12">
                                    <utm:UTMisComboBox runat="server" ID="ccmbProfessionalClass" OnSelectedIndexChanged="ccmbProfessionalClass_OnSelectedIndexChanged"
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
                                <td class="cell11">
                                    <utm:UTMisLabel runat="server" Text="仓库名称" SkinID="AutoSize"></utm:UTMisLabel>
                                </td>
                                <td class="cell12">
                                    <utm:UTMisComboBox runat="server" ID="ccmbStockName" DataSourceID="SessionDataSource_ccmbStockName"
                                        AutoPostBack="true" SkinID="cmb120" OnSelectedIndexChanged="ccmbStockName_OnSelectedIndexChanged"
                                        DataTextField="StockName" DataValueField="StockID">
                                    </utm:UTMisComboBox>
                                    <asp:SqlDataSource ID="SessionDataSource_ccmbStockName" runat="server" ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>"
                                        ProviderName="System.Data.SqlClient" SelectCommand="prStockGetListByBooksellerID"
                                        SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:ProfileParameter Name="BooksellerID" PropertyName="UserInGroupID" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                                <td class="cell12">
                                    <utm:UTMisButton ID="cbtnQuery" runat="server" Text="查询" OnClick="cbtnQuery_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="cell21">
                                    <utm:UTMisLabel runat="server" Text="领用人学号" SkinID="AutoSize"></utm:UTMisLabel>
                                </td>
                                <td class="cell22">
                                    <utm:UTMisTextBox runat="server" ID="ctxtStudentNum1" SkinID="tb160" onblur="OnLostFocus1()">
                                    </utm:UTMisTextBox>
                                    <utm:UTMisLinkButton ID="lbtnCheck1" runat="server" Text="" OnClick="lbtnCheck1_Click"></utm:UTMisLinkButton>
                                </td>
                                <td class="cell21">
                                    <utm:UTMisLabel runat="server" Text="领用人姓名" SkinID="AutoSize"></utm:UTMisLabel>
                                </td>
                                <td class="cell22">
                                    <utm:UTMisTextBox ID="ctxtStudentName1" runat="server" SkinID="txt120" Enabled="false">
                                    </utm:UTMisTextBox>
                                </td>
                                <td class="cell21">
                                    <utm:UTMisLabel runat="server" Text="联系方式" SkinID="AutoSize"></utm:UTMisLabel>
                                </td>
                                <td class="cell22">
                                    <utm:UTMisTextBox ID="ctxtTelephone1" runat="server" SkinID="txt120" onblur="CheckTelephone1()">
                                    </utm:UTMisTextBox>
                                </td>
                                <td class="cell22" colspan="3">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="cell21">
                                    <utm:UTMisLabel runat="server" Text="领用人学号" SkinID="AutoSize"></utm:UTMisLabel>
                                </td>
                                <td class="cell22">
                                    <utm:UTMisTextBox runat="server" ID="ctxtStudentNum2" SkinID="tb160" onblur="OnLostFocus2()">
                                    </utm:UTMisTextBox>
                                    <utm:UTMisLinkButton ID="lbtnCheck2" runat="server" Text="" OnClick="lbtnCheck2_Click"></utm:UTMisLinkButton>
                                </td>
                                <td class="cell21">
                                    <utm:UTMisLabel runat="server" Text="领用人姓名" SkinID="AutoSize"></utm:UTMisLabel>
                                </td>
                                <td class="cell22">
                                    <utm:UTMisTextBox ID="ctxtStudentName2" runat="server" SkinID="txt120" Enabled="false">
                                    </utm:UTMisTextBox>
                                </td>
                                <td class="cell21">
                                    <utm:UTMisLabel runat="server" Text="联系方式" SkinID="AutoSize"></utm:UTMisLabel>
                                </td>
                                <td class="cell22">
                                    <utm:UTMisTextBox ID="ctxtTelephone2" runat="server" SkinID="txt120" onblur="CheckTelephone2()">
                                    </utm:UTMisTextBox>
                                </td>
                                <td class="cell22">&nbsp;&nbsp;&nbsp;
                                <utm:UTMisButton ID="cbtnRelease" runat="server" Text="发放" ToolTip="先勾选要发放的教材，然后再发放"
                                    OnClick="cbtnRelease_Click" />


                                </td>
                                <td class="cell22" colspan="2">
                                    <utm:UTMisButton ID="cbtnPrint" runat="server" Text="打印"
                                        OnClick="cbtnPrint_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div>
                        <utm:UTMisGrid ID="cgrdStudentTbSet" runat="server" SkinID="Long" AutoGenerateColumns="False"
                            OnBeforeDataBind="cgrdStudentTbSet_OnBeforeDataBind" AllowMultiRowSelection="true"
                            OnItemDataBound="cgrdStudentTbSet_ItemDataBound">
                            <MasterTableView DataKeyNames="InventoryID,TextbookId,PlanCount,StoreCount,ReleaseCount,ShelfNumber,CourseName">
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" HeaderStyle-Width="40px">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="headerchb" runat="server" onclick="javascript:selectAll('cgrdStudentTbSet',this.checked);"></asp:CheckBox>
                                            <%--<asp:CheckBox ID="headerchb" runat="server" OnCheckedChanged="chbHeader_OnCheckedChanged" AutoPostBack="true">
                                    </asp:CheckBox>--%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chbTemplate" runat="server"></asp:CheckBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="序号" HeaderStyle-Width="40px">
                                        <ItemTemplate>
                                            <%#Container .DataSetIndex +1 %>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn HeaderText="学年学期" DataField="Term" UniqueName="Term" HeaderStyle-Width="100px">
                                    </telerik:GridBoundColumn>
                                    <%--    <telerik:GridBoundColumn HeaderText="学院" DataField="School" UniqueName="School">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="专业班级" DataField="ProfessionalClass" UniqueName="ProfessionalClass">
                                </telerik:GridBoundColumn>--%>
                                    <%--  <telerik:GridBoundColumn HeaderText="课程号" DataField="CourseNum" UniqueName="CourseNum" HeaderStyle-Width="80px">
                                </telerik:GridBoundColumn>--%>
                                    <%-- <telerik:GridBoundColumn HeaderText="课程名称" DataField="CourseName" UniqueName="CourseName">
                                </telerik:GridBoundColumn>--%>
                                    <telerik:GridTemplateColumn HeaderText="教材名称" DataField="TextbookName">
                                        <ItemTemplate>
                                            <a href="#" onclick='<%# "OnClientBookDetailMessageCommand(\""+Eval("TextbookId")+"\")" %>'>
                                                <%# Eval("TextbookName")%></a>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn HeaderText="架位号" DataField="ShelfNumber" UniqueName="ShelfNumber" HeaderStyle-Width="180px"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="发放数量" DataField="ReleaseCount" UniqueName="ReleaseCount" HeaderStyle-Width="90px"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="计划数量" DataField="PlanCount" UniqueName="PlanCount" HeaderStyle-Width="90px">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="库存数量" DataField="StoreCount" UniqueName="StoreCount" HeaderStyle-Width="90px">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="领用名单" DataField="TextbookName" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <utm:UTMisLinkButton runat="server" ID="lbtnChange" Text="更改" OnClick="lbtnChange_Click"></utm:UTMisLinkButton>
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
                <telerik:RadWindow ID="wdw_TextbookDetailMessage" runat="server" Top="150" Left="400"
                    ReloadOnShow="true">
                </telerik:RadWindow>
                <telerik:RadWindow ID="wdw_PrintPreview" runat="server" Top="20" Left="5"
                    ReloadOnShow="true">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </form>
</body>
</html>
