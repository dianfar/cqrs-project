using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using MyApp.Domain.Core.Notifications;
using MyApp.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MyApp.Application.Interfaces;
using Microsoft.AspNetCore.Authentication;

namespace MyApp.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountAppService accountAppService;

        public AccountController(
            IAccountAppService accountAppService,
            INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            this.accountAppService = accountAppService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

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

            return RedirectToRoute(new
            {
                controller = "Project",
                action = "Index"
            });
        }

        [HttpGet]
        public IActionResult Forbidden()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Unauthorize()
        {
            return View();
        }
    }
}
