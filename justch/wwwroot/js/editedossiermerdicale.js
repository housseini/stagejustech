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
        '           <a class="dropdown-item" href="/Automatisation/Index">Classification</a> ' +
        '       </div> ' +
        '   </li>    ';

    $("#listemenu").append(menu)


   
    $('#formulaire2').hide();
    $('#formulaire3').hide();
 
    
    $('#tes1').hide();
    $('#tes').hide();
    

    $.get("/DossierMedical/GetdossierById", { id: sessionStorage.getItem('iddossier') }, function (r) {
        ttt(r.Id)
        sessionStorage.setItem('iddossier',r.Id)
        sessionStorage.setItem('Type', r.Type)
        sessionStorage.setItem('DateCreation', r.DateCreation)
        sessionStorage.setItem('DateAdmission', r.DateAdmission)
        sessionStorage.setItem('Type', r.Type)
        sessionStorage.setItem('State', r.State)
        sessionStorage.setItem('Reference', r.Reference)

        var s = '<input id="Reference" name="Reference" value=" ' + r.Reference + '" type="text" class="form-control">';
        $("#Inputs").append(s);
        if (r.Type == 'Femme' || r.Type == 'Homme' ) {
            var t =
                 ' <option value="' + r.Type +'"> ' + r.Type+'  </option> '+
                '  <option value="Couple"> Couple  </option> ';

            $("#type").append(t);

            if (r.State == 'complet') {
                $("#ETAT").empty()
                var t = '  <label>ETAT  : &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; ' + r.State + '  &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; </label>    <a href="#" onclick="Incompleter(' + r.Id + ')" class="btn btn-primary"> Mettre state Incomplet</a>'

                $("#ETAT").append(t);

            }
            else {
                var t = '  <label>ETAT  : &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; ' + r.State + '  &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; </label>    <a href="#" onclick="completer(' + r.Id + ')" class="btn btn-primary"> Mettre state a complet</a>'

                $("#ETAT").append(t);
            }
            }
           

        if (r.Type == 'Couple' && r.State == 'Incomplet' ) {
            $('#choixtype').hide()
           
            var t = '  <label>ETAT  : &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; ' + r.State +'  &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; </label>    <a href="#" onclick="completer(' + r.Id+')" class="btn btn-primary"> Mettre state a complet</a>'

            $("#ETAT").append(t);
        }

        if (r.Type == 'Couple' && r.State == 'complet') {
            $('#choixtype').hide()

            var t = '  <label>ETAT  : &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; ' + r.State + '  &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; </label>    <a href="#" onclick="Incompleter(' + r.Id + ')" class="btn btn-primary"> Mettre state a  Incomplet</a>'

            $("#ETAT").append(t);
        }

        

        $("#type").change(function () {
            if ($("#type").val() == 'Couple') {
                $('#formuli').show();

                if (r.Type == 'Homme') {
                    $('#formulaire2').hide();
                    $('#formulaire3').show();
                   
                }

                if (r.Type == 'Femme') {
                }

                
                $('#formulaire3').hide();
                $('#formulaire2').show();

                }
          

        })
            

      
    });





}

)


function Incompleter(id) {
    $.get("/DossierMedical/InCompleter", { Id: id }, function (result) {
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
                timer: 4000
            })
            setTimeout(function () {
                window.location.reload()
            }, 3000)


        };
    })

}
function completer(id) {

    $.get("/DossierMedical/Completer", { Id: id }, function (result) {
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
                timer: 4000
            })
            setTimeout(function () {
                window.location.reload()
            }, 3000)


        };
    })
}



function ttt(r) {
    $.get('/UTILITY/GetDossierMedicalPersonniser', { IdDossierMedical:r}, function (donne) {



        for (i = 0; i < donne.patients.length; i++) {
            var str = '<div class="row">' +
                '   <div class="col-sm-4 col-3" id = "paragraphe" >' +


                ' <h2 class="page-title"> Proprietaire du Dossier  </h2>' +
                '   &nbsp;   &nbsp;   &nbsp;' +
                '<h2 class="page-title"> Nom : &nbsp;   &nbsp;   &nbsp;' + donne.patients[i].FirstName + ' </h2> ' +
                '     &nbsp;   &nbsp;   &nbsp;' +
                '   &nbsp;   &nbsp;   &nbsp;' +
                '  <h2 class="page-title" > Prenom :  &nbsp;   &nbsp;   &nbsp;' + donne.patients[i].LastName + '  </h2>' +
                ' &nbsp;   &nbsp;   &nbsp;   ' +
                '   &nbsp;   &nbsp;   &nbsp;   ' +

                '   </div >  ' +
                '    <div class="col-sm-8 col-9 text-right m-b-20">  ' +
                '  <a href="/Patient/Profile/' + donne.patients[i].Id + '" class="btn btn-primary float-right    submit-btn">Consulter  Profile</a>   ' +

                '  </div>   ' +

                '  </div > ';
            $("#propriertaire").append(str)
        }
    }

    );
}

function modifier() {
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
            this.DateAdmission = '';
            this.DateCreation = sessionStorage.getItem("DateCreation");
            this.State = sessionStorage.getItem("State");
            this.Type = $("#type").val();
        }

    };
    class DossierMedicalPatient {
        Id
        Role
        Observation
        IdPatient
        IdDossierMedical
        constructor() {
            if ($("#Id4").val() != 0) {
                this.IdPatient = $("#Id4").val();
            }
            if ($("#Id3").val() != 0) {
                this.IdPatient = $("#Id3").val();
            }
            this.Id = 0;
            this.Role = null;
            this.Observation = null;
            this.IdDossierMedical = sessionStorage.getItem("iddossier");

        }

    };


    if ($("#type").val() == 'Couple') {
        if (sessionStorage.getItem('Type') == 'Homme' && $("#Id4").val() == 0) {

            $('#tes').show();

        }
        if ($("#Id4").val() != 0 || $("#Id3").val() != 0) {

            $.post("/DossierMedical/editeDossierMedical", { d: new DossierMedical(), dmp: new DossierMedicalPatient() }, function (result) {
                if (result.status) {



                    Swal.fire({

                        icon: 'success',
                        title: result.message,
                        showConfirmButton: false,
                        timer: 1500
                    })
                    setTimeout(function () {
                        window.location.href = "/DossierMedical/Index"
                    }, 3000)


                }
                else {
          

                    Swal.fire({

                        icon: 'error',
                        title: result.message,
                        showConfirmButton: false,
                        timer: 30000
                    })
                   
                }



            }

            );

        }
        if (sessionStorage.getItem('Type') == 'Femme' && $("#Id3").val() == 0) {

            $('#tes1').show();

        }
       

    }

    if ($("#type").val() != 'Couple') {
        var d = new DossierMedical()
        d.Type = sessionStorage.getItem('Type')


        $.post("/DossierMedical/editeDossierMedicalsing", { d: d }, function (result) {
            console.log(result)
            if (result.status) {



                Swal.fire({

                    icon: 'success',
                    title: result.message,
                    showConfirmButton: false,
                    timer: 1500
                })
                setTimeout(function () {
                    window.location.href = "/DossierMedical/Consulter?Reference=" + sessionStorage.getItem("iddossier")
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
            }



        }

        );

    }
}