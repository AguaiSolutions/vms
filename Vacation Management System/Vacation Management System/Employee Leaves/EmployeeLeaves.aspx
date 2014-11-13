<%@ Page Title="EmployeeLeaves" Language="C#" MasterPageFile="~/Master/Aguai Master1.Master" AutoEventWireup="true" CodeBehind="EmployeeLeaves.aspx.cs" Inherits="Aguai_Leave_Management_System.EmployeeLeaves" %>

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

                                    <%--Label: Employee Name--%>
                                    <div class="btn-group form-inline">
                                        <label>Employee Name</label>
                                        <asp:TextBox ID="txtEmployee" class="form-control warning" placeholder="Please enter name" runat="server" />
                                    </div>

                                    <%--Button: Search--%>
                                    <asp:Button ID="Button1" Text="Search" OnClick="btnSearch_Click" class="btn btn-default btn-success" runat="server" />

                                    <%--Button: Clear--%>
                                    <asp:Button ID="Button2" Text="Clear" OnClick="btnClear_Click" class="btn btn-default btn-success" runat="server" />

                                    <div>
                                        <br />

                                        <%--GridView For Leave Management Of All Employees--%>
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" class="table table-bordered bg-danger" DataKeyNames="ID" BackColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="6">
                                            <Columns>
                                                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" Visible="false" />
                                                <asp:BoundField DataField="Emp_Reg_No" HeaderText="Emp_Reg_No" SortExpression="Emp_Reg_No" />
                                                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                                                <asp:BoundField DataField="From_date" HeaderText="From_date" SortExpression="From_date" />
                                                <asp:BoundField DataField="To_date" HeaderText="To_date" SortExpression="To_date" />
                                                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                                <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                                                <asp:BoundField DataField="Approver" HeaderText="Approver" SortExpression="Approver" />
                                                <asp:BoundField DataField="Approval_Status" HeaderText="Approval_Status" SortExpression="Approval_Status" />
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnApprove" class="btn btn-default btn-danger" runat="server" CommandArgument='<%# Eval("ID")%>' CommandName="Approve" Text="Approve" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnReject"  class="btn btn-default btn-danger" data-toggle="modal"  href="#myModal" runat="server" CommandArgument='<%# Eval("ID")%>' CommandName="Reject" Text="Reject" />
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



                                    <div>
                                        <br />

                                        <%--GridView For Leave Management Of Individual Employee--%>
                                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView3_RowCommand" class="table table-bordered bg-danger" DataKeyNames="ID" BackColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="6">
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

                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="panel-body">
                        <div id="morris-area-chart"></div>
                    </div>


                    <div class="modal modal-wide fade" id="myModal">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">

                                    <h1 class="modal-title">Leave Reject</h1>
                                </div>
                                <div class="modal-body">
                                    <table style="width: 57%;">
                                        <tr>
                                            <td class="auto-style1">Reason:</td>
                                            <td class="auto-style2">
                                                <asp:TextBox ID="txtReason" runat="server" Height="65px" TextMode="MultiLine" Width="339px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>

                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnReject" runat="server" OnClick="btnReject_Click" CssClass="btnbtn-primary" Width="80px" Font-Size="Large" Text="Reject" />
                                    <asp:Button ID="btnCancel" runat="server" CssClass="btnbtn-primary" data-dismiss="modal" Width="80px" Font-Size="Large" Text="Cancel" />

                                </div>
            </div><!-- /.modal-content -->
            </div><!-- /.modal-dialog -->
            </div><!-- /.modal -->



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



