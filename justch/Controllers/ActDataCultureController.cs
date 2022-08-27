using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.DAL;
using justch.Models.ENTITIES;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class ActDataCultureController : Controller
    {
        [Authorize(Roles = "Clinicien,Embryologiste")]
        public IActionResult Add(ActDataCulture actData)
            {
            return Json(BLL_ActDataCulture.Add(actData));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]
        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_ActDataCulture.GetByIdTraitement(Id));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]
        public IActionResult Update(string listenumero, int idactculture, int Jours, string Grade, string chambre, int Incubateur, int enbryologite, string date, string heur, string Commentaire, int iddeco)
        {
              
            List<int> liste = new List<int>();
            foreach (string t in listenumero.Split(","))
            {
                liste.Add(int.Parse(t));
            }
            return Json(BLL_ActDataCulture.Update(liste,  idactculture,  Jours,  Grade,  chambre,  Incubateur,  enbryologite,  date,  heur,  Commentaire,  iddeco));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]
        public IActionResult GetCultureComplet(int Id)
        {
            return Json(BLL_ActDataCulture.GetCultureComplet(Id));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]
        public IActionResult AddmedicalRepoort(MedicalReport actData)
        {
            return Json(DAL_MedicalReport.Add(actData));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]
        public IActionResult Regernere(int Id)
        {
            return Json(DAL_MedicalReport.Regernere(Id));
        }
    }
}
