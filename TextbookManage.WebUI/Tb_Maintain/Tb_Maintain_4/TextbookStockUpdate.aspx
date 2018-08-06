<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TextbookStockUpdate.aspx.cs" Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_4.TextbookStockUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            border:0;
            margin:0;
            padding:0;
        }
        .style2
        {
            color:Red;
        }
        .style3
        {
            border:0;
            margin:0;
            padding:0;
        }   
        .style4 
        {
            color:Gray;
            border:0;
            margin:0;
            padding:0; 
    </style>
    
    
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
        </telerik:RadScriptManager>
        <telerik:RadFormDecorator ID="RadFormDecorator1" Runat="server" />
        <div>
             <table class="style1" style="text-align:center">
                  <tr align="left">
                    <td  class="style3"><cp:CPMisLabel ID="clalStockName" runat="server" Text="仓库名称：" SkinID="AutoSize"></cp:CPMisLabel>
                    <span class="style2">*</span>
                    </td>
                    <td class="style3"><cp:CPMisTextBox ID="ctxtStockName" runat="server" 
                            Enabled="False"></cp:CPMisTextBox>
                    </td>
                    <td class="style4">
                    <cp:CPMisLabel ID="clalStockNameExample" runat="server" Text="如：北校仓库" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                  </tr>
                  <tr align="left">
                    <td class="style3"><cp:CPMisLabel ID="clalStockNum" runat="server" Text="仓库编号：" SkinID="AutoSize"></cp:CPMisLabel>
                    <span class="style2">*</span> 
                    </td>
                    <td class="style3"><cp:CPMisTextBox ID="ctxtStockNum" runat="server" 
                            Enabled="False"></cp:CPMisTextBox>
                    </td>
                    <td class="style4">
                    <cp:CPMisLabel ID="clalStockNumExample" runat="server" Text="如：1号仓库" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                </tr>
                <tr align="left">
                    <td class="style3"><cp:CPMisLabel ID="clalStockAddress" runat="server" Text="仓库地址：" SkinID="AutoSize"></cp:CPMisLabel>
                    <span class="style2">*</span>
                    </td>
                    <td class="style3"><cp:CPMisTextBox ID="ctxtStockAddress" runat="server"></cp:CPMisTextBox>
                    </td>
                    <td class="style4">
                    <cp:CPMisLabel ID="clalStockAddressExample" runat="server" Text="如：北校一栋0层" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
               </tr>
                  <tr align="left">
                    <td class="style3"><cp:CPMisLabel ID="clalTelephone" runat="server" Text="联系电话：" SkinID="AutoSize"></cp:CPMisLabel>
                    <span class="style2">*</span>
                    </td>
                    <td class="style3"><cp:CPMisTextBox ID="ctxtTelephone" runat="server"></cp:CPMisTextBox>
                    </td>
                    <td class="style4">
                    <cp:CPMisLabel ID="clalTelephoneExample" runat="server" Text="如：0734—8830876" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
               </tr>
                  <tr align="left">
                    <td class="style3">
                    <cp:CPMisLabel ID="clalAccountBeginDate" runat="server" Text="账务开始时间：" SkinID="AutoSize"></cp:CPMisLabel>
                    <span class="style2">*</span>
                    </td>
                    <td class="style3"><cp:CPMisDatePicker ID="CPMisDatePicker1" runat="server" Style="margin-left: 4px;" runat="server"  Width="160px"></cp:CPMisDatePicker>
                    </td>
                    <td class="style4">
                    <cp:CPMisLabel ID="clalAccountBeginDateExample" runat="server" Text="如：2009/09/18" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                <asp:ValidationSummary ID ="vds_OverseasAdd" ValidationGroup="BaseInfoGroup" ShowSummary="false" ShowMessageBox="true" 
                 HeaderText="验证信息出错!" runat ="server" />
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="ctxtTelephone" 
                   Display="None" ValidationGroup="BaseInfoGroup" ValidationExpression="^[0-9]{5,12}$" ErrorMessage="联系方式格式错误，请输入正确的联系方式！">
               </asp:RegularExpressionValidator>             
               <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="ctxtStockAddress" 
                   Display="None" ValidationGroup="BaseInfoGroup" ValidationExpression="[a-zA-Z0-9\u4e00-\u9fa5]+" ErrorMessage="仓库地址格式错误，请输入正确的仓库地址！">
               </asp:RegularExpressionValidator>
             </table> 
             <br />
             <div style="text-align: center">
             <cp:CPMisButton ID="cbtnSave" runat="server" Text="保存" OnBeforeClick="cbtnBeforeSave" 
                    OnAfterClick="cbtnAfterSave" ValidationGroup="BaseInfoGroup" SkinID="bt40"/>&nbsp; &nbsp;
             <cp:CPMisButton ID="CPMisButton1" runat="server" Text="取消" OnClick="cbtnCancle_Click" SkinID="bt40"/> 
             </div>
              
        </div>
    </form>
</body>
</html>
    