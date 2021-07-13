using FluentValidation;
using FluentValidation.Validators;

using MongoDB.Bson;

namespace UserAPI.Infrastructure.Validators
{
	public class BeAValidHexadecimalValidator<T, TProperty> : PropertyValidator<T, TProperty>, IBeAValidHexadecimalValidator
	{
		private readonly object _defaultValueForType;

		public BeAValidHexadecimalValidator(object defaultValueForType) : base() =>
			_defaultValueForType = defaultValueForType;
		public override string Name => "NotNullValidator";
		public override bool IsValid(ValidationContext<T> context, TProperty value)
		{
			if (!(value is string))
			{
				return false;
			}

			switch (value)
			{
				case null:
				case string s when string.IsNullOrWhiteSpace(s):
				case string d when !ObjectId.TryParse(d, out ObjectId _):
					return false;
			}

			return true;
		}
	}

	public interface IBeAValidHexadecimalValidator : IPropertyValidator
	{
	}

	public static class BeAValidHexadecimalValidatorExtensinos
	{
		public static IRuleBuilderOptions<T, TProperty> BeAValidHexadecimal<T, TProperty>(
			this IRuleBuilder<T, TProperty> ruleBuilder) =>
			ruleBuilder.SetValidator(new BeAValidHexadecimalValidator<T,TProperty>(default(TProperty)));
	}
}
