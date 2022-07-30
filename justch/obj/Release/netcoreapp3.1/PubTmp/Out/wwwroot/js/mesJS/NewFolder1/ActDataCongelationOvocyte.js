$().ready(function () {
    $.get("/ActDataCongelationOvocyte/GetByIdTraitement", { Id: sessionStorage.getItem("IdmedicalrecordActe") }, function (resulta) {

        if (resulta.length == 0) {
            $("#boutonActDataCongelationOvocyte").append(' <a href="#AjouterActDataCongelationOvocyteM" onclick="showaddActDataCongelationOvocyte()" class="btn btn-primary"><i class="fa fa-plus"></i>  Ajouter Act Data Congelation Ovocyte </a>')
        } else {
            $("#boutonActDataCongelationOvocyte").append(' <a href="#EditerActDataCongelationOvocyteM" onclick="showaediteActDataCongelationOvocyte()" class="btn btn-primary"><i class="fa fa-plus"></i>  Editer Act Data Congelation Ovocyte </a>')

            $("#CommentaireActDataCongelationOvocyte").text(resulta[0].Commentaires)
            $("#CommentairesOvcyteCongeles1").val(resulta[0].Commentaires)
            $("#NombreeCongélationCongelationOvocyte").text(resulta[0].NombreOvocyteCongeles)
            $("#NombreOvcyteCongeles1").val(resulta[0].NombreOvocyteCongeles)


            $.get("/OvocyteCongelationData/GetByIdTraitement", { Id: resulta[0].Id }, function (res) {
                if (res.length == 0) {
                    sessionStorage.setItem("IdActDataCongelationOvocyte", resulta[0].Id)
                    $("#boutonActDataCongelationOvocyte").append(' <a href="#EditerActDataCongelationOvocyteM" onclick="showaediteActDataCongelationOvocyte()" class="btn btn-primary"><i class="fa fa-plus"></i>  Editer Act Data Congelation Ovocyte </a>')

                    $("#boutonActDataCongelationOvocyte").append(' <a href="#ajouterCongelationOvocyteDataM" onclick="showaddajouterCongelationOvocyteDataMData()" class="btn btn-primary"><i class="fa fa-plus"></i>  ajouter Congelation Ovocyte Data </a>')


                } else {
                    sessionStorage.setItem("IdActDataCongelationOvocyte", resulta[0].Id)

                    $("#boutonCongelationOvocyteDATA").append(' <a href="#editerCongelationOvocyteDataM" onclick="ShowediterCongelationOvocyteDataM()" class="btn btn-primary"><i class="fa fa-plus"></i>  Editer ongelation Ovocyte data </a>')
                    $("#DateeOvocyteCongelationData").text(res[0].Date)
                    $("#DateCongelationOvocyteData1").val(res[0].Date)

                    $("#IdEnbryologisteDoctorOvocyteCongelationData1").val(res[0].IdEnbryologisteDoctor)

                    $("#HeureeOvocyteCongelationData").text(res[0].Heure)
                    $("#HeureCongelationOvocyteData1").val(res[0].Heure)

                    $("#NumeroOvocyteCongelationData").text(res[0].NumeroOvocyte)
                    $("#NumeroCongelationOvocyteData1").val(res[0].NumeroOvocyte)

                    $("#jourCongelationOvocyteCongelationData").text(res[0].jourCongelation)
                    $("#jourCongelationCongelationOvocyteData1").val(res[0].jourCongelation)

              

                    $("#MilieueOvocyteCongelationData").text(res[0].Milieu)
                    $("#MilieuCongelationOvocyteData1").val(res[0].Milieu)

                    $("#StatueOvocyteCongelationData").text(res[0].Statu)
                    $("#StatuCongelationOvocyteData1").val(res[0].Statu)
                    $("#CommentairesCongelationOvocyteData1").val(res[0].Commentaires)

                    $("#CommentaireseOvocyteCongelationData").text(res[0].Commentaires)
                    $("#IdPailleCongelationOvocyteData1").val(res[0].Id)






                    $.get("/Paillette/GetById", { Id: res[0].IdPaillette }, function (re) {

                        $('#PailletteeOvocyteCongelationData').text(' .')

                        $('#PailletteeOvocyteCongelationData').css("background-color", re[0].Couleur)
                        $('#IdPailleCongelationOvocyteData1').css("background-color", re[0].Couleur)

                    })

                    /*   $("#PailletteeOvocyteCongelationData").css(res[0].Heure)*/


                }


            })



        }
    })





    //$('#IdPailleOvocyteCongelationData').change(function (event) {




    //    $.get("/Paillette/GetById", { Id: event.target.value }, function (re) {


    //        $('#IdPailleOvocyteCongelationData').css("background-color", re[0].Couleur)

    //    })
    //    //    $('#IdVisotube').css("background-color", event.target.value)
    //})

    //$('#IdPailleOvocyteCongelationData1').change(function (event) {




    //    $.get("/Paillette/GetById", { Id: event.target.value }, function (re) {


    //        $('#IdPailleOvocyteCongelationData1').css("background-color", re[0].Couleur)

    //    })
    //    //    $('#IdVisotube').css("background-color", event.target.value)
    //})


    //$.get("/Paillette/Gets", function (re) {
    //    for (i = 0; i < re.length; i++) {

    //        $("#IdPailleOvocyteCongelationData").append('<option id="' + re[i].Couleur.split("#")[1] + '"   value="' + re[i].Id + '">  </option>')
    //        $('' + re[i].Couleur).css("background-color", re[i].Couleur)
    //        $("#IdPailleOvocyteCongelationData1").append('<option id="' + re[i].Couleur.split("#")[1] + 1 + '"   value="' + re[i].Id + '">  </option>')
    //        $('' + re[i].Couleur).css("background-color", re[i].Couleur + 1)
    //    }
    //})


    $("#formActDataCongelationOvocyteMAdd").on('submit', function (e) {
        AjouterActDataCongelationOvocytefo()
        e.preventDefault()


    })


    $("#formActDataCongelationOvocyteMEditer").on('submit', function (e) {
        editerActDataCongelationOocytefo()
        e.preventDefault()


    })


    $("#formCongelationOvocyteData").on('submit', function (e) {
        AjouterOvocyteCongelationDatafo()
        e.preventDefault()


    })


    $("#formCongelationOvocyteDataedite").on('submit', function (e) {
        EditerOvocyteCongelationDatafo()
        e.preventDefault()


    })











})


function showaddActDataCongelationOvocyte() {
    $("#AjouterActDataCongelationOvocyteM").modal('show')
}

function showaediteActDataCongelationOvocyte() {
    $("#EditerActDataCongelationOvocyteM").modal('show')
}

function AjouterActDataCongelationOvocytefo() {
    $.post("/ActDataCongelationOvocyte/Add", {
        actData: {
            Id: 0, IdMedicalRecordAct: sessionStorage.getItem("IdmedicalrecordActe"),
            NombreOvocyteCongeles: parseInt($("#NombreOvcyteCongeles").val()), Commentaires: ($("#CommentairesOvcyteCongeles").val())
        }
    }, function (result) {
        if (result.status) {
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#AjouterActDataCongelationOvocyteM").modal('hide');
            $("#formActDataCongelationOvocyteMAdd").trigger("reset");
            window.location.reload();



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

function editerActDataCongelationOocytefo() {

    $.post("/ActDataCongelationOvocyte/Update", {
        actData: {
            Id: 0, IdMedicalRecordAct: sessionStorage.getItem("IdmedicalrecordActe"),
            NombreOvocyteCongeles: parseInt($("#NombreOvcyteCongeles1").val()), Commentaires: ($("#CommentairesOvcyteCongeles1").val())
        }
    }, function (result) {
        if (result.status) {
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#EditerActDataCongelationOvocyteM").modal('hide');
       
            window.location.reload();



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

function showaddajouterCongelationOvocyteDataMData() {

    $("#ajouterCongelationOvocyteDataM").modal('show')

}

function AjouterOvocyteCongelationDatafo() {

    $.post("/OvocyteCongelationData/Add", {
        actData: {
            Id: 0, IdActDataCongelationOvocyte: sessionStorage.getItem("IdActDataCongelationOvocyte"),
            IdPaillette: parseInt($("#IdPailleCongelationOvocyteData").val()),
            IdEnbryologisteDoctor: parseInt($("#IdEnbryologisteDoctorCongelationOvocyteData").val()),
            EmbryologisteDoctorType: "Embryologiste",
            jourCongelation: parseInt($("#jourCongelationCongelationOvocyteData").val()),
            Heure: ($("#HeureCongelationOvocyteData").val()),
            Date: ($("#DateCongelationOvocyteData").val()),
            Commentaires: ($("#CommentairesCongelationOvocyteData").val()),
            Milieu: ($("#MilieuCongelationOvocyteData").val()),
            Statu: ($("#StatuCongelationOvocyteData").val()),
            NumeroOvocyte: parseInt($("#NumeroCongelationOvocyteData").val())
        }
    }, function (result) {
        if (result.status) {
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#ajouterCongelationOvocyteDataM").modal('hide');
            $("#formCongelationOvocyteData").trigger("reset");
            window.location.reload();



        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })





        }



    })


}

function ShowediterCongelationOvocyteDataM() {
    $("#editerCongelationOvocyteDataM").modal('show')
}


function EditerOvocyteCongelationDatafo() {
    $.post("/OvocyteCongelationData/Update", {
        actData: {
            Id: 0, IdActDataCongelationOvocyte: sessionStorage.getItem("IdActDataCongelationOvocyte"),
            IdPaillette: parseInt($("#IdPailleCongelationOvocyteData1").val()),
            IdEnbryologisteDoctor: parseInt($("#IdEnbryologisteDoctorCongelationOvocyteData1").val()),
            EmbryologisteDoctorType: "Embryologiste",
            jourCongelation: parseInt($("#jourCongelationCongelationOvocyteData1").val()),
            Heure: ($("#HeureCongelationOvocyteData1").val()),
            Date: ($("#DateCongelationOvocyteData1").val()),
            Commentaires: ($("#CommentairesCongelationOvocyteData1").val()),
            Milieu: ($("#MilieuCongelationOvocyteData1").val()),
            Statu: ($("#StatuCongelationOvocyteData1").val()),
            NumeroOvocyte: parseInt($("#NumeroCongelationOvocyteData1").val())
        }
    }, function (result) {
        if (result.status) {
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#editerCongelationOvocyteDataM").modal('hide');
            window.location.reload();



        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })





        }



    })


}