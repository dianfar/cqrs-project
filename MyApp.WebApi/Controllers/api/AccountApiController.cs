using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.ViewModels;
using MyApp.Application.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using MediatR;
using MyApp.Domain.Core.Notifications;

namespace MyApp.WebApi.Controllers.api
{
    [Route("api/account")]
    public class AccountApiController : BaseApiController
    {
        private readonly IAccountAppService accountAppService;

        public AccountApiController(IAccountAppService accountAppService, INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            this.accountAppService = accountAppService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel viewModel)
        {
            var user = await accountAppService.Login(viewModel);

            if (user == null)
            {
                return RedirectToAction("Unauthorize");
            }

            List<Claim> userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.RoleName)
            };

            ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(userClaims, "CustomClaims"));
            await HttpContext.SignInAsync(principal);

            return Ok();
        }
    }
}
