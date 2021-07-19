using System;

namespace UserAPI.Infrastructure.Exceptions
{
	public class UserAPIDomainException : Exception
	{
		public UserAPIDomainException()
		{
		}

		public UserAPIDomainException(string message)
			: base(message)
		{
		}

		public UserAPIDomainException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
