<%@ Page Title="" Language="C#" MasterPageFile="~/WidgetGoods.Master" AutoEventWireup="true" CodeBehind="addOrder.aspx.cs" Inherits="WidgetGoods.addOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Panel ID="pnlProductSearch" runat="server">

        <h3>Product Search</h3>

        <asp:TextBox ID="txtSearchBar" runat="server" Width="70%"></asp:TextBox>
        <asp:Button ID="btnSearchBar" runat="server" Text="Search For Products" />
        <br />
        <br />

        <asp:GridView ID="GridView2" runat="server" DataSourceID="productSearchData"
            AutoGenerateColumns="False" DataKeyNames="ProductID" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">           
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="Product Name"/>
                <asp:BoundField DataField="CompanyName" HeaderText="Suplier Name"/>
                <asp:BoundField DataField="CategoryName" HeaderText="Category Name"/>            
                      
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource id="productSearchData" runat="server" 
            SelectCommand="SELECT [Products].ProductID, [Products].ProductName, [Suppliers].CompanyName, [Categories].CategoryName 
                            FROM Products, Suppliers, Categories 
                            WHERE [Products].ProductName LIKE ('%' + @Search + '%') 
                            OR [Suppliers].CompanyName LIKE ('%' + @Search + '%')
                            OR [Categories].CategoryName LIKE ('%' + @Search + '%')" 
            ConnectionString="<%$ ConnectionStrings:Northwind %>" >
            <SelectParameters>

            <asp:ControlParameter Name="Search" 
                ControlID="txtSearchBar"
                PropertyName="Text"/>
            </SelectParameters>

        </asp:SqlDataSource>
    </asp:Panel>

    <asp:Panel ID="pnlAddOrder" runat="server" Visible="False">

        <h3>Add Order</h3>

        <asp:Button ID="btnShowSearchProducts" runat="server" Text="Search For A Different Product" OnClick="btnShowSearchProducts_Click" />
        <br />
        <br />

        <asp:Label ID="lblLabelCustomerName" runat="server" Text="Customer Name"></asp:Label>
        <br />
        <asp:Label ID="lblCustomerName" runat="server" Text=""></asp:Label>
        <br />
        <br />

        <asp:Label ID="lblEmployeeName" runat="server" Text="Employee Name"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlEmployeeName" runat="server"></asp:DropDownList>
        <br />
        <br />

        <section>
            <article>
                <asp:Label ID="lblOrderDate" runat="server" Text="Order Date"></asp:Label>
                <br />
                <asp:Calendar ID="cldOrderDate" runat="server"></asp:Calendar>
                <br />
                <br />

                <asp:Label ID="lblShippingCompany" runat="server" Text="Shipping Company"></asp:Label>
                <br />
                <asp:DropDownList ID="ddlShippingCompany" runat="server"></asp:DropDownList>
                <br />
                <br />

                <asp:Label ID="lblFreight" runat="server" Text="Freight"></asp:Label>
                <br />
                <asp:TextBox ID="txtFreight" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="lblShipName" runat="server" Text="Ship Name"></asp:Label>
                <br />
                <asp:TextBox ID="txtShipName" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="lblShipAddress" runat="server" Text="Ship Address"></asp:Label>
                <br />
                <asp:TextBox ID="txtShipAddress" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="lblShipCity" runat="server" Text="Ship City"></asp:Label>
                <br />
                <asp:TextBox ID="txtShipCity" runat="server"></asp:TextBox>
                <br />
                <br />

            </article>
            <article>
                <asp:Label ID="lblRequiredDate" runat="server" Text="Required Date"></asp:Label>
                <br />
                <asp:Calendar ID="cldRequiredDate" runat="server"></asp:Calendar>
                <br />
                <br />

                <asp:Label ID="lblShipRegion" runat="server" Text="Ship Region"></asp:Label>
                <br />
                <asp:TextBox ID="txtShipRegion" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="lblShipPostalCode" runat="server" Text="Ship Postal Code"></asp:Label>
                <br />
                <asp:TextBox ID="txtShipPostalCode" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="lblShipCountry" runat="server" Text="Ship Country"></asp:Label>
                <br />
                <asp:TextBox ID="txtShipCountry" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="lblQuantity" runat="server" Text="Quantity"></asp:Label>
                <br />
                <asp:DropDownList ID="ddlQuantity" runat="server"></asp:DropDownList>
                <br />
                <br />
                <br />

                <asp:Button ID="btnAddNewOrder" runat="server" Text="Add New Order" OnClick="btnAddNewOrder_Click" />
            </article>
        </section>
        
    </asp:Panel>
</asp:Content>
