<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" Inherits="WebApplication5.welcome.WebForm3" %>

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
             align-content:flex-start;
        }

        .method{
            align-content:flex-start;
            margin-bottom:20px;
        }

    </style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="method">
            <asp:Button ID="view_all" runat="server" Text="查看全部" OnClick="view_all_Click" style="margin-right:20px;"/>
            用户名：<asp:TextBox ID="key" runat="server" ></asp:TextBox>
            <asp:Button ID="view_part" runat="server" Text="查询" OnClick="view_part_Click" />
        </div>

        <div class="content">
        <asp:GridView ID="gv_xml" runat="server" AutoGenerateColumns="False"   
            OnRowCancelingEdit="gv_xml_RowCancelingEdit"   
            OnRowUpdating="gv_xml_RowUpdating"  
            OnRowEditing="gv_xml_RowEditing"   
            OnRowDeleting="gv_xml_RowDeleting"
            OnPageIndexChanging="gv_xml_PageIndexChanging"
            CellPadding="4" ForeColor="#333333" 
            GridLines="None" AllowPaging="true" PageSize="5">

            <Columns>

            <asp:TemplateField HeaderText="ID">  
                    <ItemTemplate>
                       <asp:Label  ID="Label0" style="text-align:center;"  Width="100px" Text='<%# DataBinder.Eval(Container.DataItem, "id")%>' runat="server"></asp:Label>
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="Txtbox0" runat="server"  Width="100px" Text='<%#  DataBinder.Eval(Container.DataItem,"id") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  

                <asp:TemplateField HeaderText="姓名">  
                    <ItemTemplate>  
                        <asp:Label  style="text-align:center;"  Width="100px" Text='<%# DataBinder.Eval(Container.DataItem, "name")%>' runat="server"></asp:Label>
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="Txtbox1"  Width="100px" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"name") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>

                <asp:TemplateField HeaderText="性别">  
                    <ItemTemplate>
                        <asp:Label  style="text-align:center;"  Width="100px" Text='<%# DataBinder.Eval(Container.DataItem, "gender")%>' runat="server"></asp:Label>
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:DropDownList runat="server" ID="ddl" Text='<%# Bind("gender") %>' Width="100px">
                            <asp:ListItem>男</asp:ListItem>
                            <asp:ListItem>女</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="手机">  
                    <ItemTemplate>  
                        <asp:Label  style="text-align:center;"  Width="100px" Text='<%# DataBinder.Eval(Container.DataItem, "phone")%>' runat="server"></asp:Label> 
                    </ItemTemplate>  
                    <EditItemTemplate>
                        <asp:TextBox ID="Txtbox3" Width="100px"  runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"phone") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>

                <asp:TemplateField HeaderText="出生日期">  
                    <ItemTemplate>  
                        <asp:Label  style="text-align:center;"  Width="100px" Text='<%# DataBinder.Eval(Container.DataItem, "birthday")%>' runat="server"></asp:Label>
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <input type="date" runat="server" style="width:100px;" title='<%# DataBinder.Eval(Container.DataItem, "birthday")%>' id="dateText"/>
                    </EditItemTemplate>  
                </asp:TemplateField>

                <asp:TemplateField HeaderText="密码">  
                    <ItemTemplate>  
                        <asp:Label  style="text-align:center;"  Width="100px" Text='<%# DataBinder.Eval(Container.DataItem, "password")%>' runat="server"></asp:Label>
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="Txtbox5"  Width="100px" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"password") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>

                <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
                  
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
            <asp:Button ID="addUser" Text="增加用户" OnClick="addUser_Click" runat="server" />
        </div>

    </form>
</body>
</html>
