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
    public class AntecedentParticulierController : Controller
    {
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Add(AntecedentParticulier antecedent)
        {
            return Json(BLL_AntecedentParticulier.Add(antecedent));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Update(AntecedentParticulier antecedent)
        {
            return Json(BLL_AntecedentParticulier.Update(antecedent));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Gets(int IdReneignement)
        {
            return Json(BLL_AntecedentParticulier.Gets(IdReneignement));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Delete(int Id)
        {
            return Json(BLL_AntecedentParticulier.Delete(Id));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Get(int Id)
        {
            return Json(BLL_AntecedentParticulier.GET(Id));
        }
    }
}
