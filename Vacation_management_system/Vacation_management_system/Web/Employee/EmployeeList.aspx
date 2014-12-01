<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="Vacation_management_system.Web.Employee.EmployeeList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
    <style>
        a{
            color:white;
        }
    </style>
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
                  
                         <asp:GridView ID="GvEmployeeList" runat="server" AutoGenerateColumns="False"  cssclass="table table-bordered bg-danger" DataKeyNames="ID" CellPadding="4" class="table table-bordered bg-danger" ForeColor="#333333" GridLines="None">
                             <AlternatingRowStyle BackColor="White" />
                        <Columns>
                           
                            
                                                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" Visible="false" />
                                                <asp:BoundField DataField="emp_no" HeaderText="Employee Number" SortExpression="Emp_Reg_No" />
                                                <asp:BoundField DataField="first_name" HeaderText="First Name" SortExpression="UserName" />
                                                <asp:BoundField DataField="last_name" HeaderText="Last Name" SortExpression="From_date" />
                                                <asp:BoundField DataField="gender" HeaderText="Gender" SortExpression="To_date" />
                                                <asp:BoundField DataField="official_email" HeaderText="Official Email ID" SortExpression="Description" />
                                                <asp:BoundField DataField="date_of_join" HeaderText="Date of joining" SortExpression="Type" />
                                                <asp:BoundField DataField="contact_number" HeaderText="Phone number" SortExpression="Approver" />
                                                <asp:BoundField DataField="permanent_address" HeaderText="Address" SortExpression="Approval_Status" />
                             <asp:BoundField DataField="isactive" HeaderText=" Status" SortExpression="Approval_Status" />
                             <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="Add.aspx?id={0}" Text="Edit" ItemStyle-CssClass="btn  btn-lg btn-primary
                                " >
<ItemStyle CssClass="btn  btn-lg btn-primary
                                " ForeColor="White"></ItemStyle>
                                                </asp:HyperLinkField>
                        </Columns>
                             <EditRowStyle BackColor="#7C6F57" />
                                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#E3EAEB" />
                                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>


                     </div>
                </div>
         </div>
               
     

</asp:Content>
