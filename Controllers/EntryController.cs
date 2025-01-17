using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelManagement.Dtos.Entries;
using TravelManagement.Models.Driver.Service;
using TravelManagement.Models.Entries;
using TravelManagement.Models.Entries.Service;

namespace TravelManagement.Controllers
{
    [Authorize]
    public class EntryController : Controller
    {
        private readonly EntryService _entryService;
        private readonly DriverService _driverService;
        public EntryController(EntryService entryService, DriverService driverService)
        {
            _entryService = entryService;
            _driverService = driverService;
        }

        public async Task<IActionResult> Index()
        {
            var drivers = await _driverService.GetAllAsync();
            ViewBag.Drivers = drivers;
            var entries = _entryService.GetAll().ToList();

            return View(entries);
        }

        [HttpPost]
        public async Task<IActionResult> Save(EntryInput input)
        {
            if (input.Id > 0)
                await Update(new EntryModel(input));
            else
                await Create(new EntryModel(input));

            return RedirectToAction("Index");
        }

        private async Task Create(EntryModel input)
        {
            //if (ModelState.IsValid)
                await _entryService.CreateAsync(input);
        }

        private async Task Update(EntryModel input)
        {
            if (ModelState.IsValid)
                await _entryService.UpdateAsync(input);
        }

        public async Task<IActionResult> Get(long id)
        {
            return Json(await _entryService.GetAsync(id));
        }
    }
}
