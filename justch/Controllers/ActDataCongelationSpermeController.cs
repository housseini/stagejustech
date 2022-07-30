using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class ActDataCongelationSpermeController : Controller
    {
        public IActionResult Add(ActDataCongelationSperme actData)
        {
            return Json(BLL_ActDataCongelationSperme.Add(actData));
        }

        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_ActDataCongelationSperme.GetByIdTraitement(Id));
        }

        public IActionResult Update(ActDataCongelationSperme actData)
        {
            return Json(BLL_ActDataCongelationSperme.Update(actData));
        }
    }
}
