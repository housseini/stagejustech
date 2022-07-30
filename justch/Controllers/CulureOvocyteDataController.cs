using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class CulureOvocyteDataController : Controller
    {
        public IActionResult Add(CulureOvocyteData actData)
        {
            return Json(BLL_CulureOvocyteData.Add(actData));
        }

        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_CulureOvocyteData.GetByIdTraitement(Id));
        }

       
    }
}
