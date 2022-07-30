using justch.Models.BLL;
using justch.Models.ENTITIES;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Controllers
{
    public class TraitementCycleController : Controller
    {
        public IActionResult Index() {

            BLL_TraitementCycle.Gets();
            ViewBag.ACTMEDICAL = BLL_MedicalAct.gets();
            return View();
        }
       [Authorize]
      [HttpPost]
        public IActionResult Add(String trai,int Id )
        {
            TraitementCycle t = new TraitementCycle();
                t.Name = trai;
            t.Id = 0;
            t.IdMedicalAct = Id;

            return Json(BLL_TraitementCycle.Add(t)); 
        }

        [Authorize]
        [HttpGet]
        public IActionResult ALLTCACM()
        {
            return Json(BLL_TraitementCycle.ALLTCACM());
        }
        [Authorize]
        [HttpGet]
        public IActionResult DeletById(int Id) {
            return Json(BLL_TraitementCycle.deletById(Id));
        
        }
        /// <summary>
        /// retourne TCACM DONT ID DE ACT ELEMENTAIRE CYCLE EST PASSE EN PARAMMETRE 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public IActionResult GetTCACM(int Id)
        {
            return Json(BLL_TraitementCycle.GetTCACMbyID(Id));
        }
        [Authorize]
        [HttpPost]
        public IActionResult Update( int Idtraitemen , string Name ,int idtraitementElement ,int Idact )
        {
            TraitementCycle traitement = new TraitementCycle();
            traitement.Id = Idtraitemen;
            traitement.Name = Name;
            TreatmentCycleElementaryAct  te= new TreatmentCycleElementaryAct();
            te.Id = idtraitementElement;
            te.IdMedicalAct = Idact;

            return Json(BLL_TraitementCycle.Update(traitement, te));
        }


    }
}
