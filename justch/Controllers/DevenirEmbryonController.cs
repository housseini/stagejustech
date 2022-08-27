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
    public class DevenirEmbryonController : Controller
    {
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult Add(string listenumero, string Devenir, int idculture,int idcongelation,int idtransafert)

        {
            List<int> liste = new List<int>();
            foreach (string t in listenumero.Split(","))
            {
                liste.Add(int.Parse(t));
            }
            return Json(BLL_DevenirEmbryon.Update(liste,  Devenir,  idculture,idcongelation, idtransafert));
        }
        [Authorize(Roles = "Clinicien,Embryologiste")]

        public IActionResult GetByIdTraitement(int Id)
        {
            return Json(BLL_DevenirEmbryon.GetByIdTraitement(Id));
        }


       


    }
}
