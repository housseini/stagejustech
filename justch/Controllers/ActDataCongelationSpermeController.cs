using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class ActDataCongelationSpermeController : Controller
    {
        [Authorize(Roles = "Clinicien,Embryologiste")]
        public IActionResult Add(ActDataCongelationSperme actData)
        {
            return Json(BLL_ActDataCongelationSperme.Add(actData));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]
        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_ActDataCongelationSperme.GetByIdTraitement(Id));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]
        public IActionResult Update(ActDataCongelationSperme actData)
        {
            return Json(BLL_ActDataCongelationSperme.Update(actData));
        }
    }
}
