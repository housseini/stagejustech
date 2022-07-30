
$().ready(function () {

    $('#Id1').change(function () {

        $('#tes2').hide()
    })
    $('#Id2').change(function () {

        $('#tes3').hide()
    })
    $('#Id4').change(function () {

        $('#tes').hide()
    })
    $('#Id3').change(function () {

        $('#tes1').hide()
    })
    $('#FirstName').on("keyup", function () {
        $('#e').hide();
    })
    $('#LastName').on("keyup", function () {
        $('#f').hide();
    })
    if ($('#Dataofbirth').val()!='') {
        $('#g').hide();
    }

    $('#Placeofbirth').click(function () {
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
    $('#g').hide();
    $('#h').hide();
    $('#i').hide();
    $('#j').hide();
    $('#k').hide();
    $('#l').hide();
    $('#m').hide();


    $.get("/DossierMedical/Count", function (r) {


        var s = '<input id="Reference" name="Reference" value="DOC00' + r + '" type="text" class="form-control">';
        $("#Inputs").append(s);
    })

    $('#formulaire1').hide();
    $('#formulaire2').hide();
    $('#formulaire3').hide();
    $('#tes').hide();
    $('#tes1').hide();
    $('#formuli').hide();
    $('#tes2').hide();
    $('#tes3').hide();


    $("#type").change(function () {



        if ($("#type").val() == "Femme") {
            $('#formulaire1').hide();
            $('#formulaire3').hide();
            $('#formulaire2').show();
            $('#formuli').show();



        }
        if ($("#type").val() == "Homme") {
            $('#formulaire2').hide();
            $('#formulaire1').hide();
            $('#formulaire3').show();

            $('#formuli').show();

        }
        if ($("#type").val() == "Couple") {
            $('#formulaire2').hide();
            $('#formulaire1').show();
            $('#formulaire3').hide();
            $('#formuli').show();


        }
        if ($("#type").val() == "select") {
            $('#formulaire2').hide();
            $('#formulaire1').hide();
            $('#formulaire3').hide();
            $('#formuli').hide();


        }


    });

})


function creer() {

    class DossierMedical {
        Id;
        Reference;
        DateCreation;
        DateAdmission;
        Type;
        State
        constructor() {
            this.Id = 0;
            this.Reference = $("#Reference").val();
            this.DateAdmission = "";
            this.DateCreation = "";
            this.State = 'Incomplet';
            this.Type = $("#type").val();
        }

    };



    if (($("#type").val() == "Femme")) {
        if ($("#Id4").val() == 0) {
            $('#tes').show();
        }
        else {
            $.post("/DossierMedical/AddDossierMedical", { dossierMedical: new DossierMedical(), id: $("#Id4").val() }, function (result) {
                if (result.status) {

                    Swal.fire({

                        icon: 'success',
                        title: result.message,
                        showConfirmButton: false,
                        timer: 15000
                    })
                    setTimeout(function () {
                        window.location.href="/DossierMedical/Index"
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

        }



    } else if ($("#type").val() == "Homme") {
        if ($("#Id3").val() == 0) {
            $('#tes1').show();
        }
        else {
            $.post("/DossierMedical/AddDossierMedical", { dossierMedical: new DossierMedical(), id: $("#Id3").val() }, function (result) {

                if (result.status) {

                    Swal.fire({

                        icon: 'success',
                        title: 'DOSSIER ajouter',
                        showConfirmButton: false,
                        timer: 1500
                    })
                    setTimeout(function () {
                        window.location.href = "/DossierMedical/Index"
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

        }

    }
    else {

        if ($("#Id2").val() == 0 || $("#Id1").val() == 0) {
            if ($("#Id1").val() == 0) { $('#tes2').show(); }
            else { $('#tes3').show(); }


        }
        else {
            var t = '' + ($("#Id2").val()) + ',' + ($("#Id1").val());

            $.post("/DossierMedical/AddDossierMedicalTowP", { dossierMedical: new DossierMedical(), ids: t }, function (result) {


                if (result.status) {

                    Swal.fire({

                        icon: 'success',
                        title: 'DOSSIER ajouter',
                        showConfirmButton: false,
                        timer: 15000
                    })
                    setTimeout(function () {
                        window.location.href = "/DossierMedical/Index"
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

        }
    }



}

function showmodaladdpatien() {
    $("#addDossierMedical").modal('hide');

    $("#add_patient").modal('show');

}
function AddPatient() {

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

            this.Id = localStorage.getItem("idPatient");
            var files = $('#Photo').get(0);
            this.Cin = $("#Cin").val();
            this.IssuedOn = null;
            this.FirstName = $("#FirstName").val();
            this.LastName = $("#LastName").val();
            this.MaidenName = null;
            this.Gender = $('input[name=gender]:checked').val();
            this.Profession = $("#Profession").val();

            this.Photo = null;



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
            this.State = null;


        }



    };

    if ($("#Cin").val() == "" || $("#FirstName").val() == "" || $("#LastName").val() == "" || $("#Phone").val() == "" || $("#Dataofbirth").val() == "" || $("#Placeofbirth").val() == "") {
        if ($("#Cin").val() == "") {
            $('#d').show();
        }
        if ($("#FirstName").val() == "") { $('#e').show(); }
        if ($("#LastName").val() == "") { $('#f').show(); }
        if ($("#Dataofbirth").val() == "") { $('#g').show(); }

        if ($("#Placeofbirth").val() == "") { $('#h').show(); }
        if ($("#Phone").val() == "") { $('#i').show(); }
        if ($("#Nationality").val() == "") { $('#j').show(); }
        if ($("#Email").val() == "") { $('#k').show(); }
        if ($('input[name=gender]:checked').val() == "") { $('#l').show(); }
        if ($("#Civility").val() == "") { $('#m').show(); }


    } else {


        var regex = /[a-zA-Z-áàâäãåçéèêëíìîïñóòôöõúùûüýÿæœÁÀÂÄÃÅÇ()""''ÉÈÊËÍÌÎÏÑÓÒÔÖÕÚÙÛÜÝŸÆŒ._\s\.\,\--]/;

        if (!$("#Phone").val().match(regex)) {
            $('#i').hide()

            $.post("/Patient/AddPatient", { patient: new Patient() }, function (result) {

                if (result.status) {

                    Swal.fire({

                        icon: 'success',
                        title: 'patient ajouter',
                        showConfirmButton: false,
                        timer: 1500,

                    })

                    patient = new Patient()
                    $.get("/Patient/GetPatientsBy_EMAIL", { email: $("#Email").val() }, function (re) {

                        if ($("#type").val() == "Couple") {
                            if (re.Gender == "Femme") {
                                $("#Id2").append(' <option value="' + re.Id + '" selected> ' + re.FirstName + ' & nbsp;  & nbsp;   & nbsp; ' + re.LastName + '  </option>')
                                $("#add_patient").modal('hide');

                            }
                            if (re.Gender == "Homme") {
                                $("#Id1").append(' <option value="' + re.Id + ' " selected> ' + re.FirstName + '&nbsp;  &nbsp;   &nbsp; ' + re.LastName + ' </option>')
                                $("#add_patient").modal('hide');

                            }
                        }
                        if ($("#type").val() == "Femme") {
                            if (re.Gender == "Femme") {
                                $("#Id4").append(' <option value="' + re.Id + '"  selected> ' + re.FirstName + '&nbsp;  &nbsp;   &nbsp; ' + re.LastName + ' </option>')
                                $("#add_patient").modal('hide');
                            }


                        }
                        if ($("#type").val() == "Homme") {

                            if (re.Gender == "Homme") {

                                $("#Id3").append(' <option value="' + re.Id + '"   selected> ' + re.FirstName + '&nbsp;  &nbsp;   &nbsp; ' + re.LastName + +' </option>')
                                $("#add_patient").modal('hide');
                            }

                        }



                    })



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

};