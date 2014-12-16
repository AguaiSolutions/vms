<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="Holidays.aspx.cs" Inherits="Vacation_management_system.Web.Holidays.Holidays" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(function () {
            $(".dates1").datepicker({
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

                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">Holidays
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="fa fa-picture-o"></i> Holidays
                            </li>
                            <li class="active">
                                <i class="fa fa-suitcase"></i> Holidays List
                            </li>
                        </ol>
                    </div>
                </div>

                <div class="panel panel-default" style="width: 750px;">
                    <div class="panel-heading">
                        <h3 class="panel-title"></h3>
                    </div>
                    <div class="panel-body">
                        <div class="btn-group form-group">
                            <asp:Button ID="btnAddHolidays" Text="Add Holidays" CssClass="btn btn-primary" runat="server" OnClick="btnAddHolidays_Click" />
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblEmpty" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>

                            <asp:GridView ID="gvHolidays" runat="server" OnRowCommand="gvHolidays_RowCommand" HeaderStyle-Font-Bold="true"
                                OnRowCancelingEdit="gvHolidays_RowCancelingEdit"
                                OnRowEditing="gvHolidays_RowEditing"
                                OnRowUpdating="gvHolidays_RowUpdating" AutoGenerateColumns="False" class="table table-bordered bg-danger" DataKeyNames="id" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>

                                    <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" Visible="false" />
                                    <asp:TemplateField HeaderText="Holiday Name" SortExpression="holiday_name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("holiday_name") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtName" CssClass="form-control" runat="server" Text='<%#Eval("holiday_name") %>' />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Holiday Date" SortExpression="holiday_date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate" runat="server" Text='<%#Eval("holiday_date") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtHolidayDate" CssClass="dates1 form-control" runat="server" Text='<%#Eval("holiday_date") %>' />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" CssClass="btn btn-primary" />
                                            <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-primary" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-primary" />
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID")%>' CommandName="Delete" OnClientClick="return confirm('Do you want to delete?')" Text="Delete" CssClass="btn btn-danger" />
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
                        <div class="btn-group form-group">
                            <asp:Button ID="btnAddHolidays1" Text="Add Holidays" CssClass="btn btn-primary" runat="server" OnClick="btnAddHolidays_Click" />
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
