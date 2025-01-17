using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelManagement.Models.Driver;
using TravelManagement.Models.Driver.Service;

namespace TravelManagement.Controllers
{
    [Authorize]
    public class DriverController : Controller
    {
        private readonly DriverService _driverService;

        public DriverController(DriverService driverService)
        {
            _driverService = driverService;
        }

        public async Task<IActionResult> Index()
        {
            var drivers = await _driverService.GetAllAsync();
            return View(drivers);
        }

        [HttpPost]
        public async Task<IActionResult> Save(DriverModel input)
        {
            if (input.Id > 0)
                await Update(input);
            else
                await Create(input);

            return RedirectToAction("Index");
        }

        private async Task Create(DriverModel input)
        {
            //if (ModelState.IsValid)
                await _driverService.CreateAsync(input);
        }

        private async Task Update(DriverModel input)
        {
            if (ModelState.IsValid)
                await _driverService.UpdateAsync(input);
        }

        public async Task<IActionResult> Get(long id)
        {
            var driver = await _driverService.GetAsync(id);
            return Json(driver);
        }
    }
}
