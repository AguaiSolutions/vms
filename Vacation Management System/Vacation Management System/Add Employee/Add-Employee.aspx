<%@ Page Title="Add-Employee" Language="C#" MasterPageFile="~/Master/Aguai Master1.Master" AutoEventWireup="true" CodeBehind="Add-Employee.aspx.cs" Inherits="Aguai_Leave_Management_System.Add_Employee" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <section>

        <div id="wrapper">

            <div id="page-wrapper">

                <div class="container-fluid">
                    <!-- /.row -->

            <script>
                $(function () {
                    $("#txtDOB").datepicker();
                    $("#txtDOJ").datepicker();
                });
            </script>
            <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:Label ID="lblEmpid" runat="server" Text="Employee ID:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmpid" runat="server"></asp:TextBox>
                        <br />
                    </td>
                    <br/>
                    <td>
                        <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                        <br />
                    </td>
                    <td>
                        <asp:Label ID="lblGender" runat="server" Text="Select Gender:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="drpGender" runat="server">
                            <asp:ListItem Text="Male"></asp:ListItem>
                            <asp:ListItem Text="Female"></asp:ListItem>
                            <asp:ListItem Text="Other"></asp:ListItem>
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
                    <td>
                        <asp:Label ID="lblOfficialEmail" runat="server" Text="Official Email:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOfficialEmail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDOJ" runat="server" Text="Date of Joining:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDOJ" runat="server"></asp:TextBox>
                        <br />
                    </td>
                    <td>
                        <asp:Label ID="lblDOB" runat="server" Text="Date of Birth:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPAN" runat="server" Text="PAN Number:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPAN" runat="server"></asp:TextBox>
                        <br />
                    </td>
                    <td>
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
                    <td>
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
                        <textarea id="txtLocalAdd" cols="20" name="S1" rows="2"></textarea><br />
                    </td>
                    <td>
                        <asp:Label ID="lblPermanentAdd" runat="server" Text="Permanent Address:"></asp:Label>
                    </td>
                    <td>
                        <textarea id="txtPermanentAdd" cols="20" name="S2" rows="2"></textarea></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblBankName" runat="server" Text="Bank Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBankName" runat="server"></asp:TextBox>
                        <br />
                    </td>
                    <td>
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
                    <td>
                        <asp:Label ID="lblIFSC" runat="server" Text="IFSC Code:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtIFSC" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblRole" runat="server" Text="Role:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="drpRole" runat="server" OnSelectedIndexChanged="drpRole_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        <br />
                    </td>
                    <td>
                        <asp:Label ID="lblImage" runat="server" Text="Image:"></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="imgEmployee" runat="server" />
                    </td>
                </tr>
                <br/>
                <tr>
                    <td></td>
                    <td>
                        <br />
                        <br />
                        <br />
                    </td>
                    <td class="auto-style2">
                        <asp:Button ID="btnAddEmployee" runat="server" Text="Add Employee" />
                    </td>
                <td>
                    <input type="reset"/>
                </td>
                    
                </tr>


            </table>

                    
                    
                    

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



