using Core.Flash;
using justch.Models.BLL;
using justch.Models.DAL;
using justch.Models.ENTITIES;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace justch.Controllers
{
    public class Patient : Controller

    {
        public IFlasher f;
        private readonly IWebHostEnvironment webHostEnvironment;
        public Patient(IFlasher f, IWebHostEnvironment webHostEnvironment)
        {
            this.f = f;
            this.webHostEnvironment = webHostEnvironment;
        }

 
        public IActionResult Index()
        {
          
            ViewBag.countrys = GetAllContry();
            return View(BLL_Patient.GetPatients());
        // return Json(BLL_Patient.GetPatients());
        }
        [Authorize(Roles = "Clinicien,Secretaire,Embryologiste")]
    
        [HttpPost]
        public IActionResult Adven(string CIN, string FirstName, string LastName, string Phone, string Email, DateTime Addedon, string State, DateTime Dataofbirth, int nombre)
        {
            return Json(BLL_Patient.Adven(CIN, FirstName, LastName, Phone, Email, Addedon, State, Dataofbirth, nombre));
        }
        [Authorize(Roles = "Clinicien,Secretaire,Embryologiste")]
        [HttpGet]
        public IActionResult Profile(int Id)
        {
            ViewBag.Documents = BLL_Document.getsBy("'IdPatient'",Id);
            var dossierMedicals = BLL_View_P_DMP_DM.GetDossierMedicalesByIdPatient(Id);
            if (dossierMedicals != null)
            {
                ViewBag.DossiersMedicals = BLL_View_P_DMP_DM.GetDossierMedicalesByIdPatient(Id);

            }
            else
            {
                ViewBag.DossiersMedicals = null;


            }
           
            ViewBag.DocumentType = BLL_DocumentType.gets();
            ViewBag.Patient = BLL_Patient.getPatientById(Id);
            ViewBag.Doctors=BLL_Doctor.gets();
            ViewBag.MedicalAct=BLL_MedicalAct.gets();
            return View();
        }
        [Authorize(Roles = "Clinicien,Secretaire,Embryologiste")]
        public JsonResult GetPatients()
        {
            return Json(BLL_Patient.GetPatients());
        }
        [Authorize]
        public IActionResult ADD()
        {
            ViewBag.countrys = GetAllContry();
            ViewBag.nationnalite = GetAllCivility();


            return View();
        }
        [Authorize(Roles = "Clinicien,Secretaire,Embryologiste")]
        [HttpPost]
        public IActionResult FILEUPLOAD(IFormFile file)
        {
            if (file.FileName != null)
            {
                string dossier = Path.Combine(webHostEnvironment.WebRootPath, "img/Profile");
                string filePath = Path.Combine(dossier, file.FileName);
                FileStream fileStream = new FileStream(filePath, FileMode.Create);
                file.CopyTo(fileStream);
                return Json(new Message(true, "file ajoutée "));
            }
            else
            {
                return Json(new Message(false, "file non ajoutée "));
            }
        }
        [Authorize(Roles = "Clinicien,Secretaire,Embryologiste")]
        [HttpPost]
        public IActionResult AddPatient(Models.ENTITIES.Patient patient)
        {

            //return Json(patient);

            var m = BLL_Patient.add(patient);
            if (m.status)
            {
                f.Flash(Types.Success, m.message, dismissable: true);

                return Json(m);
            }

            else
            {
                f.Flash(Types.Danger, m.message, dismissable: true);
                return Json(m);
            }



        }
        [Authorize(Roles = "Clinicien,Secretaire,Embryologiste")]
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var message = BLL_Patient.deletePatient(Id);
            if (message.status)
                this.f.Flash(Types.Success, message.message, dismissable: true);
            else
                this.f.Flash(Types.Warning, message.message, dismissable: true);
            return Json(message);
        }
        public List<string> GetAllContry()
        {
            List<string> lisname = new List<string>();

            CultureInfo[] culin = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo c in culin)
            {

                RegionInfo r = new RegionInfo(c.LCID);
                if (!lisname.Contains(r.EnglishName))
                {
                    lisname.Add(r.EnglishName);
                }



            }
            lisname.Sort();

            return lisname;
        }
        [Authorize(Roles = "Clinicien,Secretaire,Embryologiste")]
        [HttpGet]
        public IActionResult GetPatientsBy_EMAIL(string email)
        {
            return Json(BLL_Patient.getPatientsBy_EMAIL(email));
        }
        public List<string> GetAllCivility()
        {
            string pah = @"E:/projet/projet/stage/code/justch/justch/Views/Shared/nationalities.csv";
            List<string> lisname = new List<string>();

            TextReader reader = new StreamReader(pah);
            var csvReader = reader.ReadLine();
            foreach (string s in csvReader.ToString().Split(','))
            {
                lisname.Add(s);
            }
            lisname.Sort();
            return lisname;




        }
        [Authorize(Roles = "Clinicien,Secretaire,Embryologiste")]
        [HttpGet]
        public IActionResult EditPatient(int Id)
        {
            ViewBag.countrys = GetAllContry();
            ViewBag.nationnalite = GetAllCivility();
            ViewBag.Patient = BLL_Patient.getPatientById(Id);

            return View();
        }
        [Authorize(Roles = "Clinicien,Secretaire,Embryologiste")]
        [HttpPost]
        public IActionResult Edd(Models.ENTITIES.Patient patient)
        {
            var message = BLL_Patient.update(patient);
            if (message.status)
                this.f.Flash(Types.Success, message.message);
            else
                this.f.Flash(Types.Warning, message.message);
            return Json(message);

        }

        //ajouter document file 
       
        [HttpPost]
        public IActionResult FILEdocumen(IFormFile file)
        {
            if (file.FileName != null)
            {
                string dossier = Path.Combine(webHostEnvironment.WebRootPath, "Documents/" );
                string filePath = Path.Combine(dossier, file.FileName);
                FileStream fileStream = new FileStream(filePath, FileMode.Create);
                file.CopyTo(fileStream);
                return Json(new Message(true, "file ajoutée "));
            }
            else
            {

            }
            {
                return Json(new Message(false, "file non ajoutée "));
            }
        }
        [Authorize(Roles = "Clinicien,Secretaire,Embryologiste")]

        [HttpPost]
        public IActionResult AddDocument(Document d,int id)
        {
            var m = BLL_Document.Add(d,id);

            if (m.status)
            {
                f.Flash(Types.Success, m.message, dismissable: true);

                return Json(m);
            }

            else
            {
                f.Flash(Types.Danger, m.message, dismissable: true);
                return Json(m);
            }

        }
        //delete document by id 
        [Authorize(Roles = "Clinicien,Secretaire,Embryologiste")]

        [HttpGet]
        public IActionResult DeleteDocument(int id)
        {
            var m = BLL_Document.Delete(id);
         
          
            if (m.status)
            {
                f.Flash(Types.Success, m.message, dismissable: true);

                return Json(m);
            }

            else
            {
                f.Flash(Types.Danger, m.message, dismissable: true);
                return Json(m);
            }
        }
       
        public  bool DeleteFile(string file)
        {
          
            string dossier = Path.Combine(webHostEnvironment.WebRootPath, "Documents/"+file);
            string filePath = Path.Combine(dossier);
            System.IO.File.Delete(filePath);
            return true;
        }


        public FileResult ConsulterDcument(string file)
        {
            string dossier = Path.Combine(webHostEnvironment.WebRootPath, "Documents/" + file);
            string filePath = Path.Combine(dossier);
            return File(filePath, "application/pdf");
        }
       /// <summary>
       /// mettre le document a jous 
       /// </summary>
       /// <param name="d"></param>
       /// <returns></returns>
        public IActionResult Updatedocument(Document d)
        {
            return Json(BLL_Document.update(d));
        }
        /// <summary>
        /// supprimer le document selon id document  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult deleteDocument(int id)
        {
            return Json(BLL_Document.Delete(id));
        }
    }
}
