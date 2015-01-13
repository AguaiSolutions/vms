<%@ Page Title="Add Employee" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Vacation_management_system.Web.Employee.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



    <script type="text/javascript">


        function confirmation() {

            var check = $('#<%=cdInactive.ClientID%>').prop('checked');
            if (check) {
                var answer = confirm('Are you sure you want to Deactivate the employee...!');
                if (answer) {
                    if (document.getElementById('<%= txtDor.ClientID %>').value == "") {
                        alert("please select the date of resignation");
                        $("#<%= txtDor.ClientID %>").focus();
                    }
                    // document.getElementById("txtDor").select();
                }
            }
        }

        $(function () {
            $("#<%= txtDor.ClientID %>").datepicker({
                format: 'dd/mm/yyyy',
                autoclose: true,
                todayHighlight: true
            });

        });


        $(document).ready(function () {
            if (document.getElementById('<%=lblTitle.ClientID%>').innerHTML== "Add Employee") {
            $("#txtDOJ").datepicker({
                format: 'dd/mm/yyyy',
                autoclose: true,
                todayHighlight: true
            });
        }

        });


        $(function () {
            //$("[id$=txtDOB]").datepicker();
            $("#txtDOB").datepicker({
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

    </script>

    <style type="text/css">
        .auto-style1 {
            height: 60px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p id="demo"></p>
    <div id="wrapper">

        <div id="page-wrapper">

            <div class="container-fluid" style="background-color: white;">
                <!-- /.row -->

                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">
                            <asp:Label ID="lblTitle" runat="server" />

                        </h1>

                        <ol class="breadcrumb">
                            <li>
                                <i class="fa fa-users"></i>User Management 
                            </li>
                            <li class="active">
                                <i id="icon" runat="server"></i>
                                <asp:Label ID="lblEmployee" runat="server" />
                            </li>
                        </ol>
                    </div>
                </div>
                <!-- /.Add Employee Details -->

                <div class="panel panel-default">
                    <div class="panel-heading" runat="server">
                        <h3 class="panel-title" runat="server"></h3>


                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div>
                                    <asp:Button ID="btnSave1" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnSave_Click" />

                                    <asp:Button ID="btnSaveandaddnew1" CssClass="btn btn-primary" runat="server" Text="Save & Add New" OnClick="btnSaveandAddNew_Click" />

                                    <asp:Button ID="btnupdate1" CssClass="btn btn-primary" runat="server" Text="Update" OnClick="Update_Click" />

                                    <asp:HyperLink ID="hlinkCancel1" CssClass="btn btn-primary" runat="server" NavigateUrl="~/Web/Employee/EmployeeList/EmployeeList.aspx">Cancel</asp:HyperLink>
                                </div>
                            </div>
                        </div>

                        <div class="row" style="margin-bottom: 10px;">
                            <div id="check" class="form-group pull-right">

                                <input id="cdInactive" type="checkbox" onclick="confirmation();" runat="server" />
                                <label id="lblDeactivate" runat="server" class="control-label text-danger">Deactivate</label>
                            </div>

                            <div class="form-group">

                                <asp:ValidationSummary CssClass="alert alert-danger" DisplayMode="List" ID="vldSummary" ForeColor="Black" runat="server" />

                            </div>
                        </div>

                        <div class="row" style="margin-bottom: 10px;">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div>
                                        <label class="col-sm-2 control-label">Employee Number:<span style="color: red">*</span></label>

                                        <asp:TextBox ID="txtEmpNo" class="col-sm-6 form-control" name="Employee Number" placeholder="Enter Number" runat="server" Style="width: 300px;" />

                                    </div>

                                    <div>
                                        <label class="col-sm-2 control-label">First Name:<span style="color: red">*</span></label>

                                        <asp:TextBox ID="txtFirstName" class="alpha col-sm-6 form-control" name="firstname" placeholder="First Name" runat="server" Style="width: 300px;" />

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row" style="margin-bottom: 10px;">
                            <%-- txtLastname--%>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div>
                                        <label class="col-sm-2 control-label">Last Name:<span style="color: red">*</span></label>

                                        <asp:TextBox ID="txtLastName" class="alpha col-sm-6 form-control" name="lastname" placeholder="Last Name" runat="server" Style="width: 300px;" />

                                    </div>

                                    <div>
                                        <label class="col-sm-2 control-label">Select Gender:<span style="color: red">*</span></label>

                                        <asp:DropDownList class="col-sm-6 form-control" ID="drdGender" runat="server" Style="width: 300px;">
                                            <asp:ListItem Value="M">Male</asp:ListItem>
                                            <asp:ListItem Value="F">Female</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row" style="margin-bottom: 10px;">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div>
                                        <label class="col-sm-2 control-label">Personal Email:</label>

                                        <asp:TextBox ID="txtPersonalEmail" class="col-sm-6 form-control" name="Personal Email" placeholder="Personal Email" runat="server" Style="width: 300px;" />


                                    </div>

                                    <div>
                                        <label class="col-sm-2 control-label">Official Email:<span style="color: red">*</span></label>

                                        <asp:TextBox ID="txtOfficialEmail" class="col-sm-6 form-control" name="Official Email" placeholder="Official Email" runat="server" Style="width: 300px;" />

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row" style="margin-bottom: 10px;">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div>
                                        <label class="col-sm-2 control-label">Date of Joining:<span style="color: red">*</span></label>

                                        <asp:TextBox ID="txtDOJ" ClientIDMode="Static" class="col-sm-6 form-control" name="Date of Joining" placeholder="Date of Joining" runat="server" Style="width: 300px;" />

                                    </div>

                                    <div>
                                        <label class="col-sm-2 control-label">Date of Birth:</label>

                                        <asp:TextBox ID="txtDOB" ClientIDMode="Static" class="col-sm-6 form-control" name="Date of Birth" placeholder="Date of Birth" runat="server" Style="width: 300px;" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row" style="margin-bottom: 10px;">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div>
                                        <label class="col-sm-2 control-label">Contact Number:<span style="color: red">*</span></label>

                                        <asp:TextBox ID="txtContactNo" class="col-sm-6 form-control numeric" MaxLength="10" name="Contact Number" placeholder="Contact Number" runat="server" Style="width: 300px;" />

                                    </div>

                                    <div>
                                        <label class="col-sm-2 control-label">Emergency Contact Number:</label>

                                        <asp:TextBox ID="txtEmergencyNo" class="col-sm-6 form-control numeric" MaxLength="10" name="Emergency Contact Number" placeholder="Emergency Contact Number" runat="server" Style="width: 300px;" />
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="row" style="margin-bottom: 10px;">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div>
                                        <label class="col-sm-2 control-label">Local Address:</label>


                                        <asp:TextBox ID="txtLocalAdd" class="col-sm-6 form-control" TextMode="MultiLine" placeholder="Local Address" runat="server" Style="width: 300px;"></asp:TextBox>
                                    </div>

                                    <div>
                                        <label class="col-sm-2 control-label">Permanent Address:</label>

                                        <asp:TextBox ID="txtPermanentAdd" class="col-sm-6 form-control" TextMode="MultiLine" placeholder="Permanent Address" runat="server" Style="width: 300px;"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="row" style="margin-bottom: 10px;">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div>
                                        <label class="col-sm-2 control-label">PAN Number:<span style="color: red">*</span></label>

                                        <asp:TextBox ID="txtPAN" class="col-sm-6 form-control" MaxLength="20" name="PAN Number" placeholder="PAN Number" runat="server" Style="width: 300px;" />

                                    </div>

                                    <div>
                                        <label class="col-sm-2 control-label">Passport Number:</label>

                                        <asp:TextBox ID="txtPassport" class="col-sm-6 form-control" MaxLength="20" name="Passport Number" placeholder="Passport Number" runat="server" Style="width: 300px;" />
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="row" style="margin-bottom: 10px;">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div>
                                        <label class="col-sm-2 control-label">Bank Name:</label>

                                        <asp:TextBox ID="txtBankName" class="alpha col-sm-6 form-control" MaxLength="20" name="Bank Name" placeholder="Bank Name" runat="server" Style="width: 300px;" />

                                    </div>

                                    <div>
                                        <label class="col-sm-2 control-label">Branch Location:</label>

                                        <asp:TextBox ID="txtBranchLocation" class="alpha col-sm-6 form-control" MaxLength="20" name="Branch Location" placeholder="Branch Location" runat="server" Style="width: 300px;" />
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="row" style="margin-bottom: 10px;">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div>
                                        <label class="col-sm-2 control-label">Account Number:</label>

                                        <asp:TextBox ID="txtAccountNo" class="col-sm-6 form-control" MaxLength="20" name="Account Number" placeholder="Account Number" runat="server" Style="width: 300px;" />

                                    </div>

                                    <div>
                                        <label class="col-sm-2 control-label">Account Name:</label>

                                        <asp:TextBox ID="txtAccountHolder" class="alpha col-sm-6 form-control" MaxLength="50" name="Account Holder" placeholder="Account Holder" runat="server" Style="width: 300px;" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row" style="margin-bottom: 10px;">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div>
                                        <label class="col-sm-2 control-label">IFSC Code:</label>


                                        <asp:TextBox ID="txtIFSC" class="col-sm-6 form-control" MaxLength="20" name="Account Holder" placeholder="IFSC Code" runat="server" Style="width: 300px;" />
                                    </div>
                                    <div>
                                        <label id="lblDor" runat="server" class="col-sm-2 control-label">Date of Resignation:</label>

                                        <asp:TextBox ID="txtDor" class="col-sm-6 form-control" name="Account Holder" placeholder="Date of Resignation" runat="server" Style="width: 300px;" />
                                    </div>


                                    <div>
                                        <label id="lblImage" runat="server" class="col-sm-2 control-label">Image:</label>


                                        <asp:FileUpload ID="empImage" class="col-sm-6 form-control" runat="server" Style="width: 300px;" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row" style="margin-bottom: 10px;">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div>
                                        <label class="col-sm-2 control-label">Select Role:<span style="color: red">*</span></label>


                                        <asp:DropDownList ID="drdRole" class="col-sm-6 form-control" runat="server" OnSelectedIndexChanged="drdRole_SelectedIndexChanged" Style="width: 300px;"></asp:DropDownList>
                                    </div>

                                    <div>
                                        <label class="col-sm-2 control-label">Select Reporting Manager:<span style="color: red">*</span></label>
                                        <asp:DropDownList ID="drdManager" class="col-sm-6 form-control" runat="server" OnSelectedIndexChanged="drdManager_SelectedIndexChanged" Style="width: 300px;"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div>
                                    <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnSave_Click" />

                                    <asp:Button ID="btnSaveandaddnew" CssClass="btn btn-primary" runat="server" Text="Save & Add New" OnClick="btnSaveandAddNew_Click" />

                                    <asp:Button ID="btnupdate" CssClass="btn btn-primary" runat="server" Text="Update" OnClick="Update_Click" />

                                    <asp:HyperLink ID="hlinkCancel" CssClass="btn btn-primary" runat="server" NavigateUrl="~/Web/Employee/EmployeeList/EmployeeList.aspx">Cancel</asp:HyperLink>
                                </div>
                            </div>
                        </div>

                        <div>
                            <asp:RequiredFieldValidator Display="None" ID="RfdEmp_no" runat="server" ControlToValidate="txtEmpNo" ErrorMessage="Please enter Employee Number!"></asp:RequiredFieldValidator>

                            <asp:RequiredFieldValidator Display="None" ID="RfdFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Please enter Employee First Name!" ForeColor="Red"></asp:RequiredFieldValidator>


                            <asp:RequiredFieldValidator Display="None" ID="RfdLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="Please enter Employee Last Name!" ForeColor="Red"></asp:RequiredFieldValidator>

                            <%--<asp:RequiredFieldValidator Display="None" ID="RfdGender" runat="server" ControlToValidate="drdGender" ErrorMessage="Please select Employee Gender" ForeColor="Red"></asp:RequiredFieldValidator>--%>

                            <asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPersonalEmail" ErrorMessage="Please enter valid Personal Email!" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                            <asp:RequiredFieldValidator Display="None" ID="RfdOfficalEmail" runat="server" ControlToValidate="txtOfficialEmail" ErrorMessage="Please enter Official Email!" ForeColor="Red"></asp:RequiredFieldValidator>

                            <asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtOfficialEmail" ErrorMessage="Please enter valid Official Email!" ForeColor="#CC0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                            <asp:RequiredFieldValidator Display="None" ID="RfdDateofjoining" runat="server" ControlToValidate="txtDoj" ErrorMessage="Please enter Employee Date of joining!" ForeColor="Red"></asp:RequiredFieldValidator>

                            <%--<asp:RequiredFieldValidator Display="None" ID="Rfddateofdirth" runat="server" ControlToValidate="txtDOB" ErrorMessage="Please enter Employee Date of birth!" ForeColor="Red"></asp:RequiredFieldValidator>--%>

                            <asp:RequiredFieldValidator Display="None" ID="RfdContactNo" runat="server" ControlToValidate="txtContactNo" ErrorMessage="Please enter Employee Contact number!" ForeColor="Red"></asp:RequiredFieldValidator>

                            <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPAN" ErrorMessage="Please enter Employee Pan number!" ForeColor="Red"></asp:RequiredFieldValidator>
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
