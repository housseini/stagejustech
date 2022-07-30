$().ready(function () {
    $("#acte13").show()
    $("#acte12").show()
    $("#acte11").show()
    $("#acte10").show()
    $("#acte9").show()
    $("#acte8").show()
    $("#acte7").show()
    $("#acte13").show()
    $("#acte11").show()
    $("#acte10").show()
    $("#acte9").show()
    $("#acte8").show()
    $("#acte7").show()
    $("#acte3").show()
    $("#acte2").show()
    $("#acte4").show()
    $("#acte5").show()
    $("#acte0").show()
    $("#acte6").show()


    $.get('/MedicalAct/GetmedicalActRecordByid', { id: sessionStorage.getItem("IdmedicalrecordActe") }, function (re) {

        if (re.MedicalActName == "ICSI") {
            $('#myTab2 a[href="#about-cont"]').tab('show');
            $("#acte13").hide()
            $("#acte12").hide()
            $("#acte11").hide()
            $("#acte10").hide()
            $("#acte9").hide()
            $("#acte8").hide()
            $("#acte7").hide()
          
        }
        if (re.MedicalActName == "FIV") {
            $('#myTab2 a[href="#about-cont"]').tab('show');
            $("#acte13").hide()
            $("#acte12").hide()
            $("#acte11").hide()
            $("#acte10").hide()
            $("#acte9").hide()
            $("#acte8").hide()
            $("#acte7").hide()

        }

        if (re.MedicalActName == "IAC") {
            $('#myTab2 a[href="#bottom-tab1"]').tab('show');

            $("#acte13").hide()
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

        }
        if (re.MedicalActName == "Congélation Sperme") {
            $('#myTab2 a[href="#bottom-tab1"]').tab('show');

            $("#acte13").hide()
            $("#acte11").hide()
            $("#acte10").hide()
            $("#acte9").hide()
            $("#acte8").hide()
            $("#acte12").hide()
            $("#acte3").hide()
            $("#acte2").hide()
            $("#acte4").hide()
            $("#acte5").hide()
            $("#acte0").hide()
            $("#acte6").hide()

        }
        if (re.MedicalActName == "Congélation Ovocytair") {
            $('#myTab2 a[href="#about-cont"]').tab('show');

            $("#acte13").hide()
            $("#acte11").hide()
            $("#acte10").hide()
            $("#acte9").hide()
            $("#acte7").hide()
            $("#acte12").hide()
            $("#acte3").hide()
            $("#acte4").hide()
            $("#acte5").hide()
            $("#acte1").hide()
            $("#acte6").hide()

        }
        if (re.MedicalActName == "Transfert d'embryon congélés (TEC)") {
            $('#myTab2 a[href="#bottom-tab5"]').tab('show');
                
            $("#acte13").hide()
            $("#acte11").hide()
            $("#acte0").hide()
            $("#acte9").hide()
            $("#acte7").hide()
            $("#acte12").hide()
            $("#acte3").hide()
            $("#acte4").hide()
            $("#acte8").hide()
            $("#acte1").hide()
            $("#acte6").hide()
            $("#acte2").hide()

        }

        if (re.MedicalActName == "Biopsie Testiculaire") {
            $('#myTab2 a[href="#bottom-tab13"]').tab('show');

            $("#acte5").hide()
            $("#acte11").hide()
            $("#acte0").hide()
            $("#acte9").hide()
            $("#acte10").hide()
            $("#acte12").hide()
            $("#acte3").hide()
            $("#acte4").hide()
            $("#acte8").hide()
            $("#acte1").hide()
            $("#acte6").hide()
            $("#acte2").hide()

        }
       

    })

})