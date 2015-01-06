<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="Vacation_management_system.Web.Employee.Roles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #role
        {
            padding-left:40px;
        }
        .auto-style3 {
            width: 82px;
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

         function openModal() {
             $('#myModalRole').modal('show');
         }

        
         
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="wrapper"  >

            <div id="page-wrapper">

                <div class="container-fluid"  style="background-color:white;">
                    <!-- /.row -->

                    <!-- Page Heading -->
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header"> Roles
                            </h1>
                            <ol class="breadcrumb">
                                <li>
                                <i class="fa fa-users"></i>User Management 
                               </li>
                                <li class="active">
                                    <i class="glyphicon glyphicon-lock"></i>   Roles
                            </li>
                            </ol>
                        </div>
                    </div>


                    <%--//row--%>
                     <div class="row">
                    <div class="col-lg-12">

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                </h3>
                            </div>
                            <div class="panel-body">
                            
                                 <table style="width: 78%; height: 56px; margin-left: 231px;">
                                         <tr >
                                             <td class="auto-style3" >Roles </td>
                                             
                                              <td><asp:DropDownList ID="drplist_Roles" runat="server"  OnSelectedIndexChanged="drplist_Roles_SelectedIndexChanged" CssClass="form-control"  AutoPostBack="true" Width="164px" Height="30px"></asp:DropDownList></td>
                                             <td class="text-right "><a href="#myModalRole"  data-toggle="modal"> Add New Role</a></td>
                                         </tr>
                                     </table>

                                

 <asp:GridView ID="gvmenu" runat="server" AutoGenerateColumns="False" DataKeyNames="id" CssClass="table table-bordered" OnRowDataBound="OnRowDataBound" >
    
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                 <asp:Label ID="lblName"  Text='<%# Bind("menu_name") %>' runat="server"></asp:Label>
          
                 <asp:Label ID="Label1"  Text='<%# Bind("id") %>' runat="server"  Visible="false" ></asp:Label>
        
                <asp:Label ID="Label2"  Text='<%# Bind("parent_id") %>' runat="server" Visible="false" ></asp:Label>
                 </ItemTemplate>
        </asp:TemplateField>
         
        <asp:TemplateField>
            <ItemTemplate>
                    <asp:GridView  ID="gvChildmenu" runat="server" CssClass="table table-bordered " AutoGenerateColumns="False" DataKeyNames="id" OnRowDataBound="gvchild_OnRowDataBound"  >
                     <Columns>
                             
                            <asp:BoundField ItemStyle-Width="150px" DataField="menu_name" HeaderText="child menu" />
                            <asp:TemplateField>
                           <ItemTemplate>
                          
                           <asp:Label ID="lblchk"  Text='<%# Bind("id") %>' runat="server" Visible="false" ></asp:Label>
                           <asp:CheckBox ID="chk_child_name" Width="50" Height="25" runat="server"  />
                           </ItemTemplate>
                           </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                   </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                 <ItemTemplate>
                <asp:CheckBox ID="chk_name"  Width="50" Height="25" runat="server" />
         </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    
</asp:GridView>

<asp:Button ID="Button1" CssClass="btn btn-primary"  runat="server" Text="Save"  OnClick="Button1_Click1" />


                               
                           
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
                                              <b>Role Name</b><br /><br />
                                               <asp:TextBox  ID="txtRole_Name" runat="server"  CssClass="form-control" ></asp:TextBox>
                                                
                                            </div>
                                            <asp:Button ID="btnRole" runat="server" OnClick=" btnAdd_Click"  Font-Size="Medium"  Height="30px" Text="Add"  Enabled="false"/>&nbsp;&nbsp;
                                            <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" data-dismiss="modal" Font-Size="Medium"  Height="30px" Text="Cancel" />

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
