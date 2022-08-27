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
    public class ActDataPonctionController : Controller
    {
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Add(ActDataPonction actData)
        {
            return Json(BLL_ActDataPonction.Add(actData));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult GetByIdTraitement(int  Id)
        {
            return Json(BLL_ActDataPonction.GetByIdTraitement(Id));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Update(ActDataPonction actData)
        {
            return Json(BLL_ActDataPonction.Update(actData));
        }
    }
}
