<?php

define('EMAIL_FOR_REPORTS', 'erick.horror@gmail.com');
define('RECAPTCHA_PRIVATE_KEY', '@privatekey@');
define('FINISH_URI', 'http://');
define('FINISH_ACTION', 'message');
define('FINISH_MESSAGE', 'Thanks for filling out my form!');
define('UPLOAD_ALLOWED_FILE_TYPES', 'doc, docx, xls, csv, txt, rtf, html, zip, jpg, jpeg, png, gif');

require_once('login_files/formoid1/handler.php');

?><!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
	<meta http-equiv="content-type" content="text/html; charset=utf-8" />
	<title>My Formoid form</title>
</head>
<body style="background-color:#EBEBEB">


<? if (frmd_message()): ?>
<link rel="stylesheet" href="login_files/formoid1/formoid-default.css" type="text/css" />
<span class="alert alert-success"><?=FINISH_MESSAGE;?></span>
<? else: ?>
<!-- Start Formoid form-->
<link rel="stylesheet" href="login_files/formoid1/formoid-default.css" type="text/css" />
<script type="text/javascript" src="login_files/formoid1/jquery.min.js"></script>
<form class="formoid-default" style="background-color:#FFFFFF;font-size:14px;font-family:'Open Sans','Helvetica Neue','Helvetica',Arial,Verdana,sans-serif;width:480px" title="My Formoid form" method="post">
	<div class="element-text" ><h2 class="title">Iniciar Sesion</h2></div>
	<div class="element-input"  <?frmd_add_class("input")?>><label class="title">Usuario</label><input type="text" name="input" /></div>
	<div class="element-password"  <?frmd_add_class("password")?>><label class="title">Contraseña</label><input type="password" name="password" value="" /></div>
	<div class="element-submit" ><input type="submit" value="Acceder"/></div>

</form>
<script type="text/javascript" src="login_files/formoid1/formoid-default.js"></script>

<p class="frmd"><a href="http://formoid.com/">Code For Html Form Formoid.com 1.5</a></p>
<!-- Stop Formoid form-->
<? endif; ?>


</body>
</html>
