
$().ready(function () {
    $('a[data-toggle="tab"]').on('show.bs.tab', function (e) {
        localStorage.setItem('activeTab', $(e.target).attr('href'));
    });
    var activeTab = localStorage.getItem('activeTab');
    if (activeTab) {

        $('#myTab3 a[href="' + activeTab + '"]').tab('show');
    }


    $.get("/UTILITY/MedicalActs", function (result) {

        result.forEach(function (item) {
            if (item.MedicalActType == "Exploration") {
                $("#IdMedicalAct11").append('<option value=' + item.ID + '>' + item.Name + '</option>')

            }
         
        })
    })




    ModelMDAELEMENTAIRE = []
    Modelexploration = []
    $.get('/UTILITY/GetDossierMedicalPersonniser', { IdDossierMedical: sessionStorage.getItem('IdDossierMedical') }, function (donne) {
    
        $("#patientssss").empty()
        if (donne.patients.length == 1) {
            $("#patientssss").append('<option  value=' + donne.patients[0].FirstName + ' ' + donne.patients[0].LastName + '>' +  donne.patients[0].FirstName + '&nbsp; ' + donne.patients[0].LastName +'</option>')
        } else {
            $("#patientssss").append('<option  value=' + donne.patients[0].FirstName + ' ' + donne.patients[0].LastName + '>' +  donne.patients[0].FirstName + '&nbsp; ' + donne.patients[0].LastName + '</option>')
            $("#patientssss").append('<option  value=' + donne.patients[1].FirstName + ' ' + donne.patients[1].LastName + '>' +  donne.patients[1].FirstName + '&nbsp; ' + donne.patients[1].LastName + '</option>')
        }


        creerALLtavle(donne)
     
    })


    $("#Typemedicalac").change(function () {
        $('#rangze').show();
        $('#rangze').empty();

    })


})

function creerALLtavle(donne) {
    console.log(donne)
    for (i = 0; i < donne.MedicalRecordActs.length; i++) {
        donne.MedicalRecordActs[i].MedicalActName
        if (donne.MedicalRecordActs[i].MedicalActType == "Exploration") {


            var elementaire = { "Type": donne.MedicalRecordActs[i].MedicalActType, "Name": donne.MedicalRecordActs[i].MedicalActName, "Patient": donne.MedicalRecordActs[i].Patients, "State": donne.MedicalRecordActs[i].State, "Medecins": donne.doctors[i].FirstName + ' &nbsp; &nbsp;' + donne.doctors[i].LastName, 'Id': donne.MedicalRecordActs[i].Id }
            ModelMDAELEMENTAIRE.push(elementaire)

        }
        else {
            var elementaire = { "Rang": donne.MedicalRecordActs[i].Rang, "Type": donne.MedicalRecordActs[i].MedicalActType, "Name": donne.MedicalRecordActs[i].MedicalActName, "Patient": donne.MedicalRecordActs[i].Patients, "State": donne.MedicalRecordActs[i].State, "Medecins": donne.doctors[i].FirstName + ' &nbsp; &nbsp;' + donne.doctors[i].LastName, 'Id': donne.MedicalRecordActs[i].Id }
            Modelexploration.push(elementaire)

        }

    }

    creertableactemedicalexploration(ModelMDAELEMENTAIRE.reverse())
    creertableactemedicalexplorationCycle(Modelexploration.reverse())
}




function creertableactemedicalexploration(model) {
   

    if ($.fn.DataTable.isDataTable("#tableactelementaire")) {
        $('#tableactelementaire').DataTable().destroy();


    }
    $('#tableactelementaire').DataTable({
        "filter": true,
        "aaData": model,
        "sort": false,
        "aoColumns":
            [
               
                { "data": "Name", "name": " Name", "autoWidth": true },
                { "data": "Patient", "name": "Patient ", "autoWidth": true },
                { "data": "State", "name": "State", "autoWidth": true },
                { "data": "Medecins", "name": "Medecins", "autoWidth": true },
                {
                    "data": "Id", "render": function (data) {
                        return '<td class="text - right">'
                            + ' <div class="dropdown dropdown-action">'
                            + '<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>' +
                            '<div class="dropdown-menu dropdown-menu-right">' +
                            '<a class="dropdown-item" href="/DossierMedical/ConsulterActExploration?Reference=' + sessionStorage.getItem('IdDossierMedical') + '" onclick="ConsulterTRAITEMENTC(' + data + ')"><i class="fa fa-pencil m-r-5"></i>Consulter </a>' +

                            '<a class="dropdown-item" href="#modifiermedicalrecordactELEMENTAIRE" onclick="showmadalmodifierMedicalrecordactELEMENTAIRE(' + data + ')"><i class="fa fa-pencil m-r-5"></i> editer </a>' +
                            '<a class="dropdown-item" href="#deletemedicalRecored" onclick="showmadaldeleteMedicalrecordact(' + data + ')"><i class="fa fa-trash m-r-5"></i> supprimer </a>' +
                            ' <a class="dropdown-item" href="#deletemedicalRecored" onclick="terminer(' + data + ')"><i class="fa fa-stop m-r-5"></i> Terminer Act </a>' +
                            '</div>' + '</div >' + '</td >'
                    }
                }

            ],

    });




}



function creertableactemedicalexplorationCycle(model) {
  

    if ($.fn.DataTable.isDataTable("#tablemedicaleacteCycle")) {
        $('#tablemedicaleacteCycle').DataTable().destroy();


    }
    $('#tablemedicaleacteCycle').DataTable({
        "filter": true,
        "aaData": model,
        "sort": false,
        "reverse": true,
     
        "aoColumns":
            [
               
                { "data": "Name", "name": " Name", "autoWidth": true },
                { "data": "Patient", "name": "Patient ", "autoWidth": true },
                { "data": "State", "name": "State", "autoWidth": true },
                { "data": "Rang", "name": "Rang", "autoWidth": true },
                { "data": "Medecins", "name": "Medecins", "autoWidth": true },
                {
                    "data": "Id", "render": function (data) {
                        return '<td class="text - right">'
                            + ' <div class="dropdown dropdown-action">'
                            + '<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>' +
                            '<div class="dropdown-menu dropdown-menu-right">' +
                            '<a class="dropdown-item" href="/DossierMedical/ConsulterTraitementCycle?Reference=' + sessionStorage.getItem('IdDossierMedical') + '&Idtraitement='+data +'" onclick="ConsulterTRAITEMENTC(' + data + ')"><i class="fa fa-pencil m-r-5"></i>Consulter </a>' +

                            ' <a class="dropdown-item" href="#modifiermedicalrecordact" onclick="showmadalmodifierMedicalrecordact(' + data + ')"><i class="fa fa-pencil m-r-5"></i> editer </a>' +
                            '<a class="dropdown-item" href="#deletemedicalRecored" onclick="showmadaldeleteMedicalrecordact(' + data + ')"><i class="fa fa-trash m-r-5"></i> supprimer </a>' +
                            ' <a class="dropdown-item" href="#deletemedicalRecored" onclick="terminer(' + data + ')"><i class="fa fa-stop m-r-5"></i> Terminer Act </a>' +
                            '</div>' + '</div >' + '</td >'
                    }
                }

            ],

    });




}




function Reacharge() {

    ModelMDAELEMENTAIRE = []
    Modelexploration = []
    $.get('/UTILITY/GetDossierMedicalPersonniser', { IdDossierMedical: sessionStorage.getItem('IdDossierMedical') }, function (donne) {
        donne.MedicalRecordActs.length


        for (i = 0; i < donne.MedicalRecordActs.length; i++) {
            donne.MedicalRecordActs[i].MedicalActName
            if (donne.MedicalRecordActs[i].MedicalActType == "Exploration") {


                var elementaire = { "Type": donne.MedicalRecordActs[i].MedicalActType, "Name": donne.MedicalRecordActs[i].MedicalActName, "Patient": donne.MedicalRecordActs[i].Patients, "State": donne.MedicalRecordActs[i].State, "Medecins": donne.doctors[i].FirstName + ' &nbsp; &nbsp;' + donne.doctors[i].LastName, 'Id': donne.MedicalRecordActs[i].Id }
                ModelMDAELEMENTAIRE.push(elementaire)

            }
            else {
                var elementaire = { "Rang": donne.MedicalRecordActs[i].Rang, "Type": donne.MedicalRecordActs[i].MedicalActType, "Name": donne.MedicalRecordActs[i].MedicalActName, "Patient": donne.MedicalRecordActs[i].Patients, "State": donne.MedicalRecordActs[i].State, "Medecins": donne.doctors[i].FirstName + ' &nbsp; &nbsp;' + donne.doctors[i].LastName, 'Id': donne.MedicalRecordActs[i].Id }
                Modelexploration.push(elementaire)

            }

        }

        creertableactemedicalexploration(ModelMDAELEMENTAIRE.reverse())
        creertableactemedicalexplorationCycle(Modelexploration.reverse())

    })

}





function addMedicalRecordActElementaire() {
  
    sessionStorage.getItem('idmedicalrecordact')
    if ($("#patientss").val().toString() == '') {
       
        $("#e1").show();

    }
    if ($("#IdPrescribingDoctorMedial11").val() == 0) {
       
        $("#d1").show();
    }


    if ($("#IdMedicalAct11").val() == 0) {
      
        $("#h11").show();


    }
   
    if ($("#IdMedicalAct11").val() != 0 && $("#IdPrescribingDoctorMedial11").val() != 0 && $("#patientss").val().toString() != '') {




        class MedicalRecordAct {
            Id
            IdMedicalRecord
            IdPrescribingDoctorMedical
            IdMedicalAct
            Patients
            MedicalActType
            MedicalActName
            Rang
            State

            constructor() {
                this.Id = 0;
                this.IdMedicalRecord = sessionStorage.getItem('iddossier');
                this.IdPrescribingDoctorMedical = $("#IdPrescribingDoctorMedial11").val();
                this.IdMedicalAct = $("#IdMedicalAct11").val();
                this.Patients = $("#patientss").val().toString();
                this.Rang = 0;
                this.State = "en cours";
                this.MedicalActName = "";
                this.MedicalActType = "";

            }



        }
        $.post("/DossierMedical/AddMedicalRecordAct", { recordAct: new MedicalRecordAct() }, function (result) {
            if (result.status) {



                Swal.fire({

                    icon: 'success',
                    title: result.message,
                    showConfirmButton: false,
                    timer: 1500
                })

                $("#ajoutermedicalrecordactELEMENTAIRE").modal('hide');

                location.reload();
            }
            else {

                Swal.fire({

                    icon: 'error',
                    title: result.message,
                    showConfirmButton: false,
                    timer: 1500
                })

            }
            Reacharge()
        });

    }
}

function addMedicalRecordAct() {
    $("#e").hide();
    $("#d").hide();
    $("#g").hide();
    sessionStorage.getItem('idmedicalrecordact')
    if ($("#patients").val().toString() == '') {
        $("#e").show();
        $("#e1").show(); 

    }
    if ($("#IdPrescribingDoctorMedial").val() == 0) {
        $("#d").show();
        $("#d1").show();
    }


    if ($("#IdMedicalAct").val() == 0) {
        $("#h").show();
        $("#h11").show();


    }
    if ($("#MedicalActName").val() == '') {
        $("#g").show();

    }
    if ($("#IdMedicalAct").val() != 0 && $("#IdPrescribingDoctorMedial").val() != 0 && $("#patients").val().toString() !='') {

    


    class MedicalRecordAct {
        Id
        IdMedicalRecord
        IdPrescribingDoctorMedical
        IdMedicalAct
        Patients
        MedicalActType
        MedicalActName
        Rang
        State

        constructor() {
           
            this.Id = 0;
            this.IdMedicalRecord = sessionStorage.getItem('iddossier');
            this.IdPrescribingDoctorMedical = $("#IdPrescribingDoctorMedial").val();
            this.IdMedicalAct = 0;
            this.Patients = $("#patients").val().toString();


            this.Rang = 0;
            this.State = "en cours";
            this.MedicalActName = $("#MedicalActName").val();
            this.MedicalActType = "TRAITEMENT Cycle ";
           
        }



    }
        $.post("/DossierMedical/AddMedicalRecordAct", { recordAct: new MedicalRecordAct() }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })
            $("#ajoutermedicalrecordact").modal('hide')
           


        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })
         
            }
            Reacharge()
    });

    }
}
function showmadaldeleteMedicalrecordact(id) {
    sessionStorage.setItem('idmedicalrecordact', id);
  
    $("#deletemedicalRecored").modal('show');
}
function showmadalmodifierMedicalrecordactELEMENTAIRE(id) {
    sessionStorage.setItem('idmedicalrecordact', id);
  
    $.get('/MedicalAct/GetmedicalActRecordByid', { id: id }, function (re) {
      
        sessionStorage.setItem('Id', id);
        sessionStorage.setItem('MedicalActType', re.MedicalActType);
        sessionStorage.setItem('IdMedicalRecord', re.IdMedicalRecord);
        sessionStorage.setItem('IdPrescribingDoctorMedical', re.IdPrescribingDoctorMedical);
        sessionStorage.setItem('IdMedicalAct', re.IdMedicalAct);
        sessionStorage.setItem('MedicalActName', re.MedicalActName);
        sessionStorage.setItem('Rang', re.Rang);
        sessionStorage.setItem('State', re.State);
        $("#patientssss").empty()
        $('#IdMedicalAct11154').append('<option selected value="' + id + '">' + re.MedicalActName + '</option>')
        $.get('/UTILITY/GetDossierMedicalPersonniser', { IdDossierMedical: sessionStorage.getItem('IdDossierMedical') }, function (donne) {
           
         

            if (donne.patients.length == 1) {
                $("#patientssss").append('<option  value=' + donne.patients[0].FirstName + ' ' + donne.patients[0].LastName + '>' + donne.patients[0].FirstName + '&nbsp; ' + donne.patients[0].LastName + '</option>')
            } else {
                $("#patientssss").append('<option  value=' + donne.patients[0].FirstName + ' ' + donne.patients[0].LastName + '>' + donne.patients[0].FirstName + '&nbsp; ' + donne.patients[0].LastName + '</option>')
                $("#patientssss").append('<option  value=' + donne.patients[1].FirstName + ' ' + donne.patients[1].LastName + '>' + donne.patients[1].FirstName + '&nbsp; ' + donne.patients[1].LastName + '</option>')



            }
        })
        if (re.Patients.split(',').length == 1) {
            
            $("#patientssss").append('<option selected value="' + re.Patients + '">' + re.Patients + '</option>')
        } else {
            $("#patientssss").append('<option selected value=' + re.Patients.split(',')[0] + '>' + re.Patients.split(',')[0] + '</option>')
            $("#patientssss").append('<option selected value=' + re.Patients.split(',')[1] + '>' + re.Patients.split(',')[1] + '</option>')



        }
        $("#patientsedite").append('<option selected value=' + re.Patients + '>' + re.Patients + '</option>')
        sessionStorage.setItem('Patients', re.Patients);
        $("#Typemedicalac111").append('<option value=' + re.IdMedicalAct+'>' + re.MedicalActName+'</option>')
     


        $.get('/Doctor/Gets', function (re) {
            re.forEach(function (item) {
              
                if (item.Id == sessionStorage.getItem('IdPrescribingDoctorMedical')) {
                   
                    $("#IdPrescribingDoctorMedial121").append('<option   selected value=' + item.Id + '>' + item.FirstName + '&nbsp; ' + item.LastName + '</option>')
                }
            })

        })
       



    });

    $("#modifiermedicalrecordactELEMENTAIRE").modal('show');
}
function ModifierMedicalRecordActELMENTAIRE() {
    class MedicalRecordAct {
        Id
        IdMedicalRecord
        IdPrescribingDoctorMedical
        IdMedicalAct
        Patients
        MedicalActType
        MedicalActName
        Rang
        State

        constructor() {
            this.Id = sessionStorage.getItem('Id');
            this.IdMedicalRecord = sessionStorage.getItem('IdMedicalRecord');
            if ($('#IdPrescribingDoctorMedial121').val() == 0) {
                this.IdPrescribingDoctorMedical = sessionStorage.getItem('IdPrescribingDoctorMedical');
            }
            if ($('#IdPrescribingDoctorMedial121').val() != 0) {
                this.IdPrescribingDoctorMedical = $('#IdPrescribingDoctorMedial121').val()
            }
            if ($('#IdMedicalAct11').val() == 0) {
                this.IdMedicalAct = sessionStorage.getItem('IdMedicalAct');
            }
            if ($('#IdMedicalAct11').val() != 0) {
                this.IdMedicalAct = $('#IdMedicalAct11').val()
            }
          
            this.Patients = $("#patientssss").val().toString();
                this.Rang = ''
                this.State = sessionStorage.getItem('State');
                this.MedicalActName = '';



                this.MedicalActType = ''
         
        }




    }
    $.post("/MedicalAct/Updatemedicaactrecord", { medicalRecordAct: new MedicalRecordAct() }, function (result) {

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
        $("#modifiermedicalrecordactELEMENTAIRE").modal('hide');

        Reacharge()
    })

}



function showmadalmodifierMedicalrecordact(id) {
    sessionStorage.setItem('idmedicalrecordact', id);
   
    $.get('/MedicalAct/GetmedicalActRecordByid', { id: id }, function (re) {

        sessionStorage.setItem('Id', id);
        sessionStorage.setItem('MedicalActType', re.MedicalActType);
        sessionStorage.setItem('IdMedicalRecord', re.IdMedicalRecord);
        sessionStorage.setItem('IdPrescribingDoctorMedical', re.IdPrescribingDoctorMedical);
        sessionStorage.setItem('IdMedicalAct', re.IdMedicalAct);
        sessionStorage.setItem('MedicalActName', re.MedicalActName);
        sessionStorage.setItem('Rang', re.Rang);
        sessionStorage.setItem('State', re.State);
        sessionStorage.setItem('Patients', re.Patients);
        $("#patientset1").empty()
        $.get("/UTILITY/MedicalActs", function (result) {
            result.forEach(function (item) {
               
                if (item.ID == re.IdMedicalAct) {
                    $("#IdMedicalAct12").append('<option selected value=' + item.ID + '>' + item.Name + '</option>')

                }

            })
        })
        $.get('/Doctor/Gets', function (re) {
            re.forEach(function (item) {

                if (item.Id == sessionStorage.getItem('IdPrescribingDoctorMedical')) {

                    $("#IdPrescribingDoctorMedial1").append('<option   selected value=' + item.Id + '>' + item.FirstName + '&nbsp; ' + item.LastName + '</option>')
                }
            })

        })


        $.get('/UTILITY/GetDossierMedicalPersonniser', { IdDossierMedical: sessionStorage.getItem('IdDossierMedical') }, function (donne) {



            if (donne.patients.length == 1) {
                $("#patientset1").append('<option  value="' + donne.patients[0].FirstName + ' ' + donne.patients[0].LastName + '">' + donne.patients[0].FirstName + '&nbsp; ' + donne.patients[0].LastName + '</option>')
            } else {
                $("#patientset1").append('<option  value="' + donne.patients[0].FirstName + ' ' + donne.patients[0].LastName + '">' + donne.patients[0].FirstName + '&nbsp; ' + donne.patients[0].LastName + '</option>')
                $("#patientset1").append('<option  value="' + donne.patients[1].FirstName + ' ' + donne.patients[1].LastName + '">' + donne.patients[1].FirstName + '&nbsp; ' + donne.patients[1].LastName + '</option>')



            }
        })
       
        if (re.Patients.split(',').length == 1) {
           
            $("#patientset1").append('<option selected value="' + re.Patients + '">' + re.Patients + '</option>')
        } else {
            alert(re.Patients.split(',')[0])
            $("#patientset1").append('<option selected value=' + re.Patients.split(',')[0] + '>' + re.Patients.split(',')[0] + '</option>')
            $("#patientset1").append('<option selected value=' + re.Patients.split(',')[1] + '>' + re.Patients.split(',')[1] + '</option>')



        }
        $("#name1").empty()
        $("#name1").text( re.MedicalActName)
     
        if (re.MedicalActType == 'Elementaire') {
            
            

            $("#Typemedicalac1").append(' <option value="Elementaire"> Elementaire  </option>  <option value="Cycle">Cycle   </option> ')
        }
        if (re.MedicalActType == 'Cycle') {
            $("#rangf").append('<label for="inputPassword4" class="float-left">  Rang <span>*</span></label>  <input type="number" value="' + re.Rang + '" class="form-control" id="Rang1" min=0> ')

            $("#Typemedicalac1").append(' <option value="Cycle">Cycle   </option>  ')
        }

        $("#Typemedicalac1").change(function () {
            if ($("#Typemedicalac1").val() == 'Cycle') {
                sessionStorage.setItem('MedicalActType', 'Cycle');
                $("#rangf").empty();
                $("#rangf").append('<label for="inputPassword4" class="float-left">  Rang <span>*</span></label>  <input type="number" value="1" class="form-control" id="Rang1" min=0> ')

            } else {
                sessionStorage.setItem('MedicalActType', 'Elementaire');
                $("#rangf").empty();
            }
        })

    
       
    });
   
    $("#modifiermedicalrecordact").modal('show');
}
function ModifierMedicalRecordActELEMENTAIRE() {

    class MedicalRecordAct {
        Id
        IdMedicalRecord
        IdPrescribingDoctorMedical
        IdMedicalAct
        Patients
        MedicalActType
        MedicalActName
        Rang
        State

        constructor() {
            this.Id = sessionStorage.getItem('Id');
            this.IdMedicalRecord = sessionStorage.getItem('IdMedicalRecord');
            if ($('#IdPrescribingDoctorMedial111').val() == 0) {
                this.IdPrescribingDoctorMedical = sessionStorage.getItem('IdPrescribingDoctorMedical');
            }
            if ($('#IdPrescribingDoctorMedial111').val() != 0) {
                this.IdPrescribingDoctorMedical = $('#IdPrescribingDoctorMedial111').val()
            }
            if ($('#IdMedicalAct11154').val() == 0) {
                this.IdMedicalAct = sessionStorage.getItem('IdMedicalAct');
            }
            if ($('#IdMedicalAct11154').val() != 0) {
                this.IdMedicalAct = parseInt($('#IdMedicalAct11154').val())


                this.Patients = $("#patientsedite").val();
                this.Rang = ''
                this.State = "en cours";
                this.MedicalActName = '';



                this.MedicalActType =''
            }
        }




    }
    $.post("/MedicalAct/Updatemedicaactrecord", { medicalRecordAct: new MedicalRecordAct() }, function (result) {

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
        Reacharge()
    })

}

function terminer(id) {
    $.get("/UTILITY/TerminerMedicalactRecord", { id: id }, function (result) {

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
        Reacharge()

    })
}




function ModifierMedicalRecordAct() {

    class MedicalRecordAct {
        Id
        IdMedicalRecord
        IdPrescribingDoctorMedical
        IdMedicalAct
        Patients
        MedicalActType
        MedicalActName
        Rang
        State

        constructor() {
            this.Id = sessionStorage.getItem('Id');
            this.IdMedicalRecord = sessionStorage.getItem('IdMedicalRecord');
            if ($('#IdPrescribingDoctorMedial1').val() == 0) {
                this.IdPrescribingDoctorMedical = sessionStorage.getItem('IdPrescribingDoctorMedical');
            }
            if ($('#IdPrescribingDoctorMedial1').val() != 0) {
                this.IdPrescribingDoctorMedical = $('#IdPrescribingDoctorMedial1').val()
            }
            if ($('#IdMedicalAct1').val() == 0) {
                this.IdMedicalAct = sessionStorage.getItem('IdMedicalAct');
            }
            if ($('#IdMedicalAct1').val() != 0) {
                this.IdMedicalAct = $('#IdMedicalAct1').val()
            }
            alert($("#patientset1").val().toString())
            this.Patients = $("#patientset1").val().toString();
            this.Rang = sessionStorage.getItem('Rang')
            this.State = sessionStorage.getItem('State');
            this.MedicalActName = sessionStorage.getItem('MedicalActName');
           
            this.MedicalActType = sessionStorage.getItem('MedicalActType');

        }




    }
    $.post("/MedicalAct/Updatemedicaactrecord", { medicalRecordAct: new MedicalRecordAct() }, function (result) {

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
        Reacharge()
        $("#modifiermedicalrecordact").modal('hide');
    })

}
function confirmationdelete1() {
   
    $.get("/UTILITY/DeletemedicalRECORDACTE", { ID: sessionStorage.getItem('idmedicalrecordact') }, function (result) {
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
        $("#deletemedicalRecored").modal('hide');
        Reacharge()
      


    })
}



function ConsulterTRAITEMENTC(id) {

    sessionStorage.setItem("IdmedicalrecordActe", id)


}