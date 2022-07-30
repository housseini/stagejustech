// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.



// Write your JavaScript code.
$().ready(function () {

    $('#infor').hide()
    $("#listemenu").empty()
    var menu = '<li class="menu-title">Main</li>' +
        '  <li >' +
        '   <a  href = "/DossierMedical/Index" ><i class="fa fa-folder"></i> <span>Dossiers</span></a > ' +
        '  </li>' +
        '     <li>' +
        '      <li   class="active" >' +
        '        <a  href="/Patient/Index"><i class="fa fa-user"></i> <span>Patients</span></a>' +
        '     </li>' +
        '     <li>' +
        '         <a href="/Appointment/Index"><i class="fa fa-calendar-check-o"></i> <span>Rendez-vous</span></a>' +
        '      </li>' +
        '     <li>' +
        '          <a href="/Doctor/Index"><i class="fa fa-user"></i> <span>Medecins</span></a>' +
        '      </li>' +
        '    <li>' +
        '       <a href="#"  data-toggle="dropdown" aria-expanded="false"> <i class="fa fa-cog"> <span> Parametre </span></i></a>' +
        '      <div class="dropdown-menu ">' +
        '             <a class="dropdown-item" href="/Room/Index"> Salles</a>' +
        '             <a class="dropdown-item" href="/TechnienEnbrylogiste/Index">Techniciens</a>' +
        '<a class="dropdown-item" href="/DocumentType/Index">Docment Type </a>'+
        '           <a class="dropdown-item" href="/MedicalAct/Index">ACTES MEDICALS</a> ' +
        '           <a class="dropdown-item" href="/TraitementCycle/Index">TraitementCycle</a> ' +
        '           <a class="dropdown-item" href="/Incubateur_Chambre/Index">Incubateur/Chambre</a> ' +
        '            <a class="dropdown-item" href="/Cuve/Index">Cuve</a> ' +

        '           <a class="dropdown-item" href="/Utilisateur/Index">Utilisateur</a> ' +
        '           <a class="dropdown-item" href="/Automatisation/Index">Classification</a> ' +
        '       </div> ' +
        '   </li>    ';

    $("#listemenu").append(menu)



    $('#LastName').on("keyup", function () {
        $('#f').hide();
    })

    
    $('#FirstName').on("keyup", function () {
        $('#e').hide();
    })
    $('#Dataofbirth').change(function () {
        $('#gdf').hide();
    })
    $('#Placeofbirth').on("keyup", function () {
        $('#h').hide();
    })
    $('#Cin').on("keyup", function () {
        $('#d').hide();
    })
    $('#Email').on("keyup", function () {
        $('#k').hide();
    })

    $('#Phone').on("keyup", function () {
        var regex = /[a-zA-Z-áàâäãåçéèêëíìîïñóòôöõúùûüýÿæœÁÀÂÄÃÅÇÉÈÊËÍÌÎÏÑÓÒÔÖÕÚÙÛÜÝŸÆŒ._\s\.\,\--]/;


        if ($("#Phone").val().match(regex)) {
            $('#i').show();
        }
        else {
            $('#i').hide();
        }

    })


    $('#d').hide();
    $('#e').hide();
    $('#f').hide();
    $('#gdf').hide();
    $('#h').hide();
    $('#i').hide();
    $('#j').hide();
    $('#k').hide();
    $('#l').hide();
    $('#m').hide();
    
    $('#trr').hide();


    $("#Photo1").change(function () {

        var files = $('#Photo1').get(0);
        var formData = new FormData();
       
        formData.append('file', files.files[0]);
        sessionStorage.setItem('Photo1', files.files[0].name)

        $.ajax({
            type: 'POST',
            url: "/Patient/FILEUPLOAD",
            data: formData,
            cache: false,
            contentType: false,
            processData: false,
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            success: function (repo) {
                if (repo.status) {

                }
            },
            error: function () {
                Swal.fire({

                    icon: 'warning',
                    title: 'cette image existe dans le systeme',
                    showConfirmButton: false,
                    timer: 15000
                })
            }
        });
    });
    
})
function addidtolocalstorage(id) {
  
    sessionStorage.setItem("idPatient", id);

}

function modalrecherche() {
    $("#rechecher").modal('show');
}

function edit(Id) {
 
    sessionStorage.setItem("idPatient", Id);

}


function edd_Patient(Id) {
    
    class Patient {
        Id;
        Cin;
        IssuedOn;
        FirstName;
        LastName;
        MaidenName;
        Gender;
        Profession;
        Photo;
        Phone;
        Email;
        Dataofbirth;
        Placeofbirth;
        Address;
        PostalCode;
        City;
        Country;
        InsuranceAgency;
        InsuranceID;
        Nationality;
        Civility;
        State;
        Addedon;
        constructor() {
           
            this.Id = Id;
            this.Cin = $("#Cin").val();
            this.IssuedOn = $("#IssuedOn").val();
            this.FirstName = $("#FirstName").val();
            this.LastName = $("#LastName").val();
            this.MaidenName = $("#MaidenName").val();
            this.Gender = $('input[name=gender]:checked').val();
            this.Profession = $("#Profession").val();
            if ($("#Photo1").val() == '') {
                this.Photo = $("#Photo").val();
            } else {
                this.Photo = sessionStorage.getItem('Photo1')

            }
         

            this.Phone = $("#Phone").val();
            this.Email = $("#Email").val();
            this.Dataofbirth = $("#Dataofbirth").val();
            this.Placeofbirth = $("#Placeofbirth").val();
            this.Address = $("#Address").val();
            this.PostalCode = $("#PostalCode").val();
            this.City = $("#City").val();
            this.Country = $("#Country").val();
            this.InsuranceAgency = $("#InsuranceAgency").val();
            this.InsuranceID = $("#InsuranceID").val();
            this.Nationality = $("#Nationality").val();
            this.Civility = $('input[name=Civility]:checked').val();
            this.State = $("#State").val();


        }
    };


    $.post("/Patient/Edd", { patient: new Patient() }, function (result) {


    
       
        Swal.fire({

            icon: 'success',
            title: 'patient MODIFIER',
            showConfirmButton: true,
            
       
        })
        window.location.href = "/Patient/Index"
       
       
        

          
      
      
    }

    );
   
}




function deletePatient() {
    var Id = sessionStorage.getItem("idPatient");
    $("#delete_patient").modal('hide');
    $.get("/Patient/Delete", { Id: Id }, function (result) {
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
                timer: 1500
            })
            setTimeout(function () {
                window.location.reload()
            }, 3000)
        }
    }

    );

  

}


function AddPatient() {
    
    class Patient {
             Id ;
             Cin ;
            IssuedOn ;
            FirstName ;
            LastName  ;  
            MaidenName     ;
            Gender ;
            Profession  ;
            Photo ;
             Phone ;
            Email ;
           Dataofbirth ;
            Placeofbirth ;
            Address ;
            PostalCode ;
            City ;
            Country ;
            InsuranceAgency ;
            InsuranceID ;
            Nationality ;
            Civility ;
            State ;
            Addedon;
        constructor() {
            
            this.Id = localStorage.getItem("idPatient");
           
            this.Cin = $("#Cin").val();
            this.IssuedOn = null;
            this.FirstName = $("#FirstName").val();
            this.LastName = $("#LastName").val();
            this.MaidenName = null;
            this.Gender = $('input[name=gender]:checked').val();
            this.Profession = $("#Profession").val();
            if (($('#Photo').val() != 0)) {
                var files = $('#Photo').get(0);
                this.Photo = files.files[0].name;

            }
            else {
                this.Photo = null;
            };
           
         
            this.Phone = $("#Phone").val();
            this.Email = $("#Email").val();
            this.Dataofbirth = $("#Dataofbirth").val();
            this.Placeofbirth = $("#Placeofbirth").val();
            this.Address = $("#Address").val();
            this.PostalCode = $("#PostalCode").val();
            this.City = $("#City").val();
            this.Country = $("#Country").val();
            this.InsuranceAgency = null;
            this.InsuranceID = null;
            this.Nationality = $("#Nationality").val();
            this.Civility = $('input[name=Civility]:checked').val();
            this.State = 'Temporaire';


        }



    };
    
    if ($("#Cin").val() == "" || $("#FirstName").val() == "" || $("#LastName").val() == "" || $("#Phone").val() == "" || $("#Dataofbirth").val() == "" || $("#Placeofbirth").val() == "") {
        if ($("#Cin").val() == "") {
            $('#d').show();
        }
        if ($("#FirstName").val() == "") { $('#e').show(); }
        if ($("#LastName").val() == "") { $('#f').show(); }
        if ($("#Dataofbirth").val() == "") { $('#gdf').show(); }

        if ($("#Placeofbirth").val() == "") { $('#h').show(); }
        if ($("#Phone").val() == "") { $('#i').show(); }
        if ($("#Nationality").val() == "") { $('#j').show(); }
        if ($("#Email").val() == "") { $('#k').show(); }
        if ($("#Gender").val() == "") { $('#l').show(); }
        if ($("#Civility").val() == "") { $('#m').show(); }
      
       
    } else {

       

        if ($('#Photo').val()!=0) {
            var files = $('#Photo').get(0);
            var formData = new FormData();

            formData.append('file', files.files[0]);




            $.ajax({
                type: 'POST',
                url: "/Patient/FILEUPLOAD",
                data: formData,
                cache: false,
                contentType: false,
                processData: false,
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("XSRF-TOKEN",
                        $('input:hidden[name="__RequestVerificationToken"]').val());
                },
                success: function (repo) {
                    if (repo.status ) {
                       
                    }
                },
                error: function () {
                    alert("Error occurs");
                }
            });

            var regex = /[a-zA-Z-áàâäãåçéèêëíìîïñóòôöõúùûüýÿæœÁÀÂÄÃÅÇÉÈÊËÍÌÎÏÑÓÒÔÖÕÚÙÛÜÝŸÆŒ._\s\.\,\--]/;

            if (!$("#Phone").val().match(regex)) {
                $('#i').hide()
                $.post("/Patient/AddPatient", { patient: new Patient() }, function (result) {

                    if (result.status) {
                        Swal.fire({

                            icon: 'success',
                            title: result.message,
                            showConfirmButton: false,
                            timer: 1500
                        })
                        setTimeout(function () {
                            window.location.href = "/Patient/Index"
                        }, 2000);
                    }
                    else {

                        Swal.fire({

                            icon: 'warning',
                            title: result.message,
                            showConfirmButton: false,
                            timer: 30000
                        })

                    };
                }

                );
            } else {
                $('#i').show();
            }

        } else {



            var regex = /[a-zA-Z-áàâäãåçéèêëíìîïñóòôöõúùûüýÿæœÁÀÂÄÃÅÇÉÈÊËÍÌÎÏÑÓÒÔÖÕÚÙÛÜÝŸÆŒ._\s\.\,\--]/;

            if (!$("#Phone").val().match(regex)) {
                $('#i').hide()

            $.post("/Patient/AddPatient", { patient: new Patient() }, function (result) {

                if (result.status) {

                    Swal.fire({

                        icon: 'success',
                        title: result.message,
                        showConfirmButton: false,
                        timer: 1500
                    })
                    setTimeout(function () {
                        window.location.href = "/Patient/Index"
                    }, 2000);
                }
                else {

                


                    Swal.fire({

                        icon: 'warning',
                        title: result.message,
                        showConfirmButton: false,
                        timer: 30000
                    })

                };
            });
            } else {
                $('#i').show();
            }

        }


      
    }

    };
