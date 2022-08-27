$().ready(function () {
    $("#header").hide()
    $("#sidebar").hide()
    

})

function Login() {
    token=''
    login = {Utilisateur: $("#Username").val(), Passeword: $("#Password").val(), Type: '' }
    //$.ajax({
    //    type: "Post",
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json",
    //    url: '/Authentification/Login',
    //    data: { nom: $("#Username").val(), pass: $("#Password").val() },
    //    success: function (re) {
    //        console.log(re)


    //    }
    //}).done(function (data) {
    //    console.log(data)
    //});
    //$.ajax({
    //    type: "get",
    //    url: "/Patient/Index",
    //    headers: {
    //        Authorization: 'Bearer ' + token
    //    }
       
      
    //});

    
    $.post("/Authentification/login", { login: { Utilisateur: $("#Username").val(), Passeword: $("#Password").val(), Type: '' } }, function (re, status) {

        if (re == "non") {
            Swal.fire({

                icon: 'error',
                title: "merci de verifier vos prametre d acces ",
                showConfirmButton: false,
                timer: 4000
            })


        }
        else {

            if (re.Type == "Admis") {
                location.href = "/Utilisateur/Index";
            }
            if (re.Type == "Secretaire") {
                location.href = "/Patient/Index";
            }
            if (re.Type == "Clinicien") {
                location.href = "/Patient/Index";
            } if (re.Type == "Embryologiste") {
                location.href = "/DossierMedical/Index";
            }
       
  



        }
    });
 
}