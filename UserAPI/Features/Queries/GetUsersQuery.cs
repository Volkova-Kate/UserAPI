using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserAPI.Infrastructure.Requests;
using UserAPI.Infrastructure.Validators;
using UserAPI.Models;
using UserAPI.Repositories;

namespace UserAPI.Features.Users.Queries
{
	public class GetUsersQuery : IRequest<DataWithTotal<User>>, IPagingRequest
	{
		/// <summary>
		///     Размер страницы
		/// </summary>
		[DefaultValue(10)]
		[FromQuery]
		public int PageSize { get; set; } = 10;

		/// <summary>
		///     Индекс страницы
		/// </summary>
		[DefaultValue(0)]
		[FromQuery]
		public int PageIndex { get; set; } = 0;

		public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, DataWithTotal<User>>
		{
			private readonly ILogger<GetUsersQueryHandler> _logger;
			private readonly IUsersRepository _usersRepository;

			public GetUsersQueryHandler(IUsersRepository usersRepository,
				ILogger<GetUsersQueryHandler> logger)
			{
				_usersRepository = usersRepository;
				_logger = logger;
			}


			public async Task<DataWithTotal<User>> Handle(GetUsersQuery query,
				CancellationToken cancellationToken)
			{
				IEnumerable<User> users =
					await _usersRepository.Get(query.PageSize, query.PageSize * query.PageIndex);
				long total = await _usersRepository.Count();

				return new DataWithTotal<User>(users, (int)total);
			}
		}

		public class GetUsersQueryValidator : PagingValidator<GetUsersQuery>
		{
		}
	}
}
