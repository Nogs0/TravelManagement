using Microsoft.AspNetCore.Mvc;
using TravelManagement.Models.Driver.Service;
using TravelManagement.Models.Driver;
using TravelManagement.Models.Entries;
using TravelManagement.Models.Entries.Service;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TravelManagement.Controllers
{
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
            ViewBag.Drivers = drivers.Select(x => new SelectListItem(){ Text = x.Name, Value = x.Id.ToString() }).ToList();
            var entries = _entryService.GetAll().ToList();

            return View(entries);
        }

        [HttpPost]
        public async Task<IActionResult> Save(EntryModel input)
        {
            if (input.Id > 0)
                await Update(input);
            else
                await Create(input);

            return RedirectToAction("Index");
        }

        private async Task Create(EntryModel input)
        {
            if (ModelState.IsValid)
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
