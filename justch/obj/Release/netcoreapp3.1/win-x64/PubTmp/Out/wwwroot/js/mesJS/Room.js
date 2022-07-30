$(document).ready(function () {




    rechargeRoomtype();
   




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





}
)

function rechargeRoomtype() {
    modelRoomtype = []
    $.get('/Room/GetROOMTYPES', function (re) {
        for (i = 0; i < re.length; i++) {
            nom = re[i].Name
            ds = re[i].Id

            mo = { "Nom": nom, "Id": ds, }
            modelRoomtype.push(mo)
        }

        creerertableRoomtype(modelRoomtype)
        rechargeRoom(re)

    })
}


function rechargeRoom(modelRoomTYPE) {  
    modelRom=[]



    $.get('/Room/GetROOMs', function (re) {

      
        for (i = 0; i < re.length; i++) {
            nom = re[i].Name
            ds = re[i].Id

            for (j = 0; j < modelRoomTYPE.length; j++) {

                if (modelRoomTYPE[j].Id == re[i].IdRoomType) {
           
                    mo = { "Nom": nom, "Id": ds, ROMTYPE: modelRoomTYPE[j].Name  }
                    modelRom.push(mo)

                }

            }

      
        }
        creerertableRoomt(modelRom)


    })


}


function creerertableRoomtype(modelRoomtype) {

    if ($.fn.DataTable.isDataTable("#roomtypetable")) {
        $('#roomtypetable').DataTable().destroy();
    }
    $('#roomtypetable').DataTable({
        "filter": true,
        "aaData": modelRoomtype,
        "aoColumns":
            [
                { "data": "Nom", "name": "Nom", "autoWidth": true },
               
                {
                    "data": "Id", "render": function (data) {
                        return '<td class="text-right">' +
                            '<a href="#editemodalRoomtype" onclick="editedroomTypetolocalsession(' + data + ')" class="btn btn btn-secondary btn-rounded "><i class="fa fa-pencil"> </i>   edit  </a>' +
                            '<a href="#supprimermodalRoomtype"  onclick="addIdroomTypetolocalsession(' + data + ')" class="btn btn btn-danger btn-rounded "><i class="fa fa-trash"> </i>  delete  </a>  </td> ';


                          
                    }
                }

            ],

    })

}

function creerertableRoomt(modelRoom) {
    
    if ($.fn.DataTable.isDataTable("#room")) {
        $('#room').DataTable().destroy();
    }
    $('#room').DataTable({
        "filter": true,
        "aaData": modelRoom,
        "aoColumns":
            [
                { "data": "ROMTYPE", "name": "Room Type", "autoWidth": true },
                { "data": "Nom", "name": "Nom", "autoWidth": true },

                {
                    "data": "Id", "render": function (data) {
                        return  ' <a href="#editemodalRoom"  onclick="addIdroomtolocalsessionforedite(' + data + ')" class="btn btn btn-secondary btn-rounded "><i class="fa fa-pencil"> </i>   edit  </a>' +
                            '<a href="#supprimermodalRoom"  onclick="addIdroomtolocalsession(' + data + ')" class="btn btn btn-danger btn-rounded "><i class="fa fa-trash"> </i>  delete  </a> ';



                    }
                }

            ],

    })

}


function showmodaladdRoomType() {


    $("#ajoutermodalRoomtype").modal('show');
}
function showmodaladdRoom() {


    $("#ajoutermodalRoom").modal('show');
}
function addRoomType() {
    class Roomtype{
        Id
        Name
        constructor() {
            this.Id = 0;
            this.Name = $("#NameRoomType").val();
        }

    }
    if ($("#NameRoomType").val() != "") {
        $.post("/Room/AddRoomType", { RoomType: new Roomtype() }, function (result) {
            $("#ajoutermodalRoomtype").modal('hide');
            if (result.status) {
                rechargeRoomtype()
                Swal.fire({

                    icon: 'success',
                    title: result.message,
                    showConfirmButton: false,
                    timer: 1500
                })
               


            }
            else {

                Swal.fire({

                    icon: 'error',
                    title: result.message,
                    showConfirmButton: false,
                    timer: 3000
                })



            };
        }        )
    }
}

function addRoom() {
    class Room {
        Id
        Name
        IdRoomType
        constructor() {
            this.Id = 0;
            this.Name = $("#NameRoom").val();
            this.IdRoomType = $('#Idroomtype').val();
        }

    }
    if ($("#NameRoom").val() != "") {
        $.post("/Room/AddRoom", { Room: new Room() }, function (result) {
            rechargeRoomtype()
            if (result.status) {
                Swal.fire({

                    icon: 'success',
                    title: result.message,
                    showConfirmButton: false,
                    timer: 1500
                })
               


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
        $("#ajoutermodalRoom").modal('hide');
     
    }
}
function confirmationdeleteroom() {
    $("#supprimermodalRoom").modal('hide');
    $.get("/Room/DeleteRoom", { id: sessionStorage.getItem("idroom") }, function (result) {
        if (result.status) {
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })
          


        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })



        };
        rechargeRoomtype()

    })
}
function addIdroomtolocalsession(id) {
    sessionStorage.setItem("idroom", id);
    $("#supprimermodalRoom").modal('show');
}

function editeRoom() {

    class Room {
        Id
        Name
        IdRoomType
        constructor() {
            this.Id = sessionStorage.getItem("idroom")
            this.Name = $("#NameRoomEDITE").val();
            this.IdRoomType = $('#Idroomtypeedi').val();
        }
      
    }
    $.post('/Room/UpdatERoom', { room: new Room() }, function (result) {

        if (result.status) {
            rechargeRoomtype()
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })


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


    $('#editemodalRoom').modal("hide")

    rechargeRoomtype();





}

function addIdroomtolocalsessionforedite(id) {
    sessionStorage.setItem("idroom", id);
    $.get("/Room/GetByID", { id: id }, function (re) {
        $.get("/Room/GetsBy", { idRoomtype: re.IdRoomType }, function (resulta) {
            $("#editroom").empty()
            $("#editroom").append('<label for="inputPassword4" class="float-left">  Name <span> </span></label> <input type="text" class="form-control" id="NameRoomEDITE" value="' + re.Name + '">')
            $("#Idroomtypeedi").append('<option value="' + resulta[0].Id + '" selected> ' + resulta[0]['Name'] +'</option>')

        })

  
    })
    $('#editemodalRoom').modal("show")

}
function addIdroomTypetolocalsession(id) {
    sessionStorage.setItem("idroomtype", id);
    $("#supprimermodalRoomtype").modal('show');
    

}
function confirmationdeleteroomtype() {
    $("#supprimermodalRoomtype").modal('hide');
    $.get("/Room/DeleteRoomType", { id: sessionStorage.getItem("idroomtype") }, function (result) {
        if (result.status) {
            rechargeRoomtype()
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })
         

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
function editedroomTypetolocalsession(id) {
    sessionStorage.setItem("idroomtype", id);
             
    $("#editemodalRoomtype").modal('show');
}
function modifierRoomtype(){
    
    $("#editemodalRoomtype").modal('hide');
    class Roomtype {
        Id
        Name
        constructor() {
            this.Id = sessionStorage.getItem("idroomtype");
            this.Name = $("#NameRoomTypemodifier").val();
        }
    }
    $.post("/Room/UpdateRoomType", { RoomType: new Roomtype() }, function (result) {
        if (result.status) {
            rechargeRoomtype()
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })
        

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