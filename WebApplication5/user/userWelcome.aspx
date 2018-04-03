<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userWelcome.aspx.cs" Inherits="WebApplication5.user.userWelcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<frameset rows="15%,85%">

    <frame src="titleForm.aspx" noresize="noresize">

    <frameset cols="15%,85%">
        <frame name="left_frame" src="leftFrame.aspx" noresize="noresize">
        <frame name="right_frame" src="GoodsForm.aspx" noresize="noresize">
    </frameset>
</html>
