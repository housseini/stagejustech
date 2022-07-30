$().ready(function () {

    $(".tab").css("display", "none");
    $("#tab-1").css("display", "block");
    $("#tab-4").css("display", "block");

    $("#tab-13").css("display", "block");
    


    $("#formPreparationSpermeAdd").on('submit', function (e) {
        ajoutePreparationSpermefo()
        e.preventDefault()
    })



    $("#formPreparationSpermeEdite").on('submit', function (e) {
        EDITERPreparationSpermefo()
        e.preventDefault()
    })


    $.get("/ActDataPreparationSperme/GetByIdTraitement", { Id: sessionStorage.getItem("IdmedicalrecordActe") }, function (resulta) {

        if (resulta.length == 0) {
            $("#boutonDataPreparationSperme").append(' <a href="#ajouteDataPreparationSpermeM" onclick="showaddDataPreparationSpermeM()" class="btn btn-primary"><i class="fa fa-plus"></i>  Ajouter DataPreparationSperme </a>')
        } else {
            $("#boutonDataPreparationSperme").append(' <a href="#editeDataPreparationSpermeM" onclick="showeditDataPreparationSpermeM()" class="btn btn-primary"><i class="fa fa-plus"></i>  editer DataPreparationSperme </a>')
            $("#DateeSpermeDate").text(resulta[0].SpermeDate)
            $("#SpermeDate1").val(resulta[0].SpermeDate)
            $("#IdEnbryologistePreparationSperme1").val(resulta[0].IdAnalyseInitialeEnbryologiste)


            $("#AnalyseInitialeHeuree").text(resulta[0].AnalyseInitialeHeure)
            $("#AnalyseInitialeHeure1").val(resulta[0].AnalyseInitialeHeure)

            $("#SpermeOriginee").text(resulta[0].SpermeOrigine)
            $("#SpermeOrigine1").val(resulta[0].SpermeOrigine)

            $("#SpermeMilieue").text(resulta[0].SpermeMilieu)
            $("#SpermeMilieu1").val(resulta[0].SpermeMilieu)


            $("#SpermePreparatione").text(resulta[0].SpermePreparation)
            $("#SpermePreparation1").val(resulta[0].SpermePreparation)


            $("#SpermeRecueile").text(resulta[0].SpermeRecueil)
            $("#SpermeRecueil1").val(resulta[0].SpermeRecueil)


            $("#SpermeCommentairee").text(resulta[0].SpermeCommentaire)
            $("#SpermeCommentaire1").val(resulta[0].SpermeCommentaire)

            $("#AnalyseInitialJoursAbstinencee").text(resulta[0].AnalyseInitialJoursAbstinence)
            $("#AnalyseInitialJoursAbstinence1").val(resulta[0].AnalyseInitialJoursAbstinence)


            $("#AnalyseInitialeAspecte").text(resulta[0].AnalyseInitialeAspect)
            $("#AnalyseInitialeAspect1").val(resulta[0].AnalyseInitialeAspect)

            $("#AnalyseInitialeVolumee").text(resulta[0].AnalyseInitialeVolume)
            $("#AnalyseInitialeVolume1").val(resulta[0].AnalyseInitialeVolume)

            $("#AnalyseInitialeViscositee").text(resulta[0].AnalyseInitialeViscosite)
            $("#AnalyseInitialeViscosite1").val(resulta[0].AnalyseInitialeViscosite)


            $("#AnalyseInitialeLiquefactione").text(resulta[0].AnalyseInitialeLiquefaction)
            $("#AnalyseInitialeLiquefaction1").val(resulta[0].AnalyseInitialeLiquefaction)

            $("#AnalyseInitialeMorphologiee").text(resulta[0].AnalyseInitialeMorphologie)
            $("#AnalyseInitialeMorphologie1").val(resulta[0].AnalyseInitialeMorphologie)

            $("#AnalyseInitialeLeucocytese").text(resulta[0].AnalyseInitialeLeucocytes)
            $("#AnalyseInitialeLeucocytes1").val(resulta[0].AnalyseInitialeLeucocytes)


            $("#AnalyseInitialeCelluleRondese").text(resulta[0].AnalyseInitialeCelluleRondes)
            $("#AnalyseInitialeCelluleRondes1").val(resulta[0].AnalyseInitialeCelluleRondes)


            $("#AnalyseInitialeCelluleEpithelialese").text(resulta[0].AnalyseInitialeCelluleEpitheliales)
            $("#AnalyseInitialeCelluleEpitheliales1").val(resulta[0].AnalyseInitialeCelluleEpitheliales)

            $("#AnalyseInitialeAgglutinatione").text(resulta[0].AnalyseInitialeAgglutination)
            $("#AnalyseInitialeAgglutination1").val(resulta[0].AnalyseInitialeAgglutination)


            $("#AnalyseInitialeMobilitee").text(resulta[0].AnalyseInitialeMobilite)
            $("#AnalyseInitialeMobilite1").val(resulta[0].AnalyseInitialeMobilite)

            $("#AnalyseInitialeConcentratione").text(resulta[0].AnalyseInitialeConcentration)
            $("#AnalyseInitialeConcentration1").val(resulta[0].AnalyseInitialeConcentration)

            $("#AnalyseInitialeCommentairese").text(resulta[0].AnalyseInitialeCommentaires)
            $("#AnalyseInitialeCommentaires1").val(resulta[0].AnalyseInitialeCommentaires)


            $("#ApresTraitementVolumeTraitee").text(resulta[0].ApresTraitementVolumeTraite)
            $("#ApresTraitementVolumeTraite1").val(resulta[0].ApresTraitementVolumeTraite)


            $("#ApresTraitementVolumeFinale").text(resulta[0].ApresTraitementVolumeFinal)
            $("#ApresTraitementVolumeFinal1").val(resulta[0].ApresTraitementVolumeFinal)


            $("#ApresTraitementVolumeMobilitee").text(resulta[0].ApresTraitementVolumeMobilite)
            $("#ApresTraitementVolumeMobilite1").val(resulta[0].ApresTraitementVolumeMobilite)


            $("#ApresTraitementVolumeConcentratione").text(resulta[0].ApresTraitementVolumeConcentration)
            $("#ApresTraitementVolumeConcentration1").val(resulta[0].ApresTraitementVolumeConcentration)

            $("#ApresTraitementVolumeCommentaireFinale").text(resulta[0].ApresTraitementVolumeCommentaireFinal)
            $("#ApresTraitementVolumeCommentaireFinal1").val(resulta[0].ApresTraitementVolumeCommentaireFinal)

            $("#ApresTraitementNumerationTotaleTde").text(resulta[0].ApresTraitementNumerationTotaleTd)
            $("#ApresTraitementNumerationTotaleTd1").val(resulta[0].ApresTraitementVolumeCommentaireFinal)
            $("#ApresTraitementCommentairee").text(resulta[0].ApresTraitementCommentaire)
            $("#ApresTraitementCommentaire1").val(resulta[0].ApresTraitementCommentaire)






        }

    })

})



    function showaddDataPreparationSpermeM() {

        $("#ajouteDataPreparationSpermeM").modal('show')

}


function showeditDataPreparationSpermeM() {
    $("#editeDataPreparationSpermeM").modal('show')

}


function EDITERPreparationSpermefo() {
    $.post("/ActDataPreparationSperme/Update", {
        actData: {
            Id: 0, IdMedicalRecordAct: sessionStorage.getItem("IdmedicalrecordActe"),
            IdAnalyseInitialeEnbryologiste: parseInt($("#IdEnbryologistePreparationSperme1").val()),
            SpermeDate: $("#SpermeDate1").val(), SpermeOrigine: $("#SpermeOrigine1").val(),
            SpermeMilieu: $("#SpermeMilieu1").val(), SpermePreparation: $("#SpermePreparation1").val(), SpermeRecueil: $("#SpermeRecueil").val(),
            SpermeCommentaire: $("#SpermeCommentaire1").val(), AnalyseInitialeHeure: $("#AnalyseInitialeHeure1").val(),
            AnalyseInitialJoursAbstinence: $("#AnalyseInitialJoursAbstinence1").val(), AnalyseInitialeAspect: $("#AnalyseInitialeAspect1").val(),
            AnalyseInitialeVolume: $("#AnalyseInitialeVolume1").val(), AnalyseInitialeViscosite: $("#AnalyseInitialeViscosite1").val(),
            AnalyseInitialeLiquefaction: $("#AnalyseInitialeLiquefaction1").val(), AnalyseInitialeMorphologie: $("#AnalyseInitialeMorphologie1").val(), AnalyseInitialeLeucocytes: $("#AnalyseInitialeLeucocytes1").val(), AnalyseInitialeCelluleRondes: $("#AnalyseInitialeCelluleRondes1").val(),
            AnalyseInitialeCelluleEpitheliales: $("#AnalyseInitialeCelluleEpitheliales1").val(), AnalyseInitialeAgglutination: $("#AnalyseInitialeAgglutination1").val(),
            AnalyseInitialeMobilite: $("#AnalyseInitialeMobilite1").val(), AnalyseInitialeConcentration: $("#AnalyseInitialeConcentration1").val(),
            AnalyseInitialeCommentaires: $("#AnalyseInitialeCommentaires1").val(), ApresTraitementVolumeTraite: parseInt($("#ApresTraitementVolumeTraite1").val()),
            ApresTraitementVolumeFinal: parseInt($("#ApresTraitementVolumeFinal1").val()), ApresTraitementVolumeMobilite: $("#ApresTraitementVolumeMobilite1").val(), ApresTraitementVolumeConcentration: parseInt($("#ApresTraitementVolumeConcentration1").val()), ApresTraitementVolumeCommentaireFinal: parseInt($("#ApresTraitementVolumeCommentaireFinal1").val()),
            ApresTraitementNumerationTotaleTd: parseInt($("#ApresTraitementNumerationTotaleTd1").val()), ApresTraitementCommentaire: $("#ApresTraitementCommentaire1").val()



        }
    }, function (result) {

        console.log(result)
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#editeDataPreparationSpermeM").modal('hide');
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


function run(hideTab, showTab) {
    if (hideTab < showTab) { // If not press previous button
        // Validation if press next button
        var currentTab = 0;
        x = $('#tab-' + hideTab);
        y = $(x).find("input")
        for (i = 0; i < y.length; i++) {
            if (y[i].value == "") {
                $(y[i]).css("background", "#ffdddd");
                return false;
            }
        }
    }

    // Progress bar
    for (i = 1; i < showTab; i++) {
        $("#step-" + i).css("opacity", "1");
    }

    // Switch tab
    $("#tab-" + hideTab).css("display", "none");
    $("#tab-" + showTab).css("display", "block");
    $("input").css("background", "#fff");
}




function ajoutePreparationSpermefo() {

    $.post("/ActDataPreparationSperme/Add", {
        actData: {
            Id: 0, IdMedicalRecordAct: sessionStorage.getItem("IdmedicalrecordActe"),
            IdAnalyseInitialeEnbryologiste: parseInt($("#IdEnbryologistePreparationSperme").val()),
            SpermeDate: $("#SpermeDate").val(), SpermeOrigine: $("#SpermeOrigine").val(),
            SpermeMilieu: $("#SpermeMilieu").val(), SpermePreparation: $("#SpermePreparation").val(), SpermeRecueil: $("#SpermeRecueil").val(),
            SpermeCommentaire: $("#SpermeCommentaire").val(), AnalyseInitialeHeure: $("#AnalyseInitialeHeure").val(),
            AnalyseInitialJoursAbstinence: $("#AnalyseInitialJoursAbstinence").val(), AnalyseInitialeAspect: $("#AnalyseInitialeAspect").val(),
            AnalyseInitialeVolume: $("#AnalyseInitialeVolume").val(), AnalyseInitialeViscosite: $("#AnalyseInitialeViscosite").val(),
            AnalyseInitialeLiquefaction: $("#AnalyseInitialeLiquefaction").val(), AnalyseInitialeMorphologie: $("#AnalyseInitialeMorphologie").val(), AnalyseInitialeLeucocytes: $("#AnalyseInitialeLeucocytes").val(), AnalyseInitialeCelluleRondes: $("#AnalyseInitialeCelluleRondes").val(),
            AnalyseInitialeCelluleEpitheliales: $("#AnalyseInitialeCelluleEpitheliales").val(), AnalyseInitialeAgglutination: $("#AnalyseInitialeAgglutination").val(),
            AnalyseInitialeMobilite: $("#AnalyseInitialeMobilite").val(), AnalyseInitialeConcentration: $("#AnalyseInitialeConcentration").val(),
            AnalyseInitialeCommentaires: $("#AnalyseInitialeCommentaires").val(), ApresTraitementVolumeTraite: parseInt($("#ApresTraitementVolumeTraite").val()),
            ApresTraitementVolumeFinal: parseInt($("#ApresTraitementVolumeFinal").val()), ApresTraitementVolumeMobilite: $("#ApresTraitementVolumeMobilite").val(), ApresTraitementVolumeConcentration: parseInt($("#ApresTraitementVolumeConcentration").val()), ApresTraitementVolumeCommentaireFinal: parseInt($("#ApresTraitementVolumeCommentaireFinal").val()),
            ApresTraitementNumerationTotaleTd: parseInt($("#ApresTraitementNumerationTotaleTd").val()), ApresTraitementCommentaire: $("#ApresTraitementCommentaire").val()



        }
    }, function (result) {

        console.log(result)
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#ajouteDataPreparationSpermeM").modal('hide');
            $("#formPonctionAdd").trigger("reset");




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