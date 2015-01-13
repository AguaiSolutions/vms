<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vacation_management_system.Web.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <script type="text/javascript">

        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (o) }
    </script>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <title>Login </title>

</head>


<body runat="server" style="background-color: ghostwhite">

    <form id="loginform" class="form-horizontal " method="POST" runat="server">

        <div id="loginbox" style="margin-top: 90px;" class="mainbox col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-2">
            <div class="panel">
                <div style="text-align: center">
                    <img  src="../Web/Images/Capture.PNG" style="width:383px;"/>
                </div>
                <div class="panel-heading" style="text-align: center">
                    <div class="panel-title">VACATION MANAGEMENT SYSTEM</div>
                </div>
                <br />

                <div style="margin-bottom: 25px" class="input-group col-md-8 col-md-offset-2">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                    <asp:TextBox ID="txtUsername" class="form-control input-round" name="username" placeholder="Email / Employee No" runat="server" />
                </div>



                <div style="margin-bottom: 25px" class="input-group col-md-8 col-md-offset-2">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                    <asp:TextBox ID="txtPassword" TextMode="password" class="form-control input-round" name="password" placeholder="Password" runat="server" />
                </div>

                <div style="margin-top: 10px" class="form-group">
                    <!-- Button -->

                    <div class="col-sm-10 col-md-offset-2 controls">
                        <asp:Button Style="margin-right: 40px" ID="butsignin" Text="Sign In" OnClick="butsignin_Click" type="button" class="click btn btn-info" runat="server" />
                        <a style="margin-left: 40px" href="~/Password/ForgotPassword.aspx" runat="server">Forgot password?</a>
                    </div>
                </div>
            </div>
        </div>
    </form>

</body>
</html>
