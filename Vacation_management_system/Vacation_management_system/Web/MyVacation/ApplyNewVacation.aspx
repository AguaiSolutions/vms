<%@ Page Title="Apply New Vacation" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="ApplyNewVacation.aspx.cs" Inherits="Vacation_management_system.Web.MyVacation.ApplyNewVacation" %>

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
        $(document).ready(function (e) {
            $('.click').click(function() {
                var res = false;

                var check = $('#chkrh').prop('checked');

                if ($('#<%= drpLeaveType.ClientID %>').val() == 1) {

                    var fromDate = document.getElementById('<%=txtFromDate.ClientID%>').value;

                    var toDate = document.getElementById('<%=txtToDate.ClientID%>').value;

                    if (fromDate != "" && toDate != "") {
                        
                        if (check) {

                            if (fromDate === toDate) {
                                res = true;
                            } else {
                                alert("Please enter same From and To Date to avail half day leave");
                            }
                        } else {
                            res = true;
                        }
                    } else {
                        alert("From Date and To Date can't be Empty");
                    }
                } else {
                    res = true;
                }

                return res;
            });
        });

        $(document).ready(function () {
            
            $('.type').change(function () {
                if ($('#<%= drpLeaveType.ClientID %>').val() == 1) {
                    document.getElementById("rhlist").style.display = "none";
                    document.getElementById("RhListHide").style.display = "none";
                    document.getElementById("hidedatedetials").style.display = "block";
                }
                else {
                    document.getElementById("hidedatedetials").style.display = "none";
                    document.getElementById("RhListHide").style.display = "block";
                    document.getElementById("rhlist").style.display = "block";
                }

            })
        })

        function hiderow() {
            document.getElementById("hidedatedetials").style.display = "none";
            document.getElementById("RhListHide").style.display = "block";
            document.getElementById("rhlist").style.display = "block";
        }
        function hiderhlist(){
            document.getElementById("rhlist").style.display = "none";
            document.getElementById("RhListHide").style.display = "none";
        }
    </script>

    <style type="text/css">
        .auto-style1 {
            width: 79px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wrapper">

        <div id="page-wrapper">

            <div class="container-fluid" style="background-color: white;">
                <!-- /.row -->

                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">Apply New Vacation
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="fa fa-plane"></i>Vacation Management
                            </li>
                            <li class="active">
                                <i class="glyphicon glyphicon-plus-sign"></i>Apply New Vacation
                            </li>
                        </ol>
                    </div>
                </div>
                <!-- Page Heading End -->

                <!-- Apply new vacation form body -->



                <div class="row">
                    <div class="col-lg-6">
                        <div class="panel panel-default" style="float: left; width: 550px;">
                            <div class="panel-heading">
                                <h3 class="panel-title"></h3>
                            </div>
                            <div class="panel-body">

                                <div class="form-group form-inline">
                                    <asp:Button ID="Button1" CssClass="click btn btn-primary" runat="server" Text="Apply" OnClick="btnApply_Click"/>

                                    <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Clear" OnClick="btnClear_Click" />

                                    <asp:HyperLink ID="hyperlink1" CssClass="btn btn-primary" runat="server" NavigateUrl="~/Web/MyVacation/MyVacation.aspx">Cancel</asp:HyperLink>
                                </div>
                                <div class="form-group">

                                    <asp:ValidationSummary CssClass="alert alert-danger" DisplayMode="List" ID="vldSummary" ForeColor="Black" runat="server" />

                                </div>
                                <div style="width: 500px;">
                                    <div class="form-group">
                                        <label class="control-label">Vacation Type:</label>
                                        <asp:DropDownList class="type form-control" ID="drpLeaveType" runat="server" >
                                        </asp:DropDownList>
                                    </div>

                                    <div id="hidedatedetials">
                                        <div class="form-group">
                                            <label class="control-label">From:</label>
                                            <asp:TextBox ID="txtFromDate" class="form-control" name="From Date" placeholder="From Date" runat="server" />
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label">To:</label>
                                            <asp:TextBox ID="txtToDate" class="form-control" name="To Date" placeholder="To Date" runat="server" />
                                        </div>
                                        &nbsp;<asp:Label ID="lblManager_Email" runat="server" Visible="False"></asp:Label>
                                        &nbsp;<asp:Label ID="lblManager_Id" runat="server" Visible="False"></asp:Label>

                                        <div class="form-group">
                                            <asp:CheckBox ID="chkrh" CssClass="checkbox-inline" ClientIDMode="Static" runat="server" Text="Half Day Leave"/>
                                        </div>
                                    </div>
                                    <div id="rhlist" class="form-group">

                                        <label class="control-label">List of RH:</label>
                                        <asp:DropDownList ID="ddlrh" class="form-control" runat="server"></asp:DropDownList>
                                        <asp:Label ID="lblrh" runat="server" ForeColor="red" Visible="False"></asp:Label>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label">Reason:</label>
                                        <asp:TextBox ID="txtReason" TextMode="MultiLine" MaxLength="50" class="form-control" name="Reason" placeholder="Reason" runat="server" />
                                    </div>


                                    <div class="form-group">
                                        <label class="control-label">Approver:</label>
                                        <asp:Label ID="lblApprover" runat="server" class="control-label"></asp:Label>
                                        <asp:TextBox ID="txtApprover" ReadOnly="true" class="form-control" name="Approver" runat="server" />
                                    </div>
                                </div>

                                <div class="form-group form-inline" style="margin-top: 30px;">
                                    <asp:Button ID="btnApply" CssClass="click btn btn-primary" runat="server" Text="Apply" OnClick="btnApply_Click"/> 

                                    <asp:Button ID="btnClear" CssClass="btn btn-primary" runat="server" Text="Clear" OnClick="btnClear_Click" />

                                    <asp:HyperLink ID="hyperlinkCancel" CssClass="btn btn-primary" runat="server" NavigateUrl="~/Web/MyVacation/MyVacation.aspx">Cancel</asp:HyperLink>
                                </div>

                                <div>
                                         <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtReason" ErrorMessage="please enter the Reason" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div id="RhListHide">
                     <div class="panel panel-default" style="float: right; width: 400px; margin-right: 100px;">
                        <div class="panel-heading">
                            <h3 class="panel-title">RH List</h3>
                        </div>
                        <div class="panel-body form-group">
                            <div>
                                <asp:Label ID="Label1" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" class="table table-bordered bg-danger" DataKeyNames="id" CellPadding="4" ForeColor="#333333" EmptyDataText="No records found" ShowHeaderWhenEmpty="true" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <%--<asp:BoundField DataField="id" HeaderText="id" SortExpression="id" Visible="false" />--%>
                                        <asp:BoundField DataField="holiday_name" HeaderText="Holiday Name"/>
                                        <asp:BoundField DataField="holiday_date" HeaderText="Holiday Date" SortExpression="holiday_date" />
                                        <%--<asp:BoundField DataField="approval_status" HeaderText="Approval Status" SortExpression="Approval_Status" />--%>
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
                        </div>
                    </div>
                    </div>
                   <%-- skfkjsdhf--%>

                    <div class="panel panel-default" style="float: right; width: 400px; margin-right: 100px;">
                        <div class="panel-heading">
                            <h3 class="panel-title">Vacation Summary</h3>
                        </div>
                        <div class="panel-body form-group">
                            <div>
                                <asp:Label ID="lblEmpty" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                <asp:GridView ID="gvVacation" runat="server" AutoGenerateColumns="False" class="table table-bordered bg-danger" DataKeyNames="id" CellPadding="4" ForeColor="#333333" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" Visible="false" />
                                        <asp:BoundField DataField="from_date" HeaderText="From Date" SortExpression="from_date" />
                                        <asp:BoundField DataField="to_date" HeaderText="To Date" SortExpression="to_date" />
                                        <asp:BoundField DataField="approval_status" HeaderText="Approval Status" SortExpression="Approval_Status" />
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
                        </div>
                    </div>



                </div>
            </div>
            <!-- /.container-fluid -->

        </div>
        <!-- /#page-wrapper -->

    </div>
    <!-- /#wrapper -->
</asp:Content>
