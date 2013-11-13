<%@ Page Title="" Language="C#" MasterPageFile="~/WidgetGoods.Master" AutoEventWireup="true" CodeBehind="manageProducts.aspx.cs" Inherits="WidgetGoods.manageProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3>Manage Products</h3>

    <asp:Label ID="lblProducts" runat="server" Text="Product List"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlProducts" runat="server" ></asp:DropDownList>
    <br />
    <br />

    <asp:Panel ID="pnlProductForm" runat="server">

        <asp:Label ID="lblProductID" runat="server" Text="Product ID"></asp:Label>
        <br />
        <br />
        <section>
            <article>
                <asp:Label ID="lblProductName" runat="server" Text="Product Name"></asp:Label>
                <br />
                <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="lblSupplierID" runat="server" Text="Supplier"></asp:Label>
                <br />
                <asp:DropDownList ID="ddlSupplierID" runat="server"></asp:DropDownList>
                <br />
                <br />

                <asp:Label ID="lblCategoryID" runat="server" Text="Category"></asp:Label>
                <br />
                <asp:DropDownList ID="ddlCategoryID" runat="server"></asp:DropDownList>
                <br />
                <br />

                <asp:Label ID="lblQuantityPerUnit" runat="server" Text="Quantity Per Unit"></asp:Label>
                <br />
                <asp:TextBox ID="txtQuantityPerUnit" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="lblUnitPrice" runat="server" Text="Unit Price"></asp:Label>
                <br />
                <asp:TextBox ID="txtUnitPrice" runat="server"></asp:TextBox>
                <br />
                <br />
            </article>
            <article>
                <asp:Label ID="lblUnitsInStock" runat="server" Text="Units In Stock"></asp:Label>
                <br />
                <asp:TextBox ID="txtUnitsInStock" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="lblUnitsOnOrder" runat="server" Text="Units On Order"></asp:Label>
                <br />
                <asp:TextBox ID="txtUnitsOnOrder" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="lblReorderLevel" runat="server" Text="Reorder Level"></asp:Label>
                <br />
                <asp:TextBox ID="txtReorderLevel" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="lblDiscontinued" runat="server" Text="Discontinued"></asp:Label>
                <br />
                <asp:CheckBox ID="ckbDiscontinued" runat="server" />
                <br />
                <br />

                <br />
                <asp:Button ID="btnUpdateProduct" runat="server" Text="Update Product" OnClick="btnUpdateProduct_Click" />
                <asp:Button ID="btnAddProduct" runat="server" Text="Add New Product" OnClick="btnAddProduct_Click" />
            </article>
        </section>       

    </asp:Panel>
</asp:Content>
