﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Kanban_board_project.html.login"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Kanban Boards Project - Registro</title>

<link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div class="style_2"><span class="style3"><a href="http://www.zonnebank-studio-vergelijk.nl" title="Zonnebank Zonnestudio"><strong>Zonnebank zonnestudio</strong></a></span></div>
<div id="wrap">
<div id="topbar">
  <h1 id="sitename"><a href="main.aspx" target="_blank"><img src="images/multimedia/logo.png" width=250 height=65/></a></h1>
  <div id="menus">
  <ul id="topmenu">
<li><a href="main.aspx">Iniciar Sesión</a>
</li>
</ul>
</div>
</div>
<div id="content">
<div id="mainpage">
<p>

<link rel="stylesheet" href="login_files/formoid1/formoid-default.css" type="text/css" />
<script type="text/javascript" src="login_files/formoid1/jquery.min.js"></script>
<form enctype="multipart/form-data" class="formoid-default" style="background-color:#FFFFFF;font-size:16px;font-family:Tahoma,Geneva,sans-serif;width:480px" title="Kanban Board Project" method="post" runat=server>
	
<asp:ScriptManager ID="ScriptManager1" runat="server" 
    ScriptPath="C:\Users\Boston\Documents\Visual Studio 2010\Projects\Kanban_board_project\Kanban_board_project\html\register.aspx.cs">
</asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Label ID="LblErrorMessage" runat="server" Font-Italic="True" 
            ForeColor="#FF9900"></asp:Label>
    </ContentTemplate>
</asp:UpdatePanel>
    
    <div class="element-text" ><h2 class="title">Regístrate en Kanban Board</h2></div>
	<div class="element-input" ><label class="title">Nombre Completo<span class="required">*</span></label><input type="text" name="input" id="name" required="required" runat=server/></div>
	<div class="element-select" ><label class="title">Profesión<span class="required">*</span></label><asp:DropDownList 
            ID="DropDownList1" runat="server">
        <asp:ListItem>Diseñador gráfico</asp:ListItem>
        <asp:ListItem>DBA</asp:ListItem>
        <asp:ListItem>Analizador</asp:ListItem>
        <asp:ListItem>Programador</asp:ListItem>
        </asp:DropDownList>
    </div>


	<div class="element-email" ><label class="title" id="email_label">Correo Electrónico<span class="required">*<asp:Label 
            ID="LblEmail" runat="server" Font-Italic="True" ForeColor="#FF9900"></asp:Label>
        </span></label><input type="text" name="email" value="" id="email" required="required" runat=server/></div>
	<div class="element-input" ><label class="title">Nombre de Usuario<span class="required">*<asp:Label 
            ID="LblUser" runat="server" Font-Italic="True" ForeColor="#FF9900"></asp:Label>
        </span></label><input type="text" name="input1" id="user" required="required" runat=server/></div>
	<div class="element-password" ><label class="title">Contraseña<span class="required">*</span></label><input type="password" name="password" value="" id="pass" required="required" runat=server/></div>
	<div class="element-file" ><label class="title">Subir su imagen de identificación</label><input type="file" name="file" id="image" runat=server/></div>
    <div class="element-email" ><label class="title">Código en la imagen<span class="required">*<asp:Label 
            ID="LblImage" runat="server" Font-Italic="True" ForeColor="#FF9900"></asp:Label>
        </span></label><input type="text" name="code" value="" id="code" required="required" runat=server/></div>
     <asp:Image ID="Image1" runat="server" ImageUrl="CImage.aspx"/>

    <div class="element-submit" >
        <asp:Button ID="Button1" runat="server" Text="Enviar" onclick="Button1_Click" />
    </div>

</form>
<script type="text/javascript" src="registration_files/formoid1/formoid-default.js"></script>

</p>
</div>
<div id="sidebar">

</div>
<div id="sidebarcontents"> 
<ul id="menu">

</ul>
</div>

  <div id="sidebarbottom"></div>
</div>
<div class="clear"></div>
</div>

</div>
</body>

</html>
