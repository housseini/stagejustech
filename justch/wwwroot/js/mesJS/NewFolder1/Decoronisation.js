$().ready(function () {






    $('#acte3').mouseenter(function () {
       
        if ($("#example1 tbody tr").length ==1) {
            $('#acte3').css({ "cursor": 'not-allowed' });
        }
        else {
      

            $('#acte3').css({ "cursor": 'pointer' });

        }

    });

    $('#acte3').click((event) => {
        if ($("#example1 tbody tr").length == 1) {
            event.stopPropagation()
        }
    })




    //culture 

    $('#acte4').mouseenter(function () {

        if ($("#example1 tbody tr").length == 1) {
            $('#acte4').css({ "cursor": 'not-allowed' });
        }
        else {
          
          

            $('#acte4').css({ "cursor": 'pointer' });

        }

    });

    $('#acte4').click((event) => {
        if ($("#example1 tbody tr").length == 1) {
            event.stopPropagation()
        }
    })






















    teste2 = false


    $('#acte3,#acte4,#acte5,#acte6,#acte8').click((event) => {
        if (teste2 != true) {
            event.stopPropagation()
        }
    })



    //$('#acte3,#acte4,#acte5,#acte6 ,#acte8').mouseenter(function () {
    //    if (teste2 != true) {
    //        $('#acte4,#acte3 ,#acte5 ,#acte6 ,#acte8').css({ "cursor": 'not-allowed' });
    //    }
    //    else {

    //        $('#acte3,#acte4,#acte5,#acte6,#acte8').css({ "cursor": 'pointer' });

    //    }

    //});

    var table = $('#example').DataTable();

    $('#example tbody').on('click', 'tr', function () {
        $(this).toggleClass('selected');
        if ($.trim($(this).find('td').eq(1).text()) == "Dégeénèré") {

            $(this).toggleClass("odd selected");
        }

    });

    $('#button').click(function () {
        if ($('#example').DataTable().rows('.selected').data().toArray().length == 0) {
            Swal.fire({

                icon: 'error',
                title: 'Vous devez choisir au moin une ligne ',
                showConfirmButton: false,
                timer: 1500
            })

        } else {
            showEditActDataDecoronisationOvocyteDataM($('#example').DataTable().rows('.selected').data().toArray());

        }
    });






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


    $("#formAediteActDataDecoronisationOvocyteData").on('submit', function (e) {
        e.preventDefault()
        formEditeActDataDecoronisationOvocyteDataMEditefo()
      
    })



    


    $.get("/ActDataDecoronisation/GetByIdTraitement", { Id: sessionStorage.getItem("IdmedicalrecordActe") }, function (resulta) {

        if (resulta.length == 0) {
            $("#DecoronisationInfo1").hide()
            $("#DecoronisationInfo").show()
            $("#CultureInfo").show()
            $("#CultureInfo1").hide()
            
            $("#boutonActDataDecoronisation").append(' <a href="#ajouteDEcoronisationM" onclick="showaddDEcoronisationM()" class="btn btn-primary"><i class="fa fa-plus"></i>  Ajouter ActDataDecoronisation </a>')
        } else {
            teste2 = true
            $("#CultureInfo").hide()
            $("#CultureInfo1").show()
            $("#DecoronisationInfo1").show()
            $("#DecoronisationInfo").hide()
            sessionStorage.setItem("IdDataDecoronisation", resulta[0].Id)
            $("#DateDEcoronisation1").val(resulta[0].Date)
            $("#HeureDEcoronisation1").val(resulta[0].Heure)
            $("#CommentairesDEcoronisation1").val(resulta[0].Commentaires)

            $("#boutonActDataDecoronisation").append(' <a href="#modifierDEcoronisationM" onclick="showeditdecoronisationM()" class="btn btn-primary"><i class="fa fa-plus"></i>  editer ActDataDecoronisation </a>')
            $.get("/ActDataDecoronisationOvocyteData/GetByIdTraitement", { Id: resulta[0].Id }, function (resulta) {

               
                if (resulta.length == 0) {

                    $("#boutonActDataDecoronisation").append(' <a href="#AjouterActDataDecoronisationOvocyteDataM" onclick="showAddActDataDecoronisationOvocyteDataM()" class="btn btn-primary"><i class="fa fa-plus"></i>  Ajouter  ActDataDecoronisationOvocyteData </a>')

                } else {

                    re = []
                    re1=[]
                    resulta.forEach(item => {
                        re.push({ numero: item.DecoronisationOvocyteNumeroOvocyte, etat: item.DecoronisationOvocyteEtat, commentaire: item.DecoronisationOvocyteCommantaire })
                        if (item.DecoronisationOvocyteEtat == "Métaphase II" || item.DecoronisationOvocyteEtat == "Vésicule germinale =>Métaphase II"  || item.DecoronisationOvocyteEtat == "Métaphase I =>Métaphase II") {
                            re1.push({ numero: item.DecoronisationOvocyteNumeroOvocyte, etat: item.DecoronisationOvocyteEtat, commentaire: item.DecoronisationOvocyteCommantaire })
                        }


                    })

                    creatabledeconoOvocyte(re)
                    creatableinjetions(re1)

             
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

function creatableinjetions(re) {
  
    $("#nombreovovytesinjecter").val(re.length)
    $("#nombreovovytesinjecter1").text(re.length)
    
    $("#nombreDovocyteInjectione").text(re.length)
    
    if ($.fn.DataTable.isDataTable("#example1")) {
        $('#example1').DataTable().destroy();


    }
    $('#example1').DataTable({
        "filter": true,
        "aaData": re,
        "sort": false,
        "select": true,
        "aoColumns":
            [

                { "data": "numero", "name": "numero", "autoWidth": true },
                { "data": "etat", "name": "etat ", "autoWidth": true },
                { "data": "commentaire", "name": "commentaire", "autoWidth": true },


            ],

    });






}



function creatabledeconoOvocyte(re) {
    if ($.fn.DataTable.isDataTable("#example")) {
        $('#example').DataTable().destroy();


    }
    $('#example').DataTable({
        "filter": true,
        "aaData": re,
        "sort": false,
        "select": true,
        "aoColumns":
            [

                { "data": "numero", "name": " numero", "autoWidth": true },
                { "data": "etat", "name": "etat ", "autoWidth": true },
                { "data": "commentaire", "name": "commentaire", "autoWidth": true },
             

            ],

    });


    $('#example tbody   tr ').each(function () {
        console.log($.trim($(this).find('td').eq(0).text()))
        if ($.trim($(this).find('td').eq(1).text()) == "Dégeénèré" || $.trim($(this).find('td').eq(1).text()) == "Métaphase I") {

            $(this).css("background-color", '#F9B0DB');
        }


    });




}

function showAddActDataDecoronisationOvocyteDataM() {
    $('#AjouterActDataDecoronisationOvocyteDataM').modal('show')

}

function showaddDEcoronisationM() {
    $('#ajouteDEcoronisationM').modal('show')


}

function showEditActDataDecoronisationOvocyteDataM(r) {
    var t = ""
    listenumer=[]
    r.forEach(i => {
        t = t + "," + i.numero
        listenumer.push(i.numero)
    })

    console.log(listenumer)

    sessionStorage.setItem('numero', listenumer)
    $("#DecoronisationOvocyteNumeroOvocyte1").text(t)
    $('#modifierActDataDecoronisationOvocyteDataM').modal('show')

}

function showeditdecoronisationM() {
    $('#modifierDEcoronisationM').modal('show')
}
function formEditeActDataDecoronisationOvocyteDataMEditefo() {
    k = sessionStorage.getItem('numero')
   

    $.post("/ActDataDecoronisationOvocyteData/Update", {

        listenumero: k ,
            etat: $("#DecoronisationOvocyteEtat1").val(),
            commantaire: $("#DecoronisationOvocyteCommantaire1").val(),
            Iddeco: sessionStorage.getItem("IdDataDecoronisation")
        
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