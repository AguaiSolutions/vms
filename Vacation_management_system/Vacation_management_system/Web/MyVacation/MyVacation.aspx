<%@ Page Title="My Vacation" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="MyVacation.aspx.cs" Inherits="Vacation_management_system.Web.MyVacation.Vacation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function openModal() {
            $('#myModal').modal('show');
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div id="wrapper">

        <div id="page-wrapper">

            <div class="container-fluid">
                <!-- /.row -->
                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">My Vacation
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="fa fa-plane"></i> Leave Management
                            </li>
                            <li class="active">
                                <i class="fa fa-calendar"></i> My Vacation
                            </li>
                        </ol>
                    </div>
                </div>
                <!-- Page Heading End -->

                <div class="row">
                    <div class="col-lg-12">

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                </h3>
                            </div>
                            <div class="panel-body">
                                <div class="btn-group form-group">
                                    <asp:Button ID="Button1" Text="Apply Leave" OnClick="btnApplyLeave_Click" CssClass="btn btn-primary" runat="server" />
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblEmpty" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>

                                    <asp:Label ID="lblRow_Id" runat="server" Visible="False"></asp:Label>

                                    <asp:Label ID="lblLeaves" runat="server" Visible="False"></asp:Label>

                                    <asp:Label ID="lblStatus" runat="server" Visible="False"></asp:Label>

                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" class="table table-bordered bg-danger" DataKeyNames="id" CellPadding="4" ForeColor="#333333" GridLines="None">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" Visible="false" />
                                            <asp:BoundField DataField="first_name" HeaderText="Employee Name" SortExpression="first_name" />
                                            <asp:BoundField DataField="from_date" HeaderText="From Date" SortExpression="from_date" />
                                            <asp:BoundField DataField="to_date" HeaderText="To Date" SortExpression="to_date" />
                                            <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description" />
                                            <asp:BoundField DataField="type_id" HeaderText="Type" SortExpression="Type" />
                                            <asp:BoundField DataField="approval_status" HeaderText="Approval Status" SortExpression="Approval_Status" />
                                            <asp:BoundField DataField="reason" HeaderText="Reason" SortExpression="Reason" />
                                            <asp:BoundField DataField="leaves" HeaderText="leaves" SortExpression="leave" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="btncancel" runat="server" CommandArgument='<%# Eval("ID")%>' Text="Cancel Vacation" CssClass="btn btn-primary" OnClick="btncancel" />
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
                                    <div class="btn-group form-group"">
                                        <asp:Button ID="btnapplyleave" Text="Apply Leave" OnClick="btnApplyLeave_Click" CssClass="btn btn-primary" runat="server" />
                                    </div>
                             </div>
                            </div>
                        </div>
                    </div>
                </div>

                <%--  modal for cancel vacation--%>
                <div class="modal modal-wide fade" id="myModal">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="col-lg-8">
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                        <h3 class="panel-title modal-title">please enter the reason</h3>
                                    </div>
                                    <div class="panel-body">

                                        <div class="center-block">


                                            <div class="form-group">

                                                <asp:TextBox ID="txtCreason" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCreason" ErrorMessage="This felid cant be null" ForeColor="Red"></asp:RequiredFieldValidator>
                                                --%>
                                            </div>
                                            <asp:Button ID="Button2" runat="server" OnClick=" btnCancelReason_Click" CssClass="btn btn-primary" Font-Size="Large" Text="Cancel Vacation" />&nbsp;&nbsp;
                                            <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" data-dismiss="modal" Font-Size="Large" Text="Back" />

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /.modal-content -->

                </div>
                <!-- /.modal-dialog -->
            </div>
            <!-- /.modal -->

        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#wrapper -->


</asp:Content>


