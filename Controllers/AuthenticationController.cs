using Microsoft.AspNetCore.Mvc;
using TravelManagement.Dtos.Authentication;
using TravelManagement.Models.Users;
using TravelManagement.Models.Users.Service;
using TravelManagement.Models.Users.Service.Actions;
using TravelManagement.Services.Authentication;

namespace TravelManagement.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserService _userService;

        public AuthenticationController(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(LoginInput input)
        {
            try
            {
                var user = await _userService.GetByUsernameAsync(input.Username);
                if (!user.IsCorrectPassword(input.Password))
                    throw new Exception("Incorrect Password");

                var token = AuthenticationHelper.GenerateJWTToken(user);

                HttpContext.Response.Cookies.Append(AuthenticationConsts.CookieAuthName, token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    Expires = DateTime.UtcNow.AddHours(6)
                });

                return RedirectToAction("Index", "Driver");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public async Task<IActionResult> Register(SignUpInput input)
        {
            try
            {
                var user = await _userService.CreateAsync(new UserModel(input));
                return await Login(new LoginInput() { Username = input.Username, Password = input.Password});
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public async Task<IActionResult> Logout()
        {
            try
            {
                Response.Cookies.Delete(AuthenticationConsts.CookieAuthName);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
