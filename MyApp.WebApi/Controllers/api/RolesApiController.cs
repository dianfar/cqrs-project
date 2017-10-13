using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;

namespace MyApp.WebApi.Controllers.api
{
    [Route("api/roles")]
    public class RolesApiController : Controller
    {
        private readonly IRoleAppService roleAppService;

        public RolesApiController(IRoleAppService roleAppService)
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
