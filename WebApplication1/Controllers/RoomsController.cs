using Hotels.Application.DTO.Request;
using Hotels.Application.Services;
using Hotels.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hotels.Web.Controllers
{
    public class RoomsController : Controller
    {
        private readonly RoomService _roomService;

        public RoomsController(RoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: HotelsController
        public ActionResult Index(Guid hotelId)
        {
            var response = _roomService.GetListByIdService(hotelId);

            ViewData["hotelId"] = hotelId;  

            return View(response.Result);
        }

        // GET: HotelsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HotelsController/Create
        public ActionResult Create(Guid hotelId)
        {
            var dtoRoom = new DTORoomNew
            {
                HotelId = hotelId
            };

            return View(dtoRoom);
        }

        // POST: HotelsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTORoomNew dtoRoom)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _roomService.Insert(dtoRoom);

                    return RedirectToAction(nameof(Index), new { hotelId = dtoRoom.HotelId });
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: HotelsController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var dtoRoom = _roomService.GetById(id);

            return View(dtoRoom.Result);
        }

        // POST: HotelsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DTORoomEdit dtoRoom)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _roomService.Update(dtoRoom);

                    return RedirectToAction(nameof(Index), new { hotelId = dtoRoom.HotelId });
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: HotelsController/Delete/5
        public ActionResult Delete(Guid id, Guid hotelId)
        {
            _roomService.Delete(id);

            return RedirectToAction(nameof(Index), new { hotelId = hotelId });
        }

        // POST: HotelsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
