using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class SpermogrammeTMSController : Controller
    {
        public IActionResult Add(SpermogrammeTMS spermogramme)
        {
            return Json(BLL_SpermogrammeTMS.Add(spermogramme));
        }
        public IActionResult Update(SpermogrammeTMS spermogramme)
        {
            return Json(BLL_SpermogrammeTMS.Update(spermogramme));
        }

        public IActionResult Gets(int Idre)
        {
            return Json(BLL_SpermogrammeTMS.Gets(Idre));
        }

        public IActionResult Get(int Id)
        {
            return Json(BLL_SpermogrammeTMS.GETbyID(Id));
        }
        public IActionResult Delete(int Id)
        {
            return Json(BLL_SpermogrammeTMS.Delete(Id));
        }
    }
}
