<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/VMS.Master" CodeBehind="AddFamilyDetails.aspx.cs" Inherits="Vacation_management_system.Web.Employee.AddFamilyDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var specialKeys = new Array();
        //specialKeys.push(music); //Backspace
        $(function () {
            $(".numeric").bind("keypress", function (e) {
                var keyCode = e.which ? e.which : e.keyCode;
                var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
                $(".error").css("display", ret ? "none" : "inline");
                return ret;
            });
            $(".numeric").bind("paste", function (e) {
                return false;
            });
            $(".numeric").bind("drop", function (e) {
                return false;
            });
        });

        function checkAll(objRef) {
            var DataList = objRef.parentNode.parentNode.parentNode;
            var inputList = DataList.getElementsByTagName("input");
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

        $(function () {
            $('.alpha').keydown(function (e) {
                if (e.shiftKey || e.ctrlKey || e.altKey) {
                    e.preventDefault();
                } else {
                    var key = e.keyCode;
                    if (!((key == 8) || (key == 32) || (key == 46) || (key >= 35 && key <= 40) || (key >= 65 && key <= 90))) {
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
                        <h1 class="page-header">Family Details
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="fa fa-users"></i>User Management 
                            </li>
                            <li class="active">
                                <i class="glyphicon glyphicon-plus-sign"></i>Add Family
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
                                <table id="familytable" class="table table-hover" runat="server">
                                    <tr>
                                        <td>
                                            <label class="control-label"></label>
                                        </td>
                                        <td>
                                            <label class="control-label">Name:</label></td>
                                        <td>
                                            <label class="control-label">Relationship:</label></td>
                                        <td>
                                            <label class="control-label">Age:</label></td>
                                        <td>
                                            <label class="control-label">Dependency:</label>
                                        </td>
                                        <td>
                                            <label class="control-label"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label class="control-label"></label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="textname1" class="alpha form-control" name="Name" placeholder="Name" runat="server" /></td>
                                        <td>
                                            <asp:TextBox ID="textrelation1" class="alpha form-control" name="Relationship" placeholder="Relationship" runat="server" /></td>
                                        <td>
                                            <asp:TextBox ID="textage1" MaxLength="3" class="numeric form-control" name="Age" placeholder="Age" runat="server" /></td>
                                        <td>
                                            <asp:DropDownList class="form-control" ID="drdDependent1" runat="server">
                                                <asp:ListItem Value="D">Dependent</asp:ListItem>
                                                <asp:ListItem Value="I">Independent</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="Add" CssClass="btn btn-primary" /></td>
                                    </tr>
                                </table>

                                <div class="form-group">
                                    <div class="row">
                                        <div class="form-group form-inline" style="margin-left:15px;">
                                            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" OnClientClick="return confirm('Do you want to delete?')" Text="Delete" CssClass="btn btn-danger" />
                                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" CssClass="btn btn-primary" />
                                            </div>
                                        </div>

                                            <asp:GridView ID="gvDetails" runat="server" OnRowCommand="gvDetails_RowCommand" HeaderStyle-Font-Bold="true" ShowFooter="true"
                                                OnRowCancelingEdit="gvDetails_RowCancelingEdit"
                                                OnRowEditing="gvDetails_RowEditing"
                                                OnRowUpdating="gvDetails_RowUpdating" AutoGenerateColumns="False" class="table table-bordered bg-danger" DataKeyNames="id" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>

                                                    <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" Visible="false" />
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkRow" runat="server" onclick="Check_Click(this)" />
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="Label11" runat="server" Text='<%#Eval("id")%>' Visible="false" />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name" SortExpression="relation_name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("relation_name") %>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtName" CssClass="alpha form-control" runat="server" Text='<%#Eval("relation_name") %>' />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtRname" CssClass="alpha form-control" name="Name" placeholder="Name" runat="Server" />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Relationship" SortExpression="relationship">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRelation" runat="server" Text='<%#Eval("relationship") %>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtRelationship" CssClass="alpha form-control" runat="server" Text='<%#Eval("relationship") %>' />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtRelationship1" class="alpha form-control" name="Relationship" placeholder="Relationship" runat="server" />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Age" SortExpression="age">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAge" runat="server" Text='<%#Eval("age") %>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtAge" CssClass="numeric form-control" runat="server" Text='<%#Eval("age") %>' />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtAge1" class="numeric form-control" name="Age" placeholder="Age" runat="server" />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Dependency" SortExpression="Dependency">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDependent" runat="server" Text='<%#Eval("dependency") %>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList class="form-control" ID="drdDependent1" runat="server">
                                                                <asp:ListItem Value="">Select</asp:ListItem>
                                                                <asp:ListItem Value="D">Dependent</asp:ListItem>
                                                                <asp:ListItem Value="I">Independent</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:DropDownList class="form-control" ID="drdDependent2" runat="server">
                                                                <asp:ListItem Value="">Select</asp:ListItem>
                                                                <asp:ListItem Value="D">Dependent</asp:ListItem>
                                                                <asp:ListItem Value="I">Independent</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-primary" />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" CssClass="btn btn-primary" />
                                                            <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-primary" />
                                                        </EditItemTemplate>
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

