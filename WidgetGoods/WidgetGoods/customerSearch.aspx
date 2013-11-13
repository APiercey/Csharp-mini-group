<%@ Page Title="" Language="C#" MasterPageFile="~/WidgetGoods.Master" AutoEventWireup="true" CodeBehind="customerSearch.aspx.cs" Inherits="WidgetGoods.customerSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="pnlCustomerSearch" runat="server">

        <h3>Customer Search</h3>

        <asp:TextBox ID="txtSearchBar" runat="server" Width="70%"></asp:TextBox>
        <asp:Button ID="btnSearchBar" runat="server" Text="Search For Customers" />
        <br />
        <br />

        <asp:Button ID="btnShowAddCustomer" runat="server" Text="Add A New Customer" OnClick="btnShowAddCustomer_Click" />
        <br />
        <br />

        <asp:GridView ID="GridView2" runat="server" DataSourceID="customerSearchData"
            AutoGenerateColumns="False" DataKeyNames="CustomerID" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">           
            <Columns>
                <asp:BoundField DataField="CompanyName" HeaderText="Company Name"/>
                <asp:BoundField DataField="ContactName" HeaderText="Contact Name"/>
                <asp:BoundField DataField="ContactTitle" HeaderText="Contact Title"/>            
                <asp:BoundField DataField="Email" HeaderText="Email"/>
                <asp:BoundField DataField="City" HeaderText="City"/>
                <asp:BoundField DataField="Phone" HeaderText="Phone"/>
                <asp:BoundField DataField="Fax" HeaderText="Fax"/>
                      
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource id="customerSearchData" runat="server" 
            SelectCommand="SELECT * FROM Customers WHERE ContactName LIKE ('%' + @Search + '%') OR CompanyName LIKE ('%' + @Search + '%')" 
            ConnectionString="<%$ ConnectionStrings:Northwind %>" >
            <SelectParameters>

            <asp:ControlParameter Name="Search" 
                ControlID="txtSearchBar"
                PropertyName="Text"/>
            </SelectParameters>

        </asp:SqlDataSource>
    </asp:Panel>

    <asp:Panel ID="pnlAddNewCustomer" runat="server" Visible="False">

        <h3>Add New Customer</h3>

        <asp:Button ID="btnShowCustomerSearch" runat="server" Text="Search For A Customer" OnClick="btnShowCustomerSearch_Click" />
        <br />
        <br />

        <section>
            <article>
                <asp:Label ID="lblCustomerID" runat="server" Text="Customer ID"></asp:Label>
                <br />
                <asp:TextBox ID="txtCustomerID" runat="server"></asp:TextBox>
                <br />
                <br />

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
            </article>
            <article>
                <asp:Label ID="lblRegion" runat="server" Text="Region"></asp:Label>
                <br />
                <asp:TextBox ID="txtRegion" runat="server"></asp:TextBox>
                <br />
                <br />

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

                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                <br />
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Button ID="btnAddNewCustomer" runat="server" Text="Add New Customer" OnClick="btnAddNewCustomer_Click" />
            </article>
        </section>
    </asp:Panel>

</asp:Content>
