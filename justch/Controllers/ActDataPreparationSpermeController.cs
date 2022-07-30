using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class ActDataPreparationSpermeController : Controller
    {
        public IActionResult Add(ActDataPreparationSperme actData)
        {
            return Json(BLL_ActDataPreparationSperme.Add(actData));
        }

        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_ActDataPreparationSperme.GetByIdTraitement(Id));
        }

        public IActionResult Update(ActDataPreparationSperme actData)
        {
            return Json(BLL_ActDataPreparationSperme.Update(actData));
        }
    }
}
