<%@ Page Title="My Vacation" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="MyVacation.aspx.cs" Inherits="Vacation_management_system.Web.MyVacation.Vacation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>

        $(document).ready(function () {
            validate();
            $('#<%= txtCreason.ClientID %>').keyup(validate);
         });

         function validate() {
             $('#<%= Button2.ClientID %>').addClass('btn');
            if ($('#<%= txtCreason.ClientID %>').val().length > 0) {
                $('#<%= Button2.ClientID %>').prop("disabled", false);
                $('#<%= Button2.ClientID %>').addClass('btn-primary');

                 <%--$('#<%= btnRole.ClientID %>').css('backgroundColor', 'blue');--%>
            }
            else {
                $('#<%= Button2.ClientID %>').prop("disabled", true);
                $('#<%= Button2.ClientID %>').removeClass('btn-primary');

            }
        }
        
        function openModal() {
            $('#myModal').modal('show');
        }

        $(document).ready(function () {
            $('.cancel').click(function () {
                $('#<%= txtCreason.ClientID %>').val('');
                var x = document.getElementById('<%=txtCreason.ClientID%>').value;
                if (x == "") {
                    $('#<%= Button2.ClientID %>').prop("disabled", true);
                    $('#<%= Button2.ClientID %>').removeClass('btn-primary');


                }
            });
          });

    </script>

    <style>
          th
        {
        text-align:center;
        }
    </style>
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
                                <i class="fa fa-plane"></i> Vacations
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

                                <div style="float:right;">
                            <div class="form-group">
                                <label class="control-label" id="lblApprovedVacation"  runat="server">Total Approved vacations:</label>
                                <asp:Label ID="lblApproved" runat="server"></asp:Label> <b> , </b>
                             
                                <label class="control-label" runat="server" id="lblBalance">Total Remaining vacations:</label>
                                <asp:Label ID="lblRemaining"  runat="server"></asp:Label>
                            </div>
                                </div>

                                <div class="btn-group form-group">
                                    <asp:Button ID="btnapplyleave1" Text="Apply Vacation" OnClick="btnApplyLeave_Click" CssClass="btn btn-primary" runat="server" />
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblEmpty" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>

                                    <asp:Label ID="lblRow_Id" runat="server" Visible="False"></asp:Label>

                                    <asp:Label ID="lblLeaves" runat="server" Visible="False"></asp:Label>

                                    <asp:Label ID="lblStatus" runat="server" Visible="False"></asp:Label>
                                    
                                    <asp:Label ID="lblType" runat="server" Visible="False"></asp:Label>

                                    <asp:GridView ID="GridView1" runat="server" OnPageIndexChanging="grdview1_PageIndexChanging" AutoGenerateColumns="False" AllowPaging="true" PageSize="10" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" class="table table-bordered bg-danger" DataKeyNames="id" CellPadding="4" ForeColor="#333333" EmptyDataText="No records found" ShowHeaderWhenEmpty="true" GridLines="None">
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
                                            <asp:BoundField DataField="leaves" HeaderText="No of Days" SortExpression="leave" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="btncancel" runat="server" CommandArgument='<%# Eval("ID")%>' Text="Cancel Vacation" CssClass="btn btn-primary" OnClick="btncancel" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#7C6F57" />
                                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        
                                        <PagerStyle BackColor="#1C5E55"  ForeColor="White" HorizontalAlign = "Right" CssClass = "GridPager"  />
                                        <RowStyle BackColor="#E3EAEB" />
                                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                                    </asp:GridView>
                                    <div class="btn-group form-group">
                                        <asp:Button ID="btnapplyleave" Text="Apply Vacation" OnClick="btnApplyLeave_Click" CssClass="btn btn-primary" runat="server" />
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
                                            <asp:Button ID="Button2" runat="server" OnClick="btnCancelReason_Click" CssClass="btn btn-primary" Font-Size="Large" Text="Cancel Vacation" />&nbsp;&nbsp;
                                            <asp:Button ID="Button3" runat="server" CssClass="cancel btn btn-primary" data-dismiss="modal" Font-Size="Large" Text="Back" />

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


