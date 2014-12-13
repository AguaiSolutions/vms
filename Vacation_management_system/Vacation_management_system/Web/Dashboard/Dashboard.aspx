<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Vacation_management_system.Web.Dashboard.Dashboard" %>

<%@ Register Src="~/Web/Common/BirthDay.ascx" TagPrefix="uc1" TagName="BirthDay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                    <asp:Image ID="img_profile_pic" Width="200" Height="200" runat="server" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblUsername" runat="server"></asp:Label>
                                    <asp:Label ID="lblBirthday" runat="server"></asp:Label>
                                    <br />
                                <div class="text-right">
                                    <a href="#">View Details <i class="fa fa-arrow-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
              
                     <!-- /.Birthday List -->
                  
                    <div class="col-lg-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title"><i class="fa fa-birthday-cake"></i> Birthday List</h3>
                            </div>
                            <div class="panel-body">
                                <uc1:BirthDay runat="server" ID="BirthDay" />
                                <div class="text-right">
                                    <a href="#">View Details <i class="fa fa-arrow-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
               </div>


                    <!-- /.row2 -->
                     
                   
                <div class="row">
                     <!-- /.Holiday List -->
                    <div class="col-lg-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title"><i class="fa fa-list"></i>  Holiday List</h3>
                            </div>
                            <div class="panel-body">
                                    <div class="text-right">
                                        <a href="#">
                                        <asp:Label ID="lblEmpty" runat="server"></asp:Label>
                                        <asp:GridView ID="grdHolidayList"  runat="server" BackColor="#DEBA84" class="table table-bordered  text-center" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                            <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                            <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                            <SortedDescendingHeaderStyle BackColor="#93451F" />
                                        </asp:GridView>
                                        View Details <i class="fa fa-arrow-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
              
                     <!-- /.Leave Information -->
                  
                    <div class="col-lg-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title"><i class="fa fa-plane"></i> Leave Information</h3>
                            </div>
                            <div class="panel-body">
                                    Lorem ipsum dolor sit amet
                               Consectetur adipiscing elit
                                 Integer molestie lorem at massa
                                Facilisis in pretium nisl aliquet
                                Nulla volutpat aliquam velit
                                Phasellus iaculis neque
                                 Lorem ipsum dolor sit amet
                               Consectetur adipiscing elit
                                 Integer molestie lorem at massa
                                Facilisis in pretium nisl aliquet
                                Nulla volutpat aliquam velit
                                Phasellus iaculis neque
                                <div class="text-right">
                                    <a href="#">View Details <i class="fa fa-arrow-circle-right"></i></a>
                                </div>
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
