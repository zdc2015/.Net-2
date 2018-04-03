<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Instorage.aspx.cs" Inherits="WebApplication5.welcome.Instorage" %>

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
            left:5%;
        }

    </style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div class="content">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
            OnPageIndexChanging="GridView1_PageIndexChanging"
            CellPadding="4" ForeColor="#333333" 
            GridLines="None" AllowPaging="true" PageSize="5">

            <Columns>

            <asp:TemplateField HeaderText="流水号">  
                    <ItemTemplate>
                       <asp:Label  style="text-align:center;" Text='<%# DataBinder.Eval(Container.DataItem, "serial")%>' runat="server"></asp:Label>
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="Txtbox0" runat="server"  Width="100px" Text='<%#  DataBinder.Eval(Container.DataItem,"serial") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  

                <asp:TemplateField HeaderText="物品序列">  
                    <ItemTemplate>  
                        <asp:Label  style="text-align:center;"  Width="100px" Text='<%# DataBinder.Eval(Container.DataItem, "isbn")%>' runat="server"></asp:Label>
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="Txtbox1"  Width="100px" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"isbn") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>

                <asp:TemplateField HeaderText="购买数量">  
                    <ItemTemplate>
                        <asp:Label  style="text-align:center;"  Width="100px" Text='<%# DataBinder.Eval(Container.DataItem, "num")%>' runat="server"></asp:Label>
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="Txtbox2"  Width="100px" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"num") %>'></asp:TextBox>  
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="单价">  
                    <ItemTemplate>  
                        <asp:Label  style="text-align:center;"  Width="100px" Text='<%# DataBinder.Eval(Container.DataItem, "price")%>' runat="server"></asp:Label> 
                    </ItemTemplate>  
                    <EditItemTemplate>
                        <asp:TextBox ID="Txtbox3" Width="100px"  runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"price") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>

                <asp:TemplateField HeaderText="购买日期">  
                    <ItemTemplate>  
                        <asp:Label  style="text-align:center;"  Width="100px" Text='<%# DataBinder.Eval(Container.DataItem, "purchase")%>' runat="server"></asp:Label>
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <input type="date" runat="server" style="width:100px;" title='<%# DataBinder.Eval(Container.DataItem, "purchase")%>' id="dateText"/>
                    </EditItemTemplate>  
                </asp:TemplateField>

                <asp:TemplateField HeaderText="总价">  
                    <ItemTemplate>  
                        <asp:Label  style="text-align:center;"  Width="100px" Text='<%# DataBinder.Eval(Container.DataItem, "totPrice")%>' runat="server"></asp:Label>
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="Txtbox5"  Width="100px" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"totPrice") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
            </Columns>

            <AlternatingRowStyle Wrap="False" BackColor="White" />
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
            <asp:Button ID="addInstorage" Text="物品入库" OnClick="addInstorage_Click" runat="server" />
        </div>
    </form>
</body>
</html>
