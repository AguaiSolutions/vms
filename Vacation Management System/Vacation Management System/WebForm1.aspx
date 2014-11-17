<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Aguai_Leave_Management_System.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     
      <script type="text/javascript">
          $(function () {
              var date = new Date();
              var currentMonth = date.getMonth(); // current month
              var currentDate = date.getDate(); // current date
              var currentYear = date.getFullYear(); //this year
              $("#<%= TextBox4.ClientID %>").datepicker({
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
                            $("#<%= TextBox5.ClientID %>").datepicker({
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
    <style type="text/css">
        .auto-style1 {
            width: 111px;
        }
        .auto-style3 {
            width: 111px;
            height: 60px;
        }
        .auto-style5 {
            height: 60px;
        }
        .auto-style6 {
            width: 123px;
        }
        .auto-style7 {
            height: 60px;
            width: 123px;
        }
        .auto-style8 {
            height: 60px;
            width: 155px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;first name<br />
        <br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        emp id<br />
        <br />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
&nbsp;leave type<br />
        <br />
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
&nbsp;from date <asp:TextBox ID="TextBox5" runat="server" OnTextChanged="TextBox5_TextChanged"></asp:TextBox>
&nbsp;todate<br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <table style="width: 100%; margin-bottom: 7px;">
            <tr>
                <td class="auto-style1">First Name</td>
                <td class="auto-style8">
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Employee Id</td>
                <td class="auto-style8">
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Leave Type</td>
                <td class="auto-style8">
                    
                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">From Date</td>
                <td class="auto-style8">
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style7">Todate</td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
