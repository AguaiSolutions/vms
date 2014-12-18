<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Vacation_management_system.Web.Dashboard.Dashboard" %>

<%@ Register Src="~/Web/Common/BirthDay.ascx" TagPrefix="uc1" TagName="BirthDay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style>
      #ContentPlaceHolder1_img_profile_pic
      {
          float:left;
      }
      #profile_information
      {
          margin-left: 165px;
          padding-bottom: 20px;
          line-height: 2;

      }
      th
      {
text-align:center;
      }

    #profile  a {
  float: left;
  position: relative;
}

#profile a img {
  display: block;
}

#profile a #eg {
  display: none;
  position: absolute;
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
  background: rgba(0,0,0,0.6);
  color: #ddd;
  padding: 20px;
}

#profile a:hover #eg{
  display: block;
}
    </style> 
      

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div id="wrapper"  >

            <div id="page-wrapper">

                <div class="container-fluid"  style="background-color:white;">
                    <!-- /.row -->

                    <!-- Page Heading -->
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">Dashboard 
                            </h1>
                            <ol class="breadcrumb">
                                <li class="active">
                                    <i class="glyphicon glyphicon-home"></i>    Dashboard
                            </li>
                            </ol>
                        </div>
                    </div>
                 
                    <!-- /.row1 -->

                <div class="row">
                     <!-- /.profile panel -->
                    <div class="col-lg-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title"><i class="fa fa-user"></i> Profile</h3>
                            </div>
                            
                            <div class="panel-body">
                                <div id="profile">
                                  <a href="#myModal"  data-toggle="modal">
                                   <asp:Image ID="img_profile_pic"  Width="140" Height="140" runat="server"  />
                                  <span id="eg">Change profile pic</span>
                                  </a>
                                  </div> 
                                   
                                 <div id="profile_information">
                                 
                                    <b><asp:Label ID="lblUsername" runat="server"></asp:Label></b><br />
                                    <asp:Label ID="lblEmpno" runat="server"></asp:Label>
                                     <asp:Label ID="lblEmail" runat="server"></asp:Label><br />
                                    <asp:Label ID="lblBirthday" runat="server"></asp:Label><br />
                                     <asp:Label ID="lblDOJ" runat="server"></asp:Label>
                                    
                                   </div>
                                <div class="text-right">
                                    <a href="~/web/Employee/PersonalDetails.aspx" runat="server">View more details <i class="fa fa-arrow-circle-right"></i></a>
                                </div>
                             </div>
                            </div>
                        </div>
                       
                     <!-- /.Birthday List -->
                  
                    <div class="col-lg-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title"><i class="fa fa-birthday-cake"></i>  <asp:Label ID="lblBirth" runat="server"></asp:Label></h3>
                            </div>
                            <div class="panel-body">
                                <uc1:BirthDay runat="server" ID="BirthDay" />
                                <div class="text-right">
                                    <a href="~/web/Holidays/Holidays.aspx" runat="server">View All <i class="fa fa-arrow-circle-right"></i></a>
                                    
                                </div>
                            </div>
                        </div>
                        </div>
                    </div>

                    <div class="row"> 
                      <%--  Vacation summary--%>
                    <div class="col-lg-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title"><i class="fa fa-plane"></i> Current year vacation summary</h3>
                            </div>
                            <div class="panel-body">
                               <asp:Label ID="lblTotalVaction" runat="server"></asp:Label><br />
                                    <asp:Label ID="lblPendingVaction" runat="server"></asp:Label><br />
                                <asp:Label ID="lblApprovedVaction" runat="server"></asp:Label><br />
                                    <asp:Label ID="lblCancelVaction" runat="server"></asp:Label><br />
                                <asp:Label ID="lblrejectedVaction" runat="server"></asp:Label><br />

                                <div class="text-right">
                                    <a href="~/web/MyVacation/MyVacation.aspx" runat="server">View Details <i class="fa fa-arrow-circle-right"></i></a>
                                </div>
                            </div>
                        </div>

                    </div>
              
                    
                     <%--   Holiday List--%>
                 <div class="col-lg-6">
                         <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title"><i class="fa fa-list"></i>  Holiday List</h3>
                            </div>
                            <div class="panel-body">
                                    <div class="text-right">
                                        <a href="#">
                                        <asp:Label ID="lblEmpty" runat="server"></asp:Label>
                                        <asp:GridView ID="grdHolidayList"  runat="server" class="table table-bordered  text-center " CellPadding="4" ForeColor="#333333" GridLines="None">
                                            <AlternatingRowStyle BackColor="White" />
                                            <EditRowStyle BackColor="#7C6F57" />
                                            <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True"  />
                                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"  />
                                            <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#666666" />
                                            <RowStyle BackColor="#E3EAEB"   />
                                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                                        </asp:GridView>
                                        View Details <i class="fa fa-arrow-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                     </div>

                    
               </div>


                      <%--  modal for image upload--%>
                <div class="modal modal-wide fade" id="myModal">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="col-lg-8">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h3 class="panel-title modal-title">Update Profile Picture</h3>
                                    </div>
                                    <div class="panel-body">

                                        <div class="center-block">


                                            <div class="form-group">
                                                 
                                                 <asp:FileUpload ID="empImage" runat="server" Style="width: 200px; height:20px" /><br />
                                            </div>
                                            <asp:Button ID="Button2" runat="server" OnClick=" btnUpload_Click" CssClass="btn btn-primary" Font-Size="Medium"  Height="30px" Text="Upload" />&nbsp;&nbsp;
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
