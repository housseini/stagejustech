$().ready(function () {


    $("#formiBiopsieTesticulaireAdd").on('submit', function (e) {
        ajouteBiopsieTesticulairefo()
        e.preventDefault()
    })

    $("#formiBiopsieTesticulaireedi").on('submit', function (e) {
        editeBiopsieTesticulairefo()
        e.preventDefault()
    })

    


    $.get("/ActDataCongelationBiopsieTesticulaire/GetByIdTraitement", { Id: sessionStorage.getItem("IdmedicalrecordActe") }, function (resulta) {

        if (resulta.length == 0) {
            $("#BiopsieTesticulaireInfo").show()
            $("#BiopsieTesticulaireInfo1").hide()
            $("#boutonActDataBiopsieTesticulaire").append(' <a href="#ajouteboutonActDataBiopsieTesticulaireM" onclick="showaddboutonActDataBiopsieTesticulaireM()" class="btn btn-primary"><i class="fa fa-plus"></i>  Ajouter ActDataBiopsieTesticulaire </a>')
        } else {
            $("#BiopsieTesticulaireInfo").hide()
            $("#BiopsieTesticulaireInfo1").show()
            $("#DateDEcoronisation1").val(resulta[0].Date)
            $("#HeureDEcoronisation1").val(resulta[0].Heure)
            $("#CommentairesDEcoronisation1").val(resulta[0].Commentaires)

            $("#boutonActDataBiopsieTesticulaire").append(' <a href="#modifierboutonActDataBiopsieTesticulaireM" onclick="showeditboutonActDataBiopsieTesticulaireM()" class="btn btn-primary"><i class="fa fa-plus"></i>  editer ActDataBiopsieTesticulaire </a>')
            $("#IdEnbryologisteDoctorBiopsieTesticulaire1").val(resulta[0].IdEnbryologisteDoctor)
            $("#IdTretingDoctorBiopsieTesticulaire1").val(resulta[0].IdTretingDoctor)
            $("#DateBiopsieTesticulaire1").val(resulta[0].Date)
            $("#DateesBiopsieTesticulaire").text(resulta[0].Date)
            $("#heureeBiopsieTesticulaire").text(resulta[0].Heure)
            $("#Milieu").text(resulta[0].Milieu)


            $("#HeureBiopsieTesticulaire1").val(resulta[0].Heure)
            $("#Milieu1").val(resulta[0].Milieu)
            $("#CommentairesBiopsieTesticulaire1").val(resulta[0].Commentaires)
            $("#CommentairBiopsieTesticulaire").text(resulta[0].Commentaires)

        }

    })


})

function showaddboutonActDataBiopsieTesticulaireM() {

    $('#ajouteboutonActDataBiopsieTesticulaireM').modal('show')

}
function showeditboutonActDataBiopsieTesticulaireM() {
    $('#modifierboutonActDataBiopsieTesticulaireM').modal('show')
}



function ajouteBiopsieTesticulairefo() {

    $.post("/ActDataCongelationBiopsieTesticulaire/Add", {
        actData: {
            Id: 0, IdMedicalRecordAct: sessionStorage.getItem("IdmedicalrecordActe"),
            IdTretingDoctor: parseInt($("#IdTretingDoctorBiopsieTesticulaire").val()), IdEnbryologisteDoctor: parseInt($("#IdEnbryologisteDoctorBiopsieTesticulaire").val()),
            EmbryologisteDoctorType: "Embryogiste",
            Date: $("#DateBiopsieTesticulaire").val(), Heure: $("#HeureBiopsieTesticulaire").val(), Commentaires: $("#CommentairesBiopsieTesticulaire").val(), Milieu: $("#MilieuE").val()


        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#ajouteboutonActDataBiopsieTesticulaireM").modal('hide');
            $("#formiBiopsieTesticulaireAdd").trigger("reset");

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


function editeBiopsieTesticulairefo() {
    $.post("/ActDataCongelationBiopsieTesticulaire/Update", {
        actData: {
            Id: 0, IdMedicalRecordAct: sessionStorage.getItem("IdmedicalrecordActe"),
            IdTretingDoctor: parseInt($("#IdTretingDoctorBiopsieTesticulaire1").val()), IdEnbryologisteDoctor: parseInt($("#IdEnbryologisteDoctorBiopsieTesticulaire1").val()),
            EmbryologisteDoctorType: "Embryogiste",
            Date: $("#DateBiopsieTesticulaire1").val(), Heure: $("#HeureBiopsieTesticulaire1").val(), Commentaires: $("#CommentairesBiopsieTesticulaire1").val(), Milieu: $("#Milieu1").val()


        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#modifierboutonActDataBiopsieTesticulaireM").modal('hide');

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