<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VMS.Master" AutoEventWireup="true" CodeBehind="Holidays.aspx.cs" Inherits="Vacation_management_system.Web.Holidays.Holidays" %>

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
                    name.push($(this).val());
                });
                $(".dates1").each(function () {
                    x.push($(this).val());

                });
            }
            for (var i = 0, j = 0; i < x.length, j < name.length; i++, j++) {
                a.push("{HolidayName: '"+name[i]+"',HolidayDate: '" + x[i] + "'}");
            }

            var obj = JSON.stringify(a);

            var hdnfldVariable = document.getElementById('<%=hdnfldVariable.ClientID%>');
            hdnfldVariable.value = obj;

            alert(a);

            //var jsonString = "{HolidayName: 'Fruits', HolidayDate: '2014-12-13'}";
            //var myObj = $.parseJSON(jsonString);
            //alert(myObj);

            var insertJson = "http://localhost:2046/Service/InsertJson";

            var GetAStudent = "http://localhost:2046/Service/GetAStudent";

            var holidays = {}

            holidays.Name = "Holiday";

            holidays.Date = "2014-12-13";

            var student = {}

            student.name = "Raghava";

            var obj = {}

            obj.holiday = holidays;

            obj.stud = student;

            var nextStudentID = 10;
            
            $.ajax({
                cache: false,
                type: "POST",
                async: false,
                url: insertJson,
                data:  JSON.stringify(obj),
                contentType: "application/json",
                dataType: "json",
                success: function(std) {
                    alert(std);
                    if (student===1) {
                        alert("Holidays Inserted Successfully.");
                    }
                    
                },
                error: function (xhr) {
                        alert(xhr.responseText);
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
                    
                    <asp:HiddenField ID="hdnfldVariable" runat="server" />

                    <div class="panel-body">

                        <div class="form-group form-inline">
                            <input type="button" id="btnSave" class="btn btn-primary" value="Save" onclick="Javascript: GetValues()" />

                            <asp:Button ID="btnCancel" CssClass="btn btn-primary" runat="server" Text="Cancel"/>
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
                            <asp:Button ID="btnSave1" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnSave1_OnClick"/>

                            <asp:Button ID="btnCancel1" CssClass="btn btn-primary" runat="server" Text="Cancel" OnClick="btnCancel1_OnClick"/>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
