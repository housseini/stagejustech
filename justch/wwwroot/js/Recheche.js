

$(document).ready(function () {
    $('#info').hide()
    $('#infor').hide()
    
    //var model = [];
    $('#table_id').dataTable({
        "filter": true,
                "sort": false,
        
        "reverse": true,
    })
       


})

function rechargerlPATIENT() {

    $("#rechecher").modal('hide');
    var model = [];
    var datatable = $('#table_id').DataTable();
    if ($.fn.DataTable.isDataTable("#table_id")) {
        $('#table_id').DataTable().destroy();
    }
    $('#table_id').DataTable({
        "aaData": model,
        "sort": false,

        "reverse": true,
        "aoColumns":
            [
                { "data": "FirstName", "name": "FirstName", "autoWidth": true },
                { "data": "LastName", "name": " LastName", "autoWidth": true },
                { "data": "Cin", "name": "Cin ", "autoWidth": true },
                { "data": "Email", "name": "Email", "autoWidth": true },
                { "data": "Address", "name": "Address", "autoWidth": true },
                { "data": "Phone", "name": "Phone", "autoWidth": true },
                { "data": "Country", "name": "Country", "autoWidth": true },
                {
                    "data": "Id", "render": function (data) {
                        return '<td class="text - right">' + ' <div class="dropdown dropdown-action">' + '<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>' + '<div class="dropdown-menu dropdown-menu-right">' + '<a class="dropdown-item" href="/Patient/EditPatient/' + data + '"  onclick="edit(' + data + ')"><i class="fa fa - plus m - r - 5"  ></i> detaille</a>' + '	<a class="dropdown-item" href="#" data-toggle="modal" data-target="#delete_patient" onclick="addidtolocalstorage(' + data + ')"><i class="fa fa - trash - o m - r - 5"></i> Supprimer</a>' + '</div>' + '</div >' + '</td >'
                    }
                }

            ],
    });

    $.get("/Patient/GetPatients", function (resulta) {
            if (resulta.length > 0) {



                resulta.forEach(
                    function (item) {
                        var patient = { "FirstName": item.FirstName, "LastName": item.LastName, "Cin": item.Cin, "Email": item.Email, "Address": item.Address, "Phone": item.Phone, "Country": item.Country, 'Id': item.Id };

                        model.push(patient)


                    }

                )
                $('#table_id').dataTable().fnClearTable();
                $('#table_id').dataTable().fnAddData(model);


            }
            else {

                Swal.fire({

                    icon: 'error',
                    title: "aucune donnée trouver ",
                    showConfirmButton: false,
                    timer: 1500
                })
            }
        })


    

}

function recher() {

    $("#rechecher").modal('hide');
    var model = [];
    var datatable = $('#table_id').DataTable();
    if ($.fn.DataTable.isDataTable("#table_id")) {
        $('#table_id').DataTable().destroy();


    }
    $('#table_id').DataTable({
        "aaData": model,
        "aoColumns":
            [
                { "data": "FirstName", "name": "FirstName", "autoWidth": true },
                { "data": "LastName", "name": " LastName", "autoWidth": true },
                { "data": "Cin", "name": "Cin ", "autoWidth": true },
                { "data": "Email", "name": "Email", "autoWidth": true },
                { "data": "Address", "name": "Address", "autoWidth": true },
                { "data": "Phone", "name": "Phone", "autoWidth": true },
                { "data": "Country", "name": "Country", "autoWidth": true },
                {
                    "data": "Id", "render": function (data) {
                        return '<td class="text - right">' + ' <div class="dropdown dropdown-action">' + '<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>' + '<div class="dropdown-menu dropdown-menu-right">' + '<a class="dropdown-item" href="/Patient/EditPatient/' + data + '"  onclick="edit(' + data + ')"><i class="fa fa - plus m - r - 5"  ></i> detaille</a>' + '	<a class="dropdown-item" href="#" data-toggle="modal" data-target="#delete_patient" onclick="addidtolocalstorage(' + data + ')"><i class="fa fa - trash - o m - r - 5"></i> Supprimer</a>' + '</div>' + '</div >' + '</td >'
                    }
                }

            ],
    });
    if ($("#CIN").val() == '' && + $("#FirstName").val() == '' && + $("#LastName").val() == '' && $("#Phone").val() == '' && $("#Email").val() == '' && $("#Addedon").val() == '' && $("#Dataofbirth").val() == '') {
        $('#infor').show()
        $("#rechecher").modal('show')
    }
    else {
        $.post("/Patient/Adven", { CIN: $("#CIN").val(), FirstName: $("#FirstName").val(), LastName: $("#LastName").val(), Phone: $("#Phone").val(), Email: $("#Email").val(), Addedon: $("#Addedon").val(), State: $("#State").val(), Dataofbirth: $("#Dataofbirth").val(), nombre: $("#Palage").val() }, function (resulta) {
            if (resulta.length > 0) {
              
            

                resulta.forEach(
                    function (item) {
                        var patient = { "FirstName": item.FirstName, "LastName": item.LastName, "Cin": item.Cin, "Email": item.Email, "Address": item.Address, "Phone": item.Phone, "Country": item.Country, 'Id': item.Id };

                        model.push(patient)


                    }

                )
                $('#table_id').dataTable().fnClearTable();
                $('#table_id').dataTable().fnAddData(model);


            }
            else {

                Swal.fire({

                    icon: 'error',
                    title: "aucune donnée trouver ",
                    showConfirmButton: false,
                    timer: 1500
                })
            }
        })


    }
}




//}

    //$("#table_id").DataTable({
    //    "processing": true,
    //    "serverSide": true,
    //    "filter": true,
    //    "ajax": {
    //        "url": "/api/customer",
    //        "type": "POST",
    //        "datatype": "json"
    //    },
    //    "columnDefs": [{
    //        "targets": [0],
    //        "visible": false,
    //        "searchable": false
    //    }],
    //    "columns": [
    //        { "data": "id", "name": "Id", "autoWidth": true },
    //        { "data": "firstName", "name": "First Name", "autoWidth": true },
    //        { "data": "lastName", "name": "Last Name", "autoWidth": true },
    //        { "data": "contact", "name": "Country", "autoWidth": true },
    //        { "data": "email", "name": "Email", "autoWidth": true },
    //        { "data": "dateOfBirth", "name": "Date Of Birth", "autoWidth": true },
    //        {
    //            "render": function (data, row) {
    //                return "<a href='#' class='btn btn-danger' onclick=DeleteCustomer('" + row.id + "'); >Delete</a>";
    //            }
    //        },
    //    ]
    //});


/*    */
    //$.get("/Patient/Adven", { CIN: "" + $("#CIN").val(), FirstName: "" + $("#FirstName").val(), LastName: "" + $("#LastName").val(), Phone: "" + $("#Phone").val(), Email: "" + $("#Email").val(), Addedon: "" + $("#Addedon").val(), State: $("#State").val(), Dataofbirth: "" + $("#Dataofbirth").val()  }, function (result) {
/*      window.location.reload();*/
    //$('#table_id').DataTable({


    //});


    //if ($("#FisrtName").val() != "") {

    //    alert($("#FisrtName").val());

    //}
    //if ($("#FisrtName").val() != "" && $("#LastName").val() != "") {

    //}
    //if ($("#FisrtName").val() != "" && $("#LastName").val() != "" && $("#DateofBirth").val() != "") { }
    //if ($("#Cin").val() != "" && $("#LastName").val() != "" && $("#DateofBirth").val() != "") { }




//}