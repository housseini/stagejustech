using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class ActDataInseminationIACController : Controller
    {
        public IActionResult Add(ActDataInseminationIAC actData)
        {
            return Json(BLL_ActDataInseminationIAC.Add(actData));
        }

        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_ActDataInseminationIAC.GetByIdTraitement(Id));
        }

        public IActionResult Update(ActDataInseminationIAC actData)
        {
            return Json(BLL_ActDataInseminationIAC.Update(actData));
        }
    }
}
