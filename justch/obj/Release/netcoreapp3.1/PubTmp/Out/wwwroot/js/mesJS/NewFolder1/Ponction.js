$().ready(function () {
    teste1 = false
    //$('a[data-toggle="tab"]').on('show.bs.tab', function (e) {
    //    localStorage.setItem('activeTab', $(e.target).attr('href'));
    //});
    //var activeTab = localStorage.getItem('activeTab');
    //if (activeTab) {

    //    $('#myTab2 a[href="' + activeTab + '"]').tab('show');
    //}



    $('#acte2').click((event) => {
        if (teste1 != true) {
            event.stopPropagation()
        } 
    })



    $('#acte2').mouseenter(function () {
        if(teste1 != true) {
            $(' #acte2').css({ "cursor": 'not-allowed' });
        }
        else {

            $('#acte2').css({ "cursor": 'pointer' });

        }
      
    });


    $.get("/ActDataPonction/GetByIdTraitement", { Id: sessionStorage.getItem("IdmedicalrecordActe") }, function (resulta) {

        if (resulta.length == 0) {
            $('#ponctionInfo1').hide()
            $('#ponctionEInfo1').hide()
            $('#ponctionEInfo').show()
            $("#boutonponction").append(' <a href="#ajoutePontionM" onclick="showaddPontionM()" class="btn btn-primary"><i class="fa fa-plus"></i>  Ajouter Ponction </a>')
        } else {
            teste1 = true
            $('#ponctionInfo').hide()
            $('#ponctionInfo1').show()
            $('#ponctionEInfo1').show()
            $('#ponctionEInfo').hide()
            $.get("/Doctor/Gets", function (re) {
                for (i = 0; i < re.length; i++) {
                    if (re[i].Id == resulta[0].IdTretingDoctor) {
                        $("#IdTretingDoctor1").append('<option  selected value="' + re[i].Id + '"> ' + re[i].FirstName + '  ' + re[i].LastName + '</option>')
                    }
                }


            })

            $.get("/Utilisateur/GetUtilisateursEnbrologite", function (re) {

                for (i = 0; i < re.length; i++) {
                    if (re[i].Id == resulta[0].IdEnbryologisteDoctor) {
                    $("#IdEnbryologisteDoctor1").append('<option selected value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
                    }
                }


            })
            $.get("/Incubateur_Chambre/GetsChambreByIdncubateur", { Id: resulta[0].IdIncubateur}, function (re1) {


                for (i = 0; i < re1.length; i++) {
                    
                    $("#Chambree1").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                }
            })
           
            
            $("#boutonponction").append(' <a href="#modifierPontionM" onclick="showeditePontionM()" class="btn btn-primary"><i class="fa fa-plus"></i>  editer Ponction </a>')
            $("#Chambreeeee").text(resulta[0].Chambre)
            $("#Datees").text(resulta[0].Date)
            $("#Dateponctiion1").val(resulta[0].Date)
            $("#heuree").text(resulta[0].Heure)
            $("#Heure1").val(resulta[0].Heure)
            $("#nombre_Follicules").text(resulta[0].NombreFollicules)
            $("#NombreFollicules1").val(resulta[0].NombreFollicules)
            $("#NombreOvocytesCollecte1").val(resulta[0].NombreOvocytesCollectes)
            $("#nombre_Ovocytes_Collects").text(resulta[0].NombreOvocytesCollectes)
            $("#nombre_Tubes").text(resulta[0].NombreType)
            $("#NombreType1").val(resulta[0].NombreType)
            $("#Ovocytes_Degeneres").text(resulta[0].OvocytesDegeneres)
            $("#OvocytesDegeneres1").val(resulta[0].OvocytesDegeneres)

            $("#Commentaire").text(resulta[0].Commentaires)
            $("#Commentaires1").text(resulta[0].Commentaires)

        }

    })




    $("#formPonctionAdd").on('submit', function (e) {
        ajoutePontionfo()
        e.preventDefault()
    })



    $("#formPonctionedite").on('submit', function (e) {
        modifierPontionfo()
        e.preventDefault()
    })


    



    $.get("/Doctor/Gets", function (re) {
        
        for (i = 0; i < re.length; i++) {
            $("#IdTretingDoctor1").append('<option value="' + re[i].Id + '"> ' + re[i].FirstName + '  ' + re[i].LastName + '</option>')

            $("#IdTretingDoctor").append('<option value="' + re[i].Id + '"> ' + re[i].FirstName + '  ' + re[i].LastName +'</option>')
            $("#IdTretingDoctorDEcoronisation").append('<option value="' + re[i].Id + '"> ' + re[i].FirstName + '  ' + re[i].LastName +'</option>')
            $("#IdTretingDoctorDEcoronisation1").append('<option value="' + re[i].Id + '"> ' + re[i].FirstName + '  ' + re[i].LastName +'</option>')
            $("#IdTretingDoctorInjection").append('<option value="' + re[i].Id + '"> ' + re[i].FirstName + '  ' + re[i].LastName +'</option>')
            $("#IdTretingDoctorInjection1").append('<option value="' + re[i].Id + '"> ' + re[i].FirstName + '  ' + re[i].LastName +'</option>')
            $("#IdTretingDoctorBiopsieTesticulaire").append('<option value="' + re[i].Id + '"> ' + re[i].FirstName + '  ' + re[i].LastName +'</option>')
            $("#IdTretingDoctorBiopsieTesticulaire1").append('<option value="' + re[i].Id + '"> ' + re[i].FirstName + '  ' + re[i].LastName +'</option>')
            $("#IdTretingDoctorInseminationIAC").append('<option value="' + re[i].Id + '"> ' + re[i].FirstName + '  ' + re[i].LastName +'</option>')
            $("#IdTretingDoctorInseminationIAC1").append('<option value="' + re[i].Id + '"> ' + re[i].FirstName + '  ' + re[i].LastName +'</option>')
            $("#IdTretingDoctorActDataCongelationSperme").append('<option value="' + re[i].Id + '"> ' + re[i].FirstName + '  ' + re[i].LastName +'</option>')
            $("#IdTretingDoctorActDataCongelationSperme1").append('<option value="' + re[i].Id + '"> ' + re[i].FirstName + '  ' + re[i].LastName +'</option>')
            $("#IdTreatingDoctorActDataBiopsie").append('<option value="' + re[i].Id + '"> ' + re[i].FirstName + '  ' + re[i].LastName +'</option>')
            $("#IdTreatingDoctorActDataBiopsie1").append('<option value="' + re[i].Id + '"> ' + re[i].FirstName + '  ' + re[i].LastName +'</option>')
            $("#IdEnbryologisteDoctorEnbryonnaireMedecinCongelationData").append('<option value="' + re[i].Id + '"> ' + re[i].FirstName + '  ' + re[i].LastName +'</option>')
            

        }


    })

    $.get("/Utilisateur/GetUtilisateursEnbrologite", function (re) {
    
        for (i = 0; i < re.length; i++) {
            $("#IdEnbryologisteDoctor").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdEnbryologisteDoctor1").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdEnbryologisteDoctorDEcoronisation").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdEnbryologisteDoctorDEcoronisation1").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdEnbryologisteDoctorInjection").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdEnbryologisteDoctorInjection1").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdEnbryologisteDoctorBiopsieTesticulaire").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdEnbryologisteDoctorBiopsieTesticulaire1").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdEnbryologisteDoctorInseminationIAC").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdEnbryologisteDoctorInseminationIAC1").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdEnbryologistePreparationSperme").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')            
            $("#IdEnbryologistePreparationSperme1").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdEnbryologisteDoctorActDataTransfertsEnbryonnaire").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdEnbryologisteDoctorActDataTransfertsEnbryonnaire1").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdEnbryologisteDoctorEnbryonnaireCongelationData").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdEnbryologisteDoctorEnbryonnaireCongelationData1").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdEnbryologisteDoctorActDataCongelationSperme").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdEnbryologisteDoctorActDataCongelationSperme1").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdEnbryologisteDoctorCongelationOvocyteData").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdEnbryologisteDoctorCongelationOvocyteData1").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdEnbryologisteDoctorActDataBiopsie").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdEnbryologisteDoctorActDataBiopsie1").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdJ1EmbryologisteDoctor").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdJ2EmbryologisteDoctor").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdJ3EmbryologisteDoctor").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdJ4EmbryologisteDoctor").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdJ5EmbryologisteDoctor").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdJ6EmbryologisteDoctor").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')


            $("#IdJ1EmbryologisteDoctor11").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdJ2EmbryologisteDoctor11").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdJ3EmbryologisteDoctor11").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdJ4EmbryologisteDoctor11").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdJ5EmbryologisteDoctor11").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdJ6EmbryologisteDoctor11").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')
            $("#IdEnbryologisteDoctorssEnbryonnaireCongelationData").append('<option value="' + re[i].Id + '"> ' + re[i].UserName + '</option>')

            
            
        }


    })
   
    $.get("/Incubateur_Chambre/GETS", function (re) {
      
        for (i = 0; i < re.length; i++) {
            $("#IdIncubateur").append('<option value="' + re[i].Id +  '"> ' + re[i].NomIncubateur + '</option>')
            $("#IdIncubateur1").append('<option value="' + re[i].Id +  '"> ' + re[i].NomIncubateur + '</option>')
            $("#IdJ1Incubateur").append('<option value="' + re[i].Id +  '"> ' + re[i].NomIncubateur + '</option>')
            $("#IdJ2Incubateur").append('<option value="' + re[i].Id +  '"> ' + re[i].NomIncubateur + '</option>')
            $("#IdJ3Incubateur").append('<option value="' + re[i].Id +  '"> ' + re[i].NomIncubateur + '</option>')
            $("#IdJ4Incubateur").append('<option value="' + re[i].Id +  '"> ' + re[i].NomIncubateur + '</option>')
            $("#IdJ5Incubateur").append('<option value="' + re[i].Id +  '"> ' + re[i].NomIncubateur + '</option>')
            $("#IdJ6Incubateur").append('<option value="' + re[i].Id +  '"> ' + re[i].NomIncubateur + '</option>')


            $("#IdJ1Incubateur11").append('<option value="' + re[i].Id + '"> ' + re[i].NomIncubateur + '</option>')
            $("#IdJ2Incubateur11").append('<option value="' + re[i].Id + '"> ' + re[i].NomIncubateur + '</option>')
            $("#IdJ3Incubateur11").append('<option value="' + re[i].Id + '"> ' + re[i].NomIncubateur + '</option>')
            $("#IdJ4Incubateur11").append('<option value="' + re[i].Id + '"> ' + re[i].NomIncubateur + '</option>')
            $("#IdJ5Incubateur11").append('<option value="' + re[i].Id + '"> ' + re[i].NomIncubateur + '</option>')
            $("#IdJ6Incubateur11").append('<option value="' + re[i].Id + '"> ' + re[i].NomIncubateur + '</option>')


        }

        $.get("/Incubateur_Chambre/GetsChambreByIdncubateur", { Id: re[0].Id }, function (re1) {
         
          
            for (i = 0; i < re1.length; i++) {
                $("#Chambree").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#Chambree1").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#J1Chambres").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#J2Chambres").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#J3Chambres").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#J4Chambres").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#J5Chambres").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#J6Chambres").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')


                $("#J1Chambres11").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#J2Chambres11").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#J3Chambres11").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#J4Chambres11").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#J5Chambres11").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#J6Chambres11").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')


            }
        })
    })


    $('#IdIncubateur').change(function () {
        $("#Chambree").empty();

        $.get("/Incubateur_Chambre/GetsChambreByIdncubateur", { Id: parseInt($("#IdIncubateur").val()) }, function (re1) {


            for (i = 0; i < re1.length; i++) {

                $("#Chambree").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#Chambree1").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
            }
        })


    })

    $('#IdJ1Incubateur').change(function () {
        $("#J1Chambres").empty();

        $.get("/Incubateur_Chambre/GetsChambreByIdncubateur", { Id: parseInt($("#IdJ1Incubateur").val()) }, function (re1) {


            for (i = 0; i < re1.length; i++) {

                $("#J1Chambres").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#J1Chambres").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
            }
        })


    })

    $('#IdJ2Incubateur').change(function () {
        $("#J2Chambres").empty();

        $.get("/Incubateur_Chambre/GetsChambreByIdncubateur", { Id: parseInt($("#IdJ2Incubateur").val()) }, function (re1) {


            for (i = 0; i < re1.length; i++) {

                $("#J2Chambres").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#J2Chambres").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
            }
        })


    })
    $('#IdJ3Incubateur').change(function () {
        $("#J3Chambres").empty();

        $.get("/Incubateur_Chambre/GetsChambreByIdncubateur", { Id: parseInt($("#IdJ3Incubateur").val()) }, function (re1) {


            for (i = 0; i < re1.length; i++) {

                $("#J3Chambres").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#J3Chambres").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
            }
        })


    })
    $('#IdJ4Incubateur').change(function () {
        $("#J4Chambres").empty();

        $.get("/Incubateur_Chambre/GetsChambreByIdncubateur", { Id: parseInt($("#IdJ4Incubateur").val()) }, function (re1) {


            for (i = 0; i < re1.length; i++) {

                $("#Chambree").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#J4Chambres").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
            }
        })


    })
    $('#IdJ5Incubateur').change(function () {
        $("#J5Chambres").empty();

        $.get("/Incubateur_Chambre/GetsChambreByIdncubateur", { Id: parseInt($("#IdJ5Incubateur").val()) }, function (re1) {


            for (i = 0; i < re1.length; i++) {

                $("#J5Chambres").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#J5Chambres").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
            }
        })


    })
    $('#IdJ6Incubateur').change(function () {
        $("#J6Chambres").empty();

        $.get("/Incubateur_Chambre/GetsChambreByIdncubateur", { Id: parseInt($("#IdJ6Incubateur").val()) }, function (re1) {


            for (i = 0; i < re1.length; i++) {

                $("#J6Chambres").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
                $("#J6Chambres").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
            }
        })


    })




  
    $('#IdIncubateur1').change(function () {
        $("#Chambree1").empty();

        $.get("/Incubateur_Chambre/GetsChambreByIdncubateur", { Id: parseInt($("#IdIncubateur1").val()) }, function (re1) {
            console.log(re1)

            for (i = 0; i < re1.length; i++) {

                $("#Chambree1").append('<option value="' + re1[i].NomChambre + '"> ' + re1[i].NomChambre + '</option>')
            }
        })


    })


  

})

function showeditePontionM() {
    $("#modifierPontionM").modal("show")

}


function showaddPontionM() {
    $("#ajoutePontionM").modal("show")
}

function ajoutePontionfo() {
    $.post("/ActDataPonction/Add", {
        actData: {
            Id: 0, IdMedicalRecordAct: sessionStorage.getItem("IdmedicalrecordActe"),
            IdTretingDoctor: parseInt($("#IdTretingDoctor").val()), IdEnbryologisteDoctor: parseInt($("#IdEnbryologisteDoctor").val()),
            IdIncubateur: parseInt($("#IdIncubateur").val()), EmbryologisteDoctorType: "Embryogiste",
            Chambre: $("#Chambree").val(), Date: $("#Dateponctiion").val(), Heure: $("#Heure").val(), Commentaires: $("#Commentaires").val(),
            NombreFollicules: parseInt($("#NombreFollicules").val()), NombreType: parseInt($("#NombreType").val()),
            NombreOvocytesCollectes: parseInt($("#NombreOvocytesCollecte").val()), OvocytesDegeneres: parseInt($("#OvocytesDegeneres").val()),
           

        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#ajoutePontionM").modal('hide');
            $("#formPonctionAdd").trigger("reset");
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


function modifierPontionfo() {

    $.post("/ActDataPonction/Update", {
        actData: {
            Id: 0, IdMedicalRecordAct: sessionStorage.getItem("IdmedicalrecordActe"),
            IdTretingDoctor: parseInt($("#IdTretingDoctor1").val()), IdEnbryologisteDoctor: parseInt($("#IdEnbryologisteDoctor1").val()),
            IdIncubateur: parseInt($("#IdIncubateur1").val()), EmbryologisteDoctorType: "Embryogiste",
            Chambre: $("#Chambree1").val(), Date: $("#Dateponctiion1").val(), Heure: $("#Heure1").val(), Commentaires: $("#Commentaires1").val(),
            NombreFollicules: parseInt($("#NombreFollicules1").val()), NombreType: parseInt($("#NombreType1").val()),
            NombreOvocytesCollectes: parseInt($("#NombreOvocytesCollecte1").val()), OvocytesDegeneres: parseInt($("#OvocytesDegeneres1").val()),


        }
    }, function (result) {
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#modifierPontionM").modal('hide');
            $("#formPonctionedite").trigger("reset");
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