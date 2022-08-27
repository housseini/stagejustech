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
    public class EnbryonnaireCongelationDataController : Controller
    {

        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_EnbryonnaireCongelationData.GetByIdTraitement(Id));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Update(EnbryonnaireCongelationData actData)
        {
            return Json(BLL_EnbryonnaireCongelationData.Update(actData));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult GET(int Id)
        {
            return Json(BLL_EnbryonnaireCongelationData.GET(Id));
        }
    }
}
