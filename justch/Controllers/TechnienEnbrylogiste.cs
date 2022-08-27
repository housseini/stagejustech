using Core.Flash;
using justch.Models.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class TechnienEnbrylogiste : Controller
    {
        public IFlasher f;
        public TechnienEnbrylogiste ( IFlasher f )
        {
            this.f = f;
        }
        [Authorize(Roles = "Admis")]

        public IActionResult Index ( )
        {
            var v = BLL_TechnienEnbrylogiste.Gets();
            if (v != null)
            {
                ViewBag.Techniciens= v;
            }
            else
            {
                ViewBag.Techniciens = null;
            }
            return View();
        }
        [Authorize(Roles = "Admis")]
        [HttpPost]

        public IActionResult Add ( justch.Models.ENTITIES.TechnienEnbrylogiste enbrylogiste)
        {
            var m = BLL_TechnienEnbrylogiste.Add(enbrylogiste);
            if (m.status)
            {
                f.Flash(Types.Success, m.message, dismissable: true);

                return Json(m);
            }

            else
            {
                f.Flash(Types.Danger, m.message, dismissable: true);
                return Json(m);
            }
        }
        [Authorize(Roles = "Admis")]
        [HttpPost]

        public IActionResult Update ( justch.Models.ENTITIES.TechnienEnbrylogiste enbrylogiste )
        {
            var m = BLL_TechnienEnbrylogiste.Update(enbrylogiste);
            if (m.status)
            {
                f.Flash(Types.Success, m.message, dismissable: true);

                return Json(m);
            }

            else
            {
                f.Flash(Types.Danger, m.message, dismissable: true);
                return Json(m);
            }
        }
        [Authorize(Roles = "Admis")]
        [HttpGet]

        public IActionResult Delete ( int ID  )
        {
            var m = BLL_TechnienEnbrylogiste.Delete(ID);
            if (m.status)
            {
                f.Flash(Types.Success, m.message, dismissable: true);

                return Json(m);
            }

            else
            {
                f.Flash(Types.Danger, m.message, dismissable: true);
                return Json(m);
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetById(int id )
        {
            return Json(BLL_TechnienEnbrylogiste.GetsbyId(id));
        }





    }
}
