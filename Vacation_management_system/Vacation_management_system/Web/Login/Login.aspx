<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vacation_management_system.Web.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"  >
    
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <title> Login </title>
  
    <style type="text/css">
        .controls {
            top: 0px;
            left: 0px;
            height: 143px;
        }
        .auto-style1 {
            height: 53px;
        }
        .auto-style2 {
            width: 402px;
            height: 130px;
        }
        .auto-style3 {
            width: 210px;
        }
        .auto-style4 {
            height: 53px;
            width: 210px;
        }
    </style>
   
    </head>
 
   
<body runat="server" style="background-color:white">
    

    <div class="container" >

            <form id="loginform" class="form-horizontal " method="POST" runat="server" style="align-self:auto"  >

                <div id="loginbox" style="margin-top: 90px;  top: -5px; left: 149px; width: 628px; height: 387px; background-color:lightblue" class="mainbox col-md-1 col-md-offset-1 col-sm-1 col-sm-offset-1">
                    <div >
                        <div class="panel-heading panel-primary" style="text-align: center">
                            <div class="panel-title"><b style="font-size: 18px; font-family: &quot;Arial Black&quot;; color: #000000"> 
                                <img class="auto-style2" src="../Images/Capture.PNG"  /> 
                                <br />
                                <br />VACATION MANAGMENT SYSTEM</b></div>
                            
                        </div>

                        <div style="margin-top: 10px;background-color:lightblue" class="form-group">

                            <table style="width:72%; margin-left:auto;margin-right:auto;background-color:lightblue; height: 180px;">
                                <tr>
                                    <td class="auto-style3">
                                        <asp:Label ID="lblusername" runat="server" Font-Bold="False" Font-Italic="False" Font-Size="Medium" Text="EMAIL ID / EMPLOYEE ID" ForeColor="Black"></asp:Label>
                                        :</td>
                                    <td>
                                        <asp:TextBox ID="txtUsername" runat="server" Height="28px" Width="219px"></asp:TextBox>
                                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="please enter valid username" ControlToValidate="txtUsername" EnableClientScript="False" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                        <br />
                                        <br />
                                    </td>
                                   
                                </tr>
                                <tr>
                                    <td class="auto-style3">
                                        <asp:Label ID="lblpassword" runat="server" Font-Bold="False" Font-Italic="False" Font-Size="Medium" ForeColor="Black" Text="PASSWORD:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" runat="server" Height="29px" TextMode="Password" Width="219px"></asp:TextBox>
                                        
                                        <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="please enter valid password" ControlToValidate="txtPassword" EnableClientScript="False" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                        <br />
                                    </td>
                                  
                                </tr>
                                
                                <tr>
                                    <td class="auto-style4">
                                        <asp:Button ID="butsignin" runat="server" Text="SIGN IN" CssClass=" btn-lg" Font-Bold="False" Font-Italic="False" Font-Size="Large" ForeColor="Black" background-color="black" OnClick="butsignin_Click" />
                                    </td>
                                    <td class="auto-style1">
                                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="Medium" ForeColor="Black">FORGOT PASSWORD</asp:LinkButton>
                                    </td>
                                                                  </tr>
                                                            </table>
                            <br />
                        </div>                     
</div>
                    </div>
                </form>
                </div>
        
      
    

   

              
</body>
</html>