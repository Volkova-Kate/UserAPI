using FluentValidation;
using UserAPI.Infrastructure.Requests;

namespace UserAPI.Infrastructure.Validators
{
	public class PagingValidator<T> : AbstractValidator<T> where T : IPagingRequest
	{
		protected PagingValidator()
		{
			RuleFor(q => q.PageSize).GreaterThan(0);
			RuleFor(q => q.PageIndex).GreaterThanOrEqualTo(0);
		}
	}
}
