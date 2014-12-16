<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="Vacation_management_system.Web.Employee.EmployeeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        a {
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wrapper">

        <div id="page-wrapper">

            <div class="container-fluid" style="background-color: white;">
                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">Employees List
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="fa fa-users"></i>User Management 
                            </li>
                            <li class="active">
                                <i class="fa fa-suitcase"></i>Employees List
                            </li>
                        </ol>
                    </div>
                </div>


                <%--GridView For vaction Management Of All Employees--%>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title"></h3>
                    </div>
                    <div class="panel-body">
                        <asp:GridView ID="GvEmployeeList" runat="server" AutoGenerateColumns="False" OnRowCommand="GvEmployeeList_RowCommand" OnRowDataBound="GvEmployeeList_RowDataBound" CssClass="table table-bordered bg-danger" DataKeyNames="ID" CellPadding="4" class="table table-bordered bg-danger" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>

                                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" Visible="false" />
                                <asp:BoundField DataField="emp_no" HeaderText="Employee No" HeaderStyle-HorizontalAlign="Center" SortExpression="Emp_Reg_No" />
                                <asp:BoundField DataField="first_name" HeaderText="First Name" SortExpression="UserName" />
                                <asp:BoundField DataField="last_name" HeaderText="Last Name" SortExpression="From_date" />
                                <asp:BoundField DataField="gender" HeaderText="Gender" SortExpression="To_date" />
                                <asp:BoundField DataField="official_email" HeaderText="Official Email" SortExpression="Description" />
                                <asp:BoundField DataField="date_of_join" HeaderText="Date of joining" SortExpression="Type" />
                                <asp:BoundField DataField="contact_number" HeaderText="Contact" SortExpression="Approver" />
                                <asp:BoundField DataField="permanent_address" HeaderText="Address" SortExpression="Approval_Status" />
                                <asp:BoundField DataField="isactive" HeaderText=" Status" SortExpression="Approval_Status" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnEdit" CssClass="btn btn-primary" runat="server" CommandArgument='<%# Eval("ID")%>' CommandName="Edit" Text="Edit" />
                                    </ItemTemplate>
                                </asp:TemplateField>
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
        </div>
    </div>



</asp:Content>
