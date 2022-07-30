
$().ready(function () {


    $('#acte6').mouseenter(function () {
   

        if ($("#tablecongelation tbody tr").length == 0) {
            $('#acte6').css({ "cursor": 'not-allowed' });
        }
        else {


            $('#acte6').css({ "cursor": 'pointer' });

        }

    });

    $('#acte6').click((event) => {
        if ($("#tablecongelation tbody tr").length == 0) {
            event.stopPropagation()
        }
    })
   
    $.get("/ActDataCongelationEnbryonnaire/GetByIdTraitement", { Id: sessionStorage.getItem("IdmedicalrecordActe") }, function (resulta) {

        if (resulta.length == 0) {
            $("#boutonActDataCongelationEnbryonnaire").append(' <a href="#AjouterActDataCongelationEnbryonnaireM" onclick="showaddboutonActDataCongelationEnbryonnaire()" class="btn btn-primary"><i class="fa fa-plus"></i>  Ajouter Act Congelation Enbryonnaire </a>')
        } else {
           
            $.get("/EnbryonnaireCongelationData/GetByIdTraitement", { Id: resulta[0].Id }, function (res) {
                
                if (res.length == 0) {
                    sessionStorage.setItem("IdActDataCongelationEnbryonnaire", resulta[0].Id)
                    $("#boutonActDataCongelationEnbryonnaire").append(' <a href="#EditerActDataCongelationEnbryonnaireM" onclick="showaediteboutonActDataCongelationEnbryonnaire()" class="btn btn-primary"><i class="fa fa-plus"></i>  Editer Act Congelation Enbryonnaire </a>')

                    $("#boutonActDataCongelationEnbryonnaire").append(' <a href="#ajouterEnbryonnaireCongelationDataM" onclick="showaddEnbryonnaireCongelationData()" class="btn btn-primary"><i class="fa fa-plus"></i>  ajouter Enbryonnaire Congelation Data </a>')


                } else {
                    
 

                    sessionStorage.setItem("IdActDataCongelationEnbryonnaire", resulta[0].Id)
                  
                 
             
                    ////$("#boutonActDataCongelationEnbryonnaire").append(' <a href="#EditerActDataCongelationEnbryonnaireM" onclick="showaediteboutonActDataCongelationEnbryonnaire()" class="btn btn-primary"><i class="fa fa-plus"></i>  Editer Act Congelation Enbryonnaire </a>')
                    ////$("#boutonCongelationEnbryonnaireDATA").append(' <a href="#EditerCongelationEnbryonnaireDATAM" onclick="showaeditebCongelationEnbryonnaireDATAe()" class="btn btn-primary"><i class="fa fa-plus"></i>  Editer Congelation Enbryonnaire DATA</a>')
                    ////$("#DateeEnbryonnaireCongelationData").text(res[0].Date)
                    ////$("#DateEnbryonnaireCongelationData1").val(res[0].Date)

                    ////$("#IdEnbryologisteDoctorEnbryonnaireCongelationData1").val(res[0].IdEnbryologisteDoctor)

                    ////$("#HeureeEnbryonnaireCongelationData").text(res[0].Heure)
                    ////$("#HeureEnbryonnaireCongelationData1").val(res[0].Heure)

                    ////$("#NumeroEnbroyoneEnbryonnaireCongelationData").text(res[0].NumeroEnbroyon)
                    ////$("#NumeroEnbryonnaireCongelationData1").val(res[0].NumeroEnbroyon)

                    ////$("#jourCongelationEnbryonnaireCongelationData").text(res[0].jourCongelation)
                    ////$("#jourCongelationEnbryonnaireCongelationData1").val(res[0].jourCongelation)

                    ////$("#GradeEnbryonEnbryonnaireCongelationData").text(res[0].GradeEnbryon)
                    ////$("#GradeEnbryon1").val(res[0].GradeEnbryon)

                    ////$("#MilieueEnbryonnaireCongelationData").text(res[0].Milieu)
                    ////$("#MilieuEnbryonnaireCongelationData1").val(res[0].Milieu)

                    ////$("#StatueEnbryonnaireCongelationData").text(res[0].Statu)
                    ////$("#StatuEnbryonnaireCongelationData1").val(res[0].Statu)
                    ////$("#CommentairesEnbryonnaireCongelationData1").val(res[0].Commentaires)

                    ////$("#CommentaireseEnbryonnaireCongelationData").text(res[0].Commentaires)
                    ////$("#IdPailleEnbryonnaireCongelationData1").val(res[0].Id)






                    ////$.get("/Paillette/GetById", { Id: res[0].IdPaillette }, function (re) {

                    ////    $('#PailletteeEnbryonnaireCongelationData').text(' .')

                    ////    $('#PailletteeEnbryonnaireCongelationData').css("background-color", re[0].Couleur)
                    ////    $('#IdPailleEnbryonnaireCongelationData1').css("background-color", re[0].Couleur)

           /*         })*/

                 /*   $("#PailletteeEnbryonnaireCongelationData").css(res[0].Heure)*/


                }

               
            })



            $("#NombreeCongélationEnbryonsCongelation").text(resulta[0].NombreEnbryonsCongeles)
            $("#CommentaireActDataCongelationEnbryonnaire").text(resulta[0].Commentaires)

            $("#NombreEnbryonsCongeles1").val(resulta[0].NombreEnbryonsCongeles)
            $("#CommentairesEnbryonsCongeles1").val(resulta[0].Commentaires)
        }
    })



    $('#IdPailleEnbryonnaireCongelationData').change(function (event) {




        $.get("/Paillette/GetById", { Id: event.target.value }, function (re) {


            $('#IdPailleEnbryonnaireCongelationData').css("background-color", re[0].Couleur)

        })
        //    $('#IdVisotube').css("background-color", event.target.value)
    })

    $('#IdPailleEnbryonnaireCongelationData1').change(function (event) {




        $.get("/Paillette/GetById", { Id: event.target.value }, function (re) {


            $('#IdPailleEnbryonnaireCongelationData1').css("background-color", re[0].Couleur)

        })
        //    $('#IdVisotube').css("background-color", event.target.value)
    })


    $('#IdPailleCongelationOvocyteData').change(function (event) {




        $.get("/Paillette/GetById", { Id: event.target.value }, function (re) {


            $('#IdPailleCongelationOvocyteData').css("background-color", re[0].Couleur)


        })
        //    $('#IdVisotube').css("background-color", event.target.value)
    })



    $('#IdPailleCongelationOvocyteData1').change(function (event) {




        $.get("/Paillette/GetById", { Id: event.target.value }, function (re) {


            $('#IdPailleCongelationOvocyteData1').css("background-color", re[0].Couleur)


        })
        //    $('#IdVisotube').css("background-color", event.target.value)
    })




    $.get("/Paillette/Gets", function (re) {
        for (i = 0; i < re.length; i++) {

            $("#IdPailleEnbryonnaireCongelationData").append('<option  style="background-color:' + re[i].Couleur +';"  id="' + re[i].Couleur.split("#")[1] + '"   value="' + re[i].Id+'">  </option>')
            $("#IdPailleEnbryonnaireCongelationData1").append('<option  style="background-color:' + re[i].Couleur +';"   id="' + re[i].Couleur.split("#")[1] + 1+'"   value="' + re[i].Id + '">  </option>')

            $("#IdPailleCongelationOvocyteData").append('<option  style="background-color:' + re[i].Couleur +';"    id="' + re[i].Couleur.split("#")[1] + 11+ '"   value="' + re[i].Id + '">.  </option>')
            $("#IdPailleCongelationOvocyteData1").append('<option  style="background-color:' + re[i].Couleur +';"    id="' + re[i].Couleur.split("#")[1] + 11+ '"   value="' + re[i].Id + '">.  </option>')

        }
    })


    $("#formAAjouterActDataCongelationEnbryonnaireMAdd").on('submit', function (e) {
      AjouterActDataCongelationEnbryonnairefo()
        e.preventDefault()

   
    })


    $("#formAediterActDataCongelationEnbryonnaireMAdd").on('submit', function (e) {
        editerActDataCongelationEnbryonnairefo()
        e.preventDefault()


    })


    $("#formEnbryonnaireCongelationData").on('submit', function (e) {
        AjouterEnbryonnaireCongelationDatafo()
        e.preventDefault()


    })


    $("#formediteEnbryonnaireCongelationData").on('submit', function (e) {
        EditerEnbryonnaireCongelationDatafo()
        e.preventDefault()


    })


    
    
    


})


function showaddboutonActDataCongelationEnbryonnaire() {
    $('#AjouterActDataCongelationEnbryonnaireM').modal('show')
}


function showaediteboutonActDataCongelationEnbryonnaire() {
    $('#EditerActDataCongelationEnbryonnaireM').modal('show')
}
function AjouterActDataCongelationEnbryonnairefo() {
    $.post("/ActDataCongelationEnbryonnaire/Add", {
        actData: {
            Id: 0, IdMedicalRecordAct: sessionStorage.getItem("IdmedicalrecordActe"),
            NombreEnbryonsCongeles: parseInt($("#NombreEnbryonsCongeles").val()), Commentaires: ($("#CommentairesEnbryonsCongeles").val()) }
    }, function (result) {
        if (result.status) {
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#AjouterActDataCongelationEnbryonnaireM").modal('hide');
            $("#formAAjouterActDataCongelationEnbryonnaireMAdd").trigger("reset");
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


function showaeditebCongelationEnbryonnaireDATAe(id) {
    sessionStorage.setItem("IdEnbryonnaireCongelationData",id)
    $.get("/EnbryonnaireCongelationData/GET", { Id: id }, function (res) {
        console.log(res)

                  $("#DateEnbryonnaireCongelationData1").val(res.Date)

                    $("#IdEnbryologisteDoctorEnbryonnaireCongelationData1").val(res.IdEnbryologisteDoctor)

                    $("#HeureEnbryonnaireCongelationData1").val(res.Heure)

                    $("#NumeroEnbryonnaireCongelationData1").val(res.NumeroEnbroyon)

                    $("#jourCongelationEnbryonnaireCongelationData1").val(res.jourCongelation)

                    $("#GradeEnbryon1").val(res.GradeEnbryon)

                    $("#MilieuEnbryonnaireCongelationData1").val(res.Milieu)

                    $("#StatuEnbryonnaireCongelationData1").val(res.Statu)
                    $("#CommentairesEnbryonnaireCongelationData1").val(res.Commentaires)

                    $("#IdPailleEnbryonnaireCongelationData1").val(res.Id)



    })

    $('#EditerCongelationEnbryonnaireDATAM').modal('show')

}



function editerActDataCongelationEnbryonnairefo() {
    $.post("/ActDataCongelationEnbryonnaire/Update", {
        actData: {
            Id: 0, IdMedicalRecordAct: sessionStorage.getItem("IdmedicalrecordActe"),
            NombreEnbryonsCongeles: parseInt($("#NombreEnbryonsCongeles1").val()), Commentaires: ($("#CommentairesEnbryonsCongeles1").val())
        }
    }, function (result) {
        if (result.status) {
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#EditerActDataCongelationEnbryonnaireM").modal('hide');
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


function showaddEnbryonnaireCongelationData() {
    $("#ajouterEnbryonnaireCongelationDataM").modal('show')

}



function AjouterEnbryonnaireCongelationDatafo() {

    $.post("/EnbryonnaireCongelationData/Add", {
        actData: {
            Id: 0, IdActDataCongelationEnbryonnaire: sessionStorage.getItem("IdActDataCongelationEnbryonnaire"),
            IdPaillette: parseInt($("#IdPailleEnbryonnaireCongelationData").val()),
            IdEnbryologisteDoctor: parseInt($("#IdEnbryologisteDoctorEnbryonnaireCongelationData").val()),
            EmbryologisteDoctorType:"Embryologiste",
            jourCongelation: parseInt($("#jourCongelationEnbryonnaireCongelationData").val()),
            Heure: ($("#HeureEnbryonnaireCongelationData").val()),
            GradeEnbryon: ($("#GradeEnbryon").val()),
            Date: ($("#DateEnbryonnaireCongelationData").val()),
            Commentaires: ($("#CommentairesEnbryonnaireCongelationData").val()),
            Milieu: ($("#MilieuEnbryonnaireCongelationData").val()),
            Statu: ($("#StatuEnbryonnaireCongelationData").val()),
            NumeroEnbroyon: parseInt($("#NumeroEnbryonnaireCongelationData").val())   }
    }, function (result) {
        if (result.status) {
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#ajouterEnbryonnaireCongelationDataM").modal('hide');
            $("#formEnbryonnaireCongelationData").trigger("reset");
            window.location.reload();



        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })





        }



    })


}




function EditerEnbryonnaireCongelationDatafo() {



    $.post("/EnbryonnaireCongelationData/Update", {
        actData: {
            Id: sessionStorage.getItem("IdEnbryonnaireCongelationData"), IdActDataCongelationEnbryonnaire: sessionStorage.getItem("IdActDataCongelationEnbryonnaire"),
            IdPaillette: parseInt($("#IdPailleEnbryonnaireCongelationData1").val()),
            IdEnbryologisteDoctor: parseInt($("#IdEnbryologisteDoctorEnbryonnaireCongelationData1").val()),
            EmbryologisteDoctorType: "Embryologiste",
            jourCongelation: ($("#jourCongelationEnbryonnaireCongelationData1").val()),
            Heure: ($("#HeureEnbryonnaireCongelationData1").val()),
            GradeEnbryon: ($("#GradeEnbryon1").val()),
            Date: ($("#DateEnbryonnaireCongelationData1").val()),
            Commentaires: ($("#CommentairesEnbryonnaireCongelationData1").val()),
            Milieu: ($("#MilieuEnbryonnaireCongelationData1").val()),
            Statu: "Congelé",
            NumeroEnbroyon: 0
        }
    }, function (result) {
        if (result.status) {
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#EditerCongelationEnbryonnaireDATAM").modal('hide');
          
            window.location.reload();



        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })





        }



    })


}