$().ready(function () {

    $("#formInseminationIACAdd").on('submit', function (e) {
      
        e.preventDefault()

        ajoutInseminationIACAddfo()
    })
    


    $("#formInseminationIACedd").on('submit', function (e) {

        e.preventDefault()

        EDITERInseminationIACAddfo()
    })



    $.get("/ActDataInseminationIAC/GetByIdTraitement", { Id: sessionStorage.getItem("IdmedicalrecordActe") }, function (resulta) {

        if (resulta.length == 0) {
            $("#boutonActDataInseminationIAC").append(' <a href="#ajouteboutonActDataInseminationIACM" onclick="showaddboutonActDataInseminationIACM()" class="btn btn-primary"><i class="fa fa-plus"></i>  Ajouter ActDataInseminationIAC </a>')
        } else {

            $("#DateInseminationIAC1").val(resulta[0].Date)
            $("#HeureInseminationIAC1").val(resulta[0].Heure)
            $("#CommentairesInsemination1").val(resulta[0].Commentaires)
            $("#boutonActDataInseminationIAC").append(' <a href="#modifierboutonActDataInseminationIACM" onclick="showeditboutonActDataInseminationIACM()" class="btn btn-primary"><i class="fa fa-plus"></i>  editer ActDataInseminationIAC </a>')
            $("#IdEnbryologisteDoctorInseminationIAC1").val(resulta[0].IdEnbryologisteDoctor)
            $("#IdTretingDoctorInseminationIAC1").val(resulta[0].IdTretingDoctor)
            $("#DateesInseminee").text(resulta[0].Date)
            $("#heureeInseminee").text(resulta[0].Heure)
            $("#VolumeInseminee").text(resulta[0].VolumeInsemine)
            $("#NombreSpermatozoidesInseminees").text(resulta[0].NombreSpermatozoidesInsemines)
            $("#cathetere").text(resulta[0].catheter)
            $("#Transerfere").text(resulta[0].Transerfer)
            $("#Sange").text(resulta[0].Sang)
            $("#Glairee").text(resulta[0].Glaire)
            $("#VolumeInsemine1").val(resulta[0].VolumeInsemine)
            $("#catheter1").val(resulta[0].catheter)
            $("#Transerfer1").val(resulta[0].Transerfer)
            $("#Sang1").val(resulta[0].Sang)
            $("#Glaire1").val(resulta[0].Glaire)
            $("#NombreSpermatozoidesInsemines1").val(resulta[0].NombreSpermatozoidesInsemines)

 
         $("#CommentairesInsemination1").val(resulta[0].Commentaires)
           $("#Commentairinsemilation").text(resulta[0].Commentaires)

        }

    })




})

function showaddboutonActDataInseminationIACM() {
    $("#ajouteboutonActDataInseminationIACM").modal('show')


}

function showeditboutonActDataInseminationIACM() {
    $("#modifierboutonActDataInseminationIACM").modal('show')

}


function ajoutInseminationIACAddfo() {

    $.post("/ActDataInseminationIAC/Add", {
        actData: {
            Id: 0, IdMedicalRecordAct: sessionStorage.getItem("IdmedicalrecordActe"),
            IdTretingDoctor: parseInt($("#IdTretingDoctorInseminationIAC").val()), IdEnbryologisteDoctor: parseInt($("#IdEnbryologisteDoctorInseminationIAC").val()),
            EmbryologisteDoctorType: "Embryogiste",
            Date: $("#DateInseminationIAC").val(), Heure: $("#HeureInseminationIAC").val(), Commentaires: $("#CommentairesInsemination").val(), VolumeInsemine: parseInt($("#VolumeInsemine").val())
            , NombreSpermatozoidesInsemines: parseInt($("#NombreSpermatozoidesInsemines").val()), catheter: $("#catheter").val(), Transerfer: $("#Transerfer").val(), Sang: $("#Sang").val(), Glaire: $("#Glaire").val()


        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#ajouteboutonActDataInseminationIACM").modal('hide');
            $("#formInseminationIACAdd").trigger("reset");
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


function EDITERInseminationIACAddfo() {

    $.post("/ActDataInseminationIAC/Update", {
        actData: {
            Id: 0, IdMedicalRecordAct: sessionStorage.getItem("IdmedicalrecordActe"),
            IdTretingDoctor: parseInt($("#IdTretingDoctorInseminationIAC1").val()), IdEnbryologisteDoctor: parseInt($("#IdEnbryologisteDoctorInseminationIAC1").val()),
            EmbryologisteDoctorType: "Embryogiste",
            Date: $("#DateInseminationIAC1").val(), Heure: $("#HeureInseminationIAC1").val(), Commentaires: $("#CommentairesInsemination").val(), VolumeInsemine: parseInt($("#VolumeInsemine1").val())
            , NombreSpermatozoidesInsemines: parseInt($("#NombreSpermatozoidesInsemines1").val()), catheter: $("#catheter1").val(), Transerfer: $("#Transerfer1").val(), Sang: $("#Sang1").val(), Glaire: $("#Glaire1").val()


        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#modifierboutonActDataInseminationIACM").modal('hide');


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