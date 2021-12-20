<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" Codefile="addcat.aspx.cs" Inherits="ZaraShopProject.addcat" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br /><br /><br />
<br />
  <h1>
            enter name of Category:</p>
  </h1>  <p>

    <p>
        <asp:TextBox ID="TextBoxcat" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="addcatbtn" runat="server" Height="32px" OnClick="addcatbtn_Click" Text="add" Width="93px" />
    </p>
    <p>
        <asp:Label ID="lblmsg" runat="server"></asp:Label>
</p>



</asp:Content>
