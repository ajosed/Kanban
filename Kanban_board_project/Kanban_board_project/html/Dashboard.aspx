<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Kanban_board_project.html.Dashboard" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Kanban Boards Project</title>

<link href="style.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form1" runat="server">
<div class="style3"></div><div class="style_2"><span class="style3"><a href="http://www.zonnebank-studio-vergelijk.nl" title="Zonnebank Zonnestudio"><strong>Zonnebank zonnestudio</strong></a></span></div>
<div id="wrap">
<div id="topbar">
  <h1 id="sitename"><a href="Dashboard.aspx" target="_blank"><img src="images/multimedia/logo.png" width=180 height=65/></a></h1>
</div>
</div>
        <center>
            <br />
            <ext:ResourceManager ID="ResourceManager1" runat="server" />
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
            <br />
            <br />
            <ext:Button ID="Button1" runat="server" OnDirectClick="Button1_DirectClick" Text="New Kanbanboard" />
            <br />

        <asp:GridView ID="GridView1" runat="server" RowStyle-BackColor="#0000cc" AlternatingRowStyle-ForeColor="#ffffff" RowStyle-ForeColor="#ffffff" AlternatingRowStyle-BackColor="#3399ff" HeaderStyle-BackColor="#000000" HeaderStyle-ForeColor="White" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="IDBOARD" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand">
            <AlternatingRowStyle BackColor="#3399FF" ForeColor="White" />
            <Columns>
                <asp:CommandField SelectText="Ver" ShowSelectButton="True">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:CommandField>
                <asp:BoundField DataField="IDBOARD" HeaderText="IDBOARD" SortExpression="IDBOARD" InsertVisible="False" ReadOnly="True" />
                <asp:BoundField DataField="Expr1" HeaderText="Nombre" SortExpression="Expr1" ReadOnly="True" />
                <asp:BoundField DataField="Expr2" HeaderText="Fecha" SortExpression="Expr2" ReadOnly="True" />
                <asp:ButtonField CommandName="borr" Text="Delete" />
            </Columns>
            <HeaderStyle BackColor="Black" ForeColor="White" />
            <RowStyle BackColor="#0000CC" ForeColor="White" />
            <EmptyDataTemplate>
                <asp:Label runat="server" Text="No se an creado boards, animate y crea 1"/>
            </EmptyDataTemplate>
        </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Kanban %>" SelectCommand="SELECT BOARDS.IDBOARD, CONVERT (varchar, BOARDS.NOMBRE) AS Expr1, CONVERT (varchar, BOARDS.FECHAINICIO) AS Expr2 
FROM BOARDS 
INNER JOIN USUARIOSxBOARD ON BOARDS.IDBOARD = USUARIOSxBOARD.IDBOARD 
INNER JOIN USUARIOS ON USUARIOSxBOARD.IDUSUARIO = USUARIOS.IDUSUARIO 
WHERE (USUARIOSxBOARD.IDUSUARIO =@user) AND (USUARIOSxBOARD.ROLE = 2 OR USUARIOSxBOARD.ROLE = 1) GROUP BY BOARDS.IDBOARD, CONVERT (varchar, BOARDS.NOMBRE), CONVERT (varchar, BOARDS.FECHAINICIO)">
                <SelectParameters>
                    <asp:SessionParameter Name="user" SessionField="userid" />
                </SelectParameters>
            </asp:SqlDataSource>
    </center>
        </form>

</body>
</html>
