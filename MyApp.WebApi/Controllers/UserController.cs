using System;
using System.Collections.Generic;
using MyApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.ViewModels;

namespace MyApp.Web.Controllers
{
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserAppService userAppService;

        public UserController(IUserAppService userAppService)
        {
            this.userAppService = userAppService;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<UserViewModel> GetUsers()
        {
            var users = userAppService.GetAll();
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
