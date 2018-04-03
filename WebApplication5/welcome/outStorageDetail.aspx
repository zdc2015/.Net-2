<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="outStorageDetail.aspx.cs" Inherits="WebApplication5.welcome.outStorageDetail" %>

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
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
                ForeColor="#333333" 
                GridLines="None"
                AutoGenerateColumns="false"
                AllowPaging="true"
                OnPageIndexChanging="GridView1_PageIndexChanging">

                <AlternatingRowStyle BackColor="White" />

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

                    
                </Columns>

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
    </form>
</body>
</html>
