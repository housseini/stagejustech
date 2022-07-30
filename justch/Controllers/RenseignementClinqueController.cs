using justch.Models.BLL;
using justch.Models.ENTITIES;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Controllers
{
    public class RenseignementClinqueController : Controller
    {

        /// <summary>
        /// ajouter 
        /// </summary>
        /// <param name="renseignementClinque"></param>
        /// <returns></returns>
        public IActionResult Add(RenseignementClinque renseignementClinque)
        {
            return Json(BLL_RenseignementClinique.Add(renseignementClinque)) ;
        }
        /// <summary>
        /// retourner selon id dossier merdical
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult GetbyIddossiermedicale(int id)
        {
            return Json(BLL_RenseignementClinique.GETBYIDMEDICALE(id));
        }/// <summary>
        /// modification 
        /// </summary>
        /// <param name="renseignementClinque"></param>
        /// <returns></returns>

        public IActionResult Update(RenseignementClinque renseignementClinque)
        {
            return Json(BLL_RenseignementClinique.Update(renseignementClinque));
        }
    }
}
