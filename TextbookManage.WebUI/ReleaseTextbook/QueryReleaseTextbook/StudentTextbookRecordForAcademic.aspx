<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentTextbookRecordForAcademic.aspx.cs" Inherits="CPMis.WebPage.Tb_Query.Tb_Query_02.StudentTextbookRecordForAcademic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>学生领书记录查询</title>
    <link href="../../App_Themes/CPMisTheme/style.css" rel="Stylesheet" type="text/css"/>
    <style type="text/css" >
        .colText,.colControl,.table,.noBorder
       {
            padding:0;
            margin:0;
            border:0;
         }
        .colText
        {
            text-align:right;
            }
        .colControl
        {
            text-align:center;
            }
            .table
            {
                width:990px;
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
                    <telerik:AjaxUpdatedControl ControlID="cgrd_Result" /> 
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cbntQuery">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdResult"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                    <telerik:AjaxUpdatedControl ControlID="ctxtSumCharge" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ccmbSchool">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ccmbClass" />
                    <telerik:AjaxUpdatedControl ControlID="ccmbStudent" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ccmbGrade">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ccmbClass" />
                    <telerik:AjaxUpdatedControl ControlID="ccmbStudent" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ccmbClass">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ccmbStudent" />
                </UpdatedControls>
            </telerik:AjaxSetting>
           <telerik:AjaxSetting AjaxControlID="ccmbStudent">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdResult"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                    <telerik:AjaxUpdatedControl ControlID="ctxtSumCharge" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cgrdResult">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cgrdResult"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                    <telerik:AjaxUpdatedControl ControlID="ctxtSumCharge" />
                </UpdatedControls>
            </telerik:AjaxSetting>
           </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <telerik:RadToolTipManager  ID="RadToolTipManager1" runat="server" AutoTooltipify="true"></telerik:RadToolTipManager>
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
                  oWnd.setUrl(encodeURI("../TextbookDetailMessage.aspx?TextbookId=" + TextbookId)); //
                  oWnd.show();
                  oWnd.setSize(450, 280);
              }
          </script>

    <div id="tab" runat="server"  class="sty_div" >
      <cp:CPMisTabStrip ID="CPMisTabStrip1" runat="server" MultiPageID="married" SkinID="Long" >
         <Tabs>
           <cp:CPMisTab runat="server" Text="学生教材费用查询" selected="true" ></cp:CPMisTab>
         </Tabs>
     </cp:CPMisTabStrip>
     <cp:CPMisMultiPage ID="married" runat="server" SkinID="long">
       <cp:CPMisPageView ID="CPMisPageView1"  runat="server">
            <div id="div_choose" runat="server" style="padding-left:5px;padding-top:2px;text-align:left;background-color: #E1EBF7;" > 
              <table class="table">
              <tr>
               <td class="colText">
                <cp:CPMisLabel runat="server" Text="学年学期" SkinID="AutoSize" ></cp:CPMisLabel>
               </td>
               <td class="colControl">
                  <cp:CPMisComboBox runat="server" ID="ccmbTerm" SkinID="AutoSize" AutoPostBack="true" Skin="Office2007"  
                DataTextField="Term" DataValueField="Term" ></cp:CPMisComboBox>
               </td>
               <td class="colText">
               <cp:CPMisLabel runat="server" Text="学院" SkinID="AutoSize" ></cp:CPMisLabel>
               </td>
               <td class="colControl">
                <cp:CPMisComboBox runat="server"  ID="ccmbSchool" DataTextField="SchoolName" DataValueField="SchoolID"  
             SkinID="AutoSize" AutoPostBack="true" OnSelectedIndexChanged="ccmbSchool_SelectedIndexChanged"></cp:CPMisComboBox>
               </td>
               <td class="colText">
               <cp:CPMisLabel ID="CPMisLabel5"  runat="server" Text="年级" SkinID="AutoSize" ></cp:CPMisLabel>
               </td>
               <td class="colControl">
                <cp:CPMisComboBox runat="server" ID="ccmbGrade" DataTextField="grade" DataValueField="grade"   
             SkinID="AutoSize" AutoPostBack="true" OnSelectedIndexChanged="ccmbGrade_SelectedIndexChanged"></cp:CPMisComboBox>
               </td>
               <td class="colText">
                <cp:CPMisLabel ID="CPMisLabel6"  runat="server" Text="班级" SkinID="AutoSize" ></cp:CPMisLabel>
               </td>
               <td class="colControl">
               <cp:CPMisComboBox runat="server" ID="ccmbClass"  DataTextField="ClassName" DataValueField="ClassID" 
             SkinID="AutoSize" Skin="Office2007" AutoPostBack="true" OnSelectedIndexChanged="ccmbClass_SelectedIndexChanged"></cp:CPMisComboBox>
               </td>
               
              </tr>
              <tr>
              <td class="colText">
               <cp:CPMisLabel ID="CPMisLabel1" runat="server" Text="学生" SkinID="AutoSize" ></cp:CPMisLabel>
               </td>
               <td class="colControl">
               <cp:CPMisComboBox runat="server" ID="ccmbStudent" DataTextField="StudentNumAndName" DataValueField="StudentNum" 
                     AutoPostBack="true" OnSelectedIndexChanged="ccmbStudent_SelectedIndexChanged"></cp:CPMisComboBox>
               </td>
                  <td class="noBorder" colspan="2"> <cp:CPMisButton  runat="server" ID="cbntQuery" Text="查询" OnClick="cbntQuery_Click"></cp:CPMisButton></td>
                  
                  <td class="colText">
                   <cp:CPMisLabel runat="server" Text="预存费用" SkinID="AutoSize"></cp:CPMisLabel>
                  </td>
                  <td class="colControl">
                  <cp:CPMisTextBox runat="server" ID="ctxtAdanceCharge" Enabled="false" ></cp:CPMisTextBox>
                  </td>
                  <td class="colText">
                  <cp:CPMisLabel runat="server" Text="费用总计" SkinID="AutoSize"></cp:CPMisLabel>
                  </td>
                  <td class="colControl">
                    <cp:CPMisTextBox runat="server" ID="ctxtSumCharge"  Enabled="false" ></cp:CPMisTextBox>
                  </td>
              </tr>
             
              </table>
               </div>       
           <div id="result" runat="server" class="sty_div">
              <cp:CPMisGrid ID="cgrdResult" runat="server"  AutoGenerateColumns="false" SkinID="long" OnBeforeDataBind="cdgrdResult_BeforeDataBind" >
                 <MasterTableView>
                   <Columns> 
                     <telerik:GridTemplateColumn HeaderText="序号"  HeaderStyle-Width="30px">
                     <ItemTemplate> <%# Container.DataSetIndex + 1%>  </ItemTemplate>
                     </telerik:GridTemplateColumn>
                     <telerik:GridBoundColumn HeaderText="学年学期" DataField="Term" ></telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderText="学院" DataField="StudentSchool" HeaderStyle-Width="120px"></telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderText="专业班级" DataField="ProfessionalClass"></telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderText="学号" DataField="StudentNum"></telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderText="教材ID" DataField="TextbookId" Visible="false"></telerik:GridBoundColumn>
                     <telerik:GridTemplateColumn  HeaderText="教材名称" HeaderStyle-Width="80px" >
                         <ItemTemplate>
                            <a  href="javascript:void(0)"  onclick='<%# "OnClientBookDetailMessageCommand(\""+Eval("TextbookId")+"\")" %>'><%# Eval("TextbookName")%></a>
                         </ItemTemplate>
                     </telerik:GridTemplateColumn>
                     <telerik:GridBoundColumn HeaderText="零售价" DataField="RetailPrice"></telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderText="折后价" DataField="DiscountPrice"></telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderText="数量" DataField="ReleaseCount"></telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderText="领取人" DataField="Recipient"></telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderText="联系方式" DataField="RecipientTelephone"></telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderText="领取时间" DataField="ReleaseDate"></telerik:GridBoundColumn>
                   </Columns>
                 </MasterTableView>
               </cp:CPMisGrid>
            </div>
       </cp:CPMisPageView>
     </cp:CPMisMultiPage>        
   </div>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        <Windows>
            <telerik:RadWindow ID="wdw_TextbookDetailMessage" runat="server" Top="100" Left="200" ReloadOnShow="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>   
    <asp:SqlDataSource ID="Sql_Term" runat="server" 
        ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>" SelectCommand="prTermGetList" 
        SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlSchool" runat="server" 
        ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>" 
        SelectCommand="prSchoolNameGetList" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlGrade" runat="server" ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>" 
        SelectCommand="prGradeGetList" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlClass" runat="server" ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>" 
        SelectCommand="prProfessionalClassGetListByCondition" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter  ControlID="ccmbSchool" Name="SchoolId" PropertyName="SelectedValue"/>
            <asp:ControlParameter  ControlID="ccmbGrade" Name="Grade" PropertyName="SelectedValue"/>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlStudent" runat="server" ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>"
        SelectCommand="prStudentGetInfoByClassID" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="ccmbClass" Name="ClassID" PropertyName="SelectedValue" />
        </SelectParameters>    
    </asp:SqlDataSource>
   </form>
</body>
</html>
