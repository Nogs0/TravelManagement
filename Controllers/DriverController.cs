using Microsoft.AspNetCore.Mvc;
using TravelManagement.Models.Driver.Service;

namespace TravelManagement.Controllers
{
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


    }
}
