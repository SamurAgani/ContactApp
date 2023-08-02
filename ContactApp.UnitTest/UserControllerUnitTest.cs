using AutoMapper;
using ContactApp.Controllers;
using ContactApp.Entities;
using ContactApp.Services;
using ContactApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Claims;

namespace ContactApp.UnitTest
{
    public class UserControllerUnitTest
    {
        private List<Contact> contacts;
        private Contact contact1;
        private Contact contact2;
        private Contact contact3;
        private User user1;
        private UpdateUserVM userUpdate;
        private List<User> users;
        private UserController userController;
        private Mock<IUserService> userservice;
        private Mock<IMapper> mapper;
        public UserControllerUnitTest()
        {
            user1 = new User() { Email = "Samur@gmail.com", Id = 1, Password = "123!" };
            userUpdate = new UpdateUserVM() { Email = "Samur@gmail.com", Password = "123!" };
            contact1 = new Contact() { Id = 1, Name = "Samur", Surname = "Aganiyev", Number = "123", PhotoUrl = "Url", UserId = 1 };
            contact2 = new Contact() { Id = 2, Name = "Samur2", Surname = "Aganiyev", Number = "123", PhotoUrl = "Url", UserId = 1 };
            contact3 = new Contact() { Id = 3, Name = "Samur3", Surname = "Aganiyev", Number = "123", PhotoUrl = "Url", UserId = 1 };
            users = new List<User>();
            contacts = new List<Contact>();
            users.Add(user1);
            contacts.Add(contact1);
            contacts.Add(contact2);
            contacts.Add(contact3);

            userservice = new Mock<IUserService>();
            mapper = new Mock<IMapper>();
            userController = new UserController(userservice.Object,mapper.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                 new Claim(ClaimTypes.Name, "1"),
                 new Claim(ClaimTypes.NameIdentifier, "Samur@gmail.com"),
                // Add any other claims as needed for your authentication logic
            }, "mock"));
            var controllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            userController.ControllerContext = controllerContext;
        }
        [Test]
        public void Index_ActionExecutes_ReturnView()
        {
            userservice.Setup(u => u.GetByEmail(It.IsAny<string>())).Returns(user1);
            mapper.Setup(u=>u.Map<UpdateUserVM>(user1)).Returns(userUpdate);
            var result = userController.Index() as ViewResult;
            var model = result.Model as UpdateUserVM;

            Assert.AreEqual(model, userUpdate);
        }
    }
}
