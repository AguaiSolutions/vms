<%@ Page Title="Add Employee" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Vacation_management_system.Web.Employee.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $("[id$=txtDOJ]").datepicker();
        });
        $(function () {
            $("[id$=txtDOB]").datepicker();
        });
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 60px;
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
                        <h1 class="page-header">Add Employees
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="glyphicon glyphicon-home"></i><a href="~/Web/Dashboard/Dashboard.aspx" runat="server">Dashboard</a>
                            </li>
                            <li class="active">
                                <i class="glyphicon glyphicon-plus-sign"></i>Add Employees
                            </li>
                        </ol>
                    </div>
                </div>
                <!-- /.Add Employee Details -->

                <div class="form-group form-inline">

                    <div class="col-md-6">
                        <label class="col-md-4 control-label">Employee Number:</label>
                        <span style="color: red">*</span>
                        <asp:TextBox ID="txtEmpNo" class="col-md-4 form-control" name="Employee Number" placeholder="Enter Number" runat="server" />
                    </div>

                    <div class="col-md-6">
                        <label class="col-md-4 control-label">First Name:</label>
                        <span style="color: red">*</span>
                        <asp:TextBox ID="txtFirstName" class="col-md-4 form-control" name="firstname" placeholder="First Name" runat="server" />
                    </div>

                </div>
                <br />
                <br />
                <div class="form-group form-inline">
                    <%-- txtLastname--%>

                    <div class="col-md-6">
                        <label class="col-md-4 control-label">Last Name:</label>
                        <span style="color: red">*</span>
                        <asp:TextBox ID="txtLastName" class="col-md-4 form-control" name="lastname" placeholder="Last Name" runat="server" />
                    </div>

                    <div class="col-md-6">
                        <label class="col-md-4 control-label">Select Gender:</label>
                        <span style="color: red">*</span>
                        <asp:DropDownList class="col-md-4 form-control" ID="drdGender" runat="server">
                            <asp:ListItem Value="M">Male</asp:ListItem>
                            <asp:ListItem Value="F">Female</asp:ListItem>
                            <asp:ListItem Value="O">other</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <br />
                <br />
                <div class="form-group form-inline">

                    <div class="col-md-6">
                        <label class="col-md-4 control-label">Personal Email:</label>

                        <asp:TextBox ID="txtPersonalEmail" class="col-md-4 form-control" name="Personal Email" placeholder="Personal Email" runat="server" />
                    </div>

                    <div class="col-md-6">
                        <label class="col-md-4 control-label">Official Email:</label>
                        <span style="color: red">*</span>
                        <asp:TextBox ID="txtOfficialEmail" class="col-md-4 form-control" name="Official Email" placeholder="Official Email" runat="server" />
                    </div>

                </div>
                <br />
                <br />
                <div class="form-group form-inline">

                    <div class="col-md-6">
                        <label class="col-md-4 control-label">Date of Joining:</label>
                        <span style="color: red">*</span>
                        <asp:TextBox ID="txtDOJ" class="col-md-6 form-control" name="Date of Joining" placeholder="Date of Joining" runat="server" />
                    </div>

                    <div class="col-md-6">
                        <label class="col-md-4 control-label">Date of Birth:</label>
                        <span style="color: red">*</span>
                        <asp:TextBox ID="txtDOB" class="col-md-6 form-control" name="Date of Birth" placeholder="Date of Birth" runat="server" />
                    </div>

                </div>
                <br />
                <br />
                <div class="form-group form-inline">

                    <div class="col-md-6">
                        <label class="col-md-4 control-label">Contact Number:</label>
                        <span style="color: red">*</span>
                        <asp:TextBox ID="txtContactNo" class="col-md-6 form-control" name="Contact Number" placeholder="Contact Number" runat="server" />
                    </div>

                    <div class="col-md-6">
                        <label class="col-md-4 control-label">Emergency Contact Number:</label>

                        <asp:TextBox ID="txtEmergencyNo" class="col-md-6 form-control" name="Emergency Contact Number" placeholder="Emergency Contact Number" runat="server" />
                    </div>

                </div>
                <br />
                <br />

                <div class="form-group form-inline">

                    <div class="col-md-6">
                        <label class="col-md-4 control-label">Local Address:</label>
                       

                        <textarea id="txtLocalAdd" class="col-md-6 form-control" placeholder="Local Address" runat="server"></textarea>
                    </div>

                    <div class="col-md-6">
                        <label class="col-md-4 control-label">Permanent Address:</label>
                    
                        <textarea id="txtPermanentAdd" class="col-md-6 form-control" placeholder="Permanent Address" runat="server"></textarea>
                    </div>

                </div>
                <br />
                <br />
                <br />
      
                <div class="form-group form-inline">

                    <div class="col-md-6">
                        <label class="col-md-4 control-label">PAN Number:</label>
                        <span style="color: red">*</span>
                        <asp:TextBox ID="txtPAN" class="col-md-6 form-control" name="PAN Number" placeholder="PAN Number" runat="server" />
                    </div>

                    <div class="col-md-6">
                        <label class="col-md-4 control-label">Passport Number:</label>
                       
                        <asp:TextBox ID="txtPassport" class="col-md-6 form-control" name="Passport Number" placeholder="Passport Number" runat="server" />
                    </div>

                </div>
                <br />
                <br />

                <div class="form-group form-inline">

                    <div class="col-md-6">
                        <label class="col-md-4 control-label">Bank Name:</label>

                        <asp:TextBox ID="txtBankName" class="col-md-6 form-control" name="Bank Name" placeholder="Bank Name" runat="server" />

                    </div>

                    <div class="col-md-6">
                        <label class="col-md-4 control-label">Branch Location:</label>

                        <asp:TextBox ID="txtBranchLocation" class="col-md-6 form-control" name="Branch Location" placeholder="Branch Location" runat="server" />
                    </div>

                </div>
                <br />
                <br />


                <div class="form-group form-inline">

                    <div class="col-md-6">
                        <label class="col-md-4 control-label">Account Number:</label>

                        <asp:TextBox ID="txtAccountNo" class="col-md-6 form-control" name="Account Number" placeholder="Account Number" runat="server" />

                    </div>

                    <div class="col-md-6">
                        <label class="col-md-4 control-label">IFSC Code:</label>

                        <asp:TextBox ID="txtIFSC" class="col-md-6 form-control" name="IFSC Code" placeholder="IFSC Code" runat="server" />
                    </div>

                </div>
                <br />
                <br />


                <div class="form-group form-inline">

                    <div class="col-md-6">
                        <label class="col-md-4 control-label">Select Role:</label>
                        <span style="color: red">*</span>

                        <asp:DropDownList ID="drdRole" class="col-md-6 form-control" runat="server" OnSelectedIndexChanged="drdRole_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    </div>

                    <div class="col-md-6">
                        <label id="lblImage" runat="server" class="col-md-4 control-label">Image:</label>


                        <asp:FileUpload ID="empImage" class="col-md-6 form-control" runat="server" />
                    </div>

                </div>
                <br />
                <br />


                <div class="form-group form-inline fa-align-right">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />

                     <asp:Button ID="btnSaveandaddnew" runat="server" Text="Save&AddNew" OnClick="btnSaveandAddNew_Click" />
                    
                    <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="Update_Click" />

                    <asp:Button ID="btncancel" runat="server" OnClick="Cancel_Click" Text="Cancel" />
                </div>



            </div>
            <!-- /.container-fluid -->

        </div>
        <!-- /#page-wrapper -->

    </div>
    <!-- /#wrapper -->

</asp:Content>
