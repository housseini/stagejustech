$().ready(function () {


    
    $("#forminjectiondite").on('submit', function (e) {
        editeDinjectionfo()
        e.preventDefault()
    })

    $("#forminjectionAdd").on('submit', function (e) {
        addDinjectionfo()
        e.preventDefault()
    })

    $.get("/ActDataInjection/GetByIdTraitement", { Id: sessionStorage.getItem("IdmedicalrecordActe") }, function (resulta) {

        if (resulta.length == 0) {
            $("#boutonActDataInjection").append(' <a href="#ajouteInjectionM" onclick="showaddInjectionM()" class="btn btn-primary"><i class="fa fa-plus"></i>  Ajouter Injection </a>')
        } else {

            $("#DateDEcoronisation1").val(resulta[0].Date)
            $("#HeureDEcoronisation1").val(resulta[0].Heure)
            $("#CommentairesDEcoronisation1").val(resulta[0].Commentaires)

            $("#boutonActDataInjection").append(' <a href="#modifierInjectionM" onclick="showeditInjectionM()" class="btn btn-primary"><i class="fa fa-plus"></i>  editer Injection </a>')
            $("#IdEnbryologisteDoctorInjection1").val(resulta[0].IdEnbryologisteDoctor)
            $("#IdTretingDoctorInjection1").val(resulta[0].IdTretingDoctor)
            $("#DateInjection11").val(resulta[0].Date)
            $("#DateesInjection").text(resulta[0].Date)
            $("#heureeInjection").text(resulta[0].Heure)
            $("#nombreDovocyteInjectione").text(resulta[0].NombreOvocytesInjectes)

            
            $("#HeureInjection1").val(resulta[0].Heure)
            $("#nombreovovytesinjecter1").val(resulta[0].NombreOvocytesInjectes)
            $("#CommentairesInjection1").val(resulta[0].Commentaires)
            $("#CommentairInjectione").text(resulta[0].Commentaires)

        }

    })

})

function showaddInjectionM() {
    $("#ajouteInjectionM").modal('show')
}



function addDinjectionfo() {

    $.post("/ActDataInjection/Add", {
        actData: {
            Id: 0, IdMedicalRecordAct: sessionStorage.getItem("IdmedicalrecordActe"),
            IdTretingDoctor: parseInt($("#IdTretingDoctorInjection").val()), IdEnbryologisteDoctor: parseInt($("#IdEnbryologisteDoctorInjection").val()),
            EmbryologisteDoctorType: "Embryogiste",
            Date: $("#DateInjection").val(), Heure: $("#HeureInjection").val(), Commentaires: $("#CommentairesInjection").val(), NombreOvocytesInjectes: parseInt( $("#nombreovovytesinjecter").val())


        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#ajouteInjectionM").modal('hide');
            $("#forminjectionAdd").trigger("reset");




        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })


            $("#ajouteInjectionM").modal('hide');
            $("#forminjectionAdd").trigger("reset");


        }



    })

}


function editeDinjectionfo() {
    $.post("/ActDataInjection/Update", {
        actData: {
            Id: 0, IdMedicalRecordAct: sessionStorage.getItem("IdmedicalrecordActe"),
            IdTretingDoctor: parseInt($("#IdTretingDoctorInjection1").val()), IdEnbryologisteDoctor: parseInt($("#IdEnbryologisteDoctorInjection1").val()),
            EmbryologisteDoctorType: "Embryogiste",
            Date: $("#DateInjection11").val(), Heure: $("#HeureInjection1").val(), Commentaires: $("#CommentairesInjection1").val(), NombreOvocytesInjectes: parseInt($("#nombreovovytesinjecter1").val())


        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#modifierInjectionM").modal('hide');
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

function showeditInjectionM() {
    $("#modifierInjectionM").modal('show')
}