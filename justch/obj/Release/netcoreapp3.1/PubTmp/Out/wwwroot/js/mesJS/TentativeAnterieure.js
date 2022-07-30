$().ready(function () {
    if (sessionStorage.getItem("IdRenseingnementClinique")) {
        creerRATable()
    }

    $("#ajoutertentativeanterieur").on('submit', function (e) {
        ajoutertentativeanterieur()
        e.preventDefault()
    })

    $("#modifiertentativeanterieur").on('submit', function (e) {
        modifierrtentativeanterieur()
        e.preventDefault()
    })
    

})


function modifierrtentativeanterieur() {
    $.post("/TentativeAnterieure/Update", {
        tentative: {
            Id: sessionStorage.getItem("IdTENTATIVEANTERIEUR"), IdRenseignementClinique: sessionStorage.getItem('IdRenseingnementClinique'), Acte: $("#ActtentativeA1").val()
            , Remarques: $("#RemarquestentativeA1").val(), Resultats: $("#ResultatstentativeA1").val(), Date: $("#Dateante1").val()
        }

    }, function (result) {

        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#ModifiierMTentativeAnterieur").modal('hide');

            creerRATable()



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

function creerRATable() {

    if (sessionStorage.getItem("IdRenseingnementClinique")) {
        $.get("/TentativeAnterieure/Gets", { IdRenseignement: sessionStorage.getItem("IdRenseingnementClinique") }, function (re) {
            if ($.fn.DataTable.isDataTable("#RATable")) {
                $('#RATable').DataTable().destroy();
            }
          
            $("#RATablebody").empty()
            var model = re.reverse()
            for (var i = 0; i < model.length; i++) {
                $("#RATablebody").append('<tr>' +
                    '<td>' + model[i]['Date'] + ' </td>' +

                    '<td>  ' + model[i]['Acte'] + '</td>' +
                    '<td> ' + model[i]['Remarques'] + ' </td>' +
                    '<td>' + model[i]['Resultats'] + ' </td>' +
                    '<td class="text - right">'
                    +
                    ' <a  href="#ModifiierMTentativeAnterieur" class="btn btn-outline-primary" onclick="editermodale(' + model[i]['Id'] + ')" ><i class="fa fa-pencil "></i>  </a>' +
                    '<a  href="#supprimerMTentativeAnterieur" class="btn btn-outline-danger"  onclick="supprimertentativeanterieur(' + model[i]['Id'] + ')" ><i class="fa fa-trash "></i>  </a>' +
                    '</td >' +
                    '</tr>'
                )
            }
            $('#RATable').DataTable({
                "sort": false,
                "reverse": true,

            })
        })


    }

}

function confirmesuppressiontentativean() {
    $.get("/TentativeAnterieure/Delete", { Id: sessionStorage.getItem("IdTENTATIVEANTERIEUR") }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#ModifiierMTentativeAnterieur").modal('hide');
            creerRATable()



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

    $("#supprimerMTentativeAnterieur").modal('hide')

}

function supprimertentativeanterieur(id) {
    sessionStorage.setItem("IdTENTATIVEANTERIEUR", id)
    $("#supprimerMTentativeAnterieur").modal('show')
}


function editermodale(id) {
    sessionStorage.setItem("IdTENTATIVEANTERIEUR", id)
    $.get("/TentativeAnterieure/GetById", { Id: id }, function (re) {
    
        $("#ActtentativeA1").val(re.Acte)
        $("#Dateante1").val(re.Date)
        $("#RemarquestentativeA1").val(re.Remarques)
        $("#ResultatstentativeA1").val(re.Resultats)
       
    })
    $("#ModifiierMTentativeAnterieur").modal('show')
 

}

function showTAM() {
    $("#ajouterTentativeAnterieur").modal('show')
}

function ajoutertentativeanterieur() {

    $.post("/TentativeAnterieure/Add", {
        tentative: {
            Id: 0, IdRenseignementClinique: sessionStorage.getItem('IdRenseingnementClinique'), Acte: $("#ActtentativeA").val()
            , Remarques: $("#RemarquestentativeA").val(), Resultats: $("#ResultatstentativeA").val(), Date: $("#Dateante").val()
        }

    }, function (result) {

        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#ajouterTentativeAnterieur").modal('hide');
            $("#ajoutertentativeanterieur").trigger("reset");
            creerRATable()



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