<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TermAdd.aspx.cs" Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_2.TermAdd" %>

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
            margin-left:auto;
            margin-right:auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:radskinmanager id="RadSkinManager1" runat="server">
    </telerik:radskinmanager>
    <telerik:radscriptmanager id="RadScriptManager1" runat="server">
    </telerik:radscriptmanager>
    <script type="text/javascript" language="javascript">
        function OnClientValidateClick(GroupName)
        {
            Page_ClientValidate(GroupName); //先验证
            if (Page_IsValid)
            {
                return confirm('确认新增?'); //之后进行新增
            } else
            {
                return false;
            }
        }

        //检查文本框的输入是否有效
        function MyCustomValidation(objSource, objArgs)
        {
            // Get value.
            var stringTerm = objArgs.Value.toString();  //接收文本框的输入
            objArgs.IsValid = true; //初始值为true

            var length = stringTerm.length; //字符串的长度
            //使用Substring进行处理string
            var year1 = stringTerm.substr(0, 4); //start at 0,length is 4;  year1
            var year2 = stringTerm.substr(5, 4); //year2
            var term = stringTerm.substr(10, 1); //学期

            //用到的条件
            var strLength = length == 11 ? true : false; //学年学期的长度
            var yearDifference = (parseInt(year2) - parseInt(year1) == 1) ? true : false; //学年之间相差为1
            var termValue = ((parseInt(term) == 1) || (parseInt(term) == 2)) ? true : false; //学期为1或2
            var firstYearRange = parseInt(year1) >= 2000 ? true : false; //第一个学年在2000之后
            var secondYearRange = parseInt(year2) >= 2001 ? true : false; //第二个学年在2001年之后             

            //
            if ((strLength && yearDifference && termValue && firstYearRange && secondYearRange) == true)
            {
                //if所有条件都为true的话吗,则返回true
                objArgs.IsValid = true;
                return;
            }
            else
            {
                objArgs.IsValid = false;
                return;
            }
        }       
    </script>
    <telerik:radajaxmanager id="RadAjaxManager1" runat="server" updatepanelsrendermode="Inline">
        <ClientEvents OnRequestStart="onRequestStart" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cbntQuery">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdTeacherQuery" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cgrdTeacherQuery">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdTeacherQuery" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:radajaxmanager>
    <telerik:radformdecorator id="RadFormDecorator1" runat="server" decoratedcontrols="All" />
    <telerik:radstylesheetmanager id="RadStyleSheetManager1" runat="server">
    </telerik:radstylesheetmanager>
    <telerik:radtooltipmanager id="RadToolTipManager1" runat="server" autotooltipify="true">
    </telerik:radtooltipmanager>
    <telerik:radajaxloadingpanel id="RadAjaxLoadingPanel1" runat="server">
    </telerik:radajaxloadingpanel>
    <script type="text/javascript">
        //如果点击的是导出按钮则将AJAX禁用
        function onRequestStart(sender, args)
        {
            if (args.get_eventTarget().indexOf("ExportToExcelButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToWordButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToPdfButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToCsvButton") >= 0)
            {
                args.set_enableAjax(false);
            }
        }
    </script>
    <div>
        <cp:cpmistoolbar id="CPMisToolBar1" runat="server" skinid="Long">
            <Items>
                <telerik:RadToolBarButton runat="server" CommandName="help" Text="帮助" ImageUrl="~/Img/tlb_Help.png">
                </telerik:RadToolBarButton>
            </Items>
        </cp:cpmistoolbar>
    </div>
    <div>
        <cp:cpmistabstrip runat="server" id="tabStrip" multipageid="cterm" skinid="Long">
            <Tabs>
                <cp:CPMisTab Text="增加学年学期信息">
                </cp:CPMisTab>
            </Tabs>
        </cp:cpmistabstrip>
        <cp:cpmismultipage runat="server" id="cterm" skinid="Long">
            <cp:CPMisPageView ID="CPMisPageView1" runat="server">
                <table class="border">
                    <tr>
                        <td class="border" align="right">
                            <asp:Label ID="lblTerm" Text="学年学期：" runat="server">
                            </asp:Label>
                        </td>
                        <td class="border">
                            <span style="color: Red">*</span>
                        </td>
                        <td class="border" align="left">
                            <cp:CPMisTextBox ID="ctxtTerm" runat="server" ValidationGroup="BaseInfoGroup" SkinID="Auto"
                                Width="121px">
                            </cp:CPMisTextBox>
                            <asp:Label ID="lblAlert" Text="如: 2010-2011-1"
                                runat="server" ForeColor="Gray"></asp:Label>
                            <asp:RegularExpressionValidator ID="vldTerm" ValidationExpression="\d{4}-\d{4}-\d{1}"
                                ControlToValidate="ctxtTerm" ErrorMessage="请输入正确的学年学期" runat="server" Display="None"
                                ValidationGroup="BaseInfoGroup" />
                            <asp:RequiredFieldValidator ID="vldRequiredTerm" runat="server" ValidationGroup="BaseInfoGroup"
                                ErrorMessage="学年学期不可以为空!" ControlToValidate="ctxtTerm" Display="None"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="vldCode" runat="server" ErrorMessage="前面的两个年份表示学年. 最后一位的1表示第一学期,2表示第二学期."
                                ValidateEmptyText="False" ControlToValidate="ctxtTerm" ClientValidationFunction="MyCustomValidation"
                                ValidationGroup="BaseInfoGroup" Width="232px" Display="None"></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="border" align="right">
                            <asp:Label ID="lblIsCurrentTerm" Text="是否为当前学期：" runat="server">
                            </asp:Label>
                        </td>
                        <td class="border">
                        </td>
                        <td class="border" align="left">
                            <cp:CPMisCheckBox ID="chkIsCurrentTerm" runat="server" Text="勾选表示是当前学期" />
                        </td>
                    </tr>
                    <tr>
                        <td class="border" align="right">
                            <asp:Label ID="Label1" Text="开始日期：" runat="server">
                            </asp:Label>
                        </td>
                        <td class="border">
                            <span style="color: Red">*</span>
                        </td>
                        <td class="border" align="left">
                            <cp:CPMisDatePicker ID="cdateBeginDate" runat="server">
                            </cp:CPMisDatePicker>
                            <asp:RequiredFieldValidator ID="vldBeginDate" runat="server" ValidationGroup="BaseInfoGroup"
                                ErrorMessage="开始日期不可以为空或格式不正确,请用日历控件选择日期!" ControlToValidate="cdateBeginDate" Display="None"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="border" align="right">
                            <asp:Label ID="Label2" Text="结束日期：" runat="server">
                            </asp:Label>
                        </td>
                        <td class="border">
                            <span style="color: Red">*</span>
                        </td>
                        <td class="border" align="left">
                            <cp:CPMisDatePicker ID="cdateEndDate" runat="server">
                            </cp:CPMisDatePicker>
                            <asp:RequiredFieldValidator ID="vldEndDate" runat="server" ValidationGroup="BaseInfoGroup"
                                ErrorMessage="结束日期不可以为空或格式不正确,请用日历控件选择日期!" ControlToValidate="cdateEndDate" Display="None"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="vldDate" ControlToValidate="cdateBeginDate" ControlToCompare="cdateEndDate"
                                Operator="LessThan" Type="Date" ErrorMessage="日期请按时间先后顺序输入!" runat="server"
                                Display="None" ValidationGroup="BaseInfoGroup" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:ValidationSummary ID="vldSummary" runat="server" ShowMessageBox="true" ShowSummary="false"
                    ValidationGroup="BaseInfoGroup" />
                <br />
                <div style="text-align: center">
                    <cp:CPMisButton ID="cbtnAdd" runat="server" OnClick="cbtnAdd_Click" ValidationGroup="BaseInfoGroup"
                        Text="确定" SkinID="bt60" OnClientClick="return OnClientValidateClick('BaseInfoGroup')" />
                    <%-- OnClientClick="return confirm('是否新增？')"--%>
                    &nbsp; &nbsp;
                    <cp:CPMisButton ID="cbtnCancle" runat="server" OnClick="cbtnCancle_Click" SkinID="bt60"
                        Text="取消" />
                    <br />
                </div>
            </cp:CPMisPageView>
        </cp:cpmismultipage>
    </div>
    </form>
</body>
</html>
