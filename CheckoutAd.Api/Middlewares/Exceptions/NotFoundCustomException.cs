using System.Net;

namespace CheckoutAd.Api.Middlewares.Exceptions
{
	/// <summary>
	/// NotFoundCustomException
	/// </summary>
	public class NotFoundCustomException : BaseCustomException
	{
		/// <summary>
		/// NotFoundCustomException
		/// </summary>
		/// <param name="message"></param>
		/// <param name="description"></param>
		public NotFoundCustomException(string message, string description) : base(message, description, (int)HttpStatusCode.NotFound)
		{
		}
	}
}
