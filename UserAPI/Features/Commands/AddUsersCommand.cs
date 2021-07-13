using System;
using System.Threading;
using System.Threading.Tasks;

using FluentValidation;

using MediatR;
using UserAPI.Models;
using UserAPI.Repositories;

namespace UserAPI.Features.Users.Commands
{
	public class AddUsersCommand : IRequest<User> //интерфейс команды
	{
		/// <summary>
		///     Имя
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		///     Фамилия
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		///     Номер телефона
		/// </summary>
		public string Number { get; set; }

		public class AddUserCommandHandler : IRequestHandler<AddUsersCommand, User> //обработчик нашей команды
		{
			private readonly IUsersRepository _usersRepository;

			public AddUserCommandHandler(IUsersRepository usersRepository) => _usersRepository =
				usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));

			public async Task<User> Handle(AddUsersCommand command, CancellationToken cancellationToken)
			{
				User user = new User();
				user.FirstName = command.FirstName;
				user.LastName = command.LastName;
				user.Number = command.Number;

				await _usersRepository.Add(user);
				return user;
			}
		}

		public class AddUserCommandValidator : AbstractValidator<AddUsersCommand>
		{
			public AddUserCommandValidator()
			{
				RuleFor(c => c.FirstName).NotEmpty();
				RuleFor(c => c.LastName).NotEmpty();
				RuleFor(c => c.Number).NotEmpty();
			}
		}
	}
}
