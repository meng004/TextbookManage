<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IdentityCardTypeDelete.aspx.cs"
    Inherits="CPMis.WebPage.Tb_Maintain.Tb_Maintain_22.IdentityCardTypeDelete" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .Red
        {
            color: Red;
        }
        .Border
        {
            margin: 0;
            border: 0;
            padding: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:radskinmanager id="RadSkinManager1" runat="server">
    </telerik:radskinmanager>
    <telerik:radscriptmanager id="RadScriptManager1" runat="server">
    </telerik:radscriptmanager>
    <telerik:radajaxmanager id="RadAjaxManager1" runat="server" updatepanelsrendermode="Inline">
    </telerik:radajaxmanager>
    <telerik:radformdecorator id="RadFormDecorator1" runat="server" />
    <div id="tool" runat="server" class="sty_div">
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
                <cp:CPMisTab Text="删除证件类型信息">
                </cp:CPMisTab>
            </Tabs>
        </cp:cpmistabstrip>
        <cp:cpmismultipage runat="server" id="cterm" skinid="Long">
            <cp:CPMisPageView ID="CPMisPageView1" runat="server">
        <table class="Border">
            <tr>
                <td class="Border" style="text-align:center;">
                    <cp:CPMisLabel ID="clalIdentityCardType" runat="server" Text="证件类型：" SkinID="Auto">
                    </cp:CPMisLabel>
                    <cp:CPMisComboBox ID="clstIdentityCardType" runat="server"
                    DataTextField="IdentityCard"  DataValueField="IdentityCardTypeNum" 
                    AutoPostBack="true" 
                   OnSelectedIndexChanged="clstIdCardType_OnSelectedIndexChanged" 
                   MarkFirstMatch="true"  >
                    </cp:CPMisComboBox>
                </td><td class="Border">
                    <cp:CPMisLabel ID="clalIdentityCardTypeExample" runat="server" 
                        Enabled="False" IsCancelDataBind="False" SkinID="Auto" Text=" "></cp:CPMisLabel>
                </td>
            </tr>
        </table>
        <br />
        <div>
            <cp:CPMisButton ID="cbtnDelete" runat="server" Text="删除" SkinID="bt60"  OnClick="cbtnDelete_Cilck" OnClientClick="return confirm('确认删除吗?')"/> &nbsp;&nbsp;
            <cp:CPMisButton ID="cbtnCancle" runat="server" Text="取消" SkinID="bt60"  OnClick="cbtnCancle_Click"/>
        </div>
       </cp:CPMisPageView>
      </cp:cpmismultipage>
    </div>
    </form>
</body>
</html>
