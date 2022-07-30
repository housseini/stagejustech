using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class AntecedentParticulierController : Controller
    {
        public IActionResult Add(AntecedentParticulier antecedent)
        {
            return Json(BLL_AntecedentParticulier.Add(antecedent));
        }
        public IActionResult Update(AntecedentParticulier antecedent)
        {
            return Json(BLL_AntecedentParticulier.Update(antecedent));
        }
        public IActionResult Gets(int IdReneignement)
        {
            return Json(BLL_AntecedentParticulier.Gets(IdReneignement));
        }

        public IActionResult Delete(int Id)
        {
            return Json(BLL_AntecedentParticulier.Delete(Id));
        }
        public IActionResult Get(int Id)
        {
            return Json(BLL_AntecedentParticulier.GET(Id));
        }
    }
}
