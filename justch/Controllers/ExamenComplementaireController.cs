using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.BLL;
using justch.Models.ENTITIES;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class ExamenComplementaireController : Controller
    {
        /// <summary>
        /// ajouter examen complementaire 
        /// </summary>
        /// <param name="examen"></param>
        /// <returns></returns>
        public IActionResult Add(ExamenComplementaire examen)
        {
            return Json(BLL_ExamenComplementaire.Add(examen));
        }

        /// <summary>
        /// retour la liste 
        /// </summary>
        /// <param name="IdREnseignement"></param>
        /// <returns></returns>

        public IActionResult Gets(int IdREnseignement )
        {
            return Json(BLL_ExamenComplementaire.Gets(IdREnseignement));
        }

        public IActionResult GetsbyID(int Id)
        {
            return Json(BLL_ExamenComplementaire.GetbyId(Id));
        }

        public IActionResult Update(ExamenComplementaire examen)
        {
            return Json(BLL_ExamenComplementaire.Update(examen));
        }

        public IActionResult Delete(int Id)
        {
            return Json(BLL_ExamenComplementaire.Delete(Id));
        }

    }
}
