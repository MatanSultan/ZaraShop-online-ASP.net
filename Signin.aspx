<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Signin.aspx.cs" Inherits="ZaraShopProject.Signin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>


            sssUser Name :
            <br />
            <asp:TextBox ID="txtuser" runat="server"></asp:TextBox>
            <br />
            password:<br />   <asp:TextBox ID="txtpass"  type="password" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <br />
            <asp:CheckBox ID="remeberbtn" runat="server" />


        </div>
        <asp:Label ID="LabelEror" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        if you not register u can register<a href ="SignUp.aspx">here</a></form>
</body>
</html>
