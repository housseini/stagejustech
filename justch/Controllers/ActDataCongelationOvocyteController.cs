using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class ActDataCongelationOvocyteController : Controller
    {
        public IActionResult Add(ActDataCongelationOvocyte actData)
        {
            return Json(BLL_ActDataCongelationOvocyte.Add(actData));
        }

        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_ActDataCongelationOvocyte.GetByIdTraitement(Id));
        }

        public IActionResult Update(ActDataCongelationOvocyte actData)
        {
            return Json(BLL_ActDataCongelationOvocyte.Update(actData));
        }
    }
}
