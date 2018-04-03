<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addGoods.aspx.cs" Inherits="WebApplication5.welcome.addGoods" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        html,body,form{
            width:100%;
            height:100%;
            margin:0 0 0 0;
            border-width:0px;
            padding:0 0 0 0;
            position:relative;
        }

        .add{
            position:absolute;
            top:0;
            left:0;
            right:0;
            bottom:0;
            margin:auto;
            width:400px;
        }
    </style>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="add">
                <tr>
                    <td>编号</td>
                    <td> <asp:TextBox ID="isbn"  runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td>名称</td>
                    <td> <asp:TextBox ID="name"  runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td>类别</td>
                    <td><asp:DropDownList ID="typeddl" runat="server" OnSelectedIndexChanged="typeddl_SelectedIndexChanged" ></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>数量</td>
                    <td> <asp:TextBox ID="num"  runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td>生产地</td>
                    <td> <asp:TextBox ID="origin"  runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td>规格</td>
                    <td> <asp:TextBox ID="specifications"  runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td>型号</td>
                    <td> <asp:TextBox ID="model"  runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td style="text-align:center;">上传图片</td>
                    <td> <asp:FileUpload ID="imgUpload" runat="server" /> </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button style="margin-top:10px; margin-left:30%;" ID="save" Text="确定" runat="server" OnClick="Unnamed_Click"/>
                        <asp:Button style="margin-top:10px; margin-left:15%;" ID="back" runat="server" OnClick="back_Click" Text="返回" />
                    </td>
                </tr>
                <tr>
                    <td rowspan="3" colspan="2">
                        <asp:Label ID="tip" runat="server" ></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
