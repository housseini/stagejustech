using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class SpermogrammeTMSController : Controller
    {
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Add(SpermogrammeTMS spermogramme)
        {
            return Json(BLL_SpermogrammeTMS.Add(spermogramme));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Update(SpermogrammeTMS spermogramme)
        {
            return Json(BLL_SpermogrammeTMS.Update(spermogramme));
        }
        [Authorize]


        public IActionResult Gets(int Idre)
        {
            return Json(BLL_SpermogrammeTMS.Gets(Idre));
        }
        [Authorize]

        public IActionResult Get(int Id)
        {
            return Json(BLL_SpermogrammeTMS.GETbyID(Id));
        }
        [Authorize]
        public IActionResult Delete(int Id)
        {
            return Json(BLL_SpermogrammeTMS.Delete(Id));
        }
    }
}
