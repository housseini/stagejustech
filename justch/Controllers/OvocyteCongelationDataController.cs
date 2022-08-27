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
    public class OvocyteCongelationDataController : Controller
    {
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Add(OvocyteCongelationData actData)
        {
            return Json(BLL_OvocyteCongelationData.Add(actData));
        }

        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_OvocyteCongelationData.GetByIdTraitement(Id));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]


        public IActionResult Update(OvocyteCongelationData actData)
        {
            return Json(BLL_OvocyteCongelationData.Update(actData));
        }
    }
}
