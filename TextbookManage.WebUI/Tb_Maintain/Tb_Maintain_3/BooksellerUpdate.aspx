<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BooksellerUpdate.aspx.cs" Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_3.BooksellerUpdate" %>

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
    <telerik:RadCodeBlock ID="RadCodeBlock" runat="server">
    <script  language="javascript" type="text/javascript" >
        function CloseAndRebind() {
            GetRadWindow().BrowserWindow.refreshGrid();
            GetRadWindow().close();
            return false;
        }
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

            return oWindow;
        }
        </script>
        </telerik:RadCodeBlock>
        
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" />
    <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" AutoTooltipify="true">
    </telerik:RadToolTipManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
  
   <div  align="center">  <%--style="border: 1px groove #ABC1DE; width:300; height:180;"--%>
   <asp:ValidationSummary ID ="vds_OverseasAdd" ValidationGroup="BaseInfoGroup" ShowSummary="false" ShowMessageBox="true" HeaderText="验证信息出错!" runat ="server" />
    
              
              <table class ="border">
               <tr style="Height:30px">
                  <td class="border" align="right">
                  书商编号：
                  </td>
                  <td class="border">
                  <span style="color:Red">*</span></td>
                  <td class="border">
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None"
                            ValidationGroup="BaseInfoGroup" ErrorMessage="书商编号不能为空，请填写书商名称！" ControlToValidate="ctxtBooksellerNum">
                        </asp:RequiredFieldValidator>
                  <cp:CPMisTextBox ID="ctxtBooksellerNum" runat="server" SkinID="txt200"  Enabled="false">
                  </cp:CPMisTextBox>
                  
                  </td>                                    
               </tr>
               <tr style="Height:30px">
                  <td class="border" align="right">
                  书商名称：
                  </td>
                  <td class="border">
                  <span style="color:Red" class="border">*</span></td>
                  <td class="border">
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="None"
                            ValidationGroup="BaseInfoGroup" ErrorMessage="书商名称不能为空，请填写书商名称！" ControlToValidate="ctxtBooksellerName">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="ctxtBooksellerName" 
                            Display="None" ValidationGroup="BaseInfoGroup" ValidationExpression="[a-zA-Z0-9\u4e00-\u9fa5]+" ErrorMessage="书商名称格式错误，请填重新写书商名称！"></asp:RegularExpressionValidator>
                  <cp:CPMisTextBox ID="ctxtBooksellerName" runat="server" SkinID="txt200">
                  </cp:CPMisTextBox></td>
                  
                  <td class="border"  style="color: Gray" align="left">
                  如:新华书店
                  
                  </td>
               </tr>
               <tr style="Height:30px">
                  <td class="border" align="right">
                  联系人：
                  </td>
                  <td class="border">
                  </td> 
                  <td class="border">  
                 <cp:CPMisTextBox ID="ctxtContact" runat="server" SkinID="txt200">
                  </cp:CPMisTextBox>
                  </td> 
                  <td class="border"  style="color: Gray" align="left">
                  如:张建华
                  
                  </td>

               </tr>
               <tr style="Height:30px">
                  <td class="border" align="right">
                  联系电话： 
                  </td>     
                  <td class="border">
                  </td>
                  <td class="border"> 
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="ctxtTelephone" 
                    Display="None" ValidationGroup="BaseInfoGroup" ValidationExpression="^\d{5,13}$" ErrorMessage="电话号码格式错误，请输入正确的电话号码！"></asp:RegularExpressionValidator>
                  <cp:CPMisTextBox ID="ctxtTelephone" runat="server" SkinID="txt200">
                  </cp:CPMisTextBox>
                  </td> 
                  <td class="border"  style="color: Gray" align="left">
                  如:15173441653
                  
                  </td>
               </tr>
              </table>
              <br />
           
           <div style="text-align: center">
               <cp:CPMisButton ID="cbtnSumbit" runat="server"  onclick="cbtnSumbit_Click" 
                    Text="确定" SkinID="bt40" ValidationGroup="BaseInfoGroup" />
               &nbsp; &nbsp;
               <cp:CPMisButton ID="cbtnCancle" runat="server" onclick="cbtnCancle_Click" 
                    SkinID="bt40" Text="取消" />
               <br />
               <br />
              
           </div>
          
   </div>

          
    </form>
   
</body>
</html>