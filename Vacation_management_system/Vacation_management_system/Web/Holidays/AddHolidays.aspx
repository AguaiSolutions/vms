<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="AddHolidays.aspx.cs" Inherits="Vacation_management_system.Web.Holidays.AddHolidays" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        $(function () {
            $("#txtDate").datepicker({
                format: 'dd/mm/yyyy',
                autoclose: true,
                todayHighlight: true
            });
        });

        function addRow() {

            var txtHolidayname = document.getElementById("txtHolidayname");
            var txtDate = document.getElementById("txtDate");
            var Delete = document.getElementById("Delete");
            var Add = document.getElementById("Add");
            var table = document.getElementById("myTableData");
            var rowCount = table.rows.length;
            var row = table.insertRow(rowCount);

            row.insertCell(0).innerHTML = '<input id="txtHolidayname1" runat="server" type="text" class="Holidayname1 form-control" value="" />';
            row.insertCell(1).innerHTML = '<input id="txtDate1" runat="server" type="text" class="dates1 form-control" value="" />';
            row.insertCell(2).innerHTML = '<button id="Delete" type="button" class="btn btn-mini btn-danger" onclick="Javacsript: deleteRow(this)" ><span class="glyphicon glyphicon-trash"></span></button>';
            row.insertCell(3).innerHTML = '<button id="Add" type="button" class="btn btn-mini btn-primary" onclick="Javascript: addRow()" ><span class="glyphicon glyphicon-plus"></span></button>';
            $(".dates1").datepicker({
                format: 'dd/mm/yyyy',
                autoclose: true,
                todayHighlight: true
            });
        }

        function GetValues() {

            var test = 0, x = [], name = [], a = [];
            $(".Holidayname1").each(function () {
                if ($(this).val() == "") {
                    test = 1;
                    alert("Holiday Name can not be null");
                }
            });
            $(".dates1").each(function () {
                if ($(this).val() == "") {
                    test = 1;
                    alert("Holiday Date can not be null");
                }
            });
            if (test == 0) {
                $(".Holidayname1").each(function () {
                    x.push($(this).val());
                });
                $(".dates1").each(function () {
                    name.push($(this).val());

                });
            }
           // for (var i = 0, j = 0; i < x.length, j < name.length; i++, j++) {

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: 'http://localhost:11485/Holidays.svc/InsertJson',
                    data: '{"HolidayName":"' + x + '","HolidayDate":"' + name + '"}',
                    dataType: "json",
                    processData: false,
                    success: function (data) {
                        if (data != null) {
                            alert("Holidays Inserted Successfully.")
                        }
                        else {
                            alert("Not inserted")
                        }

                    }
                });
            //}
        }

        function deleteRow(obj) {

            var index = obj.parentNode.parentNode.rowIndex;
            var table = document.getElementById("myTableData");
            table.deleteRow(index);

        }
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
                                <i class="fa fa-picture-o"></i>Holidays
                            </li>
                            <li class="active">
                                <i class="fa fa-plus"></i>Add Holidays
                            </li>
                        </ol>
                    </div>
                </div>

                <div class="panel panel-default" style="width: 500px;">
                    <div class="panel-heading">
                        <h3 class="panel-title"></h3>
                    </div>
                    <div class="panel-body">

                        <div class="form-group form-inline">
                            <input type="button" id="btnSave" class="btn btn-primary" value="Save" onclick="Javascript: GetValues()" />

                            <asp:Button ID="btnCancel" CssClass="btn btn-primary" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        </div>

                        <div id="mydata">

                            <table id="myTableData" class="form-group" border="1">
                                <tr>
                                    <td style="text-align: center">
                                        <label class="control-label">Holiday Name</label></td>
                                    <td style="text-align: center">
                                        <label class="control-label">Holiday Date</label></td>
                                    <td>
                                        <button id="Delete1" type="button" class="btn btn-mini btn-danger">
                                            <span class="glyphicon glyphicon-trash"></span>
                                        </button>
                                    </td>
                                    <td>
                                        <button id="Add1" type="button" class="btn btn-mini btn-primary" onclick="Javascript: addRow()">
                                            <span class="glyphicon glyphicon-plus"></span>
                                        </button>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <input id="txtHolidayname" type="text" class="Holidayname1 form-control" value="" /></td>
                                    <td>
                                        <input id="txtDate" type="text" class="dates1 form-control" value="" /></td>
                                    <td>
                                        <button id="Delete" type="button" class="btn btn-mini btn-danger" onclick="Javacsript: deleteRow(this)">
                                            <span class="glyphicon glyphicon-trash"></span>
                                        </button>
                                    </td>
                                    <td>
                                        <button id="Add" type="button" class="btn btn-mini btn-primary" onclick="Javascript: addRow()">
                                            <span class="glyphicon glyphicon-plus"></span>
                                        </button>
                                    </td>
                                </tr>
                            </table>


                        </div>

                        <div class="form-group form-inline">
                            <asp:Button ID="btnSave1" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnSave_Click" />

                            <asp:Button ID="btnCancel1" CssClass="btn btn-primary" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
