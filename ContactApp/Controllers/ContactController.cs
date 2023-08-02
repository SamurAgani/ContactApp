using AutoMapper;
using ContactApp.Entities;
using ContactApp.Services;
using ContactApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ContactApp.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        public IContactService _contactService;
        private IMapper _mapper;
        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactVM createContactVM)
        {
            // adding userId to the VM and Create
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            createContactVM.UserId = int.Parse(userId);
            _contactService.CreateContact(createContactVM);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Update(int Id)
        {
            var contact = _contactService.GetById(Id);
            return View(_mapper.Map<UpdateContactVM>(contact));
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateContactVM createContactVM)
        {
            // adding userId to the VM and Update
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            createContactVM.UserId = int.Parse(userId);
            _contactService.UpdateContact(createContactVM);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int ContactId)
        {
            var contact = _contactService.GetById(ContactId);
            _contactService.DeleteContact(contact);
            return Ok();
        }

    }
}
