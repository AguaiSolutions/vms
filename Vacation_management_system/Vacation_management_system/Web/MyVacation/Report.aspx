<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Vacation_management_system.Web.MyVacation.Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
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

                                <div class="form-group form-inline">
                                    <label class="control-label">Month:</label>
                                    <asp:DropDownList ID="drpMonth" runat="server" class="form-control"></asp:DropDownList>
                                    <label class="control-label">Employee:</label>
                                    <asp:DropDownList class="form-control" ID="drpEmployee" runat="server">
                                        <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>

                                    </asp:DropDownList>
                                    <label class="control-label">Status:</label>
                                    <asp:DropDownList class="form-control" ID="drpStatus" runat="server">
                                        <asp:ListItem Text="Approved" Value="a"></asp:ListItem>
                                        <asp:ListItem Text="Rejected" Value="r"></asp:ListItem>
                                        <asp:ListItem Text="Cancel" Value="c"></asp:ListItem>
                                        <asp:ListItem Text="Cancel pendding" Value="x"></asp:ListItem>
                                        <asp:ListItem Text="Ideal" Value="i"></asp:ListItem>
                                        <asp:ListItem Text="Pending" Value="p"></asp:ListItem>
                                    </asp:DropDownList>
                                    <div>
                                        <br />

                                    </div>
                                    <div>
                                        <label class="control-label">From:</label>
                                        <asp:TextBox ID="txtFromDate" class="form-control" name="From Date" placeholder="From Date" runat="server" />
                                        <label class="control-label">To:</label>
                                        <asp:TextBox ID="txtToDate" class="form-control" name="To Date" placeholder="To Date" runat="server" />
                                        <div>
                                            <div>
                                                <br />
                                            </div>
                                            <asp:Button ID="btnView" CssClass="btn btn-primary" runat="server" Text="View" OnClick="btnView_Click" />
                                            <asp:Button ID="btnclear" CssClass="btn btn-primary" runat="server" Text="Clear" OnClick="btnclear_Click" />
                                            <%--  <button type="reset" class="btn btn-primary" OnClick="btnclear_Click"> clear </button>--%>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.container-fluid -->

                            </div>
                            <!-- /#page-wrapper -->
                        </div>


                    </div>



                </div>
                <div class="col-lg-12" id="grid">
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

