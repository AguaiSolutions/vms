<%@ Page Title="Employee Details" Language="C#" MasterPageFile="~/Aguai Master1.Master" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="Aguai_Leave_Management_System.Admin_UserManage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <section>

        <div id="wrapper">

            <div id="page-wrapper">

                <div class="container-fluid">
                    <!-- /.row -->

                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">

                                    <div>
                                        <br />
                                        <asp:GridView ID="GridView2" runat="server" class="table table-bordered bg-danger" DataKeyNames="ID" AutoGenerateColumns="False" OnRowCommand="GridView2_RowCommand" BackColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="6">
                                            <Columns>
                                                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" Visible="false" />
                                                <asp:BoundField DataField="Emp_Reg_No" HeaderText="Emp_Reg_No" SortExpression="Emp_Reg_No" />
                                                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                                                <asp:BoundField DataField="Email" HeaderText="Email Id" SortExpression="Email Id" />
                                                <asp:BoundField DataField="Contact" HeaderText="Contact" SortExpression="Contact" />
                                                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbtnDeactivate" class="btn btn-default btn-danger" runat="server" CommandArgument='<%# Eval("ID")%>' CommandName="Deactivate" Text="Deactivate"
                                                            OnClientClick="return confirm('Are you sure you want to deactivate this record?')"
                                                            CausesValidation="false" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                            <RowStyle BackColor="White" ForeColor="#003399" />
                                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                            <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                            <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                            <SortedDescendingHeaderStyle BackColor="#002876" />
                                        </asp:GridView>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div id="morris-area-chart"></div>
                    </div>
                </div>

            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /#wrapper -->

        <!-- jQuery -->
        <script src="js/jquery.js"></script>

        <!-- Bootstrap Core JavaScript -->
        <script src="js/bootstrap.min.js"></script>

        <!-- Morris Charts JavaScript -->
        <script src="js/plugins/morris/raphael.min.js"></script>
        <script src="js/plugins/morris/morris.min.js"></script>
        <script src="js/plugins/morris/morris-data.js"></script>

    </section>

</asp:Content>







