$().ready(function () {

    if ($.fn.DataTable.isDataTable("#tabledocteuqqr")) {
        $('#tabledocteuqqr').DataTable().destroy();
    }
    $('#tabledocteuqqr').DataTable({})


    $("#listemenu").empty()
    var menu = '<li class="menu-title">Main</li>' +
        '  <li >' +
        '   <a  href = "/DossierMedical/Index" ><i class="fa fa-folder"></i> <span>Dossiers</span></a > ' +
        '  </li>' +
        '     <li>' +
        '      <li   >' +
        '        <a  href="/Patient/Index"><i class="fa fa-user"></i> <span>Patients</span></a>' +
        '     </li>' +
        '     <li>' +
        '         <a href="/Appointment/Index"><i class="fa fa-calendar-check-o"></i> <span>Rendez-vous</span></a>' +
        '      </li>' +
        '     <li  class="active" >' +
        '          <a href="/Doctor/Index"><i class="fa fa-user"></i> <span>Medecins</span></a>' +
        '      </li>' +
        '    <li>' +
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
    $('#a').hide()
    $('#di').hide()
    
    $('#dk').hide()
    $('#dj').hide()
    $('#dij').hide()
    $('#dijk').hide()
    
})

function addmodalshow() {
    $('#addmodal').modal('show');
}
function showmodaldelle(id) {
    sessionStorage.setItem("id", id);
    ;
    $('#supprimermodal').modal('show');
}
function confirmationdelete() {


    $('#supprimermodal').modal('hide')
    $.get("/Doctor/Delete", { id: sessionStorage.getItem("id") }, function (result) {
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
                timer: 1500
            })
            setTimeout(function () {
                window.location.reload()
            }, 3000)


        };
    });

}


function showeditemodal(id) {
    $.get("/Doctor/GetBy", { Id: id }, function (resulat) {




        var str = ' <h3>   EDIT MEDECIN </h3>  <div class="form-row">' +
            '<div class="form-group col-md-4">' +
            ' <label for="inputPassword4">  FirstName <span>*</span></label> ' +
            '    <input type="text" class="form-control" id="FirstName1" value="' + resulat.FirstName + '"> ' +
            '   </div > ' +
            '<div class="form-group col-md-4" > ' +
            '  <label for="inputAddress2">LastName </label> ' +
            ' <input type="text" class="form-control" id="LastName1" value="' + resulat.LastName + '"> ' +
            '  </div>' +
            '  <div class="form-group col-md-4">' +
            '  <label for="inputAddress2">Speciality </label>  ' +
            '  <input type="text" class="form-control" id="Speciality1" value="' + resulat.Speciality + '"> ' +
            '  </div>' +
            '  <div class="form-group col-md-4">' +
            '  <label for="inputAddress2">Telephone </label>' +
            '  <input type="tel" class="form-control" id="Phone11" value="' + resulat.Phone1 + '"> ' +
            '  </div>' +
            ' <div class="form-group col-md-4">' +
            '  <label for="inputAddress2">Telephone 2 </label>' +
            '  <input type="tel" class="form-control" id="Phone21" value="' + resulat.Phone2 + '"> ' +
            '  </div>' +
            ' <div class="form-group col-md-4">' +
            '   <label for="inputAddress2">Email  </label>' +
            '   <input type="email" class="form-control" id="Email1" value="' + resulat.Email + '"> ' +
            ' </div>' +
            '  <div class="form-group col-md-4">' +
            '  <label for="inputAddress2">Adress  </label>' +
            '  <input type="text" class="form-control" id="Adress1" value="' + resulat.Adress + '"> ' +
            '  </div>' +

            ' <div class="form-group col-md-4">' +
            '    <label for="inputAddress2">Affiliation  </label>' +
            '  <input type="text" class="form-control" id="Affiliation1" value="' + resulat.Affiliation + '"> ' +
            '  </div>' +
            '   <div class="form-group col-md-4">' +
            '  <label for="inputAddress2">Type  </label>' +
            '  <input type="text" class="form-control" id="Type1" value="' + resulat.Type + '"> ' +
            '   </div>' +
            ' </div>' +
            ' <div class="mx-auto" style="width: 200px;">' +
            '<button type="button" class="btn btn-primary" onclick="Enregistrer(' + resulat.Id + ')"> Enregistrer  </button>' +
            '</div>'
            ;
        $('#modal-container').empty();
        $('#modal-container').append(str);
        $('#editmodal').modal('show');

    });





}






function addDooctor() {
    class Doctor {
        Id
        FirstName
        LastName
        Speciality
        Phone1
        Phone2
        Email
        Adress
        Affiliation
        Type
        constructor() {
            this.Id = 0;
            this.Adress = $("#Adress").val();
            this.Affiliation = $("#Affiliation").val();
            this.Type = $("#Type").val();
            this.Email = $("#Email").val();
            this.Phone2 = $("#Phone2").val();
            this.Phone1 = $("#Phone1").val();
            this.Speciality = $("#Speciality").val();
            this.LastName = $("#LastName").val();
            this.FirstName = $("#FirstName").val();


        }
    };
    if ($("#FirstName").val() != "" && $("#LastName").val() != "" && $("#Speciality").val() != "" && $("#Phone1").val() != "" && $("#Email").val() != "") {
        $.post("/Doctor/Add", { doctor: new Doctor() }, function (result) {

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
        });


    } else {
        if ($("#FirstName").val() == "") { $('#a').show() }
        if ($("#LastName").val() == "") { $('#dk').show() }
        if ($("#Speciality").val() == "") { $('#di').show() }
        if ($("#Phone1").val() == "") { $('#dij').show() }
        if ($("#Email").val() == "") { $('#dijk').show() }
        
       

    }
}
//function addDooctor() {
//    class Doctor {
//        Id
//        FirstName
//        LastName
//        Speciality
//        Phone1
//        Phone2
//        Email
//        Adress
//        Affiliation
//        Type
//        constructor() {
//            this.Id = 0;
//            this.Adress = $("#Adress").val();
//            this.Affiliation = $("#Affiliation").val();
//            this.Type = $("#Type").val();
//            this.Email = $("#Email").val();
//            this.Phone2 = $("#Phone2").val();
//            this.Phone1 = $("#Phone1").val();
//            this.Speciality = $("#Speciality").val();
//            this.LastName = $("#LastName").val();
//            this.FirstName = $("#FirstName").val();


//        }
//    };
//    if ($("#FirstName").val() != "" && $("#LastName").val() != "" && $("#Speciality").val() != "" && $("#Phone1").val() != "" && $("#Email").val() != "") {
//        $.post("/Doctor/Add", { doctor: new Doctor() }, function (resulta) {

//            window.location.reload();
//        });

//    }
//}
function Enregistrer(id) {
    $('#editmodal').modal('hide');
    class Doctor {
        Id
        FirstName
        LastName
        Speciality
        Phone1
        Phone2
        Email
        Adress
        Affiliation
        Type
        constructor() {
            this.Id = id;
            this.Adress = $("#Adress1").val();
            this.Affiliation = $("#Affiliation1").val();
            this.Type = $("#Type1").val();
            this.Email = $("#Email1").val();
            this.Phone2 = $("#Phone21").val();
            this.Phone1 = $("#Phone11").val();
            this.Speciality = $("#Speciality1").val();
            this.LastName = $("#LastName1").val();
            this.FirstName = $("#FirstName1").val();

        }


        
    };

    $.post("/Doctor/Update", { doctor: new Doctor() }, function (result) {
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
    });





  

}


function fermer() {
    $("#supprimermodal").modal('hide')
}