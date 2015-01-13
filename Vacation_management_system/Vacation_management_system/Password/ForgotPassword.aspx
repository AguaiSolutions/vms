<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Vacation_management_system.Web.Login.ForgotPassword" %>

<!DOCTYPE html>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
  <link href="/Content/bootstrap-datepicker.css" rel="stylesheet" />
    <link href="/Content/bootstrap-datepicker3.css" rel="stylesheet" />
    <link href="/Content/bootstrap-theme.css" rel="stylesheet" />
    <%--<link href="/Content/bootstrap-theme.min.css" rel="stylesheet" />--%>
    <link href="/Content/bootstrap.css" rel="stylesheet" />
    <%--<link href="/Content/bootstrap.min.css" rel="stylesheet" />--%>
   
    <link href="/Content/font-awesome.min.css" rel="stylesheet" />

    <%--<script src="/Scripts/jquery-2.1.1.min.js"  ></script>--%>
    <script src="/Scripts/jquery-2.1.1.js"></script>
    <script src="/Scripts/select2.js"></script>
    <link href="/Content/css/select2.css" rel="stylesheet" />
    <script src="/Scripts/bootstrap-datepicker.js"></script>
    <script src="/Scripts/bootstrap.js"></script>
    <style type="text/css">
        .auto-style4 {
            height: 79px;
        }
        .auto-style5 {
            height: 57px;
        }
        .auto-style6 {
            height: 57px;
            width: 137px;
        }
        .auto-style7 {
            height: 79px;
            width: 137px;
        }
        .auto-style8 {
            width: 137px
        }
    </style>
  <script>
      $(function () {
          $("[id$=txtdob]").datepicker({
              format: 'dd/mm/yyyy',
              autoclose: true,
              todayHighlight: true
          });
      });
  </script>
      
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="wrapper">

        <div id="page-wrapper">

            <div class="container-fluid" style="background-color: white; ">
               
                            <div class="panel panel-default" style="float: left; width:500px; margin-top:100px; margin-left:300px">
                                <h3 class="text-center">Forgot Password</h3>

                                    <table style="align-items:center;margin-left:30px;margin-bottom:30px">
                                        <tr>
                                            <td class="auto-style6"  >
                                                <label class="control-label">Email :<span style="color: red">*</span></label>
                                            </td>
                                            <td class="auto-style5"  >
                                                <asp:TextBox ID="txtEmail"   CssClass="form-control" runat="server" Height="35px" Width="200px"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RV1" runat="server"  Display="None"
                                                  ControlToValidate="txtEmail" 
                                                 ErrorMessage="Please Enter Email ID" 
                                                 SetFocusOnError="True">
                                                </asp:RequiredFieldValidator>
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  runat="server" ErrorMessage="please enter valid email id." ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                            </td>
                                            </tr>
                                        <tr>
                                            <td class="auto-style7" >
                                                <label class="control-label">Date of Birth :<span style="color: red">*</span></label></td>
                                            <td class="auto-style4 text-left">
                                                <asp:TextBox ID="txtdob"  CssClass="form-control" runat="server" Height="35px" Width="200px" ></asp:TextBox>
                                                <br />
                                               
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  Display="None"
                                                  ControlToValidate="txtdob" 
                                                  ErrorMessage="Please Enter Date of birth." 
                                                 SetFocusOnError="True">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            </tr>
                                        <tr>
                                            <td class="auto-style8">
                                                
                                            </td>
                                            <td class="auto-style8 text-right">
                                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click" Text="Submit" />
                                                <a href="~/Login.aspx" class="btn btn-primary" style=" width: 70px;" runat="server">Back</a>
                                            </td>
                                        </tr>
                                      
                                        </table>
                                <asp:ValidationSummary ID="ValidationSummary1" 
                                               runat="server"  ForeColor="Red" CssClass="error"/>
                                    </div>
                </div>
            </div>
            </div>

    
    </div>
    </form>
</body>
</html>
