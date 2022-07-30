using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class EnbryonTransfertDataController : Controller
    {
     
        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_EnbryonTransfertData.GetByIdTraitement(Id));
        }

        public IActionResult Update(EnbryonTransfertData actData)
        {
            return Json(BLL_EnbryonTransfertData.Update(actData));
        }
    }
}
