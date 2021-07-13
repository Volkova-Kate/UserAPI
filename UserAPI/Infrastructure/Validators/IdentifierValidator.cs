using FluentValidation;
using UserAPI.Infrastructure.Requests;

namespace UserAPI.Infrastructure.Validators
{
	public class IdentifierValidator<T> : AbstractValidator<T> where T : IIdentifiedRequest
	{
		public IdentifierValidator() => RuleFor(q => q.Id).NotEmpty().BeAValidHexadecimal();
	}
}
