using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MyApp.Domain.Core.Notifications;
using MyApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace MyApp.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : BaseController
    {
        private readonly IUserAppService userAppService;

        public UserController(IUserAppService userAppService, INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            this.userAppService = userAppService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await userAppService.GetAll();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var viewModel = await userAppService.GetRegisterNewUserData();
            viewModel.EditMode = false;
            return View("AddEdit", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserFormViewModel userFormViewModel)
        {
            if (!ModelState.IsValid) return View(userFormViewModel);
            userAppService.Create(userFormViewModel);

            if (IsValidOperation())
            {
                return RedirectToAction("Index");
            }
            else
            {
                var viewModel = await userAppService.GetRegisterNewUserData();
                userFormViewModel.Roles = viewModel.Roles;
                userFormViewModel.EditMode = false;
                userFormViewModel.ErrorMessages = GetErrorMessages();
                return View("AddEdit", userFormViewModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await userAppService.GetUpdateUserData(id);
            user.EditMode = true;
            return View("AddEdit", user);
        }

        [HttpPost]
        public IActionResult Edit(UserFormViewModel userViewModel)
        {
            if (!ModelState.IsValid) return View(userViewModel);
            userAppService.Update(userViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete([FromQuery]Guid id)
        {
            userAppService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
