using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class BilanEndocrinienController : Controller
    {
        public IActionResult Add(BilanEndocrinien bilan)
        {
            return Json(BLL_BilanEndocrinien.Add(bilan));
        }

        public IActionResult Gets(int id)
        {
            return Json(BLL_BilanEndocrinien.Gets(id));
        }

        public IActionResult GETbyID(int Id)
        {
            return Json(BLL_BilanEndocrinien.GETbyID(Id));
        }

        public IActionResult Update(BilanEndocrinien bilan)
        {
            return Json(BLL_BilanEndocrinien.Update(bilan));
        }


        public IActionResult Delete(int Id)
        {
            return Json(BLL_BilanEndocrinien.Delete(Id));
        }


    }
}
