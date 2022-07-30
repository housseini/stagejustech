$().ready(function () {

    creerAPTable()
    $("#ajouteAntecedentParticulierF").on('submit', function (event) {
        ajouterAntecedentParticuliefo()
        event.preventDefault();
    })
    $("#modifierAntecedentParticulierF").on('submit', function (event1) {
        modifierAntecedentParticuliefo()
        event1.preventDefault()
    })


    

})


function showAPH() {


    $("#Alcool1").show()
    $("#Tabac1").show()
    sessionStorage.setItem("TYPEBILAN", "Bilan Homme");


    $("#ajouteAntecedentParticulie").modal("show")
}


function showAPF() {
    $("#Alcool1").hide()
    $("#Tabac1").hide()
    $("#TabacH").val('')
    $("#AlcoolH").val('')
    sessionStorage.setItem("TYPEBILAN", "Bilan Femme");
    $("#ajouteAntecedentParticulie").modal("show")
}
function creerAPTable() {
 
    if (sessionStorage.getItem("IdRenseingnementClinique")) {
        $.get("/AntecedentParticulier/Gets", { IdReneignement: sessionStorage.getItem("IdRenseingnementClinique") }, function (re) {
 
            if ($.fn.DataTable.isDataTable("#APTable")) {
                $('#APTable').DataTable().destroy();
            }

            $("#APTablebody").empty()

            if ($.fn.DataTable.isDataTable("#APHTable")) {
                $('#APHTable').DataTable().destroy();
            }

            $("#APHTablebody").empty()



            var model = re.reverse()
            for (var i = 0; i < model.length; i++) {
                if (re[i].TypeAntecedent == "Bilan Femme") {



                    $("#APTablebody").append('<tr>' +


                        '<td>  ' + model[i]['Medicaux'] + '</td>' +
                        '<td> ' + model[i]['Chirurgicaux'] + ' </td>' +
                        '<td>' + model[i]['Familiaux'] + ' </td>' +
                        '<td>' + model[i]['Gynecologiques'] + ' </td>' +
                        '<td>' + model[i]['Autres'] + ' </td>' +
                        '<td class="text - right">'
                        +
                        ' <a  href="#MODIFIERAntecedentParticulie" class="btn btn-outline-primary" onclick="editermodalap(' + model[i]['Id'] + ')" ><i class="fa fa-pencil "></i>  </a>' +
                        '<a  href="#supprimerMAntecedentParticulier" class="btn btn-outline-danger"  onclick="supprimermodalap(' + model[i]['Id'] + ')" ><i class="fa fa-trash "></i>  </a>' +
                        '</td >' +
                        '</tr>'
                    )
                } else {


                    $("#APHTablebody").append('<tr>' +


                        '<td>  ' + model[i]['Medicaux'] + '</td>' +
                        '<td> ' + model[i]['Chirurgicaux'] + ' </td>' +
                        '<td>' + model[i]['Familiaux'] + ' </td>' +
                        '<td>' + model[i]['Gynecologiques'] + ' </td>' +
                        '<td>' + model[i]['Tabac'] + ' </td>' +
                        '<td>' + model[i]['Alcool'] + ' </td>' +
                        '<td>' + model[i]['Autres'] + ' </td>' +
                        '<td class="text - right">'
                        +
                        ' <a  href="#MODIFIERAntecedentParticulie" class="btn btn-outline-primary" onclick="editermodalap(' + model[i]['Id'] + ')" ><i class="fa fa-pencil "></i>  </a>' +
                        '<a  href="#supprimerMAntecedentParticulier" class="btn btn-outline-danger"  onclick="supprimermodalap(' + model[i]['Id'] + ')" ><i class="fa fa-trash "></i>  </a>' +
                        '</td >' +
                        '</tr>'
                    )



                }
            }
            $('#APTable').DataTable({
                "sort": false,
                "reverse": true,

            })


            $('#APHTable').DataTable({
                "sort": false,
                "reverse": true,

            })




            
        })


    }

}
function supprimermodalap(id) {
    sessionStorage.setItem("IdAntecedentParticulier", id)
    $("#supprimerMAntecedentParticulier").modal('show')
}
function confirmesuppressionAntecedentParticulier() {


    $.get("/AntecedentParticulier/Delete", { Id: sessionStorage.getItem("IdAntecedentParticulier") }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#supprimerMAntecedentParticulier").modal('hide');
            creerAPTable()



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



function editermodalap(id) {
    sessionStorage.setItem("IdAntecedentParticulier", id)


    $.get("/AntecedentParticulier/Get", { Id: id }, function (re) {
        sessionStorage.setItem("TYPEBILAN", re.TypeAntecedent);
        if (re.TypeAntecedent == "Bilan Femme") {
            $("#APHOME1").hide()

            $("#APHOMmE1").hide()
            $("#Tabac1ap").val('')
            $("#Alcool1ap").val('')
        } else {
           
            $("#Alcool1").val(re.Alcool)
          
            $("#APHOME1").show()

            $("#APHOMmE1").show()

        }
        $("#TypeAntecedent1").val(re.TypeAntecedent)
        $("#Medicaux1").val(re.Medicaux)
        $("#Chirurgicaux1").val(re.Chirurgicaux)
        $("#Familiaux1").val(re.Familiaux)
        $("#Gynecologiques1").val(re.Gynecologiques)
        $("#Tabac1ap").val(re.Tabac)
        $("#Autres1").val(re.Autres)
        $("#Alcool1ap").val(re.Alcool)
        
    })
    $("#MODIFIERAntecedentParticulie").modal('show')

}

function ajouterAntecedentParticuliefo() {
        $.post("/AntecedentParticulier/Add", {
            antecedent: {
                Id: 0, IdRenseignementClinique: sessionStorage.getItem('IdRenseingnementClinique'), TypeAntecedent: sessionStorage.getItem("TYPEBILAN")
                , Medicaux: $("#Medicaux").val(), Chirurgicaux: $("#Chirurgicaux").val(), Familiaux: $("#Familiaux").val(), Gynecologiques: $("#Gynecologiques").val()
                , Tabac: $("#TabacH").val(), Alcool: $("#AlcoolH").val(), Autres: $("#Autres").val()
            }

        }, function (result) {

            if (result.status) {



                Swal.fire({

                    icon: 'success',
                    title: result.message,
                    showConfirmButton: false,
                    timer: 3000
                })

                $("#ajouteAntecedentParticulie").modal('hide');
                $("#ajouteAntecedentParticulierF").trigger("reset");
                creerAPTable()



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


function modifierAntecedentParticuliefo() {
    $.post("/AntecedentParticulier/Update", {
        antecedent: {
            Id: sessionStorage.getItem("IdAntecedentParticulier"), IdRenseignementClinique: sessionStorage.getItem('IdRenseingnementClinique'), TypeAntecedent: sessionStorage.getItem("TYPEBILAN")
            , Medicaux: $("#Medicaux1").val(), Chirurgicaux: $("#Chirurgicaux1").val(), Familiaux: $("#Familiaux1").val(), Gynecologiques: $("#Gynecologiques1").val()
            , Tabac: $("#Tabac1ap").val(), Alcool: $("#Alcool1ap").val(), Autres: $("#Autres1").val()
        }

    }, function (result) {

        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#MODIFIERAntecedentParticulie").modal('hide');
            $("#modifierAntecedentParticulierF").trigger("reset");
            creerAPTable()



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