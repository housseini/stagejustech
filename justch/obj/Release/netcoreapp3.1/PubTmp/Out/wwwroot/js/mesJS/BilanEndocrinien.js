$().ready(function () {
    creerTableBilanEndocrinien()
    $("#ajouteBilanEncodocrinienf").on('submit', function (e) {
        ajouterBilanEndocrinienfo()
        e.preventDefault()
    })

    

    $("#ModifierBilanEncodocrinienf").on('submit', function (e) {
        ModifierBilanEndocrinienfo()
        e.preventDefault()
    })

})

function showBilanEncodocrinienH() {
    sessionStorage.setItem("TYPEBILAN", "Bilan Homme");
    $("#Testosteroneh").show()
    $("#lhf").hide()
    $("#Lh").val('')

    $("#Prolactinef").hide()
    $("#Prolactine").val('')

    $("#Tshf").hide()
    $("#Tsh").val('')


    $("#E2f").hide()
    $("#E2").val('')

    $("#Progesteronef").hide()
    $("#Progesterone").val('')


    $("#Amhf").hide()
    $("#Amh").val('')

    $("#AjouterBilanEncodocrinien").modal("show")
}


function showBilanEncodocrinien() {
    sessionStorage.setItem("TYPEBILAN", "Bilan Femme");
    $("#Testosteroneh").hide()
    $("#Testosterone").val('')
    $("#AjouterBilanEncodocrinien").modal("show")
  
}
function ModifierBilanEndocrinienfo() {

    $.post("/BilanEndocrinien/Update", {
        bilan: {
            Id: sessionStorage.getItem('IdBilanEncodocrinien'), IdRenseignementClinique: sessionStorage.getItem('IdRenseingnementClinique'), Type: sessionStorage.getItem("TYPEBILAN")
            , Date: $("#DatesBilanEncodocrinien1").val(), Fsh: $("#Fsh1").val(), Lh: $("#Lh1").val(), Prolactine: $("#Prolactine1").val()
            , Tsh: $("#Tsh1").val(), E2: $("#E21").val(), Autres: $("#AutressE1").val(), Progesterone: $("#Progesterone1").val(), Amh: $("#Amh1").val(), Testosterone: $("#Testosterone1").val()
        }

    }, function (result) {

        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })
            creerTableBilanEndocrinien()
            $("#ModifierBilanEncodocrinien").modal('hide');
            $("#ModifierBilanEncodocrinienf").trigger("reset");
            




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







function ajouterBilanEndocrinienfo() {

    $.post("/BilanEndocrinien/Add", {
        bilan: {
            Id: 0, IdRenseignementClinique: sessionStorage.getItem('IdRenseingnementClinique'), Type: sessionStorage.getItem("TYPEBILAN")
            , Date: $("#DatesBilanEncodocrinien").val(), Fsh: $("#Fsh").val(), Lh: $("#Lh").val(), Prolactine: $("#Prolactine").val()
            , Tsh: $("#Tsh").val(), E2: $("#E2").val(), Autres: $("#AutressE").val(), Progesterone: $("#Progesterone").val(), Amh: $("#Amh").val(), Testosterone: $("#Testosterone").val()
        }

    }, function (result) {

        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#AjouterBilanEncodocrinien").modal('hide');
            $("#ajouteBilanEncodocrinienf").trigger("reset");
            creerTableBilanEndocrinien()



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

function creerTableBilanEndocrinien() {
    if (sessionStorage.getItem("IdRenseingnementClinique")) {
        $.get("/BilanEndocrinien/Gets", { id: sessionStorage.getItem("IdRenseingnementClinique") }, function (re) {
         
            if ($.fn.DataTable.isDataTable("#BilanEncodocrinienTable")) {
                $('#BilanEncodocrinienTable').DataTable().destroy();
            }

            $("#BilanEncodocrinienTablebody").empty()
          

            if ($.fn.DataTable.isDataTable("#BilanEncodocrinienTableH")) {
                $('#BilanEncodocrinienTableH').DataTable().destroy();
            }

            $("#BilanEncodocrinienTablebodHy").empty()




            var model = re.reverse()
            for (var i = 0; i < model.length; i++) {

                if (model[i]['Type'] == "Bilan Femme") {


                    $("#BilanEncodocrinienTablebody").append('<tr>' +

                        '<td>  ' + model[i]['Date'] + '</td>' +
                        '<td> ' + model[i]['Fsh'] + ' </td>' +
                        '<td>' + model[i]['Lh'] + ' </td>' +
                        '<td>' + model[i]['Prolactine'] + ' </td>' +
                        '<td> ' + model[i]['Tsh'] + ' </td>' +
                        '<td>' + model[i]['E2'] + ' </td>' +
                        '<td>' + model[i]['Progesterone'] + ' </td>' +
                        '<td> ' + model[i]['Amh'] + ' </td>' +

                        '<td>' + model[i]['Autres'] + ' </td>' +
                        '<td class="text - right">'
                        +
                        ' <a  href="#ModifierBilanEncodocrinien" class="btn btn-outline-primary" onclick="editermodalBilanE(' + model[i]['Id'] + ')" ><i class="fa fa-pencil "></i>  </a>' +
                        '<a  href="#supprimerMBilanEncodocrinien" class="btn btn-outline-danger"  onclick="supprimermodalBilanE(' + model[i]['Id'] + ')" ><i class="fa fa-trash "></i>  </a>' +
                        '</td >' +
                        '</tr>'
                    )
                }
                else {


                    $("#BilanEncodocrinienTablebodHy").append('<tr>' +

                        '<td>  ' + model[i]['Date'] + '</td>' +
                        '<td> ' + model[i]['Fsh'] + ' </td>' +
                   
                        '<td> ' + model[i]['Testosterone'] + ' </td>' +

                        '<td>' + model[i]['Autres'] + ' </td>' +
                        '<td class="text - right">'
                        +
                        ' <a  href="#ModifierBilanEncodocrinien" class="btn btn-outline-primary" onclick="editermodalBilanE(' + model[i]['Id'] + ')" ><i class="fa fa-pencil "></i>  </a>' +
                        '<a  href="#supprimerMBilanEncodocrinien" class="btn btn-outline-danger"  onclick="supprimermodalBilanE(' + model[i]['Id'] + ')" ><i class="fa fa-trash "></i>  </a>' +
                        '</td >' +
                        '</tr>'
                    )

                }
            }
            $('#BilanEncodocrinienTable').DataTable({
                "sort": false,
                "reverse": true,

            })

            $('#BilanEncodocrinienTableH').DataTable({
                "sort": false,
                "reverse": true,

            })
        })


    }




}


function supprimermodalBilanE(id) {
    sessionStorage.setItem('IdBilanEncodocrinien', id)

    $("#supprimerMBilanEncodocrinien").modal("show")
}


function confirmesuppressionBilanEncodocrinien() {
    $.get("/BilanEndocrinien/Delete", { Id: sessionStorage.getItem("IdBilanEncodocrinien") }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#supprimerMBilanEncodocrinien").modal('hide');
            creerTableBilanEndocrinien()



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



function editermodalBilanE(id) {
    sessionStorage.setItem('IdBilanEncodocrinien', id)
    $.get("/BilanEndocrinien/GETbyID", { Id: id }, function (re) {
        if (re.Type == "Bilan Femme") {



            sessionStorage.setItem("TYPEBILAN", re.Type);
            $("#Testosterone1h").hide()
            $("#DatesBilanEncodocrinien1").val(re.Date)
            $("#Fsh1").val(re.Fsh)
            $("#Lh1").val(re.Lh)
            $("#Prolactine1").val(re.Prolactine)
            $("#Tsh1").val(re.Tsh)
            $("#E21").val(re.E2)
            $("#Progesterone1").val(re.Progesterone)
            $("#Amh1").val(re.Amh)
            $("#Testosterone1").val('')
            $("#AutressE1").val(re.Autres)
        } else {
           
            $("#Lh1f").hide()
          

            $("#Prolactine1f").hide()
            

            $("#Tsh1f").hide()
      


            $("#E21f").hide()
            

            $("#Progesterone1").hide()
      


            $("#Amh1f").hide()
         
            sessionStorage.setItem("TYPEBILAN", re.Type);
            $("#Testosterone1h").show()
            $("#DatesBilanEncodocrinien1").val(re.Date)
            $("#Fsh1").val(re.Fsh)
            $("#Lh1").val('')
            $("#Prolactine1").val('')
            $("#Tsh1").val('')
            $("#E21").val('')
            $("#Progesterone1").val('')
            $("#Amh1").val('')
            $("#Testosterone1").val(re.Testosterone)
            $("#AutressE1").val(re.Autres)



        }
    })
    $("#ModifierBilanEncodocrinien").modal('show')
}