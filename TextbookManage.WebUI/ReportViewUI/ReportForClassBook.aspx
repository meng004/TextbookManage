<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportForClassBook.aspx.cs" Inherits="TextbookManage.WebUI.ReportViewUI.ReportForClassBook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>班级发放打印</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
        <div>            
            <report:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
                <LocalReport ReportPath="ReportViews\Report1.rdlc" >
                </LocalReport>
                
            </report:ReportViewer>            
        </div>
    </form>
</body>
</html>
