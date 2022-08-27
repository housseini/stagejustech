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
    public class BilanEndocrinienController : Controller
    {
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Add(BilanEndocrinien bilan)
        {
            return Json(BLL_BilanEndocrinien.Add(bilan));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Gets(int id)
        {
            return Json(BLL_BilanEndocrinien.Gets(id));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult GETbyID(int Id)
        {
            return Json(BLL_BilanEndocrinien.GETbyID(Id));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Update(BilanEndocrinien bilan)
        {
            return Json(BLL_BilanEndocrinien.Update(bilan));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]


        public IActionResult Delete(int Id)
        {
            return Json(BLL_BilanEndocrinien.Delete(Id));
        }


    }
}
