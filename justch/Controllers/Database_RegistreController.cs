using justch.Models.BLL;
using justch.Models.ENTITIES;
using justch.Models.Service;
using Microsoft.AspNetCore.Mvc;
using System.Web;
namespace justch.Controllers
{
    public class Database_RegistreController : Controller
    {
    
        public IActionResult Index()
        {
           
            ViewBag.AllAckup= BLL_Database_Registre.GETS();
            ViewBag.BACKUPRO = BLL_BACKUP_Programmer.GETS();

            return View();
        }
        public IActionResult Add(string Cause)
        {
            string name = HttpContext.User.Identity.Name;

            return Json( BLL_Database_Registre.Add(name, Cause));
        }

        public IActionResult Add1( string CAUSEs, string namedata)
        {
            string name = HttpContext.User.Identity.Name;

            return Json( BLL_Database_Registre.Add1(name,CAUSEs, namedata));
        }
        public IActionResult ProgrammerBackup(BACKUP_Programmer programmer)
        {

            return Json(BLL_BACKUP_Programmer.Add(programmer));


        }
    }
}
