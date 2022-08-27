$().ready(function () {


    $("#formiActDataCongelationSpermeAdd").on('submit', function (e) {
        ajouteActDataCongelationSpermefo()
        e.preventDefault()
    })

    $("#formiActDataCongelationSpermeEDI").on('submit', function (e) {
        editeActDataCongelationSpermefo()
        e.preventDefault()
    })




    $.get("/ActDataCongelationSperme/GetByIdTraitement", { Id: sessionStorage.getItem("IdmedicalrecordActe") }, function (resulta) {

        if (resulta.length == 0) {
            $("#congelationspermeInfo").hide()
            $("#congelationspermeInfo1").show()
            
            $("#boutonActDataActDataCongelationSperme").append(' <a href="#ajouteboutonActDataActDataCongelationSpermeM" onclick="showaddboutonActDataActDataCongelationSpermeM()" class="btn btn-primary"><i class="fa fa-plus"></i>  Ajouter ActDataActDataCongelationSperme </a>')
        } else {
            $("#congelationspermeInfo1").hide()
            $("#congelationspermeInfo").show()
            $("#DateDEcoronisation1").val(resulta[0].Date)
            $("#HeureDEcoronisation1").val(resulta[0].Heure)
            $("#CommentairesDEcoronisation1").val(resulta[0].Commentaires)

            $("#boutonActDataActDataCongelationSperme").append(' <a href="#modifierboutonActDataActDataCongelationSpermeM" onclick="showeditboutonActDataActDataCongelationSpermeM()" class="btn btn-primary"><i class="fa fa-plus"></i>  editer ActDataActDataCongelationSperme </a>')
            $("#IdEnbryologisteDoctorActDataCongelationSperme1").val(resulta[0].IdEnbryologisteDoctor)
            $("#IdTretingDoctorActDataCongelationSperme1").val(resulta[0].IdTretingDoctor)
            $("#DateActDataCongelationSperme1").val(resulta[0].Date)
            $("#DateesActDataCongelationSperme").text(resulta[0].Date)
            $("#heureeActDataCongelationSperme").text(resulta[0].Heure)
            $("#MilieuEE").text(resulta[0].Milieu)


            $("#HeureActDataCongelationSperme1").val(resulta[0].Heure)
            $("#MilieuActDataCongelationSperme1").val(resulta[0].Milieu)
            $("#CommentairesActDataCongelationSperme1").val(resulta[0].Commentaires)
            $("#CommentairActDataCongelationSperme").text(resulta[0].Commentaires)

        }

    })


})

function showaddboutonActDataActDataCongelationSpermeM() {

    $('#ajouteboutonActDataActDataCongelationSpermeM').modal('show')

}
function showeditboutonActDataActDataCongelationSpermeM() {
    $('#modifierboutonActDataActDataCongelationSpermeM').modal('show')
}



function ajouteActDataCongelationSpermefo() {

    $.post("/ActDataCongelationSperme/Add", {
        actData: {
            Id: 0, IdMedicalRecordAct: sessionStorage.getItem("IdmedicalrecordActe"),
            IdTretingDoctor: parseInt($("#IdTretingDoctorActDataCongelationSperme").val()), IdEnbryologisteDoctor: parseInt($("#IdEnbryologisteDoctorActDataCongelationSperme").val()),
            EmbryologisteDoctorType: "Embryogiste",
            Date: $("#DateActDataCongelationSperme").val(), Heure: $("#HeureActDataCongelationSperme").val(), Commentaires: $("#CommentairesActDataCongelationSperme").val(), Milieu: $("#MilieuActDataCongelationSperme").val()


        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#ajouteboutonActDataActDataCongelationSpermeM").modal('hide');
            $("#formiActDataCongelationSpermeAdd").trigger("reset");

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


function editeActDataCongelationSpermefo() {
    $.post("/ActDataCongelationSperme/Update", {
        actData: {
            Id: 0, IdMedicalRecordAct: sessionStorage.getItem("IdmedicalrecordActe"),
            IdTretingDoctor: parseInt($("#IdTretingDoctorActDataCongelationSperme1").val()), IdEnbryologisteDoctor: parseInt($("#IdEnbryologisteDoctorActDataCongelationSperme1").val()),
            EmbryologisteDoctorType: "Embryogiste",
            Date: $("#DateActDataCongelationSperme1").val(), Heure: $("#HeureActDataCongelationSperme1").val(), Commentaires: $("#CommentairesActDataCongelationSperme1").val(), Milieu: $("#MilieuActDataCongelationSperme1").val()


        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#modifierboutonActDataActDataCongelationSpermeM").modal('hide');

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