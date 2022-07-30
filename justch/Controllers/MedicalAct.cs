using Core.Flash;
using justch.Models.BLL;
using justch.Models.ENTITIES;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class MedicalAct : Controller
    {
        public IFlasher f;
        [Authorize]
        public IActionResult Index()
        {
            ViewBag.Medicalacts = BLL_MedicalAct.gets();
            return View();
        }
        [Authorize]
        public IActionResult Gets()
        {
            return Json(BLL_MedicalAct.gets());
        }

        public MedicalAct(IFlasher f)
        {
            this.f = f;
        }
       [HttpPost]
        public IActionResult Add(justch.Models.ENTITIES.MedicalAct medicalAct)
        {
            var m = BLL_MedicalAct.add(medicalAct);
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
            var m = BLL_MedicalAct.delete(id);
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
        public IActionResult GetByid(int id)
        {
            return Json(BLL_MedicalAct.getByID(id));
        }
        [Authorize]
        [HttpPost]
        public IActionResult Update(justch.Models.ENTITIES.MedicalAct medicalAct)
        {
            var m = BLL_MedicalAct.update(medicalAct);
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
        // //returner LISTE  medical Act Record  SELON IDmedicalcal act
        [Authorize]
        [HttpGet]
        public IActionResult MedicalActRecordsByidmedicalact(int id)
        {
            return Json(BLL_MedicalAct.GetMedicalActPersonnaliser(id));
        }


        //returner medical Act Record 
        [Authorize]
        [HttpGet]
        public IActionResult GetmedicalActRecordByid ( int id )
        {
            return Json(BLL_MedicalRecordAct.getBYiD(id));
        }

        //update medical act Record 
        [Authorize]
        [HttpPost]
        public  IActionResult Updatemedicaactrecord( MedicalRecordAct medicalRecordAct )
        {


            var m = BLL_MedicalRecordAct.update(medicalRecordAct);
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


    }
    
}
