<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Aguai_Leave_Management_System.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom CSS -->
    <link href="css/sb-admin.css" rel="stylesheet" />

    <!-- Custom Fonts -->
    <link href="font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />


    <title>Aguai Solutions - Login System</title>
    <script src="Scripts/jquery-2.1.1.intellisense.js"></script>
    <script src="Scripts/jquery-2.1.1.js"></script>
    <script src="Scripts/jquery-2.1.1.min.js"></script>
    <script src="bootstrap-datetimepicker.min.js"></script>
    <script src="bootstrap.js"></script>
    <script src="bootstrap.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

     <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.7.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.16/jquery-ui.js" type="text/javascript"></script>
 <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>

       <script src="Scripts/jquery-ui-1.11.1.js"></script>
    <script src="Scripts/jquery-ui.min-1.11.1.js"></script>

    <script src="bootstrap-datetimepicker.min.js"></script>

   <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.16/themes/humanity/jquery-ui.css"
        rel="stylesheet" type="text/css" /> 

    

    <link href="Content/themes/base/datepicker.css" rel="stylesheet" />
    <link href="bootstrap-datetimepicker.min.css" rel="stylesheet" />
 
    <link href="bootstrap-theme.css" rel="stylesheet" />
    <link href="bootstrap-theme.min.css" rel="stylesheet" />
    <link href="bootstrap.css" rel="stylesheet" />
    <link href="bootstrap.min.css" rel="stylesheet" />

    <script type="text/javascript">
        var specialKeys = new Array();
        specialKeys.push(8); //Backspace
        $(function () {
            $(".numeric").bind("keypress", function (e) {
                var keyCode = e.which ? e.which : e.keyCode
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
            $('#txtFN').keydown(function (e) {
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
        $(function () {
            $('#txtLN').keydown(function (e) {
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
   
        $(function () {
            $("[id$=txtDOJ]").datepicker();
        });
        $(function () {
            $("[id$=txtDOB]").datepicker();
        });
</script>

    <script type="text/javascript">
        function validate() 
        {
            var Username = document.getElementById('<%=txtUsername.ClientID %>').value;
            var Firstname = document.getElementById('<%=txtFN.ClientID %>').value;
            var Lastname = document.getElementById('<%=txtLN.ClientID %>').value;
            var Gender = document.getElementById('<%=ddlgender.ClientID %>').value;
            var Email = document.getElementById('<%=txtEmail.ClientID %>').value;
            var Password = document.getElementById('<%=txtPassword.ClientID %>').value;
            var DOJ = document.getElementById('<%=txtDOJ.ClientID %>').value;
            var DOB = document.getElementById('<%=txtDOB.ClientID %>').value;
            var Contact = document.getElementById('<%=txtCON.ClientID %>').value;
            var Address = document.getElementById('<%=txtAddress.ClientID %>').value;

            if (Username == "") {
                alert("User name should not BE Empty");
                return false;
            }
            if (Firstname == "") {
                alert("First name should not BE Empty");
                return false;
            }
             else if (Lastname == "") {
                 alert("Last name should not BE Empty");
                 return false;
             }
             else if (Gender == "") {
                 alert("Gender should not BE Empty");
                 return false;
             }
             else if (Email == "") {
                 alert("Email should not BE Empty");
                 return false;
             }
             else if (Password == "") {
                 alert("Password should not BE Empty");
                 return false;
             }
             else if (Password.length < 6) {
                 alert("Password must have 6 characters");
                 return false;
             }
             else if (DOJ == "") {
                 alert("Date_of_Joining should not BE Empty");
                 return false;
             }
             else if (DOB == "") {
                 alert("Date_of_Birth should not BE Empty");
                 return false;
             }
             else if (Contact == "") {
                 alert("Contact should not BE Empty");
                 return false;
             }
             else if (Address == "") {
                 alert("Address should not BE Empty");
                 return false;
             }        
           
        }
    </script>

</head>
<body style="background: cadetblue;">

    <div class="container">

        <div style="padding-top: 10px;" class="panel-body">

            <div style="display: none" id="login-alert" class="alert alert-danger col-sm-12"></div>

            <form id="loginform" class="form-horizontal" method="POST" runat="server">

                <div id="loginbox" style="margin-top: 90px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                    <div class="panel panel-info">
                        <div class="panel-heading" style="text-align: center">
                            <div class="panel-title"><b>Aguai Solutions Leave Management</b></div>

                        </div>
                        <br />
                        <br />


                      <%-- txtEmailId--%>

                        <div style="margin-bottom: 25px" class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                <asp:TextBox ID="txtEmail1" class="form-control" name="email" placeholder="Email Address" runat="server" />
                            </div>
                       

                        <%-- txtPassword--%>

                        <div style="margin-bottom: 25px" class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                            <asp:TextBox ID="txtpwd" TextMode="password" class="form-control" name="password" placeholder="password" runat="server" />
                        </div>

                        <%-- btnLogin--%>

                        <div style="margin-top: 10px" class="form-group">

                            <div class="col-sm-12 controls">
                                <asp:Button ID="btnLogin" Text="Login" OnClick="btnLogin_Click" type="button" class="btn btn-primary" runat="server" />
                                <a id="btn-fblogin" href="#" class="btn btn-primary" onclick="$('#loginbox').hide(); $('#signupbox').show()">Register Here</a>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-14 control">

                                <div style="border-top: 1px solid#888; padding-top: 15px; margin-left: 18px; font-size: 85%">
                                    Forgot Password Please click here!!!
                                        <a href="#">Forgot password?</a>
                                </div>

                            </div>
                        </div>

                    </div>
                </div>


                <div id="signupbox" style="display: none;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <div class="panel-title">Please Sign Up </div>
                            <div style="float: right; position: relative;"></div>
                        </div>
                        <br />


                        <div id="signupalert" style="display: none" class="alert alert-danger">
                            <p>Error:</p>
                            <span></span>
                        </div>

                        <%-- txtUsername--%>

                        <div class="form-group">
                            <label for="firstname" class="col-md-3 control-label">User Name</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtUsername" class="form-control" name="UserName" placeholder="User Name" runat="server" />
                            </div>
                        </div>

                        <%-- txtFirstname--%>
                        
                        <div class="form-group">
                            <label for="firstname" class="col-md-3 control-label">First Name</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtFN" class="form-control" name="firstname" placeholder="First Name" runat="server" />
                            </div>
                        </div>

                        <%-- txtLastname--%>

                        <div class="form-group">
                            <label for="lastname" class="col-md-3 control-label">Last Name</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtLN" class="form-control" name="lastname" placeholder="Last Name" runat="server" />
                            </div>
                        </div>

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

                        <%-- txtEmailId--%>

                        <div class="form-group">
                            <label for="email" class="col-md-3 control-label">Email Id:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtEmail" class="form-control" name="email" placeholder="Email Address" runat="server" />
                            </div>
                        </div>

                        <%-- txtPassword--%>

                        <div class="form-group">
                            <label for="password" class="col-md-3 control-label">Password</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtPassword" TextMode="password" class="form-control" name="passwd" placeholder="Password" runat="server" />
                            </div>
                        </div>
                        
                        <%-- txtDate_Of_Joining--%>

                        <div class="form-group">
                            <label for="Date Of Joining" class="col-md-3 control-label">Date Of Joining</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtDOJ" class="form-control" name="Date Of Joining" placeholder="Date Of Joining" runat="server" />
                            </div>
                        </div>

                         <%-- txtDate_Of_Birth--%>

                        <div class="form-group">
                            <label for="Date Of Birth" class="col-md-3 control-label">Date Of Birth</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtDOB" class="form-control" name="Date Of Birth" placeholder="Date Of Birth" runat="server" />
                            </div>
                        </div>

                         <%-- txtContact--%>

                        <div class="form-group">
                            <label for="Contact" class="col-md-3 control-label">Contact</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtCON" class="form-control numeric" name="Contact" placeholder="Contact" MaxLength="10" runat="server" />
                            </div>
                        </div>

                         <%-- txtarea_Of_Address--%>

                        <div class="form-group">
                            <label for="Address" class="col-md-3 control-label">Address</label>
                            <div class="col-md-8">
                                <textarea id="txtAddress" class="form-control" rows="3" runat="server" />
                            </div>
                        </div>

                         <%-- btnSignUp--%>

                        <div class="form-group">
                            <!-- Button -->
                            <div class="col-md-offset-3 col-md-9">

                                <asp:Button ID="btnSave" Text="SignUp" OnClick="btnSignUp_Click" OnClientClick="return validate();" type="button" class="btn btn-primary" runat="server" />
                                <%--  <button onclick="btnSave_Click" type="button" class="btn btn-primary">&nbsp;SignUp&nbsp; </button>
					                        <span style="margin-left:4px;">or&nbsp;</span>--%>

                                <button id="signinlink" onclick="$('#signupbox').hide(); $('#loginbox').show()" class="btn btn-primary"><i class="icon-facebook"></i>Already Member Login!!</button>
                            </div>
                        </div>
                    </div>
                </div>

            </form>
        </div>

    </div>


</body>
</html>
