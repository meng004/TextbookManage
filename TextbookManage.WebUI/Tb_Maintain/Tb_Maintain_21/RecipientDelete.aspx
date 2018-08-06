<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecipientDelete.aspx.cs" Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_21.RecipientDelete" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
    .Red
    {
        color:Red;
    }
    .Border
    {
        margin:0;
        border:0;
        padding:0;
         margin-right:auto;
            margin-left:auto;
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
    </telerik:RadAjaxManager>
    <telerik:RadFormDecorator ID="RadFormDecorator1" Runat="server" />
    <div id="tool" runat="server" class="sty_div">
        <cp:CPMisToolBar ID="CPMisToolBar1" runat="server" SkinID="Long">
            <Items>
                <telerik:RadToolBarButton runat="server" CommandName="help" Text="帮助" ImageUrl="~/Img/tlb_Help.png">
                </telerik:RadToolBarButton>
            </Items>
        </cp:CPMisToolBar>
    </div>
    <div>
        <cp:CPMisTabStrip runat="server" ID="tabStrip" MultiPageID="cterm" SkinID="Long">
            <Tabs>
                <cp:CPMisTab Text="删除领用人类型信息">
                </cp:CPMisTab>
            </Tabs>
        </cp:CPMisTabStrip>
        <cp:CPMisMultiPage runat="server" ID="cterm" SkinID="Long">
            <cp:CPMisPageView ID="CPMisPageView1" runat="server">
        <table class="Border">
            <tr>
                <td class="Border" style="text-align:center;">
                    <cp:CPMisLabel ID="clalRecipient" runat="server" Text="领用人类型：" SkinID="Auto">
                    </cp:CPMisLabel>
                    <cp:CPMisComboBox ID="cdlstRecipient" runat="server" DataTextField="RecipientType" DataValueField="RecipientTypeID">
                    </cp:CPMisComboBox>
                </td><td class="Border">
                    <cp:CPMisLabel ID="clalRecipientExample" runat="server" 
                        Enabled="False" IsCancelDataBind="False" SkinID="Auto" Text=" "></cp:CPMisLabel>
                </td>
            </tr>
        </table>
        <br />
        <div align="center">
            <cp:CPMisButton ID="cbtnDelete" runat="server" Text="删除" SkinID="bt60"  OnClick="cbtnDelete_Cilck" OnClientClick="return confirm('确认删除吗？')"/> &nbsp;&nbsp;
            <cp:CPMisButton ID="cbtnCancle" runat="server" Text="取消" SkinID="bt60"  OnClick="cbtnCancle_Click"/>
        </div>
       </cp:CPMisPageView>
      </cp:CPMisMultiPage>
    </div>
    </form>
</body>
</html>
