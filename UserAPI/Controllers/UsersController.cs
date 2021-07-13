using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserAPI.Features.Users.Commands;
using UserAPI.Features.Users.Queries;
using UserAPI.Models;
using UserAPI.Repositories;

namespace CQRS.Sample.Controllers
{
	//private readonly UserRepository _userRepository;

	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly ILogger<UsersController> _logger;
		private readonly IMediator _mediator;

		public UsersController(IMediator mediator) =>
			_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

		/// <summary>
		///     Постраничное получение продуктов
		/// </summary>
		/// <param name="request"></param>
		/// <param name="token"></param>
		/// <returns></returns>
		[HttpGet]
		[ProducesResponseType(typeof(DataWithTotal<User>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]

		//public async Task<ActionResult<DataWithTotal<User>>> Get() =>
		//	_userRepository.Get();
		public async Task<ActionResult<DataWithTotal<User>>> Get([FromQuery] GetUsersQuery request,
			CancellationToken token) =>
			Ok(await _mediator.Send(request, token));

        /// <summary>
        ///     Создание продукта
        /// </summary>
        /// <param name="client"></param>
        /// <param name="apiVersion"></param>
        /// <param name="token"></param>
        /// <returns></returns>

        //[HttpGet("page")]//pagination
        //public async Task<ActionResult<DataWithTotal<User>>> GetPage(string skip, string count)
        //{
        //	if (!int.TryParse(skip, out var skipValue) || !int.TryParse(count, out var countValue))
        //		return NotFound();
        //	return _userRepository.GetPage(skipValue, countValue);
        //}

        [HttpPost]
        //[ProducesResponseType(typeof(User), StatusCodes.Status201Created)]
        //[ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        //[ProducesDefaultResponseType]
        public async Task<IActionResult> Post([FromBody] AddUsersCommand client,
            CancellationToken token)
        {
            User entity = await _mediator.Send(client, token);
            return CreatedAtAction(nameof(Get), new { id = entity.Id, version = "1" }, entity);
        }


        //[HttpPut]
        //public IActionResult Update(string id, User userIn)
        //{
        //	var user = _userRepository.Get(id);

        //	if (user == null)
        //	{
        //		return NotFound();
        //	}

        //	_userRepository.Update(id, userIn);

        //	return NoContent();
        //}

        //[HttpDelete]
        //public IActionResult Delete(string id)
        //{
        //	var user = _userRepository.Get(id);

        //	if (user == null)
        //	{
        //		return NotFound();
        //	}

        //	_userRepository.Remove(user.Id);

        //	return NoContent();
        //}
    }
}
