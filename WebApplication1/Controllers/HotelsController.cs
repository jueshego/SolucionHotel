using Hotels.Application.DTO.Request;
using Hotels.Application.DTO.Response;
using Hotels.Application.Services;
using Hotels.Domain.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotels.Web.Controllers
{
    public class HotelsController : Controller
    {
        private readonly HotelService _hotelService;

        public HotelsController(HotelService hotelService)
        {
            _hotelService = hotelService;
        }

        // GET: HotelsController
        public ActionResult Index()
        {
            var response = _hotelService.GetAll();

            return View(response.Result);
        }

        // GET: HotelsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HotelsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HotelsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTOHotelNew dtoHotel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _hotelService.Insert(dtoHotel);

                    return RedirectToAction(nameof(Index));
                }

                //ViewData["Error"] = ""

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
            var dtoHotel = _hotelService.GetById(id);

            return View(dtoHotel.Result);
        }

        // POST: HotelsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DTOHotelEdit dtoHotel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _hotelService.Update(dtoHotel); 

                    return RedirectToAction(nameof(Index));
                }

                //ViewData["Error"] = ""

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: HotelsController/Delete/5
        public ActionResult Delete(Guid id)
        {
            _hotelService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
