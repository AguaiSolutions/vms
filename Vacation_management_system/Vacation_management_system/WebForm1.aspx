<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Vacation_management_system.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="Scripts/jquery-2.1.1.js"></script>

    <script src="Scripts/select2.js"></script>
    
    <link href="Content/css/select2.css" rel="stylesheet" />

    <script>
        $(document).ready(
            function ()
        {
                $("#drpName").select2();
        }
          );
    </script>
</head>
<body>
    <%--<form id="form1" runat="server">--%>
   

       <select id="drpName"  class="select2-active  select2-default" style="width:200px" runat="server" >
           <%--<option value="1">jan</option>
           <option value="2">feb</option>
           <option value="3">march</option>--%>
       </select>
   
    <%--</form>--%>
</body>
</html>
