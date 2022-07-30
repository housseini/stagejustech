using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class ActDataDecoronisationOvocyteDataController : Controller
    {
        public IActionResult Add(ActDataDecoronisationOvocyteData actData)
        {
            return Json(BLL_ActDataDecoronisationOvocyteData.Add(actData));
        }

        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_ActDataDecoronisationOvocyteData.GetByIdTraitement(Id));
        }

        public IActionResult Update(ActDataDecoronisationOvocyteData actData)
        {
            return Json(BLL_ActDataDecoronisationOvocyteData.Update(actData));
        }
    }
}
