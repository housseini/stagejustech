$().ready(function () {


    $('a[target="_blank"] ').on('show.bs.tab', function (e) {
        localStorage.setItem('activeTb', $(e.target).attr('href'));
    });
    var activeTb = localStorage.getItem('activeTb');
    if (activeTb) {
      
        $('#myTab1 a[href="' + activeTb + '"]').tab('show');
    }



    creerSpermogrammeTMSTable()
    $("#ajouteSpermogrammeTMSf").on('submit', function (e) {
        ajouterSpermogramme()
        e.preventDefault()
    })




    $("#modifierSpermogrammeTggMSf").on('submit', function (e) {
      

        modifierSpermogramme()
        e.preventDefault()
     
    })


    
})

function showSpermogrammeC() {
    $("#ajouterSpermogrammeM").modal('show')
}

function modifierSpermogramme() {


    if ((parseInt($("#Mobilite1").val()) + parseInt($("#Mobilite12").val()) + parseInt($("#Mobilite13").val()) + parseInt($("#Mobilite14").val())) != 100) {
        Swal.fire({

            icon: 'error',
            title: 'la SOMME DES DIFFIERENT CHAMPS mobilite SAISIE DOIT ETRE EGALE A 100',
            showConfirmButton: false,
            timer: 3000
        })
    } else { 
    $.post("/SpermogrammeTMS/Update", {
        spermogramme: {
            Id: sessionStorage.getItem("IdSpermogrammeTMS"), IdRenseignementClinique: sessionStorage.getItem('IdRenseingnementClinique')
            , Date: $("#DateSpermogrammeTMS1").val(), Vol: $("#Vol1").val(), Num: $("#Num1").val(), Mobilite: $("#Mobilite1").val() + '/' + $("#Mobilite12").val() + '/' + $("#Mobilite13").val() + '/' + $("#Mobilite14").val()
            , Vita: $("#Vita1").val(), Leuco: $("#Leuco1").val(), FT: $("#FT1").val()
        }

    }, function (result) {

        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#modifierSpermogrammeM").modal('hide');
            creerSpermogrammeTMSTable()


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
}


function creerSpermogrammeTMSTable() {
  
    if (sessionStorage.getItem("IdRenseingnementClinique")) {
        $.get("/SpermogrammeTMS/Gets", { Idre: sessionStorage.getItem("IdRenseingnementClinique") }, function (re) {

            if ($.fn.DataTable.isDataTable("#SpermogrammeTable")) {
                $('#SpermogrammeTable').DataTable().destroy();
            }

            $("#SpermogrammeTablebody").empty()
            var model = re.reverse()
            for (var i = 0; i < model.length; i++) {
                $("#SpermogrammeTablebody").append('<tr>' +
                   

                    '<td>  ' + model[i]['Date'] + '</td>' +
                    '<td> ' + model[i]['Vol'] + ' </td>' +
                    '<td>' + model[i]['Num'] + ' </td>' +
                    '<td>' + model[i]['Mobilite'] + ' </td>' +
                    '<td> ' + model[i]['Vita'] + ' </td>' +
                    '<td>' + model[i]['Ft'] + ' </td>' +
                    '<td>' + model[i]['Leuco'] + ' </td>' +
                 
                    '<td class="text - right">'
                    +
                    ' <a  href="#modifierSpermogrammeM" class="btn btn-outline-primary" onclick="editermodalspermo(' + model[i]['Id'] + ')" ><i class="fa fa-pencil "></i>  </a>' +
                    '<a  href="#supprimerMBSpermogrammeTMS" class="btn btn-outline-danger"  onclick="supprimermodalspermo(' + model[i]['Id'] + ')" ><i class="fa fa-trash "></i>  </a>' +
                    '</td >' +
                    '</tr>'
                )
            }
            $('#SpermogrammeTable').DataTable({
                "sort": false,
                "reverse": true,

            })
        })


    }




}
function supprimermodalspermo(id) {
    sessionStorage.setItem("IdSpermogrammeTMS", id)
    $("#supprimerMBSpermogrammeTMS").modal('show')
}


function confirmesuppressionSpermogrammeTMS() {
    $.get("/SpermogrammeTMS/Delete", { Id: sessionStorage.getItem("IdSpermogrammeTMS") }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#supprimerMBSpermogrammeTMS").modal('hide');
            creerSpermogrammeTMSTable()



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

function editermodalspermo(id) {
    sessionStorage.setItem("IdSpermogrammeTMS", id)
    $.get("/SpermogrammeTMS/Get", { Id: id }, function (re) {
        
        
        $("#Vol1").val(re.Vol)
        $("#DateSpermogrammeTMS1").val(re.Date)
        $("#Num1").val(re.Num)
        $("#Mobilite1").val(re.Mobilite.split('/')[0])
        $("#Mobilite12").val(re.Mobilite.split('/')[1])
        $("#Mobilite13").val(re.Mobilite.split('/')[2])
        $("#Mobilite14").val(re.Mobilite.split('/')[3])
        $("#Vita1").val(re.Vita)
        $("#Leuco1").val(re.Leuco)

        $("#FT1").val(re.Ft)
     
    })
    $("#modifierSpermogrammeM").modal('show')
}





function ajouterSpermogramme() {

    if ((parseInt($("#Mobilite").val()) + parseInt($("#Mobilite2").val()) + parseInt($("#Mobilite3").val()) + parseInt($("#Mobilite4").val())) != 100) {
        Swal.fire({

            icon: 'error',
            title: 'la SOMME DES DIFFIERENT CHAMPS SAISIE DOIT ETRE EGALE A 100',
            showConfirmButton: false,
            timer: 3000
        })
    } else {

    


    $.post("/SpermogrammeTMS/Add", {
        spermogramme: {
            Id: 0, IdRenseignementClinique: sessionStorage.getItem('IdRenseingnementClinique')
            , Date: $("#DateSpermogrammeTMS").val(), Vol: $("#Vol").val(), Num: $("#Num").val(), Mobilite: $("#Mobilite").val() + '/' + $("#Mobilite2").val() + '/' + $("#Mobilite3").val() + '/' + $("#Mobilite4").val()
            , Vita: $("#Vita").val(), Leuco: $("#Leuco").val(), FT:$("#ft").val()
        }

    }, function (result) {

        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#ajouterSpermogrammeM").modal('hide');
            $("#ajouteSpermogrammeTMSf").trigger("reset");
            creerSpermogrammeTMSTable()


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
}












