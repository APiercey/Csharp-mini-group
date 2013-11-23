<%@ Page Title="" Language="C#" MasterPageFile="~/WidgetGoods.Master" AutoEventWireup="true" CodeBehind="manageEmployees.aspx.cs" Inherits="WidgetGoods.manageEmployees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="pnlViewEmployees" runat="server">
        <h3>Manage Employees</h3>

        <asp:Button ID="btnShowAddEmployee" runat="server" Text="Add An Employee" OnClick="btnShowAddEmployee_Click" />
        <br />
        <br />

        <asp:GridView ID="GridView2" runat="server" DataSourceID="sourceEmployees"
            AutoGenerateColumns="False" DataKeyNames="EmployeeID">           
        <Columns>
            <asp:BoundField DataField="EmployeeID" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="FirstName" HeaderText="First Name"/>
            <asp:BoundField DataField="LastName" HeaderText="Last Name"/>            
            <asp:BoundField DataField="Title" HeaderText="Title"/>
            <asp:BoundField DataField="HomePhone" HeaderText="Home Phone"/>
            <asp:BoundField DataField="Extension" HeaderText="Extension"/>
            <asp:HyperLinkField DataNavigateUrlFields="EmployeeID" 
                                DataNavigateUrlFormatString="manageEmployees.aspx?id={0}&action=edit" 
                                HeaderText="EmployeeID" 
                                Text="Edit"/>
        </Columns>
        </asp:GridView>

        <asp:SqlDataSource id="sourceEmployees" runat="server" 
            SelectCommand="SELECT EmployeeID, FirstName, LastName, Title, HomePhone, Extension FROM Employees" ConnectionString="<%$ ConnectionStrings:Northwind %>"
            UpdateCommand="UPDATE Employees SET FirstName=@FirstName, LastName=@LastName, Title=@Title, HomePhone=@HomePhone, Extension=@Extension WHERE EmployeeID=@EmployeeID" >
        </asp:SqlDataSource>

    </asp:Panel>
        
    <asp:Panel ID="pnlAddEmployee" runat="server" Visible="False">
        <h3><asp:Literal ID="litHeader" runat="server" /></h3>

        <asp:Button ID="btnShowEditEmployee" runat="server" Text="Display Employees To Edit" OnClick="btnShowEditEmployee_Click" />
        <br />
        <br />

        <section>
            <article>
                <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
                <br />
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                <br />
                <br />
                
                <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
                <br />
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                <br />
                <br />      
                
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                <br />
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <br />
                <br />
                
                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                <br />
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                <br />
                <br /> 
                
                <asp:Label ID="lblTitle" runat="server" Text="Title"></asp:Label>
                <br />
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                <br />
                <br />      
                
                <asp:Label ID="lblTitleOfCourtesy" runat="server" Text="Title of Courtesy"></asp:Label>
                <br />
                <asp:TextBox ID="txtTitleOfCourtesy" runat="server"></asp:TextBox>
                <br />
                <br />         
                
                <asp:Label ID="lblBirthDate" runat="server" Text="Birth Date"></asp:Label>
                <br />
                <asp:TextBox ID="txtBirthDate" runat="server"></asp:TextBox>
                <br />
                <br /> 

                <asp:Label ID="lblHireDate" runat="server" Text="Hire Date"></asp:Label>
                <br />
                <asp:TextBox ID="txtHireDate" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                <br />
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                <br />
                <br />

            </article>

            <article>

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

                <asp:Label ID="lblHomePhone" runat="server" Text="Home Phone"></asp:Label>
                <br />
                <asp:TextBox ID="txtHomePhone" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="lblExtension" runat="server" Text="Extension"></asp:Label>
                <br />
                <asp:TextBox ID="txtExtension" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="lblPhoto" runat="server" Text="Photo"></asp:Label>
                <br />
                <asp:FileUpload ID="fupPhoto" runat="server" />
                <br />
                <br />

                <asp:Label ID="lblNotes" runat="server" Text="Notes"></asp:Label>
                <br />
                <asp:TextBox ID="txtNotes" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="lblReportsTo" runat="server" Text="Reports To"></asp:Label>
                <br />
                <asp:TextBox ID="txtReportsTo" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="lblCommission" runat="server" Text="Commission"></asp:Label>
                <br />
                <asp:TextBox ID="txtCommission" runat="server"></asp:TextBox>
                <br />
                <br />

                <br />
                <asp:Button ID="btnAddEmployee" runat="server" Text="Add New Employee" OnClick="btnAddEmployee_Click" />
                <asp:Button ID="btnEditEmployee" runat="server" OnClick="btnEditEmployee_Click" Text="Edit Employee" />
            </article>
        </section>

    </asp:Panel>

</asp:Content>
