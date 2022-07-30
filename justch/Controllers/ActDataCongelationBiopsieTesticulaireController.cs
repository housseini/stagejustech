using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class ActDataCongelationBiopsieTesticulaireController : Controller
    {
        public IActionResult Add(ActDataCongelationBiopsieTesticulaire actData)
        {
            return Json(BLL_ActDataCongelationBiopsieTesticulaire.Add(actData));
        }

        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_ActDataCongelationBiopsieTesticulaire.GetByIdTraitement(Id));
        }

        public IActionResult Update(ActDataCongelationBiopsieTesticulaire actData)
        {
            return Json(BLL_ActDataCongelationBiopsieTesticulaire.Update(actData));
        }
    }
}
