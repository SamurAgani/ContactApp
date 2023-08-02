using AutoMapper;
using ContactApp.Entities;
using ContactApp.Services;
using ContactApp.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ContactApp.Controllers
{
    public class UserController : Controller
    {
        public IUserService _userService;
        private IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;

        }
        public IActionResult Index()
        {
            string userMail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var user = _userService.GetByEmail(userMail);
            var userUpdate = _mapper.Map<UpdateUserVM>(user);
            return View(userUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UpdateUserVM userUpdate)
        {
            string userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            int userId = int.Parse(userIdClaim);
            var userCheck = _userService.GetByEmail(userUpdate.Email);
            if (userCheck != null && userCheck.Id != userId)
            {
                ViewData["ValidateMessage"] = "This email is being used!";
                return View();
            }
            var user = _mapper.Map<User>(userUpdate);
            user.Id = userId;
            _userService.UpdateUser(user);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Access");
        }
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserVM createUserVM)
        {
            var user = _userService.GetByEmail(createUserVM.Email);
            if (user == null)
                _userService.CreateUser(_mapper.Map<User>(createUserVM));
            else
            {
                ViewData["ValidateMessage"] = "This email is being used!";
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
