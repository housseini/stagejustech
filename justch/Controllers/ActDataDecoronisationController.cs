using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class ActDataDecoronisationController : Controller
    {
        public IActionResult Add(ActDataDecoronisation actData)
        {
            return Json(BLL_ActDataDecoronisation.Add(actData));
        }

        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_ActDataDecoronisation.GetByIdTraitement(Id));
        }

        public IActionResult Update(ActDataDecoronisation actData)
        {
            return Json(BLL_ActDataDecoronisation.Update(actData));
        }
    }
}
