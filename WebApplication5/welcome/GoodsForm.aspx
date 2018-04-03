<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsForm.aspx.cs" Inherits="WebApplication5.welcome.GoodsForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <style type="text/css">
        .content{
            width:fit-content;
            margin:auto;
        }

        html,body{
            width:95%;
            height:95%;
            position:absolute;
            top:0;
            left:0;right:0;bottom:0;
        }

        form{
            box-sizing:border-box;
            width:90%;
            height:90%;
            margin:auto;
            padding-top:5%;
        }
        .add{
            position:relative;
            top:2%;
            left:10%;
        }

        .method{
            align-content:flex-start;
            margin-bottom:20px;
        }

    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="method">
            <asp:Button ID="view_all" runat="server" Text="查看全部" OnClick="view_all_Click" style="margin-right:20px;"/>
            物品名字：<asp:TextBox ID="key" runat="server" ></asp:TextBox>
            <asp:Button ID="view_part" runat="server" Text="查询" OnClick="view_part_Click" />
        </div>
        <div class="content">
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                OnRowEditing="GridView1_RowEditing"
                OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                AutoGenerateColumns="False"
                OnRowDeleting="GridView1_RowDeleting"
                OnRowUpdating="GridView1_RowUpdating"
                OnPageIndexChanging="GridView1_PageIndexChanging"
                AllowPaging="true"
                PageSize="8"
                >

            <Columns>
                <asp:TemplateField HeaderText="ISBN">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("isbn") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" style="text-align:center" Text='<%# Bind("isbn") %>' Width="100px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="名字">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("name") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" style="text-align:center" Text='<%# Bind("name") %>' Width="100px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="数量">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("num") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" style="text-align:center" Text='<%# Bind("num") %>' Width="100px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="类别">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddl" runat="server" Text='<%# Bind("type") %>' Width="100px">
                            <asp:ListItem>文具</asp:ListItem>
                            <asp:ListItem>纸张</asp:ListItem>
                            <asp:ListItem>刀具</asp:ListItem>
                            <asp:ListItem>单据</asp:ListItem>
                            <asp:ListItem>礼品</asp:ListItem>
                            <asp:ListItem>其他</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" style="text-align:center" Text='<%# Bind("type") %>' Width="100px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="规格">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("specifications") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" style="text-align:center" Text='<%# Bind("specifications") %>' Width="100px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="型号">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("model") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" style="text-align:center" runat="server" Text='<%# Bind("model") %>' Width="100px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="产地">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("origin") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label  style="text-align:center" ID="Label8" runat="server" Text='<%# Bind("origin") %>' Width="100px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="图片" HeaderStyle-HorizontalAlign="Center">
                    
                    <ItemTemplate>
                        <asp:Image ID="image" runat="server" ImageUrl='<%# Bind("picture") %>' Width="50px" Height="50px"/>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:CommandField HeaderText="操作" ShowEditButton="true" ShowDeleteButton="true"/>
            </Columns>

            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        </div>
       
        <div class="add" style="margin-top:10px;">
            <asp:Button ID="addGoods" Text="增加物品" OnClick="addGoods_Click" runat="server" />
        </div>
    </form>
</body>
</html>
