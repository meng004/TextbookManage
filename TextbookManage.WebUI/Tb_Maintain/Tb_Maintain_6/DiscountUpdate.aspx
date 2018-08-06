<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiscountUpdate.aspx.cs" Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_6.DiscountUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="ctxtDiscount">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ctxtDiscountPrice" 
                            LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadFormDecorator ID="RadFormDecorator1" Runat="server" />
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
            Skin="Default">
        </telerik:RadAjaxLoadingPanel>
        <div>
             <table class="style1">
                  <tr align="left">
                    <td  class="style3"><cp:CPMisLabel ID="clalTerm" runat="server" Text="学年学期：" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                      <td class="style3">
                          <span class="style2">*</span></td>
                    <td class="style3">
                    &nbsp;<cp:CPMisComboBox ID="cdlstTerm" runat="server" DataSourceID="SqlDataSource1" 
                            DataTextField="Term" DataValueField="Term" DefaultIndex="0" 
                            IsCancelDataBind="False" IsMaintainSelectedValue="False" SelectedText=""> </cp:CPMisComboBox>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>" 
                            SelectCommand="SELECT [Term] FROM [Term]"></asp:SqlDataSource>
                    </td>
                    <td class="style4" align="left">
                    <cp:CPMisLabel ID="clalTermExample" runat="server" Text="如：2008—2009—1" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                </tr>
                  <tr align="left">
                    <td class="style3"><cp:CPMisLabel ID="clalBooksellerName" runat="server" Text="书商名称：" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                      <td class="style3">
                          &nbsp;</td>
                    <td class="style3">
                        <cp:CPMisTextBox ID="ctxtBooksellerName" runat="server" 
                            ReadOnly="True" Enabled="False"></cp:CPMisTextBox>
                    </td>
                    <td class="style4">
                    <cp:CPMisLabel ID="clalBooksellerNameExample" runat="server" Text="" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                </tr>
                  <tr align="left">
                    <td class="style3"><cp:CPMisLabel ID="clalStockName" runat="server" Text="仓库名称：" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                      <td class="style3">
                          &nbsp;</td>
                    <td class="style3">
                        <cp:CPMisTextBox ID="ctxtStockName" runat="server" 
                            ReadOnly="True" Enabled="False"></cp:CPMisTextBox>
                    </td>
                    <td class="style4">
                    <cp:CPMisLabel ID="clalStockNameExample" runat="server" Text="" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                </tr>
                  <tr align="left">
                    <td class="style3"><cp:CPMisLabel ID="clalTextbookName" runat="server" Text="教材名：" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                      <td class="style3">
                          &nbsp;</td>
                    <td class="style3">
                        <cp:CPMisTextBox ID="ctxtTextbookName" runat="server" 
                            ReadOnly="True" Enabled="False"></cp:CPMisTextBox>
                    </td>
                    <td class="style4">
                    <cp:CPMisLabel ID="clalTextbookNameExample" runat="server" Text="" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                </tr>
                <tr align="left">
                    <td class="style3"><cp:CPMisLabel ID="clalStoreCount" runat="server" Text="库存量：" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                    <td class="style3">
                        &nbsp;</td>
                    <td class="style3">
                        <cp:CPMisTextBox ID="ctxtStoreCount" runat="server" 
                            ReadOnly="True" Enabled="False"></cp:CPMisTextBox>
                    </td>
                    <td class="style4">
                    <cp:CPMisLabel ID="clalStoreCountExample" runat="server" Text="" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                </tr>
                <tr align="left">
                    <td class="style3"><cp:CPMisLabel ID="clalRetailPrice" runat="server" Text="零售价：" 
                            SkinID="AutoSize" IsCancelDataBind="False"></cp:CPMisLabel>
                    </td>
                    <td class="style3">
                        &nbsp;</td>
                    <td class="style3">
                        <cp:CPMisTextBox ID="ctxtRetailPrice" runat="server" ReadOnly="True" 
                            Enabled="False">
                        </cp:CPMisTextBox>
                    </td>
                    <td class="style4">
                    &nbsp;</td>
                </tr>
                <tr align="left">
                    <td class="style3"><cp:CPMisLabel ID="clalDiscount" runat="server" Text="折扣：" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                    <td class="style3">
                        <span class="style2">*</span></td>
                    <td class="style3">
                    <cp:CPMisTextBox ID="ctxtDiscount" runat="server" 
                            ontextchanged="ctxtDiscount_TextChanged"></cp:CPMisTextBox>
                    </td>
                    <td class="style4" align="left">
                    <cp:CPMisLabel ID="clalDiscountExample" runat="server" Text="如：0.85" SkinID="AutoSize"></cp:CPMisLabel>
                        <br />
                    </td>
                </tr>
                  <tr align="left">
                    <td class="style3">
                                     <cp:CPMisLabel ID="clalDiscountPrice" runat="server" SkinID="AutoSize" 
                                         Text="折后价："></cp:CPMisLabel>
                    </td>
                      
                      <td class="style3">
                          &nbsp;</td>
                      
                      <td class="style3">
                          <cp:CPMisTextBox ID="ctxtDiscountPrice" runat="server" ReadOnly="True" 
                              Enabled="False">
                          </cp:CPMisTextBox>
                      </td>
                      <td class="style4">
                          <cp:CPMisLabel ID="clalDiscountPriceExample" runat="server" SkinID="AutoSize" 
                              Text=""></cp:CPMisLabel>
                      </td>
                      
                </tr>
             </table>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="ctxtDiscount" Display="None" ErrorMessage="折扣应该是0到1之间的2位小数" 
                        ValidationExpression="^1|(0\.[0-9]{1,2}?$)" 
                        ValidationGroup="BaseInfoGroup"></asp:RegularExpressionValidator>
                   <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        ValidationGroup="BaseInfoGroup" ShowMessageBox="True" 
                        ShowSummary="False" /><br />
             <div>
             <cp:CPMisButton ID="cbtnSubmit" runat="server" onclick="cbtnSubmit_Click" 
                  SkinID="bt40" Text="保存" ValidationGroup="BaseInfoGroup" />  &nbsp;&nbsp;    
             <cp:CPMisButton ID="cbtnCancle" runat="server" SkinID="bt40" Text="取消" /> 
             </div> 
        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
