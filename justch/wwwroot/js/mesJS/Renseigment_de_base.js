$().ready(function () {
    $.get("/RenseignementClinque/GetbyIddossiermedicale", { id: sessionStorage.getItem('IdDossierMedical') }, function (re) {
      
        if (re) {
            sessionStorage.setItem("IdRenseingnementClinique", re.Id)
            
            $("#boutonrenseigment").empty();

            $("#boutonrenseigment").append('<a href="#ModifierRenseigmentdebase" onclick="showmodifierRdDM()" class="btn btn-primary"><i class="fa fa-edite"></i> modifier   Renseigment de Base  </a>')

            $("#infertilite").append('<label  class="gen-label">Type Infertilite</label >  <div class="form-check-inline">  <label class="form-check-label"> <input type="radio" id="Type_d_Infertilite" checked value="Primaire" name="Type_d_Infertilite" required class="form-check-input">' + re.TypeDinfertilite + ' </label> </div>')
            $("#ans1").append('<label class="float-left">    Durer   <br />  <br />   <label  class="float-left"> ' + re.DurerDinfertilite + ' </label>    </label>')
            $("#gross").append('<label>Nombre des Grossesses   <br />  <br />   <label>' + re.NombreGrossesses+'  </label>  </label>')
            $("#datg").append('<label>Date de Grossesses   <br />  <br />   <label>' + re.DateGrossesses + '  </label>  </label>')
            $("#NBR").append('<label>Nombre des ENFANTS    <br />  <br />   <label>' + re.NombreEnfants  + '  </label>  </label>')
            $("#dataE").append('<label>Date de ENFANT    <br />  <br />   <label>' + re.DateEnfants + '  </label>  </label>')
            $("#NbreGeu").append('<label>Nombre des GEU  <br />  <br />   <label>' + re.NombreGeu + '  </label>  </label>')
            $("#DateGEU").append('<label>Date de GEU  <br />  <br />   <label>' + re.DateGeu + '  </label>  </label>')
            $("#nbrea").append('<label> Nombre d Avortement <br />  <br />   <label>' + re.NombreAvortement + '  </label>  </label>')
            $("#dateav").append('<label> Date de Avortement <br />  <br />   <label>' + re.DateAvortement + '  </label>  </label>')
            $("#poidMr").append('<label> Poid Monsieur<br />  <br />   <label>' + re.PoidMonsieur + '  </label>  </label>')
            $("#tailMr").append('<label> Taille Monsieur<br />  <br />   <label>' + re.TailleMonsieur + '  </label>  </label>')
            $("#BMIMMonsieurf").append('<label> BMIM Monsieur<br />  <br />   <label>' + re.BMIMMonsieur + '  </label>  </label>')
            $("#poidmD").append('<label> Poid Madame<br />  <br />   <label>' + re.PoidMadame + '  </label>  </label>')
            $("#tailda").append('<label> Taille Madame<br />  <br />   <label>' + re.TailleMadame + '  </label>  </label>')
            $("#BMIMMadamee").append('<label> BMIM Madame<br />  <br />   <label>' + re.BMIMMMadame + '  </label>  </label>')
            $("#Techniquess").append('<label> Techniques<br />  <br />   <label>' + re.Techniques + '  </label>  </label>')
            $("#Indicationss").append('<label>Indications <br />  <br />   <label>' + re.Indications + '  </label>  </label>')
            $("#Observations").append('<label>  Observations <br />  <br />   <label>' + re.Observation + '  </label>  </label>')
            $("#Remarquess").append('<label> Remarques <br />  <br />   <label>' + re.Remarques + '  </label>  </label>')

            if (re.TypeDinfertilite == "Primaire") {
                $("#infertilite1").append('<label  for="Type_d_Infertilite1"  class="gen-label">Type Infertilite</label >  <div class="form-check-inline">  <label class="form-check-label"> <input type="radio" id="Type_d_Infertilite1" checked value="Primaire" name="Type_d_Infertilite1" required class="form-check-input">' + re.TypeDinfertilite + ' </label> </div>  <div class="form-check-inline"> <label class="form-check-label">  <input type="radio" name="Type_d_Infertilite1" id="Type_d_Infertilite1" value="Secondaire" required class="form-check-input">Secondaire    </label>     </div>')
            }
            else {
                $("#infertilite1").append('<label  for="Type_d_Infertilite1"  class="gen-label">Type Infertilite</label >  <div class="form-check-inline">  <label class="form-check-label"> <input type="radio" id="Type_d_Infertilite1" checked value="Secondaire" name="Type_d_Infertilite1" required class="form-check-input">' + re.TypeDinfertilite + ' </label> </div>  <div class="form-check-inline"> <label class="form-check-label">  <input type="radio" name="Type_d_Infertilite1" id="Type_d_Infertilite1" value="Primaire" required class="form-check-input">Primaire    </label>     </div>')

            }
            $("#ans11").append(' <label for="ans111" class="float-left"> Durer  <span class="text-danger">*</span></label> <input class="form-control" id="ans111" value="' + re.DurerDinfertilite + '" name="ans111" type="number" min="0" required>')
            $("#gross1").append('  <label>Nombre des Grossesses<span class="text-danger">*</span></label> <input class="form-control"  value="' + re.NombreGrossesses + '" id="Grossessesno1" type="text">')
            $("#datg1").append(' <label>Date de Grossesses </label>    <div class="cal-icon"> <input type="text" id="Grossesses_date1" value="' + re.DateGrossesses + '" class="form-control datetimepicker">      </div>')
            $("#NBR1").append('  <label>Nombre d ENFANTS<span class="text-danger">*</span></label>   <input class="form-control" value="' + re.NombreEnfants + '" id="ENFANTS1" type="text"> ')
            $("#dataE1").append(' <label>Date de ENFANTS </label>    <div class="cal-icon"> <input type="text" id="ENFANTS_date1" value="' + re.DateEnfants + '" class="form-control datetimepicker">      </div>')
            $("#NbreGeu1").append('  <label>Nombre de GEU<span class="text-danger">*</span></label>   <input class="form-control" value="' + re.NombreGeu + '" id="GEU1" type="text"> ')
            $("#DateGEU1").append(' <label>Date de GEU </label>    <div class="cal-icon"> <input type="text" id="GEU_date1" value="' + re.DateGeu + '" class="form-control datetimepicker">      </div>')
            $("#nbrea1").append('  <label>Nombre d Avortement<span class="text-danger">*</span></label>   <input class="form-control" value="' + re.NombreAvortement + '" id="Avortement1" type="text"> ')
            $("#dateav1").append(' <label>Date d Avortement </label>    <div class="cal-icon"> <input type="text" id="Avortement_date1" value="' + re.DateAvortement + '" class="form-control datetimepicker">      </div>')
            $("#poidMr1").append(' <label>Poid Monsieur </label>  <input class="form-control"value="' + re.PoidMonsieur +'" id="POIDMonsieur1" type="text">')
            $("#tailMr1").append(' <label>Taille Monsieur </label>  <input class="form-control"value="' + re.TailleMonsieur + '" id="TailleMonsieur1" type="text">')
            $("#BMIMMonsieurf1").append(' <label>BMIM Monsieur </label>  <input class="form-control"value="' + re.BMIMMonsieur + '" id="BMIMMonsieur1" type="text">')


            $("#poidmD1").append(' <label>Poid Madame </label>  <input class="form-control"value="' + re.PoidMadame + '" id="POIDMadame1" type="text">')
            $("#tailda1").append(' <label>Taille Madame </label>  <input class="form-control"value="' + re.TailleMadame + '" id="TailleMadame1" type="text">')
            $("#BMIMMadamee1").append(' <label>BMIM Madame </label>  <input class="form-control"value="' + re.BMIMMMadame + '" id="BMIMMadame1" type="text">')



            $("#Techniquess1").append(' <label>TECHNIQUES </label>  <input class="form-control"value="' + re.Techniques + '" id="Techniques1" type="text">')
            $("#Indicationss1").append(' <label>Indications </label>  <input class="form-control"value="' + re.Indications + '" id="Indications1" type="text">')
            $("#Observations1").append(' <label>Observations </label>  <textarea id="Observation1" class="form-control">' + re.Observation + '</textarea>')
            
            $("#Remarquess1").append(' <label>Observations </label>  <textarea id="Remarques1" class="form-control">' + re.Remarques + '</textarea>')

        }
    })


    $("#formAddrenseignementClinque").on('submit', function (e) {
        AddrenseignementClinque()
        e.preventDefault()
    })

    $("#ModifierRenseigmentdebase").on('submit', function (e) {
        UpdaterenseignementClinque()
        e.preventDefault()
    })
})


function showmodifierRdDM() {
    $("#ModifierRenseigmentdebase").modal("show")
}


function showRdBM() {
    $("#ajouterRenseigmentdebase").modal("show")
}


function AddrenseignementClinque() {

    $.post("/RenseignementClinque/Add", {
        renseignementClinque: {
            id: 0, IdMedicalRecord: sessionStorage.getItem('IdDossierMedical'), TypeDinfertilite: $('input[name=Type_d_Infertilite]:checked').val()
            , DurerDinfertilite: $("#ans").val(), Remarques: $("#Remarque").val(), NombreGrossesses: $("#Grossessesno").val(),
            DateGrossesses: $("#Grossesses_date").val(), NombreEnfants: $("#ENFANTS").val(), DateEnfants: $("#ENFANTS_date").val(),
            NombreGeu: $("#GEU").val(), DateGeu: $("#GEU_date").val(), NombreAvortement: $("#Avortement").val(),
            DateAvortement: $("#Avortement_date").val(), PoidMonsieur: $("#POIDMonsieur").val(), TailleMonsieur: $("#TailleMonsieur").val(),
            BMIMMonsieur: $("#BMIMMonsieur").val(), PoidMadame: $("#POIDMadame").val(), TailleMadame: $("#TailleMadame").val(),
            BMIMMMadame: $("#BMIMMadame").val(), Techniques: $("#Techniques").val(), Indications: $("#Indications").val(),
            Observation: $("#Observation").val()


        }

    }, function (result) {

        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })

            $("#ajouterRenseigmentdebase").modal('hide');
            location.href = '/DossierMedical/ Consulter?Reference = '+localStorage.getItem(IdDossierMedical)+' #ModifierRenseigmentdebase'
            

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




function UpdaterenseignementClinque() {
    $.post("/RenseignementClinque/Update", {
        renseignementClinque: {
            id: 0, IdMedicalRecord: sessionStorage.getItem('IdDossierMedical'), TypeDinfertilite: $('input[name=Type_d_Infertilite1]:checked').val()
            , DurerDinfertilite: $("#ans111").val(), Remarques: $("#Remarques1").val(), NombreGrossesses: $("#Grossessesno1").val(),
            DateGrossesses: $("#Grossesses_date1").val(), NombreEnfants: $("#ENFANTS1").val(), DateEnfants: $("#ENFANTS_date1").val(),
            NombreGeu: $("#GEU1").val(), DateGeu: $("#GEU_date1").val(), NombreAvortement: $("#Avortement1").val(),
            DateAvortement: $("#Avortement_date1").val(), PoidMonsieur: $("#POIDMonsieur1").val(), TailleMonsieur: $("#TailleMonsieur1").val(),
            BMIMMonsieur: $("#BMIMMonsieur1").val(), PoidMadame: $("#POIDMadame1").val(), TailleMadame: $("#TailleMadame1").val(),
            BMIMMMadame: $("#BMIMMadame1").val(), Techniques: $("#Techniques1").val(), Indications: $("#Indications1").val(),
            Observation: $("#Observation1").val()


        }

    }, function (result) {

        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })
            $("#ModifierRenseigmentdebase").modal('hide');
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