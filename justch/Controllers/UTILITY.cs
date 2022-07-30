using System.Collections.Generic;
using System.IO;
using System;

using justch.Models.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Core.Flash;
using System.Text.Json;
using justch.Models.ENTITIES;

namespace justch.Controllers
{
    public class UTILITY : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public UTILITY( IWebHostEnvironment webHostEnvironment)
        {
          
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult View_P_A_R_MA ( )
        {
            return Json(BLL_View_P_A_R_MA.Gets());
        }

        public int  CountMedicalrecordActbyIdactIddossier ( string IdACT, int IdDosssier ,string patients)
        {
            return BLL_MedicalRecordAct.countMedicalrecordActbyIdactIddossier(IdACT, IdDosssier,patients);
        }

        public IActionResult AllRdv ( )
        {
            return Json(BLL_Utiliy.allRdv());
        }


        public IActionResult GetRDVbyIdAPP(int id)
        {
            return Json(BLL_Utiliy.GetRdvById(id));
        }
        public IActionResult RdvBYidpatient ( int id )
        {
            return Json(BLL_Utiliy.RdvBY(id));
        }
        public IActionResult MedicalActs ( )
        {
            return Json(BLL_Utiliy.MedicalAct());
        }

        public IActionResult TerminerMedicalactRecord (int id  )
        {
            return Json(BLL_MedicalRecordAct.terminer(id));
        }
        /// controlle sur DossierMedicalPersonniser 
        public IActionResult GetDossierMedicalPersonniser(int IdDossierMedical)
        {
            return Json(BLL_DossierMedicalPersonniser.get(IdDossierMedical));
        }


        /// controlle sur le DOCUMENTYPE 
        /// RETOUR LE DOCUMENT DON LE CODE ET PASSE EN PARAMETTRE 
        public IActionResult GetByCode(string Code)
        {
            return Json(BLL_DocumentType.getByCode(Code)) ;
        }


        public IActionResult GetsColor()
{
            string dossier = Path.Combine(webHostEnvironment.WebRootPath, "Documents/french_colors.json");
            using (StreamReader r = new StreamReader(dossier))
{
                 var json = r.ReadToEnd();
                return Json(JsonSerializer.Deserialize<List<Couleur>>(json));
            }
        }

        public  IActionResult DeletemedicalRECORDACTE(int ID)
        {
            return Json(BLL_MedicalRecordAct.delete(ID));
        }

    }
}
