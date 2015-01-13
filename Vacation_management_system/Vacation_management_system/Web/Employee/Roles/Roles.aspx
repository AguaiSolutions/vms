<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="Vacation_management_system.Web.Employee.Roles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #role {
            padding-left: 40px;
        }

        .auto-style3 {
            width: 82px;
        }


        .auto-style4 {
            width: 150px;
        }
    </style>
    <script>
        $(document).ready(function () {
            validate();
            $('#<%= txtRole_Name.ClientID %>').keyup(validate);


        });
     

        function validate() {

            $('#<%= btnRole.ClientID %>').addClass('btn');
            if ($('#<%= txtRole_Name.ClientID %>').val().length > 0) {
                $('#<%= btnRole.ClientID %>').prop("disabled", false);
                 $('#<%= btnRole.ClientID %>').addClass('btn-primary');

                 <%--$('#<%= btnRole.ClientID %>').css('backgroundColor', 'blue');--%>
             }
             else {
                 $('#<%= btnRole.ClientID %>').prop("disabled", true);
                 $('#<%= btnRole.ClientID %>').removeClass('btn-primary');

             }
        }

        $(document).ready(function () {

            $('#selectAll').click(function () {
                var isChecked = $(this).prop('checked');

                $('#<%= gvmenu.ClientID %> input:checkbox').each(function () {
                    $(this).prop('checked', isChecked);
                });

                $('#<%= gvmenu.ClientID %> tbody tr:eq(1) input[type=checkbox]').prop('checked', true);

            });

             $('.roles').click(function () {

                <%-- $('#<%= myInput.ClientID %>').val('true');--%>
                <%--$('#<%=lblhide.ClientID%>').html('1');--%>
                <%--document.getElementById('#<%=lblhide.ClientID%>').value = 'True';--%>
                var result = true;
                var x = $('#<%= gvmenu.ClientID %> tbody tr:eq(2) td:eq(1) tbody tr input[type=checkbox]:checked').size();

                var res = $('#<%= gvmenu.ClientID %> tbody tr:eq(2) input[type=checkbox]:checked').size();
                if (res != 0) {
                    if (res == x && x != 0) {
                        alert('please select User management menu');
                        result = false;
                    }
                    else if (x == 0) {
                        alert('please select atleast one Sub menu for User management');
                        result = false;
                    }
                }

                var x1 = $('#<%= gvmenu.ClientID %> tbody tr:eq(9) td:eq(1) tbody tr input[type=checkbox]:checked').size();
                var res1 = $('#<%= gvmenu.ClientID %> tbody tr:eq(9) input[type=checkbox]:checked').size();
                if (res1 != 0) {
                    if (res1 == x1 && x1 != 0) {
                        alert('please select vacation management menu');
                        result = false;
                    }

                    if (x1 == 0) {
                        alert('please select atleast one Sub menu for vacation management');
                        result = false;
                    }
                }

                return result;
            })
        })

        

        function openModal() {
            $('#myModalRole').modal('show');
        }

        function confirmation() {
            alert('Successfully updated');
            window.location = "Roles.aspx";
        }
        function clear() {
            window.location = "Roles.aspx";
        }

        $(document).ready(function() {
            $('.cancel').click(function() {
                $('#<%= txtRole_Name.ClientID %>').val('');
                var x = document.getElementById('<%=txtRole_Name.ClientID%>').value;
                if (x == "") {
                    $('#<%= btnRole.ClientID %>').prop("disabled", true);
                    $('#<%= btnRole.ClientID %>').removeClass('btn-primary');

                }
            });
        });

        function SelectheaderCheckboxes(headerchk) {
            
            var gvcheck = document.getElementById('gvmenu');
            var i;
            //Condition to check header checkbox selected or not if that is true checked all checkboxes
            if (headerchk.checked) {
                for (i = 0; i < gvcheck.rows.length; i++) {
                    var inputs = gvcheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = true;
                }
            }
                //if condition fails uncheck all checkboxes in gridview
            else {
                for (i = 0; i < gvcheck.rows.length; i++) {
                    var inputs = gvcheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = false;
                }
            }
        }
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
                        <h1 class="page-header">Roles
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="fa fa-users"></i>User Management 
                            </li>
                            <li class="active">
                                <i class="glyphicon glyphicon-lock"></i>Roles
                            </li>
                        </ol>
                    </div>
                </div>


                <%--//row--%>
                <div class="row">
                    <div class="col-lg-12">

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title"></h3>
                            </div>
                            <div class="panel-body">

                                <table style="width: 78%; height: 56px; margin-left: 231px;">
                                    <tr>
                                        <td class="auto-style3">Roles </td>

                                        <td class="auto-style4">
                                            <asp:DropDownList ID="drplist_Roles" runat="server" OnSelectedIndexChanged="drplist_Roles_SelectedIndexChanged" CssClass="form-control" AutoPostBack="true" Width="164px" Height="30px"></asp:DropDownList></td>
                                        <td class="text-left"><a href="#myModalRole" class="btn" data-toggle="modal"><i class="fa fa-plus fa-lg"></i></a></td>
                                    </tr>
                                </table>


                                <asp:GridView ID="gvmenu" runat="server" AutoGenerateColumns="False" DataKeyNames="id" CssClass="table table-bordered" OnRowDataBound="OnRowDataBound">

                                    <Columns>
                                        <asp:TemplateField HeaderText="Menu">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" Text='<%# Bind("menu_name") %>' runat="server"></asp:Label>

                                                <asp:Label ID="Label1" Text='<%# Bind("id") %>' runat="server" Visible="false"></asp:Label>

                                                <asp:Label ID="Label2" Text='<%# Bind("parent_id") %>' runat="server" Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Sub Menu">
                                            <ItemTemplate>
                                                <asp:GridView ID="gvChildmenu" runat="server" CssClass="table table-bordered " AutoGenerateColumns="False" DataKeyNames="id" OnRowDataBound="gvchild_OnRowDataBound">
                                                    <Columns>

                                                        <asp:BoundField ItemStyle-Width="150px" DataField="menu_name" HeaderText=" Name" />
                                                        <asp:TemplateField>
                                                            <ItemTemplate>

                                                                <asp:Label ID="lblchk" Text='<%# Bind("id") %>' runat="server" Visible="false"></asp:Label>
                                                                <asp:CheckBox ID="chk_child_name" Width="50" Height="25" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="selectAll" runat="server" ClientIDMode="Static" /> <%--OnCheckedChanged="CheckBox2_CheckedChanged"--%>
                                            </HeaderTemplate>
                                            <ItemTemplate>

                                                <asp:CheckBox ID="chk_name" Width="50" Height="25" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                </asp:GridView>

                                <asp:Button ID="Button1" CssClass="roles btn btn-primary" runat="server" Text="Save" OnClick="Button1_Click1" />
                                <button type="reset" title="Reset" class="btn btn-primary">Reset</button>




                            </div>
                        </div>

                    </div>
                </div>



                <%--  modal for adding new role--%>
                <div class="modal modal-wide fade" id="myModalRole">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="col-lg-8">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h3 class="panel-title modal-title">Add New Role</h3>
                                    </div>
                                    <div class="panel-body">

                                        <div class="center-block">


                                            <div class="form-group">
                                                <b>Role Name</b><br />
                                                <br />
                                                <asp:TextBox ID="txtRole_Name" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <asp:Button ID="btnRole" runat="server" OnClick="btnAdd_Click" Font-Size="Medium" Height="30px" Text="Add" Enabled="false" />&nbsp;&nbsp;
                                            <asp:Button ID="btnClear" runat="server" CssClass="cancel btn btn-primary" data-dismiss="modal" Font-Size="Medium" Height="30px" Text="Cancel" />

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
    <!-- /#page-wrapper -->

    </div>
        <!-- /#wrapper -->


</asp:Content>
