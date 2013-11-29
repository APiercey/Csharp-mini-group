<%@ Page Title="" Language="C#" MasterPageFile="~/WidgetGoods.Master" AutoEventWireup="true" CodeBehind="customerProfile.aspx.cs" Inherits="WidgetGoods.customerProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3>Customer Profile</h3>
    <asp:HiddenField ID="hdnID" runat="server" />
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
    
    <h3>&nbsp</h3> 
    <h3>List of Orders</h3>

    <asp:GridView ID="GridView1" runat="server" DataSourceID="salesReport"
            AutoGenerateColumns="False" DataKeyNames="CustomerID" ShowFooter="True" OnRowDataBound="GridView1_RowDataBound" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">           
        <Columns>
            <asp:BoundField DataField="OrderID" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="FirstName" HeaderText="First Name"/>
            <asp:BoundField DataField="LastName" HeaderText="Last Name"/>            
            <asp:BoundField DataField="OrderDate" HeaderText="Order Date"/>
            <asp:BoundField DataField="ProductName" HeaderText="Product Name"/>
            <asp:BoundField DataField="CompanyName" HeaderText="Customer Name"/>
            <asp:BoundField DataField="Quantity" HeaderText="Quantity"/>
            <asp:BoundField DataField="OrderTotal" HeaderText="Order Total" />
                               
        </Columns>
        <FooterStyle BackColor="#990000" BorderStyle="None" Font-Size="X-Large" ForeColor="White" BorderColor="#990000" Height="25px" Font-Bold="True" />
        </asp:GridView>

    <asp:SqlDataSource ID="salesReport" runat="server"
            SelectCommand="SELECT c.CustomerID, o.OrderID, e.FirstName, e.LastName, o.OrderDate, p.ProductName, s.CompanyName, od.Quantity, CONVERT(DECIMAL(10,2), (od.Quantity * od.UnitPrice)) AS OrderTotal
                            FROM Customers c JOIN Orders o
                            ON c.CustomerID = o.CustomerID JOIN [Order Details] od
                            ON od.OrderID = o.OrderID JOIN Products p
                            ON p.ProductID = od.ProductID JOIN Suppliers s
                            ON s.SupplierID = p.SupplierID JOIN Employees e
                            ON e.EmployeeID = o.EmployeeID
                            WHERE c.CustomerID =@CustomerID" 
            ConnectionString="<%$ ConnectionStrings:Northwind %>">

            <SelectParameters>
                <asp:ControlParameter Name="CustomerID" 
                    ControlID="hdnID"
                    PropertyName="Value"/>
            </SelectParameters>             

        </asp:SqlDataSource>
</asp:Content>
