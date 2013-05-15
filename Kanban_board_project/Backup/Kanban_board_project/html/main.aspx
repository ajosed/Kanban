<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Kanban_board_project.html.main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Kanban Boards Project</title>

<link href="style.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
    </script>
</head>

<body>
<div class="style_2"><span class="style3"><a href="http://www.zonnebank-studio-vergelijk.nl" title="Zonnebank Zonnestudio"><strong>Zonnebank zonnestudio</strong></a></span></div>
<div id="wrap">
<div id="topbar">
<h1 id="sitename"><a href="main.aspx" target="_blank"><img src="images/multimedia/logo.png" width=250 height=65/></a></h1>
  <div id="menus">
  <ul id="topmenu">
<li><a href="register.aspx">Registrarse</a>
</li>
</ul>
</div>
</div>

<div id="content">
<div id="mainpage">
<p>

            <link rel="stylesheet" href="login_files/formoid1/formoid-default.css" type="text/css" />
<script type="text/javascript" src="login_files/formoid1/jquery.min.js"></script>
<form id="Form1" class="formoid-default" style="background-color:#FFFFFF;font-size:14px;font-family:'Open Sans','Helvetica Neue','Helvetica',Arial,Verdana,sans-serif;width:480px" title="My Formoid form" method="post" runat=server>
	
    <asp:ScriptManager ID="ScriptManager1" runat="server" 
        ScriptPath="C:\Users\Boston\Documents\Visual Studio 2010\Projects\Kanban_board_project\Kanban_board_project\html\main.aspx.cs">
    </asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
</asp:UpdatePanel>

    <div class="element-text" ><h2 class="title">Iniciar Sesión</h2></div>
	<div class="element-input" ><label class="title" id="lbluser">Usuario<asp:Label 
            ID="LblUser" runat="server" Font-Italic="True" ForeColor="#FF6600"></asp:Label>
        </label><input type="text" name="input" id="user" required="required" runat="server" /></div>
	<div class="element-password" ><label class="title">Contraseña<asp:Label 
            ID="LblPass" runat="server" Font-Italic="True" ForeColor="#FF6600"></asp:Label>
        </label><input type="password" name="password" value="" id="pass" required="required" runat="server"/></div>
	<div class="element-submit" >
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Acceder" />
    </div>

</form>
<script type="text/javascript" src="login_files/formoid1/formoid-default.js"></script>
</p>
</div>
    
</div>
</body>
</html>
