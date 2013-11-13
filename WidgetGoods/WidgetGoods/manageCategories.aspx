<%@ Page Title="" Language="C#" MasterPageFile="~/WidgetGoods.Master" AutoEventWireup="true" CodeBehind="manageCategories.aspx.cs" Inherits="WidgetGoods.manageCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3>Manage Categories</h3>

    <asp:Label ID="lblCategories" runat="server" Text="Category List"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlCategories" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategories_SelectedIndexChanged"></asp:DropDownList>
    <br />
    <br />

    <asp:Panel ID="pnlCategoryForm" runat="server">
        <asp:Label ID="lblCategoryIDLabel" runat="server" Text="Category ID"></asp:Label>
        <br />
        <asp:Label ID="lblCategoryID" runat="server" Text=""></asp:Label>
        <br />
        <br />

        <asp:Label ID="lblCategoryName" runat="server" Text="Category Name"></asp:Label>
        <br />
        <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
        <br />
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="lblPicture" runat="server" Text="Picture"></asp:Label>
        <br />
        <asp:FileUpload ID="fupPicture" runat="server" AllowMultiple="False" />
        <br />
        <br />

        <asp:Button ID="btnUpdateCategory" runat="server" Text="Update Category" OnClick="btnUpdateCategory_Click" />
        <asp:Button ID="btnAddCategory" runat="server" Text="Add New Category" OnClick="btnAddCategory_Click" />

    </asp:Panel>
</asp:Content>
