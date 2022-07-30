using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.DAL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class CuveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add(Cuve actData)
        {
            return Json(BLL_Cuve.Add(actData));
        }

        public IActionResult GetById(int Id)
        {
            return Json(BLL_Cuve.GetById(Id));
        }

        public IActionResult Update(Cuve actData)
        {
            return Json(BLL_Cuve.Update(actData));
        }

        public IActionResult Gets()
        {
            return Json( BLL_Cuve.GETS());
        }
        public IActionResult Delete(int Id)
        {
            return Json(BLL_Cuve.delete(Id));
        }

    }
}
