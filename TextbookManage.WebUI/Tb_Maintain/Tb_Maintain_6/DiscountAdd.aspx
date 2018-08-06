<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiscountAdd.aspx.cs" Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_6.DiscountAdd" %>

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
        <telerik:RadFormDecorator ID="RadFormDecorator1" Runat="server" />
        <div>
            <telerik:RadTabStrip ID="RadTabStrip1" runat="server" SelectedIndex="0">
                <Tabs>
                    <telerik:RadTab Text="库存教材折扣信息修改" Selected="True">
                    </telerik:RadTab>
               </Tabs>
            </telerik:RadTabStrip>
                <cp:CPMisMultiPage ID="cMultiPageDiscount" runat="server" SkinID="Auto">
                <telerik:RadPageView ID="RadPageViewDiscount" runat="server">
             <table class="style1" style="text-align:center;">
                  <tr >
                    <td  class="style3" align="right"><cp:CPMisLabel ID="clalTerm" runat="server" Text="学年学期：" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                    <td class="style3">
                    <span class="style2">*</span></td>
                      <td class="style3">
&nbsp;<cp:CPMisComboBox ID="cdlstTerm" runat="server" DataSourceID="SqlDataSource1" DataTextField="Term" 
                              DefaultIndex="0" IsCancelDataBind="False" IsMaintainSelectedValue="False" 
                              SelectedText="">
                          </cp:CPMisComboBox>
                      </td>
                    <td class="style4" align="left">
                    <cp:CPMisLabel ID="clalTermExample" runat="server" Text="如：2008—2009—1" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                </tr>
                  <tr >
                    <td class="style3" align="right"><cp:CPMisLabel ID="clalBooksellerName" runat="server" Text="书商名称：" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                    <td class="style3">&nbsp;</td>
                      <td class="style3">
                          <cp:CPMisTextBox ID="ctxtBooksellerName" runat="server" Enabled="False" 
                              SkinID="tb160">
                          </cp:CPMisTextBox>
                      </td>
                    <td class="style4">
                    <cp:CPMisLabel ID="clalBooksellerNameExample" runat="server" Text="" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                </tr>
                  <tr >
                    <td class="style3" align="right"><cp:CPMisLabel ID="clalStockName" runat="server" Text="仓库名称：" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                    <td class="style3">&nbsp;</td>
                      <td class="style3">
                          <cp:CPMisTextBox ID="ctxtStockName" runat="server" Enabled="False" 
                              SkinID="tb160">
                          </cp:CPMisTextBox>
                      </td>
                    <td class="style4">
                    <cp:CPMisLabel ID="clalStockNameExample" runat="server" Text="" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                </tr>
                  <tr >
                    <td class="style3" align="right"><cp:CPMisLabel ID="clalTextbookName" runat="server" Text="教材名：" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                    <td class="style3">&nbsp;</td>
                      <td class="style3">
                          <cp:CPMisTextBox ID="ctxtTextbookName" runat="server" Enabled="False" 
                              SkinID="tb160">
                          </cp:CPMisTextBox>
                      </td>
                    <td class="style4">
                    <cp:CPMisLabel ID="clalTextbookNameExample" runat="server" Text="" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                </tr>
                <tr >
                    <td class="style3" align="right"><cp:CPMisLabel ID="clalStoreCount" runat="server" Text="库存量：" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                    <td class="style3">
                        &nbsp;</td>
                    <td class="style3">
                        <cp:CPMisTextBox ID="ctxtStoreCount" runat="server" Enabled="False" 
                            SkinID="tb160">
                        </cp:CPMisTextBox>
                    </td>
                    <td class="style4" align="right">
                    <cp:CPMisLabel ID="clalStoreCountExample" runat="server" Text="" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                </tr>
                <tr align="right">
                    <td class="style3"><cp:CPMisLabel ID="clalRetailPrice" runat="server" Text="零售价：" 
                            SkinID="AutoSize" IsCancelDataBind="False"></cp:CPMisLabel>
                    </td>
                    <td class="style4" align="center">
                        &nbsp;</td>
                    <td align="center" class="style4">
                        <cp:CPMisTextBox ID="ctxtRetailPrice" runat="server" Enable="false" 
                            Enabled="False" SkinID="tb160">
                        </cp:CPMisTextBox>
                    </td>
                    <td class="style4" align="right">
                    &nbsp;</td>
                </tr>
                <tr >
                    <td class="style3" align="right"><cp:CPMisLabel ID="clalDiscount" runat="server" Text="折扣：" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                    <td class="style3">
                        <span class="style2">*</span></td>
                    <td class="style3">
&nbsp;<cp:CPMisTextBox ID="ctxtDiscount" runat="server" AutoPostBack="true" 
                            ontextchanged="ctxtDiscount_TextChanged1" SkinID="tb160">
                        </cp:CPMisTextBox>
                    </td>
                    <td class="style4" align="left">
                    <cp:CPMisLabel ID="clalDiscountExample" runat="server" Text="如：0.85" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                </tr>
                <tr >
                    <td class="style3" align="right">
                    <cp:CPMisLabel ID="clalDiscountPrice" runat="server" Text="折后价：" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                    <td class="style3">&nbsp;</td>
                    <td class="style3">
                        <cp:CPMisTextBox ID="ctxtDiscountPrice" runat="server" Enabled="False" 
                            SkinID="tb160">
                        </cp:CPMisTextBox>
                    </td>
                    <td class="style4">
                    <cp:CPMisLabel ID="clalDiscountPriceExample" runat="server" Text="" SkinID="AutoSize"></cp:CPMisLabel>
                    </td>
                </tr>
                  <tr>
                    <td align="center" colspan="4" class="style3">
                    <cp:CPMisButton ID="cbtnSave" runat="server" Text="保存" onclick="cbtnSave_Click" />
                        </td>
                </tr>
             </table>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="ctxtDiscount" Display="None" ErrorMessage="折扣应该是0到1之间的2位小数" 
                                ValidationExpression="^1|(0\.[0-9]{1,2}?$)" 
                                ValidationGroup="BaseInfoGroup"></asp:RegularExpressionValidator>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                ValidationGroup="BaseInfoGroup" ShowMessageBox="True" 
                                ShowSummary="False" />
           </telerik:RadPageView>
               </cp:CPMisMultiPage>    
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:USCTAMisConnectionString %>" 
            SelectCommand="SELECT [Term] FROM [Term]"></asp:SqlDataSource>

        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
            Skin="Default">
        </telerik:RadAjaxLoadingPanel>
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
    </form>
</body>
</html>
