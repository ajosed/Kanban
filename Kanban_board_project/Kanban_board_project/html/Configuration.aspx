<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Configuration.aspx.cs" Inherits="Kanban_board_project.html.Configuration" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />

     <ext:Panel ID="Panel1" 
            runat="server" 
            Title="Accordion with Deferred Loaded Panels" 
            Width="500" 
            Height="300" 
            Layout="Accordion">
         <Items>
             <ext:Button ID="Button1" runat="server" Text="Submit">
             </ext:Button>
         </Items>
         </ext:Panel>
    </div>
    </form>
    <script">


    </script>
</body>
</html>
