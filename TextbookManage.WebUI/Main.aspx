<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="USCTAMis.WebPage.FrameSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>南华教务管理在线</title>
    </head>
    <frameset cols="210,11,*" frameborder="no" border="0" framespacing="0" id="main">
        <frame name="leftFrame" src="Left.aspx" />
        <frame src="Middle.htm" name="middleFrame" id="middleFrame" title="middleFrame"/>
        <frame name="mainFrame" scrolling="Auto" style="width: 100%;"  src="Default.aspx"/>
    </frameset>
</html>
