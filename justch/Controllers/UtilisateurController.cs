using justch.Models.BLL;
using justch.Models.DAL;
using justch.Models.ENTITIES;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Controllers
{
    public class UtilisateurController : Controller
    {
        //
        //[Authorize(Roles = "Admis")]
        public IActionResult Index()
        {

            
            return View();
        }
        /// <summaray>
        /// ajouter un utilisateur du systeme 
        /// </summary>   
        /// /// <returns></returns>

 //       [Authorize(Roles = "Admis")]
        [HttpPost]
        public IActionResult Add(Utilisateur utilisateur)
        {
            return Json(BLL_Utilisateur.AddUtilisateur(utilisateur));
        }
        /// <summary>
        /// retourné la liste des tous les utilisateur du systeme
        /// </summary>
        /// <returns></returns>
   
        [HttpGet]
        public IActionResult Gets()
        {
            return Json(BLL_Utilisateur.GetUtilisateurs());
        }
        /// <summary>
        /// retourner utilisateur selon son Id 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public IActionResult GetbyId(int Id)
        {
            return Json(BLL_Utilisateur.GetById(Id));

        }
        /// <summary>
        /// mettre à jours l utilisateur et retourne un message du resultat 
        /// </summary>
        /// <param name="utilisateur"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admis")]
        [HttpPost]
        public IActionResult Update(Utilisateur utilisateur)
        {
            return Json(BLL_Utilisateur.UpdateUtilisateur(utilisateur));
        }
        /// <summary>
        /// supprimmer L utilisateur selon son Id 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public  IActionResult Delete(int Id)
        {
            return Json(BLL_Utilisateur.delete(Id));
        }

        public IActionResult GetUtilisateursEnbrologite()
        {
            return Json(BLL_Utilisateur.GetUtilisateursEnbrologite());
        }

    }
}
