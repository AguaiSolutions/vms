<%@ Page Title="My Vacation" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="MyVacation.aspx.cs" Inherits="Vacation_management_system.Web.MyVacation.MyVacation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function openModal() {
            $('#myModal').modal('show');
        }
    </script>
      
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <div id="wrapper">

            <div id="page-wrapper">

                <div class="container-fluid">
                    <!-- /.row -->
                      <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">My Vacation
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="glyphicon glyphicon-home"></i><a href="~/Web/Dashboard/Dashboard.aspx" runat="server">Dashboard</a>
                            </li>
                            <li class="active">
                                <i class="glyphicon glyphicon-plus-sign"></i>My Vacation
                            </li>
                        </ol>
                    </div>
                </div> <!-- Page Heading End -->

                    <div class="row">
                        <div class="col-lg-12">
                         
                            <div class="panel panel-default">
                                <div class="panel-heading">

                                    <div>
                                        <br />

                                        <asp:Label ID="lblEmpty" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>

                                        <asp:Label ID="lblRow_Id" runat="server" Visible="False"></asp:Label>

                                        <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" onrowcommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" class="table table-bordered bg-danger" DataKeyNames="id" CellPadding="4" ForeColor="#333333" GridLines="None">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" Visible="false" />
                                                <asp:BoundField DataField="from_date" HeaderText="From Date" SortExpression="from_date" />
                                                <asp:BoundField DataField="to_date" HeaderText="To Date" SortExpression="to_date" />
                                                <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description" />
                                                <asp:BoundField DataField="type_id" HeaderText="Type" SortExpression="Type" />
                                                <asp:BoundField DataField="approval_status" HeaderText="Approval Status" SortExpression="Approval_Status" />
                                                <asp:BoundField DataField="reason" HeaderText="Reason" SortExpression="Reason" />
                                                <asp:TemplateField>
                                                   <ItemTemplate>
                                                    <asp:button id="btncancel" runat="server"  CommandArgument='<%# Eval("ID")%>' text="Cancel" CssClass="btn btn-primary" OnClick="btncancel" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EditRowStyle BackColor="#7C6F57" />
                                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#E3EAEB" />
                                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                                        </asp:GridView>
                                        
                                    </div>
                                    <div class="btn-group form-inline">
                                        <asp:Button ID="btnapplyleave" Text="Apply Leave" OnClick="btnApplyLeave_Click" CssClass="btn btn-primary" runat="server" />
                                    </div>




                                </div>
                            </div>
                        </div>
                    </div>
                   
                  <%--  modal for cancel vacation--%>
                               <div class="modal modal-wide fade" id="myModal">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                    <div class="col-lg-8">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                <h3 class="panel-title modal-title">Vacation Cancel details</h3>
                            </div>
                            <div class="panel-body">
                                  
          <div class="center-block">
                                <div class="form-group">
                                <label>From date</label>
                              <asp:TextBox ID="txtCfromdate" runat="server"  ReadOnly="true" CssClass="form-control"></asp:TextBox>
                                </div>            
                           
                                
                                <div class="form-group">
                                <label>To date</label>
                              <asp:TextBox ID="txtCtodate" runat="server"  ReadOnly="true" CssClass="form-control" ></asp:TextBox>
                                </div>            
                           
                                
                                <div class="form-group">
                                <label>Leave type</label>
                              <asp:TextBox ID="txtCleavetype" runat="server"  ReadOnly="true" CssClass="form-control" ></asp:TextBox>
                                </div>            
                           
                                
                                <div class="form-group">
                                <label>Approval status</label>
                              <asp:TextBox ID="txtCapprover" runat="server"  ReadOnly="true" CssClass="form-control" ></asp:TextBox>
                                </div>            
                           
                                
                                <div class="form-group">
                                <label>Desription</label>
                              <asp:TextBox ID="txtCdesc" runat="server"  ReadOnly="true" CssClass="form-control" TextMode="MultiLine" ></asp:TextBox>
                                </div>            
                           
                                
                                <div class="form-group">
                                <label>Reason</label>
                              <asp:TextBox ID="txtCreason" runat="server" CssClass="form-control" TextMode="MultiLine" ></asp:TextBox>
                                </div>            
                            <asp:Button ID="Button2" runat="server" OnClick=" btnCancelReason_Click" CssClass="btn btn-primary" Width="80px" Font-Size="Large" Text="Cancel" />&nbsp;&nbsp;
                            <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" data-dismiss="modal" Width="80px" Font-Size="Large" Text="Back" />

                                </div>
                                 </div>
                            </div>
                        </div>
                    </div>
                            </div><!-- /.modal-content -->
                           
                        </div>
                        <!-- /.modal-dialog -->
                    </div>
                    <!-- /.modal -->



                </div>

            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /#wrapper -->


</asp:Content>


