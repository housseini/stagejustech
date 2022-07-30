using Core.Flash;
using justch.Models.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class Doctor : Controller
    {
        public IFlasher f;
        public Doctor(IFlasher f)
        {
            this.f = f;
        }
        [Authorize]
        public IActionResult Index()
        {
            ViewBag.Doctors = BLL_Doctor.gets();
            return View();
        }

        [Authorize]
        public IActionResult Add(justch.Models.ENTITIES.Doctor doctor)
        {

            var m = BLL_Doctor.add(doctor);
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
        public IActionResult Delete(int id)
        {
            var m = BLL_Doctor.Delete(id);
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
        public IActionResult GetBy(int Id)
        {
            return Json(BLL_Doctor.getBy(Id)) ;
        }
        [Authorize]

        [HttpPost]
        public IActionResult Update(justch.Models.ENTITIES.Doctor doctor)
        {
            var m = BLL_Doctor.update(doctor);
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

        public IActionResult Gets()
        {
            return Json(BLL_Doctor.gets());
        }
    }
}
