$().ready(function () { 

$("#listemenu").empty()
var menu = '<li class="menu-title">Main</li>' +
    '  <li >' +
    '   <a  href = "/DossierMedical/Index" ><i class="fa fa-folder"></i> <span>Dossiers</span></a > ' +
    '  </li>' +
    '     <li>' +
    '      <li   >' +
    '        <a  href="/Patient/Index"><i class="fa fa-user"></i> <span>Patients</span></a>' +
    '     </li>' +
    '     <li >' +
    '         <a href="/Appointment/Index"><i class="fa fa-calendar-check-o"></i> <span>Rendez-vous</span></a>' +
    '      </li>' +
    '     <li   >' +
    '          <a href="/Doctor/Index"><i class="fa fa-user"></i> <span>Medecins</span></a>' +
    '      </li>' +
    '    <li class="active">' +
    '       <a href="#"  data-toggle="dropdown" aria-expanded="false"> <i class="fa fa-cog"> <span> Parametre </span></i></a>' +
    '      <div class="dropdown-menu ">' +
    '             <a class="dropdown-item" href="/Room/Index"> Salles</a>' +
    '             <a class="dropdown-item" href="/TechnienEnbrylogiste/Index">Techniciens</a>' +
    '<a class="dropdown-item" href="/DocumentType/Index">Docment Type </a>' +
    '           <a class="dropdown-item" href="/MedicalAct/Index">ACTES MEDICALS</a> ' +
    '           <a class="dropdown-item" href="/TraitementCycle/Index">TraitementCycle</a> ' +
    '           <a class="dropdown-item" href="/Incubateur_Chambre/Index">Incubateur/Chambre</a> ' +
    '            <a class="dropdown-item" href="/Cuve/Index">Cuve</a> ' +

    '           <a class="dropdown-item" href="/Utilisateur/Index">Utilisateur</a> ' +
    '           <a class="dropdown-item" href="/Automatisation/Index">Classification</a> ' +
    '       </div> ' +
    '   </li>    ';

    $("#listemenu").append(menu)
    creercuveTable()
    $.get("/Cuve/Gets", function (re) {
        creerViotubeTable(re)
    })

    $.get("/Visotube/Gets", function (re) {
        creerPailletteTable(re)
    })

    $("#ajouteCuveF").on('submit', function (e) {
        ajouteCuvefo()
        e.preventDefault()
    })

    $("#ajouteVisotubeF").on('submit', function (e) {
        ajouteVisotubefo()
        e.preventDefault()
    })

    

    
    $("#modifierCuveF").on('submit', function (e) {
        editerCuvefo()
        e.preventDefault()
    })


    $("#ajoutePailletteF").on('submit', function (e) {
        AjouterPaillettefo()
        e.preventDefault()
    })

    




    $("#editerVisotubeF").on('submit', function (e) {
        editeVisotubefo()
        e.preventDefault()
    })

    $("#editePailletteF").on('submit', function (e) {
        editePaillettefo()
        e.preventDefault()
    })



    $('#couleur').change(function (event) {
       
        $('#couleur').css("background-color", event.target.value)
    })
    $('#couleur1').change(function (event) {

        $('#couleur1').css("background-color", event.target.value)
    })

    $('#IdVisotube').change(function (event) {


      

        $.get("/Visotube/GetById", { Id: event.target.value }, function (re) {
           

            $('#IdVisotube').css("background-color", re[0].Couleur )
            
        })
    //    $('#IdVisotube').css("background-color", event.target.value)
    })

    $('#IdVisotube1').change(function (event) {




        $.get("/Visotube/GetById", { Id: event.target.value }, function (re) {


            $('#IdVisotube1').css("background-color", re[0].Couleur)

        })
        //    $('#IdVisotube').css("background-color", event.target.value)
    })


    $('#couleurPaillette').change(function (event) {

        $('#couleurPaillette').css("background-color", event.target.value)
    })
    $('#couleurPaillette1').change(function (event) {

        $('#couleurPaillette1').css("background-color", event.target.value)
    })

    


    $.get('/UTILITY/GetsColor', function (resulta) {
   
        
        for (i = 0; i < resulta.length; i++) {

          
            $('#couleur').append('<option   style="background-color:#' + resulta[i].hex +'"  value="#' + resulta[i].hex + '"> </option>')
            $('#couleur1').append('<option   style="background-color:#' + resulta[i].hex +'"  value="#' + resulta[i].hex + '"> </option>')
            $('#couleurPaillette').append('<option   style="background-color:#' + resulta[i].hex +'"  value="#' + resulta[i].hex + '"> </option>')
            $('#couleurPaillette1').append('<option   style="background-color:#' + resulta[i].hex +'"  value="#' + resulta[i].hex + '"> </option>')
        }
     
    })
})

function showCuve() {
    $("#ajouterCuve").modal('show')
}

function ajouteCuvefo() {
    $.post("/Cuve/Add", {
        actData: {
            Id: 0, Nom: $("#Nom").val(),
             Reference: $("#Reference").val(), NombreCanisters: parseInt($("#Canister").val())
        }

    }, function (result) {
        console.log(result)
        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#ajouterCuve").modal('hide');
            $("#ajouteCuveF").trigger("reset");
            creercuveTable()



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


function ajouteVisotubefo() {
    $.post("/Visotube/Add", {
        actData: {
            Id: 0, IdCube: parseInt($("#IdCuve").val()),
            Couleur: $("#couleur").val(), Capacite: parseInt($("#Capicite").val()),
            NumeroCanister: parseInt($("#Numeroc").val()),
            NumeroEtage: parseInt($("#Numeroe").val())
        }
    }, function(result) {


            if (result.status) {
                Swal.fire({

                    icon: 'success',
                    title: result.message,
                    showConfirmButton: false,
                    timer: 3000
                })

                $("#ajouterVisotube").modal('hide');
                $("#ajouteVisotubeF").trigger("reset");
              
                $.get("/Cuve/Gets", function (re) {
                    creerViotubeTable(re)
                })


            }
            else {

                Swal.fire({

                    icon: 'error',
                    title: result.message,
                    showConfirmButton: false,
                    timer: 1500
                })

            }

        }
    )
}

function creerViotubeTable(cuve) {
  

  


    
    $.get("/Visotube/Gets", function (re) {

        if ($.fn.DataTable.isDataTable("#ViotubeTable")) {
            $('#ViotubeTable').DataTable().destroy();
        }

 


        $("#ViotubeTablebody").empty()

        var model = re.reverse()
        for (var i = 0; i < model.length; i++) {
            $('#IdVisotube').append('<option style="background-color:' + model[i].Couleur + '"  value=" ' + model[i].Id + '" ></option>')
            $('#IdVisotube1').append('<option style="background-color:' + model[i].Couleur + '"  value=" ' + model[i].Id + '" ></option>')
            for (var k = 0; k < cuve.length; k++) {
                if (cuve[k].Id == model[i].IdCube) {

              
            
           
                    $("#ViotubeTablebody").append('<tr>' +
                        '<td>  ' + cuve[k].Nom + '</td>' +
                    '<td style="background-color:' + model[i].Couleur+'">  </td>' +
                    '<td>  ' + model[i].Capacite + '</td>' +
                    '<td> ' + model[i].NumeroCanister+ ' </td>' +
                    '<td>' + model[i].NumeroEtage + ' </td>' +
                    '<td class="text - right">'
                    +
                    ' <a  href="#editerVisotubeM" class="btn btn-outline-primary" onclick="editermodalaVisotube(' + model[i].Id + ')" ><i class="fa fa-pencil "></i>  </a>' +
                    '<a  href="#supprimerVisotube" class="btn btn-outline-danger"  onclick="supprimermodalVisotube(' + model[i].Id + ')" ><i class="fa fa-trash "></i>  </a>' +
                    '</td >' +
                    '</tr>'
                    )
                }
            }
               

         
        
           



        }

        $('#ViotubeTable').DataTable({
            "sort": false,
            "reverse": true,

        })







    })

 


}

function editermodalaVisotube(id) {

    sessionStorage.setItem("Idvisotube", id)
    

    $.get("/Visotube/GetById", { Id: id }, function (re) {
        console.log(re)
        $("#couleur1").append('<option  selected    value="' + re[0].Couleur + '" > </option> ')
        $('#couleur1').css("background-color", re[0].Couleur)
        $('#Numeroe1').val(re[0].NumeroEtage)
        $('#Numeroc1').val(re[0].NumeroCanister)
        $('#Capicite1').val(re[0].Capacite)
        $('#IdCuve1').val(re[0].IdCube)
    })
    $("#editerVisotubeM").modal('show')
    
}


function supprimermodalVisotube(id) {
    sessionStorage.setItem("Idvisotube", id)
    $("#supprimerVisotube").modal('show')

}


function showPaillette() {


    $('#ajouterPaillette').modal('show')
}




function creercuveTable() {


    $.get("/Cuve/Gets", function (re) {

        if ($.fn.DataTable.isDataTable("#cuveTable")) {
            $('#cuveTable').DataTable().destroy();
            }

    
        

        $("#cuveTablebody").empty()

            var model = re.reverse()
        for (var i = 0; i < model.length; i++) {
            console.log(model[i]['Id'] )
            $('#IdCuve').append('<option value="' + model[i]['Id'] + '" >'  + model[i]['Nom'] +'</option>')
            $('#IdCuve1').append('<option value="' + model[i]['Id'] + '" >' + model[i]['Nom'] + '</option>')



                $("#cuveTablebody").append('<tr>' +

                    
                    '<td>  ' + model[i]['Nom'] + '</td>' +
                    '<td> ' + model[i]['Reference'] + ' </td>' +
                    '<td>' + model[i]['NombreCanisters'] + ' </td>' +
                      '<td class="text - right">'
                        +
                        ' <a  href="#modifierCuve" class="btn btn-outline-primary" onclick="editermodalaCUBE(' + model[i]['Id'] + ')" ><i class="fa fa-pencil "></i>  </a>' +
                        '<a  href="#supprimerCUVE" class="btn btn-outline-danger"  onclick="supprimermodalcube(' + model[i]['Id'] + ')" ><i class="fa fa-trash "></i>  </a>' +
                        '</td >' +
                        '</tr>'
                    )
                

           
            }
        $('#cuveTable').DataTable({
                "sort": false,
                "reverse": true,

            })


          





        })


}

function editermodalaCUBE(id) {
    sessionStorage.setItem("Idcuve", id)
    $.get("/Cuve/GetById", { Id: id }, function (re) {
        $("#Nom1").val(re[0]['Nom'])
        $("#Reference1").val(re[0]['Reference'])
        $("#Canister1").val(re[0]['NombreCanisters'])
    })

    $("#modifierCuve").modal('show')

}

function editerCuvefo() {
    $.post("/Cuve/Update", {
        actData: {
            Id: sessionStorage.getItem("Idcuve"), Nom: $("#Nom1").val(),
            Reference: $("#Reference1").val(), NombreCanisters: parseInt($("#Canister1").val())
        }

    }, function (result) {

        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#modifierCuve").modal('hide');
            creercuveTable()



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

function supprimermodalcube(id) {
    sessionStorage.setItem("Idcuve", id)
    $("#supprimerCUVE").modal('show')
}
function confirmesuppressionCuve() {
    $.get("/Cuve/Delete", { Id: sessionStorage.getItem("Idcuve") }, function (result) {

    

        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#supprimerCUVE").modal('hide');
            creercuveTable()



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



function showViotube() {

    $("#ajouterVisotube").modal('show')
}

function editeVisotubefo(){


    $.post("/Visotube/Update", {
        actData: {
            Id:sessionStorage.getItem("Idvisotube"), IdCube: parseInt($("#IdCuve").val()),
            Couleur: $("#couleur1").val(), Capacite: parseInt($("#Capicite1").val()),
            NumeroCanister: parseInt($("#Numeroc1").val()),
            NumeroEtage: parseInt($("#Numeroe1").val())
        }
    }, function (result) {


        if (result.status) {
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#editerVisotubeM").modal('hide');
            $.get("/Cuve/Gets", function (re) {
                creerViotubeTable(re)
            })


        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })

        }

    }
    )
}



function confirmesuppressionVisotube() {
    $.get("/Visotube/Delete", { Id: sessionStorage.getItem("Idvisotube") }, function (result) {



        if (result.status) {



            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#supprimerVisotube").modal('hide');
           
            $.get("/Cuve/Gets", function (re) {
                creerViotubeTable(re)
            })


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



function AjouterPaillettefo() {
    $.post("/Paillette/Add", {
        actData: {
            Id: 0, IdVisotube: parseInt($("#IdVisotube").val()),
            Couleur: $("#couleurPaillette").val(), TypeCongelation: $("#congelationPaillette").val(),
            Reference: ($("#ReferencePaillette").val()),
            Statu: ($("#StatuPaillette").val())
        }
    }, function (result) {


        if (result.status) {
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#ajouterPaillette").modal('hide');
            $("#ajoutePailletteF").trigger("reset");

            $.get("/Visotube/Gets", function (re) {
                creerPailletteTable(re)
            })


        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })

        }

    }
    )

}


function creerPailletteTable(vilosube) {

    $.get("/Paillette/Gets", function (re) {

        if ($.fn.DataTable.isDataTable("#Paillettetablee")) {
            $('#Paillettetablee').DataTable().destroy();
        }
        $("#Paillettetablebody").empty()
        var model = re.reverse()
       
        for (var i = 0; i < model.length; i++) {
            console.log()
            for (var k = 0; k < vilosube.length; k++) {
                if (vilosube[k].Id == model[i].IdVisotube) {
                  
                    $("#Paillettetablebody").append('<tr>' +
                        '<td style="background-color:' + vilosube[k].Couleur + '">  </td>' +
                        '<td style="background-color:' + model[i].Couleur + '">  </td>' +
                        '<td> ' + model[i].TypeCongelation + ' </td>' +
                        '<td>' + model[i].Reference + ' </td>' +
                        '<td>' + model[i].Statu + ' </td>' +
                        '<td class="text - right">'
                        +
                        ' <a  href="#editerterPaillette" class="btn btn-outline-primary" onclick="editermodalaPaillette(' + model[i].Id + ')" ><i class="fa fa-pencil "></i>  </a>' +
                        '<a  href="#supprimerPaillete" class="btn btn-outline-danger"  onclick="supprimermodalPaillette(' + model[i].Id + ')" ><i class="fa fa-trash "></i>  </a>' +
                        '</td >' +
                        '</tr>'
                    )
                }
            }

        }

        $('#Paillettetablee').DataTable({
            "sort": false,
            "reverse": true,

        })







    })


}


function editermodalaPaillette(id) {
    sessionStorage.setItem("IdPaillette", id)

    $.get('/Paillette/GetById', { Id: id }, function (resulta) {
        $('#IdVisotube1').val(resulta[0].IdVisotube)
        $('#IdVisotube1').append('<option selected value="'+resulta[0].IdVisotube+'"></option>')
        $('#couleurPaillette1').val(resulta[0].Couleur)
        $('#congelationPaillette1').val(resulta[0].TypeCongelation)
        $('#ReferencePaillette1').val(resulta[0].Reference)
        $('#StatuPaillette1').val(resulta[0].Statu)
        
        $('#couleurPaillette1').css("background-color", resulta[0].Couleur)

        $.get("/Visotube/GetById", { Id: resulta[0].IdVisotube }, function (re) {


            $('#IdVisotube1').css("background-color", re[0].Couleur)

        })
    })
 


    $("#editerterPaillette").modal('show')


}


function editePaillettefo() {
    $.post("/Paillette/Update", {
        actData: {
            Id: sessionStorage.getItem("IdPaillette"), IdVisotube: parseInt($("#IdVisotube1").val()),
            Couleur: $("#couleurPaillette1").val(), TypeCongelation: $("#congelationPaillette1").val(),
            Reference: ($("#ReferencePaillette1").val()),
            Statu: ($("#StatuPaillette1").val())
        }
    }, function (result) {


        if (result.status) {
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#editerterPaillette").modal('hide');

            $.get("/Visotube/Gets", function (re) {
                creerPailletteTable(re)
            })


        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })

        }

    }
    )

}


function supprimermodalPaillette(id) {
    sessionStorage.setItem("IdPaillette", id)
    $("#supprimerPaillete").modal('show')
}


function confirmesuppressionpaillette() {
    $.post("/Paillette/Delete", {
            Id: sessionStorage.getItem("IdPaillette")
    }, function (result) {


        if (result.status) {
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })

            $("#supprimerPaillete").modal('hide');

            $.get("/Visotube/Gets", function (re) {
                creerPailletteTable(re)
            })


        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })

        }

    }
    )


}