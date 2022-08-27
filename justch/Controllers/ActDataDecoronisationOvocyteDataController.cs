using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class ActDataDecoronisationOvocyteDataController : Controller
    {
        [Authorize(Roles = "Clinicien,Embryologiste")]
        public IActionResult Add(ActDataDecoronisationOvocyteData actData)
        {
            return Json(BLL_ActDataDecoronisationOvocyteData.Add(actData));

        }
        [Authorize(Roles = "Clinicien,Embryologiste")]
        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_ActDataDecoronisationOvocyteData.GetByIdTraitement(Id));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]
        public IActionResult Update(string listenumero, string etat, string commantaire, int Iddeco)
        {
            List<int> liste = new List<int>();
           foreach( string t in  listenumero.Split(","))
            {
                liste.Add(int.Parse(t));
            }


            return Json(BLL_ActDataDecoronisationOvocyteData.Update(liste, etat, commantaire, Iddeco));
        }
    }
}
