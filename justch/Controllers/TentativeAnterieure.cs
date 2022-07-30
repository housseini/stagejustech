using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
  
    public class TentativeAnterieureController : Controller
    {
    
        public IActionResult Add(TentativeAnterieur tentative)
        {
            return Json( BLL_TentativeAnterieure.Add(tentative));
        }

        public IActionResult Gets(int IdRenseignement)
        {
            return Json( BLL_TentativeAnterieure.Gets(IdRenseignement));
        }

        public IActionResult GetById(int Id)
        {
            return Json(BLL_TentativeAnterieure.GetById(Id));
        }


        public IActionResult Update(TentativeAnterieur tentative)
        {
            return Json(BLL_TentativeAnterieure.Update(tentative));
        }

        public IActionResult Delete(int Id)
        {
            return Json(BLL_TentativeAnterieure.Delete(Id));
        }


    }
}
