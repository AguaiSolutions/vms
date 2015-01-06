<%@ Page Title="Employee Vacation" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="EmployeeVacation.aspx.cs" Inherits="Vacation_management_system.Web.EmployeeVacation.EmployeeVacation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function openModal() {
            $('#mModal').modal('show');
        }
    </script>

    <script type="text/javascript">
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                //Get the Cell To find out ColumnIndex
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {
                        inputList[i].checked = false;
                    }
                }
            }
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
                        <h1 class="page-header">Employee Vacation
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="fa fa-plane"></i> Vacations
                            </li>
                            <li class="active">
                                <i class="fa fa-taxi"></i> Employee Vacation
                            </li>
                        </ol>
                    </div>
                </div>
                <!-- Page Heading End -->

                <div class="row">
                    <div class="col-lg-12">

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                </h3>
                            </div>
                            <div class="panel-body">

                                <div class="form-group form-inline">
                                    <asp:Button ID="btnApprovevacation" CssClass="btn btn-primary" runat="server" Text="Approve Vacation" OnClick="btnApprove_Click" />

                                    <input type="button" id="btnRejectvacation" class="btn btn-primary" name="button" value="Reject Vacation" onclick="openModal();" />
                                </div>
                                <div>
                                    <asp:Label ID="lblEmpty" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                    <asp:Label ID="lblLeaves" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblemp_no" runat="server" Visible="False"></asp:Label>

                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" class="table table-bordered bg-danger"  OnRowDataBound="GridView1_RowDataBound"  DataKeyNames="id,emp_id" CellPadding="4" ForeColor="#333333" GridLines="None">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkRow" runat="server" onclick="Check_Click(this)" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" Visible="false" />
                                            <asp:BoundField DataField="emp_id" HeaderText="Employee ID" SortExpression="emp_id" Visible="false" />
                                            <asp:BoundField DataField="first_name" HeaderText="Employee Name" SortExpression="first_name" />
                                            <asp:BoundField DataField="type_id" HeaderText="Type" SortExpression="Type" />
                                            <asp:BoundField DataField="from_date" HeaderText="From Date" SortExpression="from_date" />
                                            <asp:BoundField DataField="to_date" HeaderText="To Date" SortExpression="to_date" />
                                            <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description" />
                                            <asp:BoundField DataField="approval_status" HeaderText="Approval Status" SortExpression="approval_status" Visible="True" />
                                            <asp:BoundField DataField="leaves" HeaderText="No of Days" SortExpression="leave" />
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
                                <div class="form-group form-inline" style="margin-top: 30px;">
                                    <asp:Button ID="btnApprovevacation1" CssClass="btn btn-primary" runat="server" Text="Approve Vacation" OnClick="btnApprove_Click" />

                                    <input type="button" id="btnRejectvacation1" class="btn btn-primary" name="button" value="Reject Vacation" onclick="openModal();" />
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

                <%--  modal for cancel vacation--%>
                <div class="modal modal-wide fade" id="mModal">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="col-lg-8">
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                        <h3 class="panel-title modal-title">please enter the reason</h3>
                                    </div>
                                    <div class="panel-body">

                                        <div class="center-block">

                                            <div class="form-group">

                                                <asp:TextBox ID="txtRejectreason" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCreason" ErrorMessage="This felid cant be null" ForeColor="Red"></asp:RequiredFieldValidator>
                                                --%>
                                            </div>
                                            <asp:Button ID="Button5" runat="server" OnClick="btnRejectReason_Click" CssClass="btn btn-primary" Font-Size="Large" Text="Reject Vacation" />&nbsp;&nbsp;
                                            <asp:Button ID="Button4" runat="server" CssClass="btn btn-primary" data-dismiss="modal" Font-Size="Large" Text="Back" />

                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /.modal-content -->

                </div>
                <!-- /.modal-dialog -->
            </div>
            <!-- /.modal -->

        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#wrapper -->

</asp:Content>



