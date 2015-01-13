<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Vacation_management_system.Web.MyVacation.Report" %>

<%--<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
     
        <%--  
    function Radio_Click() {
            if (from.checked = true) {
                document.getElementById("<%=txtToDate.ClientID %>").disabled = false;
                document.getElementById("<%=txtFromDate.ClientID %>").disabled = false;
            }--%>
        <%-- else
            {
                //document.getElementById("<%=month.ClientID %>").disabled = false;
            }--%>
        
        <%--  function Radio1_Click() {
            else {

                rmonth.checked = true;
                document.getElementById("<%=month.ClientID %>").disabled = false;
            }
        }--%>

        $(document).ready(
              function () {
                  $("#Month").select2();
                  $('#<%= month.ClientID %>').select2();

                  $("#drpEmployee").select2();
                  $('#<%= drpEmployee.ClientID %>').select2();
                  $("#drpStatus").select2();
                  $('#<%= drpStatus.ClientID %>').select2();
                  $("#drpName").select2();
                  $('#<%= drpName.ClientID %>').select2();
                
                  $('#<%=drpLeavetype.ClientID %>').select2();
               
                  if (document.getElementById("monthRadio").checked) {
                      document.getElementById("rowhide").style.display = "block";
                      document.getElementById("fromdatehide").style.display = "none";
                      document.getElementById("todatehide").style.display = "none";
                      document.getElementById("monthhide").style.display = "block";
                      document.getElementById("<%=txtFromDate.ClientID %>").val = "";
                      document.getElementById("<%=txtToDate.ClientID %>").val = "";
                  

                  }
                  else
                      if (document.getElementById("daterangeRadio").checked)
                      {
                          document.getElementById("rowhide").style.display = "block";
                          document.getElementById("fromdatehide").style.display = "block";
                          document.getElementById("todatehide").style.display = "block";
                          document.getElementById("monthhide").style.display = "none";
                          document.getElementById('#<%= month.ClientID %>').innerText = "";
                         
                      }
              }
        );
        

        <%-- function validate() {
             $('#<%= btnView.ClientID %>').addClass('btn');
             if ($('#<%= txtFromDate.ClientID %>').val().length > 0)

             {
                $('#<%= btnView.ClientID %>').prop("disabled", false);
                $('#<%= btnView.ClientID %>').addClass('btn-primary');

                 <%--$('#<%= btnRole.ClientID %>').css('backgroundColor', 'blue');--%>
         <%--   }
            else {
                $('#<%= btnView.ClientID %>').prop("disabled", true);
                $('#<%= btnView.ClientID %>').removeClass('btn-primary');

            }
        }--%>

        $(function () {
            if (document.getElementById("<%=txtFromDate.ClientID %>").val) {
                document.getElementById("<%=txtToDate.ClientID %>").focus();

            }
        });
        $(function () {
            $("[id$=txtFromDate]").datepicker({
                format: 'dd/mm/yyyy',
                autoclose: true,
                todayHighlight: true
            });
        });
        $(function () {
            $("[id$=txtToDate]").datepicker({
                format: 'dd/mm/yyyy',
                autoclose: true,
                todayHighlight: true
            });
        });

        function daterange() {
            document.getElementById("rowhide").style.display = "block";
            document.getElementById("fromdatehide").style.display = "block";
            document.getElementById("todatehide").style.display = "block";
            document.getElementById("monthhide").style.display = "none";
            document.getElementById("monthRadio").checked = false;
            document.getElementById("daterangeRadio").checked = true;
         
            $("#<%= month.ClientID %>").select2("val","");

 
        }

        function month() {
            document.getElementById("rowhide").style.display = "block";
            document.getElementById("fromdatehide").style.display = "none";
            document.getElementById("todatehide").style.display = "none";
            document.getElementById("monthhide").style.display = "block";
            document.getElementById("daterangeRadio").checked = false;
            $('#<%= txtToDate.ClientID %>').val("");
            $('#<%= txtFromDate.ClientID %>').val("");
           
        }



        function hiderow() {
            document.getElementById("rowhide").style.display = "none";
        }
        function showcheckfordate() {

            document.getElementById("daterangeRadio").checked = true;

        }
       
        function Result() {

            document.getElementById("monthRadio").checked = true;

        }

       
            
        function pageLoad() {
            $("[id$=txtToDate]").datepicker({
                format: 'dd/mm/yyyy',
                autoclose: true,
                todayHighlight: true
            });

            $("[id$=txtFromDate]").datepicker({
                format: 'dd/mm/yyyy',
                autoclose: true,
                todayHighlight: true
            });
        }

        $(document).ready(function (e) {
            $('.click').click(function () {
                var res = true;

             
                    var fromDate = document.getElementById('<%=txtFromDate.ClientID%>').value;

                    var toDate = document.getElementById('<%=txtToDate.ClientID%>').value;
                if (fromDate !== "" || toDate != "")
                    {
                    if (fromDate != "" && toDate != "") {
                        res = true;
                    } else {
                        alert('Both from and todate is required');
                        res = false;
                    }
                }
                return res;
            });
         });

    </script>
    <style>
        th {
            text-align: center;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wrapper">

        <div id="page-wrapper">

            <div class="container-fluid" style="background-color: white;">
                <!-- /.row -->

                <!-- Page Heading -->
                <%-- <div class="row">
                    <div class="col-lg-12">--%>
                <h1 class="page-header">Report
                </h1>
                <ol class="breadcrumb">
                    <li>
                        <i class="fa fa-file"></i>Report
                    </li>

                </ol>
                <%-- </div>
                </div>--%>
                <!-- Page Heading End -->

                <!-- Report form body -->


                <div class="col-lg-12">

                    <div class="panel panel-default" id="panelhide" runat="server" style="width: 1070px;margin-left: -15px;">
                        <%--<div class="panel-heading">
                                <h2>Vacation-Report </h2>
                            </div>--%>

                        <div class="panel-body" >
                            <ol class="breadcrumb">
                                <li>
                                    <i class="fa fa-file"></i>Vacation Report
                                </li>

                            </ol>
                            <div class="panel-body">

                                <div id="emp" runat="server" class="row ">

                                    <div class="form-inline">

                                        <div class="col-md-6">
                                            <label class="col-md-4 control-label">Employee Name:</label>

                                            <div class="col-md-8">
                                                <select id="drpName" runat="server" placeholder="Employee name" style="width: 300px"  class="col-md-4">
                                                    <option></option>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <label class="col-md-4">Employee Status:</label>

                                            <div class="col-md-8">
                                                <select id="drpEmployee" runat="server" style="width: 300px" multiple="true" placeholder="Employee Status" class="col-md-4">
                                                    <option></option>
                                                    <option value="1">Active</option>
                                                    <option value="0">Inactive</option>
                                                </select>
                                            </div>
                                           
                                        </div>

                                    </div>
                                </div>
                                <%-- <--row end--%>
                                <div class="row" style="padding-top: 20px">
                                    <div class="col-md-6">
                                        <label class="col-md-4">Vacation Status:</label>

                                        <div class="col-md-8">
                                            <select id="drpStatus" runat="server" style="width: 300px" multiple="true" placeholder="Leave Status" class="col-md-4">
                                                <option></option>
                                                <option value="a">Approved</option>

                                                <option value="r">Rejected</option>
                                                <option value="c">Cancel</option>
                                                <option value="p">Pending</option>
                                                <option value="x">Cancel pendding</option>
                                                <option value="i">Ideal</option>

                                            </select>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <label class="col-md-4">Vacation Type</label>

                                        <div class="col-md-8">
                                            <select id="drpLeavetype" runat="server" style="width: 300px" multiple="true" placeholder="Vacation Type" class="col-md-4">
                                               
                                            </select>
                                        </div>
                                    </div>
                                </div>
                                <%-- <--row end--%>



                                <div class="row" style="padding-top: 20px">

                                    <div class="form-group">
                                        <div class="col-md-8">
                                            <div class="col-md-4">
                                                <input type="radio" class="montclear radio-inline"  onclick="daterange();" id="daterangeRadio" />
                                               <label class="control-label">Date range </label> 

                                            </div>
                                            <div class="col-md-4">
                                                <input type="radio" class="radio-inline" onclick="month();" id="monthRadio" />
                                               <label class="control-label">Month</label> 
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <%-- <--row end--%>

                                <div id="rowhide" class="row" style="padding-top: 20px">

                                    <div class="col-md-6">
                                        <div id="fromdatehide">
                                            <label class="col-md-4  control-label">From Date:</label>

                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtFromDate"  name="From Date" placeholder="From Date" CssClass="form-control" runat="server" Width="300px" />
                                            </div>
                                        </div>
                                        <div id="monthhide">
                                            <label class="col-md-4  control-label">Month:</label>

                                            <div class="col-md-8">
                                                <select id="month" runat="server" placeholder="Month" style="width: 300px">
                                               </select>
                                            </div>
                                        </div>
                                    </div>

                                    <div id="todatehide" class="col-md-6">
                                        <label class="col-md-4  control-label">To date</label>

                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtToDate" name="To Date" placeholder="To Date" CssClass="form-control" runat="server" Width="300px" />

                                        </div>
                                    </div>
                                </div>

                                <div class="row" style="margin-top: 20px;">
                                    <div class="form-group form-inline align-left" style="float: left;">

                                        <asp:Button ID="btnView" CssClass="click btn btn-primary " runat="server" Text="Generate" OnClick="btnView_Click" />
                                        <asp:Button ID="btnclear" CssClass="btn btn-primary " runat="server" Text="Clear" OnClick="btnclear_Click" />
                                     
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /.container-fluid -->
                </div>
            </div>
            <!-- /#page-wrapper -->

            <%--  <div class="col-lg-12" id="grid">
                    <div class="panel panel-default" >--%>
            <div id="panelhide1" runat="server">
                <div class="panel panel-default" style="width: 1070px;margin-left: 15px;">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            <asp:Label ID="No_of_records" runat="server"></asp:Label></h3>
                    </div>
                    <div class="panel-body">
                        <div>

                            <asp:GridView ID="grdview1" runat="server" AutoGenerateColumns="False" class="table table-bordered bg-danger" DataKeyNames="id" CellPadding="4" ForeColor="#333333" GridLines="None"
                                OnPageIndexChanging="grdview1_PageIndexChanging" AllowPaging="true" PageSize="10" EmptyDataText="No records found" ShowHeaderWhenEmpty="true">
                                <AlternatingRowStyle BackColor="White" />


                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" Visible="false" />
                                    <asp:BoundField DataField="first_name" HeaderText="Employee Name" SortExpression="first_name" />
                                    <asp:BoundField DataField="from_date" HeaderText="From Date" SortExpression="from_date" />
                                    <asp:BoundField DataField="to_date" HeaderText="To Date" SortExpression="to_date" />
                                    <asp:BoundField DataField="leave_type" HeaderText="Leave type" />
                                    <asp:BoundField DataField="approval_status" HeaderText="Approval Status" SortExpression="Approval_Status" />



                                </Columns>
                                <EmptyDataRowStyle BackColor="White" ForeColor="Red" />
                                <EditRowStyle BackColor="#7C6F57" />
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" BorderStyle="Solid" HorizontalAlign="Right" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" PageButtonCount="2" />
                                <PagerStyle BackColor="#1C5E55" ForeColor="White" HorizontalAlign="Right" CssClass="GridPager" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />

                            </asp:GridView>

                        </div>
                    </div>
                </div>

            </div>

        </div>
    </div>

    </div>
    </div>
</asp:Content>

