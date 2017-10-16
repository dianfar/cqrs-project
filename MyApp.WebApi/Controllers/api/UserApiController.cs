using System;
using System.Collections.Generic;
using MyApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.ViewModels;
using System.Threading.Tasks;

namespace MyApp.Web.Controllers
{
    [Route("api/users")]
    public class UserApiController : Controller
    {
        private readonly IUserAppService userAppService;

        public UserApiController(IUserAppService userAppService)
        {
            this.userAppService = userAppService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<UserViewModel>> GetUsers()
        {
            var users = await userAppService.GetAll();
            return users;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Add([FromBody] UserViewModel userViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            userAppService.Create(userViewModel);

            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<UserViewModel> GetUser(Guid id)
        {
            var user = await userAppService.GetById(id);
            return user;
        }

        [HttpPut]
        [Route("")]
        public IActionResult Edit([FromBody] UserViewModel userViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            userAppService.Update(userViewModel);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            userAppService.Remove(id);
            return Ok();
        }
    }
}
