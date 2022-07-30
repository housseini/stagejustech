using Core.Flash;
using justch.Models.BLL;
using justch.Models.ENTITIES;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace justch.Controllers
{
    public class Room : Controller
    {
        public IFlasher f;
        public Room(IFlasher f)
        {
            this.f = f;

        }
        [Authorize]
        public IActionResult Index()
        {
            ViewBag.Roomtype = BLL_RoomType.Gets();
            ViewBag.Room = BLL_Room.Gets();
            
            return View();
        }
        [Authorize]
        [HttpPost] 
        public IActionResult UpdatERoom(justch.Models.ENTITIES.Room room)
        {
            return Json(BLL_Room.Update(room));
        }

        [Authorize]

        [HttpGet]
        public IActionResult GetROOMTYPES()
        {
            return Json(BLL_RoomType.Gets());
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetROOMs()
        {
            return Json(BLL_Room.Gets());
        }
        // get list Roomtype by idRoomtype 
        [Authorize]
        [HttpGet]
        public IActionResult GetsBy(int idRoomtype)
        {
            return Json(BLL_RoomType.GetsBy(idRoomtype));
        }
        // get list Room by idRoom
        [Authorize]
        [HttpGet]
        public IActionResult GetByID(int id )
        {
            return Json(BLL_Room.GetByID(id));
        }
        /// <summarnty>
        /// retour le Room  dont le Name est passé en parametre
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
       public IActionResult GetsByNom(string Name)
        {
            return Json(BLL_RoomType.GetsByNom(Name));

        }
        [Authorize]
        [HttpPost]
        public IActionResult AddRoom ( justch.Models.ENTITIES.Room Room )
        {
            var m = BLL_Room.Add(Room);
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
        public IActionResult DeleteRoom ( int id )
        {
            var m = BLL_Room.delete(id);
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
      
        [HttpPost]
        public IActionResult AddRoomType(RoomType RoomType)
        {
            var m = BLL_RoomType.Add(RoomType);
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
        public IActionResult DeleteRoomType ( int id )
        {
            var m = BLL_RoomType.delete(id);
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
        
        public IActionResult UpdateRoomType ( RoomType RoomType )
        {
            var m = BLL_RoomType.Update(RoomType);
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
