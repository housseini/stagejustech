using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class ActDataCongelationEnbryonnaireController : Controller
    {
        public IActionResult Add(string  listenumero, int IdMedicalRecordAct, int IdEnbryologisteDoctor, string Date, string heur, string sang, string glaire, string Mileu, string com, int IdPaillete, string Jours, int idculture)
        {
            List<int> liste = new List<int>();
            foreach (string t in listenumero.Split(","))
            {
                liste.Add(int.Parse(t));
            }
            return Json(BLL_ActDataCongelationEnbryonnaire.Add(liste,  IdMedicalRecordAct,  IdEnbryologisteDoctor,  Date,  heur,  sang,  glaire,  Mileu,  com,   IdPaillete,  Jours,  idculture));
        }

        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_ActDataCongelationEnbryonnaire.GetByIdTraitement(Id));
        }

        public IActionResult Update(ActDataCongelationEnbryonnaire actData)
        {
            return Json(BLL_ActDataCongelationEnbryonnaire.Update(actData));
        }
    }
}
