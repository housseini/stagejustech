$(document).ready(function () {

    (sessionStorage.getItem('idPatient'));
});
function showmadaladd() {
    $("#ajouterdocument").modal('show');;
}
function addlocalsession(id) {
    sessionStorage.setItem('IDdocumment', id);
    
}

function voirimage(ima) {
    
    Swal.fire({

        imageUrl: 'http://localhost:5000/img/Profile/' + ima,
        imageWidth: 500,
        imageHeight: 500,
        imageAlt: 'Custom image',
    })
}



function edit(Id) {

    sessionStorage.setItem("idPatient", Id);

}

function showmodaladdtypefile() {
    $("#ajouterdocument").modal('hide');
    $("#ajouterdocumentTYPE").modal('show');
}
function showaddmedicalrecordact() {
    $("#ajoutermedicalrecordact").modal('show');
}

function fermer() {
    $("#supprimerdocument").modal('hide');
}


function modalsupprimerssohw(id) {
    $("#supprimerdocument").modal('show');
    sessionStorage.setItem('IDdocumment', id);

}

function confirmationdelete() {
    var iddocument = (sessionStorage.getItem('IDdocumment'));
   
    $.get("/Patient/DeleteDocument", { id: iddocument}, function (result) {

        $("#supprimerdocument").modal('hide');
        if (result.status) {
            Swal.fire({

                icon: 'success',
                title: result.message,
                showConfirmButton: false,
                timer: 15000
            })
            setTimeout(function () {
                window.location.reload()
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

function addTypeDocument() {
    class DocumentType {
        Code;
        Label;
        constructor() {
            this.Label = $("#NomDt").val();
            this.Code=$("#Code").val() ;
        }
    }

    if ($("#Code").val() == "" || $("#NomDt").val() == "") { } else {
        $.post("/DossierMedical/AddDocummentType", { documment: new DocumentType() }, function (result) {

            if (result.status) {
                Swal.fire({

                    icon: 'success',
                    title: result.message,
                    showConfirmButton: false,
                    timer: 15000
                })
                setTimeout(function () {
                    window.location.reload()
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
    };
}

function addDocument() {

    class Document {
        Id
        IdPatient
        CodeDocumentType
        IdDossierMedical
        Name
        Description
        File
        constructor() {
            var files = $('#Fichier').get(0);
            var formData = new FormData();
            formData.append('file', files.files[0]);
            this.Id = 0;
            this.Path = files.files[0].name;
            this.CodeDocumentType = $("#TypeDocumment").val();
            this.IdPatient = sessionStorage.getItem('idPatient');
            this.IdDossierMedical = $("#DOSSIER").val();
            this.Name = $("#Nomd").val();
            this.Description = $("#Descripion").val();
        }
    }
    var files = $('#Fichier').get(0);
   
    if (files.files[0].name != "" && $("#Nomd").val() != "") {
       
        var formData = new FormData();
        formData.append('file', files.files[0]);
        $.ajax({
            type: 'POST',
            url: "/Patient/FILEdocumen",
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
                    $.post("/Patient/AddDocument", { d: new Document(),id:0 }, function (result) {
                       
                        if (result.status) {
                            Swal.fire({

                                icon: 'success',
                                title: result.message,
                                showConfirmButton: false,
                                timer: 15000
                            })
                            setTimeout(function () {
                                window.location.reload()
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
            },
            error: function (error) {
                Swal.fire({

                    icon: 'warning',
                    title: 'Un Docment de meme non exite mercie de renomer votre document',
                    showConfirmButton: false,
                    timer: 30000
                })
            }
        });

    }

    }
   






    

