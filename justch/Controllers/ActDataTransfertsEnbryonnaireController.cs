using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class ActDataTransfertsEnbryonnaireController : Controller
    {
        public IActionResult Add(string listenumero, int IdMedicalRecordAct, int IdEnbryologisteDoctor, string Date, string heur, string sang, string glaire, string cathere, string transfer, string com, string nombreembroyontr, string Jours, int IdDoctor,int idculture)
        {
            List<int> liste = new List<int>();
            foreach (string t in listenumero.Split(","))
            {
                liste.Add(int.Parse(t));
            }
            return Json(BLL_ActDataTransfertsEnbryonnaire.Add(liste,  IdMedicalRecordAct,  IdEnbryologisteDoctor,  Date,  heur,  sang,  glaire,  cathere,  transfer,  com,  nombreembroyontr,  Jours,  IdDoctor, idculture));
        }

        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_ActDataTransfertsEnbryonnaire.GetByIdTraitement(Id));
        }

        public IActionResult Update(ActDataTransfertsEnbryonnaire actData)
        {
            return Json(BLL_ActDataTransfertsEnbryonnaire.Update(actData));
        }
    }
}
