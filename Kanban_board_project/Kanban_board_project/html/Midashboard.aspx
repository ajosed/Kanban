<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Midashboard.aspx.cs" Inherits="Kanban_board_project.html.Midashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" RowStyle-BackColor="#0000cc" AlternatingRowStyle-ForeColor="#ffffff" RowStyle-ForeColor="#ffffff" AlternatingRowStyle-BackColor="#3399ff" HeaderStyle-BackColor="#000000" HeaderStyle-ForeColor="White" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="IDBOARD" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand">
            <AlternatingRowStyle BackColor="#3399FF" ForeColor="White" />
            <Columns>
                <asp:CommandField SelectText="...View..." ShowSelectButton="True" />
                <asp:BoundField DataField="IDBOARD" HeaderText="IDBOARD" SortExpression="IDBOARD" InsertVisible="False" ReadOnly="True" />
                <asp:BoundField DataField="Expr1" HeaderText="NOMBRE" SortExpression="Expr1" ReadOnly="True" />
                <asp:BoundField DataField="Expr2" HeaderText="FECHA" SortExpression="Expr2" ReadOnly="True" />
                <asp:ButtonField CommandName="btndelete" Text="...X..." />
            </Columns>
            <HeaderStyle BackColor="Black" ForeColor="White" />
            <RowStyle BackColor="#0000CC" ForeColor="White" />
        </asp:GridView>
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Kanban %>" SelectCommand="SELECT BOARDS.IDBOARD, CONVERT (varchar, BOARDS.NOMBRE) AS Expr1, CONVERT (varchar, BOARDS.FECHAINICIO) AS Expr2 
FROM BOARDS 
INNER JOIN USUARIOSxBOARD ON BOARDS.IDBOARD = USUARIOSxBOARD.IDBOARD 
INNER JOIN USUARIOS ON USUARIOSxBOARD.IDUSUARIO = USUARIOS.IDUSUARIO 
WHERE (USUARIOSxBOARD.IDUSUARIO = 1) AND (USUARIOSxBOARD.ROLE = 2 OR USUARIOSxBOARD.ROLE = 1) GROUP BY BOARDS.IDBOARD, CONVERT (varchar, BOARDS.NOMBRE), CONVERT (varchar, BOARDS.FECHAINICIO)"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
