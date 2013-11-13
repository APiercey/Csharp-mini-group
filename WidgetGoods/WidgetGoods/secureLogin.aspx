<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="secureLogin.aspx.cs" Inherits="WidgetGoods.secureLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Secure Login</title>
    <link rel="stylesheet" href="main.css" type="text/css" />
</head>
<body>
    <header>
        <h1>Widget General Goods.com</h1>
    </header>
    <form id="form1" runat="server">
    <div id="minDivWrapper">
        <div id="mainDiv">
            <h3>Secure Login</h3>
            <asp:Label ID="lblLoginError" runat="server" Text=""></asp:Label>
            <br />
                
            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
            <br />
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            <br />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />    
        </div>
    </div>

    </form>
</body>
</html>


