using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using MyApp.Domain.Core.Notifications;
using MyApp.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MyApp.Application.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;

namespace MyApp.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountAppService accountAppService;
        private readonly ILogger logger;

        public AccountController(
            IAccountAppService accountAppService,
            ILogger<AccountController> logger,
            INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            this.accountAppService = accountAppService;
            this.logger = logger;
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
                this.logger.LogWarning(1, string.Format("User {0} Unauthorize", viewModel.Email));
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
            this.logger.LogInformation(1, string.Format("User {0} Logged in", viewModel.Email));

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
