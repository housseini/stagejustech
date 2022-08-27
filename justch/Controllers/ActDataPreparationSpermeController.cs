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
    public class ActDataPreparationSpermeController : Controller
    {
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Add(ActDataPreparationSperme actData)
        {
            return Json(BLL_ActDataPreparationSperme.Add(actData));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_ActDataPreparationSperme.GetByIdTraitement(Id));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]


        public IActionResult Update(ActDataPreparationSperme actData)
        {
            return Json(BLL_ActDataPreparationSperme.Update(actData));
        }
    }
}
