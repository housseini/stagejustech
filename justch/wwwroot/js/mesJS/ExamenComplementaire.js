$().ready(function () {
    if (sessionStorage.getItem("IdRenseingnementClinique")) {
        creerECTable()
       
    }


    

    $("#ModifierExamenComplementaire").on('submit', function (e) {
        ModifierExamenComplementaire()
        e.preventDefault()
    })


    $("#ajouterExamenComplementaire").on('submit', function (e) {
        ajouterExamenComplementaire()
        e.preventDefault()
    })



})

function ModifierExamenComplementaire() {
    $.post("/ExamenComplementaire/Update", {
        examen: {
            Id: sessionStorage.getItem("IdExamenComplementaire"), IdRenseignementClinique: sessionStorage.getItem('IdRenseingnementClinique'), Echo: $("#Echo1").val()
            , Hsg: $("#Hsg1").val(), Hsg_Hs: $("#Hsg_Hs1").val(), Tpc: $("#Tpc1").val(), Cytogenetique: $("#Cytogenetique1").val()
        }

    }, function (result) {

        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#ModifiererMExamenComplementaire").modal('hide');
            creerECTable()



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



function creerECTable() {

    if (sessionStorage.getItem("IdRenseingnementClinique")) {
        $.get("/ExamenComplementaire/Gets", { IdREnseignement: sessionStorage.getItem("IdRenseingnementClinique") }, function (re) {
          
            if ($.fn.DataTable.isDataTable("#ECTable")) {
                $('#ECTable').DataTable().destroy();
            }

            $("#ECTablebody").empty()
            var model = re.reverse()
            for (var i = 0; i < model.length; i++) {
                $("#ECTablebody").append('<tr>' +
                    '<td>' + model[i]['Echo'] + ' </td>' +

                    '<td>  ' + model[i]['Hsg'] + '</td>' +
                    '<td> ' + model[i]['Hsg_Hs'] + ' </td>' +
                    '<td>' + model[i]['Tpc'] + ' </td>' +
                    '<td>' + model[i]['Cytogenetique'] + ' </td>' +
                    '<td class="text - right">'
                    +
                    ' <a  href="#" class="btn btn-outline-primary" onclick="editermodaleexamC(' + model[i]['Id'] + ')" ><i class="fa fa-pencil "></i>  </a>' +
                    '<a  href="#" class="btn btn-outline-danger"  onclick="supprimerexamenCr(' + model[i]['Id'] + ')" ><i class="fa fa-trash "></i>  </a>' +
                    '</td >' +
                    '</tr>'
                )
            }
            $('#ECTable').DataTable({
                "sort": false,
                "reverse": true,

            })
        })


    }

}

function supprimerexamenCr(id) {
    sessionStorage.setItem("IdExamenComplementaire", id)
    $("#supprimerMExamenComplementaire").modal('show')
}

function confirmesuppressionExamenComplementaire() {



    $.get("/ExamenComplementaire/Delete", { Id: sessionStorage.getItem("IdExamenComplementaire") }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#supprimerMExamenComplementaire").modal('hide');
            creerECTable()



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


function editermodaleexamC(id) {
    sessionStorage.setItem("IdExamenComplementaire", id)
    $.get("/ExamenComplementaire/GetsbyID", { Id: id }, function (re) {

        $("#Echo1").val(re.Echo)
        $("#Hsg1").val(re.Hsg)
        $("#Hsg_Hs1").val(re.Hsg_Hs)
        $("#Tpc1").val(re.Tpc)
        $("#Cytogenetique1").val(re.Cytogenetique)
    })
    $("#ModifiererMExamenComplementaire").modal('show')

}









function ajouterExamenComplementaire() {
    $.post("/ExamenComplementaire/Add", {
        examen: {
            Id: 0, IdRenseignementClinique: sessionStorage.getItem('IdRenseingnementClinique'), Echo: $("#Echo").val()
            , Hsg: $("#Hsg").val(), Hsg_Hs: $("#Hsg_Hs").val(), Tpc: $("#Tpc").val(), Cytogenetique: $("#Cytogenetique").val()
        }

    }, function (result) {

        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#ajouterMExamenComplementaire").modal('hide');
            $("#ajouterExamenComplementaire").trigger("reset");
            creerECTable()



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















function showEC() {
    $("#ajouterMExamenComplementaire").modal("show")
}