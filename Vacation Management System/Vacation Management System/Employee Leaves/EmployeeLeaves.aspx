<%@ Page Title="EmployeeLeaves" Language="C#" MasterPageFile="~/Master/Aguai Master1.Master" AutoEventWireup="true" CodeBehind="EmployeeLeaves.aspx.cs" Inherits="Aguai_Leave_Management_System.EmployeeLeaves" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
    <section>
        
        <script type="text/javascript">
            $(function () {
                var date = new Date();
                var currentMonth = date.getMonth(); // current month
                var currentDate = date.getDate(); // current date
                var currentYear = date.getFullYear(); //this year
                $("#<%= txtFromDate.ClientID %>").datepicker({
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
              $("#<%= txtToDate.ClientID %>").datepicker({
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

        <div id="wrapper">

            <div id="page-wrapper">

                <div class="container-fluid">
                    <!-- /.row -->

                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">

                                   

                                    <a href="#searchModal" class="btn btn-lg btn-primary" data-toggle="modal">Search</a>
                                    <div>
                                        <br />

                                        <%--GridView For Leave Management Of All Employees--%>
                                           <asp:Label ID="lblResult" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>
                                           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" class="table table-bordered bg-danger" DataKeyNames="ID" BackColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="6">
                                            <Columns>
                                                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" Visible="false" />
                                                <asp:BoundField DataField="emp_id" HeaderText="Employee Number" SortExpression="Emp_Reg_No" />
                                                <asp:BoundField DataField="first_name" HeaderText="First Name" SortExpression="UserName" />
                                                <asp:BoundField DataField="from_date" HeaderText="From Date" SortExpression="From_date" />
                                                <asp:BoundField DataField="to_date" HeaderText="To Date" SortExpression="To_date" />
                                                <asp:BoundField DataField="description" HeaderText="Description" SortExpression="Description" />
                                                <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                                                <asp:BoundField DataField="approver" HeaderText="Approver" SortExpression="Approver" />
                                                <asp:BoundField DataField="approval_status" HeaderText="Approval Status" SortExpression="Approval_Status" />
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnApprove" class="btn btn-default btn-danger" runat="server" CommandArgument='<%# Eval("ID")%>' CommandName="Approve" Text="Approve" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnReject"  class="btn btn-default btn-danger" runat="server" CommandArgument='<%# Eval("ID")%>' CommandName="Reject" Text="Reject" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbtnCancel" class="btn btn-default btn-danger" runat="server" CommandArgument='<%# Eval("ID")%>' CommandName="Cancel" Text="Cancel" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                            </Columns>
                                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                            <RowStyle BackColor="White" ForeColor="#003399" />
                                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                            <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                            <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                            <SortedDescendingHeaderStyle BackColor="#002876" />
                                        </asp:GridView>

                                    </div>

                                   
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="panel-body">
                        <div id="morris-area-chart"></div>
                    </div>

                    <div class="modal modal-wide fade" id="myModal">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">

                                    <h1 class="modal-title">Vacation Reject</h1>
                                </div>
                                <div class="modal-body">
                                    <table style="width: 57%;">
                                        <tr>
                                            <td class="auto-style1">Reason:</td>
                                            <td class="auto-style2">
                                                <asp:TextBox ID="txtReason" runat="server" Height="65px" TextMode="MultiLine" Width="339px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>

                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnOk" runat="server" OnClick="btnReject_Click" CssClass="btnbtn-primary" Width="80px" Font-Size="Large" Text="Reject" />
                                    <asp:Button ID="btnCancel" runat="server" CssClass="btnbtn-primary" data-dismiss="modal" Width="80px" Font-Size="Large" Text="Cancel" />

                                </div>

                            </div>
                            <!-- /.modal-content -->
                        </div>
                        <!-- /.modal-dialog -->
                    </div>
                    <!-- /.modal -->

                    <!--/.modal for search-->
                  <div class="modal modal-wide fade" id="searchModal">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">

                                    <h1 class="modal-title">Employee vacation search</h1>
                                </div>
                                <div class="modal-body">
             <table style="width: 100%; margin-bottom: 7px;">
            <tr>
                <td class="auto-style1">First Name</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtFirst" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Employee Id</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtEmpId" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Leave Type</td>
                <td class="auto-style8">
                    
                    <asp:TextBox ID="txtLeaveType" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">From Date</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style7">&nbsp;Todate</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>


                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="Button3" runat="server" OnClick="btnSearch_Click" CssClass="btn btn-lg btn-primary" Width="80px" Font-Size="Large" Text="Search" />
                                    <asp:Button ID="Button4" runat="server" CssClass="btn btn-lg btn-primary" data-dismiss="modal" Width="80px" Font-Size="Large" Text="Cancel" />

                                </div>

                            </div>
                            <!-- /.modal-content -->
                        </div>
                        <!-- /.modal-dialog -->
                    </div>
                    <!-- /.modal -->

                </div>
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /#wrapper -->

       
    </section>

</asp:Content>
