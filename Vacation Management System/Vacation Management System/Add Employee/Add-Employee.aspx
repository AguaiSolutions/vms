<%@ Page Title="Add-Employee" Language="C#" MasterPageFile="~/Master/Aguai Master1.Master" AutoEventWireup="true" CodeBehind="Add-Employee.aspx.cs" Inherits="Aguai_Leave_Management_System.Add_Employee" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <section>

        <div id="wrapper">

            <div id="page-wrapper">

                <div class="container-fluid">
                    <div class="form-group" id="content">
                        <script type="text/javascript">
                            $(function () {
                                $("[id$=txtDOJ]").datepicker();
                            });
                            $(function () {
                                $("[id$=txtDOB]").datepicker();
                            });
                        </script>
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="lblEmpNo" runat="server">Employee Number:
                            <span style="color: red">*</span>
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmpNo" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rftxtEmpNo1" runat="server" ControlToValidate="txtEmpNo" ForeColor="red" ErrorMessage="Enter the Employee No"></asp:RequiredFieldValidator>
                                    <br />
                                </td>
                                <br />
                                <td class="auto-style3">
                                    <asp:Label ID="lblFirstName" runat="server">First Name:
                            <span style="color: red">*</span>
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rftxtFirstName" runat="server" ControlToValidate="txtFirstName" ForeColor="red" ErrorMessage="Enter the FirstName"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lblLastName" runat="server">Last Name:
                            <span style="color: red">*</span>
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rftxtLastName" runat="server" ControlToValidate="txtLastName" ForeColor="red" ErrorMessage="Enter the LastName"></asp:RequiredFieldValidator>
                                    <br />
                                </td>
                                <td class="auto-style3">
                                    <asp:Label ID="lblGender" runat="server">Select Gender:
                            <span style="color: red">*</span>
                                    </asp:Label>
                                </td>
                                <td>
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
                                    <asp:RegularExpressionValidator ID="extxtPersonalEmail" runat="server" ControlToValidate="txtPersonalEmail" ForeColor="red" ErrorMessage="Enter valid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    <br />
                                </td>
                                <td class="auto-style3">
                                    <asp:Label ID="lblOfficialEmail" runat="server">Official Email:
                            <span style="color: red">*</span>
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOfficialEmail" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rftxtOfficialEmail" runat="server" ControlToValidate="txtOfficialEmail" ForeColor="red" ErrorMessage="Enter the Official Mail"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDOJ" runat="server">Date of Joining:
                            <span style="color: red">*</span>
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDOJ" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rftxtDOJ" runat="server" ControlToValidate="txtDOJ" ForeColor="red" ErrorMessage="Enter the Date of Join"></asp:RequiredFieldValidator>
                                    <br />
                                </td>
                                <td class="auto-style3">
                                    <asp:Label ID="lblDOB" runat="server" Text="Date of Birth:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPAN" runat="server">PAN Number:
                            <span style="color: red">*</span>
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPAN" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rftxtPAN" runat="server" ControlToValidate="txtPAN" ForeColor="red" ErrorMessage="Enter the PAN number"></asp:RequiredFieldValidator>
                                    <br />
                                </td>
                                <td class="auto-style3">
                                    <asp:Label ID="lblPassport" runat="server" Text="Passport Number"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPassport" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblContactNo" runat="server" Text="Contact Number:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtContactNo" runat="server"></asp:TextBox>
                                    
                                    <br />
                                </td>
                                <td class="auto-style3">
                                    <asp:Label ID="lblEmergencyNo" runat="server" Text="Emergency Contact Number:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmergencyNo" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblLocalAdd" runat="server" Text="Local Address:"></asp:Label>
                                </td>
                                <td>
                                    <textarea id="txtLocalAdd" runat="server" cols="20" name="S1" rows="2"></textarea><br />
                                </td>
                                <td class="auto-style3">
                                    <asp:Label ID="lblPermanentAdd" runat="server" Text="Permanent Address:"></asp:Label>
                                </td>
                                <td>
                                    <textarea id="txtPermanentAdd" runat="server" cols="20" name="S2" rows="2"></textarea></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblBankName" runat="server" Text="Bank Name:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBankName" runat="server"></asp:TextBox>
                                    <br />
                                </td>
                                <td class="auto-style3">
                                    <asp:Label ID="lblBranch" runat="server" Text="Branch Location:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBranchLocation" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblAccount" runat="server" Text="Account Number:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAccountNo" runat="server"></asp:TextBox>
                                    <br />
                                </td>
                                <td class="auto-style3">
                                    <asp:Label ID="lblIFSC" runat="server" Text="IFSC Code:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtIFSC" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblRole" runat="server">Select Role:
                            <span style="color: red">*</span>
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpRole" runat="server" OnSelectedIndexChanged="drpRole_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                    <br />
                                </td>
                                <td class="auto-style3">
                                    <asp:Label ID="lblImage" runat="server" Text="Image:"></asp:Label>
                                </td>
                                <td>
                                    <asp:FileUpload ID="imgEmployee" runat="server" />
                                </td>
                            </tr>
                            <br />
                            <tr>
                                <td></td>
                                <td>
                                    <br />
                                    <br />
                                    <br />
                                </td>
                                <td class="auto-style3">
                                    <asp:Button ID="btnAddEmployee" runat="server" Text="Add Employee" OnClick="btnAddEmployee_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                                </td>

                            </tr>


                        </table>

                    </div>



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



<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style3 {
            width: 240px;
        }
    </style>
</asp:Content>




