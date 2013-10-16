<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassReleasePlanQuery.aspx.cs" Inherits="CPMis.WebPage.Tb_Query.Tb_Query_06.StudentReleasePlanQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
  <style type="text/css">
    .border
       {
        border:0;
        margin:0;
        padding:0;         
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
                 <telerik:AjaxUpdatedControl ControlID="cgrdClassReleasePlanQuery" />
              </UpdatedControls>
          </telerik:AjaxSetting>
         <telerik:AjaxSetting AjaxControlID="cbntQuery">
           <UpdatedControls>
              <telerik:AjaxUpdatedControl ControlID="cgrdClassReleasePlanQuery" LoadingPanelID="RadAjaxLoadingPanel1"/>
           </UpdatedControls>
         </telerik:AjaxSetting>  
         <telerik:AjaxSetting AjaxControlID="ccmbSchool">
            <UpdatedControls>
               <telerik:AjaxUpdatedControl ControlID="ccmbProfessionalClass"/>
               <telerik:AjaxUpdatedControl ControlID="ccmbGrade"/>               
            </UpdatedControls>
         </telerik:AjaxSetting>
         <telerik:AjaxSetting AjaxControlID="ccmbGrade">
            <UpdatedControls>
               <telerik:AjaxUpdatedControl ControlID="ccmbProfessionalClass" />
            </UpdatedControls>
         </telerik:AjaxSetting>        
         <telerik:AjaxSetting AjaxControlID="cgrdTeacherQuery">
              <UpdatedControls>
                 <telerik:AjaxUpdatedControl ControlID="cgrdTeacherQuery" LoadingPanelID="RadAjaxLoadingPanel1"/>
              </UpdatedControls>
         </telerik:AjaxSetting>
     </AjaxSettings>
    </telerik:RadAjaxManager>   
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <telerik:RadToolTipManager  ID="RadToolTipManager1" runat="server" AutoTooltipify="true">
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
      <div id="tool" runat="server" class ="sty_div">
       <cp:CPMisToolBar ID="CPMisToolBar1"  runat="server" SkinID="Long">
         <Items> 
            <telerik:RadToolBarButton runat="server" CommandName="help" Text="帮助" ImageUrl ="~/Img/tlb_Help.png"> </telerik:RadToolBarButton>
         </Items> 
      </cp:CPMisToolBar>
    </div>

     
   <div>
     <cp:CPMisTabStrip runat="server" ID="tabStrip" MultiPageID="cClassReleasePlan" SkinID="Long">
        <Tabs>
          <cp:CPMisTab  Text="查询班级发放计划信息"></cp:CPMisTab>
        </Tabs>
     </cp:CPMisTabStrip>
     <cp:CPMisMultiPage  runat="server" ID="cClassReleasePlan" SkinID="Long">
       <cp:CPMisPageView ID="CPMisPageView1" runat="server" >
          <div id="div_choose" runat="server" style="padding-left:5px;padding-top:2px;text-align:left;background-color: #E1EBF7;"  > 
 
              
              <table class="border">
              <tr>
              <td class="border">
              <cp:CPMisLabel ID="clblTerm" runat="server" Text="学年学期：" SkinID="AutoSize" >
              </cp:CPMisLabel>
              </td>
               <td class="border">
              <cp:CPMisComboBox ID="ccmbTerm" runat="server" SkinID="AutoSize" Width="130px" AutoPostBack="true" 
                     DataTextField="Term" DataValueField="Term">
              </cp:CPMisComboBox>                  
              </td>
               <td class="border">
              <cp:CPMisLabel ID="clblSchool" runat="server" Text="学院：" SkinID="AutoSize" >
              </cp:CPMisLabel>
              </td>
               <td class="border">
              <cp:CPMisComboBox ID="ccmbSchool" runat="server" SkinID="AutoSize" Width="130px" AutoPostBack="true" 
                       DataTextField="SchoolName" DataValueField="SchoolID" OnSelectedIndexChanged="ccmbSchool_SelectedIndexChanged">
              </cp:CPMisComboBox>                   
              </td>            
                <td class="border">
              <cp:CPMisLabel ID="clblGrade" runat="server" Text="年级：" SkinID="AutoSize">
              </cp:CPMisLabel>
              </td>
               <td class="border">
              <cp:CPMisComboBox ID="ccmbGrade" runat="server" SkinID="AutoSize" Width="130px" AutoPostBack="true"
                       DataTextField="Grade" DataValueField="Grade" OnSelectedIndexChanged="ccmbGrade_SelectedIndexChanged">
              </cp:CPMisComboBox>                   
              </td>
                <td class="border">
              <cp:CPMisLabel ID="clblProfessionalClass" runat="server" Text="专业班级：" SkinID="AutoSize">
              </cp:CPMisLabel>
              </td>
               <td class="border">
              <cp:CPMisComboBox ID="ccmbProfessionalClass" runat="server" SkinID="AutoSize" Width="130px" DataTextField="ProfessionalClass" 
                  DataValueField="ClassID">
              </cp:CPMisComboBox>
              </td>
              <td class="border" style="Width:100px" align="right" >
              
              <cp:CPMisButton  runat="server" ID="cbntQuery" Text="查询"  OnClick="cbntQuery_Click"></cp:CPMisButton>
             </td> 
             </tr>
             </table>           
            </div>
            <div>
                <cp:CPMisGrid ID="cgrdClassReleasePlanQuery" runat="server" SkinID="Long" OnBeforeDataBind="cgrdClassReleasePlanQuery_BeforeDataBind">
                    <MasterTableView AllowSorting="true"><%--AutoGenerateColumns="False" DataKeyNames="BooksellerID" AllowSorting="true"--%>
                       <Columns >
                           <telerik:GridTemplateColumn HeaderText="序号" HeaderStyle-Width="40px">
                                    <ItemTemplate>
                                        <%#Container .DataSetIndex +1 %></ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn HeaderText="学年学期" DataField="Term" >
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="学院" DataField="SchoolName" >
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="专业班级" DataField="ProfessionalClass" >
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="课程名" DataField="CourseName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="书商名" DataField="BooksellerName" >
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="教材名称" DataField="TextbookName">
                                </telerik:GridBoundColumn>                                
                                <telerik:GridBoundColumn HeaderText="ISBN" DataField="ISBN" >
                                </telerik:GridBoundColumn>     
                                <telerik:GridBoundColumn HeaderText="出版社" DataField="Press">
                                </telerik:GridBoundColumn>                                                         
                                <telerik:GridBoundColumn HeaderText="计划发放数量" DataField="TotalCount">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="发放情况" DataField="IsRelease ">
                                </telerik:GridBoundColumn>                                                      
                        </Columns>                   
                    </MasterTableView>
                    <%--<FilterMenu EnableImageSprites="False">
                    </FilterMenu>--%>
                    <%--<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                    </HeaderContextMenu>--%>
                </cp:CPMisGrid>
          </div>
       
       </cp:CPMisPageView >
     </cp:CPMisMultiPage>
   </div>
      
    </form>
</body>
</html>
