using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class ActDataBiopsieController : Controller
    {
        public IActionResult Add(ActDataBiopsie actData)
        {
            return Json(BLL_ActDataBiopsie.Add(actData));
        }

        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_ActDataBiopsie.GetByIdTraitement(Id));
        }

        public IActionResult Update(ActDataBiopsie actData)
        {
            return Json(BLL_ActDataBiopsie.Update(actData));
        }
    }
}
