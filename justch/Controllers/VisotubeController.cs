using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class VisotubeController : Controller
    {
        public IActionResult Add(Visotube actData)
        {
            return Json(BLL_Visotube.Add(actData));
        }

        public IActionResult GetById(int Id)
        {
            return Json(BLL_Visotube.GetById(Id));
        }

        public IActionResult Update(Visotube actData)
        {
            return Json(BLL_Visotube.Update(actData));
        }

        public IActionResult Gets()
        {
            return Json(BLL_Visotube.GETS());
        }
        public IActionResult Delete(int Id)
        {
            return Json(BLL_Visotube.delete(Id));
        }
        public IActionResult GETbyIdCuve(int Id)
        {
            return Json(BLL_Visotube.GETSIdcuve(Id));
        }
    }
}
