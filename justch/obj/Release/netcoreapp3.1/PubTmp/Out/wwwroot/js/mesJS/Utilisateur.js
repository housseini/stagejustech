$().ready(function () {
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
        '     <li>' +
        '          <a href="/STATISTIQUE/Index"><i class="fa  fa-line-chart"></i> <span>Statistique</span></a>' +
        '      </li>' +
        '    <li class="active">' +
        '       <a href="#"  data-toggle="dropdown" aria-expanded="false"> <i class="fa fa-cog"> <span> Parametre </span></i></a>' +
        '      <div class="dropdown-menu ">' +
        '             <a class="dropdown-item" href="/Room/Index"> Salles</a>' +
        '             <a class="dropdown-item" href="/TechnienEnbrylogiste/Index">Techniciens</a>' +
        '<a class="dropdown-item" href="/DocumentType/Index">Docment Type </a>' +
        '           <a class="dropdown-item" href="/MedicalAct/Index">ACTES MEDICALS</a> ' +
        '           <a class="dropdown-item" href="/TraitementCycle/Index">TraitementCycle</a> ' +
        '           <a class="dropdown-item" href="/Incubateur_Chambre/Index">Incubateur/Chambre</a> ' +
        '            <a class="dropdown-item" href="/Cuve/Index">Cuve</a> ' +

        '           <a class="dropdown-item" href="/Utilisateur/Index">Utilisateur</a> ' +
        '      <a class="dropdown-item" href="/Database_Registre/Index">Sauvegarde</a> ' +

        '           <a class="dropdown-item" href="/Automatisation/Index">Classification</a> ' +
        '       </div> ' +
        '   </li>    ';

    $("#listemenu").append(menu)



    $("#a").hide()
    $("#dk").hide()
    $("#d").hide()

    $('#email').on('keyup', function () {
        $('#dk').hide()

    })

    $('#PASSWORD').on('keyup', function () {
        $('#d').hide()

    })

    $('#Username').on('keyup', function () {
        $('#a').hide()

    })

    chargeUser()


    
})

function addmodalshow() {
    $("#addmodal").modal("show")
}

function chargeUser() {
    model = []

    $.get("/Utilisateur/Gets", function (re) {
       
        createtableUtilisateur(re)
    })


}

function createtableUtilisateur(model) {
    if ($.fn.DataTable.isDataTable("#tableUser")) {
        $('#tableUser').DataTable().destroy();
    }

    $('#tableUser').DataTable({
        "filter": true,
        "aaData": model,
        "aoColumns":
            [

                { "data": "UserName", "name": "UserName", "autoWidth": true },
                { "data": "Email", "name": "EMAIL", "autoWidth": true },
                { "data": "Type", "name": "Role", "autoWidth": true },


                /* { "data": "fichier", "name": "Nom du fichier", "autoWidth": true },*/
                {
                    "data": "Id", "render": function (data) {
                        return '<td class="text - right">' +
                            ' <div class="dropdown dropdown-action">'
                            + '<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>' +
                            '<div class="dropdown-menu dropdown-menu-right">'
                             + '<a class="dropdown-item" href="#edite"'
                            + data + '"  onclick="edit(' + data + ')"><i class="fa fa - plus m - r - 5"  ></i> editer</a>'
                            + '	<a class="dropdown-item" href="#delete_utilisateur" data-toggle="modal" data-target="#delete_patient" onclick="addlocalstroendmodaldeleteshow(' + data + ')"><i  class="fa fa - trash - o m - r - 5"></i> Supprimer</a>'
                            + '</div>' + '</div >' + '</td >'
                    }
                }

            ],

    });

}



function addlocalstroendmodaldeleteshow(id) {
    sessionStorage.setItem("idutilisateur", id)

    $("#delete_utilisateur").modal('show')

}

function fermer() {


    $("#delete_utilisateur").modal('hide')
}


function confirmationdelete() {

    $.get("/Utilisateur/Delete", { Id: sessionStorage.getItem("idutilisateur") }, function (result) {

        if (result.status) {
            chargeUser()
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })
            setTimeout(function () {


            }, 2000)


        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })
            setTimeout(function () {

            }, 3000)


        };


        //window.location.reload()
        $("#delete_utilisateur").modal("hide")

    })

}
function edit(id) {
    sessionStorage.setItem("idutilisateur", id)

    $.get("/Utilisateur/GetbyId", { Id: id }, function (re) {

        console.log(re)
        $("#USERSE").append('<label for="inputPassword4" class="float-left">  Username </label><input type = "text" class= "form-control" id = "UsernameE" value = "' + re['UserName']+'" > ')
        $("#EMAILS").empty()
        $("#EMAILS").append('<label for="inputAddress2 " class="float-left">EMAIL </label><input type = "email" class= "form-control" id = "emailE" placeholder = "email" value = "' + re['Email'] +'" > ')
        $("#PASSS").empty()
        $("#PASSS").append('<label for="inputAddress2 " class="float-left">PASSWORD </label><input type = "password" class= "form-control" id = "PASSWORDE" required min = "8"  value = "' + re['Password'] + '">')
        $("#ROLEE").append('<option value="' + re['Type'] + '" selected> ' + re['Type'] + '</option>')
        

    })
    $("#USERSE").empty()



    $("#editmodal").modal('show')
}

function EditeUser() {
    $.post("/Utilisateur/Update", { utilisateur: { Id: sessionStorage.getItem("idutilisateur"), UserName: $("#UsernameE").val(), Email: $("#emailE").val(), Password: $("#PASSWORDE").val(), Type: $("#ROLEE").val() } }, function (result) {

        if (result.status) {
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })
            setTimeout(function () {

            }, 3000)


        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })
            setTimeout(function () {

            }, 3000)


        };
        window.location.reload()
        $("#editmodal").modal("hide")


    })
}

function addUser() {
    if ($("#Username").val() != "" && $("#EMAIL").val() != "" && $("#PASSWORD").val() != "") {


       
        $.post("/Utilisateur/Add", { utilisateur: { Id: 0, UserName: $("#Username").val(), Email:$("#email").val(), Password: $("#PASSWORD").val(), Type: $("#ROLE").val() } }, function (result) {

            console.log({ utilisateur: { Id: 0, UserName: $("#Username").val(), Email: $("#EMAIL").val() , Password: $("#PASSWORD").val(), Type: $("#ROLE").val() } })
            if (result.status) {
                chargeUser()
                Swal.fire({

                    icon: 'success',
                    title: result.message,
                    showConfirmButton: false,
                    timer: 1500
                })
                setTimeout(function () {
                  

                }, 2000)


            }
            else {

                Swal.fire({

                    icon: 'error',
                    title: result.message,
                    showConfirmButton: false,
                    timer: 1500
                })
                setTimeout(function () {

                }, 3000)


            };

       
            window.location.reload()
            $("#addmodal").modal("hide")

        })
    }


    if ($("#email").val() == "") { $("#dk").show() }
    if ($("#PASSWORD").val() == "") { $("#d").show() }
    if ($("#Username").val() == "") { $("#a").show() }
}