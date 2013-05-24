<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Crearboard.aspx.cs" Inherits="Kanban_board_project.html.Crearboard" %>

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
        &nbsp;<br /><br /><br /><br /><br /><br /><br /><br /><br />
        <asp:Label ID="Label1" runat="server" Text="Crear mi  Board"></asp:Label>
        <br /><br /><br />
        <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
        
    &nbsp;&nbsp;&nbsp;
        
    <asp:TextBox ID="txtnombre" runat="server"></asp:TextBox>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
    <asp:Button ID="btncrear" runat="server" onclick="Button1_Click" Text="Crear" PostBackUrl="~/html/usuarioXboard.aspx"/>
    </p>
     
    </div>
    </form>
</body>
</html>