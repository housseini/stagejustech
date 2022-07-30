$().ready(function () {
    $('#myTab2 a[href="#bottom-tab10"]').tab('dispose');
    $("#acte13").hide()
    $("#acte12").hide()
    $("#acte11").hide()
    $("#acte10").hide()
    $("#acte9").hide()
    $("#acte8").hide()
    $("#acte7").hide()
    $("#acte1").hide()
    $("#acte11").hide()
    $("#acte10").hide()
    $("#acte9").hide()
    $("#acte8").hide()
    $("#acte7").hide()
    $("#acte3").hide()
    $("#acte2").hide()
    $("#acte4").hide()
    $("#acte5").hide()
    $("#acte0").hide()
    $("#acte6").hide()
    $("#about-cont").hide()
    $("#bottom-tab1").hide()
    $("#bottom-tab2").hide()
    $("#bottom-tab3").hide()
    $("#bottom-tab4").hide()
    $("#bottom-tab5").hide()
    $("#bottom-tab6").hide()
    $("#bottom-tab7").hide()
    $("#bottom-tab8").hide()
    $("#bottom-tab9").hide()
    $("#bottom-tab10").hide()
    $("#bottom-tab11").hide()
    $("#bottom-tab12").hide()
    $("#bottom-tab13").hide()


    
      

    $.get('/MedicalAct/GetmedicalActRecordByid', { id: sessionStorage.getItem('IdmedicalrecordActe') }, function (re) {
        console.log(re)
     
        if (re.MedicalActName == "Congélation de sperme") {
            $('#myTab2 a[href="#acte7"]').tab('show');
            $("#acte7").show()
            $("#bottom-tab11").show()


            
        }

        if (re.MedicalActName == "Ponction de kystes" || re.MedicalActName == "Ponction ovocytaire" ) {
            $('#myTab2 a[href="#acte0"]').tab('show');
          
            $("#acte0").show()
            $("#about-cont").show()

        }

        if (re.MedicalActName == "Insémination / IAC") {
            $('#myTab2 a[href="#acte12"]').tab('show');
            $("#acte12").show()
            $("#bottom-tab10").show()

        }
        if (re.MedicalActName == "Biopsie") {
            $('#myTab2 a[href="#acte13"]').tab('show');
            $("#acte13").show()
            $("#bottom-tab13").show()

        }

        if (re.MedicalActName == "Transfert d'embryon frais (TEF)") {
            $('#myTab2 a[href="#acte5"]').tab('show');
            $("#acte5").show()
            $("#bottom-tab5").show()

        }

        if (re.MedicalActName == "Spermoculture") {
            $('#myTab2 a[href="#acte4"]').tab('show');
            $("#acte4").show()
            $("#bottom-tab3").show()

        }
        if (re.MedicalActName == "Préparation sperme") {
            $('#myTab2 a[href="#acte1"]').tab('show');
            $("#acte1").show()
            $("#bottom-tab1").show()

        }
        if (re.MedicalActName == "Injection") {
            $('#myTab2 a[href="#acte3"]').tab('show');
            $("#acte3").show()
            $("#bottom-tab4").show()

        }
        if (re.MedicalActName == "Décoronisation") {
            $('#myTab2 a[href="#acte2"]').tab('show');
            $("#acte2").show()
            $("#bottom-tab2").show()

        }

        if (re.MedicalActName == "Congélation d 'Ovocyte") {
            $('#myTab2 a[href="#acte8"]').tab('show');
            $("#acte8").show()
            $("#bottom-tab12").show()

        }

        if (re.MedicalActName == "Congélation de Enbryonnaire") {
            $('#myTab2 a[href="#acte6"]').tab('show');
            $("#acte6").show()
            $("#bottom-tab6").show()

        }
        if (re.MedicalActName == "Transfert (Insémination)") {
            $('#myTab2 a[href="#acte9"]').tab('show');
            $("#acte9").show()
            $("#bottom-tab10").show()

        }
        if (re.MedicalActName == "Decongelation") {
            $('#myTab2 a[href="#acte10"]').tab('show');
            $("#acte10").show()
            $("#bottom-tab8").show()

        }

        if (re.MedicalActName == "Congelation Biopsie Testiculaire") {
            $('#myTab2 a[href="#acte11"]').tab('show');
            $("#acte11").show()
            $("#bottom-tab9").show()

        }



        
    })


})