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
                if (e.ctrlKey || e.altKey) {
                    e.preventDefault();
                } else {
                    var key = e.keyCode;
                    if (!((key == 8) || (key == 32) || (e.shiftKey) || (key == 9) || (key == 46) || (key >= 35 && key <= 40) || (key >= 65 && key <= 90))) {
                        e.preventDefault();
                    }
                }
            });
        });

        $(document).ready(function () {
            var MaxLength = 200;
            $('.max').keypress(function (e) {
                if ($(this).val().length >= MaxLength) {
                    e.preventDefault();
                }
            });
        });

        function validateEmail(email) {
            var reg = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/
            if (reg.test(email)) {
                return true;
            }
            else {
                return false;
            }
        }

        $(document).ready(function (e) {
            $('.update').click(function () {

                var firstName = $('#txtFirstname').val();

                var lastName = $('#txtLastname').val();

                var dob = $('#txtDOB').val();

                if (firstName == '' || lastName == '' || dob == "") {
                    alert('First Name, Last Name and Date of Birth should not be Empty');
                    return false;
                }

                var email = $('.email').val();
                if ($.trim(email).length == 0) {
                    var x = confirm('Do you want to continue with out Personal Email?');
                    if (x)
                        return true;
                    else
                        return false;
                }
                if (!validateEmail(email)) {
                    alert('Invalid Email Address');
                    return false;
                }
            });
        });

        function Alphabets(nkey) {
            var keyval
            if (navigator.appName == "") {
                keyval = window.event.keyCode;
            }
            else if (navigator.appName == 'Netscape') {
                nkeycode = nkey.which;
                keyval = nkeycode;
            }
            //For A-Z
            if (keyval >= 65 && keyval <= 90) {
                return true;
            }
                //For a-z
            else if (keyval >= 97 && keyval <= 122) {
                return true;
            }
            else if (keyval >= 48 && keyval <= 57) {
                return true;
            }
                //For Backspace
            else if (keyval == 8) {
                return true;
            }
                //For General
            else if (keyval == 0) {
                return true;
            }
            else {
                return false;
            }
        };// End of the function

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="wrapper">

        <div id="page-wrapper">

            <div class="container-fluid" style="background-color: white;">
                <!-- /.row -->

                <!-- Page Heading -->
                <div class="row">
                    <div class="col-md-12">
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
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Personal Details</h3>
                    </div>
                    <div class="panel-body">
                        <asp:DataList ID="DataList1" runat="server" CssClass="datalist"
                            OnCancelCommand="DataList1_CancelCommand"
                            OnEditCommand="DataList1_EditCommand"
                            OnUpdateCommand="DataList1_UpdateCommand" OnItemDataBound="DataList1_ItemDataBound">

                            <ItemTemplate>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="row form-group">
                                            <div class="form-group">
                                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("id")%>' Visible="false" />

                                                <label class="col-md-4 control-label">First Name:</label>
                                                <div class="col-md-6">
                                                    <asp:Label ID="lblFn" runat="server" Text='<%#Eval("first_name")%>' />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row form-group">
                                            <div class="form-group">
                                                <label class="col-md-4 control-label">Gender:</label>
                                                <div class="col-md-6">
                                                    <asp:Label ID="lblGender1" runat="server" Text='<%#Eval("gender")%>' />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row form-group">
                                            <div class="form-group">
                                                <asp:Label ID="Label28" runat="server" Text='<%#Eval("id")%>' Visible="false" />
                                                <label class="col-md-4 control-label">Date Of Birth:</label>
                                                <div class="col-md-6">
                                                    <asp:Label ID="lblDOB1" CssClass="control-label" runat="server" Text='<%#Eval("date_of_birth")%>' />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row form-group">
                                            <div class="form-group">
                                                <label class="col-md-4 control-label">Contact Number:</label>
                                                <div class="col-md-6">
                                                    <asp:Label ID="lblCon" CssClass="control-label" runat="server" Text='<%#Eval("contact_number")%>' />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row form-group">
                                            <div class="form-group">
                                                <label class="col-md-4 control-label">Temporary Address:</label>
                                                <div class="col-md-6" style="overflow: auto; height: 80px; width: 200px;">
                                                    <asp:Label ID="lblTemp" CssClass="control-label" runat="server" Text='<%#Eval("temp_address")%>' />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:Button ID="Button3" runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-primary" />
                                                <asp:Button ID="Button4" runat="server" OnClick="btnFamily_Click" Text="Family Details" CssClass="btn btn-primary" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <div class="row form-group">
                                            <div class="form-group">
                                                <label class="col-md-4 control-label">Last Name:</label>
                                                <div class="col-md-6">
                                                    <asp:Label ID="lblLn" CssClass="control-label" runat="server" Text='<%#Eval("last_name")%>' />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row form-group">
                                            <div class="form-group">
                                                <label class="col-md-4 control-label">Personal Email:</label>
                                                <div class="col-md-6">
                                                    <asp:Label ID="lblEmail" CssClass="control-label" runat="server" Text='<%#Eval("personal_email")%>' />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row form-group">
                                            <div class="form-group">
                                                <label class="col-md-4 control-label">Passport:</label>
                                                <div class="col-md-6">
                                                    <asp:Label ID="lblPassport" CssClass="control-label" runat="server" Text='<%#Eval("passport")%>' />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row form-group">
                                            <div class="form-group">
                                                <label class="col-md-4 control-label">Emergency Contact:</label>
                                                <div class="col-md-6">
                                                    <asp:Label ID="lblEmergency" CssClass="control-label" runat="server" Text='<%#Eval("emergency_contact_number")%>' />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row form-group">
                                            <div class="form-group">
                                                <label class="col-md-4 control-label">Permanent Address:</label>
                                                <div class="col-md-6" style="overflow: auto; height: 80px; width: 200px;">
                                                    <asp:Label ID="lblPermanent" CssClass="control-label" runat="server" Text='<%#Eval("permanent_address")%>' />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </ItemTemplate>

                            <EditItemTemplate>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="row form-group">
                                            <div class="form-group">
                                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("id")%>' Visible="false" />
                                                <label class="col-md-4 control-label">First Name:<span style="color: red">*</span></label>
                                                <div class="col-md-6">
                                                    <asp:TextBox ID="txtFirstname" ClientIDMode="Static" MaxLength="30" CssClass="alpha form-control" runat="Server" Text='<%#Eval("first_name")%>' />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="form-group">
                                                <asp:Label ID="lblGender" runat="server" Text='<%#Eval("gender")%>' Visible="false" />
                                                <label class="col-md-4 control-label">Gender:</label>
                                                <div class="col-md-6">
                                                    <asp:DropDownList class="form-control" ID="drdGender" runat="server">
                                                        <asp:ListItem Value="M">Male</asp:ListItem>
                                                        <asp:ListItem Value="F">Female</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row form-group">
                                            <div class="form-group">
                                                <label class="col-md-4 control-label">Date Of Birth:<span style="color: red">*</span></label>
                                                <div class="col-md-6">
                                                    <asp:TextBox ID="txtDOB" ClientIDMode="Static" CssClass="dob form-control" runat="Server" Text='<%#Eval("date_of_birth")%>' />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row form-group">
                                            <div class="form-group">
                                                <label class="col-md-4 control-label">Contact Number:</label>
                                                <div class="col-md-6">
                                                    <asp:TextBox ID="txtContact" MaxLength="10" CssClass="numeric form-control" runat="Server" Text='<%#Eval("contact_number")%>' />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row form-group">
                                            <div class="form-group">
                                                <label class="col-md-4 control-label">Temporary Address:</label>
                                                <div class="col-md-6">
                                                    <asp:TextBox ID="txtTemp" TextMode="MultiLine" CssClass="max form-control" runat="Server" Text='<%#Eval("temp_address")%>' />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" CssClass="update btn btn-primary" />
                                                <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-primary" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <div class="row form-group">
                                            <div class="form-group">
                                                <label class="col-md-4 control-label">Last Name:<span style="color: red">*</span></label>
                                                <div class="col-md-6">
                                                    <asp:TextBox ID="txtLastname" ClientIDMode="Static" MaxLength="30" CssClass="alpha form-control" runat="Server" Text='<%#Eval("last_name")%>' />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row form-group">
                                            <div class="form-group">
                                                <label class="col-md-4 control-label">Personal Email:</label>
                                                <div class="col-md-6">
                                                    <asp:TextBox ID="txtEmail" MaxLength="30" CssClass="email form-control" runat="Server" Text='<%#Eval("personal_email")%>' />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row form-group">
                                            <div class="form-group">
                                                <label class="col-md-4 control-label">Passport:</label>
                                                <div class="col-md-6">
                                                    <asp:TextBox ID="txtPassport" MaxLength="30" CssClass="form-control" runat="Server" Text='<%#Eval("passport")%>' onkeypress="return Alphabets(event);" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row form-group">
                                            <div class="form-group">
                                                <label class="col-md-4 control-label">Emergency Contact:</label>
                                                <div class="col-md-6">
                                                    <asp:TextBox ID="txtEmergency" MaxLength="10" CssClass="numeric form-control" runat="Server" Text='<%#Eval("emergency_contact_number")%>' />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row form-group">
                                            <div class="form-group">
                                                <label class="col-md-4 control-label">Permanent Address:</label>
                                                <div class="col-md-6">
                                                    <asp:TextBox ID="txtPermanent" TextMode="MultiLine" CssClass="max form-control" runat="Server" Text='<%#Eval("permanent_address")%>' />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </EditItemTemplate>
                        </asp:DataList>
                    </div>
                </div>

                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title"></h3>
                    </div>
                    <div class="panel-body form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h3 class="panel-title">Official Details</h3>
                                    </div>
                                    <div class="panel-body form-group">
                                        <asp:DataList ID="DataList2" CssClass="datalist" runat="server">
                                            <ItemTemplate>

                                                <div class="row form-group">
                                                    <div class="form-group">
                                                        <label class="col-md-4 control-label">Employee Id:</label>
                                                        <div class="col-md-6">
                                                            <asp:Label ID="lblFn" runat="server" Text='<%#Eval("emp_no")%>' />
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row form-group">
                                                    <div class="form-group">
                                                        <label class="col-md-4 control-label">Official Email:</label>
                                                        <div class="col-md-6">
                                                            <asp:Label ID="lblGender1" runat="server" Text='<%#Eval("official_email")%>' />
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row form-group">
                                                    <div class="form-group">
                                                        <label class="col-md-4 control-label">Date Of Joining:</label>
                                                        <div class="col-md-6">
                                                            <asp:Label ID="lblDOB1" CssClass="control-label" runat="server" Text='<%#Eval("date_of_join")%>' />
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row form-group">
                                                    <div class="form-group">
                                                        <label class="col-md-4 control-label">Pan Number:</label>
                                                        <div class="col-md-6">
                                                            <asp:Label ID="lblCon" CssClass="control-label" runat="server" Text='<%#Eval("pan")%>' />
                                                        </div>
                                                    </div>
                                                </div>
                                                </div>
                                             </div>

                                            </ItemTemplate>
                                        </asp:DataList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h3 class="panel-title">Bank Details</h3>
                                    </div>
                                    <div class="panel-body form-group">
                                        <asp:DataList ID="DataList3" CssClass="datalist" runat="server">
                                            <ItemTemplate>

                                                <div class="row form-group">
                                                    <div class="form-group">
                                                        <label class="col-md-4 control-label">Bank Name:</label>
                                                        <div class="col-md-6">
                                                            <asp:Label ID="lblFn" runat="server" Text='<%#Eval("bank_name")%>' />
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row form-group">
                                                    <div class="form-group">
                                                        <label class="col-md-4 control-label">Bank Branch:</label>
                                                        <div class="col-md-6">
                                                            <asp:Label ID="lblGender1" runat="server" Text='<%#Eval("bank_branch")%>' />
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row form-group">
                                                    <div class="form-group">
                                                        <label class="col-md-4 control-label">Holder Name:</label>
                                                        <div class="col-md-6">
                                                            <asp:Label ID="lblDOB1" CssClass="control-label" runat="server" Text='<%#Eval("holder_name")%>' />
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row form-group">
                                                    <div class="form-group">
                                                        <label class="col-md-4 control-label">Account Number:</label>
                                                        <div class="col-md-6">
                                                            <asp:Label ID="lblCon" CssClass="control-label" runat="server" Text='<%#Eval("account_number")%>' />
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row form-group">
                                                    <div class="form-group">
                                                        <label class="col-md-4 control-label">IFSC Code:</label>
                                                        <div class="col-md-6">
                                                            <asp:Label ID="lblTemp" CssClass="control-label" runat="server" Text='<%#Eval("ifsc_code")%>' />
                                                        </div>
                                                    </div>
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
