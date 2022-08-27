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
        '          <a href="/STATISTIQUE/Index"><i class="fa fa-user"></i> <span>Statistique</span></a>' +
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



    $("#sauvegarde").on('submit', function (e) {
        e.preventDefault()
        AJOUTERSAUVEGARDE()
      
    })
    $("#sauvegardepro").on('submit', function (e) {
        e.preventDefault()
        AJOUTERSAUVEGARDEpro()

    })



    
})

function AJOUTERSAUVEGARDEpro() {


    $.post("/Database_Registre/ProgrammerBackup", { programmer: { id: 0, Name: $("#DATABASE1").val(), Date: $("#Date").val(), Heure: $("#Heure").val(), Add:""} }, function (re) {
        if (re.status) {

            Swal.fire({

                icon: 'success',
                title: re.message,
                showConfirmButton: false,
                timer: 1500
            })
            setTimeout(function () {

            }, 3000)


        }
        else {

            Swal.fire({

                icon: 'error',
                title: re.message,
                showConfirmButton: false,
                timer: 1500
            })
            setTimeout(function () {

            }, 3000)


        };

      

    })
}


function showmodaladdbackup() {
    $("#showmodaladdbackup").modal("show")
}
function showmodaladdProgrammee() {
    $("#showmodaladdProgrammee").modal("show")
}
function AJOUTERSAUVEGARDE() {
    $("#showmodaladdbackup").modal("hide")
    if ($("#DATABASE").val() == "ALL") {
        $.post("/Database_Registre/Add", { Cause: $("#Cause").val() }, function (re) {
            if (re.status) {

                Swal.fire({

                    icon: 'success',
                    title: re.message,
                    showConfirmButton: false,
                    timer: 1500
                })
                setTimeout(function () {

                }, 3000)


            }
            else {

                Swal.fire({

                    icon: 'error',
                    title: re.message,
                    showConfirmButton: false,
                    timer: 1500
                })
                setTimeout(function () {

                }, 3000)


            };

            window.location.reload();
            
        })

    } else {

        $.post("/Database_Registre/Add1", { CAUSEs: $("#Cause").val(), namedata: $("#DATABASE").val() }, function (re) {
            if (re.status) {

                Swal.fire({

                    icon: 'success',
                    title: re.message,
                    showConfirmButton: false,
                    timer: 1500
                })
                setTimeout(function () {

                }, 3000)


            }
            else {

                Swal.fire({

                    icon: 'error',
                    title: re.message,
                    showConfirmButton: false,
                    timer: 1500
                })
                setTimeout(function () {

                }, 3000)


            };

            window.location.reload();

        })

    }
}