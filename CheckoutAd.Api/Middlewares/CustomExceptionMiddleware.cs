using CheckoutAd.Api.Middlewares.Exceptions;
using CheckoutAd.Api.Models.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CheckoutAd.Api.Middlewares
{
	/// <summary>
	/// Exception handling middleware
	/// </summary>
	public class CustomExceptionMiddleware
	{
		private readonly RequestDelegate _next;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="next"></param>
		public CustomExceptionMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		/// <summary>
		/// Invoke task
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next.Invoke(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

		private async Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			var response = context.Response;
			var customerException = exception as BaseCustomException;
			var statusCode = (int)HttpStatusCode.InternalServerError;
			var message = "Unexpected error";
			var description = "Unexpected error";

			if (null != customerException)
			{
				message = customerException.Message;
				description = customerException.Description;
				statusCode = customerException.Code;
			}

			response.ContentType = "application/json";
			response.StatusCode = statusCode;
			await response.WriteAsync(JsonConvert.SerializeObject(new CustomErrorResponse
			{
				Message = message,
				Description = description
			}));
		}
	}
}