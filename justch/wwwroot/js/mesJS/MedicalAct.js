$().ready(function () {

    $.get("/Room/GetROOMs", function (re) {
        for (var i = 0; i < re.length; i++) {

            $("#IdRoom").append(' <option value="' + re[i].Id + '"> ' + re[i].Name + '</option>')
            $("#IdRoom1").append(' <option value="' + re[i].Id + '"> ' + re[i].Name + '</option>')
        }
    })


    $("#cherchermedicalacte").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#mytabe tr ").filter(function () {
            console.log($(this).toggle($(this).text().toLowerCase().indexOf(value) > -1))
        });
    });


  
    $("#mN").hide();
    $("#mT").hide();
    $("#mc").hide();

    if ($.fn.DataTable.isDataTable("#tableMEDICALACT")) {
        $('#tableMEDICALACT').DataTable().destroy();
    }
    $('#tableMEDICALACT').DataTable({})
    
    

})


function showaddmodal() {
    $('#ajoutermodal').modal('show');
}

function addMedicalAct() {
    class MedicalAct {
        ID
        Name
        MedicalActType
        Duration
        Category
        IdRoom
        constructor() {
            this.ID = 0;
            this.Name = $("#Name").val();
            this.MedicalActType = "Exploration";
            this.Duration = $("#Duration").val();
            this.Category = $("#Category").val();
            this.IdRoom = parseInt($("#IdRoom").val());

          
            
        }

    }
    if ($("#Name").val() != "" && $("#MedicalActType").val() != "" && $("#Duration").val() != "" && $("#Category").val() != "") {
        $.post("/MedicalAct/Add", { medicalAct: new MedicalAct() }, function (result) {
            if (result.status) {
                Swal.fire({

                    icon: 'success',
                    title: result.message,
                    showConfirmButton: false,
                    timer: 1500
                })
                setTimeout(function () {
                    window.location.reload()
                }, 3000)


            }
            else {

                Swal.fire({

                    icon: 'error',
                    title: result.message,
                    showConfirmButton: false,
                    timer: 3000
                })



            };
        });

    } else {

        if ($("#Name").val() == "") { $("#mN").show(); }
        if ($("#MedicalActType").val() == "") { $("#mT").show(); }
        if ($("#Category").val() == "") { $("#mc").show(); }
       
    }

}
function showeditemodal(id) {


    $.get("/MedicalAct/GetByid", { id: id }, function (resulat) {
        
        
       


        var str = '   <div class="modal-header p-2 mb-2 bg-primary text-white"><h3>   EDIT Medical </h3>       <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true" >&times;</span > </button ></div > <div class="form-row">' +
            '<div class="form-group col-md-6">' +
            ' <label for="inputPassword4">  NOM <span>*</span></label> ' +
            '    <input type="text" class="form-control" id="Name1" value="' + resulat.Name + '"> ' +
            '   </div > ' +
            '<div class="form-group col-md-6" > ' +
            '  <label for="inputAddress2">ROOM  </label> ' +
            ' <select class="form-control" id="IdRoom1" > <option selected  value="' + resulat.IdRoom+'">  </option> </select>' +

            '  </div>' +
            '  <div class="form-group col-md-6">' +
            '  <label for="inputAddress2">Duration </label>  ' +
            '  <input type="text" class="form-control" id="Duration1" value="' + resulat.Duration + '"> ' +
            '  </div>' +
            '  <div class="form-group col-md-6">' +
            '  <label for="inputAddress2">Categorie </label>' +
            '  <input type="tel" class="form-control" id="Category1" value="' + resulat.Category + '"> ' +
            '  </div>' +
          
            ' </div> </div >' +
            ' <div class="mx-auto" style="width: 200px;">' +
            '<button type="button" class="btn btn-primary" onclick="Enregistrer(' + resulat.ID + ')"> Enregistrer  </button>' +
            '</div>'
            ;
        $('#modal-container').empty();
        $('#modal-container').append(str);
        $('#editmodal').modal('show');



        $.get("/Room/GetROOMs", function (re) {
            for (var i = 0; i < re.length; i++) {

                $("#IdRoom1").append(' <option value="' + re[i].Id + '"> ' + re[i].Name + '</option>')
            }
        })
    });





}

function showEXPLORERmodal(id) {
   
    
    creertableTableEXPLORER(id)

    $('#EXPLORER').modal('show');
}
function showmodaldelle(ID) {
    sessionStorage.setItem("idMedical", ID);
    $('#supprimermodal').modal('show');

}
function confirmationdelete() {
    $('#supprimermodal').modal('hide');
    $.get("/MedicalAct/Delete", { id: sessionStorage.getItem("idMedical") }, function (result) {
        if (result.status) {
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })
            setTimeout(function () {
                window.location.reload()
            }, 3000)


        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })



        };
    });
        

}


function creertableTableEXPLORER(id) {

    model2 = []
    if ($.fn.DataTable.isDataTable("#TableEXPLORER")) {
        $('#TableEXPLORER').DataTable().destroy();
    }
    $('#TableEXPLORER').DataTable({

        search: true    

    })


    $.get("/MedicalAct/MedicalActRecordsByidmedicalact", { id: id }, function (re) {
        $("#bodytableexpore").empty()
        for (i = 0; i < re.medicalRecordActs.length; i++) {

            var m = { Nom: re.medicalAct['Name'], Type: re.medicalAct['MedicalActType'], Patient: re.medicalRecordActs[i]['Patients'], Rang: re.medicalRecordActs[i]['Rang'], State: re.medicalRecordActs[i]['State'] }

           

            $("#bodytableexpore").append(' <tr> <td>' + re.medicalAct['Name'] + '</td>  <td>  ' + re.medicalAct['MedicalActType'] + '</td>    <td>' + re.medicalRecordActs[i]['Patients'] + '</td> <td> ' + re.medicalRecordActs[i]['Rang'] +'</td>  <td> ' + re.medicalRecordActs[i]['State']+'</td>  </tr >')


            model2.push(m)
        }
       

    }
    )
 

   

}


function Enregistrer(id) {
  
    $('#editmodal').modal('hide');

    class MedicalAct {
        ID
        Name
        MedicalActType
        Duration
        Category
        IdRoom
        constructor() {
            this.ID = id;
            this.Name = $("#Name1").val();
            this.MedicalActType = "Exploration";
            this.Duration = $("#Duration1").val();
            this.Category = $("#Category1").val();
            this.IdRoom = parseInt( $("#IdRoom1").val())
        }
    }


   
    $.post("/MedicalAct/Update", { medicalAct: new MedicalAct() }, function (result) {
        if (result.status) {
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 1500
            })
            setTimeout(function () {
                window.location.reload()
            }, 3000)


        }
        else {

            Swal.fire({

                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 3000
            })



        };
        });

    
}

function showconsultermodal(medicalAct) {
    $.get("/MedicalAct/GetByid", { id: medicalAct }, function (resulat) {





        var str = ' <h3>    Medical  ACT</h3>  <div class="form-row">' +
            '<div class="form-group col-md-6">' +
            '  <h5> NOM </h5> ' +
            '   <h2>  ' + resulat.Name + '</h2>' +
            '   </div > ' +
            '<div class="form-group col-md-6" > ' +
            '    <h5> TYPE </h5> ' +
            '  <h2> ' + resulat.MedicalActType + '  </h2>  ' +
            '  </div>' +
            '  <div class="form-group col-md-6">' +
            '  <h5> Duration </h5>  ' +
            '  <h2> ' + resulat.Duration + '</h2> ' +
            '  </div>' +
            '  <div class="form-group col-md-6">' +
            '    <h5> Category </h5>  ' +
            '    <h2> ' + resulat.Category + '  </h2>  ' +
            '  </div>' +

            ' </div>' +
            ' <div class="mx-auto" style="width: 200px;">' +
            '<button type="button" class="btn btn-primary" onclick="fermer()"> ok  </button>' +
            '</div>'
            ;
        $('#modal-container1').empty();
        $('#modal-container1').append(str);
        $('#consultermodal').modal('show');

    });
}

function fermer() {
    $('#consultermodal').modal('hide');
}