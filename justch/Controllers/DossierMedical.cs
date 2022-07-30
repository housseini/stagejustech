using Core.Flash;
using justch.Models.BLL;
using justch.Models.DAL;
using justch.Models.ENTITIES;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Xml;

namespace justch.Controllers
{
    public class DossierMedical : Controller
    {
        public IFlasher f;
        public DossierMedical(IFlasher f) { this.f = f; }
        #region
        [Authorize]
        [HttpGet]
        public IActionResult Index()

        {
         

                
                ViewBag.Dossiers = BLL_DossierMedical.GetDossiersMedicals();
                ViewBag.Patients = BLL_Patient.GetPatients();
                return View();
      
            

            
          
        }
        [Authorize]
        [HttpGet]
        public IActionResult Consulter(int  Reference)
        {
            ViewBag.MedicalActRecords = BLL_MedicalRecordAct.getsByIdMedicalRecord(Reference);
            ViewBag.DocumentType = BLL_DocumentType.gets();
            ViewBag.Documents = BLL_Document.getsByIdDossier(Reference);
            ViewBag.DossierMedicale = BLL_DossierMedical.GetDossierMedicalbyID(Reference);
            ViewBag.Doctors = BLL_Doctor.gets();
            ViewBag.MedicalAct = BLL_MedicalAct.gets();

            ViewBag.DossierPersonnaliser = BLL_DossierMedicalPersonniser.get(Reference);
;
            return View();
        }
        [Authorize]
        public IActionResult Add()
        {
            ViewBag.Countrys = GetAllContry();
            ViewBag.Patients = BLL_Patient.GetPatients();
            return View();
        }
        [Authorize]
        [HttpGet]
        public IActionResult GETS()
        {
            return Json(BLL_DossierMedical.GetDossiersMedicals());
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetpATIENTSBYREFENCE(int  Re)
        {
            return Json(BLL_View_P_DMP_DM.Get_list_Patient(Re));
        }
        [Authorize]
        [HttpPost]
        public IActionResult RechercherAvance(int Id, string Cin, string Ref, DateTime dataa, string email, string telephone ,int nbr)
        {
            return Json(BLL_DossierMedical.RechercherAvance(Id, Cin, Ref, dataa, email, telephone, nbr));
            //return Json(dataa);
        }
        [Authorize]

        [HttpPost]
        public IActionResult AddDossierMedical(Models.ENTITIES.DossierMedical DossierMedical, int id)
        {
            var message = BLL_DossierMedical.AddDossierMedical(DossierMedical, id);
            if (message.status)
                this.f.Flash(Types.Success, message.message);
            else
                this.f.Flash(Types.Warning, message.message);
            return Json(message);

        }
        [Authorize]
        [HttpPost]
        public IActionResult AddDossierMedicalTowP(Models.ENTITIES.DossierMedical dossierMedical, string ids)
        {
            int id = int.Parse(ids.Split(',')[0]);
            var message = BLL_DossierMedical.AddDossierMedical(dossierMedical, id);
            if (message.status)
            {
                DossierMedicalPatient dP = new DossierMedicalPatient();
                dP.IdDossierMedical = BLL_DossierMedical.GetDossierMedicalbyReference(dossierMedical.Reference).Id;
                dP.IdPatient= int.Parse(ids.Split(',')[1]);
                message = DAL_DossierMedicalPatient.AddDossierMedicalPatient(dP);
                this.f.Flash(Types.Success, message.message);
            }
            else
                this.f.Flash(Types.Warning, " erreur  DossierMedical n est pas ajouter ");
            return Json(message);

        }

        [Authorize]
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
        [Authorize]
        [HttpGet]
        public IActionResult DeleteDossierMedical(int id) {
            var message = BLL_DossierMedical.deleteDossierMedical("Id", id.ToString());
            if (message.status)
                this.f.Flash(Types.Success, message.message);
            else
                this.f.Flash(Types.Warning, " erreur  DossierMedical n est pas supprimer ");
            return Json(message);

        }
        [Authorize]
        public IActionResult editeDossierMedical(int id)
        {
          
            ViewBag.id = id;
            ViewBag.Countrys = GetAllContry();
            ViewBag.DossierMedical = BLL_DossierMedical.GetDossierMedicalbyID(id);
            ViewBag.Patients = BLL_Patient.GetPatients();
            return View();

        }
        [Authorize]
        [HttpPost]
        public IActionResult editeDossierMedical(Models.ENTITIES.DossierMedical d, DossierMedicalPatient dmp)
        {
            var message = BLL_DossierMedical.updateDossierMedical(d,dmp);
            if (message.status)
                this.f.Flash(Types.Success, message.message);
            else
                this.f.Flash(Types.Warning, message.message );
            return Json(message);

        }

        [Authorize]
        [HttpPost]
        public IActionResult editeDossierMedicalsing ( Models.ENTITIES.DossierMedical d )
        {
            var message = BLL_DossierMedical.updateDossierMedical(d);
            if (message.status)
                this.f.Flash(Types.Success, message.message);
            else
                this.f.Flash(Types.Warning, message.message);
            return Json(message);

        }



        [Authorize]
        //ajouter un document Type
        [HttpPost]
        public IActionResult AddDocummentType(justch.Models.ENTITIES.DocumentType  documment)
        {
            var message = BLL_DocumentType.add(documment);
            if (message.status)
                this.f.Flash(Types.Success, message.message);
            else
                this.f.Flash(Types.Warning, message.message);
            return Json(message);

        }
        [Authorize]
        [HttpPost]
      public IActionResult AddMedicalRecordAct(MedicalRecordAct recordAct)
        {
            var message = BLL_MedicalRecordAct.add(recordAct);
            if (message.status)
                this.f.Flash(Types.Success, message.message);
            else
                this.f.Flash(Types.Warning, message.message);
            return Json(message);
        }
        [Authorize]

        [HttpGet]
    public IActionResult DeleteMedicalRecordAct(int id)
    {
        var message = BLL_MedicalRecordAct.delete(id);
        if (message.status)
            this.f.Flash(Types.Success, message.message);
        else
            this.f.Flash(Types.Warning, message.message);
        return Json(message);
    }
        [Authorize]

        [HttpGet]
    public int Count ( )
        {
            return BLL_DossierMedical.Count();
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetdossierById  ( int id )
        {
            return Json( BLL_DossierMedical.GetDossierMedicalbyID(id));
        }
        [Authorize]
        [HttpGet] 
        public IActionResult GetMedicalActsByIdmedicalrecord(int id )
        {
            return Json(BLL_MedicalRecordAct.getsByIdMedicalRecord(id));
        }
        [Authorize]

        public IActionResult Completer(int Id )
        {
            return Json(BLL_DossierMedical.completer(Id));
        }
        [Authorize]

        public IActionResult InCompleter(int Id)
        {

            return Json(BLL_DossierMedical.InCompleter(Id));

        }
        #endregion
        #region
        public IActionResult ConsulterTraitementCycle(int Reference,int Idtraitement)
        {
            ViewBag.MedicalActRecords = BLL_MedicalRecordAct.getsByIdMedicalRecord(Reference);
            ViewBag.DocumentType = BLL_DocumentType.gets();
            ViewBag.Documents = BLL_Document.getsByIdDossier(Reference);
            ViewBag.DossierMedicale = BLL_DossierMedical.GetDossierMedicalbyID(Reference);
            ViewBag.Doctors = BLL_Doctor.gets();
            ViewBag.MedicalAct = BLL_MedicalAct.gets();
            ViewBag.CultureComplet = BLL_ActDataCulture.GetCultureComplet(Idtraitement);
            return View();
        }

        public IActionResult ConsulterActExploration(int Reference)
        {

            ViewBag.MedicalActRecords = BLL_MedicalRecordAct.getsByIdMedicalRecord(Reference);
            ViewBag.DocumentType = BLL_DocumentType.gets();
            ViewBag.Documents = BLL_Document.getsByIdDossier(Reference);
            ViewBag.DossierMedicale = BLL_DossierMedical.GetDossierMedicalbyID(Reference);
            ViewBag.Doctors = BLL_Doctor.gets();
            ViewBag.MedicalAct = BLL_MedicalAct.gets();
            return View();

        }
        #endregion
        #region compteRendue
        public IActionResult CompteRendue(int Reference)
        {
            return View();
        }
        #endregion
    }
}
