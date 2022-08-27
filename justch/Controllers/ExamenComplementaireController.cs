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
    public class ExamenComplementaireController : Controller
    {
        /// <summary>
        /// ajouter examen complementaire 
        /// </summary>
        /// <param name="examen"></param>
        /// <returns></returns>
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Add(ExamenComplementaire examen)
        {
            return Json(BLL_ExamenComplementaire.Add(examen));
        }

        /// <summary>
        /// retour la liste 
        /// </summary>
        /// <param name="IdREnseignement"></param>
        /// <returns></returns>
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Gets(int IdREnseignement )
        {
            return Json(BLL_ExamenComplementaire.Gets(IdREnseignement));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult GetsbyID(int Id)
        {
            return Json(BLL_ExamenComplementaire.GetbyId(Id));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Update(ExamenComplementaire examen)
        {
            return Json(BLL_ExamenComplementaire.Update(examen));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Delete(int Id)
        {
            return Json(BLL_ExamenComplementaire.Delete(Id));
        }

    }
}
