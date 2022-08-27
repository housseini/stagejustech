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
    public class PailletteController : Controller
    {
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Add(Paillette actData)
        {
            return Json(BLL_Paillette.Add(actData));
        }

        public IActionResult GetById(int Id)
        {
            return Json(BLL_Paillette.GetById(Id));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Update(Paillette actData)
        {
            return Json(BLL_Paillette.Update(actData));
        }

        public IActionResult Gets()
        {
            return Json(BLL_Paillette.GETS());
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Delete(int Id)
        {
            return Json(BLL_Paillette.delete(Id));
        }
        public IActionResult GETSIdVisotube(int Id)
        {
            return Json(BLL_Paillette.GETSIdVisotube(Id));
        }
    }
}
