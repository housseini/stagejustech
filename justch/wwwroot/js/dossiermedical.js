$().ready(function () {
    $("#listemenu").empty()
    var menu = '<li class="menu-title">Main</li>' +
        '  <li  class="active">' +
        '   <a  href = "/DossierMedical/Index" ><i class="fa fa-folder"></i> <span>Dossiers</span></a > ' +
        '  </li>' +
        '     <li>' +
        '      <li   >' +
        '        <a  href="/Patient/Index"><i class="fa fa-user"></i> <span>Patients</span></a>' +
        '     </li>' +
        '     <li>' +
        '         <a href="/Appointment/Index"><i class="fa fa-calendar-check-o"></i> <span>Rendez-vous</span></a>' +
        '      </li>' +
        '     <li>' +
        '          <a href="/Doctor/Index"><i class="fa fa-user"></i> <span>Medecins</span></a>' +
        '      </li>' +
        '     <li>' +
        '          <a href="/STATISTIQUE/Index"><i class="fa fa-user"></i> <span>Statistique</span></a>' +
        '      </li>' +
        '    <li>' +
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



    $.get("/DossierMedical/Count", function (r) {
        
        
        var s = '<input id="Reference" name="Reference" value="DOC00' + r + '" type="text" class="form-control">';
        $("#Inputs").append(s);
    })
    
    $('#formulaire1').hide();
    $('#formulaire2').hide();
    $('#formulaire3').hide();
    $('#tes').hide();
    $('#tes1').hide();
    $('#formuli').hide();
    $('#tes2').hide();
    $('#tes3').hide();
    $('#info').hide();
    

    
    
    $("#type").change(function () {
      
        
      
        if ($("#type").val() == "Femme") {
            $('#formulaire1').hide();
            $('#formulaire3').hide();
            $('#formulaire2').show();
            $('#formuli').show();
           
           

        }
        if ($("#type").val() == "Homme") {
            $('#formulaire2').hide();
            $('#formulaire1').hide();
            $('#formulaire3').show();
            $('#formuli').show();

        }
        if ($("#type").val() == "Couple") {
            $('#formulaire2').hide();
            $('#formulaire1').show();
            $('#formulaire3').hide();
            $('#formuli').show();

            
        }
        if ($("#type").val() == "select") {
            $('#formulaire2').hide();
            $('#formulaire1').hide();
            $('#formulaire3').hide();
            $('#formuli').hide();


        }
     

    });


       

    var model = [];
   
 
    $.ajax({
        type: "get",
        url : "/DossierMedical/GETS",
        dataType:"JSON",
            success: function (resulta) {
               
                var listre = [];    
                listre = resulta;
               
                grid(resulta)
                resulta.forEach(
                    function (item) {
                        var patient = { "Reference": item.Reference, "Type": item.Type, "State": item.State, "DateAdmission": item.DateAdmission, "DateCreation": item.DateCreation, "Id": item.Id };

                        model.push(patient)


                    }

                )

                creertableDossier(model)

                
              
           
        }

    });

    $("#recherchereference").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#conterr h4 ").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
            $("#conterr h4").css('color', 'green')

        });
    });





    
});

function rechargerdossier() {
    window.location.href = "/DossierMedical/Index"
}

function creertableDossier(model) {

    var t = (model.reverse())
    if ($.fn.DataTable.isDataTable("#table_id")) {
        $('#table_id').DataTable().destroy();


    }

    $('#table_id').dataTable({
        "sort": false,
        
        "reverse": true,
        "aaData": t,
        "aoColumns":
            [
                { "data": "Reference", "name": "Reference", "autoWidth": true },
                { "data": "Type", "name": " Type", "autoWidth": true },
                { "data": "State", "name": "State ", "autoWidth": true },
                { "data": "DateAdmission", "name": "DateAdmission", "autoWidth": true },
                { "data": "DateCreation", "name": "DateCreation", "autoWidth": true },
                {
                    "data": "Id", "render": function (data) {
                        return '<td class="text - right">' +
                            ' <div class="dropdown dropdown-action">'
                            + '<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>' +
                            '<div class="dropdown-menu dropdown-menu-right">'
                            + '<a class="dropdown-item"  href="/DossierMedical/editeDossierMedical/' + data
                            + '"  onclick="addlocalstro(' + data + ')"><i class="fa fa - plus m - r - 5"  ></i> editer</a>'
                            + '<a class="dropdown-item" href="/DossierMedical/Consulter?Reference='
                            + data + '"  onclick="edit(' + data + ')"><i class="fa fa - plus m - r - 5"  ></i> consulter</a>'
                            + '	<a class="dropdown-item" href="#delete_doctor" data-toggle="modal" data-target="#delete_patient" onclick="addlocalstroendmodalshow(' + data + ')"><i  class="fa fa - trash - o m - r - 5"></i> Supprimer</a>'
                            + '</div>' + '</div >' + '</td >'
                    }
                }

            ],
    });

    //var table = $('#table_id').DataTable();

    //var data = table
    //    .column(0)
    //    .data()
    //    .sort()
    //    .reverse();
  

  

   


}



function grid(Dossier) {

    $('#conterr').empty()

    Dossier.forEach(
        function (item) {
          
            var st = ' <div class="col-md-4 col-sm-4  col-lg-3">    <div class="profile-widget">  <div class="doctor-img">  ' +
                ' <a class="dash-widget-bg1"  href="/DossierMedical/Consulter?Reference=' + item.Id + '"  onclick="edit(' + item.Id + ')" ><i  class="fa fa-folder" aria-hidden="true"> </i>  </a>   </div>  <div class="dropdown profile-action"> ' +
                ' <a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>' +
                ' <div class="dropdown-menu dropdown-menu-right">'+
                '<a class="dropdown-item"href = "/DossierMedical/editeDossierMedical/' + item.Id + '"  onclick = "addlocalstro(' + item.Id  + ')" > <i class="fa fa-pencil m-r-5"></i> Modifier</a > ' +
                '<a class="dropdown-item" href="#" data-toggle="modal"  data-target="#delete_patient" onclick="addlocalstroendmodalshow(' + item.Id + ')" ><i class="fa fa-trash-o m-r-5"></i> Supprimer</a> ' +
                '  </div>   </div> <h4 class="doctor-name text-ellipsis"><a name="refr" href="profile.html">' + item.Reference + '</a></h4>  </div>    </div>    </div>    ';

            $('#conterr').append(st)

        }


    )

     


}


function addlocalstrostring(refernce) {
 

};



function recher() {
    if ($("#Cin").val() == '' && $("#Id").val() == 0 && $("#Ref").val() == '' && $("#email").val() == '' && $("#telephone").val() == '' && $("#dataa").val() == '') {
        $('#info').show();


    }
    else
    {
       

        $("#rechecher").modal('hide');
        var model = [];
        var dossier = { Id: $("#Id").val(), Cin: $("#Cin").val(), Ref: $("#Ref").val(), dataa: $("#dataa").val(), email: $("#email").val(), telephone: $("#telephone").val(), nbr: $('#nbr').val() }
        $.post("/DossierMedical/RechercherAvance", { Id: $("#Id").val(), Cin: $("#Cin").val(), Ref: $("#Ref").val(), dataa: $("#dataa").val(), email: $("#email").val(), telephone: $("#telephone").val(), nbr: $('#nbr').val() },
             function (resulta) {
              
                
                if (resulta.length > 0) {
                    var listre = [];
                    listre = resulta;


                 

                    resulta.forEach(
                        function (item) {
                          
                            var patient = { "Reference": item.Reference, "Type": item.Type, "State": item.State, "DateAdmission": item.DateAdmission, "DateCreation": item.DateCreation, "Id": item.IdDossierMedical };

                            model.push(patient)


                        }

                    )
                    creertableDossier(model)
                    grid(model)
                   

                } else if (resulta.length==0) {

                    Swal.fire({

                        icon: 'error',
                        title: "aucune donnée trouver ",
                        showConfirmButton: false,
                        timer: 1500
                    })
                }
            }






        
        );
        $("#rechecher").modal('hide');
    }
}

function modalrecherche() {
    $("#rechecher").modal('show');
  }

function addlocalstro(id) {
  
    sessionStorage.setItem("iddossier",id); 

}
function eddDossiervi(idmed) {
    class DossierMedical {
        Id;
        Reference;
        DateCreation;
        DateAdmission;
        Type;
        State;
        constructor() {
            this.Id = sessionStorage.getItem("iddossier");
            this.Reference = $("#Reference").val();
            this.DateAdmission = $("#DateAdmission").val();
            this.DateCreation = "";
            this.State = $("#State").val();
            this.Type = $("#Type").val();
        }

    };
    class DossierMedicalPatient {
        Id
        Role
        Observation
        IdPatient
        IdDossierMedical
        constructor() {
            this.IdPatient = 0;
            this.Id = 0;
            this.Role = $("#Role").val();
            this.Observation = $("#Observation").val();
            this.IdDossierMedical = idmed;

        }

    };




   



    $.post("/DossierMedical/editeDossierMedical", { d: new DossierMedical(), dmp: new DossierMedicalPatient() }, function (result) {
        
            

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
        }



}

    );


}
function deletedossier() {
    $("#delete_doctor").modal('hide');
    $.get("/DossierMedical/DeleteDossierMedical", { id: sessionStorage.getItem("iddossier") }, function (result) {
      
       
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })
            var model = [];


            $.ajax({
                type: "get",
                url: "/DossierMedical/GETS",
                dataType: "JSON",
                success: function (resulta) {

                   

                    grid(resulta)
                    resulta.forEach(
                        function (item) {
                            var patient = { "Reference": item.Reference, "Type": item.Type, "State": item.State, "DateAdmission": item.DateAdmission, "DateCreation": item.DateCreation, "Id": item.Id };

                            model.push(patient)


                        }

                    )

                    creertableDossier(model)




                }

            });





          


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
        }


       
    }

    );

}

function edit(id) {
    sessionStorage.setItem("idmedicalrecordact", id)
    sessionStorage.setItem("iddossier", id)
}
function modalADD() {
    $("#addDossierMedical").modal('show');
}
function fermermodaLADD() {

    $("#addDossierMedical").modal('hide');
}
function fermer() {
    $("#addDossierMedical").modal('hide');
}

function addlocalstroendmodalshow(id) {
    $("#delete_doctor").modal('show');
    sessionStorage.setItem("iddossier", id);
}



