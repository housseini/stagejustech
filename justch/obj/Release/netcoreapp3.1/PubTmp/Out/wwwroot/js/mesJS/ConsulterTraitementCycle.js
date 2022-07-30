$().ready(function () {
    $('#idss').hide();
    $('#referencessss').hide();
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

    sessionStorage.setItem('IdDossierMedical', $('#idss').val());
  
    $.ajax({
        type: "get",
        url: "/DossierMedical/GetpATIENTSBYREFENCE/?Re=" + $('#idss').val(),
        dataType: "JSON",
        success: function (resulta) {
          

            if (resulta.length == 1) {

                $("#patient21").hide();
                if (resulta[0]['Photo'] == null) {
                    var str = '<div class=" profile-info-left">' +
                        '  <img style="height: 150px; width:60%;"  class="rounded-circle" src="/img/user.jpg" />' +
                        ' <h3 class="user-name m-t-0 mb-0" >' + resulta[0]['Civility'] + ' :&nbsp; &nbsp;' + resulta[0]['FirstName'] + ' &nbsp;' + resulta[0]['LastName'] + '  </h3>' +
                        ' <small class="text-muted"> ' + '&nbsp; &nbsp;' + resulta[0]['Dataofbirth'] + ' à &nbsp; ' + resulta[0]['Placeofbirth'] + ' (' + resulta[0]['Country'] + ') </small>' +

                        '  <div class="staff-msg"><a href="/Patient/Profile/' + resulta[0]['Id'] + '"  class="btn btn-primary">Consulter Profil</a></div>' +

                        ' </div >';

                    $("#patient11").append(str);
                 
               
                   


                } else {
                    sessionStorage.setItem('image', resulta[0]['Photo'])
                    var str = '<div class=" profile-info-left">' +
                        '<img style="height: 150px; width:60%;"  onclick="voirimage()" class="rounded-circle" src="/img/Profile/' + resulta[0]['Photo'] + '"  />' +
                        ' <h3 class="user-name m-t-0 mb-0" >' + resulta[0]['Civility'] + ' :&nbsp; &nbsp;' + resulta[0]['FirstName'] + ' &nbsp;' + resulta[0]['LastName'] + '  </h3>' +
                        ' <small class="text-muted"> ' + '&nbsp; &nbsp;' + resulta[0]['Dataofbirth'] + ' à &nbsp; ' + resulta[0]['Placeofbirth'] + ' (' + resulta[0]['Country'] + ') </small>' +
                        '  <div class="staff-msg"><a href="/Patient/Profile/' + resulta[0]['Id'] + '"  class="btn btn-primary">Consulter Profil</a></div>' +
                        ' </div >';

                    $("#patient11").append(str);
                    var t = ' <option value= "' + resulta[0]['FirstName'] + ' &nbsp; ' + resulta[0]['LastName'] + '">' + resulta[0]['FirstName'] + ' &nbsp;' + resulta[0]['LastName'] + '</option>';
                    $("#patients").append(t);
                    $("#patientss").append(t);
                    $("#patientsedite").append(t)
                }
            } if (resulta.length > 1) {

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
               
                $("#patient11").append(str);
              

                var p

                if (resulta[1] == undefined || resulta[1]['Photo'] == undefined || resulta[1]['Photo'] == null) {
                    p = '  <img style="height: 150px; width:60%;"  class="rounded-circle" src="/img/user.jpg" />'
                }
                else {
                    sessionStorage.setItem('image1', resulta[1]['Photo'])
                    p = '  <img style="height: 150px; width:60%;" onclick="voirimage1()" class="rounded-circle" src="/img/Profile/' + resulta[1]['Photo'] + '"  />';
                }




                var st = '<div class="profile-info-left">' + p +
                    ' <h3 class="user-name m-t-0 mb-0" >' + resulta[1]['Civility'] + ' :&nbsp; &nbsp;' + resulta[1]['FirstName'] + ' &nbsp;' + resulta[1]['LastName'] + '  </h3>' +
                    ' <small class="text-muted"> ' + '&nbsp; &nbsp;' + resulta[1]['Dataofbirth'] + ' à &nbsp;' + resulta[1]['Placeofbirth'] + ' (' + resulta[1]['Country'] + ') </small>' +

                    '  <div class="staff-msg"><a href="/Patient/Profile/' + resulta[1]['Id'] + '"  class="btn btn-primary">Consulter Profil</a></div>' +

                    ' </div >';
                var te = ' <option value= "' + resulta[1]['FirstName'] + ' &nbsp; ' + resulta[1]['LastName'] + '">' + resulta[1]['FirstName'] + ' &nbsp;' + resulta[1]['LastName'] + '</option>';


               
                $("#patient21").append(st);
              


            }



        }
    });
})