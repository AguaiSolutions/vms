<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="Holidays.aspx.cs" Inherits="Vacation_management_system.Web.Holidays.Holidays" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>

        $(function () {
            var nowDate = new Date();
            var today = new Date(nowDate.getFullYear(), nowDate.getMonth(), nowDate.getDate(), 0, 0, 0, 0);
            $('.date').datepicker({
                format: 'dd/mm/yyyy',
                startDate: today,
                autoclose: true,
                todayHighlight: true
            });
        });

        $(document).ready(function (e) {
            $('.delete').click(function () {
                var itemChk = $(".chkItem input:checkbox:checked");
                var chkd = false;

                itemChk.each(function () {
                    chkd = true;
                });


                if (!chkd) {
                    alert('Please Select a Holiday Record');
                    return false;
                }
                else {
                    if (confirm('Are you sure to delete selected records'))
                        return true;
                    else
                        return false;
                }
            });

            $(document).ready(function () {
                var headerChk = $(".chkHeader input");
                var itemChk = $(".chkItem input");

                headerChk.click(function () {
                    itemChk.each(function () {
                        this.checked = headerChk[0].checked;
                    })
                });

                itemChk.each(function () {
                    $(this).click(function () {
                        if (this.checked == false) { headerChk[0].checked = false; }
                    })
                });
            });

        });

        $(function () {
            $('.alpha').keydown(function (e) {
                if (e.altKey) {
                    e.preventDefault();
                } else {
                    var key = e.keyCode;
                    if (!((key == 8) || (key == 32) || (e.shiftKey) || (key == 9) || (key == 46) || (key >= 35 && key <= 40) || (key >= 65 && key <= 90))) {
                        e.preventDefault();
                    }
                }
            });
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
                        <h1 class="page-header">Holidays
                        </h1>
                        <ol class="breadcrumb">
                            <li class="active">
                                <i class="fa fa-picture-o"></i>Holidays
                            </li>
                        </ol>
                    </div>
                </div>
                <!-- Page Heading End -->

                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default" style="float: left;">
                            <div class="panel-heading">
                                <h3 class="panel-title"></h3>
                            </div>
                            <div class="panel-body form-group">

                                <asp:Label ID="lblEmpty4" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                <table id="holidaytable" class="table table-hover" runat="server">
                                    <tr>
                                        <td>
                                            <label class="control-label"></label>
                                        </td>
                                        <td>
                                            <label class="control-label">Holiday Name:</label></td>
                                        <td>
                                            <label class="control-label">Holiday Date:</label></td>
                                        <td>
                                            <label class="control-label"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label class="control-label"></label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtHname1" MaxLength="30" class="alpha form-control" name="Holiday Name" placeholder="Holiday Name" runat="server" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtHdate1" class="date form-control" name="Holiday Date" placeholder="Holiday Date" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="Add" CssClass="btn btn-primary" /></td>
                                    </tr>
                                </table>

                                <div class="form-group">
                                    <div class="form-group">
                                        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" CssClass="delete btn btn-danger" />
                                    </div>

                                    <asp:GridView ID="gvHolidays" ClientIDMode="Static" runat="server" OnRowCommand="gvHolidays_RowCommand" HeaderStyle-Font-Bold="true" ShowFooter="true"
                                        OnRowCancelingEdit="gvHolidays_RowCancelingEdit"
                                        OnRowEditing="gvHolidays_RowEditing"
                                        OnRowUpdating="gvHolidays_RowUpdating" AutoGenerateColumns="False" class="table table-bordered bg-danger" DataKeyNames="id" CellPadding="4" ForeColor="#333333" GridLines="None">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>

                                            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" Visible="false" />
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="checkAll" CssClass="chkHeader" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkRow" CssClass="chkItem" runat="server" />
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="Label11" runat="server" Text='<%#Eval("id")%>' Visible="false" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Holiday Name" SortExpression="holiday_name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("holiday_name") %>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtName" CssClass="alpha form-control" MaxLength="30" runat="server" Text='<%#Eval("holiday_name") %>' />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtHname3" CssClass="alpha form-control" MaxLength="30" name="Holiday Name" placeholder="Holiday name" runat="Server" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Holiday Date" SortExpression="holiday_date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDate" runat="server" Text='<%#Eval("holiday_date") %>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtHolidayDate" CssClass="date form-control" runat="server" Text='<%#Eval("holiday_date") %>' />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtHdate3" class="date form-control" name="Holiday Date" placeholder="Holiday Date" runat="server" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Is RH" SortExpression="isRH">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkRows" runat="server" ClientIDMode="Static"
                                                        Checked='<%# Convert.ToBoolean(Eval("isRH")) %>'
                                                        Text='<%# Eval("isRH").ToString().Equals("True") ? " " : " " %>' Enabled="false" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="chkRow1" runat="server"
                                                        Checked='<%# Convert.ToBoolean(Eval("isRH")) %>'
                                                        Text='<%# Eval("isRH").ToString().Equals("True") ? " " : " " %>' Enabled="true" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:CheckBox ID="chkRow2" runat="server" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <EditItemTemplate>
                                                    <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" CssClass="btn btn-primary" />
                                                    <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-primary" />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-primary" />
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Button ID="btnAdd" CommandName="Insert" runat="server" Text="Add" CssClass="btn btn-primary" />
                                                </FooterTemplate>
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

