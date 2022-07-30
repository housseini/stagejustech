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
        '           <a class="dropdown-item" href="/Automatisation/Index">Classification</a> ' +
        '       </div> ' +
        '   </li>    ';

    $("#listemenu").append(menu)

    

    if ($.fn.DataTable.isDataTable("#tableenbrologiste")) {
        $('#tableenbrologiste').DataTable().destroy();
    }
    $('#tableenbrologiste').DataTable({})


    $('#FirstName').on('keyup', function () {
        $('#dee').hide();
    })
    $('#LastName').on('keyup', function () {
        $('#dre').hide();
    })

    $('#dee').hide();
    $('#dre').hide();



})


function addmodalshow() {
    $('#addmodal').modal('show');
}

function addTECHNICIEN() {
    if ($('#FirstName').val() == '') {
        $('#dee').show();
    }   

    if ($('#LastName').val() == '') {
        $('#dre').show();
    }
    if ($('#LastName').val() == '' || $('#FirstName').val() == '') {
        
    }
    else {
        $.post('/TechnienEnbrylogiste/Add', { enbrylogiste: { 'Id': 0, 'Firsname': $('#FirstName').val(), 'LastName': $('#LastName').val() } }, function (result) {


            if (result.status) {
                Swal.fire({

                    icon: 'success',
                    title: result.message,
                    showConfirmButton: false,
                    timer: 1500
                })
                setTimeout(function () {
                    window.location.reload()
                }, 3000)


            }
            else {

                Swal.fire({

                    icon: 'error',
                    title: result.message,
                    showConfirmButton: false,
                    timer: 3000
                })



            };

        })
    }
}

function edited(Id) {
    sessionStorage.setItem('Id', Id)
    $.get("/TechnienEnbrylogiste/GetById", { id: Id }, function (re) {
        var st = '  <div class="modal-header p-1 mb-2 bg-primary text-white"><h3>   modifier technicien </h3><button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true" >&times;</span ></button ></div > <div class="modal-body">  <div class="form-row">  <div  class="form-group col-md-6">' +
            ' <label for="inputPassword4"   class="float-left" >  FirstName <span>*</span></label>   <input type="text" class="form-control" id="FirstName1" value="' + re.FirsName + '" > </div>' +
            '  <div class="form-group col-md-6"> <label for="inputAddress2"   class="float-left" >LastName </label>   <input type="text" class="form-control" id="LastName1"  value="' + re.LastName + '">     </div>    </div>    </div>';
        $('#modal-container').empty()
        $('#modal-container').append(st)

        $('#editmodal').modal('show')


    })



}

function modifierTECHNICIEN() {
    $('#editmodal').modal('hide')
    $.post('/TechnienEnbrylogiste/Update', { enbrylogiste: { 'Id': sessionStorage.getItem('Id'), 'Firsname': $('#FirstName1').val(), 'LastName': $('#LastName1').val() } }, function (result) {
        if (result.status) {
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })
            setTimeout(function () {
                window.location.reload()
            }, 3000)


        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })



        };
    })

  

}

function addtolocalsession(Id) {
    sessionStorage.setItem('Id', Id)
    $('#supprimermodal').modal('show');


}

function confirmationdelete() {
    $('#supprimermodal').modal('hide');
    $.get('/TechnienEnbrylogiste/Delete', { ID: sessionStorage.getItem('Id') }, function (result) {
        if (result.status) {
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })
            setTimeout(function () {
                window.location.reload()
            }, 3000)


        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })



        };
    })

}

function fermer(){
    $('#supprimermodal').modal('hide');
}



