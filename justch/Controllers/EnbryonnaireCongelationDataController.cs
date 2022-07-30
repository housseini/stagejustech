using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class EnbryonnaireCongelationDataController : Controller
    {
        public IActionResult Add(EnbryonnaireCongelationData actData)
        {
            return Json(BLL_EnbryonnaireCongelationData.Add(actData));
        }

        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_EnbryonnaireCongelationData.GetByIdTraitement(Id));
        }

        public IActionResult Update(EnbryonnaireCongelationData actData)
        {
            return Json(BLL_EnbryonnaireCongelationData.Update(actData));
        }
    }
}
