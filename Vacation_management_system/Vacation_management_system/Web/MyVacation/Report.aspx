<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Vacation_management_system.Web.MyVacation.Report" %>
<%--<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
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
          }
        );
      
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

    </script>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wrapper">

        <div id="page-wrapper">

            <div class="container-fluid" style="background-color: white;">
                <!-- /.row -->

                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">Report
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="fa fa-file"></i>Report
                            </li>

                        </ol>
                    </div>
                </div>
                <!-- Page Heading End -->

                <!-- Report form body -->
          


            <div class="col-lg-12">
                <div class="row">
                    <div class="col-lg-6">
                        <div class="panel panel-default" style="float: left; width: 700px">
                           <%-- <div class="panel-heading">
                                <h2>REPORT</h2>
                            </div>--%>
                            <div class="panel-body">
               
                              
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <label class="control-label">From:</label>&nbsp;
                                        </td>
                                        <td> <asp:TextBox ID="txtFromDate"  name="From Date" placeholder="From Date" runat="server" Height="35px"></asp:TextBox>
                                                                                   <br />
                                 <br />
                                                                                   </td>
                                        <td> <label class="control-label">To:</label></td>
                                        <td><asp:TextBox ID="txtToDate"  name="To Date" placeholder="To Date" runat="server" Height="35px"></asp:TextBox>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><label class="control-label">Month:</label></td>
                                        <td><select id="month" runat="server" style="width:150px" placeholder="Month">
                                            <option></option>
                                            </select> 
                                            
                                            
                                            <br />
                                            
                                            <br />
                                            
                                        </td>
                                        <td><label id="name" class="control-label" runat="server">Employee Name:</label></td>
                                        <td>  <select id="drpName" runat="server" style="width:150px" placeholder="Name">
                                            <option></option>
                                              </select> </td>
                                    </tr>
                                    <tr>
                                        <td><label class="control-label">Employee Status:</label></td>
                                        <td><select id="drpEmployee"  runat="server" style="width:150px" multiple="true" placeholder="Employee Status">
                                            <option></option>
                                          <option value="1">Active</option>
                                          <option value="0">Inactive</option>
                                      </select><br />
                                            <br />
                                        </td>
                                        <td><label class="control-label">Leave Status:</label></td>
                                        <td> <select id="drpStatus" runat="server" style="width:150px" multiple="true" placeholder="Leave Status">
                                              <option></option>
                                             <option value="a">Approved</option>
                                         
                                     <option value="r">Rejected</option>
                                     <option value="c"> Cancel</option>
                                     <option value="p">Pending</option>
                                     <option value="x">Cancel pendding</option>
                                     <option value="i">Ideal</option>

                                 </select> </td>
                                    </tr>
                                    
                                </table>
                            </div>
                                 
          
                                           
                                            
                                            <asp:Button ID="btnView" CssClass="btn btn-primary btn-sm" runat="server" Text="View" OnClick="btnView_Click" Width="53px" />
                                           <asp:Button ID="btnclear" runat="server" OnClick="btnclear_Click" CssClass="btn btn-primary btn-sm" Text="Clear" Width="52px" />
                                        </div>
                                    
                                <!-- /.container-fluid -->

                            </div>
                            <!-- /#page-wrapper -->
                        </div>


                    </div>



                </div>
               <%-- <div class="col-lg-12" id="grid">
                    <%--<div class="panel panel-default" >--%>

               <div class="panel-heading">

                        <div class="panel-body form-group">

                            <div>
                                <asp:Label ID="lblEmpty" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                              <asp:GridView ID="grdview1" runat="server" AutoGenerateColumns="False" class="table table-bordered bg-danger" DataKeyNames="id" CellPadding="4" ForeColor="#333333" GridLines="None"
                                    OnPageIndexChanging="grdview1_PageIndexChanging" AllowPaging="true" PageSize="5">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" Visible="false" />
                                        <asp:BoundField DataField="first_name" HeaderText="Employee Name" SortExpression="first_name" />
                                        <asp:BoundField DataField="from_date" HeaderText="From Date" SortExpression="from_date" />
                                        <asp:BoundField DataField="to_date" HeaderText="To Date" SortExpression="to_date" />
                                        <asp:BoundField DataField="approval_status" HeaderText="Approval Status" SortExpression="Approval_Status" />
                                    </Columns>
                                    <EditRowStyle BackColor="#7C6F57" />
                                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
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

