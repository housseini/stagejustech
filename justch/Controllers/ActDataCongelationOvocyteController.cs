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
    public class ActDataCongelationOvocyteController : Controller
    {
        [Authorize(Roles = "Clinicien,Embryologiste")]
        public IActionResult Add(ActDataCongelationOvocyte actData)
        {
            return Json(BLL_ActDataCongelationOvocyte.Add(actData));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]
        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_ActDataCongelationOvocyte.GetByIdTraitement(Id));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]
        public IActionResult Update(ActDataCongelationOvocyte actData)
        {
            return Json(BLL_ActDataCongelationOvocyte.Update(actData));
        }
    }
}
