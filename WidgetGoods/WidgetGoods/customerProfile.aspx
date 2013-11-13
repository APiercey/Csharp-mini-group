<%@ Page Title="" Language="C#" MasterPageFile="~/WidgetGoods.Master" AutoEventWireup="true" CodeBehind="customerProfile.aspx.cs" Inherits="WidgetGoods.customerProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3>Customer Profile</h3>

    <section>
        <article>
            <asp:Label ID="lblCompanyName" runat="server" Text="Company Name"></asp:Label>
            <br />
            <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="lblContactName" runat="server" Text="Contact Name"></asp:Label>
            <br />
            <asp:TextBox ID="txtContactName" runat="server"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="lblContactTitle" runat="server" Text="Contact Title"></asp:Label>
            <br />
            <asp:TextBox ID="txtContactTitle" runat="server"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
            <br />
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />
            <br />
        </article>
        <article>
            <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
            <br />
            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="lblPhone" runat="server" Text="Phone"></asp:Label>
            <br />
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="lblFax" runat="server" Text="Fax"></asp:Label>
            <br />
            <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
            <br />
            <br />

            <asp:Button ID="btnEditCustomer" runat="server" Text="Edit Customer" OnClick="btnEditCustomer_Click" />
            <asp:Button ID="btnAddNewOrder" runat="server" Text="Add New Order" OnClick="btnAddNewOrder_Click" />

        </article>
    </section>
</asp:Content>
