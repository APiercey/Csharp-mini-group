<%@ Page Title="" Language="C#" MasterPageFile="~/WidgetGoods.Master" AutoEventWireup="true" CodeBehind="manageSuppliers.aspx.cs" Inherits="WidgetGoods.manageSuppliers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3>Manage Suppliers</h3>

    <asp:Label ID="lblSuppliers" runat="server" Text="Supplier List"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlSuppliers" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSuppliers_SelectedIndexChanged"></asp:DropDownList>
    <br />
    <br />

    <asp:Panel ID="pnlSupplierForm" runat="server">

        <asp:Label ID="lblSupplierID" runat="server" Text="Supplier ID"></asp:Label>
        <br />
        <br />
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

                <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                <br />
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                <br />
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="lblRegion" runat="server" Text="Region"></asp:Label>
                <br />
                <asp:TextBox ID="txtRegion" runat="server"></asp:TextBox>
                <br />
                <br />
            </article>
            <article>
                <asp:Label ID="lblPostalCode" runat="server" Text="Postal Code"></asp:Label>
                <br />
                <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label>
                <br />
                <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="lblPhone" runat="server" Text="Phone Number"></asp:Label>
                <br />
                <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="lblFax" runat="server" Text="Fax Number"></asp:Label>
                <br />
                <asp:TextBox ID="txtFax" runat="server" TextMode="Phone"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="lblHomePage" runat="server" Text="Home Page"></asp:Label>
                <br />
                <asp:TextBox ID="txtHomePage" runat="server"></asp:TextBox>
                <br />
                <br />
        
                <br />
                <asp:Button ID="btnUpdateSupplier" runat="server" Text="Update Supplier" OnClick="btnUpdateSupplier_Click" />
                <asp:Button ID="btnAddSupplier" runat="server" Text="Add New Supplier" OnClick="btnAddSupplier_Click" />
            </article>
        </section>

    </asp:Panel>

</asp:Content>
