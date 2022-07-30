using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class ActDataTransfertsEnbryonnaireController : Controller
    {
        public IActionResult Add(ActDataTransfertsEnbryonnaire actData)
        {
            return Json(BLL_ActDataTransfertsEnbryonnaire.Add(actData));
        }

        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_ActDataTransfertsEnbryonnaire.GetByIdTraitement(Id));
        }

        public IActionResult Update(ActDataTransfertsEnbryonnaire actData)
        {
            return Json(BLL_ActDataTransfertsEnbryonnaire.Update(actData));
        }
    }
}
