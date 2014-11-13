<%@ Page Title="Add-Employee" Language="C#" MasterPageFile="~/Aguai Master1.Master" AutoEventWireup="true" CodeBehind="Add-Employee.aspx.cs" Inherits="Aguai_Leave_Management_System.Add_Employee" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <section>

        <div id="wrapper">

            <div id="page-wrapper">

                <div class="container-fluid">
                    <!-- /.row -->

                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">

                                    <%-- txtFirstname--%>

                                    <div class="form-group">
                                        <label for="firstname" class="col-md-3 control-label">First Name</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtFN" class="form-control" name="firstname" placeholder="First Name" runat="server" />
                                        </div>
                                    </div>
                                    <br />
                                    <br />

                                    <%-- txtLastname--%>

                                    <div class="form-group">
                                        <label for="lastname" class="col-md-3 control-label">Last Name</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtLN" class="form-control" name="lastname" placeholder="Last Name" runat="server" />
                                        </div>
                                    </div>
                                    <br />
                                    <br />

                                    <%-- ddlGender--%>

                                    <div class="form-group">
                                        <label for="lastname" class="col-md-3 control-label">Gender:</label>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlgender" runat="server" class="form-control" placeholder="" Width="200px" Font-Size="Large">
                                                <asp:ListItem Text="Male"></asp:ListItem>
                                                <asp:ListItem Text="Female"></asp:ListItem>
                                                <asp:ListItem Text="Other"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />
                                    <br />

                                    <%-- txtEmailId--%>

                                    <div class="form-group">
                                        <label for="email" class="col-md-3 control-label">Email Id:</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtEmail" class="form-control" name="email" placeholder="Email Address" runat="server" />
                                        </div>
                                    </div>
                                    <br />
                                    <br />

                                    <%-- txtPassword--%>

                                    <div class="form-group">
                                        <label for="password" class="col-md-3 control-label">Password</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtPassword" TextMode="password" class="form-control" name="passwd" placeholder="Password" runat="server" />
                                        </div>
                                    </div>
                                    <br />
                                    <br />

                                    <%-- txtDate_Of_Joining--%>

                                    <div class="form-group">
                                        <label for="Date Of Joining" class="col-md-3 control-label">Date Of Joining</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtDOJ" class="form-control" name="Date Of Joining" placeholder="Date Of Joining" runat="server" />
                                        </div>
                                    </div>
                                    <br />
                                    <br />

                                    <%-- txtDate_Of_Birth--%>

                                    <div class="form-group">
                                        <label for="Date Of Birth" class="col-md-3 control-label">Date Of Birth</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtDOB" class="form-control" name="Date Of Birth" placeholder="Date Of Birth" runat="server" />
                                        </div>
                                    </div>
                                    <br />
                                    <br />

                                    <%-- txtContact--%>

                                    <div class="form-group">
                                        <label for="Contact" class="col-md-3 control-label">Contact</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtCON" class="form-control numeric" name="Contact" placeholder="Contact" MaxLength="10" runat="server" />
                                        </div>
                                    </div>
                                    <br />
                                    <br />

                                    <%-- txtarea_Of_Address--%>

                                    <div class="form-group">
                                        <label for="Address" class="col-md-3 control-label">Address</label>
                                        <div class="col-md-8">
                                            <textarea id="txtAddress" class="form-control" rows="3" runat="server" />
                                        </div>
                                    </div>
                                    <br />
                                    <br />
                                    <br />

                                    <%-- btnSignUp--%>

                                    <div class="form-group">
                                        <!-- Button -->
                                        <div class="col-md-offset-3 col-md-9">

                                            <asp:Button ID="btnSave" Text="SignUp" OnClick="btnSignUp_Click" OnClientClick="return validate();" type="button" class="btn btn-primary" runat="server" />
                                            <%--  <button onclick="btnSave_Click" type="button" class="btn btn-primary">&nbsp;SignUp&nbsp; </button>
					                        <span style="margin-left:4px;">or&nbsp;</span>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel-body">
                                    <div id="morris-area-chart"></div>
                                </div>
                            </div>
                        </div>
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



