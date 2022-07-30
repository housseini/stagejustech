using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class DevenirEmbryonController : Controller
    {
        public IActionResult Add(DevenirEmbryon actData)
        {
            return Json(BLL_DevenirEmbryon.Add(actData));
        }

        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_DevenirEmbryon.GetByIdTraitement(Id));
        }

        public IActionResult Update(DevenirEmbryon actData)
        {
            return Json(BLL_DevenirEmbryon.Update(actData));
        }
    }
}
