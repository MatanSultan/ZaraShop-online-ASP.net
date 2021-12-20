<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EmpManagement.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <center>




<form id="form1" runat="server">
    
        <asp:HiddenField ID="hfUserID" runat="server" />
    <table>
        <tr>
            <td>
                user Name</td>
            <td colspan="2">
                <asp:TextBox ID="txtusername" runat="server" />
            </td>
        </tr>
        <tr>
                  <td>
                        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
            
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="2">
                <asp:Button ID="btn_login" runat="server" OnClick="btn_login_Click" Text="Login" />
            </td>
        </tr>
        <tr>
                    <td colspan="2" style="text-align: center">
                    <asp:Label ID="labelError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </td>
                </tr>

    </table>
           </center>
    </div>
    </form>
</body>
         

</html>
