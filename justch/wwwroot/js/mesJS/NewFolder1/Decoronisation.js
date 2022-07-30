$().ready(function () {

    $("#formDEcoronisationAdd").on('submit', function (e) {
        addDEcoronisatiofo()
        e.preventDefault()
    })

    $("#formDEcoronisationedite").on('submit', function (e) {
        editeEcoronisatiofo()
        e.preventDefault()
    })



    $("#formAjouterActDataDecoronisationOvocyteDataMAdd").on('submit', function (e) {
        formAjouterActDataDecoronisationOvocyteDataMAddfo()
        e.preventDefault()
    })


    $("#formAediteActDataDecoronisationOvocyteDataMAdd").on('submit', function (e) {
        formEditeActDataDecoronisationOvocyteDataMEditefo()
        e.preventDefault()
    })



    


    $.get("/ActDataDecoronisation/GetByIdTraitement", { Id: sessionStorage.getItem("IdmedicalrecordActe") }, function (resulta) {

        if (resulta.length == 0) {
            $("#boutonActDataDecoronisation").append(' <a href="#ajouteDEcoronisationM" onclick="showaddDEcoronisationM()" class="btn btn-primary"><i class="fa fa-plus"></i>  Ajouter ActDataDecoronisation </a>')
        } else {
            sessionStorage.setItem("IdDataDecoronisation", resulta[0].Id)
            $("#DateDEcoronisation1").val(resulta[0].Date)
            $("#HeureDEcoronisation1").val(resulta[0].Heure)
            $("#CommentairesDEcoronisation1").val(resulta[0].Commentaires)

            $("#boutonActDataDecoronisation").append(' <a href="#modifierDEcoronisationM" onclick="showeditdecoronisationM()" class="btn btn-primary"><i class="fa fa-plus"></i>  editer ActDataDecoronisation </a>')
            $.get("/ActDataDecoronisationOvocyteData/GetByIdTraitement", { Id: resulta[0].Id }, function (resulta) {

               
                if (resulta.length == 0) {

                    $("#boutonActDataDecoronisation").append(' <a href="#AjouterActDataDecoronisationOvocyteDataM" onclick="showAddActDataDecoronisationOvocyteDataM()" class="btn btn-primary"><i class="fa fa-plus"></i>  Ajouter  ActDataDecoronisationOvocyteData </a>')

                } else {
                    
                    $("#boutonActDataDecoronisationOvocyteData").append(' <a href="#modifierActDataDecoronisationOvocyteDataM" onclick="showEditActDataDecoronisationOvocyteDataM()" class="btn btn-primary"><i class="fa fa-plus"></i>  editer  ActDataDecoronisationOvocyteData </a>')
                    $('#NUMERO').text(resulta[0].DecoronisationOvocyteNumeroOvocyte)
                    $('#DecoronisationOvocyteNumeroOvocyte1').val(resulta[0].DecoronisationOvocyteNumeroOvocyte)
                
                    $('#ETAT').text(resulta[0].DecoronisationOvocyteEtat)
                    $('#DecoronisationOvocyteEtat1').val(resulta[0].DecoronisationOvocyteEtat)
                    $('#DecoronisationOvocyteCommantaire11').text(resulta[0].DecoronisationOvocyteCommantaire)
                    $('#DecoronisationOvocyteCommantaire1').val(resulta[0].DecoronisationOvocyteCommantaire)


                }

            })


            $("IdEnbryologisteDoctorDEcoronisation1").val(resulta[0].IdEnbryologisteDoctor)
            $("IdTretingDoctorDEcoronisation1").val(resulta[0].IdTretingDoctor)
            $("DateDEcoronisation1").val(resulta[0].Date)
            $("#Datee1s").text(resulta[0].Date)
            $("#heure1e").text(resulta[0].Heure)
            $("#HeureDEcoronisation1").val(resulta[0].Heure)
            $("#CommentairesDEcoronisation1").val(resulta[0].Commentaires)
            $("#Commentair1e").text(resulta[0].Commentaires)

        }

    })

}



)

function showAddActDataDecoronisationOvocyteDataM() {
    $('#AjouterActDataDecoronisationOvocyteDataM').modal('show')

}

function showaddDEcoronisationM() {
    $('#ajouteDEcoronisationM').modal('show')


}

function showEditActDataDecoronisationOvocyteDataM() {
    $('#modifierActDataDecoronisationOvocyteDataM').modal('show')

}

function showeditdecoronisationM() {
    $('#modifierDEcoronisationM').modal('show')
}


function formEditeActDataDecoronisationOvocyteDataMEditefo() {
    $.post("/ActDataDecoronisationOvocyteData/Update", {
        actData: {
            Id: 0, IdActDataDecoronisation: sessionStorage.getItem("IdDataDecoronisation"),
            DecoronisationOvocyteNumeroOvocyte: parseInt($("#DecoronisationOvocyteNumeroOvocyte1").val()),
            DecoronisationOvocyteEtat: $("#DecoronisationOvocyteEtat1").val(), DecoronisationOvocyteCommantaire: $("#DecoronisationOvocyteCommantaire1").val()

        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#modifierActDataDecoronisationOvocyteDataM").modal('hide');

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


function addDEcoronisatiofo() {

    $.post("/ActDataDecoronisation/Add", {
        actData: {
            Id: 0, IdMedicalRecordAct: sessionStorage.getItem("IdmedicalrecordActe"),
            IdTretingDoctor: parseInt($("#IdTretingDoctorDEcoronisation").val()), IdEnbryologisteDoctor: parseInt($("#IdEnbryologisteDoctorDEcoronisation").val()),
             EmbryologisteDoctorType: "Embryogiste",
            Date: $("#DateDEcoronisation").val(), Heure: $("#HeureDEcoronisation").val(), Commentaires: $("#CommentairesDEcoronisation").val()
          

        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#ajouteDEcoronisationM").modal('hide');
            $("#formDEcoronisationAdd").trigger("reset");




        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })

            $("#ajouteDEcoronisationM").modal('hide');
            $("#formDEcoronisationAdd").trigger("reset");

        }



    })

}
function editeEcoronisatiofo() {
    $.post("/ActDataDecoronisation/Update", {
        actData: {
            Id: 0, IdMedicalRecordAct: sessionStorage.getItem("IdmedicalrecordActe"),
            IdTretingDoctor: parseInt($("#IdTretingDoctorDEcoronisation1").val()), IdEnbryologisteDoctor: parseInt($("#IdEnbryologisteDoctorDEcoronisation1").val()),
            EmbryologisteDoctorType: "Embryogiste",
            Date: $("#DateDEcoronisation1").val(), Heure: $("#HeureDEcoronisation1").val(), Commentaires: $("#CommentairesDEcoronisation1").val()


        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#modifierDEcoronisationM").modal('hide');
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

function formAjouterActDataDecoronisationOvocyteDataMAddfo() {

    $.post("/ActDataDecoronisationOvocyteData/Add", {
        actData: {
            Id: 0, IdActDataDecoronisation: sessionStorage.getItem("IdDataDecoronisation"),
            DecoronisationOvocyteNumeroOvocyte: parseInt($("#DecoronisationOvocyteNumeroOvocyte").val()),
            DecoronisationOvocyteEtat: $("#DecoronisationOvocyteEtat").val(), DecoronisationOvocyteCommantaire: $("#DecoronisationOvocyteCommantaire").val()

        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#AjouterActDataDecoronisationOvocyteDataM").modal('hide');
            $("#formAjouterActDataDecoronisationOvocyteDataMAdd").trigger("reset");

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