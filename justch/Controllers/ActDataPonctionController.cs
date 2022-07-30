using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class ActDataPonctionController : Controller
    {
        public IActionResult Add(ActDataPonction actData)
        {
            return Json(BLL_ActDataPonction.Add(actData));
        }

        public IActionResult GetByIdTraitement(int  Id)
        {
            return Json(BLL_ActDataPonction.GetByIdTraitement(Id));
        }

        public IActionResult Update(ActDataPonction actData)
        {
            return Json(BLL_ActDataPonction.Update(actData));
        }
    }
}
