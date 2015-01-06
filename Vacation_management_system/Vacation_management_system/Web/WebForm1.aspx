<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Vacation_management_system.Web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    


    <script type="text/javascript">
        function confirmation() {
            var answer = confirm('Are you sure you want Deactivate the employee')
            if (answer) {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                //window.location = "http://www.google.com/";
            }
            else {
                alert("Thanks for sticking around!")
            }
        }
</script>
   
</head>
<body>
    <form id="form1" runat="server">
    <asp:Button ID="btnInactive" runat="server"  Text="deactive" OnClientClick="confirmation()" />
    </form>
</body>
</html>
