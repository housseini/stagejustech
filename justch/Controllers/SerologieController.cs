using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class SerologieController : Controller
    {
        public IActionResult Add(Serologie Serologie)
        {
            return Json(BLL_Serologie.Add(Serologie));
        }
        public IActionResult Update(Serologie Serologie)
        {
            return Json(BLL_Serologie.Update(Serologie));
        }

        public IActionResult Gets(int IdReneignement)
        {
            return Json(BLL_Serologie.Gets(IdReneignement));
        }
        public IActionResult GETbyID(int Id)
        {
            return Json(BLL_Serologie.GETbyID(Id));
        }

        public IActionResult Delete(int Id)
        {
            return Json(BLL_Serologie.Delete(Id));
        }

    }
}
