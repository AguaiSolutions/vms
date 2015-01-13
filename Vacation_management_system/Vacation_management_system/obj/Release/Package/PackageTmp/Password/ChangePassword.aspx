<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Vacation_management_system.Web.Login.changepassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style4 {
            width: 157px;
        }
    </style>
  
        <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <script>
        function confirmation() {
            alert('Successfully updated your password , please login with new password');
            window.location = "/Login.aspx";
        }

        function validatelink() {
            alert('This is not a valid link ');
           
        }
    </script>
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="wrapper">

        <div id="page-wrapper">

            <div class="container-fluid" style="background-color: white;">
                <!-- /.row -->

                <!-- Page Heading -->
               <%-- <div class="row">
                    <div class="col-lg-12">--%>
                        <h1 class="page-header">Password Reset
                        </h1>
                        <%--<ol class="breadcrumb">
                            <li>
                                <i class="fa fa-file"></i>  Report
                            </li>

                        </ol>--%>
                   <%-- </div>
                </div>--%>
                <!-- Page Heading End -->

                <!-- Report form body -->

                <%--<div class="col-lg-12">
                    <div class="row">--%>
                      <%--  <div class="col-lg-12">--%>
                            <div class="panel panel-default col-lg-8" style="float: left; width: 950px">
                                
                                <%--<div class="panel-heading">
                                <h2>Vacation-Report </h2>
                            </div>--%>

                                <%--<div class="panel-body">
                                    <ol class="breadcrumb">
                                        <li>
                                            <i class="fa fa-file"></i>  Password Reset
                                        </li>

                                    </ol>--%>

                                    <table  >
                                        <tr>
                                            <td class="auto-style4">
                                                 Email</td>
                                            <td>
                                                 <asp:TextBox ID="txtEmail" name="Email" CssClass="form-control" placeholder="Email Id" runat="server" Height="35px" Width="300px" Enabled="false" ></asp:TextBox>
                                            </td>
                                        </tr>
                                           <tr><td class="auto-style4"><br /></td></tr>
                                        <tr>
                                            <td class="auto-style4"  >
                                                <label class="control-label">New Password</label></td>
                                            <td  >
                                                <asp:TextBox ID="txtNewpassword" name="New password" CssClass="form-control" TextMode="Password" placeholder="New Password" runat="server" Height="35px" Width="300px" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="ReqNewpassword" runat="server" ForeColor="Red" ErrorMessage="Please enter the new password" ControlToValidate="txtNewpassword"></asp:RequiredFieldValidator>
                                               <%-- <asp:RegularExpressionValidator ID="Regtxtpassword" runat="server" ErrorMessage="RegularExpressionValidator" ></asp:RegularExpressionValidator>
                                            </td>--%>
                                                </td>
                                            <br />
                                            </tr>
                                        <tr><td class="auto-style4"><br /></td></tr>
                                        <tr>
                                            <td class="auto-style4" >
                                                <label class="control-label">Confirm Password</label></td>
                                            <td>
                                                <asp:TextBox ID="txtConfirmpassword" runat="server" Height="35px" TextMode="Password"  CssClass="form-control"  name="Confirm password<asp:RequiredFieldValidator runat=" placeholder="Confirm Password" RequiredFieldValidator="" server="" Width="300px"></asp:TextBox>
                                                <asp:CompareValidator ID="cmpassword" runat="server" ErrorMessage="CompareValidator" ControlToValidate="txtConfirmpassword" ControlToCompare="txtNewpassword" ForeColor="Red" Type="String" Text="password missmatch"></asp:CompareValidator>
                                            <asp:RequiredFieldValidator ID="Reqconfirmpassword"  runat ="server" ControlToValidate="txtConfirmpassword"  ErrorMessage="Please enter the confirm password"></asp:RequiredFieldValidator>

                                                <br />
                                               <%-- <asp:RegularExpressionValidator ID="Regconfirmpassword" runat="server" ErrorMessage="RegularExpressionValidator"></asp:RegularExpressionValidator>--%>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                            </tr>
                                        <tr>
                                            <td class="auto-style4">
                                                <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" CssClass="btn bg-primary" OnClick="btnSubmit_Click" />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style4">
                                                <br />
                                            </td>
                                        </tr>
                                        </table>
                                    </div>
    
    </div>
    </form>
</body>
</html>
