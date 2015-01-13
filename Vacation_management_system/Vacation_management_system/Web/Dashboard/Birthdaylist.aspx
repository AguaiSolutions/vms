<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="Birthdaylist.aspx.cs" Inherits="Vacation_management_system.Web.Dashboard.Birthdaylist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        th{
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div id="wrapper">

        <div id="page-wrapper">

            <div class="container-fluid" style="background-color: white;">
                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">Birthday List
                        </h1>
                             <ol class="breadcrumb">
                                  <li>
                                <i class="fa fa-birthday-cake"></i> Birthday List
                            </li>
                           
                                 </ol>
                       
                        </div>
                     
                    </div>
              <div>
                      <div class="panel panel-default" style="width:500PX">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                </h3>
                            </div>
                            <div class="panel-body" >
                 <asp:GridView ID="grdbirthday" runat="server" CellPadding="4"  class="table table-bordered bg-danger text-center " ForeColor="#333333">
                            <AlternatingRowStyle BackColor="White"  />
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"  />
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
</asp:Content>
