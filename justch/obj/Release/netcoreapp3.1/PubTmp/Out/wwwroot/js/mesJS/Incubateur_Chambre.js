$().ready(function () {
    $("#listemenu").empty()
    var menu = '<li class="menu-title">Main</li>' +
        '  <li >' +
        '   <a  href = "/DossierMedical/Index" ><i class="fa fa-folder"></i> <span>Dossiers</span></a > ' +
        '  </li>' +
        '     <li>' +
        '      <li  >' +
        '        <a  href="/Patient/Index"><i class="fa fa-user"></i> <span>Patients</span></a>' +
        '     </li>' +
        '     <li>' +
        '         <a href="/Appointment/Index"><i class="fa fa-calendar-check-o"></i> <span>Rendez-vous</span></a>' +
        '      </li>' +
        '     <li>' +
        '          <a href="/Doctor/Index"><i class="fa fa-user"></i> <span>Medecins</span></a>' +
        '      </li>' +
        '    <li   class="active">' +
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
        '           <a class="dropdown-item" href="/Automatisation/Index">Classification</a> ' +
        '       </div> ' +
        '   </li>    ';

    $("#listemenu").append(menu)



    creerINCUATEURTable()
    creerchambreTable()
    $("#ajouterIncubateur").on('submit', function (event) {
        ajouterIncubateurfo()
        event.preventDefault();
    })


    $("#ajouterchambre").on('submit', function (event) {
       ajouterchambrefo()
        event.preventDefault();
    })


    $("#modifierIncubateur").on('submit', function (event) {
        modifierIncubateurfo()
        event.preventDefault();
    })

    
    $("#modifierchambre").on('submit', function (event) {
        editechambre()
        event.preventDefault();
    })

})

function modifierIncubateurfo() {
    $.post("/Incubateur_Chambre/Update", {
        incubateur: {
            Id: sessionStorage.getItem("IdIncubateur"), NombreChambre: $("#nombrechambre1").val(), NomIncubateur: $("#NameIncubate1").val()

        }

    }, function (result) {

        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#modifiermodalIncubateurs").modal('hide');
            $("#modifierIncubateur").trigger("reset");
            creerINCUATEURTable()



        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })

        }

    })

}

function ajouterIncubateurfo() {
    $.post("/Incubateur_Chambre/Add", {
        incubateur: {
            Id: 0, NombreChambre: $("#nombrechambre").val(), NomIncubateur: $("#NameIncubate").val()
            
        }

    }, function (result) {

        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#ajoutermodalIncubateurs").modal('hide');
            $("#ajouterIncubateur").trigger("reset");
            creerINCUATEURTable()



        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })

        }

    })


}



function ajouterchambrefo() {
    $.post("/Incubateur_Chambre/AddCH", {
        chambre: {
            Id: 0, NomChambre: $("#Namechambre").val(), IdIncubateur: $("#IncubateurId").val()

        }

    }, function (result) {

        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#ajoutermodalchambre").modal('hide');
            $("#ajouterchambre").trigger("reset");
            creerchambreTable()



        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })

        }

    })

}

function creerchambreTable() {
    $.get("/Incubateur_Chambre/GetsChambre", function (re) {

        console.log(re)

        if ($.fn.DataTable.isDataTable("#chambreTable")) {
            $('#chambreTable').DataTable().destroy();
        }

        $("#chambreTablebody").empty()
        var model = re.reverse()
        for (var i = 0; i < model.length; i++) {

            $("#chambreTablebody").append('<tr>' +
                '<td>  ' + model[i]['NomChambre'] + '</td>' +
                '<td> ' + model[i]['IdIncubateur'] + ' </td>' +

                '<td class="text - right">'
                +
                ' <a  href="#modifiermodalchambre" class="btn btn-outline-primary" onclick="editermodcham(' + model[i]['Id'] + ')" ><i class="fa fa-pencil "></i>  </a>' +
                '<a  href="#supprimercHAMBREM" class="btn btn-outline-danger"  onclick="supprimermodacham(' + model[i]['Id'] + ')" ><i class="fa fa-trash "></i>  </a>' +
                '</td >' +
                '</tr>'
            )





        }

        $('#chambreTable').DataTable({
            "sort": false,
            "reverse": true,

        })


    })
}

function supprimermodacham(id) {
    sessionStorage.setItem("IdChambre", id)
    $("#supprimercHAMBREM").modal('show')
}
function editechambre() {
    $.post("/Incubateur_Chambre/Updatechambre", {
        chambre: {
            Id: sessionStorage.getItem("IdChambre"), NomChambre: $("#Namechambre1").val(), IdIncubateur: $("#IncubateurId1").val()

        }

    }, function (result) {

        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#modifiermodalchambre").modal('hide');
            $("#modifierchambre").trigger("reset");
            creerchambreTable()



        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })

        }

    })

}

function editermodcham(id) {
    sessionStorage.setItem("IdChambre", id)
    $.get("/Incubateur_Chambre/GetChambre", { Id: id }, function (re) {
        $("#Namechambre1").val(re.NomChambre);
        $("#IncubateurId1").val(re.IdIncubateur);

     
    })




    $("#modifiermodalchambre").modal('show')

}

function confirmesuppressionCHMA() {
    $.get("/Incubateur_Chambre/DeleteChambre", { Id: sessionStorage.getItem("IdChambre") }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#supprimercHAMBREM").modal('hide');
            creerchambreTable()



        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })

        }
    })

}
function showmodaladdIncubateurs() {

    $("#ajoutermodalIncubateurs").modal('show')

}


function showmodaladdCHAMBRE()
{
    $("#ajoutermodalchambre").modal('show')
}

function creerINCUATEURTable() {
    $.get("/Incubateur_Chambre/GETS", function (re) {
     


        if ($.fn.DataTable.isDataTable("#TableIncubateurs")) {
            $('#TableIncubateurs').DataTable().destroy();
        }

        $("#TableIncubateursBody").empty()
        var model = re.reverse()
        for (var i = 0; i < model.length; i++) {
 
            $("#TableIncubateursBody").append('<tr>' +
                '<td>  ' + model[i]['NomIncubateur'] + '</td>' +
                '<td> ' + model[i]['NombreChambre'] + ' </td>' +
                 
                    '<td class="text - right">'
                    +
                    ' <a  href="#modifiermodalIncubateurs" class="btn btn-outline-primary" onclick="editermodalIN(' + model[i]['Id'] + ')" ><i class="fa fa-pencil "></i>  </a>' +
                    '<a  href="#supprimerIncubateurM" class="btn btn-outline-danger"  onclick="supprimermodalIN(' + model[i]['Id'] + ')" ><i class="fa fa-trash "></i>  </a>' +
                    '</td >' +
                    '</tr>'
            )

            $("#IncubateurId").append('<option value="' + model[i]['Id'] + '">' + model[i]['NomIncubateur']+'</option>')
            $("#IncubateurId1").append('<option value="' + model[i]['Id'] + '">' + model[i]['NomIncubateur'] + '</option>')


        }

        $('#TableIncubateurs').DataTable({
            "sort": false,
            "reverse": true,

        })


    })
}

function confirmesuppressionIN() {
    $.get("/Incubateur_Chambre/Delete", { Id: sessionStorage.getItem("IdIncubateur") }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#supprimerIncubateurM").modal('hide');
            creerINCUATEURTable()



        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })

        }
    })
}

function supprimermodalIN(id) {
    sessionStorage.setItem("IdIncubateur", id)
    $("#supprimerIncubateurM").modal('show')
}

function editermodalIN(id) {
    sessionStorage.setItem("IdIncubateur", id)

    $.get("/Incubateur_Chambre/Get", { Id: id }, function (re) {
        $("#NameIncubate1").val(re.NomIncubateur);
        $("#nombrechambre1").val(re.NombreChambre);
  
        $("#modifiermodalIncubateurs").modal('show')
    })

}