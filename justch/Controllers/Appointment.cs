using Core.Flash;
using justch.Models.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace justch.Controllers
{
    public class Appointment : Controller
    {
        public IFlasher f;
        public Appointment ( IFlasher f )
        {
            this.f = f;
        }
        [Authorize]
        public IActionResult Index ( )
        {
            ViewBag.Patients=BLL_Patient.GetPatients();
            ViewBag.Rooms = BLL_Room.Gets();
            ViewBag.Doctors=BLL_Doctor.gets();
            ViewBag.MedicalActs=BLL_MedicalAct.gets();
            ViewBag.Appointements= BLL_Utiliy.allRdv();
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Add ( justch.Models.ENTITIES.Appointment ap )
        {
            var m = BLL_Appointment.add(ap);
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
        [HttpPost]
        public IActionResult Update ( justch.Models.ENTITIES.Appointment ap )
        {
            var m = BLL_Appointment.update(ap);
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
        public IActionResult Delete ( int ap )
        {
            var m = BLL_Appointment.delete(ap);
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
        public IActionResult GetRdv_Complet ( int Id  )
        {
            return Json(BLL_Appointment.GetRdv_Complet(Id));
        }

        [Authorize]

        [HttpGet]

        public IActionResult Gets ( )
        {
            return Json(BLL_Appointment.gets());
        }
        [Authorize]
        [HttpPost]
        public IActionResult Rechercheravancer(int IPITENT, int Room, DateTime jour, int plage, int Idmedecin, int IdAct)
        {
            return Json(BLL_Appointment.Rechercheravancer(IPITENT,Room,jour,plage,Idmedecin,IdAct));
        }
        /// <summary>
        /// mettre appointement en status terminer 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public IActionResult Terminer( int Id)
        {
            return  Json(BLL_Appointment.terminer(Id)) ;
        }


    }
}
