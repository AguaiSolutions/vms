<%@ Page Title="Employee Applied Leaves" Language="C#" MasterPageFile="~/Master/Aguai Master1.Master" AutoEventWireup="true" CodeBehind="AppliedLeaves.aspx.cs" Inherits="Aguai_Leave_Management_System.Emp_Leave" %>

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

                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" onrowcommand="GridView1_RowCommand" class="table table-bordered bg-danger" DataKeyNames="ID" BackColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="6">
                                            <Columns>
                                                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" Visible="false" />
                                                <asp:BoundField DataField="From_date" HeaderText="From_date" SortExpression="From_date" />
                                                <asp:BoundField DataField="To_date" HeaderText="To_date" SortExpression="To_date" />
                                                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                                <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                                                <asp:BoundField DataField="Approver" HeaderText="Approver" SortExpression="Approver" />
                                                <asp:BoundField DataField="Approval_Status" HeaderText="Approval_Status" SortExpression="Approval_Status" />
                                                <asp:BoundField DataField="Reason" HeaderText="Reason" SortExpression="Reason" />
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


