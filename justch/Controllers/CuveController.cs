using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.DAL;
using justch.Models.ENTITIES;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class CuveController : Controller
    {
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Index()
        {
            ViewBag.CuveVisotubePaitelle = new CuveVisotubePaitelle();
            return View();
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Add(Cuve actData)
        {
            return Json(BLL_Cuve.Add(actData));
        }

        public IActionResult GetById(int Id)
        {
            return Json(BLL_Cuve.GetById(Id));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]


        public IActionResult Update(Cuve actData)
        {
            return Json(BLL_Cuve.Update(actData));
        }

        public IActionResult Gets()
        {
            return Json( BLL_Cuve.GETS());
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Delete(int Id)
        {
            return Json(BLL_Cuve.delete(Id));
        }

    }
}
