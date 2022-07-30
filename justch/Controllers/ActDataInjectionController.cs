using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class ActDataInjectionController : Controller
    {
        public IActionResult Add(ActDataInjection actData)
        {
            return Json(BLL_ActDataInjection.Add(actData));
        }

        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_ActDataInjection.GetByIdTraitement(Id));
        }

        public IActionResult Update(ActDataInjection actData)
        {
            return Json(BLL_ActDataInjection.Update(actData));
        }
    }
}
