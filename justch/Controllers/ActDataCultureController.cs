using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class ActDataCultureController : Controller
    {
        public IActionResult Add(ActDataCulture actData)
        {
            return Json(BLL_ActDataCulture.Add(actData));
        }

        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_ActDataCulture.GetByIdTraitement(Id));
        }

        public IActionResult Update(ActDataCulture actData)
        {
            return Json(BLL_ActDataCulture.Update(actData));
        }
    }
}
