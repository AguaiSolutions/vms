<%@ Page Title="Apply New Vacation" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="ApplyNewVacation.aspx.cs" Inherits="Vacation_management_system.Web.MyVacation.ApplyNewVacation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(function () {
            $("[id$=txtFromDate]").datepicker({
                format: 'dd/mm/yyyy',
                autoclose: true,
                todayHighlight: true
            });
        });
        $(function () {
            $("[id$=txtToDate]").datepicker({
                format: 'dd/mm/yyyy',
                autoclose: true,
                todayHighlight: true
            });
        });
    </script>

    <style type="text/css">
        .auto-style1 {
            width: 79px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wrapper">

        <div id="page-wrapper">

            <div class="container-fluid" style="background-color: white;">
                <!-- /.row -->

                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">Apply New Vacation
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="fa fa-plane"></i> Leave Management
                            </li>
                            <li class="active">
                                <i class="glyphicon glyphicon-plus-sign"></i> Apply New Vacation
                            </li>
                        </ol>
                    </div>
                </div>
                <!-- Page Heading End -->

                <!-- Apply new vacation form body -->



                <div class="row">
                    <div class="col-lg-6">
                        <div class="panel panel-default" style="float: left; width: 550px;">
                            <div class="panel-heading">
                                <h3 class="panel-title"></h3>
                            </div>
                            <div class="panel-body">

                                <div class="form-group form-inline">
                                    <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Apply" OnClick="btnApply_Click" />

                                    <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Clear" OnClick="btnClear_Click" />

                                    <asp:HyperLink ID="hyperlink1" CssClass="btn btn-primary" runat="server" NavigateUrl="~/Web/MyVacation/MyVacation.aspx">Cancel</asp:HyperLink>
                                </div>
                                <div class="form-group">

                                    <asp:ValidationSummary CssClass="alert alert-danger" DisplayMode="List" ID="vldSummary" ForeColor="Black" runat="server" />

                                </div>
                                <div style="width: 500px;">
                                    <div class="form-group">
                                        <label class="control-label">Leave Type:</label>
                                        <asp:DropDownList class="form-control" ID="drpLeaveType" runat="server">
                                        </asp:DropDownList>
                                    </div>


                                    <div class="form-group">
                                        <label class="control-label">From:</label>
                                        <asp:TextBox ID="txtFromDate" class="form-control" name="From Date" placeholder="From Date" runat="server" />
                                    </div>


                                    <div class="form-group">
                                        <label class="control-label">To:</label>
                                        <asp:TextBox ID="txtToDate" class="form-control" name="To Date" placeholder="To Date" runat="server" />
                                    </div>
                                    &nbsp;<asp:Label ID="lblManager_Email" runat="server" Visible="False"></asp:Label>
                                    &nbsp;<asp:Label ID="lblManager_Id" runat="server" Visible="False"></asp:Label>


                                    <div class="form-group">
                                        <label class="control-label">Reason:</label>
                                        <asp:TextBox ID="txtReason" TextMode="MultiLine" class="form-control" name="Reason" placeholder="Reason" runat="server" />
                                    </div>


                                    <div class="form-group">
                                        <label class="control-label">Approver:</label>
                                        <asp:Label ID="lblApprover" runat="server" class="control-label"></asp:Label>
                                        <asp:TextBox ID="txtApprover" ReadOnly="true" class="form-control" name="Approver" runat="server" />
                                    </div>
                                </div>

                                <div class="form-group form-inline" style="margin-top: 30px;">
                                    <asp:Button ID="btnApply" CssClass="btn btn-primary" runat="server" Text="Apply" OnClick="btnApply_Click" />

                                    <asp:Button ID="btnClear" CssClass="btn btn-primary" runat="server" Text="Clear" OnClick="btnClear_Click" />

                                    <asp:HyperLink ID="hyperlinkCancel" CssClass="btn btn-primary" runat="server" NavigateUrl="~/Web/MyVacation/MyVacation.aspx">Cancel</asp:HyperLink>
                                </div>

                                <div>
                                    <asp:RequiredFieldValidator Display="None" ID="Rfdfromdate" runat="server" ControlToValidate="txtFromDate" ErrorMessage="please enter the From date " ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator Display="None" ID="Rfdtodate" runat="server" ControlToValidate="txtToDate" ErrorMessage="please enter the To date " ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtReason" ErrorMessage="please enter the Reason" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default" style="float: right; width: 300px; margin-right: 100px;">
                        <div class="panel-heading">
                            <h3 class="panel-title">Vacation Summary</h3>
                        </div>
                        <div class="panel-body form-group">
                            <div>
                                <label class="control-label">Current year vacations:</label>
                                <asp:Label ID="lblCurrent" runat="server"></asp:Label>
                            </div>
                            <div>
                                <label class="control-label">Previous year vacations:</label>
                                <asp:Label ID="lblPrevious" runat="server"></asp:Label>
                            </div>
                            <div>
                                <label class="control-label">Total Remaining vacations:</label>
                                <asp:Label ID="lblRemain" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>

                    <div class="panel panel-default" style="float: right; width: 300px; margin-right: 100px;">
                        <div class="panel-heading">
                            <h3 class="panel-title">Applied Vacation Summary</h3>
                        </div>
                        <div class="panel-body form-group">
                            <div>
                                <asp:GridView ID="grdAvs" runat="server" AutoGenerateColumns="False" class="table table-bordered bg-danger" DataKeyNames="id" CellPadding="4" ForeColor="#333333" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" Visible="false" />
                                        <asp:BoundField DataField="from_date" HeaderText="From Date" SortExpression="from_date" />
                                        <asp:BoundField DataField="to_date" HeaderText="To Date" SortExpression="to_date" />
                                        <asp:BoundField DataField="approval_status" HeaderText="Approval Status" SortExpression="Approval_Status" />
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
                <!-- /.container-fluid -->

            </div>
            <!-- /#page-wrapper -->

        </div>
        <!-- /#wrapper -->
</asp:Content>
