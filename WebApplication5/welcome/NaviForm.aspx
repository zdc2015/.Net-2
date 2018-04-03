<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NaviForm.aspx.cs" Inherits="WebApplication5.welcome.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3><a href="UserForm.aspx" target="right_frame">用户维护</a></h3>
            <h3><a href="GoodsForm.aspx" target="right_frame">物品信息</a></h3>
            <h3><a href="Instorage.aspx" target="right_frame">物品入库</a></h3>
            <h3><a href="outStorage.aspx" target="right_frame">物品出库</a></h3>
            <h3><a href="outStorageDetail.aspx" target="right_frame">领用明细</a></h3>
        </div>
    </form>
</body>
</html>
