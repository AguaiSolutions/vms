<%@ Page Title="Apply Leaves" Language="C#" MasterPageFile="~/Master/Aguai Master1.Master" AutoEventWireup="true" CodeBehind="ApplyLeave.aspx.cs" Inherits="Aguai_Leave_Management_System.ApplyLeave" %>

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
                                        <asp:Label ID="lblregno" class="navbar-brand navbar-left top-nav" runat="server">Registration No : </asp:Label><br />
                                        <br />
                                        <br />

                                        <div>
                                            <label>Type:</label>
                                            <asp:DropDownList ID="ddltype" runat="server" Width="200px">
                                                <asp:ListItem Text="Select Type"></asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                        <br />
                                        <br />

                                        <label for="name">Description</label>
                                        <textarea id="txtdescription" class="form-control" rows="3" runat="server" /><br />
                                        <br />
                                        <br />

                                         <div class="form-group" id="content">
                    <script type="text/javascript">
                        $(function () {
                            var date = new Date();
                            var currentMonth = date.getMonth(); // current month
                            var currentDate = date.getDate(); // current date
                            var currentYear = date.getFullYear(); //this year
                            $("#<%= txtstartdate.ClientID %>").datepicker({
                                changeMonth: true, // this will allow users to chnage the month
                                changeYear: true, // this will allow users to chnage the year
                                minDate: new Date(currentYear, currentMonth, currentDate),
                                beforeShowDay: function (date) {
                                    if (date.getDay() == 0 || date.getDay() == 6) {
                                        return [false, ''];
                                    } else {
                                        return [true, ''];
                                    }
                                }
                            });
                            $("#<%= txtenddate.ClientID %>").datepicker({
                                changeMonth: true, // this will allow users to chnage the month
                                changeYear: true, // this will allow users to chnage the year
                                minDate: new Date(currentYear, currentMonth, currentDate),
                                beforeShowDay: function (date) {
                                    if (date.getDay() == 0 || date.getDay() == 6) {
                                        return [false, ''];
                                    } else {
                                        return [true, ''];
                                    }
                                }
                            });
                        });

                    </script>
                                            From
                                                <asp:TextBox ID="txtstartdate" class="field" runat="server"></asp:TextBox>
                                            -
                                             To
                                                <asp:TextBox ID="txtenddate" class="field" runat="server"></asp:TextBox>
                                        </div>
                                        <br />



                                        <div>
                                            <label>Approver:</label>
                                            <asp:DropDownList ID="ddlapprover" runat="server" Width="200px">
                                                <asp:ListItem Text="select Approver"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="btn-group form-inline">
                                            <asp:Button ID="btnsubmit" Text="Submit" OnClick="btnSubmit_Click" class="btn btn-default btn-success" runat="server" />
                                        </div>

                                        <div class="btn-group form-inline">
                                            <asp:Button ID="btnclear" Text="Clear" OnClick="btnClear_Click" class="btn btn-default btn-success" runat="server" />
                                        </div>
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



