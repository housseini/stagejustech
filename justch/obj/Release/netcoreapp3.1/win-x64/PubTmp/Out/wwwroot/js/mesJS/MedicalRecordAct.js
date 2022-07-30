var model;
$().ready(function () {
    ModelMDAELEMENTAIRE = []
    Modelexploration = []
    $.get('/UTILITY/GetDossierMedicalPersonniser', { IdDossierMedical: sessionStorage.getItem('IdDossierMedical') }, function (donne) {


        donne.MedicalRecordActs.length


        for (i = 0; i < donne.MedicalRecordActs.length; i++) {
            donne.MedicalRecordActs[i].MedicalActName
            if (donne.MedicalRecordActs[i].MedicalActType == "ELEMENTAIRE") {


                var elementaire = { "Type": donne.MedicalRecordActs[i].MedicalActType, "Name": donne.MedicalRecordActs[i].MedicalActName, "Patient": donne.MedicalRecordActs[i].Patients, "State": donne.MedicalRecordActs[i].State, "Medecins": donne.doctors[i].FirstName + ' &nbsp; &nbsp;' + donne.doctors[i].LastName, 'Id': donne.MedicalRecordActs[i].Id }
                ModelMDAELEMENTAIRE.push(elementaire)

            }
            else {
                var elementaire = { "Rang": donne.MedicalRecordActs[i].Rang, "Type": donne.MedicalRecordActs[i].MedicalActType, "Name": donne.MedicalRecordActs[i].MedicalActName, "Patient": donne.MedicalRecordActs[i].Patients, "State": donne.MedicalRecordActs[i].State, "Medecins": donne.doctors[i].FirstName + ' &nbsp; &nbsp;' + donne.doctors[i].LastName, 'Id': donne.MedicalRecordActs[i].Id }
                Modelexploration.push(elementaire)

            }

        }

        creertableactemedicalexploration(ModelMDAELEMENTAIRE)
        creertableactemedicalexplorationCycle(Modelexploration)

    })


    $("#Typemedicalac").change(function () {
        $('#rangze').show();
        $('#rangze').empty();








        $.get("/UTILITY/CountMedicalrecordActbyIdactIddossier", { IdACT: $("#IdMedicalAct").val(), IdDosssier: sessionStorage.getItem('iddossier') }, function (re) {

            t = re + 1;
            var s = ' <label for="inputPassword4" class="float-left">  Rang <span>*</span></label> ' +

                '<input type = "number" class="form-control"  value =' + t + ' id = "Rang" min = 0 >';
            $('#rangze').append(s);
            if ($("#Typemedicalac").val() == 'Elementaire') {
                $('#rangze').hide();
                $('#rangze').empty();
            }
        })
    })


})


function creertableactemedicalexploration(model) {
    if ($.fn.DataTable.isDataTable("#tableactelementaire")) {
        $('#tableactelementaire').DataTable().destroy();


    }
    $('#tableactelementaire').DataTable({
        "filter": true,
        "aaData": model,
        "aoColumns":
            [
                { "data": "Type", "name": "Type", "autoWidth": true },
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
        "aoColumns":
            [
                { "data": "Type", "name": "Type", "autoWidth": true },
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
            if (donne.MedicalRecordActs[i].MedicalActType == "ELEMENTAIRE") {


                var elementaire = { "Type": donne.MedicalRecordActs[i].MedicalActType, "Name": donne.MedicalRecordActs[i].MedicalActName, "Patient": donne.MedicalRecordActs[i].Patients, "State": donne.MedicalRecordActs[i].State, "Medecins": donne.doctors[i].FirstName + ' &nbsp; &nbsp;' + donne.doctors[i].LastName, 'Id': donne.MedicalRecordActs[i].Id }
                ModelMDAELEMENTAIRE.push(elementaire)

            }
            else {
                var elementaire = { "Rang": donne.MedicalRecordActs[i].Rang, "Type": donne.MedicalRecordActs[i].MedicalActType, "Name": donne.MedicalRecordActs[i].MedicalActName, "Patient": donne.MedicalRecordActs[i].Patients, "State": donne.MedicalRecordActs[i].State, "Medecins": donne.doctors[i].FirstName + ' &nbsp; &nbsp;' + donne.doctors[i].LastName, 'Id': donne.MedicalRecordActs[i].Id }
                Modelexploration.push(elementaire)

            }

        }

        creertableactemedicalexploration(ModelMDAELEMENTAIRE)
        creertableactemedicalexplorationCycle(Modelexploration)

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
            this.IdMedicalAct = $("#IdMedicalAct").val();
            this.Patients = $("#patients").val().toString();
            this.Rang = $("#Rang").val();
            this.State = "en cours";
            this.MedicalActName = $("#MedicalActName").val();
            this.MedicalActType = $("#Typemedicalac").val();
           
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

        $("#patientsedite").append('<option selected value=' + re.Patients + '>' + re.Patients + '</option>')
        sessionStorage.setItem('Patients', re.Patients);
        $("#Typemedicalac111").append('<option value=' + re.IdMedicalAct+'>' + re.MedicalActName+'</option>')
        $.get("/UTILITY/MedicalActs", function (result) {
            result.forEach(function (item) {
                if (item.MedicalActType == "Elementaire" || item.MedicalActType == "ELEMENTAIRE") {
                    $("#Typemedicalac111").append('<option value=' + item.Id+'>'+item.Name+'</option>')
                }
            })
        })
       



    });

    $("#modifiermedicalrecordactELEMENTAIRE").modal('show');
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
        $("#name1").empty()
        $("#name1").append('<label class="float-left">Medical Act Name  </label> <input type="text" value="' + re.MedicalActName + '" class="form-control" id="MedicalActName1">')
        $("#patients1").empty()
        $("#patients1").append('<label for="inputState" class="float-left">Patients  </label> <br> <br> <h >' + re.Patients + '</h>')
        if (re.MedicalActType == 'Elementaire') {
            
           

            $("#Typemedicalac1").append(' <option value="Elementaire"> Elementaire  </option>  <option value="Cycle">Cycle   </option> ')
        }
        if (re.MedicalActType == 'Cycle') {
            $("#rangf").append('<label for="inputPassword4" class="float-left">  Rang <span>*</span></label>  <input type="number" value="' + re.Rang + '" class="form-control" id="Rang1" min=0> ')

            $("#Typemedicalac1").append(' <option value="Cycle">Cycle   </option>  <option value="Elementaire"> Elementaire  </option>  ')
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
            if ($('#Typemedicalac111').val() == 0) {
                this.IdMedicalAct = sessionStorage.getItem('IdMedicalAct');
            }
            if ($('#Typemedicalac111').val() != 0) {
                this.IdMedicalAct = $('#Typemedicalac111').val()


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
            
            this.Patients = sessionStorage.getItem('Patients');
            this.Rang = $("#Rang1").val();
            this.State = "en cours";
            this.MedicalActName = $("#MedicalActName1").val();
           
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
    })

}
function confirmationdelete() {
   
    $.get("/DossierMedical/DeleteMedicalRecordAct", { id: sessionStorage.getItem('idmedicalrecordact') }, function (result) {
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
        $("#deletemedicalRecored").modal('hide');


    })
}