<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addUser.aspx.cs" Inherits="WebApplication5.welcome.addUser" %>

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
                    <td>用户ID</td>
                    <td> <asp:TextBox ID="userId"  runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td>姓名</td>
                    <td> <asp:TextBox ID="name"  runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td>性别</td>
                    <td>
                        <asp:RadioButton ID="male" runat="server"  Text="男" GroupName="sex" ></asp:RadioButton>
                        <asp:RadioButton ID="female" runat="server"  Text="女"  GroupName="sex"></asp:RadioButton>
                    </td>
                </tr>
                <tr>
                    <td>密码</td>
                    <td> <asp:TextBox ID="password" runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td>出生日期</td>
                    <td> <input type="date" id="user_date" runat="server" /></td>
                </tr>
                <tr>
                    <td>手机号</td>
                    <td> <asp:TextBox ID="phone"  runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="save" style="margin-top:10px; margin-left:30%;" Text="确定" runat="server" OnClick="save_Click"/>
                        <asp:Button  style="margin-top:10px; margin-left:15%;" ID="back" runat="server" OnClick="back_Click" Text="返回" />
                    </td>
                </tr>
                <tr>
                    <td rowspan="3" colspan="2" style="text-align:center;">
                        <asp:Label ID="tip" runat="server" Height="10px" ></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
