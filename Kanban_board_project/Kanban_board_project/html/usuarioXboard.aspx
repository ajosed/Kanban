<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usuarioXboard.aspx.cs" Inherits="Kanban_board_project.html.usuarioXboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <p align="center">
    </p>
    <p align="center">
        <asp:Label ID="Label1" runat="server" Text="Usuarios que puedan ver mi board"></asp:Label>
    </p>
    <p align="center">
        &nbsp;</p>
    <p align="center">
        <asp:Label ID="Label2" runat="server" Text="Correo"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtnombre" runat="server" Width="171px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Enviar" style="height: 26px" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="continuar" 
            PostBackUrl="~/html/drawKanban.aspx" />
    </p>
    <p align="center">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:Kanban %>" 
            
            
            SelectCommand="SELECT USUARIOS.IDUSUARIO AS imagen, USUARIOS.NOMBRE, USUARIOS.PROFECION, ROLE.ROLE FROM USUARIOSxBOARD INNER JOIN USUARIOS ON USUARIOSxBOARD.IDUSUARIO = USUARIOS.IDUSUARIO INNER JOIN ROLE ON USUARIOSxBOARD.ROLE = ROLE.IDROLE AND USUARIOSxBOARD.ROLE = 1" 
            ProviderName="<%$ ConnectionStrings:Kanban.ProviderName %>">
        </asp:SqlDataSource>
        <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1" 
            DataKeyNames="imagen">
            <AlternatingItemTemplate>
                <tr style="background-color: #FFFFFF;color: #284775;">
                    
                    <td>
                        <asp:image ID="IMAGENLabel" runat="server"  Width='100px' Height='100px' align="center" ImageUrl='<%# "~/html/Handler1.ashx?id="+Eval("imagen") %>' />
                    </td>
                    <td>
                        <asp:Label ID="NOMBRELabel" runat="server" Text='<%# Eval("NOMBRE") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PROFECIONLabel" runat="server" Text='<%# Eval("PROFECION") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ROLELabel" runat="server" Text='<%# Eval("ROLE") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" 
                    style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td>
                            No se han devuelto datos.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <ItemTemplate>
                <tr style="background-color: #E0FFFF;color: #333333;">
                    
                    <td>
                        <asp:image ID="IMAGENLabel" runat="server"  Width='100px' Height='100px' align="center" ImageUrl='<%# "~/html/Handler1.ashx?id="+Eval("imagen") %>' />
                    </td>
                    <td>
                        <asp:Label ID="NOMBRELabel" runat="server" Text='<%# Eval("NOMBRE") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PROFECIONLabel" runat="server" Text='<%# Eval("PROFECION") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ROLELabel" runat="server" Text='<%# Eval("ROLE") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table ID="itemPlaceholderContainer" runat="server" border="1" 
                                style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color: #E0FFFF;color: #333333;">
                                    <th runat="server"></th>
                                    <th runat="server">NOMBRE</th>
                                    <th runat="server">PROFECION</th>
                                    <th runat="server">ROLE</th>
                                </tr>
                                <tr runat="server" id="itemPlaceholder">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" 
                            style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
    </p>
            
    </div>
    </form>
</body>
</html>