using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class Incubateur_ChambreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        #region methodes Incubateur
        public IActionResult Add(Incubateur incubateur)
        {
            return Json(BLL_Incubateur_Chambre.Add(incubateur));

        }

        public IActionResult GETS()
        {
            return Json(BLL_Incubateur_Chambre.Gets());


        }
        public IActionResult Get(int Id )
        {
            return Json(BLL_Incubateur_Chambre.Get(Id));
        }

        public IActionResult Update(Incubateur incubateur)
        {
            return Json(BLL_Incubateur_Chambre.Update(incubateur));
        }
        public  IActionResult Delete(int Id)
        {
            return Json(BLL_Incubateur_Chambre.Delete(Id));
        }
        #endregion
        #region chambre

        public IActionResult AddCH(Chambre chambre)
        {
            return Json(BLL_Incubateur_Chambre.Add(chambre));
        }

        public IActionResult GetsChambre()
        {
            return Json(BLL_Incubateur_Chambre.GetsChambre());
        }
        public IActionResult GetChambre(int Id)
        {
            return Json(BLL_Incubateur_Chambre.GetChambre(Id));
        }

        public IActionResult Updatechambre(Chambre chambre)
        {
            return Json(BLL_Incubateur_Chambre.Update(chambre));

        }
        public IActionResult DeleteChambre(int Id)
        {
            return Json(BLL_Incubateur_Chambre.DeleteChambre(Id));
        }

        public IActionResult GetsChambreByIdncubateur(int Id)
        {
            return Json(BLL_Incubateur_Chambre.GetsChambreByIdncubateur(Id));
        }


        #endregion
    }
}
