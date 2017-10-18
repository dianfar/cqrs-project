using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;
using MediatR;
using MyApp.Domain.Core.Notifications;

namespace MyApp.WebApi.Controllers.api
{
    [Route("api/roles")]
    public class RolesApiController : BaseApiController
    {
        private readonly IRoleAppService roleAppService;

        public RolesApiController(IRoleAppService roleAppService, INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            this.roleAppService = roleAppService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<RoleViewModel>> GetRoles()
        {
            var roles = await roleAppService.GetAll();
            return roles;
        }
    }
}
