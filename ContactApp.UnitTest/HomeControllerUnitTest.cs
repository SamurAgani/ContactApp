using ContactApp.Controllers;
using ContactApp.Entities;
using ContactApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Claims;

namespace ContactApp.UnitTest
{
    public class HomeControllerUnitTest
    {
        private List<Contact> contacts;
        private Contact contact1;
        private Contact contact2;
        private Contact contact3;
        private List<User> users;
        private HomeController homeController;
        private Mock<IContactService> contactService;
        public HomeControllerUnitTest()
        {
            contact1 = new Contact() { Id = 1, Name = "Samur", Surname = "Aganiyev", Number = "123", PhotoUrl = "Url", UserId = 1 };
            contact2 = new Contact() { Id = 2, Name = "Samur2", Surname = "Aganiyev", Number = "123", PhotoUrl = "Url", UserId = 1 };
            contact3 = new Contact() { Id = 3, Name = "Samur3", Surname = "Aganiyev", Number = "123", PhotoUrl = "Url", UserId = 1 };
            users = new List<User>();
            contacts = new List<Contact>();
            users.Add(new User() { Email = "Samur@gmail.com", Id = 1, Password = "123!" });
            contacts.Add(contact1);
            contacts.Add(contact2);
            contacts.Add(contact3);

            contactService = new Mock<IContactService>();
            homeController = new HomeController(contactService.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                 new Claim(ClaimTypes.Name, "TestUser"),
                 new Claim(ClaimTypes.NameIdentifier, "1"),
                // Add any other claims as needed for your authentication logic
            }, "mock"));
            var controllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            homeController.ControllerContext = controllerContext;
        }
        [Test]
        public void Index_ActionExecutes_ReturnView()
        {
            contactService.Setup(u => u.GetByUserId(1)).Returns(contacts);
            var result = homeController.Index("") as ViewResult;
            var model = result.Model as List<Contact>;

            CollectionAssert.Contains(model, contact1);
        }
    }
}