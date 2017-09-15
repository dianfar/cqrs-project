﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MyApp.Domain.Core.Notifications;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Web.Controllers
{
    public class ProjectMemberController : BaseController
    {
        private readonly IProjectMemberAppService projectMemberAppService;

        public ProjectMemberController(
            IProjectMemberAppService projectMemberAppService,
            INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            this.projectMemberAppService = projectMemberAppService;
        }

        [HttpPost]
        public IActionResult Add(ProjectMemberViewModel viewModel)
        {
            if (!ModelState.IsValid) return RedirectToRoute(new
                                                {
                                                    controller = "Project",
                                                    action = "Index"
                                                });
            projectMemberAppService.Add(viewModel);

            return RedirectToRoute(new
            {
                controller = "Project",
                action = "Index"
            });
        }
    }
}
