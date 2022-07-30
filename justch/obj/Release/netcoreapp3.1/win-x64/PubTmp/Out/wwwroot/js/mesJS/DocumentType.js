$().ready(function () {
    $('#Codedocumenttype').hide();
    $('#nomdocumenttype').hide();

    $('#Code').on('keyup', function () {
        $('#Codedocumenttype').hide()
    })
    $('#NomDt').on('keyup', function () {
        $('#nomdocumenttype').hide()
    })


    $("#listemenu").empty()
    var menu = '<li class="menu-title">Main</li>' +
        '  <li >' +
        '   <a  href = "/DossierMedical/Index" ><i class="fa fa-folder"></i> <span>Dossiers</span></a > ' +
        '  </li>' +
        '     <li>' +
        '      <li   >' +
        '        <a  href="/Patient/Index"><i class="fa fa-user"></i> <span>Patients</span></a>' +
        '     </li>' +
        '     <li >' +
        '         <a href="/Appointment/Index"><i class="fa fa-calendar-check-o"></i> <span>Rendez-vous</span></a>' +
        '      </li>' +
        '     <li   >' +
        '          <a href="/Doctor/Index"><i class="fa fa-user"></i> <span>Medecins</span></a>' +
        '      </li>' +
        '    <li class="active">' +
        '       <a href="#"  data-toggle="dropdown" aria-expanded="false"> <i class="fa fa-cog"> <span> Parametre </span></i></a>' +
        '      <div class="dropdown-menu ">' +
        '             <a class="dropdown-item" href="/Room/Index"> Salles</a>' +
        '             <a class="dropdown-item" href="/TechnienEnbrylogiste/Index">Techniciens</a>' +
        '<a class="dropdown-item" href="/DocumentType/Index">Docment Type </a>' +
        '           <a class="dropdown-item" href="/MedicalAct/Index">ACTES MEDICALS</a> ' +
        '           <a class="dropdown-item" href="/Utilisateur/Index">Utilisateur</a> ' +
        '       </div> ' +
        '   </li>    ';

    $("#listemenu").append(menu)
    $.get("/DocumentType/Gets", function (re) {


     
        creertabledocumentype(re)

    })



    $("#cherchermedicalacte").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#mytabe tr ").filter(function () {
            console.log($(this).toggle($(this).text().toLowerCase().indexOf(value) > -1))
        });
    });

  


})

function creertabledocumentype(model) {
    if ($.fn.DataTable.isDataTable("#DocumentTypetablez")) {
        $('#DocumentTypetablez').DataTable().destroy();
    }

    $('#DocumentTypetablez').DataTable({
        "filter": true,
        "aaData": model,
        "aoColumns":
            [
                { "data": "Code", "name": "code", "autoWidth": true },
                { "data": "Label", "name": "label", "autoWidth": true },
               /* { "data": "fichier", "name": "Nom du fichier", "autoWidth": true },*/
                {  "data": "Code", "render": function (data) {
                    return '<td class="text-right">' +
                        '<a href="#ModalExplorerDOCUMENTYPE" onclick="voirmadalexplorerdocumenttype(\'' + data.toString() + '\')" class="btn btn btn-secondary btn-rounded "><i class="fa fa-eye"> </i>   Explorer  </a>' +

                        '<a href="#modifierdocumentTYPE" onclick="ModifierdOCUMENTYPE(\'' + data.toString() + '\')" class="btn btn btn-secondary btn-rounded "><i class="fa fa-pencil"> </i>   modifier  </a>' +
                        '<a href="#deleteDocumentType"  onclick="deletedOC(\'' + data + '\')" class="btn btn btn-danger btn-rounded "><i class="fa fa-trash"> </i>  supprimer  </a>  </td> ';
                       
                    }
                }

            ],

    });
}
function deletedOC(code) {
    sessionStorage.setItem('code', code)
    $("#deleteDocumentType").modal('show');
}
function fermer() {
    $("#deleteDocumentType").modal('hide');
}

function confirmationdelete() {

    $.get("/DocumentType/Delete", { code: sessionStorage.getItem('code') },
        function (re) {
            if (re.status) {
                Swal.fire({

                    icon: 'success',
                    title: re.message,
                    showConfirmButton: false,
                    timer: 1500
                })
                $.get("/DocumentType/Gets", function (re) {



                    creertabledocumentype(re)

                })
                $("#deleteDocumentType").modal('hide');

            }
            else {

                Swal.fire({

                    icon: 'error',
                    title: re.message,
                    showConfirmButton: false,
                    timer: 1500
                })



            };
        }

        
    )
}

function showmodaladdtypefile() {
   
    $("#ajouterdocumentTYPE").modal('show');
}
function addTypeDocument() {
    class DocumentType {
        Code;
        Label;
        constructor() {
            this.Label = $("#NomDt").val();
            this.Code = $("#Code").val();
        }
    }

    if ($("#Code").val() == "" || $("#NomDt").val() == "") {


        if ($("#Code").val() == "") {
            $('#Codedocumenttype').show();
        }
        if ($("#NomDt").val() == "") {
            $('#nomdocumenttype').show();
        }

    } else {
        $.post("/DossierMedical/AddDocummentType", { documment: new DocumentType() }, function (result) {

            if (result.status) {



                Swal.fire({

                    icon: 'success',
                    title: result.message,
                    showConfirmButton: false,
                    timer: 1500
                })
                $.get("/DocumentType/Gets", function (re) {



                    creertabledocumentype(re)

                })
                $("#ajouterdocumentTYPE").modal('hide');

            }
            else {

                Swal.fire({

                    icon: 'error',
                    title: result.message,
                    showConfirmButton: false,
                    timer: 1500
                })



            };
        }

        );
    };
}
function ModifieTypeDocument() {
    class DocumentType {
        Code;
        Label;
        constructor() {
            this.Label = $("#Nommodifier").val();
            this.Code = $("#Codemodifier").val();
        }
    }


    $.post("/DocumentType/ModifierDocummentType", { documment: new DocumentType(), code: sessionStorage.getItem('code') }, function (result) {

    if (result.status) {



        Swal.fire({

            icon: 'success',
            title: result.message,
            showConfirmButton: false,
            timer: 1500
        })
        $.get("/DocumentType/Gets", function (re) {



            creertabledocumentype(re)

        })
        $("#modifierdocumentTYPE").modal('hide');

    }
    else {

        Swal.fire({

            icon: 'error',
            title: result.message,
            showConfirmButton: false,
            timer: 1500
        })



    };
});
    }


function ModifierdOCUMENTYPE(daa) {
    sessionStorage.setItem('code', daa);
    $.get("/DocumentType/getByCode", { Code: daa }, function (t) {
     
        $("#inputmodifier").empty();
        $("#inputmodifier").append('<label for="inputPassword4">  Code <span>*</span></label><input type = "text" class="form-control" id = "Codemodifier" placeholder = "Code" value="' + t.Code + '" >')
        $("#inputmodifier1").empty();
        $("#inputmodifier1").append('<label for="inputPassword4">  Nom <span>*</span></label><input type = "text" class="form-control" id = "Nommodifier" placeholder = "Nom" value="' + t.Label + '" >')


    })

    $('#modifierdocumentTYPE').modal('show');
}
function voirmadalexplorerdocumenttype(data) {

  
    $.get("/DocumentType/GetsDOCUMENbyCode", { Code: data }, function (re) {
     

        $("#bodytableexporerdocumetyme").empty()
        for (i = 0; i < re.length; i++) {




            $("#bodytableexporerdocumetyme").append(' <tr> <td>' + re[i]['CodeDocumentType'] + '</td>  <td>  ' + re[i]['Name'] + '</td>    <td>' + re[i]['Description'] + '</td> <td> ' + re[i]['Path'] + '</td> </tr >')


   
        }

    })
    $("#ModalExplorerDOCUMENTYPE").modal('show')

}