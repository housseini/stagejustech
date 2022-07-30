using justch.Models.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Controllers
{
    public class DocumentType : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
         }
        [Authorize]
        [HttpGet]
        public IActionResult Gets()
        {
            return Json(BLL_DocumentType.gets());
        }
        [Authorize]
        [HttpGet]
        //retourner la liste Des documment  dont le code est passé en parametre
        public IActionResult GetsDOCUMENbyCode( string Code)
        {
            return Json(BLL_Document.getsBycode(Code));
        }
        //retourner le documenttype selon le code 
        [Authorize]
        [HttpGet]
        public IActionResult getByCode(string Code)
        {
            return Json(BLL_DocumentType.getByCode(Code));
        }
        /// <summary>
        /// <see cref="DocumentType"/>
        /// modifier le documentype selon le code 
        /// 
        /// </summary>
        /// <param name="documment"></param>
        /// <param name="code"></param>
        /// <returns> message selon la requette de la supprission </returns>
        /// 
        [Authorize]
        [HttpPost]
        public IActionResult ModifierDocummentType(justch.Models.ENTITIES.DocumentType documment,string code)
        {
            return Json(BLL_DocumentType.update(documment,code));
        }
        /// <summary>
        /// supprimmer <see cref="DocumentType"/>le documenType selon le code 
        /// </summary>
        /// <param name="code"></param>
        /// <returns>rele message sur la requette effectuter</returns>
        [Authorize]
        [HttpGet]

        public IActionResult Delete(string code)
        {
            return Json(BLL_DocumentType.delete(code));
        }
        /// <summary>
        /// retoure le document dont Id est passé en parametre
        /// </summary>
        /// <param name="id"></param>
        [Authorize]
        [HttpGet]
       public IActionResult GetDocumentById(int id)
        {
            return Json(BLL_Document.getsById(id));
        }

       
    }
}
