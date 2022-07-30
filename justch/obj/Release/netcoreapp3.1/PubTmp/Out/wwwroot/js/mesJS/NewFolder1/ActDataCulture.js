
$().ready(function () {

    $('#IdJ1Incubateur11').change(function () {
        $("#J1Chambres11").empty();

        $.get("/Incubateur_Chambre/GetsChambreByIdncubateur", { Id: parseInt($("#IdJ1Incubateur11").val()) }, function (re1) {


            for (i = 0; i < re1.length; i++) {

                $("#J1Chambres11").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#J1Chambres11").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
            }
        })


    })


    $('#IdJ2Incubateur11').change(function () {
        $("#J2Chambres11").empty();

        $.get("/Incubateur_Chambre/GetsChambreByIdncubateur", { Id: parseInt($("#IdJ2Incubateur11").val()) }, function (re1) {


            for (i = 0; i < re1.length; i++) {

                $("#J2Chambres11").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#J2Chambres11").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
            }
        })


    })
    $('#IdJ3Incubateur11').change(function () {
        $("#J3Chambres11").empty();

        $.get("/Incubateur_Chambre/GetsChambreByIdncubateur", { Id: parseInt($("#IdJ3Incubateur11").val()) }, function (re1) {


            for (i = 0; i < re1.length; i++) {

                $("#J3Chambres11").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#J3Chambres11").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
            }
        })


    })
    $('#IdJ4Incubateur11').change(function () {
        $("#J4Chambres11").empty();

        $.get("/Incubateur_Chambre/GetsChambreByIdncubateur", { Id: parseInt($("#IdJ4Incubateur11").val()) }, function (re1) {


            for (i = 0; i < re1.length; i++) {

                $("#Chambree11").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#J4Chambres11").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
            }
        })


    })
    $('#IdJ5Incubateur11').change(function () {
        $("#J5Chambres11").empty();

        $.get("/Incubateur_Chambre/GetsChambreByIdncubateur", { Id: parseInt($("#IdJ5Incubateur11").val()) }, function (re1) {


            for (i = 0; i < re1.length; i++) {

                $("#J5Chambres11").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#J5Chambres11").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
            }
        })


    })
    $('#IdJ6Incubateur11').change(function () {
        $("#J6Chambres11").empty();

        $.get("/Incubateur_Chambre/GetsChambreByIdncubateur", { Id: parseInt($("#IdJ6Incubateur11").val()) }, function (re1) {


            for (i = 0; i < re1.length; i++) {

                $("#J6Chambres11").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#J6Chambres11").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
            }
        })


    })

    $.get("/ActDataCulture/GetByIdTraitement", { Id: sessionStorage.getItem("IdmedicalrecordActe") }, function (resulta) {

        if (resulta.length == 0) {
            $("#boutonActDataCulturee").append(' <a href="#AjouterActDataCultureM" onclick="showaddActDataCulture()" class="btn btn-primary"><i class="fa fa-plus"></i>  Ajouter  ActDataCulture </a>')
        } else {



            $("#boutonActDataCulturee").append(' <a href="#EditerActDataCultureM" onclick="showEditerActDataCulture()" class="btn btn-primary"><i class="fa fa-plus"></i>  Editer  ActDataCulture </a>')

            modeggsl = []

            $.get("/Incubateur_Chambre/GETS", function (re) {
                modeggsl.push(re)
            })
            sessionStorage.setItem("IdActDataCulture", resulta[0].Id)




            $.get("/CulureOvocyteData/GetByIdTraitement", { Id: resulta[0].Id }, function (resulta) {

                if (resulta.length == 0) {
                    $("#boutonCultureOvocyte").append(' <a href="#AjouterCultureOvocyte" onclick="showaddCultureOvocyte()" class="btn btn-primary"><i class="fa fa-plus"></i>    Ajouter Culture Ovocyte </a>')

                } else {
                    $("#boutonCultureOvocyte").append(' <a href="#EditerCultureOvocyte" onclick="showEditerCultureOvocyte()" class="btn btn-primary"><i class="fa fa-plus"></i>    Editer Culture Ovocyte </a>')
                    $("#OvocytesCultureNumeroOvocyte1").text(resulta[0].OvocytesCultureNumeroOvocyte)
                    $("#OvocytesCultureJour1").text(resulta[0].OvocytesCultureJour)
                    $("#OvocytesCultureGrade1").text(resulta[0].OvocytesCultureGrade)


                    $("#OvocytesCultureNumeroOvocyte11").val(resulta[0].OvocytesCultureNumeroOvocyte)
                    $("#OvocytesCultureJour11").val(resulta[0].OvocytesCultureJour)
                    $("#OvocytesCultureGrade11").val(resulta[0].OvocytesCultureGrade)

                }
            })

            $.get("/DevenirEmbryon/GetByIdTraitement", { Id: resulta[0].Id }, function (resulta) {

                if (resulta.length == 0) {
                    $("#boutonDevenirEmbryon").append(' <a href="#AjouterDevenirEmbryon" onclick="showaddDevenirEmbryon()" class="btn btn-primary"><i class="fa fa-plus"></i>    Ajouter  Embryon</a>')

                } else {
                    $("#boutonDevenirEmbryon").append(' <a href="#EditerDevenirEmbryon" onclick="showEditerDevenirEmbryon()" class="btn btn-primary"><i class="fa fa-plus"></i>   Editer DevenirEmbryon</a>')
                    $("#NumeroEmbryon111").text(resulta[0].NumeroEmbryon)
                    $("#Devenir11").text(resulta[0].Devenir)
           


                    $("#NumeroEmbryonC1").val(resulta[0].NumeroEmbryon)
                    $("#Devenir1").val(resulta[0].Devenir)

                }
            })

            $("#J1Date1").text(resulta[0].J1Date)
            $("#J1Heure1").text(resulta[0].J1Heure)
            $("#J1Chambres1").text(resulta[0].J1Chambres)


            $("#J1Date11").val(resulta[0].J1Date)
            $("#J1Heure11").val(resulta[0].J1Heure)
            $("#J1Chambres11").val(resulta[0].J1Chambres)
            $("IdJ1EmbryologisteDoctor11").val(resulta[0].IdJ1EmbryologisteDoctor)
            $("#IdJ1Incubateur11").val(resulta[0].IdJ1Incubateur);

            $.get("/Incubateur_Chambre/Get", { Id: resulta[0].IdJ1Incubateur }, function (re) {
                $("#IdJ1Incubateur1").text(re.NomIncubateur);
            })

            $("#J2Date1").text(resulta[0].J2Date)
            $("#J2Heure1").text(resulta[0].J2Heure)
            $("#J2Chambres1").text(resulta[0].J2Chambres)


            $("#J2Date11").val(resulta[0].J2Date)
            $("#J2Heure11").val(resulta[0].J2Heure)
            $("#J2Chambres11").val(resulta[0].J2Chambres)
            $("IdJ2EmbryologisteDoctor11").val(resulta[0].IdJ2EmbryologisteDoctor)
            $("#IdJ2Incubateur11").val(resulta[0].IdJ2Incubateur);



            $.get("/Incubateur_Chambre/Get", { Id: resulta[0].IdJ2Incubateur }, function (re) {
                $("#IdJ2Incubateur1").text(re.NomIncubateur);
            })

            $("#J3Date1").text(resulta[0].J3Date)
            $("#J3Heure1").text(resulta[0].J3Heure)
            $("#J3Chambres1").text(resulta[0].J3Chambres)


            $("#J3Date11").val(resulta[0].J3Date)
            $("#J3Heure11").val(resulta[0].J3Heure)
            $("#J3Chambres11").val(resulta[0].J3Chambres)
            $("IdJ3EmbryologisteDoctor11").val(resulta[0].IdJ3EmbryologisteDoctor)
            $("#IdJ3Incubateur11").val(resulta[0].IdJ3Incubateur);





            $.get("/Incubateur_Chambre/Get", { Id: resulta[0].IdJ3Incubateur }, function (re) {
                $("#IdJ3Incubateur1").text(re.NomIncubateur);
            })

            $("#J4Date1").text(resulta[0].J4Date)
            $("#J4Heure1").text(resulta[0].J4Heure)
            $("#J4Chambres1").text(resulta[0].J4Chambres)





            $("#J4Date11").val(resulta[0].J4Date)
            $("#J4Heure11").val(resulta[0].J4Heure)
            $("#J4Chambres11").val(resulta[0].J4Chambres)
            $("IdJ4EmbryologisteDoctor11").val(resulta[0].IdJ4EmbryologisteDoctor)
            $("#IdJ4Incubateur11").val(resulta[0].IdJ4Incubateur);




            $.get("/Incubateur_Chambre/Get", { Id: resulta[0].IdJ4Incubateur }, function (re) {
                $("#IdJ4Incubateur1").text(re.NomIncubateur);
            })

            $("#J5Date1").text(resulta[0].J5Date)
            $("#J5Heure1").text(resulta[0].J5Heure)
            $("#J5Chambres1").text(resulta[0].J5Chambres)


            $("#J5Date11").val(resulta[0].J5Date)
            $("#J5Heure11").val(resulta[0].J5Heure)
            $("#J5Chambres11").val(resulta[0].J5Chambres)
            $("IdJ5EmbryologisteDoctor11").val(resulta[0].IdJ5EmbryologisteDoctor)
            $("#IdJ5Incubateur11").val(resulta[0].IdJ5Incubateur);




            $.get("/Incubateur_Chambre/Get", { Id: resulta[0].IdJ5Incubateur }, function (re) {
                $("#IdJ5Incubateur1").text(re.NomIncubateur);
            })

            $("#J6Date1").text(resulta[0].J6Date)
            $("#J6Heure1").text(resulta[0].J6Heure)
            $("#J6Chambres1").text(resulta[0].J6Chambres)


            $("#J6Date11").val(resulta[0].J6Date)
            $("#J6Heure11").val(resulta[0].J6Heure)
            $("#J6Chambres11").val(resulta[0].J6Chambres)
            $("IdJ6EmbryologisteDoctor11").val(resulta[0].IdJ6EmbryologisteDoctor)
            $("#IdJ6Incubateur11").val(resulta[0].IdJ6Incubateur);



            $.get("/Incubateur_Chambre/Get", { Id: resulta[0].IdJ6Incubateur }, function (re) {
                $("#IdJ6Incubateur1").text(re.NomIncubateur);
            })



        }
    })
    $("#formActDataCulture").on('submit', function (e) {
        AjouterformActDataCulture()
        e.preventDefault()
    })

    $("#formEDITEActDataCulture").on('submit', function (e) {
       EditerformActDataCulture()
        e.preventDefault()
    })


    $("#formAjouterCultureOvocyte").on('submit', function (e) {
        AjouterCultureOvocyte()
        e.preventDefault()
    })


    $("#formEditerCultureOvocyte").on('submit', function (e) {
        EditerCultureOvocyte()
        e.preventDefault()
    })

    $("#formAjouterDevenirEmbryon").on('submit', function (e) {
        AjouterDevenirEmbryon()
        e.preventDefault()
    })


    $("#formEditeDevenirEmbryon").on('submit', function (e) {
        EditeDevenirEmbryon()
        e.preventDefault()
    })


    
    

})





function showaddActDataCulture() {
    $("#AJOUTEActDataCultureM").modal("show")
}



function AjouterformActDataCulture() {
    $.post("/ActDataCulture/Add", {
        actData: {
            Id: 0, IdMedicalRecordAct: sessionStorage.getItem("IdmedicalrecordActe"),
            IdJ1EmbryologisteDoctor: parseInt($("#IdJ1EmbryologisteDoctor").val()),
            IdJ2EmbryologisteDoctor: parseInt($("#IdJ2EmbryologisteDoctor").val()),
            IdJ3EmbryologisteDoctor: parseInt($("#IdJ3EmbryologisteDoctor").val()),
            IdJ4EmbryologisteDoctor: parseInt($("#IdJ4EmbryologisteDoctor").val()),
            IdJ5EmbryologisteDoctor: parseInt($("#IdJ5EmbryologisteDoctor").val()),
            IdJ6EmbryologisteDoctor: parseInt($("#IdJ6EmbryologisteDoctor").val()),
            J1Chambres: ($("#J1Chambres").val()),
            J2Chambres: ($("#J2Chambres").val()),
            J3Chambres: ($("#J3Chambres").val()),
            J4Chambres: ($("#J4Chambres").val()),
            J5Chambres: ($("#J5Chambres").val()),
            J6Chambres: ($("#J6Chambres").val()),
            J1Date: ($("#J1Date").val()),
            J2Date: ($("#J2Date").val()),
            J3Date: ($("#J3Date").val()),
            J4Date: ($("#J4Date").val()),
            J5Date: ($("#J5Date").val()),
            J6Date: ($("#J6Date").val()),
            J1Heure: ($("#J1Heure").val()),
            J2Heure: ($("#J2Heure").val()),
            J3Heure: ($("#J3Heure").val()),
            J4Heure: ($("#J4Heure").val()),
            J5Heure: ($("#J5Heure").val()),
            J6Heure: ($("#J6Heure").val()),
            IdJ1Incubateur: parseInt($("#IdJ1Incubateur").val()),
            IdJ2Incubateur: parseInt($("#IdJ2Incubateur").val()),
            IdJ3Incubateur: parseInt($("#IdJ3Incubateur").val()),
            IdJ4Incubateur: parseInt($("#IdJ4Incubateur").val()),
            IdJ5Incubateur: parseInt($("#IdJ5Incubateur").val()),
            IdJ6Incubateur: parseInt($("#IdJ6Incubateur").val()),
            J1EmbryologisteDoctorType: "Embryogiste",
            J2EmbryologisteDoctorType: "Embryogiste",
            J3EmbryologisteDoctorType: "Embryogiste",
            J4EmbryologisteDoctorType: "Embryogiste",
            J5EmbryologisteDoctorType: "Embryogiste",
            J6EmbryologisteDoctorType: "Embryogiste"
          
        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#AJOUTEActDataCultureM").modal('hide');
            $("#formActDataCulture").trigger("reset");
            window.location.reload()



        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })

        }



    })
}

function showEditerActDataCulture() {
    $("#EditerActDataCultureM").modal('show')
}

function EditerformActDataCulture() {
    $.post("/ActDataCulture/Update", {
        actData: {
            Id: 0, IdMedicalRecordAct: sessionStorage.getItem("IdmedicalrecordActe"),
            IdJ1EmbryologisteDoctor: parseInt($("#IdJ1EmbryologisteDoctor11").val()),
            IdJ2EmbryologisteDoctor: parseInt($("#IdJ2EmbryologisteDoctor11").val()),
            IdJ3EmbryologisteDoctor: parseInt($("#IdJ3EmbryologisteDoctor11").val()),
            IdJ4EmbryologisteDoctor: parseInt($("#IdJ4EmbryologisteDoctor11").val()),
            IdJ5EmbryologisteDoctor: parseInt($("#IdJ5EmbryologisteDoctor11").val()),
            IdJ6EmbryologisteDoctor: parseInt($("#IdJ6EmbryologisteDoctor11").val()),
            J1Chambres: ($("#J1Chambres11").val()),
            J2Chambres: ($("#J2Chambres11").val()),
            J3Chambres: ($("#J3Chambres11").val()),
            J4Chambres: ($("#J4Chambres11").val()),
            J5Chambres: ($("#J5Chambres11").val()),
            J6Chambres: ($("#J6Chambres11").val()),
            J1Date: ($("#J1Date11").val()),
            J2Date: ($("#J2Date11").val()),
            J3Date: ($("#J3Date11").val()),
            J4Date: ($("#J4Date11").val()),
            J5Date: ($("#J5Date11").val()),
            J6Date: ($("#J6Date11").val()),
            J1Heure: ($("#J1Heure11").val()),
            J2Heure: ($("#J2Heure11").val()),
            J3Heure: ($("#J3Heure11").val()),
            J4Heure: ($("#J4Heure11").val()),
            J5Heure: ($("#J5Heure11").val()),
            J6Heure: ($("#J6Heure11").val()),
            IdJ1Incubateur: parseInt($("#IdJ1Incubateur11").val()),
            IdJ2Incubateur: parseInt($("#IdJ2Incubateur11").val()),
            IdJ3Incubateur: parseInt($("#IdJ3Incubateur11").val()),
            IdJ4Incubateur: parseInt($("#IdJ4Incubateur11").val()),
            IdJ5Incubateur: parseInt($("#IdJ5Incubateur11").val()),
            IdJ6Incubateur: parseInt($("#IdJ6Incubateur11").val()),
            J1EmbryologisteDoctorType: "Embryogiste",
            J2EmbryologisteDoctorType: "Embryogiste",
            J3EmbryologisteDoctorType: "Embryogiste",
            J4EmbryologisteDoctorType: "Embryogiste",
            J5EmbryologisteDoctorType: "Embryogiste",
            J6EmbryologisteDoctorType: "Embryogiste"

        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#EditerActDataCultureM").modal('hide');
            $("#formEDITEActDataCulture").trigger("reset");
            window.location.reload()



        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })

        }



    })

}


function showaddCultureOvocyte() {
    $("#AjouterCultureOvocyte").modal('show')

}

function AjouterCultureOvocyte() {

    $.post("/CulureOvocyteData/Add", {
        actData: {
            Id: 0, IdActDataCulture: sessionStorage.getItem("IdActDataCulture"),
            OvocytesCultureNumeroOvocyte: parseInt($("#OvocytesCultureNumeroOvocyte").val()),
            OvocytesCultureJour: parseInt($("#OvocytesCultureJour").val()),
            OvocytesCultureGrade: ($("#OvocytesCultureGrade").val())
       

        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#AjouterCultureOvocyte").modal('hide');
            $("#formAjouterCultureOvocyte").trigger("reset");

            window.location.reload()


        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })

        }



    })

}

function showEditerCultureOvocyte() {
    $("#EditerCultureOvocyte").modal('show')

}

function EditerCultureOvocyte() {
    $.post("/CulureOvocyteData/Update", {
        actData: {
            Id: 0, IdActDataCulture: sessionStorage.getItem("IdActDataCulture"),
            OvocytesCultureNumeroOvocyte: parseInt($("#OvocytesCultureNumeroOvocyte11").val()),
            OvocytesCultureJour: parseInt($("#OvocytesCultureJour11").val()),
            OvocytesCultureGrade: ($("#OvocytesCultureGrade11").val())


        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#EditerCultureOvocyte").modal('hide');
            $("#formEditerCultureOvocyte").trigger("reset");

            window.location.reload()


        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })

        }



    })

}

function showaddDevenirEmbryon() {
    $("#AjouterDevenirEmbryon").modal('show')
}

function AjouterDevenirEmbryon() {

    $.post("/DevenirEmbryon/Add", {
        actData: {
            Id: 0, IdActDataCulture: sessionStorage.getItem("IdActDataCulture"),
            NumeroEmbryon: parseInt($("#NumeroEmbryonC").val()),
          
            Devenir: ($("#Devenir").val())


        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#AjouterDevenirEmbryon").modal('hide');
            $("#formAjouterDevenirEmbryon").trigger("reset");

            window.location.reload()


        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })

        }



    })
}


function showEditerDevenirEmbryon() {
    $("#EditerDevenirEmbryon").modal('show')

}

function EditeDevenirEmbryon() {
    $.post("/DevenirEmbryon/Update", {
        actData: {
            Id: 0, IdActDataCulture: sessionStorage.getItem("IdActDataCulture"),
            NumeroEmbryon: parseInt($("#NumeroEmbryonC1").val()),

            Devenir: ($("#Devenir1").val())


        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#EditerDevenirEmbryon").modal('hide');
            $("#formEditeDevenirEmbryon").trigger("reset");

            window.location.reload()


        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })

        }



    })

}