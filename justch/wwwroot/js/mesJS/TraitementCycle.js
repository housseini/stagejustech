
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
    $("#formtraitemen").validate({
        rules: {
            Name: "required",
            IdMedicalAct: "required",

            IdMedicalAct: {
                required: true,
                min: 1

            },

            Name: {
                required: true,
                minlength: "2"
            }
        },
        // in 'messages' user have to specify message as per rules
        messages: {
            Name: "Please enter  Name",
            IdMedicalAct: "chose MEDICAL ACT"


        },
        errorPlacement: function (error, element) {
            element.css('border-color', '#ffdddd');
            error.insertAfter(element);
        }



    });
    

    $.get("/TraitementCycle/ALLTCACM", function (resulta) {
     
        creertableTraitementCycle(resulta)
       


    })



    


});

function creertableTraitementCycle(re) {
   
    $("#tableTraitementCycle").empty()
    for (i = 0; i < re.length; i++) {
        $("#tableTraitementCycle").append(' <tr> <td>' + re[i].traitementCycle['Name'] + '</td>  <td>  ' + re[i].medicalAct['Name'] + '</td>    <td>' + re[i].medicalAct['Duration'] + '</td> <td> ' + re[i].medicalAct['MedicalActType'] + '</td> <td> ' + re[i].medicalAct['Category'] + '</td>  ' +
            '<td class="text - right">' + ' <div class="dropdown dropdown-action">' + '<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>' + '<div class="dropdown-menu dropdown-menu-right">' + '<a class="dropdown-item" href="#"  onclick="edit(' + re[i].medicalAct['ID'] + ',' + re[i].traitementCycle['Id'] + ',' + re[i].TreatmentCycleElementaryAct['Id']+ ')"><i class="fa fa - plus m - r - 5"  ></i> Editer</a>' + '	<a class="dropdown-item" href="#" data-toggle="modal" data-target="#delete_traitementCycle" onclick="addidtolocalstorage(' + re[i].traitementCycle['Id']  + ')"><i class="fa fa - trash - o m - r - 5"></i> Supprimer</a>' + '</div>' + '</div >' + '</td > </tr>')


    }
    $('#table').DataTable({})
}

function addidtolocalstorage(id) {
    localStorage.setItem("idtraitementCycle",id)
}

function fermer() {
    $("#ajoutermodalTtraitementCycle").modal("hide");
}
function edit(id, t,k) {
   
    localStorage.setItem("medicalActID", id)
    localStorage.setItem("traitementCycleID", t)
    localStorage.setItem("TreatmentCycleElementaryActID", k)
    $("#editerinput").empty()


    $.get("/TraitementCycle/GetTCACM", { Id: k }, function (re) {
      
        $("#editerinput").append(' <label for="editerName" class="float-left">  Name *</label>  <input type="text" name="editerName" class="form-control" id="editerName" value="' + re.traitementCycle.Name + '" placeholder="Name" required minlength="3">  ')

        $("#editerIdMedicalAct").append(' <option  selected value=' + re.medicalAct.ID + '> ' + re.medicalAct.Name + '</option>')
    })
    

    $("#editermodalTtraitementCycle").modal("show");

}


function editer() {

    if ($("#formtediter").valid()) {

        $.post("/TraitementCycle/Update", { Idtraitemen: localStorage.getItem("traitementCycleID"), Name: $("#editerName").val(), idtraitementElement: localStorage.getItem("TreatmentCycleElementaryActID"), Idact: $("#editerIdMedicalAct").val() },
            function (result) {
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
              
            }
        )

    }

}

function confirmationdelete() {
    $("#delete_traitementCycle").modal("hide");
    $.get("/TraitementCycle/DeletById", { Id: localStorage.getItem("idtraitementCycle") }, function (result) {
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



function showmodaladdTraitementCycle() {
  
    $("#ajoutermodalTtraitementCycle").modal("show");
 
}



function add() {
     class TraitementCycle {
           Id;
       Name;
       IdMedicalAct;
  
        constructor() {
        this.Id = 0;
        this.Name = $("#Name").val();
      
      
        this.IdMedicalAct = $("#IdMedicalAct").val();
              }

       }

    
    if ($("#formtraitemen").valid()) {
       
        $.post("/TraitementCycle/Add", { trai: $("#Name").val(), Id: $("#IdMedicalAct").val() }, function (result) {
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
        });
            
    }
}


