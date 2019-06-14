using System;

namespace CheckoutAd.Api.Middlewares.Exceptions
{
	/// <summary>
	/// BaseCustomException
	/// </summary>
	public class BaseCustomException : Exception
	{
		private readonly int _code;
		private readonly string _description;

		/// <summary>
		/// Code
		/// </summary>
		public int Code
		{
			get => _code;
		}

		/// <summary>
		/// Description
		/// </summary>
		public string Description
		{
			get => _description;
		}

		/// <summary>
		/// BaseCustomException
		/// </summary>
		/// <param name="message"></param>
		/// <param name="description"></param>
		/// <param name="code"></param>
		public BaseCustomException(string message, string description, int code) : base(message)
		{
			_code = code;
			_description = description;
		}
	}
}