$().ready(function () {
    $.get("/ActDataTransfertsEnbryonnaire/GetByIdTraitement", { Id: sessionStorage.getItem("IdmedicalrecordActe") }, function (resulta) {

        if (resulta.length == 0) {
            $("#boutonActDataTransfertsEnbryonnaire").append(' <a href="#ajouteActDataTransfertsEnbryonnaireM" onclick="showaddActDataTransfertsEnbryonnaireM()" class="btn btn-primary"><i class="fa fa-plus"></i>  Ajouter ActDataTransfertsEnbryonnaire </a>')
        } else {
            $("#boutonActDataTransfertsEnbryonnaire").append(' <a href="#editerActDataTransfertsEnbryonnaireM" onclick="showediteActDataTransfertsEnbryonnaireM()" class="btn btn-primary"><i class="fa fa-plus"></i>  editer ActDataTransfertsEnbryonnaire </a>')
            sessionStorage.setItem("IdActDataTransfertsEnbryonnaire", resulta[0].Id)


            $("#IdEnbryologisteDoctorActDataTransfertsEnbryonnaire1").val(resulta[0].IdEnbryologisteDoctor)
            $("#DateesActDataTransfertsEnbryonnaire").text(resulta[0].Date)
            $("#DateActDataTransfertsEnbryonnaire1").val(resulta[0].Date)

            $("#heureeActDataTransfertsEnbryonnaire").text(resulta[0].Heure)
            $("#HeureActDataTransfertsEnbryonnaire1").val(resulta[0].Heure)

            $("#NombreeEnbryonsTransferes").text(resulta[0].NombreEnbryonsTransferes)
            $("#NombreEnbryonsTransferesActDataTransfertsEnbryonnaire1").val(resulta[0].NombreEnbryonsTransferes)

            $("#cathetereActDataTransfertsEnbryonnaire").text(resulta[0].catheter)
            $("#catheterActDataTransfertsEnbryonnaire1").val(resulta[0].catheter)

            $("#TranserefereActDataTransfertsEnbryonnairee").text(resulta[0].Transfer)
            $("#TranserferActDataTransfertsEnbryonnaire1").val(resulta[0].Transfer)

            $("#SangeActDataTransfertsEnbryonnaire").text(resulta[0].Sang)
            $("#SangActDataTransfertsEnbryonnaire1").val(resulta[0].Sang)

            $("#GlaireeActDataTransfertsEnbryonnaire").text(resulta[0].Glaire)
            $("#GlaireActDataTransfertsEnbryonnaire1").val(resulta[0].Glaire)

            $("#CommentaireActDataTransfertsEnbryonnaire").text(resulta[0].Commentaires)
            $("#CommentairesActDataTransfertsEnbryonnaire1").val(resulta[0].Commentaires)

            $.get("/EnbryonTransfertData/GetByIdTraitement", { Id: resulta[0].Id }, function (resulta) {

                if (resulta.length == 0) {
                    $("#boutonActDataTransfertsEnbryonnaire").append(' <a href="#ajouteTransfertsEnbryonnaireM" onclick="showTransfertsEnbryonnaireM()" class="btn btn-primary"><i class="fa fa-plus"></i> TransfertsEnbryonnaire </a>')
                } else {
                    $("#boutonTransfertsEnbryonnaire").append(' <a href="#editerTransfertsEnbryonnaireM" onclick="showediteediterTransfertsEnbryonnaireMM()" class="btn btn-primary"><i class="fa fa-plus"></i>  editer ActDataTransfertsEnbryonnaire </a>')
                    $("#Numeroenbryone").text(resulta[0].Numeroenbryon)
                    $("#Numeroenbryone11").val(resulta[0].Numeroenbryon)
                    $("#Jourtransferte11").val(resulta[0].Jourtransfert)

                    $("#Jourtransferte").text(resulta[0].Jourtransfert)



                }
            })

            
        }
    })

    $("#formEnbryonTransfertDataMedite").on('submit', function (e) {
        editeformEnbryonTransfertDataMeditefo()
        e.preventDefault()
    })

    $("#formActDataTransfertsEnbryonnaireAdd").on('submit', function (e) {
        AJOUTERActDataTransfertsEnbryonnairefo()
        e.preventDefault()
    })

    $("#formActDataTransfertsEnbryonnaireedite").on('submit', function (e) {
        EditerActDataTransfertsEnbryonnairefo()
        e.preventDefault()
    })


    $("#formEnbryonTransfertDataMAdd").on('submit', function (e) {
        ajouterformEnbryonTransfertDataMAddfo()
        e.preventDefault()
    })

})



function showediteediterTransfertsEnbryonnaireMM() {
    $("#editerTransfertsEnbryonnaireM").modal('show')
}

function showaddActDataTransfertsEnbryonnaireM() {
    $("#ajouteActDataTransfertsEnbryonnaireM").modal('show')
}

function showediteActDataTransfertsEnbryonnaireM() {
    $("#editerActDataTransfertsEnbryonnaireM").modal('show')

}

function AJOUTERActDataTransfertsEnbryonnairefo() {
    $.post("/ActDataTransfertsEnbryonnaire/Add", {
        actData: {
            Id: 0, IdMedicalRecordAct: sessionStorage.getItem("IdmedicalrecordActe"),
            IdEnbryologisteDoctor: parseInt($("#IdEnbryologisteDoctorActDataTransfertsEnbryonnaire").val()),
            EmbryologisteDoctorType: "Embryogiste",
            Date: $("#DateActDataTransfertsEnbryonnaire").val(), Heure: $("#HeureActDataTransfertsEnbryonnaire").val(), Commentaires: $("#CommentairesActDataTransfertsEnbryonnaire").val(), NombreEnbryonsTransferes: parseInt($("#NombreEnbryonsTransferesActDataTransfertsEnbryonnaire").val())
            , catheter: $("#catheterActDataTransfertsEnbryonnaire").val(), Transfer: $("#TranserferActDataTransfertsEnbryonnaire").val(), Sang: $("#SangActDataTransfertsEnbryonnaire").val(), Glaire: $("#GlaireActDataTransfertsEnbryonnaire").val()


        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#ajouteActDataTransfertsEnbryonnaireM").modal('hide');
            $("#formActDataTransfertsEnbryonnaireAdd").trigger("reset");
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


function EditerActDataTransfertsEnbryonnairefo() {
    $.post("/ActDataTransfertsEnbryonnaire/Update", {
        actData: {
            Id: 0, IdMedicalRecordAct: sessionStorage.getItem("IdmedicalrecordActe"),
            IdEnbryologisteDoctor: parseInt($("#IdEnbryologisteDoctorActDataTransfertsEnbryonnaire1").val()),
            EmbryologisteDoctorType: "Embryogiste",
            Date: $("#DateActDataTransfertsEnbryonnaire1").val(), Heure: $("#HeureActDataTransfertsEnbryonnaire1").val(), Commentaires: $("#CommentairesActDataTransfertsEnbryonnaire1").val(), NombreEnbryonsTransferes: parseInt($("#NombreEnbryonsTransferesActDataTransfertsEnbryonnaire1").val())
            , catheter: $("#catheterActDataTransfertsEnbryonnaire1").val(), Transfer: $("#TranserferActDataTransfertsEnbryonnaire1").val(), Sang: $("#SangActDataTransfertsEnbryonnaire1").val(), Glaire: $("#GlaireActDataTransfertsEnbryonnaire1").val()


        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#editerActDataTransfertsEnbryonnaireM").modal('hide');
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

function showTransfertsEnbryonnaireM() {
    $("#ajouteTransfertsEnbryonnaireM").modal('show')
}







function ajouterformEnbryonTransfertDataMAddfo() {

    $.post("/EnbryonTransfertData/Add", {
        actData: {
            Id: 0, IdActDataTransfertsEnbryonnaire: sessionStorage.getItem("IdActDataTransfertsEnbryonnaire"),          
            Numeroenbryon: parseInt($("#Numeroenbryon").val())
            , Jourtransfert: $("#Jourtransfert").val()       }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#ajouteTransfertsEnbryonnaireM").modal('hide');
            $("#formEnbryonTransfertDataMAdd").trigger("reset");
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



function editeformEnbryonTransfertDataMeditefo() {

    $.post("/EnbryonTransfertData/Update", {
        actData: {
            Id: 0, IdActDataTransfertsEnbryonnaire: sessionStorage.getItem("IdActDataTransfertsEnbryonnaire"),
            Numeroenbryon: parseInt($("#Numeroenbryone11").val())
            , Jourtransfert: $("#Jourtransferte11").val()
        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#formEnbryonTransfertDataMedite").modal('hide');
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