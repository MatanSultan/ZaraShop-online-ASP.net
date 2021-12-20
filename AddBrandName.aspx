<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeFile="AddBrandName.aspx.cs" Inherits="ZaraShopProject.AddBrandName" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <p>
        <br />
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <div class ="container ">
    <br />
    <br />

            <div class ="form-horizontal ">
                <h2>Add Brand</h2>
                <hr />
                <div class ="form-group">
                    <asp:Label ID="Label1" CssClass ="col-md-2 control-label " runat="server" Text="BrandName"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:TextBox ID="textBrandName" runat="server"></asp:TextBox>
                        
                    </div>
                </div>

                

                <div class ="form-group">
                    <div class ="col-md-2 "> </div>
                    <div class ="col-md-4 ">

                        <asp:Button ID="btnAddBrand"  runat="server" Text="Add" OnClick="btnAddBrand_Click"  />
                        
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        
                    </div>

                   
                </div>
                
              
                 



                


            </div>
</asp:Content>
