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


    $.post("/Authentification/login", { login: { Utilisateur: $("#Username").val(), Passeword: $("#Password").val(), Type: '' } }, function (re) {
        if (re.status) {
            $("#header").show()
            $("#sidebar").show()
            window.location.href = "/Patient/Index"

        //$.ajax({
    
        //url: "/Patient/Index",
        //headers: {
        //  Authorization: 'Bearer ' + re.message
        //    }
    

        //});
         

        }
   

    })
}