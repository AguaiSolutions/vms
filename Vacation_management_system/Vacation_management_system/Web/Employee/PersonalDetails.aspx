<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="PersonalDetails.aspx.cs" Inherits="Vacation_management_system.Web.Employee.PersonalDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            //$("[id$=txtDOB]").datepicker();
            $(".dob").datepicker({
                format: 'dd/mm/yyyy',
                autoclose: true,
                todayHighlight: true
            });
        });
        var specialKeys = new Array();
        //specialKeys.push(music); //Backspace
        $(function () {
            $(".numeric").bind("keypress", function (e) {
                var keyCode = e.which ? e.which : e.keyCode;
                var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
                $(".error").css("display", ret ? "none" : "inline");
                return ret;
            });
            $(".numeric").bind("paste", function (e) {
                return false;
            });
            $(".numeric").bind("drop", function (e) {
                return false;
            });
        });

        $(function () {
            $('.alpha').keydown(function (e) {
                if (e.shiftKey || e.ctrlKey || e.altKey) {
                    e.preventDefault();
                } else {
                    var key = e.keyCode;
                    if (!((key == 8) || (key == 32) || (key == 46) || (key >= 35 && key <= 40) || (key >= 65 && key <= 90))) {
                        e.preventDefault();
                    }
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="wrapper">

        <div id="page-wrapper">

            <div class="container-fluid" style="background-color: white;">
                <!-- /.row -->

                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">Personal Details
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="fa fa-users"></i>User Management 
                            </li>
                            <li class="active">
                                <i class="glyphicon glyphicon-user"></i>Personal Details
                            </li>
                        </ol>
                    </div>
                </div>
                <!-- Page Heading End -->
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default" style="float: left; height: 400px; width: 1072px;">
                            <div class="panel-heading">
                                <h3 class="panel-title">Personal Details</h3>
                            </div>
                            <div class="panel-body form-group">

                                <asp:Label ID="lblEmpty1" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                <asp:DataList ID="DataList1" runat="server"
                                    OnCancelCommand="DataList1_CancelCommand"
                                    OnEditCommand="DataList1_EditCommand"
                                    OnUpdateCommand="DataList1_UpdateCommand">

                                    <ItemTemplate>
                                        <div class="form-group" style="float: left">
                                            <table class="table table-hover">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label13" runat="server" Text='<%#Eval("id")%>' Visible="false" /></td>
                                                    <td>
                                                        <label class="control-label">First Name:</label></td>
                                                    <td>
                                                        <asp:Label ID="Label15" runat="server" Text='<%#Eval("first_name")%>' /></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label16" runat="server" Text='<%#Eval("id")%>' Visible="false" /></td>
                                                    <td>
                                                        <label class="control-label">Gender:</label></td>
                                                    <td>
                                                        <asp:Label ID="Label17" runat="server" Text='<%#Eval("gender")%>' /></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label20" runat="server" Text='<%#Eval("id")%>' Visible="false" /></td>
                                                    <td>
                                                        <label class="control-label">Date Of Birth:</label></td>
                                                    <td>
                                                        <asp:Label ID="Label21" runat="server" Text='<%#Eval("date_of_birth")%>' /></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label8" runat="server" Text='<%#Eval("id")%>' Visible="false" /></td>
                                                    <td>
                                                        <label class="control-label">Contact Number:</label></td>
                                                    <td>
                                                        <asp:Label ID="Label5" runat="server" Text='<%#Eval("contact_number")%>' /></td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label24" runat="server" Text='<%#Eval("id")%>' Visible="false" /></td>
                                                    <td>
                                                        <label class="control-label">Permanent Address:</label></td>
                                                    <td>
                                                        <asp:Label ID="Label25" runat="server" Text='<%#Eval("permanent_address")%>' /></td>
                                                </tr>

                                            </table>
                                        </div>
                                        <div class="form-group" style="float: right">
                                            <table class="table table-hover">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("id")%>' Visible="false" /></td>
                                                    <td>
                                                        <label class="control-label">Last Name:</label></td>
                                                    <td>
                                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("last_name")%>' /></td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label18" runat="server" Text='<%#Eval("id")%>' Visible="false" /></td>
                                                    <td>
                                                        <label class="control-label">Personal Email:</label></td>
                                                    <td>
                                                        <asp:Label ID="Label19" runat="server" Text='<%#Eval("personal_email")%>' /></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label29" runat="server" Text='<%#Eval("emp_id")%>' Visible="false" /></td>
                                                    <td>
                                                        <label class="control-label">Passport:</label></td>
                                                    <td>
                                                        <asp:Label ID="Label30" runat="server" Text='<%#Eval("passport")%>' /></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label22" runat="server" Text='<%#Eval("id")%>' Visible="false" /></td>
                                                    <td>
                                                        <label class="control-label">Emergency Contact:</label></td>
                                                    <td>
                                                        <asp:Label ID="Label23" runat="server" Text='<%#Eval("emergency_contact_number")%>' /></td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label26" runat="server" Text='<%#Eval("id")%>' Visible="false" /></td>
                                                    <td>
                                                        <label class="control-label">Temporary Address:</label></td>
                                                    <td>
                                                        <asp:Label ID="Label27" runat="server" Text='<%#Eval("temp_address")%>' /></td>
                                                </tr>

                                            </table>
                                        </div>

                                        <div class="form-group" style="margin-left: 25px;">
                                            <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-primary" />
                                            <asp:Button ID="btnFamily" runat="server" OnClick="btnFamily_Click" Text="Add Family" CssClass="btn btn-primary" />
                                        </div>
                                    </ItemTemplate>

                                    <EditItemTemplate>
                                        <div class="form-group" style="float: left">
                                            <table class="table table-hover">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label13" runat="server" Text='<%#Eval("id")%>' Visible="false" /></td>
                                                    <td>
                                                        <label class="control-label">First Name:</label></td>
                                                    <td>
                                                        <asp:TextBox ID="txtFirstname" CssClass="alpha form-control" runat="Server" Text='<%#Eval("first_name")%>'></asp:TextBox></td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label16" runat="server" Text='<%#Eval("id")%>' Visible="false" /></td>
                                                    <td>
                                                        <label class="control-label">Gender:</label></td>
                                                    <td>
                                                        <asp:DropDownList class="form-control" ID="drdGender" runat="server">
                                                            <asp:ListItem Value="">Select Gender</asp:ListItem>
                                                            <asp:ListItem Value="M">Male</asp:ListItem>
                                                            <asp:ListItem Value="F">Female</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label20" runat="server" Text='<%#Eval("id")%>' Visible="false" /></td>
                                                    <td>
                                                        <label class="control-label">Date Of Birth:</label></td>
                                                    <td>
                                                        <asp:TextBox ID="txtDOB" CssClass="dob form-control" runat="Server" Text='<%#Eval("date_of_birth")%>'></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label7" runat="server" Text='<%#Eval("id")%>' Visible="false" /></td>
                                                    <td>
                                                        <label class="control-label">Contact Number:</label></td>
                                                    <td>
                                                        <asp:TextBox ID="txtContact" MaxLength="10" CssClass="numeric form-control" runat="Server" Text='<%#Eval("contact_number")%>'></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label24" runat="server" Text='<%#Eval("id")%>' Visible="false" /></td>
                                                    <td>
                                                        <label class="control-label">Permanent Address:</label></td>
                                                    <td>
                                                        <asp:TextBox ID="txtPermanent" TextMode="MultiLine" CssClass="form-control" runat="Server" Text='<%#Eval("permanent_address")%>'></asp:TextBox></td>
                                                </tr>

                                            </table>

                                        </div>
                                        <div class="form-group" style="float: right">
                                            <table class="table table-hover">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("id")%>' Visible="false" /></td>
                                                    <td>
                                                        <label class="control-label">Last Name:</label></td>
                                                    <td>
                                                        <asp:TextBox ID="txtLastname" CssClass="alpha form-control" runat="Server" Text='<%#Eval("last_name")%>'></asp:TextBox></td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label18" runat="server" Text='<%#Eval("id")%>' Visible="false" /></td>
                                                    <td>
                                                        <label class="control-label">Personal Email:</label></td>
                                                    <td>
                                                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="Server" Text='<%#Eval("personal_email")%>'></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblemp_id" runat="server" Text='<%#Eval("emp_id")%>' Visible="false" /></td>
                                                    <td>
                                                        <label class="control-label">Passport Number:</label></td>
                                                    <td>
                                                        <asp:TextBox ID="txtPassport" CssClass="form-control" runat="Server" Text='<%#Eval("passport")%>'></asp:TextBox></td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label22" runat="server" Text='<%#Eval("id")%>' Visible="false" /></td>
                                                    <td>
                                                        <label class="control-label">Emergency Contact:</label></td>
                                                    <td>
                                                        <asp:TextBox ID="txtEmergency" MaxLength="10" CssClass="numeric form-control" runat="Server" Text='<%#Eval("emergency_contact_number")%>'></asp:TextBox></td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label26" runat="server" Text='<%#Eval("id")%>' Visible="false" /></td>
                                                    <td>
                                                        <label class="control-label">Temporary Address:</label></td>
                                                    <td>
                                                        <asp:TextBox ID="txtTemp" TextMode="MultiLine" CssClass="form-control" runat="Server" Text='<%#Eval("temp_address")%>'></asp:TextBox></td>
                                                </tr>

                                            </table>
                                        </div>

                                        <div class="form-group" style="margin-left: 25px;">
                                            <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" CssClass="btn btn-primary" />
                                            <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-primary" />
                                        </div>

                                    </EditItemTemplate>

                                </asp:DataList>

                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default" style="height: 350px; width: 1072px;">
                            <div class="panel-heading">
                                <h3 class="panel-title"></h3>
                            </div>
                            <div class="panel-body form-group">

                                <div class="panel panel-default" style="float: left; height: 300px;">
                                    <div class="panel-heading">
                                        <h3 class="panel-title">Official Details</h3>
                                    </div>
                                    <div class="panel-body form-group">
                                        <asp:Label ID="lblEmpty2" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                        <asp:DataList ID="DataList2" runat="server">
                                            <ItemTemplate>
                                                <div class="form-group" style="float: left">
                                                    <table class="table table-hover">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label13" runat="server" Text='<%#Eval("id")%>' Visible="false" /></td>
                                                            <td>
                                                                <label class="control-label">Employee Id:</label></td>
                                                            <td>
                                                                <asp:Label ID="Label15" runat="server" Text='<%#Eval("emp_no")%>' /></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label16" runat="server" Text='<%#Eval("id")%>' Visible="false" /></td>
                                                            <td>
                                                                <label class="control-label">Official Email:</label></td>
                                                            <td>
                                                                <asp:Label ID="Label17" runat="server" Text='<%#Eval("official_email")%>' /></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label20" runat="server" Text='<%#Eval("id")%>' Visible="false" /></td>
                                                            <td>
                                                                <label class="control-label">Date Of Joining:</label></td>
                                                            <td>
                                                                <asp:Label ID="Label21" runat="server" Text='<%#Eval("date_of_join")%>' /></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label8" runat="server" Text='<%#Eval("id")%>' Visible="false" /></td>
                                                            <td>
                                                                <label class="control-label">Pan Number:</label></td>
                                                            <td>
                                                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("pan")%>' /></td>
                                                        </tr>

                                                    </table>
                                                </div>

                                            </ItemTemplate>
                                        </asp:DataList>
                                    </div>
                                </div>

                                <div class="panel panel-default" style="float: right; height: 300px;">
                                    <div class="panel-heading">
                                        <h3 class="panel-title">Bank Details</h3>
                                    </div>
                                    <div class="panel-body form-group">
                                        <asp:Label ID="lblEmpty3" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                        <asp:DataList ID="DataList3" runat="server">
                                            <ItemTemplate>
                                                <div class="form-group" style="float: left">
                                                    <table class="table table-hover">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label8" runat="server" Text='<%#Eval("emp_id")%>' Visible="false" /></td>
                                                            <td>
                                                                <label class="control-label">Bank Name:</label></td>
                                                            <td>
                                                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("bank_name")%>' /></td>
                                                        </tr>

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label24" runat="server" Text='<%#Eval("emp_id")%>' Visible="false" /></td>
                                                            <td>
                                                                <label class="control-label">Bank Branch:</label></td>
                                                            <td>
                                                                <asp:Label ID="Label25" runat="server" Text='<%#Eval("bank_branch")%>' /></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label13" runat="server" Text='<%#Eval("emp_id")%>' Visible="false" /></td>
                                                            <td>
                                                                <label class="control-label">Holder Name:</label></td>
                                                            <td>
                                                                <asp:Label ID="Label15" runat="server" Text='<%#Eval("holder_name")%>' /></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label16" runat="server" Text='<%#Eval("emp_id")%>' Visible="false" /></td>
                                                            <td>
                                                                <label class="control-label">Account Number:</label></td>
                                                            <td>
                                                                <asp:Label ID="Label17" runat="server" Text='<%#Eval("account_number")%>' /></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label20" runat="server" Text='<%#Eval("emp_id")%>' Visible="false" /></td>
                                                            <td>
                                                                <label class="control-label">Ifsc Code:</label></td>
                                                            <td>
                                                                <asp:Label ID="Label21" runat="server" Text='<%#Eval("ifsc_code")%>' /></td>
                                                        </tr>

                                                    </table>
                                                </div>

                                            </ItemTemplate>
                                        </asp:DataList>
                                    </div>

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
