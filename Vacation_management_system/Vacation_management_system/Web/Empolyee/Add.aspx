<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Vacation_management_system.Web.Empolyee.WebForm1" %>
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
      <div id="wrapper"  >

            <div id="page-wrapper">

                <div class="container-fluid"  style="background-color:white;">
                    <!-- /.row -->

                    <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">
                            Add Employees
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="glyphicon glyphicon-home"></i>  <a href="~/Web/Dashboard/Dashboard.aspx" runat="server">Dashboard</a>
                            </li>
                            <li class="active">
                                <i class="glyphicon glyphicon-plus-sign"></i> Add Employees
                            </li>
                        </ol>
                    </div>
                </div>
                    <!-- /.table -->
                    <table style="width: 100%;">
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="lblEmpNo" runat="server">Employee Number:
                            <span style="color: red">*</span>
                                    </asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="txtEmpNo" runat="server"></asp:TextBox>
                                   
                                    <br />
                                </td>
                                
                                <td class="auto-style1">
                                    <asp:Label ID="lblFirstName" runat="server">First Name:
                            <span style="color: red">*</span>
                                    </asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                                    
                                </td>
                            </tr>

                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="lblLastName" runat="server">Last Name:
                            <span style="color: red">*</span>
                                    </asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                                    
                                    <br />
                                </td>
                                <td class="auto-style1">
                                    <asp:Label ID="lblGender" runat="server">Select Gender:
                            <span style="color: red">*</span>
                                    </asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:DropDownList ID="drpGender" runat="server">
                                        <asp:ListItem Value="M">Male</asp:ListItem>
                                        <asp:ListItem Value="F">Female</asp:ListItem>
                                        <asp:ListItem Value="O">other</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPersonalEmail" runat="server" Text="Personal Email:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPersonalEmail" runat="server"></asp:TextBox>
                                   
                                    <br />
                                </td>
                                <td class="auto-style1">
                                    <asp:Label ID="lblOfficialEmail" runat="server">Official Email:
                            <span style="color: red">*</span>
                                    </asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="txtOfficialEmail" runat="server"></asp:TextBox>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="lblDOJ" runat="server">Date of Joining:
                            <span style="color: red">*</span>
                                    </asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="txtDOJ" runat="server"></asp:TextBox>
                                  
                                    <br />
                                </td>
                                <td class="auto-style1">
                                    <asp:Label ID="lblDOB" runat="server" Text="Date of Birth:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="lblPAN" runat="server">PAN Number:
                            <span style="color: red">*</span>
                                    </asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="txtPAN" runat="server"></asp:TextBox>
                                  
                                    <br />
                                </td>
                                <td class="auto-style1">
                                    <asp:Label ID="lblPassport" runat="server" Text="Passport Number"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPassport" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="lblContactNo" runat="server" Text="Contact Number:"></asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="txtContactNo" runat="server"></asp:TextBox>
                                    
                                    <br />
                                </td>
                                <td class="auto-style1">
                                    <asp:Label ID="lblEmergencyNo" runat="server" Text="Emergency Contact Number:"></asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="txtEmergencyNo" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="lblLocalAdd" runat="server" Text="Local Address:"></asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <textarea id="txtLocalAdd" runat="server" cols="20" name="S1" rows="2"></textarea><br />
                                </td>
                                <td class="auto-style1">
                                    <asp:Label ID="lblPermanentAdd" runat="server" Text="Permanent Address:"></asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <textarea id="txtPermanentAdd" runat="server" cols="20" name="S2" rows="2"></textarea></td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="lblBankName" runat="server" Text="Bank Name:"></asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="txtBankName" runat="server"></asp:TextBox>
                                    <br />
                                </td>
                                <td class="auto-style1">
                                    <asp:Label ID="lblBranch" runat="server" Text="Branch Location:"></asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="txtBranchLocation" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="lblAccount" runat="server" Text="Account Number:"></asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="txtAccountNo" runat="server"></asp:TextBox>
                                    <br />
                                </td>
                                <td class="auto-style1">
                                    <asp:Label ID="lblIFSC" runat="server" Text="IFSC Code:"></asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="txtIFSC" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="lblRole" runat="server">Select Role:
                            <span style="color: red">*</span>
                                    </asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:DropDownList ID="drpRole" runat="server" OnSelectedIndexChanged="drpRole_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                    <br />
                                </td>
                                <td class="auto-style1">
                                    <asp:Label ID="lblImage" runat="server" Text="Image:"></asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:FileUpload ID="imgEmployee" runat="server" />
                                </td>
                            </tr>
                            
                            <tr>
                                <td class="auto-style1">
                                    <asp:Button ID="btnAddEmployee" runat="server" Text="Add Employee" OnClick="btnAddEmployee_Click" />
                                </td>
                                <td class="auto-style1">
                                    <asp:Button ID="btnClear" runat="server" Text="Save & Add" OnClick="btnSaveandAdd_Click" />
                                </td>
                                <td class="auto-style1">
                                    <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Update_Click" />
                                </td>
                                <td class="auto-style1">
                                    <asp:Button ID="Button2" runat="server" OnClick="Cancel_Click" Text="Cancel" />
                                </td>
                            </tr>
                            
                            <tr>
                                
                                <td class="auto-style1">
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    &nbsp;</td>

                            </tr>

                        </table>
            


                </div>
                <!-- /.container-fluid -->

            </div>
            <!-- /#page-wrapper -->

        </div>
        <!-- /#wrapper -->
</asp:Content>
