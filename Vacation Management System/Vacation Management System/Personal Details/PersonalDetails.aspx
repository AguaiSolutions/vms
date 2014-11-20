<%@ Page Title="Personal Details" Language="C#" MasterPageFile="~/Master/Aguai Master1.Master" AutoEventWireup="true" CodeBehind="PersonalDetails.aspx.cs" Inherits="Aguai_Leave_Management_System.PersonalDetails" %>

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

                                    <div class="form-group">
                                        <asp:Label ID="lblregno" class="navbar-brand navbar-left top-nav" runat="server">Registration No :  </asp:Label><br />
                                        <br />
                                        <br />
                                        <br />

                                        <asp:Label ID="lblemp" class="navbar-brand navbar-left top-nav" runat="server">Employee Name :  </asp:Label><br />
                                        <br />
                                        <br />
                                        <br />

                                        <asp:Label ID="lblemail" class="navbar-brand navbar-left top-nav" runat="server">Email Id :  </asp:Label><br />
                                        <br />
                                        <br />
                                        <br />

                                        <asp:Label ID="lblcont" class="navbar-brand navbar-left top-nav" runat="server">Contact Number :  </asp:Label><br />
                                        <br />
                                        <br />
                                        <br />

                                        <asp:Label ID="lbladdress" class="navbar-brand navbar-left top-nav" runat="server">Address :  </asp:Label><br />
                                        <br />
                                        <br />
                                        <br />

                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div id="morris-area-chart"></div>
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





