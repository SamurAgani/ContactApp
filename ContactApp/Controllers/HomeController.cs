using ContactApp.Models;
using ContactApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;

namespace ContactApp.Controllers
{
    [Authorize]

    public class HomeController : Controller
    {
        public IContactService _contactService;
        public HomeController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IActionResult Index(string searchText = "")
        {
            List<Entities.Contact> contacts;
            if (string.IsNullOrEmpty(searchText))
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                contacts = _contactService.GetByUserId(int.Parse(userId)).ToList();
            }
            else
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                contacts = _contactService.GetByUserIdAndText(int.Parse(userId), searchText).ToList();
            }
            return View(contacts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
