<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="Vacation_management_system.Web.Employee.EmployeeList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wrapper"  >

            <div id="page-wrapper">

                <div class="container-fluid"  style="background-color:white;">
                    <!-- /.row -->

                    <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">
                           Employees List
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="glyphicon glyphicon-home"></i>  <a href="~/Web/Dashboard/Dashboard.aspx" runat="server">Dashboard</a>
                            </li>
                            <li class="active">
                                <i class="glyphicon glyphicon-th-list"></i> Employees List
                            </li>
                        </ol>
                    </div>
                </div>


          <%--GridView For vaction Management Of All Employees--%>
                  
                         <asp:GridView ID="GvEmployeeList" runat="server" AutoGenerateColumns="False"  cssclass="table table-bordered bg-danger" DataKeyNames="ID" BackColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" BorderColor="#DEBA84" CellSpacing="2">
                        <Columns>
                           
                            
                                                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" Visible="false" />
                                                <asp:BoundField DataField="emp_no" HeaderText="Employee Number" SortExpression="Emp_Reg_No" />
                                                <asp:BoundField DataField="first_name" HeaderText="First Name" SortExpression="UserName" />
                                                <asp:BoundField DataField="last_name" HeaderText="Last Name" SortExpression="From_date" />
                                                <asp:BoundField DataField="gender" HeaderText="Gender" SortExpression="To_date" />
                                                <asp:BoundField DataField="official_email" HeaderText="Ofical EmailID" SortExpression="Description" />
                                                <asp:BoundField DataField="date_of_join" HeaderText="Date of joining" SortExpression="Type" />
                                                <asp:BoundField DataField="contact_number" HeaderText="Phone number" SortExpression="Approver" />
                                                <asp:BoundField DataField="permanent_address" HeaderText="Address" SortExpression="Approval_Status" />
                             <asp:BoundField DataField="isactive" HeaderText=" Status" SortExpression="Approval_Status" />
                             <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="Add.aspx?id={0}" Text="Edit"></asp:HyperLinkField>
                        </Columns>
                             <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                             <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                             <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                             <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                             <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                             <sortedascendingcellstyle backcolor="#FFF1D4">
                             </sortedascendingcellstyle>
                             <sortedascendingheaderstyle backcolor="#B95C30">
                             </sortedascendingheaderstyle>
                             <sorteddescendingcellstyle backcolor="#F1E5CE">
                             </sorteddescendingcellstyle>
                             <sorteddescendingheaderstyle backcolor="#93451F">
                             </sorteddescendingheaderstyle>
                    </asp:GridView>


                     </div>
                </div>
         </div>
               
     

</asp:Content>
