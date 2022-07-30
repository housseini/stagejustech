$().ready(function () {
    $("#tab-7").css("display", "block");
    $.get("/ActDataBiopsie/GetByIdTraitement", { Id: sessionStorage.getItem("IdmedicalrecordActe") }, function (resulta) {

        if (resulta.length == 0) {
            $("#boutonActDataBiopsie").append(' <a href="#AjouterActDataBiopsieM" onclick="showaddActDataBiopsie()" class="btn btn-primary"><i class="fa fa-plus"></i>  Ajouter Act ActDataBiopsie </a>')
        } else {
            $("#boutonActDataBiopsie").append(' <a href="#EDITERActDataBiopsieM" onclick="showditeActDataBiopsie()" class="btn btn-primary"><i class="fa fa-plus"></i>  EDITER Act ActDataBiopsie </a>')
            $("#DateeActDataBiopsie").text(resulta[0].Date)
            $("#heureeActDataBiopsie").text(resulta[0].Heure)
            $("#TypeBiopsieTesticulaire11").text(resulta[0].TypeBiopsieTesticulaire)
            $("#ExamenAnatomopathologique11").text(resulta[0].ExamenAnatomopathologique)
            $("#TGPoleSupNombreFragments11").text(resulta[0].TGPoleSupNombreFragments)
            $("#TGPoleSupDilaceration11").text(resulta[0].TGPoleSupDilaceration)
            $("#TGPoleMedNombreFragments11").text(resulta[0].TGPoleMedNombreFragments)
            $("#TGPoleMedDilaceration11").text(resulta[0].TGPoleMedDilaceration)
            $("#TGPoleMedResultat11").text(resulta[0].TGPoleMedResultat)
            $("#TGPoleInfNombreFragments11").text(resulta[0].TGPoleInfNombreFragments)
            $("#TGPoleInfDilaceration11").text(resulta[0].TGPoleInfDilaceration)
            $("#TGPoleInfResultat11").text(resulta[0].TGPoleInfResultat)
            $("#TDPoleSupNombreFragments11").text(resulta[0].TDPoleSupNombreFragments)
            $("#TDPoleSupDilaceration11").text(resulta[0].TDPoleSupDilaceration)
            $("#TDPoleSupResultat11").text(resulta[0].TDPoleSupResultat)
            $("#TDPoleMedNombreFragments11").text(resulta[0].TDPoleMedNombreFragments)
            $("#TDPoleMedDilaceration11").text(resulta[0].TDPoleMedDilaceration)
            $("#TDPoleMedResultat11").text(resulta[0].TDPoleMedResultat)
            $("#TDPoleInfNombreFragments11").text(resulta[0].TDPoleInfNombreFragments)
            $("#TGPoleSupNombreFragments11").text(resulta[0].TGPoleSupNombreFragments)
            $("#TDPoleInfDilaceration11").text(resulta[0].TDPoleInfDilaceration)
            $("#TDPoleInfResultat11").text(resulta[0].TDPoleInfResultat)


            $("#DateActDataBiopsie1").val(resulta[0].Date)
            $("#HeureActDataBiopsie1").val(resulta[0].Heure)
            $("#TypeBiopsieTesticulaire1").val(resulta[0].TypeBiopsieTesticulaire)
            $("#ExamenAnatomopathologique1").val(resulta[0].ExamenAnatomopathologique)
            $("#TGPoleSupNombreFragments1").val(resulta[0].TGPoleSupNombreFragments)
            $("#TGPoleSupDilaceration1").val(resulta[0].TGPoleSupDilaceration)
            $("#TGPoleMedNombreFragments1").val(resulta[0].TGPoleMedNombreFragments)
            $("#TGPoleMedDilaceration1").val(resulta[0].TGPoleMedDilaceration)
            $("#TGPoleMedResultat1").val(resulta[0].TGPoleMedResultat)
            $("#TGPoleInfNombreFragments1").val(resulta[0].TGPoleInfNombreFragments)
            $("#TGPoleInfDilaceration1").val(resulta[0].TGPoleInfDilaceration)
            $("#TGPoleInfResultat1").val(resulta[0].TGPoleInfResultat)
            $("#TDPoleSupNombreFragments1").val(resulta[0].TDPoleSupNombreFragments)
            $("#TDPoleSupDilaceration1").val(resulta[0].TDPoleSupDilaceration)
            $("#TDPoleSupResultat1").val(resulta[0].TDPoleSupResultat)
            $("#TDPoleMedNombreFragments1").val(resulta[0].TDPoleMedNombreFragments)
            $("#TDPoleMedDilaceration1").val(resulta[0].TDPoleMedDilaceration)
            $("#TDPoleMedResultat1").val(resulta[0].TDPoleMedResultat)
            $("#TDPoleInfNombreFragments1").val(resulta[0].TDPoleInfNombreFragments)
            $("#TGPoleSupNombreFragments1").val(resulta[0].TGPoleSupNombreFragments)
            $("#TDPoleInfDilaceration1").val(resulta[0].TDPoleInfDilaceration)
            $("#TDPoleInfResultat1").val(resulta[0].TDPoleInfResultat)


        }
    })


    $("#formActDataBiopsie").on('submit', function (e) {
        AjouterActDataBiopsie()
        e.preventDefault()
    })
    $("#formEDActDataBiopsie").on('submit', function (e) {
        editerActDataBiopsie()
        e.preventDefault()
    })


})


function showaddActDataBiopsie() {
    $("#AjouterActDataBiopsieM").modal('show')



}

function AjouterActDataBiopsie() {
    $.post("/ActDataBiopsie/Add", {
        actData: {
            Id: 0, IdMedicalRecordAct: sessionStorage.getItem("IdmedicalrecordActe"),
            IdTretingDoctor: parseInt($("#IdTreatingDoctorActDataBiopsie").val()), IdEnbryologisteDoctor: parseInt($("#IdEnbryologisteDoctorActDataBiopsie").val()),
            EmbryologisteDoctorType: "Embryogiste",
            Date: $("#DateActDataBiopsie").val(), Heure: $("#HeureActDataBiopsie").val(),
            TypeBiopsieTesticulaire: $("#TypeBiopsieTesticulaire").val(), ExamenAnatomopathologique: ($("#ExamenAnatomopathologique").val()),
            TGPoleSupNombreFragments: parseInt($("#TGPoleSupNombreFragments").val()), TGPoleSupDilaceration: ($("#TGPoleSupDilaceration").val()), TGPoleSupResultat: ($("#TGPoleSupResultat").val()),
            TGPoleMedNombreFragments: parseInt($("#TGPoleMedNombreFragments").val()), TGPoleMedDilaceration: ($("#TGPoleMedDilaceration").val()), TGPoleMedResultat: ($("#TGPoleMedResultat").val()),
            TGPoleInfNombreFragments: parseInt($("#TGPoleInfNombreFragments").val()), TGPoleInfDilaceration: ($("#TGPoleInfDilaceration").val()), TGPoleInfResultat: ($("#TGPoleInfResultat").val()),
            TDPoleSupNombreFragments: parseInt($("#TDPoleSupNombreFragments").val()), TDPoleSupDilaceration: ($("#TDPoleSupDilaceration").val()), TDPoleSupResultat: ($("#TDPoleSupResultat").val()),
            TDPoleMedNombreFragments: parseInt($("#TDPoleMedNombreFragments").val()), TDPoleMedDilaceration: ($("#TDPoleMedDilaceration").val()), TDPoleMedResultat: ($("#TDPoleMedResultat").val()),
            TDPoleInfNombreFragments: parseInt($("#TDPoleInfNombreFragments").val()), TDPoleInfDilaceration: ($("#TDPoleInfDilaceration").val()), TDPoleInfResultat: ($("#TDPoleInfResultat").val())

        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#AjouterActDataBiopsieM").modal('hide');
            $("#formActDataBiopsie").trigger("reset");




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


function showditeActDataBiopsie() {
    $("#EDITERActDataBiopsieM").modal('show')


}

function editerActDataBiopsie() {
    $.post("/ActDataBiopsie/Update", {
        actData: {
            Id: 0, IdMedicalRecordAct: sessionStorage.getItem("IdmedicalrecordActe"),
            IdTretingDoctor: parseInt($("#IdTreatingDoctorActDataBiopsie1").val()), IdEnbryologisteDoctor: parseInt($("#IdEnbryologisteDoctorActDataBiopsie1").val()),
            EmbryologisteDoctorType: "Embryogiste",
            Date: $("#DateActDataBiopsie1").val(), Heure: $("#HeureActDataBiopsie1").val(),
            TypeBiopsieTesticulaire: $("#TypeBiopsieTesticulaire1").val(), ExamenAnatomopathologique: ($("#ExamenAnatomopathologique1").val()),
            TGPoleSupNombreFragments: parseInt($("#TGPoleSupNombreFragments1").val()), TGPoleSupDilaceration: ($("#TGPoleSupDilaceration1").val()), TGPoleSupResultat: ($("#TGPoleSupResultat1").val()),
            TGPoleMedNombreFragments: parseInt($("#TGPoleMedNombreFragments1").val()), TGPoleMedDilaceration: ($("#TGPoleMedDilaceration1").val()), TGPoleMedResultat: ($("#TGPoleMedResultat1").val()),
            TGPoleInfNombreFragments: parseInt($("#TGPoleInfNombreFragments1").val()), TGPoleInfDilaceration: ($("#TGPoleInfDilaceration1").val()), TGPoleInfResultat: ($("#TGPoleInfResultat1").val()),
            TDPoleSupNombreFragments: parseInt($("#TDPoleSupNombreFragments1").val()), TDPoleSupDilaceration: ($("#TDPoleSupDilaceration1").val()), TDPoleSupResultat: ($("#TDPoleSupResultat1").val()),
            TDPoleMedNombreFragments: parseInt($("#TDPoleMedNombreFragments1").val()), TDPoleMedDilaceration: ($("#TDPoleMedDilaceration1").val()), TDPoleMedResultat: ($("#TDPoleMedResultat1").val()),
            TDPoleInfNombreFragments: parseInt($("#TDPoleInfNombreFragments1").val()), TDPoleInfDilaceration: ($("#TDPoleInfDilaceration1").val()), TDPoleInfResultat: ($("#TDPoleInfResultat1").val())

        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#EDITERActDataBiopsieM").modal('hide');
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
