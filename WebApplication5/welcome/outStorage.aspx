<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="outStorage.aspx.cs" Inherits="WebApplication5.welcome.outStorage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
            left:25%;
        }

    </style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="content">
            <asp:GridView ID="GridView1"  OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="false" 
                runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">

                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />

                <Columns>
                    <asp:TemplateField HeaderText="流水号">
                        <ItemTemplate>
                            <asp:Label ID="serial" runat="server" Text='<%# Bind("serial") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="申请人">
                        <ItemTemplate>
                            <asp:Label ID="applicant" runat="server" Text='<%# Bind("applicant") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="物品编号">
                        <ItemTemplate>
                            <asp:Label ID="isbn" runat="server" Text='<%# Bind("isbn") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField
                        >
                    <asp:TemplateField HeaderText="申请数量">
                        <ItemTemplate>
                            <asp:Label ID="num" runat="server" Text='<%# Bind("num") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="物品库存量">
                        <ItemTemplate>
                            <asp:Label ID="storage" runat="server" Text='<%# Bind("storage") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="申请日期">
                        <ItemTemplate>
                            <asp:Label ID="date" runat="server" Text='<%# Bind("date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <asp:Label ID="status" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:ButtonField ButtonType="Button"  Text="同意" HeaderText="同意" runat="server" CommandName="agree"/>
                    <asp:ButtonField ButtonType="Button"  Text="不同意" HeaderText="不同意" runat="server" CommandName="disagree"/>
                </Columns>


            </asp:GridView>
            
        </div>
    </form>
</body>
</html>
