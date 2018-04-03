<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="titleForm.aspx.cs" Inherits="WebApplication5.user.titleForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<style type="text/css">

    .label{
        width:fit-content;
        height:fit-content;
        margin:auto;
    }

    form{
        width:100%;
        height:100%;
    }

    .link{
        position:absolute;
        top:80%;
        left:90%;
    }

</style>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="label">
            <h1><asp:Label ID="title"  runat="server" ></asp:Label></h1>
        </div>

        <a class="link" href="../index.aspx" target="_top">退出登录</a>
    </form>
</body>
</html>
