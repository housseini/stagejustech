$().ready(function () {
   
    creerSetologieTable()
    $("#ajouteserologief").on('submit', function (e) {
        ajoutersterologie()
        e.preventDefault()
    })

    $("#modifierserologief").on('submit', function (e) {
        modifierserologie()
        e.preventDefault()
    })
   

})



function ajoutersterologie() {
    $.post("/Serologie/Add", {
        Serologie: {
            Id: 0, IdRenseignementClinique: sessionStorage.getItem('IdRenseingnementClinique'), TypeSerologie: sessionStorage.getItem("TYPEBILAN")
            , Date: $("#Dates").val(), Hiv: $("#Hiv").val(), Hvb: $("#Hvb").val(), Hvc: $("#Hvc").val()
            , Syphilis: $("#Syphilis").val(), Chlamydia: $("#Chlamydia").val(), Autres: $("#Autress").val(), Mycoplasmes: $("#Mycoplasmes").val()
        }

    }, function (result) {

        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#ajouteMserologie").modal('hide');
            $("#ajouteserologief").trigger("reset");
            creerSetologieTable()



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

function modifierserologie() {
    $.post("/Serologie/Update", {
        Serologie: {
            Id: sessionStorage.getItem("IdSerologie"), IdRenseignementClinique: sessionStorage.getItem('IdRenseingnementClinique'), TypeSerologie: sessionStorage.getItem("TYPEBILAN")
            , Date: $("#Datesss1").val(), Hiv: $("#Hiv1").val(), Hvb: $("#Hvb1").val(), Hvc: $("#Hvc1").val()
            , Syphilis: $("#Syphilis1").val(), Chlamydia: $("#Chlamydia11").val(), Autres: $("#Autress1").val(), Mycoplasmes: $("#Mycoplasmes1").val()
        }

    }, function (result) {

        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#ModifierMserologie").modal('hide');

            creerSetologieTable()



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






function showSerologie() {
    sessionStorage.setItem("TYPEBILAN", "Bilan Femme");
    $("#ajouteMserologie").modal("show")
}

function creerSetologieTable() {
    if (sessionStorage.getItem("IdRenseingnementClinique")) {
        $.get("/Serologie/Gets", { IdReneignement: sessionStorage.getItem("IdRenseingnementClinique") }, function (re) {
          
            if ($.fn.DataTable.isDataTable("#SerologieTable")) {
                $('#SerologieTable').DataTable().destroy();
            }

            $("#SerologieTablebody").empty()

            if ($.fn.DataTable.isDataTable("#SerologieTableH")) {
                $('#SerologieTableH').DataTable().destroy();
            }

            $("#SerologieTablebodyH").empty()
            var model = re.reverse()
            for (var i = 0; i < model.length; i++) {
                if (model[i]['TypeSerologie'] == "Bilan Femme") {



                    $("#SerologieTablebody").append('<tr>' +

                        '<td>  ' + model[i]['Date'] + '</td>' +
                        '<td> ' + model[i]['Hiv'] + ' </td>' +
                        '<td>' + model[i]['Hvb'] + ' </td>' +
                        '<td>' + model[i]['Hvc'] + ' </td>' +
                        '<td> ' + model[i]['Syphilis'] + ' </td>' +
                        '<td>' + model[i]['Chlamydia'] + ' </td>' +
                        '<td>' + model[i]['Mycoplasmes'] + ' </td>' +
                        '<td>' + model[i]['Autres'] + ' </td>' +
                        '<td class="text - right">'
                        +
                        ' <a  href="#ModifierMserologie" class="btn btn-outline-primary" onclick="editermodalserologie(' + model[i]['Id'] + ')" ><i class="fa fa-pencil "></i>  </a>' +
                        '<a  href="#supprimerMserologie" class="btn btn-outline-danger"  onclick="supprimermodalserologie(' + model[i]['Id'] + ')" ><i class="fa fa-trash "></i>  </a>' +
                        '</td >' +
                        '</tr>'
                    )
                } else {


                    $("#SerologieTablebodyH").append('<tr>' +

                        '<td>  ' + model[i]['Date'] + '</td>' +
                        '<td> ' + model[i]['Hiv'] + ' </td>' +
                        '<td>' + model[i]['Hvb'] + ' </td>' +
                        '<td>' + model[i]['Hvc'] + ' </td>' +
                        '<td> ' + model[i]['Syphilis'] + ' </td>' +
                        '<td>' + model[i]['Chlamydia'] + ' </td>' +
                        '<td>' + model[i]['Mycoplasmes'] + ' </td>' +
                        '<td>' + model[i]['Autres'] + ' </td>' +
                        '<td class="text - right">'
                        +
                        ' <a  href="#ModifierMserologie" class="btn btn-outline-primary" onclick="editermodalserologie(' + model[i]['Id'] + ')" ><i class="fa fa-pencil "></i>  </a>' +
                        '<a  href="#supprimerMserologie" class="btn btn-outline-danger"  onclick="supprimermodalserologie(' + model[i]['Id'] + ')" ><i class="fa fa-trash "></i>  </a>' +
                        '</td >' +
                        '</tr>'
                    )

                }
            }
            $('#SerologieTable').DataTable({
                "sort": false,
                "reverse": true,

            })

            $('#SerologieTableH').DataTable({
                "sort": false,
                "reverse": true,

            })
        })


    }




}

function confirmesuppressionSEROLOGIE() {

    $.get("/Serologie/Delete", { Id: sessionStorage.getItem("IdSerologie") }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#supprimerMserologie").modal('hide');
            creerSetologieTable()



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


function showSerologieH() {
    sessionStorage.setItem("TYPEBILAN", "Bilan Homme");
    $("#ajouteMserologie").modal("show")
}


function supprimermodalserologie(id) {
    sessionStorage.setItem("IdSerologie", id)
    $("#supprimerMserologie").modal('show')
}
function editermodalserologie(id) {

    sessionStorage.setItem("IdSerologie", id)
    $.get("/Serologie/GETbyID", { Id: id }, function (re) {

        sessionStorage.setItem("TYPEBILAN", re.TypeSerologie)
        $("#Datesss1").val(re.Date)
        $("#Hiv1").val(re.Hiv)
        $("#Hvb1").val(re.Hvb)
        $("#Hvc1").val(re.Hvc)
        $("#Syphilis1").val(re.Syphilis)
        $("#Chlamydia11").val(re.Chlamydia)
        $("#Mycoplasmes1").val(re.Mycoplasmes)
        $("#Autress1").val(re.Autres)
    })
    $("#ModifierMserologie").modal('show')

}