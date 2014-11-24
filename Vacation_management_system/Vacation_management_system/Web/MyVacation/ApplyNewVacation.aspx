<%@ Page Title="Apply New Vacation" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="ApplyNewVacation.aspx.cs" Inherits="Vacation_management_system.Web.MyVacation.ApplyNewVacation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style5 {
            width: 290px;
            height: 100px;
        }
        .auto-style6 {
            width: 115px;
            height: 100px;
        }
        .auto-style9 {
            width: 290px;
            height: 113px;
        }
        .auto-style10 {
            width: 115px;
            height: 113px;
        }
        .auto-style11 {
            height: 113px;
            width: 451px;
        }
        .auto-style13 {
            width: 290px;
            height: 56px;
        }
        .auto-style14 {
            width: 115px;
            height: 56px;
        }
        .auto-style17 {
            width: 290px;
        }
        .auto-style18 {
            width: 115px;
        }
        .auto-style19 {
            width: 134px;
            height: 100px;
        }
        .auto-style21 {
            width: 134px;
            height: 56px;
        }
        .auto-style22 {
            width: 134px;
        }

        .btn {
  background-color: hsl(193, 32%, 49%) !important;
  background-repeat: repeat-x;
  filter: progid:DXImageTransform.Microsoft.gradient(startColorstr="#b8d3da", endColorstr="#5493a4");
  background-image: -khtml-gradient(linear, left top, left bottom, from(#b8d3da), to(#5493a4));
  background-image: -moz-linear-gradient(top, #b8d3da, #5493a4);
  background-image: -ms-linear-gradient(top, #b8d3da, #5493a4);
  background-image: -webkit-gradient(linear, left top, left bottom, color-stop(0%, #b8d3da), color-stop(100%, #5493a4));
  background-image: -webkit-linear-gradient(top, #b8d3da, #5493a4);
  background-image: -o-linear-gradient(top, #b8d3da, #5493a4);
  background-image: linear-gradient(#b8d3da, #5493a4);
  border-color: #5493a4 #5493a4 hsl(193, 32%, 41.5%);
  color: #333 !important;
  text-shadow: 0 1px 1px rgba(255, 255, 255, 0.49);
  -webkit-font-smoothing: antialiased;
}
        .auto-style23 {
            width: 451px;
            height: 100px;
        }
        .auto-style24 {
            width: 451px;
            height: 56px;
        }
        .auto-style25 {
            width: 451px;
        }
    .auto-style26 {
        width: 134px;
        height: 20px;
    }
    .auto-style27 {
        width: 290px;
        height: 20px;
    }
    .auto-style28 {
        width: 115px;
        height: 20px;
    }
    .auto-style29 {
        width: 451px;
        height: 20px;
    }
    .auto-style33 {
        width: 134px;
        height: 79px;
    }
    .auto-style34 {
        width: 290px;
        height: 79px;
    }
    .auto-style35 {
        width: 115px;
        height: 79px;
    }
    .auto-style36 {
        width: 451px;
        height: 79px;
    }
    .auto-style37 {
        width: 134px;
        height: 19px;
    }
    .auto-style38 {
        width: 290px;
        height: 19px;
    }
    .auto-style39 {
        width: 451px;
        height: 19px;
    }
    </style>
    <script type="text/javascript">
        $(function () {
            $("[id$=txtFromDate]").datepicker();
        });
        $(function () {
            $("[id$=txtToDate]").datepicker();
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
                        <h1 class="page-header">Apply New Vacation
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="glyphicon glyphicon-home"></i><a href="~/Web/Dashboard/Dashboard.aspx" runat="server">Dashboard</a>
                            </li>
                            <li class="active">
                                <i class="glyphicon glyphicon-plus-sign"></i>Apply New Vacation
                            </li>
                        </ol>
                    </div>
                </div> <!-- Page Heading End -->
                
                 <!-- Apply new vacation form body -->

                
                  <br />
                <table style="width: 80%; height: 250px; margin-left: 141px; margin-bottom: 0px;">
                    <tr>
                        <td class="auto-style33"> <label class=" control-label">Leave Type:</label></td>
                        <td class="auto-style34">
                            <asp:DropDownList ID="drpLeaveType" class=" form-control" runat="server" Height="47px" Width="195px">
                            </asp:DropDownList>
                        </td>
                        <td class="auto-style35"></td>
                        <td class="auto-style36">
                            </td>
                    </tr>
                    <tr>
                        <td class="auto-style26"> &nbsp;</td>
                        <td class="auto-style27">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpLeaveType" ErrorMessage="Please select leave type." ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                        <td class="auto-style28">&nbsp;</td>
                        <td class="auto-style29">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style33"> <label class=" control-label">From Date:</label></td>
                        <td class="auto-style34">
                            <asp:TextBox ID="txtFromDate"  runat="server" Height="29px" Width="196px"></asp:TextBox>
                        </td>
                        <td class="auto-style33"> <label class="control-label">To Date:</label></td>
                        <td class="auto-style36">
                            <asp:TextBox ID="txtToDate" runat="server" Height="29px" Width="196px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style37"> </td>
                        <td class="auto-style38">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFromDate" ErrorMessage="Enter from date" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                        <td class="auto-style37"> </td>
                        <td class="auto-style39">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtToDate" ErrorMessage="Enter To date" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style19"> <label class="control-label">Description:</label></td>
                        <td class="auto-style9">
                            <asp:TextBox ID="txtDescription" runat="server" Height="83px" TextMode="MultiLine" Width="275px"></asp:TextBox>
                        </td>
                        <td class="auto-style10">&nbsp;</td>
                        <td class="auto-style11">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style26"> </td>
                        <td class="auto-style27">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDescription" ErrorMessage="Enter Description" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                        <td class="auto-style28"></td>
                        <td class="auto-style29"></td>
                    </tr>
                    <tr>
                        <td class="auto-style21">
                            <asp:Label ID="Label1" runat="server" CssClass="control-label text" ><b>Approver</b></asp:Label>
                        </td>
                        <td class="auto-style13">
                            <asp:TextBox ID="txtApprover" runat="server" Height="29px" Width="196px"></asp:TextBox>
                        </td>
                        <td class="auto-style14">&nbsp;</td>
                        <td class="auto-style24"></td>
                    </tr>
                    <tr>
                        <td class="auto-style26">
                        </td>
                        <td class="auto-style27">
                            &nbsp;</td>
                        <td class="auto-style28"></td>
                        <td class="auto-style29"></td>
                    </tr>
                    <tr>
                        <td class="auto-style19"></td>
                        <td class="auto-style5">
                            <asp:Button ID="btnApply"  CssClass="btn btn-primary" runat="server" Height="38px" Text="Apply" Width="105px" />
                        </td>
                        <td class="auto-style6">
                            <asp:Button ID="btnClear" CssClass="btn btn-primary" runat="server" Height="38px" Text="Clear" Width="105px" />
                        </td>
                        <td class="auto-style23">
                            <asp:HyperLink ID="hyperlinkCancel" CssClass="btn" height="38px" Width="105px"  runat="server" NavigateUrl="~/Web/Dashboard/Dashboard.aspx">Cancel</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style22">&nbsp;</td>
                        <td class="auto-style17">&nbsp;</td>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style25">&nbsp;</td>
                    </tr>
                </table>


                  </div>
                <!-- /.container-fluid -->

            </div>
            <!-- /#page-wrapper -->

        </div>
        <!-- /#wrapper -->


</asp:Content>
