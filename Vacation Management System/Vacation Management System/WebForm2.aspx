<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Aguai Master1.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Aguai_Leave_Management_System.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
<%--    
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
&nbsp;from date<asp:TextBox ID="TextBox5" runat="server" OnTextChanged="TextBox5_TextChanged"></asp:TextBox>
&nbsp;todate<br />
        <br />--%>



    
                    <div class="modal modal-wide fade" id="searchModal">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">

                                    <h1 class="modal-title">Leave Reject</h1>
                                </div>
                                <div class="modal-body">
                                    <table style="width: 57%;">
                                        <tr>
                                            <td class="auto-style1">First Name:</td>
                                            <td class="auto-style2">
                                                <asp:TextBox ID="TextBox6" runat="server" Height="65px"  Width="339px"></asp:TextBox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">Employee Id:</td>
                                            <td class="auto-style2">
                                                <asp:TextBox ID="TextBox7" runat="server" Height="65px"  Width="339px"></asp:TextBox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">Leave Type:</td>
                                            <td class="auto-style2">
                                                <asp:TextBox ID="TextBox8" runat="server" Height="65px"  Width="339px"></asp:TextBox>

                                            </td>
                                        </tr>

                                        <tr class="col-md-6">
                                            <td class="auto-style1">From Date:</td>
                                            <td class="auto-style2">
                                                <asp:TextBox ID="TextBox9" runat="server" Height="65px"  Width="339px"></asp:TextBox>

                                            </td>
                                            <td class="auto-style1">To Date:</td>
                                            <td class="auto-style2">
                                                <asp:TextBox ID="TextBox10" runat="server" Height="65px"  Width="339px"></asp:TextBox>

                                            </td>
                                        </tr>
                                    </table>

                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="Button2" runat="server" OnClick="btnReject_Click" CssClass="btnbtn-primary" Width="80px" Font-Size="Large" Text="Reject" />
                                    <asp:Button ID="Button3" runat="server" CssClass="btnbtn-primary" data-dismiss="modal" Width="80px" Font-Size="Large" Text="Cancel" />

                                </div>
            </div><!-- /.modal-content -->
            </div><!-- /.modal-dialog -->
            </div><!-- /.modal -->

</asp:Content>
