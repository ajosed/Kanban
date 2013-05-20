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
        <div   align="right" id="div1">
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Configuracion" />
        </div>

        <ext:Panel ID="Panel1" runat="server" Height="300"  Title="Title" TitleAlign="Center" AutoScroll="true">
            <LayoutConfig>
                <ext:HBoxLayoutConfig Align="Stretch" />
            </LayoutConfig>

            <Items>
            </Items>
            
        <Plugins>
            <ext:BoxReorderer ID="BoxReorderer1" runat="server" />
        </Plugins>
            
        </ext:Panel>

    </div>
    </form>
</body>
</html>
