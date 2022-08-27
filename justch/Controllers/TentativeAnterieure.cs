using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
  
    public class TentativeAnterieureController : Controller
    {

        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Add(TentativeAnterieur tentative)
        {
            return Json( BLL_TentativeAnterieure.Add(tentative));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]
        public IActionResult Gets(int IdRenseignement)
        {
            return Json( BLL_TentativeAnterieure.Gets(IdRenseignement));
        }

        public IActionResult GetById(int Id)
        {
            return Json(BLL_TentativeAnterieure.GetById(Id));
        }

        [Authorize(Roles = "Clinicien,Embryologiste")]
        public IActionResult Update(TentativeAnterieur tentative)
        {
            return Json(BLL_TentativeAnterieure.Update(tentative));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]
        public IActionResult Delete(int Id)
        {
            return Json(BLL_TentativeAnterieure.Delete(Id));
        }


    }
}
