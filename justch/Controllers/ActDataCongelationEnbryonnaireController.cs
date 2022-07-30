using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class ActDataCongelationEnbryonnaireController : Controller
    {
        public IActionResult Add(ActDataCongelationEnbryonnaire actData)
        {
            return Json(BLL_ActDataCongelationEnbryonnaire.Add(actData));
        }

        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_ActDataCongelationEnbryonnaire.GetByIdTraitement(Id));
        }

        public IActionResult Update(ActDataCongelationEnbryonnaire actData)
        {
            return Json(BLL_ActDataCongelationEnbryonnaire.Update(actData));
        }
    }
}
