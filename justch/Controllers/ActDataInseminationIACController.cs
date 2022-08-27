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
    public class ActDataInseminationIACController : Controller
    {
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Add(ActDataInseminationIAC actData)
        {
            return Json(BLL_ActDataInseminationIAC.Add(actData));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]


        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_ActDataInseminationIAC.GetByIdTraitement(Id));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Update(ActDataInseminationIAC actData)
        {
            return Json(BLL_ActDataInseminationIAC.Update(actData));
        }
    }
}
