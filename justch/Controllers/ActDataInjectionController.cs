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
    public class ActDataInjectionController : Controller
    {
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Add(ActDataInjection actData)
        {
            return Json(BLL_ActDataInjection.Add(actData));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_ActDataInjection.GetByIdTraitement(Id));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Update(ActDataInjection actData)
        {
            return Json(BLL_ActDataInjection.Update(actData));
        }
    }
}
