<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="drawKanban.aspx.cs" Inherits="Kanban_board_project.html.drawKanban" %>

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
    
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div align="right">
            <ext:Button ID="Button1" runat="server" Text="Configuration"   PostBackUrl="www.google.com"/>
        </div>

        <ext:Panel ID="Panel1" runat="server" Height="300" Title="Title" TitleAlign="Center" >
            <LayoutConfig>
                <ext:HBoxLayoutConfig Align="Stretch" />
            </LayoutConfig>
            <Items>


            </Items>
        </ext:Panel>
    
    </div>
    </form>
</body>
</html>
