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
    public class CulureOvocyteDataController : Controller
    {
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Add(CulureOvocyteData actData)
        {
            return Json(BLL_CulureOvocyteData.Add(actData));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_CulureOvocyteData.GetByIdTraitement(Id));
        }

       
    }
}
