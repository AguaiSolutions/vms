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


                <br />
                <div class="row">
                <div class="col-lg-6">
                <div class="panel panel-default" style="float:left;width: 550px;">
                    <div class="panel-heading">
                        <h3 class="panel-title">Apply New Vacation</h3>
                    </div>
                    <div class="panel-body">


                        <div style="width: 500px;">
                            <div>
                                <label class="control-label">Leave Type:</label>
                                <asp:DropDownList class="form-control" ID="drpLeaveType" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpLeaveType" ErrorMessage="Please select leave type." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <br />

                            <div>
                                <label class="control-label">From:</label>
                                <asp:TextBox ID="txtFromDate" class="form-control" name="From Date" placeholder="From Date" runat="server" />
                                <asp:RequiredFieldValidator ID="Rfdfromdate" runat="server" ControlToValidate="txtFromDate" ErrorMessage="This felid cant be null" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <label class="control-label">To:</label>
                                <asp:TextBox ID="txtToDate" class="form-control" name="To Date" placeholder="To Date" runat="server" />
                                <asp:RequiredFieldValidator ID="Rfdtodate" runat="server" ControlToValidate="txtToDate" ErrorMessage="This felid cant be null" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            &nbsp;<asp:Label ID="lblManager_Email" runat="server" Visible="False"></asp:Label>
&nbsp;<asp:Label ID="lblManager_Id" runat="server" Visible="False"></asp:Label>
                            <br />

                            <div>
                                <label class="control-label">Reason:</label>
                                <asp:TextBox ID="txtReason" TextMode="MultiLine" class="form-control" name="Reason" placeholder="Reason" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtReason" ErrorMessage="This felid cant be null" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <br />

                            <div>
                                <asp:label id="lblApprover" runat="server" class="control-label">Approver:</asp:label>
                                <asp:TextBox ID="txtApprover" ReadOnly="true" class="form-control" name="Approver" runat="server" />
                            </div>
                        </div>

                        <div class="form-group form-inline" style="margin-top: 50px;">
                            <asp:Button ID="btnApply" CssClass="btn btn-primary" runat="server" Text="Apply" OnClick="btnApply_Click" />

                            <asp:Button ID="btnClear" CssClass="btn btn-primary" runat="server" Text="Clear" OnClick="btnClear_Click" />

                            <asp:HyperLink ID="hyperlinkCancel" CssClass="btn btn-primary" runat="server" NavigateUrl="~/Web/MyVacation/MyVacation.aspx">Cancel</asp:HyperLink>
                        </div>

                </div>
                </div>
                </div>
            <div class="col-lg-6">

                 <div class="panel panel-default" style="float:right;width: 450px;">
                    <div class="panel-heading">
                        <h3 class="panel-title">Vacation Summary</h3>
                    </div>
                    <div class="panel-body">


                        <div style="width: 325px; height: 69px;">
                            
                       
                            <table style="width: 109%; height: 82px;">
                                <tr>
                                    <td class="auto-style1"> <label class="control-label">Current year vacations:</label></td>
                                    <td>
                                        <asp:Label ID="lblCurrent" runat="server"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style1"><label class="control-label">Previous year vacations:</label></td>
                                    <td>
                                        <asp:Label ID="lblPrevious" runat="server"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style1"> <label class="control-label">Remaining leaves:</label></td>
                                    <td>
                                        <asp:Label ID="lblRemain" runat="server"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                    </div>
                </div>
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
