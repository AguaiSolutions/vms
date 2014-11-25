<%@ Page Title="My Vacation" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="MyVacation.aspx.cs" Inherits="Vacation_management_system.Web.MyVacation.MyVacation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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

                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" onrowcommand="GridView1_RowCommand" class="table table-bordered bg-danger" DataKeyNames="id" BackColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="6">
                                            <Columns>
                                                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" Visible="false" />
                                                <asp:BoundField DataField="from_date" HeaderText="From" SortExpression="from_date" />
                                                <asp:BoundField DataField="to_date" HeaderText="To" SortExpression="to_date" />
                                                <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description" />
                                                <asp:BoundField DataField="type_id" HeaderText="Type" SortExpression="Type" />
                                                <asp:BoundField DataField="approval_status" HeaderText="Approval Status" SortExpression="Approval_Status" />
                                                <asp:BoundField DataField="reason" HeaderText="Reason" SortExpression="Reason" />
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbtnCancel" class="btn btn-default btn-danger" runat="server" CommandArgument='<%# Eval("ID")%>' CommandName="Cancel" Text="Cancel" />
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
                                    <div class="btn-group form-inline">
                                        <asp:Button ID="btnapplyleave" Text="Apply Leave" OnClick="btnApplyLeave_Click" class="btn btn-default btn-warning" runat="server" />
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


