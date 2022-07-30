$().ready(function () {

    $('a[data-toggle="tab"]').on('show.bs.tab', function (e) {
        localStorage.setItem('activeTab', $(e.target).attr('href'));
    });
    var activeTab = localStorage.getItem('activeTab');
    if (activeTab) {
     
        $('#myTab a[href="' + activeTab + '"]').tab('show');
    }




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

  
    $('#Nomd1').hide()
    $('#Nomd').on('keyup', function () {
        $('#Nomd1').hide()
    })
    $('#Fichier').change(function () {

        $('#fichier1').hide()
    })

    $('#fichier1').hide()
    $('#IdPrescribingDoctorMedial11').change(function() {
      
    })
    $('#IdMedicalAct11').change(function () {
        $('#h11').hide()
    })
    $('#patientss').change(function () {
        $('#e1').hide()
    })
    $('#reference').hide();

    $('#IdPrescribingDoctorMedial').change(function () {
        $('#d').hide()
    })

    $('#IdMedicalAct').change(function () {
        $('#h').hide()
    })

    $('#IdPatientNomd1').hide()

    $('#IdPatient').change(function () {
        $('#IdPatientNomd1').hide()
    })

    $('#patients').change(function () {
        $('#e').hide()
    })

    $('#patients').change(function () {
        $('#e').hide()
    })

    $('#g').hide()

    $('#MedicalActName').on('keyup', function () {
        $('#g').hide()

    })

    $('#reference').hide();
     
    $('#id').hide();
    (sessionStorage.setItem('IdDossierMedical', $('#id').val()));
 
 
    $('#rangze').hide();
  

    $.ajax({
        type: "get",
        url: "/DossierMedical/GetpATIENTSBYREFENCE/?Re=" + $('#id').val(),
        dataType: "JSON",
        success: function (resulta) {
            if (resulta.length > 1) {
                GetRdvBypatient(resulta[0]['Id'], resulta[1]['Id'])
            }
            else {
                GetRdvBypatient(resulta[0]['Id'],0)
            }
            

            if (resulta.length == 1) {
               
                $("#patient2").hide();
                if (resulta[0]['Photo'] == null) {
                    var str = '<div class=" profile-info-left">' +
                        '  <img style="height: 150px; width:60%;"  class="rounded-circle" src="/img/user.jpg" />'+
                    ' <h3 class="user-name m-t-0 mb-0" >' + resulta[0]['Civility'] + ' :&nbsp; &nbsp;' + resulta[0]['FirstName'] + ' &nbsp;' + resulta[0]['LastName'] + '  </h3>' +
                        ' <small class="text-muted"> ' + '&nbsp; &nbsp;' + resulta[0]['Dataofbirth'] + ' à &nbsp; ' + resulta[0]['Placeofbirth'] + ' (' + resulta[0]['Country'] + ') </small>' +
                     
                        '  <div class="staff-msg"><a href="/Patient/Profile/' + resulta[0]['Id'] + '"  class="btn btn-primary">Consulter Profil</a></div>' +

                        ' </div >';

                    $("#patient1").append(str);
                    var t = ' <option value= "' + resulta[0]['FirstName'] + ' &nbsp; ' + resulta[0]['LastName'] + '">' + resulta[0]['FirstName'] + ' &nbsp;' + resulta[0]['LastName'] + '</option>';
                    $("#patients").append(t);
                    
                    $("#patientss").append(t);
                    $("#patientsedite").append(t)


                } else {
                    sessionStorage.setItem('image', resulta[0]['Photo'])
                    var str = '<div class=" profile-info-left">' +
                        '<img style="height: 150px; width:60%;"  onclick="voirimage()" class="rounded-circle" src="/img/Profile/' + resulta[0]['Photo']+'"  />'+
                    ' <h3 class="user-name m-t-0 mb-0" >' + resulta[0]['Civility'] + ' :&nbsp; &nbsp;' + resulta[0]['FirstName'] + ' &nbsp;' + resulta[0]['LastName'] + '  </h3>' +
                        ' <small class="text-muted"> ' + '&nbsp; &nbsp;' + resulta[0]['Dataofbirth'] + ' à &nbsp; ' + resulta[0]['Placeofbirth'] + ' (' + resulta[0]['Country'] + ') </small>' +
                        '  <div class="staff-msg"><a href="/Patient/Profile/' + resulta[0]['Id'] + '"  class="btn btn-primary">Consulter Profil</a></div>' +
                        ' </div >';

                    $("#patient1").append(str);
                    var t = ' <option value= "' + resulta[0]['FirstName'] + ' &nbsp; ' + resulta[0]['LastName'] + '">' + resulta[0]['FirstName'] + ' &nbsp;' + resulta[0]['LastName'] + '</option>';
                    $("#patients").append(t);
                    $("#patientss").append(t);
                    $("#patientsedite").append(t)
                }
            } if (resulta.length >1) {

                 var p
                if (resulta[0]['Photo'] == null) {
                    p = '<img style="height: 150px; width:60%;" class="rounded-circle" src="/img/user.jpg" />'
                }
                else {
                    sessionStorage.setItem('image', resulta[0]['Photo'])
                    p = '  <img style="height: 150px; width:60%;" onclick="voirimage()" class="rounded-circle" src="/img/Profile/' + resulta[0]['Photo'] + '"  />';
                }

                var str = '<div class="profile-info-left">' + p +
                         

                        ' <h3 class="user-name m-t-0 mb-0" >' + resulta[0]['Civility'] + ' :&nbsp; &nbsp;' + resulta[0]['FirstName'] + ' &nbsp;' + resulta[0]['LastName'] + '  </h3>' +
                        ' <small class="text-muted"> ' + '&nbsp; &nbsp;' + resulta[0]['Dataofbirth'] + ' à &nbsp;' + resulta[0]['Placeofbirth'] + ' (' + resulta[0]['Country'] + ') </small>' +
                        
                        '  <div class="staff-msg"><a href="/Patient/Profile/' + resulta[0]['Id'] + '"  class="btn btn-primary">Consulter Profil</a></div>' +

                        ' </div >';
                    var t = ' <option value= "' + resulta[0]['FirstName'] + ' &nbsp; ' + resulta[0]['LastName'] + '">' + resulta[0]['FirstName'] + ' &nbsp;' + resulta[0]['LastName'] + '</option>';
                    $("#patients").append(t);
                $("#patient1").append(str);
                $("#patientss").append(t);
                $("#patientsedite").append(t)

                var p
               
                if (resulta[1] == undefined || resulta[1]['Photo'] == undefined ||resulta[1]['Photo'] == null) {
                    p = '  <img style="height: 150px; width:60%;"  class="rounded-circle" src="/img/user.jpg" />'
                }
                else {
                    sessionStorage.setItem('image1', resulta[1]['Photo'])
                    p = '  <img style="height: 150px; width:60%;" onclick="voirimage1()" class="rounded-circle" src="/img/Profile/' + resulta[1]['Photo'] + '"  />';
                }
               

               
                
                   var st = '<div class="profile-info-left">' +p+
                    ' <h3 class="user-name m-t-0 mb-0" >' + resulta[1]['Civility'] + ' :&nbsp; &nbsp;' + resulta[1]['FirstName'] + ' &nbsp;' + resulta[1]['LastName'] + '  </h3>' +
                    ' <small class="text-muted"> ' + '&nbsp; &nbsp;' + resulta[1]['Dataofbirth'] + ' à &nbsp;' + resulta[1]['Placeofbirth'] + ' (' + resulta[1]['Country'] + ') </small>' +
                  
                    '  <div class="staff-msg"><a href="/Patient/Profile/' + resulta[1]['Id'] + '"  class="btn btn-primary">Consulter Profil</a></div>' +

                    ' </div >';
                    var te = ' <option value= "' + resulta[1]['FirstName'] + ' &nbsp; ' + resulta[1]['LastName'] + '">' + resulta[1]['FirstName'] + ' &nbsp;' + resulta[1]['LastName'] + '</option>';
              
          
                $("#patients").append(te);
                $("#patient2").append(st);
                $("#patientss").append(te);
                $("#patientsedite").append(te)
                

            }



        }
    });
    Reacharge1();
 



});
function voirimage1() {
    
    Swal.fire({
        
        imageUrl: 'http://localhost:5000/img/Profile/' + sessionStorage.getItem('image1'),
        imageWidth: 500,
        imageHeight: 500,
        imageAlt: 'Custom image',
    })
}


function rechargeREnseignement() {
    window.location.reload()
}

function Reacharge1() {

    docummentrrrs = [];

    $.get('/UTILITY/GetDossierMedicalPersonniser', { IdDossierMedical: sessionStorage.getItem('IdDossierMedical') }, function (donne) {

        sessionStorage.setItem("IDpatient1", donne.patients[0].Id)
        sessionStorage.setItem("nompatient1", donne.patients[0].FirstName + ' &nbsp; ' + donne.patients[0].LastName)
        if (donne.patients[1]) {
            sessionStorage.setItem("IDpatient2", donne.patients[1].Id)
            sessionStorage.setItem("nompatient2", donne.patients[1].FirstName + ' &nbsp; ' + donne.patients[1].LastName)

        }
        for (i = 0; i < donne.documents.length; i++) {
            
            nom = donne.documents[i].Name
            ds = donne.documents[i].Description
            fi = donne.documents[i].Path
            documentq = { "Id": donne.documents[i].Id, "Nom": nom, "Description":ds, "fichier":fi ,}
            docummentrrrs.push(documentq)
        }
   
        creertabledocument(docummentrrrs)




        

    })

}

function showaddmedicalrecordactELEMENTAIRE() {
    $("#e1").hide();
    $("#d1").hide();
    $("#g1").hide();
    $("#h11").hide();


    $("#ajoutermedicalrecordactELEMENTAIRE").modal('show');
}
function voirimage() {

    Swal.fire({

        imageUrl: 'http://localhost:5000/img/Profile/' + sessionStorage.getItem('image'),
        imageWidth: 500,
        imageHeight: 500,
        imageAlt: 'Custom image',
    })
}
function ConsulterDcument(path) {
    $.get("/Patient/ConsulterDcument", { file: path });
}

function showaddmedicalrecordact() {
    $("#ajoutermedicalrecordact").modal('show');
}
function GetRdvBypatient(idpatient, idpatient2) {
    model =[]
    $.ajax({
        type: "get",
        url: "/UTILITY/RdvBYidpatient/?id=" + idpatient,
        dataType: "JSON",
        success: function (resulta) {

           
            
            resulta.forEach(function (item) {

                rdv = { Id: item['Appointment']['Id'], Date: item['Appointment']['Date'].split('T')[0], Heur: item['Appointment']['Hour1'].split('T')[1], ACT: item['medicicalActs'][0]['Name'], Durer: item['medicicalActs'][0]['Duration'], SALLE: item['rooms'][0]['Name'], Patient: item['patients'][0]['Civility'], MEDECIN: item['doctors'][0]['FirstName']+'&nbsp; &nbsp;    &nbsp; &nbsp;' + item['doctors'][0]['LastName'], Etat: item['Appointment']['State']}
                model.push(rdv)
                if (item['Appointment']['IdPatient2'] != 0) {
                rdv = {
                    Id: item['Appointment']['Id'], Date: item['Appointment']['Date'].split('T')[0], Heur: item['Appointment']['Hour2'].split('T')[1], ACT: item['medicicalActs'][1]['Name'], Durer: item['medicicalActs'][1]['Duration'], SALLE: item['rooms'][1]['Name'], Patient: item['patients'][1]['Civility'], MEDECIN: item['doctors'][1]['FirstName'] +'&nbsp; &nbsp;    &nbsp; &nbsp;' + item['doctors'][1]['LastName'],Etat: item['Appointment']['State'] }
                    model.push(rdv)
                }

            })
            if (idpatient2 != 0) {

                $.ajax({
                    type: "get",
                    url: "/UTILITY/RdvBYidpatient/?id=" + idpatient2,
                    dataType: "JSON",
                    success: function (resulta) {
                        resulta.forEach(function (item) {

                            rdv = { Id: item['Appointment']['Id'], Date: item['Appointment']['Date'].split('T')[0], Heur: item['Appointment']['Hour1'].split('T')[1], ACT: item['medicicalActs'][0]['Name'], Durer: item['medicicalActs'][0]['Duration'], SALLE: item['rooms'][0]['Name'], Patient: item['patients'][0]['Civility'], MEDECIN: item['doctors'][0]['FirstName'] + '&nbsp; &nbsp;    &nbsp; &nbsp;' + item['doctors'][0]['LastName'], Etat: item['Appointment']['State'] }
                            model.push(rdv)
                            if (item['Appointment']['IdPatient2'] != 0) {
                                rdv = {
                                    Id: item['Appointment']['Id'], Date: item['Appointment']['Date'].split('T')[0], Heur: item['Appointment']['Hour2'].split('T')[1], ACT: item['medicicalActs'][1]['Name'], Durer: item['medicicalActs'][1]['Duration'], SALLE: item['rooms'][1]['Name'], Patient: item['patients'][1]['Civility'], MEDECIN: item['doctors'][1]['FirstName'] + '&nbsp; &nbsp;    &nbsp; &nbsp;' + item['doctors'][1]['LastName'], Etat: item['Appointment']['State']
                                }
                                model.push(rdv)
                            }

                        })

                        creertableRdv(model)




                    }

                });
            }
            else {
                creertableRdv(model)
            }
         
            
           


        }
        
    });
  
 

   
}
function showmadaladd() {

    $.ajax({
        type: "get",
        url: "/DossierMedical/GetpATIENTSBYREFENCE/?Re=" + $('#id').val(),
        dataType: "JSON",
        success: function (resulta) {
          

            for (let i = 0; i < resulta.length; i++) {
                var str = '<option value=' + resulta[i]['Id'] + '>' + resulta[i]['FirstName'] + ' &nbsp;' + resulta[i]['LastName'] + '</option > ';
                $("#IdPatient").append(str);
                
            }
          



        }
    });
    $("#ajouterdocument").modal('show');;
}
function addlocalsession(id) {
    sessionStorage.setItem('IDdocumment', id);
}
function showmodaladdtypefile() {
    $("#ajouterdocument").modal('hide');
    $("#ajouterdocumentTYPE").modal('show');
}
function modalsupprimerssohw(id) {
    $("#supprimerdocument").modal('show');
    sessionStorage.setItem('IDdocumment', id);

}
function confirmationdelete() {
    var iddocument = (sessionStorage.getItem('IDdocumment'));

    $.get("/Patient/DeleteDocument", { id: iddocument }, function (result) {

        $("#supprimerdocument").modal('hide');
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
function addTypeDocument() {
    class DocumentType {
        Code;
        Label;
        constructor() {
            this.Label = $("#NomDt").val();
            this.Code = $("#Code").val();
        }
    }

    if ($("#Code").val() == "" || $("#NomDt").val() == "") { } else {
        $.post("/DossierMedical/AddDocummentType", { documment: new DocumentType() }, function (result) {

            if (result.status) {



                Swal.fire({

                    icon: 'success',
                    title: result.message,
                    showConfirmButton: false,
                    timer: 1500
                })

                $.get("/UTILITY/GetByCode", { Code: $("#Code").val() }, function (r) {
                    $("#TypeDocumment").append('<option selected value="'+r.Code+'">  '+r.Label +'</option>')
                
                })

                $("#ajouterdocument").modal('show');
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


function creertableRdv(model1) {

    if ($.fn.DataTable.isDataTable("#Rdvd")) {
        $('#Rdvd').DataTable().destroy();
    }
    $("#tablebody").empty()
    var model=  model1.reverse()
    for (var i = 0; i < model.length; i++) {
        if (model[i]['Etat'] == ' EN COURS ') {
            $("#tablebody").append('<tr>' +
                '<td>' + model[i]['Date'] + ' </td>' +
                '<td> ' + model[i]['Heur'] + ' </td>' +
                '<td>  ' + model[i]['ACT'] + '</td>' +
                '<td> ' + model[i]['Durer'] + ' </td>' +
                '<td>' + model[i]['SALLE'] + ' </td>' +
                '<td>' + model[i]['Patient'] + ' </td>' +
                '<td> ' + model[i]['MEDECIN'] + ' </td>' +
                '<td> ' + model[i]['Etat'] + '</td>' +
                '<td class="text - right">'
                + ' <div class="dropdown dropdown-action">'
                + '<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>' +
                '<div class="dropdown-menu dropdown-menu-right">' +
                ' <a class="dropdown-item" onclick="inforendezvous(' + model[i]['Id'] + ')" ><i class="fa fa-print"></i> imprimer </a>' +
                ' <a class="dropdown-item" href="#" onclick="terminerrendezvous(' + model[i]['Id'] + ')" ><i class="fa fa-pencil m-r-5"></i> terminer </a>' +
                '<a class="dropdown-item" href="#"  onclick="supprimerrendezvous(' + model[i]['Id'] + ')" ><i class="fa fa-trash m-r-5"></i> supprimer </a>' +
                '</div>' + '</div >' + '</td >' +
                '</tr>'
            )
        }
        else {
            $("#tablebody").append('<tr>' +
                '<td>' + model[i]['Date'] + ' </td>' +
                '<td> ' + model[i]['Heur'] + ' </td>' +
                '<td>  ' + model[i]['ACT'] + '</td>' +
                '<td> ' + model[i]['Durer'] + ' </td>' +
                '<td>' + model[i]['SALLE'] + ' </td>' +
                '<td>' + model[i]['Patient'] + ' </td>' +
                '<td> ' + model[i]['MEDECIN'] + ' </td>' +
                '<td> ' + model[i]['Etat'] + '</td>' +
                '<td class="text - right">'
                + ' <div class="dropdown dropdown-action">'
                + '<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>' +
                '<div class="dropdown-menu dropdown-menu-right">' +
                ' <a class="dropdown-item" href="#inforendezvous" onclick="inforendezvous(' + model[i]['Id'] + ')" ><i class="fa fa-print"></i>  imprimer </a>' +
                '<a class="dropdown-item" href="#"  onclick="supprimerrendezvous(' + model[i]['Id'] + ')" ><i class="fa fa-trash m-r-5"></i> supprimer </a>' +
                '</div>' + '</div >' + '</td >' +
                '</tr>'
            )

        }



    }




    $('#Rdvd').DataTable({
            
            //"filter": true,
            //"aaData": model,
            //"aoColumns":
            //    [

            //        { "data": "Date", "name": "Date", "autoWidth": true },
            //        { "data": "Heur", "name": "Heur", "autoWidth": true },
            //        { "data": "ACT", "name": "ACT", "autoWidth": true },
            //        { "data": "Durer", "name": "Durer", "autoWidth": true },
            //        { "data": "SALLE", "name": "SALLE", "autoWidth": true },
            //        { "data": "Patient", "name": "Patient", "autoWidth": true },
            //        { "data": "MEDECIN", "name": "MEDECIN", "autoWidth": true },

            //        {
            //            "data": "Id", "render": function (data) {
            //                return '<td> ' + data + '</td>'
            //            }
            //        }



            //    ],

        });



    

}
function inforendezvous(id) {

    $("#remplirlafiche").empty()
    $.get("/UTILITY/GetRDVbyIdAPP", { id: id }, function (re) {

        $("#remplirlafiche").append('<tr> <td> <h3> Jours  &nbsp;  &nbsp;  &nbsp;  </h3>    </td>     <td> <h3> ' + re['Appointment']['Date'].split('T')[0] + '  &nbsp;  &nbsp;  &nbsp;  </h3>    </td> </tr>')
        $("#remplirlafiche").append('<tr>  <td> <h3> Heure  &nbsp;  &nbsp;  &nbsp;  </h3>    </td>   <td> <h3>  ' + re['Appointment']['Hour1'].split('T')[1] + '</h3></td></tr>')

        $("#remplirlafiche").append('<tr>   <td> <h3> Patient  &nbsp;  &nbsp;  &nbsp;  </h3>    </td>    <td> <h3>  ' + re['patients'][0]['Civility'] + '&nbsp;' + re['patients'][0]['FirstName'] + ' &nbsp;  &nbsp;' + re['patients'][0]['LastName']  + '</h3></td></tr>')
        $("#remplirlafiche").append('<tr>   <td> <h3> ACTE Medical  &nbsp;  &nbsp;  &nbsp;  </h3>    </td>    <td> <h3>  ' + re['medicicalActs'][0]['Name'] + '&nbsp;'  + '</h3></td></tr>')
        $("#remplirlafiche").append('<tr>   <td> <h3>   Durer  &nbsp;  &nbsp;  &nbsp;  </h3>    </td>    <td> <h3>  ' + re['medicicalActs'][0]['Duration'] + '&nbsp;' + '</h3></td></tr>')
        $("#remplirlafiche").append('<tr>   <td> <h3>   SALLE  &nbsp;  &nbsp;  &nbsp;  </h3>    </td>    <td> <h3>  ' + re['rooms'][0]['Name'] + '&nbsp;' + '</h3></td></tr>')
        $("#remplirlafiche").append('<tr>   <td> <h3>   Medecin Traitant   &nbsp;  &nbsp;  &nbsp;  </h3>    </td>    <td> <h3>  ' + re['doctors'][0]['FirstName'] + ' &nbsp;  &nbsp;' + re['doctors'][0]['LastName']  + '</h3></td></tr>')
        $("#remplirlafiche").append('<tr>   <td> <h3>   Statu  &nbsp;  &nbsp;  &nbsp;  </h3>    </td>    <td> <h3>  ' + re['Appointment']['State'] + '&nbsp;' + '</h3></td></tr>')

   
       
      //  



    });

   
    $("#inforendezvous").modal({
        escapeClose: false,
        clickClose: false,
        showClose: false,
        show: true
    });


}


function imprimer() {
    $.print("#fiche-content");
}
function supprimerrendezvous(id) {
    sessionStorage.setItem('idappoitement',id)
    $("#deleterendezvous").modal('show')
}

function deleteappoitement() {
    $.get("/Appointment/Delete", { ap: sessionStorage.getItem('idappoitement') }, function (result) {

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



        };

    })
}

function terminerrendezvous(id) {
    $.get("/Appointment/Terminer", { Id: id }, function (result) {

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
        


        };

    })
 
}

function creertabledocument(model) {
    
    if ($.fn.DataTable.isDataTable("#tabledocument"))
    {
        $('#tabledocument').DataTable().destroy();
    }
    $('#tabledocument').DataTable({
        "filter": true,
        "aaData": model,
        "aoColumns":
            [
                { "data": "Nom", "name": "Nom", "autoWidth": true },
                { "data": "Description", "name": "Description", "autoWidth": true },
                { "data": "fichier", "name": "Nom du fichier", "autoWidth": true },
                {
                    "data": "fichier","render": function (data) {
                        return "<a class='dropdown-item' href='#' onclick='voirfichier(\"" + data +"\")'><i class='fa fa-pencil m-r-5'></i> Consulter </a>"
                    }
                }
                ,
                {
                    "data": "Id", "render": function (data) {
                        return '<td class="text - right">'
                            + ' <div class="dropdown dropdown-action">'
                            + '<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>' +
                            '<div class="dropdown-menu dropdown-menu-right">' +
                            ' <a class="dropdown-item" href="#modifierdocument" onclick="showmadalmodifierdocument(' + data + ')"><i class="fa fa-pencil m-r-5"></i> editer </a>' +
                            '<a class="dropdown-item" href="#deletemedicalDOCUMENT" onclick="showmodaldeleteDocument(' + data + ')"><i class="fa fa-trash m-r-5"></i> supprimer </a>' +
                            '</div>' + '</div >' + '</td >'
                    }
                }



            ],

    });

}

function vider() {
    $("#contenue").empty();

}

function voirfichier(fichier) {
    $("#voirfichier").modal("show")
    $("#contenue").empty();
    $("#contenue").append('<embed  width="100%" id="pdfdata" class="custom" src ="/Documents/' + fichier + '">')

}

function showmadalmodifierdocument(id) {
    sessionStorage.setItem("iddocument", id);
    $.get("/DocumentType/GetDocumentById", { id: id }, function (re) {
        $("#IdPatientmodifier").empty()

        if (sessionStorage.getItem("IDpatient1") == re['IdPatient']) {

            $("#IdPatientmodifier").append(' <option value="' + sessionStorage.getItem("IDpatient1") + ' "  selected >' + sessionStorage.getItem("nompatient1") + ' </option>')
        }


        if (sessionStorage.getItem("IDpatient2") == re['IdPatient']) {

            $("#IdPatientmodifier").append(' <option value="' + sessionStorage.getItem("IDpatient2") + ' "  selected >' + sessionStorage.getItem("nompatient2") + ' </option>')
        }

        $.get("/DocumentType/Gets", function (t) {
            $("#TypeDocummentmodifier").empty()
            for (var i = 0; i < t.length; i++) {

                if (t[i]["Code"] == re.CodeDocumentType) {
                    $("#TypeDocummentmodifier").append(' <option value="' + t[i]["Code"] + ' "  selected >' + t[i]["Label"] + ' </option>')

                }
                else {
                    $("#TypeDocummentmodifier").append(' <option value="' + t[i]["Code"] + ' "  >' + t[i]["Label"] + ' </option>')


                }

            }



        })
        sessionStorage.setItem("Path",re["Path"])
        $("#formodifiernomdocument").empty()
        $("#formodifiernomdocument").append('<label for="inputPassword4">  NOM <span>*</span></label> <input type="text" class="form-control" id="modifierNomdoc"value="'+re["Name"]+'"> ')

        
        $("#forDescripiondocumentmodi").empty()
        $("#forDescripiondocumentmodi").append('  <label for="inputAddress">Descripion</label> <textarea class="form-control" id="Descripionmodifier" rows="3" value="' + re["Description"]+'">' + re["Description"]+'</textarea>')

        $("#modifierdocument").modal('show')


    })



}

function addDocument() {

    class Document {
        Id
        IdPatient
        CodeDocumentType
        IdDossierMedical
        Name
        Description
        File
        constructor() {
            var files = $('#Fichier').get(0);
            var formData = new FormData();
            formData.append('file', files.files[0]);
            this.Id = 0;
            this.Path = files.files[0].name;
            this.CodeDocumentType = $("#TypeDocumment").val();


            if ($("#IdPatient").length > 1) {
                this.IdPatient  = $("#IdPatient").val()[0]
            }
            else {
                this.IdPatient = $("#IdPatient").val();

            }
           
         
           this.IdDossierMedical = sessionStorage.getItem('IdDossierMedical');
            this.Name = $("#Nomd").val();
            this.Description = $("#Descripion").val();
        }
    }
    var files = $('#Fichier').get(0);
    if (files.files[0] == undefined || $("#Nomd").val() == "") {

        $('#Nomd1').show()
        $('#fichier1').show()
        
    }
    if ($("#IdPatient").val() == '') {
        $('#IdPatientNomd1').show()
    }
    if (files.files[0].name != "" && $("#Nomd").val() != "") {

        var formData = new FormData();
        formData.append('file', files.files[0]);
        $.ajax({
            type: 'POST',
            url: "/Patient/FILEdocumen",
            data: formData,
            cache: false,
            contentType: false,
            processData: false,
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            success: function (repo) {
               
                if (repo.status) {
                    var id
                    if ($("#IdPatient").val()[1]) {
                        id = $("#IdPatient").val()[1]
                    }
                    else {
                        id=0

                    }
                    
                    $.post("/Patient/AddDocument", { d: new Document() ,id:id}, function (result) {

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
                                timer: 1500
                            })
                          


                        };
                        Reacharge1()
                        $("#ajouterdocument").modal('hide')
                    }

                    );
                }
            },
            error: function (error) {
                console.log("Error occurs" + error);
            }
        });

    }

}
function fermer() {

    $("#voirfichier").modal("hide")
    $("#deletemedicalRecored").modal('hide')
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

function UpdateDocument() {

    class Document {
        Id
        IdPatient
        CodeDocumentType
        IdDossierMedical
        Name
        Description
        path
        constructor() {
            this.Id = sessionStorage.getItem("iddocument")
            this.IdPatient = $("#IdPatientmodifier").val()[0]
            this.CodeDocumentType = $("#TypeDocummentmodifier").val()
            this.IdDossierMedical = sessionStorage.getItem('IdDossierMedical')
            this.Name = $("#modifierNomdoc").val()
            this.Description = $("#Descripionmodifier").val()
        
            if ($("#Fichiermodifier").val() == '') {
                this.path = sessionStorage.getItem("Path")
            }
            if ($("#Fichiermodifier").val() != '')
            {
                var files = $('#Fichiermodifier').get(0);
                var formData = new FormData();
                this.path = files.files[0].name;
                formData.append('file', files.files[0]);
                $.ajax({
                    type: 'POST',
                    url: "/Patient/FILEdocumen",
                    data: formData,
                    cache: false,
                    contentType: false,
                    processData: false,
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader("XSRF-TOKEN",
                            $('input:hidden[name="__RequestVerificationToken"]').val());
                    },
                    success: function (repo) {
                  
                    }
                });


            }

        }
   
    }
    $.post("/Patient/Updatedocument", { d: new Document() }, function (result) {
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
                timer: 1500
            })



        };
        Reacharge1()
        $("#modifierdocument").modal('hide')


    })

}


function showmodaldeleteDocument(id) {
    sessionStorage.setItem("iddocument", id);
    $("#deletemedicalDOCUMENT").modal('show')

}

function fermer1() {
    $("#deletemedicalDOCUMENT").modal('hide')

}

function confirmationdeletedocument() {

    $.get("/Patient/deleteDocument", { id: sessionStorage.getItem("iddocument") }, function (result) {
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
                timer: 1500
            })



        };
        Reacharge1()
        $("#deletemedicalDOCUMENT").modal('hide')


    })

}