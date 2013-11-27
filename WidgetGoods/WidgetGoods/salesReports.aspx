<%@ Page Title="" Language="C#" MasterPageFile="~/WidgetGoods.Master" AutoEventWireup="true" CodeBehind="salesReports.aspx.cs" Inherits="WidgetGoods.salesReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3>Sales Reports</h3>

    <asp:Label ID="lblEmployeeList" runat="server" Text="Employee List"></asp:Label>
    <asp:DropDownList ID="ddlEmployeeList" runat="server" AutoPostBack="False"></asp:DropDownList>
    <br />
    <br />

    <section>
        <article>
            <asp:Label ID="lblStartDate" runat="server" Text="Start Date"></asp:Label>
            <asp:Calendar ID="cldStartDate" runat="server"></asp:Calendar>
            <br />
            <br />
        </article>
        <article>
            <asp:Label ID="lblEndDate" runat="server" Text="End Date"></asp:Label>
            <asp:Calendar ID="cldEndDate" runat="server"></asp:Calendar>
            <br />
            <br />
        </article>
    </section>

    <asp:GridView ID="GridView1" runat="server" DataSourceID="salesReport" AutoGenerateColumns="False" DataKeyNames="EmployeeID" ShowFooter="True" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowDataBound="GridView1_RowDataBound">   
        
        <Columns>
            <asp:BoundField DataField="EmployeeID" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="FirstName" HeaderText="First Name"/>
            <asp:BoundField DataField="LastName" HeaderText="Last Name"/>            
            <asp:BoundField DataField="OrderID" HeaderText="Order ID"/>
            <asp:BoundField DataField="OrderDate" HeaderText="Order Date" FooterText="Total Sold:" />
     <asp:TemplateField HeaderText="Order Total" >
        <ItemTemplate>
            <asp:Label ID="lblOrderTotal" runat="server" Text='<%# Eval("OrderTotal") %>' DataFormatString="{0:c}" />
        </ItemTemplate>
        <FooterTemplate>
           <asp:Label ID="lblTotalSold" runat="server" />
        </FooterTemplate>
     </asp:TemplateField>
           
     <asp:TemplateField HeaderText="Customer Name" >
         <ItemTemplate>
            <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("CompanyName") %>' />
         </ItemTemplate>
         <FooterTemplate><b>Total Commission: </b>
            <asp:Label ID="lblTotalCommission" runat="server" Text="TotalCommission"/>
         </FooterTemplate>
            </asp:TemplateField>
        </Columns>

        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    
    <asp:SqlDataSource ID="salesReport" runat="server"
            SelectCommand="SELECT CONVERT(DECIMAL(10,2), (d.Quantity * d.UnitPrice)) AS OrderTotal, e.EmployeeID, e.FirstName, e.LastName, o.OrderID, d.Quantity, d.UnitPrice, o.OrderDate, c.ContactName, c.CompanyName 
                            FROM [Employees] e JOIN [Orders] o 
                            ON e.EmployeeID = o.EmployeeID JOIN [Order Details] d 
                            ON d.OrderID = o.OrderID JOIN [Customers] c 
                            ON c.CustomerID = o.CustomerID 
                            WHERE e.EmployeeID = @EmployeeID 
                            AND o.OrderDate > @StartDate AND o.OrderDate < @EndDate" 
            ConnectionString="<%$ ConnectionStrings:Northwind %>">

            <SelectParameters>
                <asp:ControlParameter Name="EmployeeID" 
                    ControlID="ddlEmployeeList"
                    PropertyName="SelectedValue"/>
            </SelectParameters>
            <SelectParameters>
                <asp:ControlParameter Name="StartDate" 
                    ControlID="cldStartDate"
                    PropertyName="SelectedDate"
                    Type="DateTime"/>
            </SelectParameters>
            <SelectParameters>
                <asp:ControlParameter Name="EndDate" 
                    ControlID="cldEndDate"
                    PropertyName="SelectedDate"
                    Type="DateTime"/>
            </SelectParameters>              

        </asp:SqlDataSource>
</asp:Content>

