using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UserAPI.Models;
using UserAPI.Repositories;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class _UsersController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly IMediator _mediator;
        public _UsersController(IMediator mediator) =>
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        //public UsersController(UserRepository userRepository)
        ////использует класс BookService для выполнения операций CRUD;
        //{
        //    _userRepository = userRepository;
        //}

        [HttpGet]
        public ActionResult<List<User>> Get() =>
            _userRepository.Get();

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var user = _userRepository.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet("page")]//pagination
        public ActionResult<List<User>> GetPage(string skip, string count)
        {
            if (!int.TryParse(skip, out var skipValue) || !int.TryParse(count, out var countValue))
                return NotFound();
            return _userRepository.GetPage(skipValue, countValue);
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            _userRepository.Create(user);

            return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User userIn)
        {
            var user = _userRepository.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _userRepository.Update(id, userIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = _userRepository.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _userRepository.Remove(user.Id);

            return NoContent();
        }

    }
}
