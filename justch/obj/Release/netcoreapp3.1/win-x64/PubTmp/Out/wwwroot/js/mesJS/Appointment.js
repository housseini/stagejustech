function creertabledd(modeldd) {
  
  

    if ($.fn.DataTable.isDataTable("#table_rdvz")) {
        $('#table_rdvz').DataTable().destroy();
    }


    $('#table_rdvz').DataTable({
        "filter": true,
        "aaData": modeldd,
        "aoColumns":
            [
                { "data": "Date", "name": "Date", "autoWidth": true },
                { "data": "Heur", "name": "Heur", "autoWidth": true },
                { "data": "ACT", "name": "ACT", "autoWidth": true },
                { "data": "Durer", "name": "Durer", "autoWidth": true },
                { "data": "SALLE", "name": "SALLE", "autoWidth": true },
                { "data": "Patient", "name": "Patient", "autoWidth": true },
                { "data": "MEDECIN", "name": "MEDECIN", "autoWidth": true },
                { "data": "Etat", "name": "Etat", "autoWidth": true },
                {
                    "data": "Id", "render": function (data) {
                        return '<td class="text-right">'+
                            ' <div class="dropdown dropdown-action" > '+
                            '     <a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a> '+
                          '  <div class="dropdown-menu dropdown-menu-right">'+
                         '   <a class="dropdown-item" href="#" onclick="voirInfo('+data+')" data-toggle="modal" data-target="#"><i class="fa fa-plus-o m-r-5"></i> plus</a>'+
                        '    </div>'+
                          '      </div > '+
                          '  </td >'
                    }
                }

            ],

    });

    //$('#table_rdvz thead th').each(function () {
    //    var title = $(this).text();


    //    if (title != 'Action') {

    //        $(this).html('<label class="float-left" > ' + title + '</label> <input   class="form-control"  type="text" placeholder="' + title + '" />');
    //    }
    //});

    //$('#table_rdvz').DataTable({
    //    responsive: true,
    //    initComplete: function () {
    //         Apply the search
    //        this.api().columns().every(function () {
    //            var that = this;

    //            $('input', this.header()).on('keyup change clear', function () {
    //                if (that.search() !== this.value) {
    //                    that
    //                        .search(this.value)
    //                        .draw();
    //                }
    //            });
    //        });
    //    }
    //});





}

$().ready(function () {


    CreermodePourtableRdv()
    $('#date').change(function () {

        $("#jr").hide();
    })

    $('#IdPatients').change(function () {
       
        $("#labpa").hide();
    })

    $('#IdRoom1').change(function () {

        $("#sal").hide();
    })
    $('#IdPrescribingDoctor1').change(function () {

        $("#doc").hide();
    })

    $('#Hour1').change(function () {

        $("#hr1").hide();
    })

    $('#IdMedicalAct').change(function () {

        $("#medi").hide();
    })




    $("#listemenu").empty()
    var menu = '<li class="menu-title">Main</li>' +
        '  <li >' +
        '   <a  href = "/DossierMedical/Index" ><i class="fa fa-folder"></i> <span>Dossiers</span></a > ' +
        '  </li>' +
        '     <li>' +
        '      <li   >' +
        '        <a  href="/Patient/Index"><i class="fa fa-user"></i> <span>Patients</span></a>' +
        '     </li>' +
        '     <li class="active">' +
        '         <a href="/Appointment/Index"><i class="fa fa-calendar-check-o"></i> <span>Rendez-vous</span></a>' +
        '      </li>' +
        '     <li   >' +
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
    $("#jr").hide();
    $("#labpa").hide();
    $("#sal").hide();
    $("#doc").hide();
    $("#hr1").hide();
    $("#medi").hide();



    var last_valid_selection = null;

    $('#IdPatients').change(function(event) {

            if ($(this).val().length >= 2) {

              $(this).val(last_valid_selection);
            } else {
              last_valid_selection = $(this).val();
            }
    });
    $('#IdPatients111').change(function (event) {

        if ($(this).val().length >= 2) {

            $(this).val(last_valid_selection);
        } else {
            last_valid_selection = $(this).val();
        }
    });


    $('#IdRoom1').change(function (event) {

        if ($(this).val().length >= 2) {

            $(this).val(last_valid_selection);
        } else {
            last_valid_selection = $(this).val();
        }
    });

    $('#IdRoom1111').change(function (event) {

        if ($(this).val().length >= 2) {

            $(this).val(last_valid_selection);
        } else {
            last_valid_selection = $(this).val();
        }
    });

    $('#IdPrescribingDoctor1111').change(function (event) {

        if ($(this).val().length >= 2) {

            $(this).val(last_valid_selection);
        } else {
            last_valid_selection = $(this).val();
        }
    });
    $('#IdPrescribingDoctor1').change(function (event) {

        if ($(this).val().length >= 2) {

            $(this).val(last_valid_selection);
        } else {
            last_valid_selection = $(this).val();
        }
    });
    $('#IdMedicalAct').change(function (event) {

        if ($(this).val().length >= 2) {

            $(this).val(last_valid_selection);
        } else {
            last_valid_selection = $(this).val();
        }
    });

    $('#IdMedicalAct111').change(function (event) {

        if ($(this).val().length >= 2) {

            $(this).val(last_valid_selection);
        } else {
            last_valid_selection = $(this).val();
        }
    });




    var model = []
    var appoiteme=[]
   
    $.get('/UTILITY/AllRdv', function (re) {

      
       
        re.forEach(
            function (item) {
               
                
                var start = item['Appointment']['Date'].split('T')[0] + 'T' + item['Appointment']['Hour1'].split('T')[1]
                var end = moment(start).add(720, 'minutes').format("YYYY-MM-DDTHH:mm:ss");
                var app = { 'Date': item['Appointment']['Date'].split('T')[0], 'Heur': item['Appointment']['Hour1'].split('T')[1], 'ACT': item['medicicalActs'][0]['Name'], 'Durer': item['medicicalActs'][0]['Duration'], 'SALLE': item['rooms'][0]['Name'], 'Patient': item['patients'][0]['FirstName']+' ' + item['patients'][0]['LastName'], 'MEDECIN': item['doctors'][0]['FirstName'] +'  '+ item['doctors'][0]['LastName'] }
                appoiteme.push(app)
                    


                var appoitement = { 
                    title: item['Appointment']['Id'] +','+  item['Appointment']['Hour1'].split('T')[1] + ' ' + end + ' Salle : ' + item['rooms'][0]['Name'] + ' Act : ' + item['medicicalActs'][0]['Name'] + ' Patient : ' + item['patients'][0]['FirstName'] + ' ' + item['patients'][0]['LastName'] + ' Medecin Traitant : ' + item['doctors'][0]['FirstName'] + ' ' + item['doctors'][0]['LastName'] , // a property!
                    start: start, // a property!
                    end: end,
                    color: 'blue' // override!
                }
             
                model.push(appoitement)

                if (item['Appointment']['IdPatient2'] != 0) {

                    if (item['rooms'][1]) {
                        if (item['doctors'][1]) {
                            if (item['medicicalActs'][1]) {
                                var app = { 'Date': item['Appointment']['Date'].split('T')[0], 'Heur': item['Appointment']['Hour2'].split('T')[1], 'ACT': item['medicicalActs'][1]['Name'], 'Durer': item['medicicalActs'][1]['Duration'], 'SALLE': item['rooms'][1]['Name'], 'Patient': item['patients'][1]['FirstName'] + ' ' + item['patients'][1]['LastName'], 'MEDECIN': item['doctors'][1]['FirstName'] + ' ' + item['doctors'][1]['LastName'] }
                                appoiteme.push(app)
                            } else {
                                var app = { 'Date': item['Appointment']['Date'].split('T')[0], 'Heur': item['Appointment']['Hour2'].split('T')[1], 'ACT': item['medicicalActs'][0]['Name'], 'Durer': item['medicicalActs'][0]['Duration'], 'SALLE': item['rooms'][1]['Name'], 'Patient': item['patients'][1]['FirstName'] + ' ' + item['patients'][1]['LastName'], 'MEDECIN': item['doctors'][1]['FirstName'] + ' ' + item['doctors'][1]['LastName'] }
                                appoiteme.push(app)

                            }
                        }
                        else {
                            var app = { 'Date': item['Appointment']['Date'].split('T')[0], 'Heur': item['Appointment']['Hour2'].split('T')[1], 'ACT': item['medicicalActs'][0]['Name'], 'Durer': item['medicicalActs'][0]['Duration'], 'SALLE': item['rooms'][1]['Name'], 'Patient': item['patients'][1]['FirstName'] + ' ' + item['patients'][1]['LastName'], 'MEDECIN': item['doctors'][0]['FirstName'] + ' ' + item['doctors'][0]['LastName'] }
                            appoiteme.push(app)
                        }
                    } else {
                        var app = { 'Date': item['Appointment']['Date'].split('T')[0], 'Heur': item['Appointment']['Hour2'].split('T')[1], 'ACT': item['medicicalActs'][0]['Name'], 'Durer': item['medicicalActs'][0]['Duration'], 'SALLE': item['rooms'][0]['Name'], 'Patient': item['patients'][1]['FirstName'] + ' ' + item['patients'][1]['LastName'], 'MEDECIN': item['doctors'][0]['FirstName'] + ' ' + item['doctors'][0]['LastName'] }
                        appoiteme.push(app)
                    }

                    var start = item['Appointment']['Date'].split('T')[0] + 'T' + item['Appointment']['Hour2'].split('T')[1]
                    var end = moment(start).add(720, 'minutes').format("YYYY-MM-DDTHH:mm:ss");


                    if (item['rooms'][1]) {
                       
                        var appoitement = {
                            title: item['Appointment']['Id'] + ',' +  item['Appointment']['Hour2'].split('T')[1] + ' ' + end + ' Salle : ' + item['rooms'][1]['Name'] + ' Act : ' + item['medicicalActs'][0]['Name'] + ' Patient : ' + item['patients'][1]['FirstName'] + ' ' + item['patients'][1]['LastName'] + ' Medecin Traitant : ' + item['doctors'][0]['FirstName'] + ' ' + item['doctors'][0]['LastName'], // a property!
                            start: start, // a property!
                            end: end,
                            color: 'blue' // override!
                        }

                        model.push(appoitement)
                    } else {

                        
                        var appoitement = {
                            title: item['Appointment']['Id'] + ',' +  item['Appointment']['Hour2'].split('T')[1] + ' ' + end + ' Salle : ' + item['rooms'][0]['Name'] + ' Act : ' + item['medicicalActs'][0]['Name'] + ' Patient : ' + item['patients'][1]['FirstName'] + ' ' + item['patients'][1]['LastName'] + ' Medecin Traitant : ' + item['doctors'][0]['FirstName'] + ' ' + item['doctors'][0]['LastName'], // a property!
                            start: start, // a property!
                            end: end,
                            color: 'blue' // override!
                        }

                        model.push(appoitement)
                    }
                    


                }

            }
             
        )
   
        creer(model)
      



       
    })
    creertabledd(appoiteme)
   



 

})

function RECHARGECALENDRE(re) {
    var model = []
    var appoiteme = []

    re.forEach(
        function (item) {

            var start = item['Appointment']['Date'].split('T')[0] + 'T' + item['Appointment']['Hour1'].split('T')[1]
            var end = moment(start).add(720, 'minutes').format("YYYY-MM-DDTHH:mm:ss");
            var app = { 'Date': item['Appointment']['Date'].split('T')[0], 'Heur': item['Appointment']['Hour1'].split('T')[1], 'ACT': item['medicicalActs'][0]['Name'], 'Durer': item['medicicalActs'][0]['Duration'], 'SALLE': item['rooms'][0]['Name'], 'Patient': item['patients'][0]['FirstName'] + ' ' + item['patients'][0]['LastName'], 'MEDECIN': item['doctors'][0]['FirstName'] + '  ' + item['doctors'][0]['LastName'] }
            appoiteme.push(app)



            var appoitement = {
                title: item['Appointment']['Hour1'].split('T')[1] + ' ' + end + ' Salle : ' + item['rooms'][0]['Name'] + ' Act : ' + item['medicicalActs'][0]['Name'] + ' Patient : ' + item['patients'][0]['FirstName'] + ' ' + item['patients'][0]['LastName'] + ' Medecin Traitant : ' + item['doctors'][0]['FirstName'] + ' ' + item['doctors'][0]['LastName'], // a property!
                start: start, // a property!
                end: end,
                color: 'bleu' // override!
            }

            model.push(appoitement)

            if (item['Appointment']['IdPatient2'] != 0) {

                if (item['rooms'][1]) {
                    if (item['doctors'][1]) {
                        if (item['medicicalActs'][1]) {
                            var app = { 'Date': item['Appointment']['Date'].split('T')[0], 'Heur': item['Appointment']['Hour2'].split('T')[1], 'ACT': item['medicicalActs'][1]['Name'], 'Durer': item['medicicalActs'][1]['Duration'], 'SALLE': item['rooms'][1]['Name'], 'Patient': item['patients'][1]['FirstName'] + ' ' + item['patients'][1]['LastName'], 'MEDECIN': item['doctors'][1]['FirstName'] + ' ' + item['doctors'][1]['LastName'] }
                            appoiteme.push(app)
                        } else {
                            var app = { 'Date': item['Appointment']['Date'].split('T')[0], 'Heur': item['Appointment']['Hour2'].split('T')[1], 'ACT': item['medicicalActs'][0]['Name'], 'Durer': item['medicicalActs'][0]['Duration'], 'SALLE': item['rooms'][1]['Name'], 'Patient': item['patients'][1]['FirstName'] + ' ' + item['patients'][1]['LastName'], 'MEDECIN': item['doctors'][1]['FirstName'] + ' ' + item['doctors'][1]['LastName'] }
                            appoiteme.push(app)

                        }
                    }
                    else {
                        var app = { 'Date': item['Appointment']['Date'].split('T')[0], 'Heur': item['Appointment']['Hour2'].split('T')[1], 'ACT': item['medicicalActs'][0]['Name'], 'Durer': item['medicicalActs'][0]['Duration'], 'SALLE': item['rooms'][1]['Name'], 'Patient': item['patients'][1]['FirstName'] + ' ' + item['patients'][1]['LastName'], 'MEDECIN': item['doctors'][0]['FirstName'] + ' ' + item['doctors'][0]['LastName'] }
                        appoiteme.push(app)
                    }
                } else {
                    var app = { 'Date': item['Appointment']['Date'].split('T')[0], 'Heur': item['Appointment']['Hour2'].split('T')[1], 'ACT': item['medicicalActs'][0]['Name'], 'Durer': item['medicicalActs'][0]['Duration'], 'SALLE': item['rooms'][0]['Name'], 'Patient': item['patients'][1]['FirstName'] + ' ' + item['patients'][1]['LastName'], 'MEDECIN': item['doctors'][0]['FirstName'] + ' ' + item['doctors'][0]['LastName'] }
                    appoiteme.push(app)
                }

                var start = item['Appointment']['Date'].split('T')[0] + 'T' + item['Appointment']['Hour2'].split('T')[1]
                var end = moment(start).add(720, 'minutes').format("YYYY-MM-DDTHH:mm:ss");


                if (item['rooms'][1]) {

                    var appoitement = {
                        title: item['Appointment']['Hour2'].split('T')[1] + ' ' + end + ' Salle : ' + item['rooms'][1]['Name'] + ' Act : ' + item['medicicalActs'][0]['Name'] + ' Patient : ' + item['patients'][1]['FirstName'] + ' ' + item['patients'][1]['LastName'] + ' Medecin Traitant : ' + item['doctors'][0]['FirstName'] + ' ' + item['doctors'][0]['LastName'], // a property!
                        start: start, // a property!
                        end: end,
                        color: 'blue' // override!
                    }

                    model.push(appoitement)
                } else {


                    var appoitement = {
                        title: item['Appointment']['Hour2'].split('T')[1] + ' ' + end + ' Salle : ' + item['rooms'][0]['Name'] + ' Act : ' + item['medicicalActs'][0]['Name'] + ' Patient : ' + item['patients'][1]['FirstName'] + ' ' + item['patients'][1]['LastName'] + ' Medecin Traitant : ' + item['doctors'][0]['FirstName'] + ' ' + item['doctors'][0]['LastName'], // a property!
                        start: start, // a property!
                        end: end,
                        color: 'blue' // override!
                    }

                    model.push(appoitement)
                }



            }

        }

    )

    creer(model)


}
function CreermodePourtableRdv() {

    $.get('/UTILITY/AllRdv', function (re) {
        model=[]
      



        re.forEach(
            function (item) {


                var app = { 'Etat': item['Appointment']["State"] ,'Id': item['Appointment']['Id'], 'Date': item['Appointment']['Date'].split('T')[0], 'Heur': item['Appointment']['Hour1'].split('T')[1], 'ACT': item['medicicalActs'][0]['Name'], 'Durer': item['medicicalActs'][0]['Duration'], 'SALLE': item['rooms'][0]['Name'], 'Patient': item['patients'][0]['FirstName'] + ' ' + item['patients'][0]['LastName'], 'MEDECIN': item['doctors'][0]['FirstName'] + '  ' + item['doctors'][0]['LastName'] }
                model.push(app)

                if (item['Appointment']["IdPatient2"] != 0) {
                    var app = { 'Etat': item['Appointment']["State"], 'Id': item['Appointment']['Id'], 'Date': item['Appointment']['Date'].split('T')[0], 'Heur': item['Appointment']['Hour2'].split('T')[1], 'ACT': item['medicicalActs'][1]['Name'], 'Durer': item['medicicalActs'][1]['Duration'], 'SALLE': item['rooms'][1]['Name'], 'Patient': item['patients'][1]['FirstName'] + ' ' + item['patients'][1]['LastName'], 'MEDECIN': item['doctors'][1]['FirstName'] + '  ' + item['doctors'][1]['LastName'] }
                    model.push(app)

                }
            }

        )

       

        creertabledd(model)




    })
        
}
function showmodaladDap() {
    $("#ajoutermodal").modal('show')
}


function creer(model) {

   


  



   
    var initialLocaleCode = 'fr';
    var localeSelectorEl = document.getElementById('locale-selector');
    var calendarEl = document.getElementById('calendar');

    var calendar = new FullCalendar.Calendar(calendarEl, {
        headerToolbar: {
            left: 'prev,next today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay,listMonth'
        },

        eventClick: function (info) {
            var eventObj = info.event;

            if (eventObj.url) {
               

              

                info.jsEvent.preventDefault(); // prevents browser from following link in current tab.
            } else {

                voirInfo(eventObj.title.split(',')[0])
               // alert('Clicked ' + eventObj.title);
            }
        },


       
        initialDate: new Date(),
        nowIndicator: true,
        eventColor: 'bleu',
        initialView: 'dayGridMonth',
        locale: initialLocaleCode,
        buttonIcons: false, // show the prev/next text
        weekNumbers: true,
        navLinks: true, // can click day/week names to navigate views
        editable: false,
        dayMaxEvents: true,
        // allow "more" link when too many events
        events: model


    });

    calendar.render();
   
    calendar.addEvent(event[model])
    // build the locale selector's options
    calendar.getAvailableLocaleCodes().forEach(function (localeCode) {
        var optionEl = document.createElement('option');
        optionEl.value = localeCode;
        optionEl.selected = localeCode == initialLocaleCode;
        optionEl.innerText = localeCode;
        localeSelectorEl.appendChild(optionEl);
    });

    // when the selected option changes, dynamically change the calendar option
    localeSelectorEl.addEventListener('change', function () {
        if (this.value) {
            calendar.setOption('locale', this.value);
        }
    });
}

function deletes(id) {
    sessionStorage.setItem("idappointement", id)
    $("#delete_appointement").modal('show')

}

function showmodalsupprimer() {
    
    $("#Inforendevous").modal('hide')
    $("#delete_appointement").modal('show')
}

function voirInfo(id) {


   
    sessionStorage.setItem("idappointement", id)
    $.get("/UTILITY/GetRDVbyIdAPP", { id:id}, function (re) {
        
        $("#INFODATE").empty()
        sessionStorage.setItem("Date", re['Appointment']['Date'])
        sessionStorage.setItem("Hour1", re['Appointment']['Hour1'])
        sessionStorage.setItem("Hour2", re['Appointment']['Hour2'])
        $("#INFODATE").append('<label for="inputAddress2" class="float-left">jour*     <h3> ' + re['Appointment']['Date'].split('T')[0] + ' </h3>  </label> <input type="date" class="form-control" id="INFO" > ')
        $("#IdPatientsinnfof").empty()
        $("#IdPatients111info").empty()
        
        $("#IdPatientsinnfof").append(' <option  selected  value="' + re['Appointment']['IdPatient1'] + '"> ' + re['patients'][0]['FirstName'] + ' &nbsp;  ' + re['patients'][0]['LastName'] + '  </option>')
        $.get("/Patient/GetPatients", function (te) {
         
            for (var i = 0; i < te.length; i++) {
                $("#IdPatientsinnfof").append(' <option   value="' + te[i]['Id'] + '"> ' + te[i]['FirstName'] + ' &nbsp;  ' + te[i]['LastName'] + '  </option>')
                $("#IdPatients111info").append(' <option   value="' + te[i]['Id'] + '"> ' + te[i]['FirstName'] + ' &nbsp;  ' + te[i]['LastName'] + '  </option>')

            }
        })
        $("#IdRoominfo").empty()
        $("#IdRoom1111info").empty()
   
        $.get("/Room/GetROOMs", function (te) {
           
            for (var i = 0; i < te.length; i++) {
                $("#IdRoominfo").append(' <option   value="' + te[i]['Id'] + '"> ' + te[i]['Name'] + ' &nbsp;   </option>')
                $("#IdRoom1111info").append(' <option   value="' + te[i]['Id'] + '"> ' + te[i]['Name'] + ' &nbsp;   </option>')

            }
        })



        $("#IdPrescribingDoctorinfo").empty()
        $("#IdPrescribingDoctor1111infoee").empty()
        $.get("/Doctor/Gets", function (te) {

            for (var i = 0; i < te.length; i++) {
                $("#IdPrescribingDoctorinfo").append(' <option   value="' + te[i]['Id'] + '"> ' + te[i]['FirstName'] + ' &nbsp;  ' + te[i]['LastName'] + '  </option>')
                $("#IdPrescribingDoctor1111infoee").append(' <option   value="' + te[i]['Id'] + '"> ' + te[i]['FirstName'] + ' &nbsp;  ' + te[i]['LastName'] + '  </option>')

            }
        })

        $("#IdMedicalActinfo").empty()
        $("#IdMedicalAct111Info").empty()
        $.get("/MedicalAct/Gets", function (te) {
            
            for (var i = 0; i < te.length; i++) {
                $("#IdMedicalActinfo").append(' <option   value="' + te[i]['Id'] + '"> ' + te[i]['Name'] + ' &nbsp;   </option>')
                $("#IdMedicalAct111Info").append(' <option   value="' + te[i]['Id'] + '"> ' + te[i]['Name'] + ' &nbsp;   </option>')

            }
        })



        $("#IdRoominfo").append(' <option  selected  value = "' + re['Appointment']['IdRoom1'] + '" > ' + re['rooms'][0]['Name'] + ' &nbsp; ' + '  </option > ')
        $("#IdPrescribingDoctorinfo").append(' <option  selected  value="' + re['Appointment']['IdPrescribingDoctor1'] + '"> ' + re['doctors'][0]['FirstName'] + ' &nbsp;  ' + re['doctors'][0]['LastName'] + '  </option>')
        $("#infoheure").empty()
        $("#infoheure").append('<label for="inputAddress2" class="float-left">heur *     <h3> ' + re['Appointment']['Hour1'].split('T')[1] + ' </h3>  </label> <input type="time" class="form-control" id="heur1Info" > ')
        
        $("#IdMedicalActinfo").append(' <option  selected  value = "' + re['Appointment']['IdMedicalAct1'] + '" > ' + re['medicicalActs'][0]['Name'] + ' &nbsp; ' + '  </option > ')
        $("#Infonote").empty()
        $("#Infonote").append('<label for="inputAddress2" class="float-left">Notes </label> <textarea type="text" class="form-control" id="NotesInfo" rows="2" value="'  + re['Appointment']['Notes']+'"> ' + re['Appointment']['Notes']+'</textarea>')


        if (re['Appointment']['IdPatient2']!=0) {
         
            $("#IdPatients111info").append(' <option  selected  value="' + re['Appointment']['IdPatient2'] + '"> ' + re['patients'][1]['FirstName'] + ' &nbsp;  ' + re['patients'][1]['LastName'] + '  </option>')
            
            $("#IdRoom1111info").append(' <option  selected  value = "' + re['Appointment']['IdRoom2'] + '" > ' + re['rooms'][1]['Name'] + ' &nbsp; ' + '  </option > ')
            $("#IdPrescribingDoctor1111infoee").append(' <option  selected  value="' + re['Appointment']['IdPrescribingDoctor2'] + '"> ' + re['doctors'][1]['FirstName'] + ' &nbsp;  ' + re['doctors'][1]['LastName'] + '  </option>')
            $("#heur2Info").empty()
            $("#heur2Info").append('<label for="inputAddress2" class="float-left">heur *     <h3> ' + re['Appointment']['Hour2'].split('T')[1] + ' </h3>  </label> <input type="time" class="form-control" id="Hour2indf" > ')

            $("#IdMedicalAct111Info").append(' <option  selected  value = "' + re['Appointment']['IdMedicalAct2'] + '" > ' + re['medicicalActs'][1]['Name'] + ' &nbsp; ' + '  </option > ')

        }

        if (re['Appointment']['State'] ==" EN COURS ") {

            $("#divbuton").empty()

            $("#divbuton").append('<button type="button" class="btn btn-white" onclick="fermer()"><i class="m-r-5"> fermer </i> </button>'+
               '<button type="button" class="btn btn-primary" onclick="edite()" > <i class="fa fa-pencil m-r-5"> Modifier </i> </button > '+
           '<button type = "button" class= "btn  btn-white" onclick = "terminerrendezvous()" > <i class="fa fa-pencil m-r-5"> terminer </i> </button > '+

            '<button type = "button" class= "btn  btn-danger" onclick = "showmodalsupprimer()" > <i class="fa fa-trash-o m-r-5"> suprimer </i> </button > ')

        }
        if (re['Appointment']['State'] == " TERMINER ") {

            $("#divbuton").empty()

            $("#divbuton").append('<button type="button" class="btn btn-white" onclick="fermer()"><i class="m-r-5"> fermer </i> </button>' +
               '<button type = "button" class= "btn  btn-danger" onclick = "showmodalsupprimer()" > <i class="fa fa-trash-o m-r-5"> suprimer </i> </button > ')

        }



    })

   
    

    $("#Inforendevous").modal("show")
}
function voirmodalrecher() {
    $("#Rechercheavant").modal('show')
}
function terminerrendezvous() {
    $.get("/Appointment/Terminer", { Id: sessionStorage.getItem('idappointement') }, function (result) {
        if (result.status) {
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })
            setTimeout(function () {

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


        };
        rechargerlecalandrer()
        CreermodePourtableRdv()

    })
}
function rechargerlecalandrer() {
    CreermodePourtableRdv()


    var model = []
    var appoiteme = []

    $.get('/UTILITY/AllRdv', function (re) {


        re.forEach(
            function (item) {

                var start = item['Appointment']['Date'].split('T')[0] + 'T' + item['Appointment']['Hour1'].split('T')[1]
                var end = moment(start).add(720, 'minutes').format("YYYY-MM-DDTHH:mm:ss");
                var app = { 'Date': item['Appointment']['Date'].split('T')[0], 'Heur': item['Appointment']['Hour1'].split('T')[1], 'ACT': item['medicicalActs'][0]['Name'], 'Durer': item['medicicalActs'][0]['Duration'], 'SALLE': item['rooms'][0]['Name'], 'Patient': item['patients'][0]['FirstName'] + ' ' + item['patients'][0]['LastName'], 'MEDECIN': item['doctors'][0]['FirstName'] + '  ' + item['doctors'][0]['LastName'] }
                appoiteme.push(app)



                var appoitement = {
                    title: item['Appointment']['Hour1'].split('T')[1] + ' ' + end + ' Salle : ' + item['rooms'][0]['Name'] + ' Act : ' + item['medicicalActs'][0]['Name'] + ' Patient : ' + item['patients'][0]['FirstName'] + ' ' + item['patients'][0]['LastName'] + ' Medecin Traitant : ' + item['doctors'][0]['FirstName'] + ' ' + item['doctors'][0]['LastName'], // a property!
                    start: start, // a property!
                    end: end,
                    color: 'bleu' // override!
                }

                model.push(appoitement)

                if (item['Appointment']['IdPatient2'] != 0) {

                    if (item['rooms'][1]) {
                        if (item['doctors'][1]) {
                            if (item['medicicalActs'][1]) {
                                var app = { 'Date': item['Appointment']['Date'].split('T')[0], 'Heur': item['Appointment']['Hour2'].split('T')[1], 'ACT': item['medicicalActs'][1]['Name'], 'Durer': item['medicicalActs'][1]['Duration'], 'SALLE': item['rooms'][1]['Name'], 'Patient': item['patients'][1]['FirstName'] + ' ' + item['patients'][1]['LastName'], 'MEDECIN': item['doctors'][1]['FirstName'] + ' ' + item['doctors'][1]['LastName'] }
                                appoiteme.push(app)
                            } else {
                                var app = { 'Date': item['Appointment']['Date'].split('T')[0], 'Heur': item['Appointment']['Hour2'].split('T')[1], 'ACT': item['medicicalActs'][0]['Name'], 'Durer': item['medicicalActs'][0]['Duration'], 'SALLE': item['rooms'][1]['Name'], 'Patient': item['patients'][1]['FirstName'] + ' ' + item['patients'][1]['LastName'], 'MEDECIN': item['doctors'][1]['FirstName'] + ' ' + item['doctors'][1]['LastName'] }
                                appoiteme.push(app)

                            }
                        }
                        else {
                            var app = { 'Date': item['Appointment']['Date'].split('T')[0], 'Heur': item['Appointment']['Hour2'].split('T')[1], 'ACT': item['medicicalActs'][0]['Name'], 'Durer': item['medicicalActs'][0]['Duration'], 'SALLE': item['rooms'][1]['Name'], 'Patient': item['patients'][1]['FirstName'] + ' ' + item['patients'][1]['LastName'], 'MEDECIN': item['doctors'][0]['FirstName'] + ' ' + item['doctors'][0]['LastName'] }
                            appoiteme.push(app)
                        }
                    } else {
                        var app = { 'Date': item['Appointment']['Date'].split('T')[0], 'Heur': item['Appointment']['Hour2'].split('T')[1], 'ACT': item['medicicalActs'][0]['Name'], 'Durer': item['medicicalActs'][0]['Duration'], 'SALLE': item['rooms'][0]['Name'], 'Patient': item['patients'][1]['FirstName'] + ' ' + item['patients'][1]['LastName'], 'MEDECIN': item['doctors'][0]['FirstName'] + ' ' + item['doctors'][0]['LastName'] }
                        appoiteme.push(app)
                    }

                    var start = item['Appointment']['Date'].split('T')[0] + 'T' + item['Appointment']['Hour2'].split('T')[1]
                    var end = moment(start).add(720, 'minutes').format("YYYY-MM-DDTHH:mm:ss");


                    if (item['rooms'][1]) {

                        var appoitement = {
                            title: item['Appointment']['Hour2'].split('T')[1] + ' ' + end + ' Salle : ' + item['rooms'][1]['Name'] + ' Act : ' + item['medicicalActs'][0]['Name'] + ' Patient : ' + item['patients'][1]['FirstName'] + ' ' + item['patients'][1]['LastName'] + ' Medecin Traitant : ' + item['doctors'][0]['FirstName'] + ' ' + item['doctors'][0]['LastName'], // a property!
                            start: start, // a property!
                            end: end,
                            color: 'bleu' // override!
                        }

                        model.push(appoitement)
                    } else {


                        var appoitement = {
                            title: item['Appointment']['Hour2'].split('T')[1] + ' ' + end + ' Salle : ' + item['rooms'][0]['Name'] + ' Act : ' + item['medicicalActs'][0]['Name'] + ' Patient : ' + item['patients'][1]['FirstName'] + ' ' + item['patients'][1]['LastName'] + ' Medecin Traitant : ' + item['doctors'][0]['FirstName'] + ' ' + item['doctors'][0]['LastName'], // a property!
                            start: start, // a property!
                            end: end,
                            color: 'bleu' // override!
                        }

                        model.push(appoitement)
                    }



                }

            }

        )

        creer(model)

     





    })

    Swal.fire({
        icon: 'success',
        title: 'refresh',
        timer: 1500
         }
    )
}
function recherche() {
    model = { 'IPITENT': $('#IdPatientsrecherche').val()[0], 'Room': $('#IdRoomrecher').val()[0], 'jour': $('#dateREcher').val(), 'plage': $('#plagerecher').val(), 'Idmedecin': $('#IdPrescribingDoctorrecher').val()[0], 'IdAct': $('#IdMedicalActrecher').val()[0] }

    $.post("/Appointment/Rechercheravancer", { IPITENT: $('#IdPatientsrecherche').val()[0], Room: $('#IdRoomrecher').val()[0], jour: $('#dateREcher').val(), plage: $('#plagerecher').val(), Idmedecin: $('#IdPrescribingDoctorrecher').val()[0], IdAct: $('#IdMedicalActrecher').val()[0] }, function (re) {
        $("#Rechercheavant").modal('hide')
        
        if (re.length != 0 || re==null) {
            model = []




            re.forEach(
                function (item) {


                    var app = { 'Etat': item['Appointment']["State"], 'Id': item['Appointment']['Id'], 'Date': item['Appointment']['Date'].split('T')[0], 'Heur': item['Appointment']['Hour1'].split('T')[1], 'ACT': item['medicicalActs'][0]['Name'], 'Durer': item['medicicalActs'][0]['Duration'], 'SALLE': item['rooms'][0]['Name'], 'Patient': item['patients'][0]['FirstName'] + ' ' + item['patients'][0]['LastName'], 'MEDECIN': item['doctors'][0]['FirstName'] + '  ' + item['doctors'][0]['LastName'] }
                    model.push(app)

                    if (item['Appointment']["IdPatient2"] != 0) {
                        var app = { 'Etat': item['Appointment']["State"], 'Id': item['Appointment']['Id'], 'Date': item['Appointment']['Date'].split('T')[0], 'Heur': item['Appointment']['Hour2'].split('T')[1], 'ACT': item['medicicalActs'][1]['Name'], 'Durer': item['medicicalActs'][1]['Duration'], 'SALLE': item['rooms'][1]['Name'], 'Patient': item['patients'][1]['FirstName'] + ' ' + item['patients'][1]['LastName'], 'MEDECIN': item['doctors'][1]['FirstName'] + '  ' + item['doctors'][1]['LastName'] }
                        model.push(app)

                    }
                }

            )



            creertabledd(model)

            RECHARGECALENDRE(re)


        }
        if (re['length'] == 0 || re == null || re['Appointment'] == undefined) {

            Swal.fire({
                    
                icon: 'error',
                title: 'aucune donne trouvée',
                showConfirmButton: false,
                timer: 3000
            })
            setTimeout(function () {

            }, 3000)

        }
    })

}
function fermerRDVINFO() {
    $("#Inforendevous").modal("hide")
    $("#Rechercheavant").modal("hide")
}
function fermer() {
    $("#delete_appointement").modal('hide')
    $("#Inforendevous").modal('hide')
}

function deleteappoitement() {
    $("#delete_appointement").modal('hide')


    $.get("/Appointment/Delete", { ap: sessionStorage.getItem('idappointement') }, function (result) {
        if (result.status) {
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })
            setTimeout(function () {
              
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


        };
        rechargerlecalandrer()
        CreermodePourtableRdv()

    })

}

function editemodalshow(id) {
    sessionStorage.setItem("idappointement", id)
    $.get("/Appointment/GetRdv_Complet", { Id: id }, function (result) {
       
       
        sessionStorage.setItem("Id1", result.Appointment['IdPatient1'])
        sessionStorage.setItem("IdPatient2", result.Appointment['IdPatient2'])
        sessionStorage.setItem("IdRoom1", result.Appointment['IdRoom1'])
        sessionStorage.setItem("IdRoom2", result.Appointment['IdRoom2'])
        sessionStorage.setItem("IdPrescribingDoctor1", result.Appointment['IdPrescribingDoctor1'])
        sessionStorage.setItem("IdPrescribingDoctor2", result.Appointment['IdPrescribingDoctor2'])
        sessionStorage.setItem("IdMedicalAct1", result.Appointment['IdMedicalAct1'])
        sessionStorage.setItem("IdMedicalAct2", result.Appointment['IdMedicalAct2'])
        sessionStorage.setItem("Date", result.Appointment['Date'])
        sessionStorage.setItem("Hour1", result.Appointment['Hour1'])
        sessionStorage.setItem("Hour2", result.Appointment['Hour2'])
        sessionStorage.setItem("Notes", result.Appointment['Notes'])
        sessionStorage.setItem("State", result.Appointment['State'])

        $("#labpa0").empty()
        $("#labpa0").append('patients')
        $.each(result.patients, function (index, value) {

            var s = ' &nbsp;' + value.FirstName + ' &nbsp;' + value.LastName
            $("#labpa0").append(s)
        });
        $("#sal1").empty()
        $("#sal1").append('salles')
        $.each(result.rooms, function (index, value) {

            var s = '  &nbsp; &nbsp;' + value.Name
            $("#sal1").append(s)
        });

        $("#doc1").empty()
        $("#doc1").append('Medecins')
        $.each(result.doctors, function (index, value) {

            var s = '  &nbsp; &nbsp;' + value.FirstName + '  &nbsp; &nbsp;' + value.LastName
            $("#doc1").append(s)
        });

        $("#jr1").empty()
        
        $("#jr1").append(' <label for="inputAddress2" class="float-left" >jour*  ' + moment(result.Appointment['Date']).format("DD/MM/YYYY") + '</label> <input type="date" class="form-control"    id="date11">')


        $("#hr11").empty()
       
        $("#hr11").append(' <label for="inputAddress2" class="float-left">heure 1  &nbsp; &nbsp;' + result.Appointment['Hour1'].split('T')[1] + '</label>   <input type="time" class="form-control" id="Hour11">')

        $("#hr22").empty()
        
        $("#hr22").append(' <label for="inputAddress2" class="float-left">heure 2 &nbsp; &nbsp;' + result.Appointment['Hour2'].split('T')[1] + '</label>   <input type="time" class="form-control" id="Hour22">')
        
        $("#medi11").empty()
        $("#medi11").append('Act Medical')
        $.each(result.medicicalActs, function (index, value) {
         
            var s = '  &nbsp; &nbsp;' + value.Name + '  &nbsp; &nbsp;';
            $("#medi11").append(s)
        });
        $("#noteedite").empty()
        s = result.Appointment['Notes']
       
        $("#noteedite").append('<label class= "float-left" > Notes   &nbsp; &nbsp; '+ s+'  </label>  <textarea type="text" class="form-control" id="Notes11" rows="3"    value='+s+'> </textarea>')

     
         
     
    }
    )
    
    $("#editemodal").modal('show')
   
  

}
function edite() {
    
    class Appointment {
        Id
        IdPatient1
        IdPatient2
        IdRoom1
        IdRoom2
        IdPrescribingDoctor1
        IdPrescribingDoctor2
        IdMedicalAct1
        IdMedicalAct2
        Date
        Hour1
        Hour2
        Notes
        State
        constructor() {
           
            this.Id = sessionStorage.getItem("idappointement");
            this.IdPatient1 = parseInt($("#IdPatientsinnfof").val())
            if ($("#IdPatients111info").val() != '') {


                this.IdPatient2 = parseInt($("#IdPatients111info").val())
            }
            else {
                this.IdPatient2 = 0;
            } 
            this.IdRoom1 = parseInt($("#IdRoominfo").val())

            if ($("#IdPatients111info").val() != '') {

                if ($("#IdRoom1111info").val() == '') {
                    this.IdRoom2 = parseInt($("#IdRoominfo").val());

                } else {
                    this.IdRoom2 = parseInt($("#IdRoom1111info").val())
                }
            }
            else {
                this.IdRoom2 = 0; 
            }
            this.IdPrescribingDoctor1 = parseInt($("#IdPrescribingDoctorinfo").val())

            if ($("#IdPatients111info").val() != '') {

                if ($("#IdPrescribingDoctor1111infoee").val() == '') {
                    this.IdPrescribingDoctor2 = parseInt($("#IdPrescribingDoctorinfo").val())
                }
                else {
                    this.IdPrescribingDoctor2 = parseInt($("#IdPrescribingDoctor1111infoee").val())
                }
               
            }
            else {
                this.IdPrescribingDoctor2 = 0;
            }

            this.IdMedicalAct1 = $("#IdMedicalActinfo").val();
            if ($("#IdPatients111info").val() != '') {

                if ($("#IdMedicalAct111Info").val() == '') {
                    this.IdMedicalAct2 = $("#IdMedicalActinfo").val()

                } else {
                    this.IdMedicalAct2 = parseInt($("#IdMedicalAct111Info").val())
                }
                
            }
            else {
                this.IdMedicalAct2 = 0;
            }


           


            this.State = ' EN COURS '
            if ($("#INFO").val() == '') {
                this.Date = sessionStorage.getItem("Date")
            } else {
                this.Date = $("#INFO").val()
            }
            if ($("#heur1Info").val() == '') {
                this.Hour1 = sessionStorage.getItem("Hour1")
            } else {
                this.Hour1 = $("#heur1Info").val()
            }
            if ($("#Hour2indf").val() == '') {
                this.Hour2 = sessionStorage.getItem("Hour2")
            }
            else {
                this.Hour2 = $("#Hour2indf").val()
            }
          
       
            this.Notes = $("#NotesInfo").val()
            

        }

    }

    
    $.post('/Appointment/Update', { ap: new Appointment() }, function (result) {
        if (result.status) {
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })
            setTimeout(function () {
                rechargerlecalandrer()
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
            

        };
    })
}
function addppointment() {
 
    class Appointment {
        Id
        IdPatient1
        IdPatient2
        IdRoom1
        IdRoom2
        IdPrescribingDoctor1
        IdPrescribingDoctor2
        IdMedicalAct1
        IdMedicalAct2
        Date
        Hour1
        Hour2
        Notes
        State
        constructor() {
            this.Id = 0;

            
            this.IdPatient1 = $("#IdPatients").val();

            if ($("#IdPatients111").val() != '') {
                this.IdPatient2 = $("#IdPatients111").val();



            }
            else {
              
                this.IdPatient2 =0;
            }


            this.IdRoom1 = $("#IdRoom1").val();
             
            if ($("#IdRoom1111").val() != '') {
                this.IdRoom2 = $("#IdRoom1111").val();
            }
            else {
                

                if ($("#IdPatients111").val() != '') {
                    this.IdRoom2 = $("#IdRoom1").val();
                } else {
                    this.IdRoom2 = 0;
                }
            }


            this.IdPrescribingDoctor1 = $("#IdPrescribingDoctor1").val();



            if ($("#IdPrescribingDoctor1111").val() != '') {
                this.IdPrescribingDoctor2 = $("#IdPrescribingDoctor1111").val();
            }
            else {


                if ($("#IdPatients111").val() != '') {
                    this.IdPrescribingDoctor2 = $("#IdPrescribingDoctor1").val();

                }
                else {
                    this.IdPrescribingDoctor2 =0

                }


            }

            this.IdMedicalAct1 = $("#IdMedicalAct").val();


            if ($("#IdMedicalAct111").val() != '') {
                this.IdMedicalAct2 = $("#IdMedicalAct111").val();
            }
            else {

                if ($("#IdPatients111").val() != '') {
                    this.IdMedicalAct2 = $("#IdMedicalAct").val();

                }
                else {
                    this.IdMedicalAct2 = 0;
                }
                
               
            }
            this.State = ' EN COURS '
            this.Date = $("#date").val()
            this.Hour1 = $("#Hour1").val()

            if ($("#Hour2").val() != '') {
                this.Hour2 = $("#Hour2").val()
            }
            else {
                this.Hour2 = $("#Hour1").val()
            }
           
            this.Notes = $("#Notes").val()

        }

    }

    if ($("#IdRoom1").val() == '') {

        $("#sal").show();
    }

    if ($("#IdPrescribingDoctor1").val() == '') {
        $("#doc").show();

    }

    if ($("#IdMedicalAct").val() == '') {

        $("#medi").show();
    }
    if ($("#date").val() == '') {
        $("#jr").show();


    }
    if ($("#Hour1").val() == '') {
        $("#hr1").show();}


    if ($("#IdPatients").val() == "") {
        $("#labpa").show();
    }
    if ($("#IdPatients").val() != '') {

        $("#labpa").hide();

    }






    if ($("#IdPatients").val()!= '' && $("#IdRoom1").val() != '' && $("#IdPrescribingDoctor1").val() != '' && $("#IdMedicalAct").val() != '' && $("#date").val() != '' && $("#Hour1").val() != '') {
        $.post("/Appointment/Add", { ap: new Appointment() }, function (result) {
            $("#ajoutermodal").modal('hide')
            if (result.status) {
                Swal.fire({

                    icon: 'success',
                    title: result.message,
                    showConfirmButton: false,
                    timer: 1500
                })
                setTimeout(function () {
             
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


            };

            rechargerlecalandrer()
            CreermodePourtableRdv()
        })

    } 


        
    

   

  
}