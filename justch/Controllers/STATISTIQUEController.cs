using justch.Models.BLL;

using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class STATISTIQUEController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CountGenre()
        {
            return Json(BLL_STATISTIQUE.COUNTGENRE());
        }
        public IActionResult COUNTdossierType()
        {
            return Json(BLL_STATISTIQUE.COUNTdossierType());
        }
        public IActionResult COUNTMEDICALRECOREType()
        {
            return Json(BLL_STATISTIQUE.COUNTMEDICALRECOREType());
        }
    }
}
